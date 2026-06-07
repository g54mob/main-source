using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DsaPrivateKeyParameters : DsaKeyParameters
	{
		private readonly BigInteger x;

		public BigInteger X => null;

		public DsaPrivateKeyParameters(BigInteger x, DsaParameters parameters)
			: base(isPrivate: false, null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(DsaPrivateKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
