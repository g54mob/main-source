using System;
using System.Globalization;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.RuntimeDependencies;
using Amazon.Util.Internal;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime
{
	public class AssumeRoleAWSCredentials : RefreshingAWSCredentials
	{
		private RegionEndpoint DefaultSTSClientRegion = RegionEndpoint.USEast1;

		private Logger _logger = Logger.GetLogger(typeof(AssumeRoleAWSCredentials));

		public AWSCredentials SourceCredentials { get; private set; }

		public string RoleArn { get; private set; }

		public string RoleSessionName { get; private set; }

		public AssumeRoleAWSCredentialsOptions Options { get; private set; }

		public AssumeRoleAWSCredentials(AWSCredentials sourceCredentials, string roleArn, string roleSessionName)
			: this(sourceCredentials, roleArn, roleSessionName, new AssumeRoleAWSCredentialsOptions())
		{
		}

		public AssumeRoleAWSCredentials(AWSCredentials sourceCredentials, string roleArn, string roleSessionName, AssumeRoleAWSCredentialsOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			SourceCredentials = sourceCredentials;
			RoleArn = roleArn;
			RoleSessionName = roleSessionName;
			Options = options;
			base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_STS_ASSUME_ROLE);
			base.PreemptExpiryTime = TimeSpan.FromMinutes(15.0);
		}

		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			RegionEndpoint region = FallbackRegionFactory.GetRegionEndpoint() ?? DefaultSTSClientRegion;
			AssumeRoleImmutableCredentials assumeRoleImmutableCredentials = GetSTSClient(region).CredentialsFromAssumeRoleAuthentication(RoleArn, RoleSessionName, Options);
			_logger.DebugFormat("New credentials created for assume role that expire at {0}", assumeRoleImmutableCredentials.Expiration.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
			return new CredentialsRefreshState(assumeRoleImmutableCredentials, assumeRoleImmutableCredentials.Expiration);
		}

		protected override async Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			RegionEndpoint region = FallbackRegionFactory.GetRegionEndpoint() ?? DefaultSTSClientRegion;
			AssumeRoleImmutableCredentials assumeRoleImmutableCredentials = await GetSTSClient(region).CredentialsFromAssumeRoleAuthenticationAsync(RoleArn, RoleSessionName, Options).ConfigureAwait(continueOnCapturedContext: false);
			_logger.DebugFormat("New credentials created for assume role that expire at {0}", assumeRoleImmutableCredentials.Expiration.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
			return new CredentialsRefreshState(assumeRoleImmutableCredentials, assumeRoleImmutableCredentials.Expiration);
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		private ICoreAmazonSTS GetSTSClient(RegionEndpoint region)
		{
			ICoreAmazonSTS coreAmazonSTS = GlobalRuntimeDependencyRegistry.Instance.GetInstance<ICoreAmazonSTS>("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", new CreateInstanceContext(new SecurityTokenServiceClientContext
			{
				Action = SecurityTokenServiceClientContext.ActionContext.AssumeRoleAWSCredentials,
				Region = region,
				ProxySettings = Options?.ProxySettings
			}));
			if (coreAmazonSTS == null)
			{
				try
				{
					ClientConfig clientConfig = ServiceClientHelpers.CreateServiceConfig("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceConfig");
					clientConfig.RegionEndpoint = region;
					if (Options?.ProxySettings != null)
					{
						clientConfig.SetWebProxy(Options.ProxySettings);
					}
					coreAmazonSTS = ServiceClientHelpers.CreateServiceFromAssembly<ICoreAmazonSTS>("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", SourceCredentials, clientConfig);
				}
				catch (Exception innerException)
				{
					if (InternalSDKUtils.IsRunningNativeAot())
					{
						throw new MissingRuntimeDependencyException("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", "RegisterSecurityTokenServiceClient");
					}
					InvalidOperationException ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Assembly {0} could not be found or loaded. This assembly must be available at runtime to use Amazon.Runtime.AssumeRoleAWSCredentials.", "AWSSDK.SecurityToken"), innerException);
					Logger.GetLogger(typeof(AssumeRoleAWSCredentials)).Error(ex, ex.Message);
					throw ex;
				}
			}
			return coreAmazonSTS;
		}
	}
}
