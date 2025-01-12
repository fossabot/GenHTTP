﻿using System.Collections.Generic;

using GenHTTP.Api.Content;
using GenHTTP.Api.Content.Templating;
using GenHTTP.Api.Protocol;

using GenHTTP.Modules.Basics;

namespace GenHTTP.Modules.Placeholders.Providers
{

    public class PageProvider : IHandler
    {

        #region Get-/Setters

        public IHandler Parent { get; }

        public ContentInfo PageInfo { get; }

        public IResourceProvider Content { get; }

        #endregion

        #region Initialization

        public PageProvider(IHandler parent, ContentInfo pageInfo, IResourceProvider content)
        {
            Parent = parent;

            PageInfo = pageInfo;
            Content = content;
        }

        #endregion

        #region Functionality

        public IResponse? Handle(IRequest request)
        {
            var templateModel = new TemplateModel(request, this, PageInfo, Content.GetResourceAsString());

            return this.Page(templateModel)
                       .Build();
        }

        public IEnumerable<ContentElement> GetContent(IRequest request) => this.GetContent(request, PageInfo, ContentType.TextHtml);

        #endregion

    }

}
