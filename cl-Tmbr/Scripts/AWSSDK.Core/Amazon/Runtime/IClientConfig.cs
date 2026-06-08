using System;
using System.Net;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Telemetry;

namespace Amazon.Runtime
{
	public interface IClientConfig
	{
		bool IgnoreConfiguredEndpointUrls { get; }

		string ServiceId { get; }

		Profile Profile { get; }

		AWSCredentials DefaultAWSCredentials { get; }

		IIdentityResolverConfiguration IdentityResolverConfiguration { get; }

		IAWSTokenProvider AWSTokenProvider { get; }

		DefaultConfigurationMode DefaultConfigurationMode { get; }

		RegionEndpoint RegionEndpoint { get; }

		string RegionEndpointServiceName { get; }

		string ServiceURL { get; }

		IEndpointProvider EndpointProvider { get; }

		bool UseHttp { get; }

		string ServiceVersion { get; }

		SigningAlgorithm SignatureMethod { get; }

		string AuthenticationRegion { get; }

		string AuthenticationServiceName { get; }

		string UserAgent { get; }

		bool DisableLogging { get; }

		bool LogMetrics { get; }

		bool LogResponse { get; }

		bool AllowAutoRedirect { get; }

		int BufferSize { get; }

		int MaxErrorRetry { get; }

		bool IsMaxErrorRetrySet { get; }

		long ProgressUpdateInterval { get; }

		bool ResignRetries { get; }

		ICredentials ProxyCredentials { get; }

		TimeSpan? Timeout { get; }

		bool UseDualstackEndpoint { get; }

		bool UseFIPSEndpoint { get; }

		bool DisableRequestCompression { get; }

		long RequestMinCompressionSizeBytes { get; }

		string ClientAppId { get; }

		bool ThrottleRetries { get; }

		bool DisableHostPrefixInjection { get; }

		bool EndpointDiscoveryEnabled { get; }

		int EndpointDiscoveryCacheLimit { get; }

		RequestRetryMode RetryMode { get; }

		bool FastFailRequests { get; }

		bool UseAlternateUserAgentHeader { get; }

		TelemetryProvider TelemetryProvider { get; }

		RequestChecksumCalculation RequestChecksumCalculation { get; }

		ResponseChecksumValidation ResponseChecksumValidation { get; }

		AccountIdEndpointMode AccountIdEndpointMode { get; }

		int? MaxConnectionsPerServer { get; }

		bool CacheHttpClient { get; }

		int HttpClientCacheSize { get; }

		string ProxyHost { get; }

		int ProxyPort { get; }

		HttpClientFactory HttpClientFactory { get; }

		Endpoint DetermineServiceOperationEndpoint(ServiceOperationEndpointParameters parameters);

		void Validate();

		IWebProxy GetWebProxy();

		IWebProxy GetHttpsProxy();

		IWebProxy GetHttpProxy();
	}
}
