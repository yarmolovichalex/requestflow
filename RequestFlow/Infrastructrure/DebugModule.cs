﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestFlow.Infrastructrure
{
    public class DebugModule : IHttpModule
    {
        private static List<string> requestUrls = new List<string>();
        private static object lockObject = new object();

        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += (sender, args) =>
            {
                lock (lockObject)
                {
                    if (app.Request.RawUrl == "/Stats")
                    {
                        app.Response.Write(string.Format("<div>There have been {0} requests</div>", requestUrls.Count));
                        app.Response.Write("<table><tr><th>ID</th><th>URL</th></tr>");
                        for (int i = 0; i < requestUrls.Count; i++)
                        {
                            app.Response.Write(string.Format("<tr><td>{0}</td><td>{1}</td></tr>", i, requestUrls[i]));
                        }
                        app.CompleteRequest();
                    }
                    else
                    {
                        requestUrls.Add(app.Request.RawUrl);
                    }
                }
            };
        }
    }
}