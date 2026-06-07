using System;

namespace FractureField.Shared.DTOs.Auth
{
	public class AuthResponse
	{
		public int PlayerId { get; set; }

		public string ApiKey { get; set; }

		public string Token { get; set; }

		public DateTime ExpiresDate { get; set; }

		public PlayerDto Player { get; set; }
	}
}
