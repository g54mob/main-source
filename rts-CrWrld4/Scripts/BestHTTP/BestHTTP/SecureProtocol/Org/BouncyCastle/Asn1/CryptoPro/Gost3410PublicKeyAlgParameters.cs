namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.CryptoPro
{
	public class Gost3410PublicKeyAlgParameters : Asn1Encodable
	{
		private DerObjectIdentifier publicKeyParamSet;

		private DerObjectIdentifier digestParamSet;

		private DerObjectIdentifier encryptionParamSet;

		public DerObjectIdentifier PublicKeyParamSet => null;

		public DerObjectIdentifier DigestParamSet => null;

		public DerObjectIdentifier EncryptionParamSet => null;

		public static Gost3410PublicKeyAlgParameters GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static Gost3410PublicKeyAlgParameters GetInstance(object obj)
		{
			return null;
		}

		public Gost3410PublicKeyAlgParameters(DerObjectIdentifier publicKeyParamSet, DerObjectIdentifier digestParamSet)
		{
		}

		public Gost3410PublicKeyAlgParameters(DerObjectIdentifier publicKeyParamSet, DerObjectIdentifier digestParamSet, DerObjectIdentifier encryptionParamSet)
		{
		}

		public Gost3410PublicKeyAlgParameters(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
