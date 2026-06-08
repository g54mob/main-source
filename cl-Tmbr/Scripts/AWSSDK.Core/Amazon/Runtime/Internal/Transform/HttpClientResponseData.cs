using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Amazon.Runtime.Internal.Transform
{
	public class HttpClientResponseData : IWebResponseData
	{
		private HttpResponseMessageBody _response;

		private string[] _headerNames;

		private Dictionary<string, string> _headers;

		private HashSet<string> _headerNamesSet;

		public HttpStatusCode StatusCode { get; private set; }

		public bool IsSuccessStatusCode { get; private set; }

		public string ContentType { get; private set; }

		public long ContentLength { get; private set; }

		public IHttpResponseBody ResponseBody => _response;

		internal HttpClientResponseData(HttpResponseMessage response)
			: this(response, null, disposeClient: false)
		{
		}

		internal HttpClientResponseData(HttpResponseMessage response, HttpClient httpClient, bool disposeClient)
		{
			_response = new HttpResponseMessageBody(response, httpClient, disposeClient);
			StatusCode = response.StatusCode;
			IsSuccessStatusCode = response.IsSuccessStatusCode;
			ContentLength = response.Content.Headers.ContentLength.GetValueOrDefault();
			if (response.Content.Headers.ContentType != null)
			{
				ContentType = response.Content.Headers.ContentType.MediaType;
			}
			CopyHeaderValues(response);
		}

		public string GetHeaderValue(string headerName)
		{
			if (_headers.TryGetValue(headerName, out var value))
			{
				return value;
			}
			return string.Empty;
		}

		public bool IsHeaderPresent(string headerName)
		{
			return _headerNamesSet.Contains(headerName);
		}

		public string[] GetHeaderNames()
		{
			return _headerNames;
		}

		private void CopyHeaderValues(HttpResponseMessage response)
		{
			List<string> list = new List<string>();
			_headers = new Dictionary<string, string>(10, StringComparer.OrdinalIgnoreCase);
			foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
			{
				list.Add(header.Key);
				string firstHeaderValue = GetFirstHeaderValue(response.Headers, header.Key);
				_headers.Add(header.Key, firstHeaderValue);
			}
			if (response.Content != null)
			{
				foreach (KeyValuePair<string, IEnumerable<string>> header2 in response.Content.Headers)
				{
					if (!list.Contains(header2.Key))
					{
						list.Add(header2.Key);
						string firstHeaderValue2 = GetFirstHeaderValue(response.Content.Headers, header2.Key);
						_headers.Add(header2.Key, firstHeaderValue2);
					}
				}
			}
			_headerNames = list.ToArray();
			_headerNamesSet = new HashSet<string>(_headerNames, StringComparer.OrdinalIgnoreCase);
		}

		private string GetFirstHeaderValue(HttpHeaders headers, string key)
		{
			IEnumerable<string> values = null;
			if (headers.TryGetValues(key, out values))
			{
				return values.FirstOrDefault();
			}
			return string.Empty;
		}
	}
}
