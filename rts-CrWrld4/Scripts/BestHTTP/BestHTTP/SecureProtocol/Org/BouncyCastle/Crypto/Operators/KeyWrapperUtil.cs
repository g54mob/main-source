using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	internal class KeyWrapperUtil
	{
		private static readonly IDictionary providerMap;

		static KeyWrapperUtil()
		{
		}

		public static IKeyWrapper WrapperForName(string algorithm, ICipherParameters parameters)
		{
			return null;
		}

		public static IKeyUnwrapper UnwrapperForName(string algorithm, ICipherParameters parameters)
		{
			return null;
		}
	}
}
