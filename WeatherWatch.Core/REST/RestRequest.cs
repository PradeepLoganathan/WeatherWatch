using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWatch.Core.REST
{
    internal class RESTRequest
    {
        private readonly RESTClient _client;
        private readonly string _endpoint;
        private List<KeyValuePair<string,string>> _QueryString;
        private List<KeyValuePair<string, string>> _URLSegment;
        private object _body;

        public RESTRequest(RESTClient client, string EndPoint)
        {
            _client = client;
            _endpoint = EndPoint;
        }

        public RESTRequest AddParameter(KeyValuePair<string, string> pair, ParameterType pType = ParameterType.QueryString)
        {
            AddParameter(pair.Key, pair.Value, pType);
            return this;
        }

        public RESTRequest AddParameter(string Key, string Value, ParameterType pType = ParameterType.QueryString)
        {
            switch (pType)
            {
                case ParameterType.QueryString:
                    return AddQueryString(Key, Value);
                case ParameterType.URLSegment:
                    return AddURLSegment(Key, Value);
            }
            return this;

        }

        public RESTRequest AddQueryString(string Key, string Value)
        {
            if (_QueryString == null)
            {
                _QueryString = new List<KeyValuePair<string, string>>();
                _QueryString.Add(new KeyValuePair<string, string>(Key, Value));
            }
            else
            {
                _QueryString.Add(new KeyValuePair<string, string>(Key, Value));
            }

            return this;
        }

        public RESTRequest AddURLSegment(string Key, string Value)
        {
            if (_URLSegment == null)
            {
                _URLSegment = new List<KeyValuePair<string, string>>();
                _URLSegment.Add(new KeyValuePair<string, string>(Key, Value));
            }
            else
            {
                _URLSegment.Add(new KeyValuePair<string, string>(Key, Value));
            }

            return this;
        }

        private HttpRequestMessage PrepareRequest(HttpMethod method)
        {
            StringBuilder sbQueryString = new StringBuilder();
            string EndPoint = _endpoint;

            if (_QueryString != null)
            {
                foreach (KeyValuePair<string, string> pair in _QueryString)
                    AppendQueryString(sbQueryString, pair);
            }

            if (_URLSegment != null)
            {
                foreach (KeyValuePair<string, string> pair in _URLSegment)
                {
                    EndPoint = EndPoint.Replace("{" + pair.Key + "}", pair.Value);
                }
            }
            
            UriBuilder builder = new UriBuilder()

        }

        private void AppendQueryString(StringBuilder sbQueryString, KeyValuePair<string, string> pair)
        {
            if (sbQueryString.Length > 0)
            {
                sbQueryString.Append("&");
                sbQueryString.Append(WebUtility.UrlEncode(pair.Key));
                sbQueryString.Append("=");
                sbQueryString.Append(WebUtility.UrlEncode(pair.Value));

            }
        }

        private async Task<HttpResponseMessage> SendInternal(HttpMethod Method)
        {
            int _timestotry = _client.MaxRetryCount + 1;

            do
            {

            } while (_timestotry-- > 0);
        }


    }
}
