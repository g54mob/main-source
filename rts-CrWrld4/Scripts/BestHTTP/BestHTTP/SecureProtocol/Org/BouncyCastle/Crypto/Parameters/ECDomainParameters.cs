using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ECDomainParameters
	{
		private readonly ECCurve curve;

		private readonly byte[] seed;

		private readonly ECPoint g;

		private readonly BigInteger n;

		private readonly BigInteger h;

		private BigInteger hInv;

		public ECCurve Curve => null;

		public ECPoint G => null;

		public BigInteger N => null;

		public BigInteger H => null;

		public BigInteger HInv => null;

		public ECDomainParameters(ECCurve curve, ECPoint g, BigInteger n)
		{
		}

		public ECDomainParameters(ECCurve curve, ECPoint g, BigInteger n, BigInteger h)
		{
		}

		public ECDomainParameters(ECCurve curve, ECPoint g, BigInteger n, BigInteger h, byte[] seed)
		{
		}

		public byte[] GetSeed()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected virtual bool Equals(ECDomainParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public BigInteger ValidatePrivateScalar(BigInteger d)
		{
			return null;
		}

		public ECPoint ValidatePublicPoint(ECPoint q)
		{
			return null;
		}

		internal static ECPoint ValidatePublicPoint(ECCurve c, ECPoint q)
		{
			return null;
		}
	}
}
