﻿using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

using GenHTTP.Api.Content;
using GenHTTP.Api.Protocol;

using GenHTTP.Modules.Basics;
using GenHTTP.Modules.Controllers;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Layouting;

namespace GenHTTP.Testing.Acceptance.Modules.Controllers
{ 

    public class RoutingTests
    {

        #region Supporting data structures

        public class RouteController
        {

            public IHandlerBuilder Appenders([FromPath] int one, [FromPath] string two)
            {
                return new AppenderDependentHandlerBuilder();
            }

            public IHandlerBuilder Nested([FromPath] int one, [FromPath] string two)
            {
                return Layout.Create()
                             .Add("inner", new AppenderDependentHandlerBuilder());
            }

            public IHandlerBuilder InnerController([FromPath] int i)
            {
                return Layout.Create()
                             .Add((i + 1).ToString(), Controller.From<RouteController>());
            }

            public IHandlerBuilder Index() => Content.From("Index");

            public IHandlerBuilder DoSomethingWithController()
            {
                return Redirect.To("{controller}/", true);
            }

            public IHandlerBuilder DoSomethingWithIndex()
            {
                return Redirect.To("{index}/", true);
            }

            public IHandlerBuilder DoSomethingWithParent()
            {
                return Redirect.To("{fallback}/test", true);
            }

            public IHandlerBuilder DoSomethingWithAppenders()
            {
                return Redirect.To("appenders/1/2/", true);
            }

        }

        public class AppenderDependentHandlerBuilder : IHandlerBuilder
        {

            public IHandler Build(IHandler parent) => new AppenderDependentHandler(parent);

        }

        public class AppenderDependentHandler : IHandler
        {

            public IHandler Parent { get; }

            public AppenderDependentHandler(IHandler parent)
            {
                Parent = parent;
            }

            public IEnumerable<ContentElement> GetContent(IRequest request)
            {
                var root = this.GetRoot(request, false);

                var info = ContentInfo.Create()
                                      .Title("My File")
                                      .Build();

                yield return new ContentElement(root, info, ContentType.ApplicationForceDownload);
            }

            public IResponse? Handle(IRequest request)
            {
                return Content.From(GetContent(request).Select(c => c.Path).First())
                              .Build(this)
                              .Handle(request);
            }

        }

        #endregion

        #region Tests

        [Fact]
        public void TestAppenders()
        {
            using var runner = Setup();

            using var response = runner.GetResponse("/r/appenders/1/test/");

            Assert.Equal("/r/appenders/1/test/", response.GetContent());
        }

        [Fact]
        public void TestNested()
        {
            using var runner = Setup();

            using var response = runner.GetResponse("/r/nested/1/test/inner");

            Assert.Equal("/r/nested/1/test/inner", response.GetContent());
        }

        /// <summary>
        /// Ensure that nesting of controllers is possible and
        /// routing still works as expected.
        /// </summary>
        [Fact]
        public void TestInner()
        {
            using var runner = Setup();

            using var response = runner.GetResponse("/r/inner-controller/1/2/inner-controller/3/4/appenders/5/6/");

            Assert.Equal("/r/inner-controller/1/2/inner-controller/3/4/appenders/5/6/", response.GetContent());
        }

        [Fact]
        public void TestRoutingToController()
        {
            using var runner = Setup();

            using var response = runner.GetResponse("/r/do-something-with-controller/");

            Assert.Equal("/r/", new Uri(response.Headers["Location"]).AbsolutePath);
        }

        [Fact]
        public void TestRoutingToIndex()
        {
            using var runner = Setup();

            using var response = runner.GetResponse("/r/do-something-with-index/");

            Assert.Equal("/r/", new Uri(response.Headers["Location"]).AbsolutePath);
        }

        [Fact]
        public void TestRoutingToParent()
        {
            using var runner = Setup();

            using var response = runner.GetResponse("/r/do-something-with-parent/");

            Assert.Equal("/test", new Uri(response.Headers["Location"]).AbsolutePath);
        }

        [Fact]
        public void TestRoutingToAppender()
        {
            using var runner = Setup();

            using var response = runner.GetResponse("/r/do-something-with-appenders/");

            Assert.Equal("/r/appenders/1/2/", new Uri(response.Headers["Location"]).AbsolutePath);
        }

        #endregion

        #region Helpers

        private TestRunner Setup()
        {
            var layout = Layout.Create()
                               .AddController<RouteController>("r")
                               .Fallback(Content.From("Blubb"));

            return TestRunner.Run(layout);
        }

        #endregion

    }

}
