using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public sealed class Srp6GroupParameters
	{
		private readonly BigInteger n;

		private readonly BigInteger g;

		public BigInteger G => null;

		public BigInteger N => null;

		public Srp6GroupParameters(BigInteger N, BigInteger g)
		{
		}
	}
}
