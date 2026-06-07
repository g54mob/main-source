using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DsaPublicKeyParameters : DsaKeyParameters
	{
		private readonly BigInteger y;

		public BigInteger Y => null;

		private static BigInteger Validate(BigInteger y, DsaParameters parameters)
		{
			return null;
		}

		public DsaPublicKeyParameters(BigInteger y, DsaParameters parameters)
			: base(isPrivate: false, null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(DsaPublicKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
