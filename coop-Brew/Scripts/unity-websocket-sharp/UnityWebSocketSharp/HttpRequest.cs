using System;
using System.Collections.Specialized;
using System.IO;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp
{
	internal class HttpRequest : HttpBase
	{
		private CookieCollection _cookies;

		private string _method;

		private string _target;

		internal string RequestLine => null;

		public AuthenticationResponse AuthenticationResponse => null;

		public CookieCollection Cookies => null;

		public string HttpMethod => null;

		public bool IsWebSocketRequest => false;

		public override string MessageHeader => null;

		public string RequestTarget => null;

		private HttpRequest(string method, string target, Version version, NameValueCollection headers)
			: base(null, null)
		{
		}

		internal HttpRequest(string method, string target)
			: base(null, null)
		{
		}

		internal static HttpRequest CreateConnectRequest(Uri targetUri)
		{
			return null;
		}

		internal static HttpRequest CreateWebSocketHandshakeRequest(Uri targetUri)
		{
			return null;
		}

		internal HttpResponse GetResponse(Stream stream, int millisecondsTimeout)
		{
			return null;
		}

		internal static HttpRequest Parse(string[] messageHeader)
		{
			return null;
		}

		internal static HttpRequest ReadRequest(Stream stream, int millisecondsTimeout)
		{
			return null;
		}

		public void SetCookies(CookieCollection cookies)
		{
		}
	}
}
