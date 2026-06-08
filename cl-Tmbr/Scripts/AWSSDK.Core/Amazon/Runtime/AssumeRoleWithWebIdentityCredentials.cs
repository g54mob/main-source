using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.RuntimeDependencies;
using Amazon.Util;
using Amazon.Util.Internal;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime
{
	public class AssumeRoleWithWebIdentityCredentials : RefreshingAWSCredentials
	{
		private const int PREEMPT_EXPIRY_MINUTES = 15;

		private static readonly RegionEndpoint _defaultSTSClientRegion = RegionEndpoint.USEast1;

		private static readonly string _roleSessionNameDefault = Guid.NewGuid().ToString();

		public const string WebIdentityTokenFileEnvVariable = "AWS_WEB_IDENTITY_TOKEN_FILE";

		public const string RoleArnEnvVariable = "AWS_ROLE_ARN";

		public const string RoleSessionNameEnvVariable = "AWS_ROLE_SESSION_NAME";

		private const string RoleSessionNameRegexPattern = "^[\\w+=,.@-]{2,64}$";

		private static readonly Regex _roleSessionNameRegex = new Regex("^[\\w+=,.@-]{2,64}$", RegexOptions.Compiled);

		private readonly Logger _logger = Logger.GetLogger(typeof(AssumeRoleWithWebIdentityCredentials));

		private AssumeRoleWithWebIdentityCredentialsOptions _options;

		public string WebIdentityTokenFile { get; }

		public string RoleArn { get; }

		public string RoleSessionName { get; }

		private static Regex RoleSessionNameRegex()
		{
			return _roleSessionNameRegex;
		}

		public AssumeRoleWithWebIdentityCredentials(string webIdentityTokenFile, string roleArn, string roleSessionName)
			: this(webIdentityTokenFile, roleArn, roleSessionName, new AssumeRoleWithWebIdentityCredentialsOptions())
		{
		}

		public AssumeRoleWithWebIdentityCredentials(string webIdentityTokenFile, string roleArn, string roleSessionName, AssumeRoleWithWebIdentityCredentialsOptions options)
		{
			if (string.IsNullOrEmpty(webIdentityTokenFile))
			{
				throw new ArgumentNullException("webIdentityTokenFile", "The webIdentityTokenFile must be an absolute path.");
			}
			if (!AWSSDKUtils.IsAbsolutePath(webIdentityTokenFile))
			{
				throw new ArgumentException("The webIdentityTokenFile must be an absolute path.", "webIdentityTokenFile");
			}
			if (string.IsNullOrEmpty(roleArn))
			{
				throw new ArgumentNullException("roleArn", "The role ARN must be specified.");
			}
			if (!string.IsNullOrEmpty(roleSessionName) && !RoleSessionNameRegex().IsMatch(roleSessionName))
			{
				throw new ArgumentOutOfRangeException("roleSessionName", roleSessionName, $"The value must match the regex pattern @\"{RoleSessionNameRegex()}\".");
			}
			WebIdentityTokenFile = webIdentityTokenFile;
			RoleArn = roleArn;
			RoleSessionName = (string.IsNullOrEmpty(roleSessionName) ? _roleSessionNameDefault : roleSessionName);
			_options = options;
			base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_STS_ASSUME_ROLE_WEB_ID);
			base.PreemptExpiryTime = TimeSpan.FromMinutes(15.0);
		}

		public static AssumeRoleWithWebIdentityCredentials FromEnvironmentVariables()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("AWS_WEB_IDENTITY_TOKEN_FILE");
			string environmentVariable2 = Environment.GetEnvironmentVariable("AWS_ROLE_ARN");
			string environmentVariable3 = Environment.GetEnvironmentVariable("AWS_ROLE_SESSION_NAME");
			return new AssumeRoleWithWebIdentityCredentials(environmentVariable, environmentVariable2, environmentVariable3)
			{
				FeatureIdSources = { UserAgentFeatureId.CREDENTIALS_ENV_VARS_STS_WEB_ID_TOKEN }
			};
		}

		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			string webIdentityToken = null;
			for (int i = 0; i <= 3; i++)
			{
				try
				{
					using FileStream stream = new FileStream(WebIdentityTokenFile, FileMode.Open, FileAccess.Read);
					using StreamReader streamReader = new StreamReader(stream);
					webIdentityToken = streamReader.ReadToEnd();
				}
				catch (Exception ex)
				{
					if (i == 3)
					{
						_logger.Debug(ex, "A token could not be loaded from the WebIdentityTokenFile at " + WebIdentityTokenFile + ".");
						throw new InvalidOperationException("A token could not be loaded from the WebIdentityTokenFile.", ex);
					}
					DefaultRetryPolicy.WaitBeforeRetry(i, 1000);
					continue;
				}
				break;
			}
			AssumeRoleImmutableCredentials assumeRoleImmutableCredentials = CreateClient().CredentialsFromAssumeRoleWithWebIdentityAuthentication(webIdentityToken, RoleArn, RoleSessionName, _options);
			_logger.DebugFormat("New credentials created using assume role with web identity that expire at {0}", assumeRoleImmutableCredentials.Expiration.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
			return new CredentialsRefreshState(assumeRoleImmutableCredentials, assumeRoleImmutableCredentials.Expiration);
		}

		protected override async Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			string token = null;
			for (int retry = 0; retry <= 3; retry++)
			{
				try
				{
					using FileStream fileStream = new FileStream(WebIdentityTokenFile, FileMode.Open, FileAccess.Read);
					using StreamReader streamReader = new StreamReader(fileStream);
					token = await streamReader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex)
				{
					if (retry == 3)
					{
						_logger.Debug(ex, "A token could not be loaded from the WebIdentityTokenFile at " + WebIdentityTokenFile + ".");
						throw new InvalidOperationException("A token could not be loaded from the WebIdentityTokenFile.", ex);
					}
					DefaultRetryPolicy.WaitBeforeRetry(retry, 1000);
					continue;
				}
				break;
			}
			AssumeRoleImmutableCredentials assumeRoleImmutableCredentials = await CreateClient().CredentialsFromAssumeRoleWithWebIdentityAuthenticationAsync(token, RoleArn, RoleSessionName, _options).ConfigureAwait(continueOnCapturedContext: false);
			_logger.DebugFormat("New credentials created using assume role with web identity that expire at {0}", assumeRoleImmutableCredentials.Expiration.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
			return new CredentialsRefreshState(assumeRoleImmutableCredentials, assumeRoleImmutableCredentials.Expiration);
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		protected virtual ICoreAmazonSTS CreateClient()
		{
			RegionEndpoint regionEndpoint = FallbackRegionFactory.GetRegionEndpoint() ?? _defaultSTSClientRegion;
			ICoreAmazonSTS coreAmazonSTS = GlobalRuntimeDependencyRegistry.Instance.GetInstance<ICoreAmazonSTS>("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", new CreateInstanceContext(new SecurityTokenServiceClientContext
			{
				Action = SecurityTokenServiceClientContext.ActionContext.AssumeRoleAWSCredentials,
				Region = regionEndpoint,
				ProxySettings = _options?.ProxySettings
			}));
			if (coreAmazonSTS == null)
			{
				try
				{
					ClientConfig clientConfig = ServiceClientHelpers.CreateServiceConfig("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceConfig");
					clientConfig.RegionEndpoint = regionEndpoint;
					if (_options?.ProxySettings != null)
					{
						clientConfig.SetWebProxy(_options.ProxySettings);
					}
					coreAmazonSTS = ServiceClientHelpers.CreateServiceFromAssembly<ICoreAmazonSTS>("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", new AnonymousAWSCredentials(), regionEndpoint);
				}
				catch (Exception innerException)
				{
					if (InternalSDKUtils.IsRunningNativeAot())
					{
						throw new MissingRuntimeDependencyException("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", "RegisterSecurityTokenServiceClient");
					}
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Assembly {0} could not be found or loaded. This assembly must be available at runtime to use Amazon.Runtime.AssumeRoleAWSCredentials.", "AWSSDK.SecurityToken"), innerException);
				}
			}
			return coreAmazonSTS;
		}
	}
}
