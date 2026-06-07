using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class Gost3410PrivateKeyParameters : Gost3410KeyParameters
	{
		private readonly BigInteger x;

		public BigInteger X => null;

		public Gost3410PrivateKeyParameters(BigInteger x, Gost3410Parameters parameters)
			: base(false, (Gost3410Parameters)null)
		{
		}

		public Gost3410PrivateKeyParameters(BigInteger x, DerObjectIdentifier publicKeyParamSet)
			: base(false, (Gost3410Parameters)null)
		{
		}
	}
}
