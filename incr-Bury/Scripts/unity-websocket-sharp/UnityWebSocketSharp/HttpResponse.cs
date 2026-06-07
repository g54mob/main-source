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

		internal string StatusLine
		{
			get
			{
				if (_reason == null)
				{
					return $"HTTP/{base.ProtocolVersion} {_code}{HttpBase.CrLf}";
				}
				return $"HTTP/{base.ProtocolVersion} {_code} {_reason}{HttpBase.CrLf}";
			}
		}

		public bool CloseConnection
		{
			get
			{
				StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
				return base.Headers.Contains("Connection", "close", comparisonTypeForValue);
			}
		}

		public CookieCollection Cookies => base.Headers.GetCookies(response: true);

		public bool IsProxyAuthenticationRequired => _code == 407;

		public bool IsRedirect
		{
			get
			{
				if (_code != 301)
				{
					return _code == 302;
				}
				return true;
			}
		}

		public bool IsSuccess
		{
			get
			{
				if (_code >= 200)
				{
					return _code <= 299;
				}
				return false;
			}
		}

		public bool IsUnauthorized => _code == 401;

		public bool IsWebSocketResponse
		{
			get
			{
				if (base.ProtocolVersion > HttpVersion.Version10 && _code == 101)
				{
					return base.Headers.Upgrades("websocket");
				}
				return false;
			}
		}

		public override string MessageHeader => StatusLine + base.HeaderSection;

		public string Reason => _reason;

		public int StatusCode => _code;

		private HttpResponse(int code, string reason, Version version, NameValueCollection headers)
			: base(version, headers)
		{
			_code = code;
			_reason = reason;
		}

		internal HttpResponse(int code)
			: this(code, code.GetStatusDescription())
		{
		}

		internal HttpResponse(HttpStatusCode code)
			: this((int)code)
		{
		}

		internal HttpResponse(int code, string reason)
			: this(code, reason, HttpVersion.Version11, new NameValueCollection())
		{
			base.Headers["Server"] = "websocket-sharp/1.0";
		}

		internal HttpResponse(HttpStatusCode code, string reason)
			: this((int)code, reason)
		{
		}

		internal static HttpResponse CreateCloseResponse(HttpStatusCode code)
		{
			HttpResponse httpResponse = new HttpResponse(code);
			httpResponse.Headers["Connection"] = "close";
			return httpResponse;
		}

		internal static HttpResponse CreateUnauthorizedResponse(string challenge)
		{
			HttpResponse httpResponse = new HttpResponse(HttpStatusCode.Unauthorized);
			httpResponse.Headers["WWW-Authenticate"] = challenge;
			return httpResponse;
		}

		internal static HttpResponse CreateWebSocketHandshakeResponse()
		{
			HttpResponse httpResponse = new HttpResponse(HttpStatusCode.SwitchingProtocols);
			NameValueCollection headers = httpResponse.Headers;
			headers["Upgrade"] = "websocket";
			headers["Connection"] = "Upgrade";
			return httpResponse;
		}

		internal static HttpResponse Parse(string[] messageHeader)
		{
			int num = messageHeader.Length;
			if (num == 0)
			{
				throw new ArgumentException("An empty response header.");
			}
			string[] array = messageHeader[0].Split(new char[1] { ' ' }, 3);
			int num2 = array.Length;
			if (num2 < 2)
			{
				throw new ArgumentException("It includes an invalid status line.");
			}
			int code = array[1].ToInt32();
			string reason = ((num2 == 3) ? array[2] : null);
			Version version = array[0].Substring(5).ToVersion();
			WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
			for (int i = 1; i < num; i++)
			{
				webHeaderCollection.InternalSet(messageHeader[i], response: true);
			}
			return new HttpResponse(code, reason, version, webHeaderCollection);
		}

		internal static HttpResponse ReadResponse(Stream stream, int millisecondsTimeout)
		{
			return HttpBase.Read(stream, Parse, millisecondsTimeout);
		}

		public void SetCookies(CookieCollection cookies)
		{
			if (cookies == null || cookies.Count == 0)
			{
				return;
			}
			NameValueCollection headers = base.Headers;
			foreach (Cookie item in cookies.Sorted)
			{
				string value = item.ToResponseString();
				headers.Add("Set-Cookie", value);
			}
		}
	}
}
