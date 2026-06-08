using System.Collections.Generic;
using Amazon.Runtime.Internal.Settings;

namespace Amazon.Runtime.CredentialManagement
{
	public class CredentialProfileStoreChain : ICredentialProfileSource
	{
		public string ProfilesLocation { get; private set; }

		public CredentialProfileStoreChain()
			: this(null)
		{
		}

		public CredentialProfileStoreChain(string profilesLocation)
		{
			ProfilesLocation = profilesLocation;
		}

		public bool TryGetAWSCredentials(string profileName, out AWSCredentials credentials)
		{
			if (TryGetProfile(profileName, out var profile))
			{
				return AWSCredentialsFactory.TryGetAWSCredentials(profile, profile.CredentialProfileStore, out credentials);
			}
			credentials = null;
			return false;
		}

		public bool TryGetProfile(string profileName, out CredentialProfile profile)
		{
			if (string.IsNullOrEmpty(ProfilesLocation) && UserCrypto.IsUserCryptAvailable && new NetSDKCredentialsFile().TryGetProfile(profileName, out profile))
			{
				return true;
			}
			if (new SharedCredentialsFile(ProfilesLocation).TryGetProfile(profileName, out profile))
			{
				return true;
			}
			profile = null;
			return false;
		}

		public List<CredentialProfile> ListProfiles()
		{
			List<CredentialProfile> list = new List<CredentialProfile>();
			if (string.IsNullOrEmpty(ProfilesLocation) && UserCrypto.IsUserCryptAvailable)
			{
				NetSDKCredentialsFile netSDKCredentialsFile = new NetSDKCredentialsFile();
				list.AddRange(netSDKCredentialsFile.ListProfiles());
			}
			SharedCredentialsFile sharedCredentialsFile = new SharedCredentialsFile(ProfilesLocation);
			list.AddRange(sharedCredentialsFile.ListProfiles());
			return list;
		}

		public void RegisterProfile(CredentialProfile profile)
		{
			if (string.IsNullOrEmpty(ProfilesLocation) && UserCrypto.IsUserCryptAvailable)
			{
				new NetSDKCredentialsFile().RegisterProfile(profile);
			}
			else
			{
				new SharedCredentialsFile(ProfilesLocation).RegisterProfile(profile);
			}
		}

		public void UnregisterProfile(string profileName)
		{
			if (TryGetProfile(profileName, out var profile))
			{
				profile.CredentialProfileStore.UnregisterProfile(profileName);
			}
		}
	}
}
