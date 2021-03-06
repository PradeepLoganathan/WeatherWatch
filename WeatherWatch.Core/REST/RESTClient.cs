﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherWatch.Core.REST
{
    internal class RESTClient
    {
        private int _MaxRetryCount;

        internal JsonSerializer Serializer { get; set; }
        internal Uri BaseURL { get; set; }
        internal List<KeyValuePair<string, string>> QueryString { get; }
        internal Encoding Encoding { get; } = new UTF8Encoding(false);

        public RESTClient(Uri BaseURL, JsonSerializer Serializer )
        {
            this.BaseURL = BaseURL;
            this.Serializer = Serializer;
        }

        public int MaxRetryCount
        {
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else
                    _MaxRetryCount = value;
            }
            get
            {
                return _MaxRetryCount;
            }
        }
        public void AddQueryString(string Key, string Value)
        {
            QueryString.Add(new KeyValuePair<string, string>(Key, Value));
        }

        public RESTRequest Create(string endpoint)
        {
            return new RESTRequest(this, endpoint);
        }

        


    }
}
