using System;
using System.Collections.Generic;
using System.IO;
using BestHTTP.Authentication;

namespace BestHTTP
{
	public abstract class Proxy
	{
		public Uri Address { get; set; }

		public Credentials Credentials { get; set; }

		public List<string> Exceptions { get; set; }

		internal Proxy(Uri address, Credentials credentials)
		{
		}

		internal abstract void Connect(Stream stream, HTTPRequest request);

		internal abstract string GetRequestPath(Uri uri);

		internal bool UseProxyForAddress(Uri address)
		{
			return false;
		}
	}
}
