﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using GenHTTP.Api.Protocol;

namespace GenHTTP.Api.Infrastructure
{

    public interface IServerExtension
    {
        
        void Intercept(IRequest request, IResponse response);

    }

}