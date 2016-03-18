﻿#region Copyright
// /************************************************************************
//    Copyright (c) 2016 Jamie Rees
//    File: TvMazeApi.cs
//    Created By: Jamie Rees
//   
//    Permission is hereby granted, free of charge, to any person obtaining
//    a copy of this software and associated documentation files (the
//    "Software"), to deal in the Software without restriction, including
//    without limitation the rights to use, copy, modify, merge, publish,
//    distribute, sublicense, and/or sell copies of the Software, and to
//    permit persons to whom the Software is furnished to do so, subject to
//    the following conditions:
//   
//    The above copyright notice and this permission notice shall be
//    included in all copies or substantial portions of the Software.
//   
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
//    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//  ************************************************************************/
#endregion
using System;
using System.Collections.Generic;

using NLog;

using PlexRequests.Api.Models.Tv;

using RestSharp;

namespace PlexRequests.Api
{
    public class TvMazeApi : TvMazeBase
    {
        public TvMazeApi()
        {
            Api = new ApiRequest();
        }
        private ApiRequest Api { get;  }
        private static Logger Log = LogManager.GetCurrentClassLogger();
        public List<TvMazeSearch> Search(string searchTerm)
        {
            var request = new RestRequest
            {
                Method = Method.GET,
                Resource = "search/shows?q={searchTerm}"
            };
            request.AddUrlSegment("searchTerm", searchTerm);
            request.AddHeader("Content-Type", "application/json");

            return Api.Execute<List<TvMazeSearch>>(request, new Uri(Uri));
        }

    }
}