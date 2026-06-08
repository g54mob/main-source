using System;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal;
using Amazon.S3.Internal;
using Amazon.Util.Internal;

namespace Amazon.S3
{
	public class AmazonS3Config : ClientConfig
	{
		private const string UseArnRegionEnvName = "AWS_S3_USE_ARN_REGION";

		private const string DisableS3ExpressSessionAuthEnvName = "AWS_S3_DISABLE_EXPRESS_SESSION_AUTH";

		private const string AccelerateEndpointSuffix = "s3-accelerate.amazonaws.com";

		private const string AccelerateDualstackEndpointSuffix = "s3-accelerate.dualstack.amazonaws.com";

		private const string AwsProfileEnvironmentVariable = "AWS_PROFILE";

		private const string DefaultProfileName = "default";

		private const string AwsS3UsEast1RegionalEndpointsEnvironmentVariable = "AWS_S3_US_EAST_1_REGIONAL_ENDPOINT";

		private const string DisableMRAPEnvName = "AWS_S3_DISABLE_MULTIREGION_ACCESS_POINTS";

		private bool forcePathStyle;

		private bool useAccelerateEndpoint;

		private S3UsEast1RegionalEndpointValue? s3UsEast1RegionalEndpointValue;

		private readonly string legacyUSEast1GlobalRegionSystemName = RegionEndpoint.USEast1.SystemName;

		private static CredentialProfileStoreChain credentialProfileChain = new CredentialProfileStoreChain();

		private static CredentialProfile _profile;

		private static object _triedToResolveProfileLock = new object();

		private static bool _triedToResolveProfile = false;

		private IS3ExpressCredentialProvider s3ExpressCredentialProvider;

		private bool? _useArnRegion;

		private object _useArnRegionLock = new object();

		private bool? _disableS3ExpressSessionAuth;

		private object _disableS3ExpressSessionAuthLock = new object();

		private bool? _disableMultiregionAccessPoints;

		private static readonly string UserAgentString = InternalSDKUtils.BuildUserAgentString("S3", "4.0.0.6");

		private static readonly AmazonS3EndpointResolver EndpointResolver = new AmazonS3EndpointResolver();

		private string _userAgent = UserAgentString;

		public IS3ExpressCredentialProvider S3ExpressCredentialProvider
		{
			get
			{
				return s3ExpressCredentialProvider;
			}
			set
			{
				s3ExpressCredentialProvider = value;
			}
		}

		public bool ForcePathStyle
		{
			get
			{
				return forcePathStyle;
			}
			set
			{
				forcePathStyle = value;
			}
		}

		public bool UseAccelerateEndpoint
		{
			get
			{
				return useAccelerateEndpoint;
			}
			set
			{
				useAccelerateEndpoint = value;
			}
		}

		public bool UseArnRegion
		{
			get
			{
				if (_useArnRegion.HasValue)
				{
					return _useArnRegion == true;
				}
				ResolveCredentialProfile();
				lock (_useArnRegionLock)
				{
					if (_useArnRegion.HasValue)
					{
						return _useArnRegion.Value;
					}
					if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_S3_USE_ARN_REGION")) && bool.TryParse(Environment.GetEnvironmentVariable("AWS_S3_USE_ARN_REGION"), out var result))
					{
						_useArnRegion = result;
					}
					if (!_useArnRegion.HasValue)
					{
						_useArnRegion = _profile?.S3UseArnRegion;
					}
					if (!_useArnRegion.HasValue)
					{
						_useArnRegion = base.RegionEndpoint?.SystemName == RegionEndpoint.USEast1.SystemName;
					}
					return _useArnRegion.Value;
				}
			}
			set
			{
				lock (_useArnRegionLock)
				{
					_useArnRegion = value;
				}
			}
		}

		public bool DisableS3ExpressSessionAuth
		{
			get
			{
				if (_disableS3ExpressSessionAuth.HasValue)
				{
					return _disableS3ExpressSessionAuth == true;
				}
				ResolveCredentialProfile();
				lock (_disableS3ExpressSessionAuthLock)
				{
					if (_disableS3ExpressSessionAuth.HasValue)
					{
						return _disableS3ExpressSessionAuth.Value;
					}
					if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_S3_DISABLE_EXPRESS_SESSION_AUTH")) && bool.TryParse(Environment.GetEnvironmentVariable("AWS_S3_DISABLE_EXPRESS_SESSION_AUTH"), out var result))
					{
						_disableS3ExpressSessionAuth = result;
						return _disableS3ExpressSessionAuth.Value;
					}
					_disableS3ExpressSessionAuth = _profile?.S3DisableExpressSessionAuth;
					return _disableS3ExpressSessionAuth == true;
				}
			}
			set
			{
				lock (_disableS3ExpressSessionAuthLock)
				{
					_disableS3ExpressSessionAuth = value;
				}
			}
		}

		public bool DisableMultiregionAccessPoints
		{
			get
			{
				if (!_disableMultiregionAccessPoints.HasValue)
				{
					_disableMultiregionAccessPoints = CheckDisableMRAPEnvironmentVariable() ?? CheckDisableMRAPCredentialsFile();
				}
				return _disableMultiregionAccessPoints == true;
			}
			set
			{
				_disableMultiregionAccessPoints = value;
			}
		}

		public S3UsEast1RegionalEndpointValue? USEast1RegionalEndpointValue
		{
			get
			{
				if (!s3UsEast1RegionalEndpointValue.HasValue)
				{
					s3UsEast1RegionalEndpointValue = CheckS3EnvironmentVariable() ?? CheckCredentialsFile() ?? base.DefaultConfiguration.S3UsEast1RegionalEndpoint;
				}
				return s3UsEast1RegionalEndpointValue;
			}
			set
			{
				s3UsEast1RegionalEndpointValue = value;
			}
		}

		internal string AccelerateEndpoint
		{
			get
			{
				if (!base.UseDualstackEndpoint)
				{
					return "s3-accelerate.amazonaws.com";
				}
				return "s3-accelerate.dualstack.amazonaws.com";
			}
		}

		public new static string ServiceId => "S3";

		public override string RegionEndpointServiceName => "s3";

		public override string ServiceVersion => "2006-03-01";

		public override string UserAgent => _userAgent;

		private static void ResolveCredentialProfile()
		{
			if (_triedToResolveProfile)
			{
				return;
			}
			lock (_triedToResolveProfileLock)
			{
				if (!_triedToResolveProfile)
				{
					string profileName = Environment.GetEnvironmentVariable("AWS_PROFILE") ?? "default";
					credentialProfileChain.TryGetProfile(profileName, out _profile);
					_triedToResolveProfile = true;
				}
			}
		}

		protected override void Initialize()
		{
			base.AllowAutoRedirect = false;
			base.Timeout = ClientConfig.MaxTimeout;
		}

		private S3UsEast1RegionalEndpointValue? GetEndpointFlagValueForUsEast1Regional()
		{
			if (USEast1RegionalEndpointValue.HasValue)
			{
				return USEast1RegionalEndpointValue;
			}
			return CheckS3EnvironmentVariable() ?? CheckCredentialsFile();
		}

		public override void Validate()
		{
			base.Validate();
			if (ForcePathStyle && UseAccelerateEndpoint)
			{
				throw new AmazonClientException("S3 accelerate is not compatible with Path style requests. Disable Path style requests using AmazonS3Config.ForcePathStyle property to use S3 accelerate.");
			}
			if (!string.IsNullOrEmpty(base.ServiceURL) && (base.ServiceURL.IndexOf("s3-accelerate.amazonaws.com", StringComparison.OrdinalIgnoreCase) >= 0 || base.ServiceURL.IndexOf("s3-accelerate.dualstack.amazonaws.com", StringComparison.OrdinalIgnoreCase) >= 0))
			{
				if (base.RegionEndpoint == null && string.IsNullOrEmpty(base.AuthenticationRegion))
				{
					throw new AmazonClientException("Specify a region using AmazonS3Config.RegionEndpoint or AmazonS3Config.AuthenticationRegion to use S3 accelerate.");
				}
				if (base.RegionEndpoint == null && !string.IsNullOrEmpty(base.AuthenticationRegion))
				{
					base.RegionEndpoint = RegionEndpoint.GetBySystemName(base.AuthenticationRegion);
				}
				UseAccelerateEndpoint = true;
			}
		}

		private static S3UsEast1RegionalEndpointValue? CheckS3EnvironmentVariable()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("AWS_S3_US_EAST_1_REGIONAL_ENDPOINT");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				if (!Enum.TryParse<S3UsEast1RegionalEndpointValue>(environmentVariable, ignoreCase: true, out var result))
				{
					throw new InvalidOperationException("Invalid value for AWS_S3_US_EAST_1_REGIONAL_ENDPOINT variable. A string regional/legacy is expected.");
				}
				return result;
			}
			return null;
		}

		private static S3UsEast1RegionalEndpointValue? CheckCredentialsFile()
		{
			ResolveCredentialProfile();
			return _profile?.S3RegionalEndpoint;
		}

		private static bool? CheckDisableMRAPEnvironmentVariable()
		{
			bool? result = null;
			if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_S3_DISABLE_MULTIREGION_ACCESS_POINTS")))
			{
				if (!bool.TryParse(Environment.GetEnvironmentVariable("AWS_S3_DISABLE_MULTIREGION_ACCESS_POINTS"), out var result2))
				{
					throw new InvalidOperationException("Invalid value for AWS_S3_DISABLE_MULTIREGION_ACCESS_POINTS environment variable. true/false is expected.");
				}
				result = result2;
			}
			return result;
		}

		private static bool? CheckDisableMRAPCredentialsFile()
		{
			ResolveCredentialProfile();
			return _profile?.S3DisableMultiRegionAccessPoints;
		}

		public AmazonS3Config()
			: base(new DefaultConfigurationProvider(AmazonS3DefaultConfiguration.GetAllConfigurations()))
		{
			base.ServiceId = "S3";
			base.AuthenticationServiceName = "s3";
			base.EndpointProvider = new AmazonS3EndpointProvider();
		}

		public override Endpoint DetermineServiceOperationEndpoint(ServiceOperationEndpointParameters parameters)
		{
			ExecutionContext executionContext = new ExecutionContext(new RequestContext(enableMetric: false)
			{
				ClientConfig = this,
				OriginalRequest = parameters.Request,
				Request = new DefaultRequest(parameters.Request, ServiceId)
				{
					AlternateEndpoint = parameters.AlternateEndpoint
				}
			}, null);
			return EndpointResolver.GetEndpoint(executionContext);
		}
	}
}
