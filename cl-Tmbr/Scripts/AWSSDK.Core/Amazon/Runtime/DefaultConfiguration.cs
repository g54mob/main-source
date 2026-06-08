using System;
using System.Diagnostics;

namespace Amazon.Runtime
{
	[DebuggerDisplay("{Name}")]
	public class DefaultConfiguration : IDefaultConfiguration
	{
		public DefaultConfigurationMode Name { get; set; }

		public RequestRetryMode RetryMode { get; set; }

		public S3UsEast1RegionalEndpointValue S3UsEast1RegionalEndpoint { get; set; }

		public TimeSpan? ConnectTimeout { get; set; }

		public TimeSpan? TlsNegotiationTimeout { get; set; }

		public TimeSpan? TimeToFirstByteTimeout { get; set; }

		public TimeSpan? HttpRequestTimeout { get; set; }
	}
}
