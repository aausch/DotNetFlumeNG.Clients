﻿// 
//    Copyright 2013 Mark Lamley
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System;
using System.Globalization;
using DotNetFlumeNG.Client.Avro;
using DotNetFlumeNG.Client.Core;
using DotNetFlumeNG.Client.Thrift;

namespace DotNetFlumeNG.Client
{
    internal static partial class FlumeClientFactory
    {
        public static IFlumeClient CreateClient()
        {
            if (_client == null || _client.IsClosed)
            {
                switch (_clientType)
                {
                    case ClientType.Thrift:
                        _client = new ThriftClient(_host, _port);
                        break;

                    case ClientType.Avro:
                        _client = new AvroClient(_host, _port);
                        break;

                    default:
                        throw new NotSupportedException(
                            string.Format(CultureInfo.InvariantCulture,
                                          "The client type [{0}] is not supported. The only supported type is Thrift.",
                                          _clientType));
                }
            }

            return _client;
        }
    }
}