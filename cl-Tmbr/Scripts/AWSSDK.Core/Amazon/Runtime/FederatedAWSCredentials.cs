using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.RuntimeDependencies;
using Amazon.Util.Internal;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime
{
	public class FederatedAWSCredentials : RefreshingAWSCredentials
	{
		private const int MaxAuthenticationRetries = 3;

		private static readonly RegionEndpoint DefaultSTSClientRegion = RegionEndpoint.USEast1;

		private static readonly TimeSpan MaximumCredentialTimespan = TimeSpan.FromHours(1.0);

		private static readonly TimeSpan DefaultPreemptExpiryTime = TimeSpan.FromMinutes(15.0);

		private readonly SAMLRoleSessionManager sessionManager = new SAMLRoleSessionManager();

		public SAMLEndpoint SAMLEndpoint { get; private set; }

		public string RoleArn { get; private set; }

		public FederatedAWSCredentialsOptions Options { get; private set; }

		public FederatedAWSCredentials(SAMLEndpoint samlEndpoint, string roleArn)
			: this(samlEndpoint, roleArn, new FederatedAWSCredentialsOptions())
		{
		}

		public FederatedAWSCredentials(SAMLEndpoint samlEndpoint, string roleArn, FederatedAWSCredentialsOptions options)
		{
			if (string.IsNullOrEmpty(roleArn))
			{
				throw new ArgumentException("RoleArn must not be null or empty.");
			}
			Options = options ?? throw new ArgumentNullException("options");
			SAMLEndpoint = samlEndpoint ?? throw new ArgumentNullException("samlEndpoint");
			RoleArn = roleArn;
			base.PreemptExpiryTime = DefaultPreemptExpiryTime;
			base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_STS_ASSUME_ROLE_SAML);
		}

		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			Validate();
			if (TryGetRoleSession(out var sessionCredentials))
			{
				CredentialsRefreshState credentialsRefreshState = new CredentialsRefreshState(sessionCredentials, sessionCredentials.Expires);
				if (!credentialsRefreshState.IsExpiredWithin(base.PreemptExpiryTime))
				{
					return credentialsRefreshState;
				}
			}
			CredentialsRefreshState credentialsRefreshState2 = null;
			int num = 0;
			do
			{
				try
				{
					NetworkCredential userCredential = GetUserCredential(num);
					credentialsRefreshState2 = Authenticate(userCredential);
				}
				catch (FederatedAuthenticationFailureException)
				{
					if (num < 3)
					{
						num++;
						continue;
					}
					throw;
				}
			}
			while (credentialsRefreshState2 == null && num < 3);
			return credentialsRefreshState2;
		}

		protected override async Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			Validate();
			if (TryGetRoleSession(out var sessionCredentials))
			{
				CredentialsRefreshState credentialsRefreshState = new CredentialsRefreshState(sessionCredentials, sessionCredentials.Expires);
				if (!credentialsRefreshState.IsExpiredWithin(base.PreemptExpiryTime))
				{
					return credentialsRefreshState;
				}
			}
			CredentialsRefreshState newState = null;
			int attempts = 0;
			do
			{
				try
				{
					NetworkCredential userCredential = GetUserCredential(attempts);
					newState = await AuthenticateAsync(userCredential).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (FederatedAuthenticationFailureException)
				{
					if (attempts < 3)
					{
						attempts++;
						continue;
					}
					throw;
				}
			}
			while (newState == null && attempts < 3);
			return newState;
		}

		private NetworkCredential GetUserCredential(int attempts)
		{
			NetworkCredential networkCredential = null;
			if (Options.UserIdentity != null)
			{
				if (Options.CredentialRequestCallback != null)
				{
					CredentialRequestCallbackArgs arg = new CredentialRequestCallbackArgs
					{
						ProfileName = Options.ProfileName,
						UserIdentity = Options.UserIdentity,
						CustomState = Options.CustomCallbackState,
						PreviousAuthenticationFailed = (attempts > 0)
					};
					networkCredential = Options.CredentialRequestCallback(arg);
					if (networkCredential == null)
					{
						throw new FederatedAuthenticationCancelledException("User cancelled credential request.");
					}
				}
				else
				{
					Logger.GetLogger(typeof(FederatedAWSCredentials)).InfoFormat("FederatedAWSCredentials configured for a specific user but no credential request callback registered; falling back to default identity.");
				}
			}
			return networkCredential;
		}

		private CredentialsRefreshState Authenticate(ICredentials userCredential)
		{
			RegionEndpoint regionEndpoint = Options.STSRegion;
			if (regionEndpoint == null)
			{
				regionEndpoint = FallbackRegionFactory.GetRegionEndpoint();
			}
			if (regionEndpoint == null)
			{
				regionEndpoint = DefaultSTSClientRegion;
			}
			ICoreAmazonSTS sTSClient = GetSTSClient(regionEndpoint);
			try
			{
				SAMLImmutableCredentials sAMLImmutableCredentials = sTSClient.CredentialsFromSAMLAuthentication(SAMLEndpoint.EndpointUri.ToString(), SAMLEndpoint.AuthenticationType.ToString(), RoleArn, MaximumCredentialTimespan, userCredential);
				RegisterRoleSession(sAMLImmutableCredentials);
				return new CredentialsRefreshState(sAMLImmutableCredentials, sAMLImmutableCredentials.Expires);
			}
			catch (Exception innerException)
			{
				AmazonClientException ex = new AmazonClientException("Credential generation from SAML authentication failed.", innerException);
				Logger.GetLogger(typeof(FederatedAWSCredentials)).Error(ex, ex.Message);
				throw ex;
			}
		}

		private async Task<CredentialsRefreshState> AuthenticateAsync(ICredentials userCredential)
		{
			RegionEndpoint regionEndpoint = Options.STSRegion;
			if (regionEndpoint == null)
			{
				regionEndpoint = FallbackRegionFactory.GetRegionEndpoint();
			}
			if (regionEndpoint == null)
			{
				regionEndpoint = DefaultSTSClientRegion;
			}
			ICoreAmazonSTS sTSClient = GetSTSClient(regionEndpoint);
			try
			{
				SAMLImmutableCredentials sAMLImmutableCredentials = await sTSClient.CredentialsFromSAMLAuthenticationAsync(SAMLEndpoint.EndpointUri.ToString(), SAMLEndpoint.AuthenticationType.ToString(), RoleArn, MaximumCredentialTimespan, userCredential).ConfigureAwait(continueOnCapturedContext: false);
				RegisterRoleSession(sAMLImmutableCredentials);
				return new CredentialsRefreshState(sAMLImmutableCredentials, sAMLImmutableCredentials.Expires);
			}
			catch (Exception innerException)
			{
				AmazonClientException ex = new AmazonClientException("Credential generation from SAML authentication failed.", innerException);
				Logger.GetLogger(typeof(FederatedAWSCredentials)).Error(ex, ex.Message);
				throw ex;
			}
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
					if (Options.ProxySettings != null)
					{
						clientConfig.SetWebProxy(Options.ProxySettings);
					}
					coreAmazonSTS = ServiceClientHelpers.CreateServiceFromAssembly<ICoreAmazonSTS>("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", new AnonymousAWSCredentials(), clientConfig);
				}
				catch (Exception innerException)
				{
					if (InternalSDKUtils.IsRunningNativeAot())
					{
						throw new MissingRuntimeDependencyException("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", "RegisterSecurityTokenServiceClient");
					}
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Assembly {0} could not be found or loaded. This assembly must be available at runtime to use this profile class.", "AWSSDK.SecurityToken"), innerException);
				}
			}
			return coreAmazonSTS;
		}

		private string GetRoleSessionName()
		{
			if (string.IsNullOrEmpty(Options.ProfileName))
			{
				return SAMLEndpoint.Name + "," + RoleArn + "," + Options.UserIdentity;
			}
			return Options.ProfileName;
		}

		private bool TryGetRoleSession(out SAMLImmutableCredentials sessionCredentials)
		{
			if (SAMLRoleSessionManager.IsAvailable)
			{
				return sessionManager.TryGetRoleSession(GetRoleSessionName(), out sessionCredentials);
			}
			sessionCredentials = null;
			return false;
		}

		private void RegisterRoleSession(SAMLImmutableCredentials sessionCredentials)
		{
			if (SAMLRoleSessionManager.IsAvailable)
			{
				sessionManager.RegisterRoleSession(GetRoleSessionName(), sessionCredentials);
			}
		}

		public override void ClearCredentials()
		{
			base.ClearCredentials();
		}
	}
}
