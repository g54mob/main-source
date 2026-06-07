using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ECKeyGenerationParameters : KeyGenerationParameters
	{
		private readonly ECDomainParameters domainParams;

		private readonly DerObjectIdentifier publicKeyParamSet;

		public ECDomainParameters DomainParameters => null;

		public DerObjectIdentifier PublicKeyParamSet => null;

		public ECKeyGenerationParameters(ECDomainParameters domainParameters, SecureRandom random)
			: base(null, 0)
		{
		}

		public ECKeyGenerationParameters(DerObjectIdentifier publicKeyParamSet, SecureRandom random)
			: base(null, 0)
		{
		}
	}
}
