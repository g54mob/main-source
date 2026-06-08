using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security;
using System.Threading;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	[Obsolete("This class is deprecated. Please use DefaultAWSCredentialsIdentityResolver instead to obtain AWSCredentials.")]
	public static class FallbackCredentialsFactory
	{
		public delegate AWSCredentials CredentialsGenerator();

		private static ReaderWriterLockSlim cachedCredentialsLock;

		internal const string AWS_PROFILE_ENVIRONMENT_VARIABLE = "AWS_PROFILE";

		internal const string DefaultProfileName = "default";

		private static readonly CredentialProfileStoreChain credentialProfileChain;

		private static AWSCredentials cachedCredentials;

		public static List<CredentialsGenerator> CredentialsGenerators { get; set; }

		static FallbackCredentialsFactory()
		{
			cachedCredentialsLock = new ReaderWriterLockSlim();
			credentialProfileChain = new CredentialProfileStoreChain();
			Reset();
		}

		public static void Reset()
		{
			Reset(null);
		}

		public static void Reset(IWebProxy proxy)
		{
			try
			{
				cachedCredentialsLock.EnterWriteLock();
				cachedCredentials = null;
				CredentialsGenerators = new List<CredentialsGenerator>
				{
					() => AssumeRoleWithWebIdentityCredentials.FromEnvironmentVariables(),
					() => GetAWSCredentials(credentialProfileChain),
					() => new EnvironmentVariablesAWSCredentials(),
					() => ContainerEC2CredentialsWrapper()
				};
			}
			finally
			{
				cachedCredentialsLock.ExitWriteLock();
			}
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

		private static AWSCredentials GetAWSCredentials(ICredentialProfileSource source)
		{
			string profileName = GetProfileName();
			if (source.TryGetProfile(profileName, out var profile))
			{
				return profile.GetAWSCredentials(source, nonCallbackOnly: true);
			}
			throw new AmazonClientException("Unable to find the \"" + profileName + "\" profile in CredentialProfileStoreChain.");
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
			return DefaultInstanceProfileAWSCredentials.Instance;
		}

		public static AWSCredentials GetCredentials()
		{
			return GetCredentials(fallbackToAnonymous: false);
		}

		public static AWSCredentials GetCredentials(IClientConfig config, bool fallbackToAnonymous = false)
		{
			Profile profile = config.Profile;
			if (profile != null)
			{
				CredentialProfileStoreChain credentialProfileStoreChain = new CredentialProfileStoreChain(profile.Location);
				if (credentialProfileStoreChain.TryGetProfile(profile.Name, out var profile2))
				{
					return profile2.GetAWSCredentials(credentialProfileStoreChain, nonCallbackOnly: true);
				}
				throw new AmazonClientException("Unable to find the \"" + profile.Name + "\" profile in CredentialProfileStoreChain.");
			}
			return GetCredentials(fallbackToAnonymous);
		}

		public static AWSCredentials GetCredentials(bool fallbackToAnonymous)
		{
			try
			{
				cachedCredentialsLock.EnterReadLock();
				if (cachedCredentials != null)
				{
					return cachedCredentials;
				}
			}
			finally
			{
				cachedCredentialsLock.ExitReadLock();
			}
			try
			{
				cachedCredentialsLock.EnterWriteLock();
				if (cachedCredentials != null)
				{
					return cachedCredentials;
				}
				List<Exception> list = new List<Exception>();
				foreach (CredentialsGenerator credentialsGenerator in CredentialsGenerators)
				{
					try
					{
						cachedCredentials = credentialsGenerator();
					}
					catch (ProcessAWSCredentialException)
					{
						throw;
					}
					catch (Exception item)
					{
						cachedCredentials = null;
						list.Add(item);
					}
					if (cachedCredentials != null)
					{
						break;
					}
				}
				if (cachedCredentials == null)
				{
					if (fallbackToAnonymous)
					{
						return new AnonymousAWSCredentials();
					}
					using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
					stringWriter.WriteLine("Unable to find credentials");
					stringWriter.WriteLine();
					for (int i = 0; i < list.Count; i++)
					{
						Exception ex2 = list[i];
						stringWriter.WriteLine("Exception {0} of {1}:", i + 1, list.Count);
						stringWriter.WriteLine(ex2.ToString());
						stringWriter.WriteLine();
					}
					throw new AmazonServiceException(stringWriter.ToString());
				}
				return cachedCredentials;
			}
			finally
			{
				cachedCredentialsLock.ExitWriteLock();
			}
		}
	}
}
