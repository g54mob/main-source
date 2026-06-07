using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ECPublicKeyParameters : ECKeyParameters
	{
		private readonly ECPoint q;

		public ECPoint Q => null;

		public ECPublicKeyParameters(ECPoint q, ECDomainParameters parameters)
			: base((string)null, false, (ECDomainParameters)null)
		{
		}

		public ECPublicKeyParameters(ECPoint q, DerObjectIdentifier publicKeyParamSet)
			: base((string)null, false, (ECDomainParameters)null)
		{
		}

		public ECPublicKeyParameters(string algorithm, ECPoint q, ECDomainParameters parameters)
			: base((string)null, false, (ECDomainParameters)null)
		{
		}

		public ECPublicKeyParameters(string algorithm, ECPoint q, DerObjectIdentifier publicKeyParamSet)
			: base((string)null, false, (ECDomainParameters)null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(ECPublicKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
