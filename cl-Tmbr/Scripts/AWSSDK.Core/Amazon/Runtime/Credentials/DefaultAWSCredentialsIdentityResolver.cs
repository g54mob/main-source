using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Credentials
{
	public class DefaultAWSCredentialsIdentityResolver : IIdentityResolver<AWSCredentials>, IIdentityResolver
	{
		private delegate AWSCredentials CredentialsGenerator();

		private class EnvironmentState
		{
			public string AccessKey { get; private set; }

			public string SecretKey { get; private set; }

			public string SessionToken { get; private set; }

			public string ProfileName { get; private set; }

			public bool HasEnvironmentChanged()
			{
				string text = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY") ?? Environment.GetEnvironmentVariable("AWS_SECRET_KEY");
				if (!(AccessKey != Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID")) && !(SecretKey != text) && !(SessionToken != Environment.GetEnvironmentVariable("AWS_SESSION_TOKEN")))
				{
					return ProfileName != Environment.GetEnvironmentVariable("AWS_PROFILE");
				}
				return true;
			}

			public void UpdateEnvironment()
			{
				AccessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
				SecretKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY") ?? Environment.GetEnvironmentVariable("AWS_SECRET_KEY");
				SessionToken = Environment.GetEnvironmentVariable("AWS_SESSION_TOKEN");
				ProfileName = Environment.GetEnvironmentVariable("AWS_PROFILE");
			}
		}

		private const string AWS_PROFILE_ENVIRONMENT_VARIABLE = "AWS_PROFILE";

		private const string DEFAULT_PROFILE_NAME = "default";

		private static readonly ReaderWriterLockSlim _cachedCredentialsLock = new ReaderWriterLockSlim();

		private AWSCredentials _cachedCredentials;

		private readonly List<CredentialsGenerator> _credentialsGenerators;

		private readonly CredentialProfileStoreChain _credentialProfileChain = new CredentialProfileStoreChain();

		private readonly EnvironmentState _lastKnownEnvironmentState = new EnvironmentState();

		private static readonly Lazy<DefaultAWSCredentialsIdentityResolver> _defaultInstance = new Lazy<DefaultAWSCredentialsIdentityResolver>();

		public DefaultAWSCredentialsIdentityResolver()
		{
			_cachedCredentials = null;
			_credentialsGenerators = new List<CredentialsGenerator>
			{
				() => new EnvironmentVariablesAWSCredentials(),
				() => AssumeRoleWithWebIdentityCredentials.FromEnvironmentVariables(),
				() => GetProfileCredentials(_credentialProfileChain),
				() => ContainerEC2CredentialsWrapper()
			};
		}

		public static AWSCredentials GetCredentials(IClientConfig clientConfig = null)
		{
			return _defaultInstance.Value.ResolveIdentity(clientConfig);
		}

		public static Task<AWSCredentials> GetCredentialsAsync(IClientConfig clientConfig = null)
		{
			return _defaultInstance.Value.ResolveIdentityAsync(clientConfig);
		}

		BaseIdentity IIdentityResolver.ResolveIdentity(IClientConfig clientConfig)
		{
			return ResolveIdentity(clientConfig);
		}

		public AWSCredentials ResolveIdentity(IClientConfig clientConfig)
		{
			Profile profile = clientConfig?.Profile;
			if (profile != null)
			{
				CredentialProfileStoreChain credentialProfileStoreChain = new CredentialProfileStoreChain(profile.Location);
				if (credentialProfileStoreChain.TryGetProfile(profile.Name, out var profile2))
				{
					return profile2.GetAWSCredentials(credentialProfileStoreChain, nonCallbackOnly: true);
				}
				throw new AmazonClientException("Unable to find the \"" + profile.Name + "\" profile specified in the client configuration.");
			}
			return InternalGetCredentials();
		}

		Task<BaseIdentity> IIdentityResolver.ResolveIdentityAsync(IClientConfig clientConfig, CancellationToken cancellationToken)
		{
			return Task.FromResult((BaseIdentity)ResolveIdentity(clientConfig));
		}

		public Task<AWSCredentials> ResolveIdentityAsync(IClientConfig clientConfig, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.FromResult(ResolveIdentity(clientConfig));
		}

		private AWSCredentials InternalGetCredentials()
		{
			bool flag = false;
			try
			{
				_cachedCredentialsLock.EnterReadLock();
				if (_cachedCredentials != null)
				{
					flag = _lastKnownEnvironmentState.HasEnvironmentChanged();
					if (!flag)
					{
						return _cachedCredentials;
					}
				}
			}
			finally
			{
				_cachedCredentialsLock.ExitReadLock();
			}
			try
			{
				_cachedCredentialsLock.EnterWriteLock();
				if (_cachedCredentials != null && !flag)
				{
					return _cachedCredentials;
				}
				List<Exception> list = new List<Exception>();
				foreach (CredentialsGenerator credentialsGenerator in _credentialsGenerators)
				{
					try
					{
						_cachedCredentials = credentialsGenerator();
					}
					catch (ProcessAWSCredentialException)
					{
						throw;
					}
					catch (ProfileNotFoundException)
					{
						throw;
					}
					catch (Exception item)
					{
						_cachedCredentials = null;
						list.Add(item);
					}
					if (_cachedCredentials != null)
					{
						break;
					}
				}
				if (_cachedCredentials != null)
				{
					_lastKnownEnvironmentState.UpdateEnvironment();
					return _cachedCredentials;
				}
				using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
				stringWriter.WriteLine("Failed to resolve AWS credentials. The credential providers used to search for credentials returned the following errors:");
				stringWriter.WriteLine();
				for (int i = 0; i < list.Count; i++)
				{
					Exception ex3 = list[i];
					stringWriter.WriteLine("Exception {0} of {1}: {2}", i + 1, list.Count, ex3.Message);
				}
				throw new AmazonClientException(stringWriter.ToString());
			}
			finally
			{
				_cachedCredentialsLock.ExitWriteLock();
			}
		}

		private static AWSCredentials GetProfileCredentials(ICredentialProfileSource source)
		{
			string profileName = GetProfileName();
			if (source.TryGetProfile(profileName, out var profile))
			{
				return profile.GetAWSCredentials(source, nonCallbackOnly: true);
			}
			if (!profileName.Equals("default", StringComparison.OrdinalIgnoreCase))
			{
				throw new ProfileNotFoundException("Unable to find the \"" + profileName + "\" profile.");
			}
			throw new AmazonClientException("Unable to find the \"default\" profile.");
		}

		internal static string GetProfileName()
		{
			string text = AWSConfigs.AWSProfileName;
			if (string.IsNullOrEmpty(text?.Trim()))
			{
				text = Environment.GetEnvironmentVariable("AWS_PROFILE");
			}
			if (string.IsNullOrEmpty(text?.Trim()))
			{
				text = "default";
			}
			return text;
		}

		private static AWSCredentials ContainerEC2CredentialsWrapper()
		{
			try
			{
				if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_CONTAINER_CREDENTIALS_RELATIVE_URI")))
				{
					return new GenericContainerCredentials();
				}
				if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_CONTAINER_CREDENTIALS_FULL_URI")))
				{
					return new GenericContainerCredentials();
				}
			}
			catch (SecurityException exception)
			{
				Logger.GetLogger(typeof(GenericContainerCredentials)).Error(exception, "Failed to access environment variables AWS_CONTAINER_CREDENTIALS_RELATIVE_URI and AWS_CONTAINER_CREDENTIALS_FULL_URI. Either AWS_CONTAINER_CREDENTIALS_RELATIVE_URI or AWS_CONTAINER_CREDENTIALS_FULL_URI environment variables must be set.");
			}
			try
			{
				DefaultInstanceProfileAWSCredentials instance = DefaultInstanceProfileAWSCredentials.Instance;
				instance.GetCredentials();
				return instance;
			}
			catch (AmazonServiceException ex)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Failed to connect to EC2 instance metadata to retrieve credentials: {0}.", ex.Message), ex);
			}
		}
	}
}
