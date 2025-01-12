﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using GenHTTP.Api.Content;

namespace GenHTTP.Testing.Acceptance
{

    public static class TestExtensions
    {

        #region Supporting data structures

        private class HandlerBuilder : IHandlerBuilder
        {
            private IHandler _Handler;

            public HandlerBuilder(IHandler handler) { _Handler = handler; }

            public IHandler Build(IHandler parent)
            {
                return _Handler;
            }

        }

        #endregion

        public static string GetContent(this HttpWebResponse response)
        {
            using var stream = response.GetResponseStream();
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        public static HashSet<string> GetSitemap(this HttpWebResponse response)
        {
            var content = response.GetContent();

            var sitemap = XDocument.Parse(content);

            var namespaces = new XmlNamespaceManager(new NameTable());

            namespaces.AddNamespace("n", "http://www.sitemaps.org/schemas/sitemap/0.9");

            return sitemap.Root.XPathSelectElements("//n:loc", namespaces)
                               .Select(x => new Uri(x.Value).AbsolutePath)
                               .ToHashSet();
        }

        public static HttpWebResponse GetSafeResponse(this WebRequest request)
        {
            try
            {
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                var response = e.Response as HttpWebResponse;

                if (response != null)
                {
                    return response;
                }
                else
                {
                    throw;
                }
            }
        }

        public static DateTime WithoutMS(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
        }

        public static void IgnoreSecurityErrors(this HttpWebRequest request)
        {
            request.ServerCertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) =>
            {
                return true;
            };
        }

        public static IHandlerBuilder Wrap(this IHandler handler) => new HandlerBuilder(handler);

    }

}
