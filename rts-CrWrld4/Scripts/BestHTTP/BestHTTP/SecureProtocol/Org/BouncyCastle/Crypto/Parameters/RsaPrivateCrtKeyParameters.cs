using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class RsaPrivateCrtKeyParameters : RsaKeyParameters
	{
		private readonly BigInteger e;

		private readonly BigInteger p;

		private readonly BigInteger q;

		private readonly BigInteger dP;

		private readonly BigInteger dQ;

		private readonly BigInteger qInv;

		public BigInteger PublicExponent => null;

		public BigInteger P => null;

		public BigInteger Q => null;

		public BigInteger DP => null;

		public BigInteger DQ => null;

		public BigInteger QInv => null;

		public RsaPrivateCrtKeyParameters(BigInteger modulus, BigInteger publicExponent, BigInteger privateExponent, BigInteger p, BigInteger q, BigInteger dP, BigInteger dQ, BigInteger qInv)
			: base(isPrivate: false, null, null)
		{
		}

		public RsaPrivateCrtKeyParameters(RsaPrivateKeyStructure rsaPrivateKey)
			: base(isPrivate: false, null, null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private static void ValidateValue(BigInteger x, string name, string desc)
		{
		}
	}
}
