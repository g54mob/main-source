using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ElGamalPublicKeyParameters : ElGamalKeyParameters
	{
		private readonly BigInteger y;

		public BigInteger Y => null;

		public ElGamalPublicKeyParameters(BigInteger y, ElGamalParameters parameters)
			: base(isPrivate: false, null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(ElGamalPublicKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
