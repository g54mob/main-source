using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	internal class DHKeyGeneratorHelper
	{
		internal static readonly DHKeyGeneratorHelper Instance;

		private DHKeyGeneratorHelper()
		{
		}

		internal BigInteger CalculatePrivate(DHParameters dhParams, SecureRandom random)
		{
			return null;
		}

		internal BigInteger CalculatePublic(DHParameters dhParams, BigInteger x)
		{
			return null;
		}
	}
}
