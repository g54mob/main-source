using System;
using System.Collections.Generic;

namespace Amazon.Runtime.SharedInterfaces
{
	public class GetSsoTokenRequest
	{
		public string ClientName { get; set; }

		public string ClientType { get; set; }

		public string StartUrl { get; set; }

		public Action<SsoVerificationArguments> SsoVerificationCallback { get; set; }

		public IDictionary<string, object> AdditionalProperties { get; set; }

		public IList<string> Scopes { get; set; }

		public PkceFlowOptions PkceFlowOptions { get; set; }
	}
}
