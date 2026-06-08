using Amazon.Runtime.CredentialManagement;

namespace Amazon.Runtime
{
	public interface ISSOTokenProviderFactory
	{
		SSOTokenProvider Build(CredentialProfile profile);
	}
}
