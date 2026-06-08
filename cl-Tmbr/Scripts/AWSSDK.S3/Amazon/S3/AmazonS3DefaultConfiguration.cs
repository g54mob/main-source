using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Amazon.Runtime;

namespace Amazon.S3
{
	public static class AmazonS3DefaultConfiguration
	{
		public static IDefaultConfiguration Standard { get; } = new DefaultConfiguration
		{
			Name = DefaultConfigurationMode.Standard,
			RetryMode = RequestRetryMode.Standard,
			S3UsEast1RegionalEndpoint = S3UsEast1RegionalEndpointValue.Regional,
			ConnectTimeout = TimeSpan.FromMilliseconds(3100.0),
			TlsNegotiationTimeout = TimeSpan.FromMilliseconds(3100.0),
			TimeToFirstByteTimeout = null,
			HttpRequestTimeout = null
		};

		public static IDefaultConfiguration InRegion { get; } = new DefaultConfiguration
		{
			Name = DefaultConfigurationMode.InRegion,
			RetryMode = RequestRetryMode.Standard,
			S3UsEast1RegionalEndpoint = S3UsEast1RegionalEndpointValue.Regional,
			ConnectTimeout = TimeSpan.FromMilliseconds(1100.0),
			TlsNegotiationTimeout = TimeSpan.FromMilliseconds(1100.0),
			TimeToFirstByteTimeout = null,
			HttpRequestTimeout = null
		};

		public static IDefaultConfiguration CrossRegion { get; } = new DefaultConfiguration
		{
			Name = DefaultConfigurationMode.CrossRegion,
			RetryMode = RequestRetryMode.Standard,
			S3UsEast1RegionalEndpoint = S3UsEast1RegionalEndpointValue.Regional,
			ConnectTimeout = TimeSpan.FromMilliseconds(3100.0),
			TlsNegotiationTimeout = TimeSpan.FromMilliseconds(3100.0),
			TimeToFirstByteTimeout = null,
			HttpRequestTimeout = null
		};

		public static IDefaultConfiguration Mobile { get; } = new DefaultConfiguration
		{
			Name = DefaultConfigurationMode.Mobile,
			RetryMode = RequestRetryMode.Standard,
			S3UsEast1RegionalEndpoint = S3UsEast1RegionalEndpointValue.Regional,
			ConnectTimeout = TimeSpan.FromMilliseconds(30000.0),
			TlsNegotiationTimeout = TimeSpan.FromMilliseconds(30000.0),
			TimeToFirstByteTimeout = null,
			HttpRequestTimeout = null
		};

		public static IDefaultConfiguration Auto { get; } = new DefaultConfiguration
		{
			Name = DefaultConfigurationMode.Auto,
			RetryMode = RequestRetryMode.Standard,
			S3UsEast1RegionalEndpoint = S3UsEast1RegionalEndpointValue.Regional,
			ConnectTimeout = TimeSpan.FromMilliseconds(1100.0),
			TlsNegotiationTimeout = TimeSpan.FromMilliseconds(1100.0),
			TimeToFirstByteTimeout = null,
			HttpRequestTimeout = null
		};

		public static ReadOnlyCollection<IDefaultConfiguration> GetAllConfigurations()
		{
			return new ReadOnlyCollection<IDefaultConfiguration>(new List<IDefaultConfiguration> { Standard, InRegion, CrossRegion, Mobile, Auto });
		}
	}
}
