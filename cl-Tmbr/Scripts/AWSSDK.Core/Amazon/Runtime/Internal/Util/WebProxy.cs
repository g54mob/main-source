using System;
using System.Net;

namespace Amazon.Runtime.Internal.Util
{
	public class WebProxy : IWebProxy
	{
		public Uri ProxyUri { get; set; }

		public ICredentials Credentials { get; set; }

		public WebProxy(string proxyUri)
			: this(new Uri(proxyUri))
		{
		}

		public WebProxy(Uri proxyUri)
		{
			ProxyUri = proxyUri;
		}

		public WebProxy(string proxyHost, int proxyPort)
			: this(new Uri("http://" + proxyHost + ":" + proxyPort))
		{
		}

		public Uri GetProxy(Uri destination)
		{
			return ProxyUri;
		}

		public bool IsBypassed(Uri host)
		{
			return false;
		}
	}
}
