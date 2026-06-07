namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Net
{
	public class IPAddress
	{
		public static bool IsValid(string address)
		{
			return false;
		}

		public static bool IsValidWithNetMask(string address)
		{
			return false;
		}

		public static bool IsValidIPv4(string address)
		{
			return false;
		}

		private static bool unsafeIsValidIPv4(string address)
		{
			return false;
		}

		public static bool IsValidIPv4WithNetmask(string address)
		{
			return false;
		}

		public static bool IsValidIPv6WithNetmask(string address)
		{
			return false;
		}

		private static bool IsMaskValue(string component, int size)
		{
			return false;
		}

		public static bool IsValidIPv6(string address)
		{
			return false;
		}

		private static bool unsafeIsValidIPv6(string address)
		{
			return false;
		}
	}
}
