﻿using System;
using System.Collections.Generic;
using System.Text;

using GenHTTP.Api.Infrastructure;
using GenHTTP.Api.Protocol;

namespace GenHTTP.Core.Infrastructure
{

    internal class ConsoleCompanion : IServerCompanion
    {

        public void OnRequestHandled(IRequest request, IResponse response, Exception? error)
        {
            Console.WriteLine($"REQ - {request.Handler.IPAddress} - {request.Method.RawMethod} {request.Path} - {response.Status.RawStatus} - {response.ContentLength ?? 0}");

            if (error != null)
            {
                Console.WriteLine($"REQ - {error}");
            }
        }

        public void OnServerError(ServerErrorScope scope, Exception error)
        {
            Console.WriteLine($"ERR - {scope} - {error}");
        }

    }

}
