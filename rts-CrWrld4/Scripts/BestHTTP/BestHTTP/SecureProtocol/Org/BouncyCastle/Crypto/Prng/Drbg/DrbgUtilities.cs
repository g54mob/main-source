using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng.Drbg
{
	internal class DrbgUtilities
	{
		private static readonly IDictionary maxSecurityStrengths;

		static DrbgUtilities()
		{
		}

		internal static int GetMaxSecurityStrength(IDigest d)
		{
			return 0;
		}

		internal static int GetMaxSecurityStrength(IMac m)
		{
			return 0;
		}

		internal static byte[] HashDF(IDigest digest, byte[] seedMaterial, int seedLength)
		{
			return null;
		}

		internal static bool IsTooLarge(byte[] bytes, int maxBytes)
		{
			return false;
		}
	}
}
