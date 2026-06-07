namespace Epic.OnlineServices.Auth
{
	public class IOSCredentials : ISettable
	{
		public string Id { get; set; }

		public string Token { get; set; }

		public LoginCredentialType Type { get; set; }

		public IOSCredentialsSystemAuthCredentialsOptions SystemAuthCredentialsOptions { get; set; }

		public ExternalCredentialType ExternalType { get; set; }

		internal void Set(IOSCredentialsInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
