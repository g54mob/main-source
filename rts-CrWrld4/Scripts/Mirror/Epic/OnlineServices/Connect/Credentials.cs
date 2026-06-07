namespace Epic.OnlineServices.Connect
{
	public class Credentials : ISettable
	{
		public string Token { get; set; }

		public ExternalCredentialType Type { get; set; }

		internal void Set(CredentialsInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
