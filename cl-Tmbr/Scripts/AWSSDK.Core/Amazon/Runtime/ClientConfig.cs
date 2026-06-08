using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Telemetry;

namespace Amazon.Runtime
{
	public abstract class ClientConfig : IClientConfig
	{
		internal static readonly TimeSpan InfiniteTimeout = TimeSpan.FromMilliseconds(-1.0);

		internal const long UpperLimitCompressionSizeBytes = 10485760L;

		public static readonly TimeSpan MaxTimeout = TimeSpan.FromMilliseconds(2147483647.0);

		private IDefaultConfigurationProvider _defaultConfigurationProvider;

		private string serviceId;

		private DefaultConfigurationMode? defaultConfigurationMode;

		private RegionEndpoint regionEndpoint;

		private bool probeForRegionEndpoint = true;

		private bool throttleRetries = true;

		private bool useHttp;

		private bool useAlternateUserAgentHeader = AWSConfigs.UseAlternateUserAgentHeader;

		private string serviceURL;

		private string authRegion;

		private string authServiceName;

		private string clientAppId;

		private SigningAlgorithm signatureMethod = SigningAlgorithm.HmacSHA256;

		private bool logResponse;

		private int bufferSize = 8192;

		private long progressUpdateInterval = 102400L;

		private bool resignRetries;

		private ICredentials proxyCredentials;

		private bool logMetrics = AWSConfigs.LoggingConfig.LogMetrics;

		private bool disableLogging;

		private TimeSpan? timeout;

		private bool allowAutoRedirect = true;

		private bool? useDualstackEndpoint;

		private bool? useFIPSEndpoint;

		private bool? disableRequestCompression;

		private long? requestMinCompressionSizeBytes;

		private bool disableHostPrefixInjection;

		private bool? endpointDiscoveryEnabled;

		private bool? ignoreConfiguredEndpointUrls;

		private int endpointDiscoveryCacheLimit = 1000;

		private RequestRetryMode? retryMode;

		private int? maxRetries;

		private const int MaxRetriesDefault = 2;

		private const long DefaultMinCompressionSizeBytes = 10240L;

		private bool didProcessServiceURL;

		private AWSCredentials _defaultAWSCredentials;

		private IIdentityResolverConfiguration _identityResolverConfiguration = DefaultIdentityResolverConfiguration.Instance;

		private IAWSTokenProvider _awsTokenProvider;

		private TelemetryProvider telemetryProvider = AWSConfigs.TelemetryProvider;

		private AccountIdEndpointMode? accountIdEndpointMode;

		private RequestChecksumCalculation? requestChecksumCalculation;

		private ResponseChecksumValidation? responseChecksumValidation;

		private CredentialProfileStoreChain credentialProfileStoreChain;

		private IDefaultConfiguration defaultConfigurationBackingField;

		private int? _httpClientCacheSize;

		private IWebProxy proxy;

		private string proxyHost;

		private int proxyPort = -1;

		public AccountIdEndpointMode AccountIdEndpointMode
		{
			get
			{
				if (!accountIdEndpointMode.HasValue)
				{
					return FallbackInternalConfigurationFactory.AccountIdEndpointMode.GetValueOrDefault();
				}
				return accountIdEndpointMode.Value;
			}
			set
			{
				accountIdEndpointMode = value;
			}
		}

		public Profile Profile { get; set; }

		private CredentialProfileStoreChain CredentialProfileStoreChain
		{
			get
			{
				if (credentialProfileStoreChain == null)
				{
					if (Profile != null)
					{
						credentialProfileStoreChain = new CredentialProfileStoreChain(Profile.Location);
					}
					else
					{
						credentialProfileStoreChain = new CredentialProfileStoreChain();
					}
				}
				return credentialProfileStoreChain;
			}
			set
			{
				credentialProfileStoreChain = value;
			}
		}

		public AWSCredentials DefaultAWSCredentials
		{
			get
			{
				return _defaultAWSCredentials;
			}
			set
			{
				_defaultAWSCredentials = value;
			}
		}

		public IIdentityResolverConfiguration IdentityResolverConfiguration
		{
			get
			{
				return _identityResolverConfiguration;
			}
			set
			{
				_identityResolverConfiguration = value;
			}
		}

		public IAWSTokenProvider AWSTokenProvider
		{
			get
			{
				return _awsTokenProvider;
			}
			set
			{
				_awsTokenProvider = value;
			}
		}

		public abstract string ServiceVersion { get; }

		public SigningAlgorithm SignatureMethod
		{
			get
			{
				return signatureMethod;
			}
			set
			{
				signatureMethod = value;
			}
		}

		public abstract string UserAgent { get; }

		public bool UseAlternateUserAgentHeader
		{
			get
			{
				return useAlternateUserAgentHeader;
			}
			set
			{
				useAlternateUserAgentHeader = value;
			}
		}

		public RegionEndpoint RegionEndpoint
		{
			get
			{
				if (probeForRegionEndpoint)
				{
					RegionEndpoint = GetDefaultRegionEndpoint();
					probeForRegionEndpoint = false;
				}
				return regionEndpoint;
			}
			set
			{
				if (!string.IsNullOrEmpty(serviceURL))
				{
					Logger.GetLogger(GetType()).InfoFormat("RegionEndpoint and ServiceURL are mutually exclusive. Since " + $"RegionEndpoint was set last, RegionEndpoint: {value} will be used to make the request and ServiceUrl: {serviceURL} has been set to null.");
				}
				defaultConfigurationBackingField = null;
				serviceURL = null;
				regionEndpoint = value;
				probeForRegionEndpoint = regionEndpoint == null;
				if (!string.IsNullOrEmpty(value?.SystemName) && (value.SystemName.Contains("fips-") || value.SystemName.Contains("-fips")))
				{
					Logger.GetLogger(GetType()).InfoFormat("FIPS Pseudo Region support is deprecated. Will attempt to convert " + value.SystemName + ".");
					UseFIPSEndpoint = true;
					regionEndpoint = RegionEndpoint.GetBySystemName(value.SystemName.Replace("fips-", "").Replace("-fips", ""));
				}
			}
		}

		public abstract string RegionEndpointServiceName { get; }

		public string ServiceURL
		{
			get
			{
				if (!didProcessServiceURL && serviceURL == null && !IgnoreConfiguredEndpointUrls && ServiceId != null)
				{
					string text = TransformServiceId.TransformServiceIdToEnvVariable(ServiceId);
					string text2 = TransformServiceId.TransformServiceIdToConfigVariable(ServiceId);
					if (Environment.GetEnvironmentVariable(text) != null)
					{
						Logger.GetLogger(GetType()).InfoFormat("ServiceURL configured from service specific environment variable: " + text + ".");
						ServiceURL = Environment.GetEnvironmentVariable(text);
					}
					else if (Environment.GetEnvironmentVariable("AWS_ENDPOINT_URL") != null)
					{
						ServiceURL = Environment.GetEnvironmentVariable("AWS_ENDPOINT_URL");
						Logger.GetLogger(GetType()).InfoFormat("ServiceURL configured from global environment variable: AWS_ENDPOINT_URL.");
					}
					else
					{
						CredentialProfile profile;
						if (Profile != null)
						{
							CredentialProfileStoreChain.TryGetProfile(Profile.Name, out profile);
						}
						else
						{
							CredentialProfileStoreChain.TryGetProfile(DefaultAWSCredentialsIdentityResolver.GetProfileName(), out profile);
						}
						if (profile != null)
						{
							if (profile.NestedProperties.TryGetValue(text2, out var value))
							{
								if (value.TryGetValue("endpoint_url", out var value2))
								{
									Logger.GetLogger(GetType()).InfoFormat("ServiceURL configured from service specific endpoint url in profile " + profile.Name + " from key " + text2 + ".");
									ServiceURL = value2;
								}
							}
							else if (!string.IsNullOrEmpty(profile.EndpointUrl))
							{
								Logger.GetLogger(GetType()).InfoFormat("ServiceURL configured from global endpoint urlin profile " + profile.Name + " from key endpoint_url.");
								ServiceURL = profile.EndpointUrl;
							}
						}
					}
					didProcessServiceURL = true;
				}
				return serviceURL;
			}
			set
			{
				if (regionEndpoint != null)
				{
					Logger.GetLogger(GetType()).InfoFormat("RegionEndpoint and ServiceURL are mutually exclusive. Since " + $"ServiceUrl was set last, ServiceUrl: {value} will be used to make the request and RegionEndpoint: {regionEndpoint} has been set to null.");
				}
				regionEndpoint = null;
				probeForRegionEndpoint = false;
				if (!string.IsNullOrEmpty(value))
				{
					try
					{
						string pathAndQuery = new Uri(value).PathAndQuery;
						if ((string.IsNullOrEmpty(pathAndQuery) || pathAndQuery == "/") && !string.IsNullOrEmpty(value) && !value.EndsWith("/"))
						{
							value += "/";
						}
					}
					catch (UriFormatException)
					{
						throw new AmazonClientException("Value for ServiceURL is not a valid URL: " + value);
					}
				}
				serviceURL = value;
			}
		}

		public bool UseHttp
		{
			get
			{
				return useHttp;
			}
			set
			{
				useHttp = value;
			}
		}

		public string AuthenticationRegion
		{
			get
			{
				return authRegion;
			}
			set
			{
				authRegion = value;
			}
		}

		public string AuthenticationServiceName
		{
			get
			{
				return authServiceName;
			}
			set
			{
				authServiceName = value;
			}
		}

		public string ServiceId
		{
			get
			{
				return serviceId;
			}
			set
			{
				serviceId = value;
			}
		}

		public int MaxErrorRetry
		{
			get
			{
				if (!maxRetries.HasValue)
				{
					return (FallbackInternalConfigurationFactory.MaxAttempts - 1) ?? 2;
				}
				return maxRetries.Value;
			}
			set
			{
				maxRetries = value;
			}
		}

		public bool IsMaxErrorRetrySet => maxRetries.HasValue;

		public bool LogResponse
		{
			get
			{
				return logResponse;
			}
			set
			{
				logResponse = value;
			}
		}

		public int BufferSize
		{
			get
			{
				return bufferSize;
			}
			set
			{
				bufferSize = value;
			}
		}

		public long ProgressUpdateInterval
		{
			get
			{
				return progressUpdateInterval;
			}
			set
			{
				progressUpdateInterval = value;
			}
		}

		public bool ResignRetries
		{
			get
			{
				return resignRetries;
			}
			set
			{
				resignRetries = value;
			}
		}

		public bool AllowAutoRedirect
		{
			get
			{
				return allowAutoRedirect;
			}
			set
			{
				allowAutoRedirect = value;
			}
		}

		public bool LogMetrics
		{
			get
			{
				return logMetrics;
			}
			set
			{
				logMetrics = value;
			}
		}

		public bool DisableLogging
		{
			get
			{
				return disableLogging;
			}
			set
			{
				disableLogging = value;
			}
		}

		public DefaultConfigurationMode DefaultConfigurationMode
		{
			get
			{
				if (defaultConfigurationMode.HasValue)
				{
					return defaultConfigurationMode.Value;
				}
				return DefaultConfiguration.Name;
			}
			set
			{
				defaultConfigurationMode = value;
				defaultConfigurationBackingField = null;
			}
		}

		protected IDefaultConfiguration DefaultConfiguration
		{
			get
			{
				if (defaultConfigurationBackingField != null)
				{
					return defaultConfigurationBackingField;
				}
				defaultConfigurationBackingField = _defaultConfigurationProvider.GetDefaultConfiguration(RegionEndpoint, defaultConfigurationMode);
				return defaultConfigurationBackingField;
			}
		}

		public ICredentials ProxyCredentials
		{
			get
			{
				if (proxyCredentials == null && (!string.IsNullOrEmpty(AWSConfigs.ProxyConfig.Username) || !string.IsNullOrEmpty(AWSConfigs.ProxyConfig.Password)))
				{
					return new NetworkCredential(AWSConfigs.ProxyConfig.Username, AWSConfigs.ProxyConfig.Password ?? string.Empty);
				}
				return proxyCredentials;
			}
			set
			{
				proxyCredentials = value;
			}
		}

		public TimeSpan? Timeout
		{
			get
			{
				if (timeout.HasValue)
				{
					return timeout;
				}
				return DefaultConfiguration.TimeToFirstByteTimeout;
			}
			set
			{
				ValidateTimeout(value);
				timeout = value;
			}
		}

		public bool UseDualstackEndpoint
		{
			get
			{
				if (!useDualstackEndpoint.HasValue)
				{
					return FallbackInternalConfigurationFactory.UseDualStackEndpoint == true;
				}
				return useDualstackEndpoint.Value;
			}
			set
			{
				useDualstackEndpoint = value;
			}
		}

		public bool UseFIPSEndpoint
		{
			get
			{
				if (!useFIPSEndpoint.HasValue)
				{
					return FallbackInternalConfigurationFactory.UseFIPSEndpoint == true;
				}
				return useFIPSEndpoint.Value;
			}
			set
			{
				useFIPSEndpoint = value;
			}
		}

		public bool IgnoreConfiguredEndpointUrls
		{
			get
			{
				if (!ignoreConfiguredEndpointUrls.HasValue)
				{
					return FallbackInternalConfigurationFactory.IgnoreConfiguredEndpointUrls == true;
				}
				return ignoreConfiguredEndpointUrls.Value;
			}
			set
			{
				ignoreConfiguredEndpointUrls = value;
			}
		}

		public bool DisableRequestCompression
		{
			get
			{
				if (!disableRequestCompression.HasValue)
				{
					return FallbackInternalConfigurationFactory.DisableRequestCompression == true;
				}
				return disableRequestCompression.Value;
			}
			set
			{
				disableRequestCompression = value;
			}
		}

		public long RequestMinCompressionSizeBytes
		{
			get
			{
				if (!requestMinCompressionSizeBytes.HasValue)
				{
					return FallbackInternalConfigurationFactory.RequestMinCompressionSizeBytes ?? 10240;
				}
				return requestMinCompressionSizeBytes.Value;
			}
			set
			{
				ValidateMinCompression(value);
				requestMinCompressionSizeBytes = value;
			}
		}

		public string ClientAppId
		{
			get
			{
				if (clientAppId == null)
				{
					return FallbackInternalConfigurationFactory.ClientAppId;
				}
				return clientAppId;
			}
			set
			{
				ValidateClientAppId(value);
				clientAppId = value;
			}
		}

		public bool ThrottleRetries
		{
			get
			{
				return throttleRetries;
			}
			set
			{
				throttleRetries = value;
			}
		}

		public bool DisableHostPrefixInjection
		{
			get
			{
				return disableHostPrefixInjection;
			}
			set
			{
				disableHostPrefixInjection = value;
			}
		}

		public bool EndpointDiscoveryEnabled
		{
			get
			{
				if (!endpointDiscoveryEnabled.HasValue)
				{
					return FallbackInternalConfigurationFactory.EndpointDiscoveryEnabled == true;
				}
				return endpointDiscoveryEnabled.Value;
			}
			set
			{
				endpointDiscoveryEnabled = value;
			}
		}

		public int EndpointDiscoveryCacheLimit
		{
			get
			{
				return endpointDiscoveryCacheLimit;
			}
			set
			{
				endpointDiscoveryCacheLimit = value;
			}
		}

		public RequestRetryMode RetryMode
		{
			get
			{
				if (!retryMode.HasValue)
				{
					return FallbackInternalConfigurationFactory.RetryMode ?? DefaultConfiguration.RetryMode;
				}
				return retryMode.Value;
			}
			set
			{
				retryMode = value;
			}
		}

		public bool FastFailRequests { get; set; }

		public bool CacheHttpClient { get; set; } = true;

		public int HttpClientCacheSize
		{
			get
			{
				if (_httpClientCacheSize.HasValue)
				{
					return _httpClientCacheSize.Value;
				}
				if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					return Environment.ProcessorCount;
				}
				return 1;
			}
			set
			{
				_httpClientCacheSize = value;
			}
		}

		public IEndpointProvider EndpointProvider { get; set; }

		public TelemetryProvider TelemetryProvider
		{
			get
			{
				return telemetryProvider;
			}
			set
			{
				telemetryProvider = value;
			}
		}

		public RequestChecksumCalculation RequestChecksumCalculation
		{
			get
			{
				if (!requestChecksumCalculation.HasValue)
				{
					return FallbackInternalConfigurationFactory.RequestChecksumCalculation.GetValueOrDefault();
				}
				return requestChecksumCalculation.Value;
			}
			set
			{
				requestChecksumCalculation = value;
			}
		}

		public ResponseChecksumValidation ResponseChecksumValidation
		{
			get
			{
				if (!responseChecksumValidation.HasValue)
				{
					return FallbackInternalConfigurationFactory.ResponseChecksumValidation.GetValueOrDefault();
				}
				return responseChecksumValidation.Value;
			}
			set
			{
				responseChecksumValidation = value;
			}
		}

		public string ProxyHost
		{
			get
			{
				if (string.IsNullOrEmpty(proxyHost))
				{
					return AWSConfigs.ProxyConfig.Host;
				}
				return proxyHost;
			}
			set
			{
				proxyHost = value;
				if (ProxyPort > 0)
				{
					proxy = new Amazon.Runtime.Internal.Util.WebProxy(ProxyHost, ProxyPort);
				}
			}
		}

		public int ProxyPort
		{
			get
			{
				if (proxyPort <= 0)
				{
					return AWSConfigs.ProxyConfig.Port.GetValueOrDefault();
				}
				return proxyPort;
			}
			set
			{
				proxyPort = value;
				if (ProxyHost != null)
				{
					proxy = new Amazon.Runtime.Internal.Util.WebProxy(ProxyHost, ProxyPort);
				}
			}
		}

		public int? MaxConnectionsPerServer { get; set; }

		public HttpClientFactory HttpClientFactory { get; set; } = AWSConfigs.HttpClientFactory;

		private static Amazon.Runtime.Internal.Util.WebProxy GetWebProxyWithCredentials(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				Uri uri = new Uri(value);
				Amazon.Runtime.Internal.Util.WebProxy webProxy = new Amazon.Runtime.Internal.Util.WebProxy(uri);
				if (!string.IsNullOrEmpty(uri.UserInfo))
				{
					string[] array = uri.UserInfo.Split(new char[1] { ':' });
					webProxy.Credentials = new NetworkCredential(array[0], (array.Length > 1) ? array[1] : string.Empty);
				}
				return webProxy;
			}
			return null;
		}

		public IWebProxy GetHttpProxy()
		{
			IWebProxy webProxy = GetWebProxy();
			if (webProxy != null)
			{
				return webProxy;
			}
			return GetWebProxyWithCredentials(Environment.GetEnvironmentVariable("http_proxy"));
		}

		public IWebProxy GetHttpsProxy()
		{
			IWebProxy webProxy = GetWebProxy();
			if (webProxy != null)
			{
				return webProxy;
			}
			return GetWebProxyWithCredentials(Environment.GetEnvironmentVariable("https_proxy"));
		}

		protected ClientConfig(IDefaultConfigurationProvider defaultConfigurationProvider)
		{
			_defaultConfigurationProvider = defaultConfigurationProvider;
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		internal CancellationToken BuildDefaultCancellationToken()
		{
			TimeSpan? timeToFirstByteTimeout = DefaultConfiguration.TimeToFirstByteTimeout;
			if (!timeToFirstByteTimeout.HasValue)
			{
				return default(CancellationToken);
			}
			return new CancellationTokenSource(timeToFirstByteTimeout.Value).Token;
		}

		private static void ValidateClientAppId(string clientAppId)
		{
			if (clientAppId != null && clientAppId.Length > 50)
			{
				Logger.GetLogger(typeof(InternalConfiguration)).InfoFormat("Warning: Client app id exceeds recommended maximum length of {0} characters: \"{1}\"", 50, clientAppId);
			}
		}

		private static void ValidateMinCompression(long minCompressionSize)
		{
			if (minCompressionSize < 0 || minCompressionSize > 10485760)
			{
				throw new ArgumentException(string.Format("Invalid value {0} for {1}. A long value between 0 and {2} bytes inclusive is expected.", minCompressionSize, "requestMinCompressionSizeBytes", 10485760L));
			}
		}

		public void SetUseNagleIfAvailable(bool useNagle)
		{
		}

		public virtual void Validate()
		{
			if (RegionEndpoint == null && string.IsNullOrEmpty(ServiceURL))
			{
				throw new AmazonClientException("No RegionEndpoint or ServiceURL configured");
			}
		}

		public static void ValidateTimeout(TimeSpan? timeout)
		{
			if (!timeout.HasValue)
			{
				throw new ArgumentNullException("timeout");
			}
			if (timeout != InfiniteTimeout && (timeout <= TimeSpan.Zero || timeout > MaxTimeout))
			{
				throw new ArgumentOutOfRangeException("timeout");
			}
		}

		public static TimeSpan? GetTimeoutValue(TimeSpan? clientTimeout, TimeSpan? requestTimeout)
		{
			return requestTimeout ?? clientTimeout ?? ((TimeSpan?)null);
		}

		public abstract Endpoint DetermineServiceOperationEndpoint(ServiceOperationEndpointParameters parameters);

		private static RegionEndpoint GetDefaultRegionEndpoint()
		{
			return FallbackRegionFactory.GetRegionEndpoint();
		}

		public IWebProxy GetWebProxy()
		{
			return proxy;
		}

		public void SetWebProxy(IWebProxy proxy)
		{
			this.proxy = proxy;
		}

		internal static bool CacheHttpClients(IClientConfig clientConfig)
		{
			if (clientConfig.HttpClientFactory == null)
			{
				return clientConfig.CacheHttpClient;
			}
			return clientConfig.HttpClientFactory.UseSDKHttpClientCaching(clientConfig);
		}

		internal static bool DisposeHttpClients(IClientConfig clientConfig)
		{
			if (clientConfig.HttpClientFactory == null)
			{
				return !clientConfig.CacheHttpClient;
			}
			return clientConfig.HttpClientFactory.DisposeHttpClientsAfterUse(clientConfig);
		}

		internal static string CreateConfigUniqueString(IClientConfig clientConfig)
		{
			if (clientConfig.HttpClientFactory != null)
			{
				return clientConfig.HttpClientFactory.GetConfigUniqueString(clientConfig);
			}
			string empty = string.Empty;
			empty = "AllowAutoRedirect:" + clientConfig.AllowAutoRedirect.ToString() + "CacheSize:" + clientConfig.HttpClientCacheSize;
			if (clientConfig.Timeout.HasValue)
			{
				empty = empty + "Timeout:" + clientConfig.Timeout.Value;
			}
			if (clientConfig.MaxConnectionsPerServer.HasValue)
			{
				empty = empty + "MaxConnectionsPerServer:" + clientConfig.MaxConnectionsPerServer.Value;
			}
			return empty;
		}

		internal static bool UseGlobalHttpClientCache(IClientConfig clientConfig)
		{
			if (clientConfig.HttpClientFactory == null)
			{
				if (clientConfig.ProxyCredentials == null)
				{
					return clientConfig.GetWebProxy() == null;
				}
				return false;
			}
			return clientConfig.HttpClientFactory.GetConfigUniqueString(clientConfig) != null;
		}
	}
}
