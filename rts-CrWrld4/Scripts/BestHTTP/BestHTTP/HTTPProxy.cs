using System;
using System.IO;
using BestHTTP.Authentication;

namespace BestHTTP
{
	public sealed class HTTPProxy : Proxy
	{
		public bool IsTransparent { get; set; }

		public bool SendWholeUri { get; set; }

		public bool NonTransparentForHTTPS { get; set; }

		public HTTPProxy(Uri address)
			: base(null, null)
		{
		}

		public HTTPProxy(Uri address, Credentials credentials)
			: base(null, null)
		{
		}

		public HTTPProxy(Uri address, Credentials credentials, bool isTransparent)
			: base(null, null)
		{
		}

		public HTTPProxy(Uri address, Credentials credentials, bool isTransparent, bool sendWholeUri)
			: base(null, null)
		{
		}

		public HTTPProxy(Uri address, Credentials credentials, bool isTransparent, bool sendWholeUri, bool nonTransparentForHTTPS)
			: base(null, null)
		{
		}

		internal override string GetRequestPath(Uri uri)
		{
			return null;
		}

		internal override void Connect(Stream stream, HTTPRequest request)
		{
		}
	}
}
