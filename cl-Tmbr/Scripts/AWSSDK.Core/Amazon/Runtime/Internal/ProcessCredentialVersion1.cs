using System;

namespace Amazon.Runtime.Internal
{
	public class ProcessCredentialVersion1
	{
		public int Version { get; set; }

		public string AccessKeyId { get; set; }

		public string SecretAccessKey { get; set; }

		public string SessionToken { get; set; }

		public DateTime Expiration { get; set; } = DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Utc);

		public string AccountId { get; set; }
	}
}
