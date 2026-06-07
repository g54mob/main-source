using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ElGamalPrivateKeyParameters : ElGamalKeyParameters
	{
		private readonly BigInteger x;

		public BigInteger X => null;

		public ElGamalPrivateKeyParameters(BigInteger x, ElGamalParameters parameters)
			: base(isPrivate: false, null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(ElGamalPrivateKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
