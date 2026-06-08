using System;

namespace Amazon.Runtime
{
	public interface IDefaultConfiguration
	{
		DefaultConfigurationMode Name { get; }

		RequestRetryMode RetryMode { get; }

		S3UsEast1RegionalEndpointValue S3UsEast1RegionalEndpoint { get; }

		TimeSpan? ConnectTimeout { get; }

		TimeSpan? TlsNegotiationTimeout { get; }

		TimeSpan? TimeToFirstByteTimeout { get; }

		TimeSpan? HttpRequestTimeout { get; }
	}
}
