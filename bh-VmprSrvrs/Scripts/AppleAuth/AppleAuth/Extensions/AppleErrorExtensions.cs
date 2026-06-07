using AppleAuth.Enums;
using AppleAuth.Interfaces;

namespace AppleAuth.Extensions
{
	public static class AppleErrorExtensions
	{
		public static AuthorizationErrorCode GetAuthorizationErrorCode(this IAppleError error)
		{
			return default(AuthorizationErrorCode);
		}
	}
}
