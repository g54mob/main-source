using System;
using System.Collections.Generic;
using Amazon.Runtime.SharedInterfaces;

namespace Amazon.Runtime.Credentials.Internal
{
	public class SSOTokenManagerGetTokenOptions
	{
		private const string SsoClientTypePublic = "public";

		public string StartUrl { get; set; }

		public string Session { get; set; }

		public string Region { get; set; }

		public string CacheFolderLocation { get; set; }

		public string ClientName { get; set; }

		public string ClientType { get; set; } = "public";

		public IList<string> Scopes { get; set; }

		public Action<SsoVerificationArguments> SsoVerificationCallback { get; set; }

		public PkceFlowOptions PkceFlowOptions { get; set; }

		public bool SupportsGettingNewToken { get; set; } = true;
	}
}
