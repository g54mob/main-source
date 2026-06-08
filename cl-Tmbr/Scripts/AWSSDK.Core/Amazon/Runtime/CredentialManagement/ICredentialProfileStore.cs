using System.Collections.Generic;

namespace Amazon.Runtime.CredentialManagement
{
	public interface ICredentialProfileStore : ICredentialProfileSource
	{
		void RenameProfile(string oldProfileName, string newProfileName);

		void RenameProfile(string oldProfileName, string newProfileName, bool force);

		void CopyProfile(string fromProfileName, string toProfileName);

		void CopyProfile(string fromProfileName, string toProfileName, bool force);

		void RegisterProfile(CredentialProfile profile);

		void UnregisterProfile(string profileName);

		List<string> ListProfileNames();

		List<CredentialProfile> ListProfiles();
	}
}
