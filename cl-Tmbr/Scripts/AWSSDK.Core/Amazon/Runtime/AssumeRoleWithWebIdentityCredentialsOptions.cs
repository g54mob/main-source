using System.Collections.Generic;
using System.Net;

namespace Amazon.Runtime
{
	public class AssumeRoleWithWebIdentityCredentialsOptions
	{
		public int? DurationSeconds { get; set; }

		public string ProviderId { get; set; }

		public string Policy { get; set; }

		public List<string> PolicyArns { get; set; }

		public IWebProxy ProxySettings { get; set; }
	}
}
