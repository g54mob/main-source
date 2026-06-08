using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime
{
	public class GenericContainerCredentials : URIBasedRefreshingCredentialHelper
	{
		private const int MaxRetries = 5;

		internal const string RelativeURIEnvVariable = "AWS_CONTAINER_CREDENTIALS_RELATIVE_URI";

		internal const string FullURIEnvVariable = "AWS_CONTAINER_CREDENTIALS_FULL_URI";

		internal const string AuthorizationTokenEnvVariable = "AWS_CONTAINER_AUTHORIZATION_TOKEN";

		internal const string AuthorizationTokenFileEnvVariable = "AWS_CONTAINER_AUTHORIZATION_TOKEN_FILE";

		private const string ECSContainerHostAddress = "169.254.170.2";

		private const string EKSContainerHostIPv4Address = "169.254.170.23";

		private const string EKSContainerHostIPv6Address = "[fd00:ec2::23]";

		private readonly string[] AllowedHosts = new string[3] { "169.254.170.2", "169.254.170.23", "[fd00:ec2::23]" };

		private const string MissingEnvErrorMessage = "Cannot fetch credentials from container - neither {0} or {1} environment variables are set.";

		private const string InvalidHostErrorMessage = "Cannot fetch credentials from container - the full URI contains an invalid host: {0}";

		internal Uri ResolvedEndpointUri { get; private set; }

		public GenericContainerCredentials()
		{
			base.PreemptExpiryTime = TimeSpan.FromMinutes(15.0);
			DetermineEndpoint();
			base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_HTTP);
		}

		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			JitteredDelay jitteredDelay = new JitteredDelay(TimeSpan.FromMilliseconds(200.0), TimeSpan.FromMilliseconds(50.0));
			int num = 1;
			SecurityCredentials objectFromResponse;
			while (true)
			{
				try
				{
					Dictionary<string, string> headers = CreateAuthorizationHeader();
					objectFromResponse = URIBasedRefreshingCredentialHelper.GetObjectFromResponse<SecurityCredentials, SecurityCredentialsJsonSerializerContexts>(ResolvedEndpointUri, null, headers);
					if (objectFromResponse != null)
					{
						break;
					}
				}
				catch (Exception innerException)
				{
					if (num == 5)
					{
						while (innerException.InnerException != null)
						{
							innerException = innerException.InnerException;
						}
						throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Unable to retrieve credentials. Message = \"{0}\"", innerException.Message));
					}
				}
				AWSSDKUtils.Sleep(jitteredDelay.Next());
				num++;
			}
			return new CredentialsRefreshState(new ImmutableCredentials(objectFromResponse.AccessKeyId, objectFromResponse.SecretAccessKey, objectFromResponse.Token, objectFromResponse.AccountId), objectFromResponse.Expiration);
		}

		protected override async Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			JitteredDelay retry = new JitteredDelay(TimeSpan.FromMilliseconds(200.0), TimeSpan.FromMilliseconds(50.0));
			int i = 1;
			SecurityCredentials securityCredentials;
			while (true)
			{
				try
				{
					Dictionary<string, string> headers = CreateAuthorizationHeader();
					securityCredentials = await URIBasedRefreshingCredentialHelper.GetObjectFromResponseAsync<SecurityCredentials, SecurityCredentialsJsonSerializerContexts>(ResolvedEndpointUri, null, headers).ConfigureAwait(continueOnCapturedContext: false);
					if (securityCredentials != null)
					{
						break;
					}
				}
				catch (Exception innerException)
				{
					if (i == 5)
					{
						while (innerException.InnerException != null)
						{
							innerException = innerException.InnerException;
						}
						throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Unable to retrieve credentials. Message = \"{0}\"", innerException.Message));
					}
				}
				await Task.Delay(retry.Next()).ConfigureAwait(continueOnCapturedContext: false);
				i++;
			}
			return new CredentialsRefreshState(new ImmutableCredentials(securityCredentials.AccessKeyId, securityCredentials.SecretAccessKey, securityCredentials.Token, securityCredentials.AccountId), securityCredentials.Expiration);
		}

		internal void DetermineEndpoint()
		{
			Uri uri = null;
			string environmentVariable = Environment.GetEnvironmentVariable("AWS_CONTAINER_CREDENTIALS_RELATIVE_URI");
			string environmentVariable2 = Environment.GetEnvironmentVariable("AWS_CONTAINER_CREDENTIALS_FULL_URI");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				uri = new UriBuilder("169.254.170.2")
				{
					Path = environmentVariable
				}.Uri;
			}
			else if (!string.IsNullOrEmpty(environmentVariable2))
			{
				uri = new Uri(environmentVariable2);
			}
			if (uri == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Cannot fetch credentials from container - neither {0} or {1} environment variables are set.", "AWS_CONTAINER_CREDENTIALS_RELATIVE_URI", "AWS_CONTAINER_CREDENTIALS_FULL_URI"));
			}
			if (uri.Scheme != Uri.UriSchemeHttps && !AllowedHosts.Contains(uri.Host) && !uri.IsLoopback)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Cannot fetch credentials from container - the full URI contains an invalid host: {0}", uri.ToString()));
			}
			ResolvedEndpointUri = uri;
		}

		internal static Dictionary<string, string> CreateAuthorizationHeader()
		{
			Dictionary<string, string> result = null;
			string text = null;
			string environmentVariable = Environment.GetEnvironmentVariable("AWS_CONTAINER_AUTHORIZATION_TOKEN_FILE");
			string environmentVariable2 = Environment.GetEnvironmentVariable("AWS_CONTAINER_AUTHORIZATION_TOKEN");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				text = File.ReadAllText(environmentVariable);
			}
			else if (!string.IsNullOrEmpty(environmentVariable2))
			{
				text = environmentVariable2;
			}
			if (!string.IsNullOrEmpty(text))
			{
				if (text.Contains("\r\n"))
				{
					throw new InvalidOperationException("Authorization token must not contain the newline sequence.");
				}
				result = new Dictionary<string, string> { { "Authorization", text } };
			}
			return result;
		}
	}
}
