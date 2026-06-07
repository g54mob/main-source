using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public abstract class Gost3410KeyParameters : AsymmetricKeyParameter
	{
		private readonly Gost3410Parameters parameters;

		private readonly DerObjectIdentifier publicKeyParamSet;

		public Gost3410Parameters Parameters => null;

		public DerObjectIdentifier PublicKeyParamSet => null;

		protected Gost3410KeyParameters(bool isPrivate, Gost3410Parameters parameters)
			: base(privateKey: false)
		{
		}

		protected Gost3410KeyParameters(bool isPrivate, DerObjectIdentifier publicKeyParamSet)
			: base(privateKey: false)
		{
		}

		private static Gost3410Parameters LookupParameters(DerObjectIdentifier publicKeyParamSet)
		{
			return null;
		}
	}
}
