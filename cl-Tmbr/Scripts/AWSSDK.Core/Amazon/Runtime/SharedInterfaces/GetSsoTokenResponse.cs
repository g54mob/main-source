using System;

namespace Amazon.Runtime.SharedInterfaces
{
	public class GetSsoTokenResponse
	{
		public string AccessToken { get; set; }

		public DateTime ExpiresAt { get; set; }

		public string RefreshToken { get; set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public string RegistrationExpiresAt { get; set; }

		public string Region { get; set; }

		public string StartUrl { get; set; }

		public string CodeVerifier { get; set; }
	}
}
