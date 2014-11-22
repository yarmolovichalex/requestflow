﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestFlow.Infrastructrure
{
    public class InfoHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.RawUrl == "/Test/Index")
            {
                context.Server.TransferRequest("/Home/Index");
            }
            else
            {
                context.Response.Write("Content generated by InfoHandler");
            }
        }
    }
}