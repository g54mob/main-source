namespace Amazon.Runtime.Internal
{
	public class InternalConfiguration
	{
		public bool? EndpointDiscoveryEnabled { get; set; }

		public RequestRetryMode? RetryMode { get; set; }

		public int? MaxAttempts { get; set; }

		public string EC2MetadataServiceEndpoint { get; set; }

		public EC2MetadataServiceEndpointMode? EC2MetadataServiceEndpointMode { get; set; }

		public string DefaultConfigurationModeName { get; set; }

		public bool? UseDualstackEndpoint { get; set; }

		public bool? UseFIPSEndpoint { get; set; }

		public bool? IgnoreConfiguredEndpointUrls { get; set; }

		public bool? DisableRequestCompression { get; set; }

		public long? RequestMinCompressionSizeBytes { get; set; }

		public string ClientAppId { get; set; }

		public AccountIdEndpointMode? AccountIdEndpointMode { get; set; }

		public RequestChecksumCalculation? RequestChecksumCalculation { get; set; }

		public ResponseChecksumValidation? ResponseChecksumValidation { get; set; }
	}
}
