using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using AWSSDK.Runtime.Internal.Util;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime
{
	public class InstanceProfileAWSCredentials : URIBasedRefreshingCredentialHelper
	{
		private static readonly TimeSpan _preemptExpiryTime = TimeSpan.FromMinutes(15.0);

		private static readonly TimeSpan _refreshAttemptPeriod = TimeSpan.FromHours(1.0);

		private CredentialsRefreshState _currentRefreshState;

		private readonly IWebProxy _proxy;

		private const string _receivedExpiredCredentialsFromIMDS = "Attempting credential expiration extension due to a credential service availability issue. A refresh of these credentials will be attempted again in 5-10 minutes.";

		private Logger _logger;

		private static string[] AliasSeparators = new string[1] { "<br/>" };

		private static string Server = EC2InstanceMetadata.ServiceEndpoint;

		private static string RolesPath = "/latest/meta-data/iam/security-credentials/";

		private static string InfoPath = "/latest/meta-data/iam/info";

		public string Role { get; set; }

		private static Uri RolesUri => new Uri(Server + RolesPath);

		private Uri CurrentRoleUri => new Uri(Server + RolesPath + Role);

		private static Uri InfoUri => new Uri(Server + InfoPath);

		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			CredentialsRefreshState credentialsRefreshState = null;
			string token = EC2InstanceMetadata.FetchApiToken();
			try
			{
				credentialsRefreshState = GetRefreshState(token);
			}
			catch (Exception ex)
			{
				if (ExceptionUtils.DetermineHttpStatusCode(ex) == HttpStatusCode.Unauthorized)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex, "EC2 Metadata service returned unauthorized for token based secure data flow.");
					throw;
				}
				Logger.GetLogger(typeof(InstanceProfileAWSCredentials)).InfoFormat("Error getting credentials from Instance Profile service: {0}", ex);
				if (_currentRefreshState != null)
				{
					DateTime expiration = AWSSDKUtils.CorrectedUtcNow + TimeSpan.FromMinutes(2.0);
					_currentRefreshState = new CredentialsRefreshState(_currentRefreshState.Credentials.Copy(), expiration);
					return _currentRefreshState;
				}
			}
			if (credentialsRefreshState != null && credentialsRefreshState.IsExpiredWithin(TimeSpan.Zero))
			{
				_logger.InfoFormat("Attempting credential expiration extension due to a credential service availability issue. A refresh of these credentials will be attempted again in 5-10 minutes.");
				DateTime expiration2 = AWSSDKUtils.CorrectedUtcNow + TimeSpan.FromMinutes(new Random().Next(5, 11));
				_currentRefreshState = new CredentialsRefreshState(credentialsRefreshState.Credentials.Copy(), expiration2);
				return _currentRefreshState;
			}
			if (credentialsRefreshState != null)
			{
				_currentRefreshState = credentialsRefreshState;
			}
			if (_currentRefreshState == null)
			{
				try
				{
					_currentRefreshState = GetRefreshState(token);
				}
				catch (Exception ex2)
				{
					if (ExceptionUtils.DetermineHttpStatusCode(ex2) == HttpStatusCode.Unauthorized)
					{
						Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex2, "EC2 Metadata service returned unauthorized for token based secure data flow.");
					}
					throw;
				}
			}
			return GetEarlyRefreshState(_currentRefreshState);
		}

		protected override async Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			CredentialsRefreshState newState = null;
			string token = await EC2InstanceMetadata.FetchApiTokenAsync().ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				newState = await GetRefreshStateAsync(token).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				if (ExceptionUtils.DetermineHttpStatusCode(ex) == HttpStatusCode.Unauthorized)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex, "EC2 Metadata service returned unauthorized for token based secure data flow.");
					throw;
				}
				Logger.GetLogger(typeof(InstanceProfileAWSCredentials)).InfoFormat("Error getting credentials from Instance Profile service: {0}", ex);
				if (_currentRefreshState != null)
				{
					DateTime expiration = AWSSDKUtils.CorrectedUtcNow + TimeSpan.FromMinutes(2.0);
					_currentRefreshState = new CredentialsRefreshState(_currentRefreshState.Credentials.Copy(), expiration);
					return _currentRefreshState;
				}
			}
			if (newState?.IsExpiredWithin(TimeSpan.Zero) ?? false)
			{
				_logger.InfoFormat("Attempting credential expiration extension due to a credential service availability issue. A refresh of these credentials will be attempted again in 5-10 minutes.");
				DateTime expiration2 = AWSSDKUtils.CorrectedUtcNow + TimeSpan.FromMinutes(new Random().Next(5, 11));
				_currentRefreshState = new CredentialsRefreshState(newState.Credentials.Copy(), expiration2);
				return _currentRefreshState;
			}
			if (newState != null)
			{
				_currentRefreshState = newState;
			}
			if (_currentRefreshState == null)
			{
				try
				{
					_currentRefreshState = await GetRefreshStateAsync(token).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex2)
				{
					if (ExceptionUtils.DetermineHttpStatusCode(ex2) == HttpStatusCode.Unauthorized)
					{
						Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex2, "EC2 Metadata service returned unauthorized for token based secure data flow.");
					}
					throw;
				}
			}
			return GetEarlyRefreshState(_currentRefreshState);
		}

		public InstanceProfileAWSCredentials(string role)
			: this(role, null)
		{
		}

		public InstanceProfileAWSCredentials(string role, IWebProxy proxy)
		{
			_logger = Logger.GetLogger(GetType());
			_proxy = proxy;
			if (role == null)
			{
				throw new ArgumentNullException("role");
			}
			if (IsNullOrWhiteSpace(role))
			{
				throw new ArgumentException("The argument 'role' must contain a valid role name.");
			}
			Role = role;
			base.PreemptExpiryTime = _preemptExpiryTime;
		}

		public InstanceProfileAWSCredentials()
			: this((IWebProxy)null)
		{
		}

		public InstanceProfileAWSCredentials(IWebProxy proxy)
			: this(GetFirstRole(proxy), proxy)
		{
		}

		public static IEnumerable<string> GetAvailableRoles()
		{
			return GetAvailableRoles(null);
		}

		public static IEnumerable<string> GetAvailableRoles(IWebProxy proxy)
		{
			string token = EC2InstanceMetadata.FetchApiToken();
			_ = string.Empty;
			string contents;
			try
			{
				contents = URIBasedRefreshingCredentialHelper.GetContents(RolesUri, proxy, CreateMetadataTokenHeaders(token));
			}
			catch (Exception ex)
			{
				if (ExceptionUtils.DetermineHttpStatusCode(ex) == HttpStatusCode.Unauthorized)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex, "EC2 Metadata service returned unauthorized for token based secure data flow.");
				}
				throw;
			}
			if (string.IsNullOrEmpty(contents))
			{
				yield break;
			}
			string[] array = contents.Split(AliasSeparators, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i].Trim();
				if (!string.IsNullOrEmpty(text))
				{
					yield return text;
				}
			}
		}

		public static async Task<IEnumerable<string>> GetAvailableRolesAsync(IWebProxy proxy)
		{
			string token = await EC2InstanceMetadata.FetchApiTokenAsync().ConfigureAwait(continueOnCapturedContext: false);
			List<string> roles = new List<string>();
			_ = string.Empty;
			string text;
			try
			{
				text = await URIBasedRefreshingCredentialHelper.GetContentsAsync(RolesUri, proxy, CreateMetadataTokenHeaders(token)).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				if (ExceptionUtils.DetermineHttpStatusCode(ex) == HttpStatusCode.Unauthorized)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex, "EC2 Metadata service returned unauthorized for token based secure data flow.");
				}
				throw;
			}
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(AliasSeparators, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					string text2 = array[i].Trim();
					if (!string.IsNullOrEmpty(text2))
					{
						roles.Add(text2);
					}
				}
			}
			return roles;
		}

		private CredentialsRefreshState GetEarlyRefreshState(CredentialsRefreshState state)
		{
			DateTime dateTime = AWSSDKUtils.CorrectedUtcNow + _refreshAttemptPeriod + base.PreemptExpiryTime;
			if (dateTime > state.Expiration)
			{
				dateTime = state.Expiration;
			}
			return new CredentialsRefreshState(state.Credentials.Copy(), dateTime);
		}

		private CredentialsRefreshState GetRefreshState(string token)
		{
			SecurityInfo serviceInfo = GetServiceInfo(_proxy, token);
			if (!string.IsNullOrEmpty(serviceInfo.Message))
			{
				throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Unable to retrieve credentials. Message = \"{0}\".", serviceInfo.Message));
			}
			SecurityCredentials roleCredentials = GetRoleCredentials(token);
			return new CredentialsRefreshState(new ImmutableCredentials(roleCredentials.AccessKeyId, roleCredentials.SecretAccessKey, roleCredentials.Token), roleCredentials.Expiration);
		}

		private async Task<CredentialsRefreshState> GetRefreshStateAsync(string token)
		{
			SecurityInfo securityInfo = await GetServiceInfoAsync(_proxy, token).ConfigureAwait(continueOnCapturedContext: false);
			if (!string.IsNullOrEmpty(securityInfo.Message))
			{
				throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Unable to retrieve credentials. Message = \"{0}\".", securityInfo.Message));
			}
			SecurityCredentials securityCredentials = await GetRoleCredentialsAsync(token).ConfigureAwait(continueOnCapturedContext: false);
			return new CredentialsRefreshState(new ImmutableCredentials(securityCredentials.AccessKeyId, securityCredentials.SecretAccessKey, securityCredentials.Token), securityCredentials.Expiration);
		}

		private static SecurityInfo GetServiceInfo(IWebProxy proxy, string token)
		{
			CheckIsIMDSEnabled();
			return URIBasedRefreshingCredentialHelper.GetObjectFromResponse<SecurityInfo, SecurityInfoJsonSerializerContexts>(InfoUri, proxy, CreateMetadataTokenHeaders(token));
		}

		private static async Task<SecurityInfo> GetServiceInfoAsync(IWebProxy proxy, string token)
		{
			CheckIsIMDSEnabled();
			return await URIBasedRefreshingCredentialHelper.GetObjectFromResponseAsync<SecurityInfo, SecurityInfoJsonSerializerContexts>(InfoUri, proxy, CreateMetadataTokenHeaders(token)).ConfigureAwait(continueOnCapturedContext: false);
		}

		private SecurityCredentials GetRoleCredentials(string token)
		{
			CheckIsIMDSEnabled();
			return URIBasedRefreshingCredentialHelper.GetObjectFromResponse<SecurityCredentials, SecurityCredentialsJsonSerializerContexts>(CurrentRoleUri, _proxy, CreateMetadataTokenHeaders(token));
		}

		private async Task<SecurityCredentials> GetRoleCredentialsAsync(string token)
		{
			CheckIsIMDSEnabled();
			return await URIBasedRefreshingCredentialHelper.GetObjectFromResponseAsync<SecurityCredentials, SecurityCredentialsJsonSerializerContexts>(CurrentRoleUri, _proxy, CreateMetadataTokenHeaders(token)).ConfigureAwait(continueOnCapturedContext: false);
		}

		private static void CheckIsIMDSEnabled()
		{
			if (!EC2InstanceMetadata.IsIMDSEnabled)
			{
				throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Unable to retrieve credentials."));
			}
		}

		private static string GetFirstRole()
		{
			return GetFirstRole(null);
		}

		private static async Task<string> GetFirstRoleAsync()
		{
			return await GetFirstRoleAsync(null).ConfigureAwait(continueOnCapturedContext: false);
		}

		private static string GetFirstRole(IWebProxy proxy)
		{
			using (IEnumerator<string> enumerator = GetAvailableRoles(proxy).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			throw new InvalidOperationException("No roles found");
		}

		private static async Task<string> GetFirstRoleAsync(IWebProxy proxy)
		{
			using (IEnumerator<string> enumerator = (await GetAvailableRolesAsync(proxy).ConfigureAwait(continueOnCapturedContext: false)).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			throw new InvalidOperationException("No roles found");
		}

		private static bool IsNullOrWhiteSpace(string s)
		{
			if (s == null)
			{
				return true;
			}
			if (s.Trim().Length == 0)
			{
				return true;
			}
			return false;
		}

		private static Dictionary<string, string> CreateMetadataTokenHeaders(string token)
		{
			Dictionary<string, string> dictionary = null;
			if (!string.IsNullOrEmpty(token))
			{
				dictionary = new Dictionary<string, string>();
				dictionary.Add("x-aws-ec2-metadata-token", token);
			}
			return dictionary;
		}
	}
}
