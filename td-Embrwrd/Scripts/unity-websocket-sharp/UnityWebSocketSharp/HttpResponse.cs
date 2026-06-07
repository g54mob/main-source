using System;
using System.Collections.Specialized;
using System.IO;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp
{
	internal class HttpResponse : HttpBase
	{
		private int _code;

		private string _reason;

		internal string StatusLine => null;

		public bool CloseConnection => false;

		public CookieCollection Cookies => null;

		public bool IsProxyAuthenticationRequired => false;

		public bool IsRedirect => false;

		public bool IsSuccess => false;

		public bool IsUnauthorized => false;

		public bool IsWebSocketResponse => false;

		public override string MessageHeader => null;

		public string Reason => null;

		public int StatusCode => 0;

		private HttpResponse(int code, string reason, Version version, NameValueCollection headers)
			: base(null, null)
		{
		}

		internal HttpResponse(int code)
			: base(null, null)
		{
		}

		internal HttpResponse(HttpStatusCode code)
			: base(null, null)
		{
		}

		internal HttpResponse(int code, string reason)
			: base(null, null)
		{
		}

		internal HttpResponse(HttpStatusCode code, string reason)
			: base(null, null)
		{
		}

		internal static HttpResponse CreateCloseResponse(HttpStatusCode code)
		{
			return null;
		}

		internal static HttpResponse CreateUnauthorizedResponse(string challenge)
		{
			return null;
		}

		internal static HttpResponse CreateWebSocketHandshakeResponse()
		{
			return null;
		}

		internal static HttpResponse Parse(string[] messageHeader)
		{
			return null;
		}

		internal static HttpResponse ReadResponse(Stream stream, int millisecondsTimeout)
		{
			return null;
		}

		public void SetCookies(CookieCollection cookies)
		{
		}
	}
}
