using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class RsaBlindingParameters : ICipherParameters
	{
		private readonly RsaKeyParameters publicKey;

		private readonly BigInteger blindingFactor;

		public RsaKeyParameters PublicKey => null;

		public BigInteger BlindingFactor => null;

		public RsaBlindingParameters(RsaKeyParameters publicKey, BigInteger blindingFactor)
		{
		}
	}
}
