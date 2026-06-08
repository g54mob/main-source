using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.SharedInterfaces
{
	public class PkceFlowOptions
	{
		public string RedirectUri { get; set; }

		public IList<string> GrantTypes { get; set; } = new List<string> { "authorization_code", "refresh_token" };

		public string IssuerUrl { get; set; }

		public Func<Uri, CancellationToken, Task<string>> RetrieveAuthorizationCodeCallbackAsync { get; set; }
	}
}
