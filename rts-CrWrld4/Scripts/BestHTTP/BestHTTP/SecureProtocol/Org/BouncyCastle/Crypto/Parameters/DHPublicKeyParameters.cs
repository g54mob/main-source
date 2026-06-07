using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DHPublicKeyParameters : DHKeyParameters
	{
		private readonly BigInteger y;

		public virtual BigInteger Y => null;

		private static BigInteger Validate(BigInteger y, DHParameters dhParams)
		{
			return null;
		}

		public DHPublicKeyParameters(BigInteger y, DHParameters parameters)
			: base(isPrivate: false, null)
		{
		}

		public DHPublicKeyParameters(BigInteger y, DHParameters parameters, DerObjectIdentifier algorithmOid)
			: base(isPrivate: false, null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(DHPublicKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
