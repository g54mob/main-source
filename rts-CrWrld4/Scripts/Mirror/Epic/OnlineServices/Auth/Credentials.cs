using System;

namespace Epic.OnlineServices.Auth
{
	public class Credentials : ISettable
	{
		public string Id { get; set; }

		public string Token { get; set; }

		public LoginCredentialType Type { get; set; }

		public IntPtr SystemAuthCredentialsOptions { get; set; }

		public ExternalCredentialType ExternalType { get; set; }

		internal void Set(CredentialsInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
