using System;
using System.Collections.Generic;
using Amazon.Runtime.CredentialManagement;

namespace Amazon.Runtime.Internal
{
	public static class FallbackInternalConfigurationFactory
	{
		private delegate InternalConfiguration ConfigGenerator();

		private static CredentialProfileStoreChain _credentialProfileChain;

		private static InternalConfiguration _cachedConfiguration;

		public static bool? EndpointDiscoveryEnabled => _cachedConfiguration.EndpointDiscoveryEnabled;

		public static RequestRetryMode? RetryMode => _cachedConfiguration.RetryMode;

		public static int? MaxAttempts => _cachedConfiguration.MaxAttempts;

		public static string EC2MetadataServiceEndpoint => _cachedConfiguration.EC2MetadataServiceEndpoint;

		public static EC2MetadataServiceEndpointMode? EC2MetadataServiceEndpointMode => _cachedConfiguration.EC2MetadataServiceEndpointMode;

		public static string DefaultConfigurationModeName => _cachedConfiguration.DefaultConfigurationModeName;

		public static bool? UseDualStackEndpoint => _cachedConfiguration.UseDualstackEndpoint;

		public static bool? UseFIPSEndpoint => _cachedConfiguration.UseFIPSEndpoint;

		public static bool? IgnoreConfiguredEndpointUrls => _cachedConfiguration.IgnoreConfiguredEndpointUrls;

		public static bool? DisableRequestCompression => _cachedConfiguration.DisableRequestCompression;

		public static long? RequestMinCompressionSizeBytes => _cachedConfiguration.RequestMinCompressionSizeBytes;

		public static string ClientAppId => _cachedConfiguration.ClientAppId;

		public static AccountIdEndpointMode? AccountIdEndpointMode => _cachedConfiguration.AccountIdEndpointMode;

		public static RequestChecksumCalculation? RequestChecksumCalculation => _cachedConfiguration.RequestChecksumCalculation;

		public static ResponseChecksumValidation? ResponseChecksumValidation => _cachedConfiguration.ResponseChecksumValidation;

		static FallbackInternalConfigurationFactory()
		{
			_credentialProfileChain = new CredentialProfileStoreChain();
			Reset();
		}

		public static void Reset()
		{
			InternalConfiguration environmentVariablesConfiguration = new EnvironmentVariableInternalConfiguration();
			InternalConfiguration profileConfiguration = new ProfileInternalConfiguration(_credentialProfileChain);
			_cachedConfiguration = new InternalConfiguration();
			List<ConfigGenerator> generators = new List<ConfigGenerator>
			{
				() => environmentVariablesConfiguration,
				() => profileConfiguration
			};
			_cachedConfiguration.DefaultConfigurationModeName = SeekString(generators, (InternalConfiguration c) => c.DefaultConfigurationModeName, null);
			_cachedConfiguration.EndpointDiscoveryEnabled = SeekValue(generators, (InternalConfiguration c) => c.EndpointDiscoveryEnabled);
			_cachedConfiguration.RetryMode = SeekValue(generators, (InternalConfiguration c) => c.RetryMode);
			_cachedConfiguration.MaxAttempts = SeekValue(generators, (InternalConfiguration c) => c.MaxAttempts);
			_cachedConfiguration.EC2MetadataServiceEndpoint = SeekString(generators, (InternalConfiguration c) => c.EC2MetadataServiceEndpoint);
			_cachedConfiguration.EC2MetadataServiceEndpointMode = SeekValue(generators, (InternalConfiguration c) => c.EC2MetadataServiceEndpointMode);
			_cachedConfiguration.UseDualstackEndpoint = SeekValue(generators, (InternalConfiguration c) => c.UseDualstackEndpoint);
			_cachedConfiguration.UseFIPSEndpoint = SeekValue(generators, (InternalConfiguration c) => c.UseFIPSEndpoint);
			_cachedConfiguration.IgnoreConfiguredEndpointUrls = SeekValue(generators, (InternalConfiguration c) => c.IgnoreConfiguredEndpointUrls);
			_cachedConfiguration.DisableRequestCompression = SeekValue(generators, (InternalConfiguration c) => c.DisableRequestCompression);
			_cachedConfiguration.RequestMinCompressionSizeBytes = SeekValue(generators, (InternalConfiguration c) => c.RequestMinCompressionSizeBytes);
			_cachedConfiguration.ClientAppId = SeekString(generators, (InternalConfiguration c) => c.ClientAppId, null);
			_cachedConfiguration.AccountIdEndpointMode = SeekValue(generators, (InternalConfiguration c) => c.AccountIdEndpointMode);
			_cachedConfiguration.RequestChecksumCalculation = SeekValue(generators, (InternalConfiguration c) => c.RequestChecksumCalculation);
			_cachedConfiguration.ResponseChecksumValidation = SeekValue(generators, (InternalConfiguration c) => c.ResponseChecksumValidation);
		}

		private static T? SeekValue<T>(List<ConfigGenerator> generators, Func<InternalConfiguration, T?> getValue) where T : struct
		{
			foreach (ConfigGenerator generator in generators)
			{
				InternalConfiguration arg = generator();
				T? result = getValue(arg);
				if (result.HasValue)
				{
					return result;
				}
			}
			return null;
		}

		private static string SeekString(List<ConfigGenerator> generators, Func<InternalConfiguration, string> getValue, string defaultValue = "")
		{
			foreach (ConfigGenerator generator in generators)
			{
				InternalConfiguration arg = generator();
				string text = getValue(arg);
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
			}
			return defaultValue;
		}
	}
}
