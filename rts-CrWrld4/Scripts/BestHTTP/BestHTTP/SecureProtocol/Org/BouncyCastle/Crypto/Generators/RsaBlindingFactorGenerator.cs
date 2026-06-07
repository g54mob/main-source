using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class RsaBlindingFactorGenerator
	{
		private RsaKeyParameters key;

		private SecureRandom random;

		public void Init(ICipherParameters param)
		{
		}

		public BigInteger GenerateBlindingFactor()
		{
			return null;
		}
	}
}
