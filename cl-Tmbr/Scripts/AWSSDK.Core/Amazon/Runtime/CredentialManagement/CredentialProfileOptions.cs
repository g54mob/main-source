using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.CredentialManagement
{
	public class CredentialProfileOptions
	{
		public string AccessKey { get; set; }

		public string CredentialSource { get; set; }

		public string EndpointName { get; set; }

		public string ExternalID { get; set; }

		public string MfaSerial { get; set; }

		public string RoleArn { get; set; }

		public string RoleSessionName { get; set; }

		public string SecretKey { get; set; }

		public string SourceProfile { get; set; }

		public string Token { get; set; }

		public string UserIdentity { get; set; }

		public string CredentialProcess { get; set; }

		public string WebIdentityTokenFile { get; set; }

		public string SsoAccountId { get; set; }

		public string SsoRegion { get; set; }

		public string SsoRegistrationScopes { get; set; }

		public string SsoRoleName { get; set; }

		public string SsoSession { get; set; }

		public string SsoStartUrl { get; set; }

		public string AwsAccountId { get; set; }

		internal bool IsEmpty
		{
			get
			{
				if (string.IsNullOrEmpty(EndpointName) && string.IsNullOrEmpty(UserIdentity) && string.IsNullOrEmpty(AccessKey) && string.IsNullOrEmpty(ExternalID) && string.IsNullOrEmpty(MfaSerial) && string.IsNullOrEmpty(RoleArn) && string.IsNullOrEmpty(RoleSessionName) && string.IsNullOrEmpty(SecretKey) && string.IsNullOrEmpty(SourceProfile) && string.IsNullOrEmpty(Token) && string.IsNullOrEmpty(CredentialProcess) && string.IsNullOrEmpty(SsoAccountId) && string.IsNullOrEmpty(SsoRegion) && string.IsNullOrEmpty(SsoRegistrationScopes) && string.IsNullOrEmpty(SsoRoleName) && string.IsNullOrEmpty(SsoStartUrl) && string.IsNullOrEmpty(SsoSession) && string.IsNullOrEmpty(WebIdentityTokenFile))
				{
					return string.IsNullOrEmpty(AwsAccountId);
				}
				return false;
			}
		}

		public override string ToString()
		{
			return "[AccessKey=" + AccessKey + ", EndpointName=" + EndpointName + ", ExternalID=" + ExternalID + ", MfaSerial=" + MfaSerial + ", RoleArn=" + RoleArn + ", RoleSessionName=" + RoleSessionName + ", SecretKey=XXXXX, SourceProfile=" + SourceProfile + ", Token=" + Token + ", UserIdentity=" + UserIdentity + ", CredentialProcess=" + CredentialProcess + ", WebIdentityTokenFile=" + WebIdentityTokenFile + ", SsoAccountId=" + SsoAccountId + ", SsoRegion=" + SsoRegion + ", SsoRegistrationScopes=" + SsoRegistrationScopes + ", SsoRoleName=" + SsoRoleName + ", SsoStartUrl=" + SsoStartUrl + ", SsoSession=" + SsoSession + ", AwsAccountId=" + AwsAccountId + "]";
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is CredentialProfileOptions credentialProfileOptions))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[19]
			{
				AccessKey, EndpointName, ExternalID, MfaSerial, RoleArn, RoleSessionName, SecretKey, SourceProfile, Token, UserIdentity,
				CredentialProcess, WebIdentityTokenFile, SsoAccountId, SsoRegion, SsoRegistrationScopes, SsoRoleName, SsoStartUrl, SsoSession, AwsAccountId
			}, new object[19]
			{
				credentialProfileOptions.AccessKey, credentialProfileOptions.EndpointName, credentialProfileOptions.ExternalID, credentialProfileOptions.MfaSerial, credentialProfileOptions.RoleArn, credentialProfileOptions.RoleSessionName, credentialProfileOptions.SecretKey, credentialProfileOptions.SourceProfile, credentialProfileOptions.Token, credentialProfileOptions.UserIdentity,
				credentialProfileOptions.CredentialProcess, credentialProfileOptions.WebIdentityTokenFile, credentialProfileOptions.SsoAccountId, credentialProfileOptions.SsoRegion, credentialProfileOptions.SsoRegistrationScopes, credentialProfileOptions.SsoRoleName, credentialProfileOptions.SsoStartUrl, credentialProfileOptions.SsoSession, credentialProfileOptions.AwsAccountId
			});
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(AccessKey, EndpointName, ExternalID, MfaSerial, RoleArn, RoleSessionName, SecretKey, SourceProfile, Token, UserIdentity, CredentialProcess, WebIdentityTokenFile, SsoAccountId, SsoRegion, SsoRegistrationScopes, SsoRoleName, SsoStartUrl, SsoSession, AwsAccountId);
		}
	}
}
