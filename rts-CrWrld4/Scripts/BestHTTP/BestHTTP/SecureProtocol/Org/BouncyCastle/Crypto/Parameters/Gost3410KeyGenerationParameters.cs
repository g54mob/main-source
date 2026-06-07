using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class Gost3410KeyGenerationParameters : KeyGenerationParameters
	{
		private readonly Gost3410Parameters parameters;

		private readonly DerObjectIdentifier publicKeyParamSet;

		public Gost3410Parameters Parameters => null;

		public DerObjectIdentifier PublicKeyParamSet => null;

		public Gost3410KeyGenerationParameters(SecureRandom random, Gost3410Parameters parameters)
			: base(null, 0)
		{
		}

		public Gost3410KeyGenerationParameters(SecureRandom random, DerObjectIdentifier publicKeyParamSet)
			: base(null, 0)
		{
		}

		private static Gost3410Parameters LookupParameters(DerObjectIdentifier publicKeyParamSet)
		{
			return null;
		}
	}
}
