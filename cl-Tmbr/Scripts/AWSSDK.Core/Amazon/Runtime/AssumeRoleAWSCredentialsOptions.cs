using System;
using System.Collections.Generic;
using System.Net;

namespace Amazon.Runtime
{
	public class AssumeRoleAWSCredentialsOptions
	{
		public string ExternalId { get; set; }

		public string Policy { get; set; }

		public int? DurationSeconds { get; set; }

		public IWebProxy ProxySettings { get; set; }

		public string MfaSerialNumber { get; set; }

		public string MfaTokenCode
		{
			get
			{
				if (string.IsNullOrEmpty(MfaSerialNumber))
				{
					return null;
				}
				if (MfaTokenCodeCallback == null)
				{
					throw new InvalidOperationException("The MfaSerialNumber has been set but the MfaTokenCodeCallback hasn't.  MfaTokenCodeCallback is required in order to determine the MfaTokenCode when MfaSerialNumber is set.");
				}
				return MfaTokenCodeCallback();
			}
		}

		public Func<string> MfaTokenCodeCallback { get; set; }

		public string SourceIdentity { get; set; }

		public List<KeyValuePair<string, string>> Tags { get; set; }

		public List<string> TransitiveTagKeys { get; set; }
	}
}
