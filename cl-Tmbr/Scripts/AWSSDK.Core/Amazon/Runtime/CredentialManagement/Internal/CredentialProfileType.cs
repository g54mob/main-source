namespace Amazon.Runtime.CredentialManagement.Internal
{
	public enum CredentialProfileType
	{
		AssumeRole = 0,
		AssumeRoleCredentialSource = 1,
		AssumeRoleExternal = 2,
		AssumeRoleExternalMFA = 3,
		AssumeRoleMFA = 4,
		Basic = 5,
		SAMLRole = 6,
		SAMLRoleUserIdentity = 7,
		Session = 8,
		CredentialProcess = 9,
		AssumeRoleWithWebIdentity = 10,
		AssumeRoleWithWebIdentitySessionName = 11,
		AssumeRoleSessionName = 12,
		AssumeRoleCredentialSourceSessionName = 13,
		AssumeRoleExternalSessionName = 14,
		AssumeRoleExternalMFASessionName = 15,
		AssumeRoleMFASessionName = 16,
		SSO = 17
	}
}
