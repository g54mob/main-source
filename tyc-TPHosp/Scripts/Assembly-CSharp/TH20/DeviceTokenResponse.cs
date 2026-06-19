using System;
using System.Collections.Generic;

namespace TH20
{
	[Serializable]
	public class DeviceTokenResponse
	{
		public readonly string AccessToken;

		public readonly string RefreshToken;

		public readonly string TokenType;

		public readonly int ExpiresIn;

		public DeviceTokenResponse(Dictionary<string, object> responseData)
		{
			AccessToken = (string)responseData["access_token"];
			RefreshToken = (string)responseData["refresh_token"];
			TokenType = (string)responseData["token_type"];
			ExpiresIn = Convert.ToInt32(responseData["expires_in"]);
		}
	}
}
