namespace ModIO.Implementation.API.Requests
{
	internal static class AuthenticateUser
	{
		public static WebRequestConfig InternalRequest(string securityCode)
		{
			return null;
		}

		public static WebRequestConfig ExternalRequest(AuthenticationServiceProvider serviceProvider, string data, TermsHash? hash, string emailAddress, string nonce, OculusDevice? device, string userId, PlayStationEnvironment environment)
		{
			return null;
		}
	}
}
