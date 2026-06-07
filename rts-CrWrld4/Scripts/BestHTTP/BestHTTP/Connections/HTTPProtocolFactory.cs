using System;
using System.IO;

namespace BestHTTP.Connections
{
	public static class HTTPProtocolFactory
	{
		public const string W3C_HTTP1 = "http/1.1";

		public const string W3C_HTTP2 = "h2";

		public static HTTPResponse Get(SupportedProtocols protocol, HTTPRequest request, Stream stream, bool isStreamed, bool isFromCache)
		{
			return null;
		}

		public static SupportedProtocols GetProtocolFromUri(Uri uri)
		{
			return default(SupportedProtocols);
		}

		public static bool IsSecureProtocol(Uri uri)
		{
			return false;
		}
	}
}
