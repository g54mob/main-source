using System;
using System.Collections.Generic;
using System.Net;
using Amazon.Runtime.SharedInterfaces;

namespace Amazon.Runtime
{
	public class SSOAWSCredentialsOptions
	{
		public string ClientName { get; set; }

		public string SessionName { get; set; }

		public IList<string> Scopes { get; set; }

		public Action<SsoVerificationArguments> SsoVerificationCallback { get; set; }

		public PkceFlowOptions PkceFlowOptions { get; set; }

		public bool SupportsGettingNewToken { get; set; }

		public IWebProxy ProxySettings { get; set; }
	}
}
