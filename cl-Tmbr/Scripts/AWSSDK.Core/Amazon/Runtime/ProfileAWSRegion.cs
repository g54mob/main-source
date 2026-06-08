using System;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public class ProfileAWSRegion : AWSRegion
	{
		public ProfileAWSRegion(ICredentialProfileSource source)
		{
			string profileName = DefaultAWSCredentialsIdentityResolver.GetProfileName();
			Setup(source, profileName);
		}

		public ProfileAWSRegion(ICredentialProfileSource source, string profileName)
		{
			Setup(source, profileName);
		}

		private void Setup(ICredentialProfileSource source, string profileName)
		{
			RegionEndpoint regionEndpoint = null;
			if (source.TryGetProfile(profileName, out var profile))
			{
				regionEndpoint = profile.Region;
				if (regionEndpoint == null)
				{
					throw new InvalidOperationException("There is no Region set in the profile named '" + profileName + "' in store " + source.GetType());
				}
				base.Region = regionEndpoint;
				Logger.GetLogger(typeof(ProfileAWSRegion)).InfoFormat("Region found in profile '" + profileName + "' in store " + source.GetType());
				return;
			}
			throw new InvalidOperationException("Unable to find a profile named '" + profileName + "' in store " + source.GetType());
		}
	}
}
