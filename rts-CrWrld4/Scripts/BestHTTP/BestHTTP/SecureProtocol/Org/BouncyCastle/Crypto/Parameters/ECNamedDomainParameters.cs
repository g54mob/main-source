using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ECNamedDomainParameters : ECDomainParameters
	{
		private readonly DerObjectIdentifier name;

		public DerObjectIdentifier Name => null;

		public ECNamedDomainParameters(DerObjectIdentifier name, ECDomainParameters dp)
			: base(null, null, null)
		{
		}

		public ECNamedDomainParameters(DerObjectIdentifier name, ECCurve curve, ECPoint g, BigInteger n)
			: base(null, null, null)
		{
		}

		public ECNamedDomainParameters(DerObjectIdentifier name, ECCurve curve, ECPoint g, BigInteger n, BigInteger h)
			: base(null, null, null)
		{
		}

		public ECNamedDomainParameters(DerObjectIdentifier name, ECCurve curve, ECPoint g, BigInteger n, BigInteger h, byte[] seed)
			: base(null, null, null)
		{
		}
	}
}
