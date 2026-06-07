using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.OpenSsl
{
	internal sealed class PemUtilities
	{
		private enum PemBaseAlg
		{
			AES_128 = 0,
			AES_192 = 1,
			AES_256 = 2,
			BF = 3,
			DES = 4,
			DES_EDE = 5,
			DES_EDE3 = 6,
			RC2 = 7,
			RC2_40 = 8,
			RC2_64 = 9
		}

		private enum PemMode
		{
			CBC = 0,
			CFB = 1,
			ECB = 2,
			OFB = 3
		}

		static PemUtilities()
		{
		}

		private static void ParseDekAlgName(string dekAlgName, out PemBaseAlg baseAlg, out PemMode mode)
		{
			baseAlg = default(PemBaseAlg);
			mode = default(PemMode);
		}

		internal static byte[] Crypt(bool encrypt, byte[] bytes, char[] password, string dekAlgName, byte[] iv)
		{
			return null;
		}

		private static ICipherParameters GetCipherParameters(char[] password, PemBaseAlg baseAlg, byte[] salt)
		{
			return null;
		}
	}
}
