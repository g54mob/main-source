using System;
using System.Net;
using System.Threading.Tasks;

namespace Amazon.Runtime.SharedInterfaces
{
	public interface ICoreAmazonSTS
	{
		AssumeRoleImmutableCredentials CredentialsFromAssumeRoleAuthentication(string roleArn, string roleSessionName, AssumeRoleAWSCredentialsOptions options);

		Task<AssumeRoleImmutableCredentials> CredentialsFromAssumeRoleAuthenticationAsync(string roleArn, string roleSessionName, AssumeRoleAWSCredentialsOptions options);

		SAMLImmutableCredentials CredentialsFromSAMLAuthentication(string endpoint, string authenticationType, string roleARN, TimeSpan credentialDuration, ICredentials userCredential);

		Task<SAMLImmutableCredentials> CredentialsFromSAMLAuthenticationAsync(string endpoint, string authenticationType, string roleARN, TimeSpan credentialDuration, ICredentials userCredential);

		AssumeRoleImmutableCredentials CredentialsFromAssumeRoleWithWebIdentityAuthentication(string webIdentityToken, string roleArn, string roleSessionName, AssumeRoleWithWebIdentityCredentialsOptions options);

		Task<AssumeRoleImmutableCredentials> CredentialsFromAssumeRoleWithWebIdentityAuthenticationAsync(string webIdentityToken, string roleArn, string roleSessionName, AssumeRoleWithWebIdentityCredentialsOptions options);
	}
}
