using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.CredentialManagement
{
	public class CredentialProfile
	{
		private Dictionary<string, string> _properties;

		private Dictionary<string, Dictionary<string, string>> _nestedProperties;

		internal Dictionary<string, Dictionary<string, string>> NestedProperties
		{
			get
			{
				return _nestedProperties ?? (_nestedProperties = new Dictionary<string, Dictionary<string, string>>());
			}
			set
			{
				_nestedProperties = value;
			}
		}

		public string Name { get; private set; }

		public CredentialProfileOptions Options { get; private set; }

		public RegionEndpoint Region { get; set; }

		internal Guid? UniqueKey { get; set; }

		public string DefaultConfigurationModeName { get; set; }

		public bool? EndpointDiscoveryEnabled { get; set; }

		public bool? S3UseArnRegion { get; set; }

		public bool? S3DisableExpressSessionAuth { get; set; }

		public bool? S3DisableMultiRegionAccessPoints { get; set; }

		public S3UsEast1RegionalEndpointValue? S3RegionalEndpoint { get; set; }

		public RequestRetryMode? RetryMode { get; set; }

		public int? MaxAttempts { get; set; }

		public string EC2MetadataServiceEndpoint { get; set; }

		public EC2MetadataServiceEndpointMode? EC2MetadataServiceEndpointMode { get; set; }

		public bool? UseDualstackEndpoint { get; set; }

		public bool? UseFIPSEndpoint { get; set; }

		public bool? IgnoreConfiguredEndpointUrls { get; set; }

		public string EndpointUrl { get; set; }

		public bool? DisableRequestCompression { get; set; }

		public long? RequestMinCompressionSizeBytes { get; set; }

		public string ClientAppId { get; set; }

		public string Services { get; set; }

		public RequestChecksumCalculation? RequestChecksumCalculation { get; set; }

		public ResponseChecksumValidation? ResponseChecksumValidation { get; set; }

		public AccountIdEndpointMode? AccountIdEndpointMode { get; set; }

		internal Dictionary<string, string> Properties
		{
			get
			{
				return _properties ?? (_properties = new Dictionary<string, string>());
			}
			set
			{
				_properties = value;
			}
		}

		public bool CanCreateAWSCredentials => ProfileType.HasValue;

		public ICredentialProfileStore CredentialProfileStore { get; internal set; }

		public string CredentialDescription => CredentialProfileTypeDetector.GetUserFriendlyCredentialType(ProfileType);

		internal CredentialProfileType? ProfileType => CredentialProfileTypeDetector.DetectProfileType(Options);

		internal bool IsCallbackRequired => AWSCredentialsFactory.IsCallbackRequired(ProfileType);

		public CredentialProfile(string name, CredentialProfileOptions profileOptions)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Name must not be null or empty.");
			}
			Options = profileOptions ?? throw new ArgumentNullException("profileOptions");
			Name = name;
		}

		public AWSCredentials GetAWSCredentials(ICredentialProfileSource profileSource)
		{
			return GetAWSCredentials(profileSource, nonCallbackOnly: false);
		}

		internal AWSCredentials GetAWSCredentials(ICredentialProfileSource profileSource, bool nonCallbackOnly)
		{
			return AWSCredentialsFactory.GetAWSCredentials(this, profileSource, nonCallbackOnly);
		}

		private string GetPropertiesString()
		{
			return "{" + string.Join(",", (from p in Properties
				orderby p.Key
				select p.Key + "=" + p.Value).ToArray()) + "}";
		}

		public override string ToString()
		{
			return "[Name=" + Name + ",Options = " + Options?.ToString() + ",Region = " + ((Region == null) ? "" : Region.SystemName) + ",Properties = " + GetPropertiesString() + ",ProfileType = " + ProfileType.ToString() + ",UniqueKey = " + UniqueKey.ToString() + ",CanCreateAWSCredentials = " + CanCreateAWSCredentials + ",RetryMode= " + RetryMode.ToString() + ",MaxAttempts= " + MaxAttempts + "AccountIdEndpointMode= " + AccountIdEndpointMode.ToString() + "]";
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is CredentialProfile credentialProfile))
			{
				return false;
			}
			if (AWSSDKUtils.AreEqual(new object[6] { Name, Options, Region, ProfileType, CanCreateAWSCredentials, UniqueKey }, new object[6] { credentialProfile.Name, credentialProfile.Options, credentialProfile.Region, credentialProfile.ProfileType, credentialProfile.CanCreateAWSCredentials, credentialProfile.UniqueKey }))
			{
				return AWSSDKUtils.DictionariesAreEqual(Properties, credentialProfile.Properties);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(Name, Options, Region, ProfileType, CanCreateAWSCredentials, GetPropertiesString(), UniqueKey);
		}
	}
}
