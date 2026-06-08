namespace Amazon.Runtime.CredentialManagement
{
	public interface ICredentialProfileSource
	{
		bool TryGetProfile(string profileName, out CredentialProfile profile);
	}
}
