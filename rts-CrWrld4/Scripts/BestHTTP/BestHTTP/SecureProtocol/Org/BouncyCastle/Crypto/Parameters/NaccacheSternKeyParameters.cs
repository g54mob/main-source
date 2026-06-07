using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class NaccacheSternKeyParameters : AsymmetricKeyParameter
	{
		private readonly BigInteger g;

		private readonly BigInteger n;

		private readonly int lowerSigmaBound;

		public BigInteger G => null;

		public int LowerSigmaBound => 0;

		public BigInteger Modulus => null;

		public NaccacheSternKeyParameters(bool privateKey, BigInteger g, BigInteger n, int lowerSigmaBound)
			: base(privateKey: false)
		{
		}
	}
}
