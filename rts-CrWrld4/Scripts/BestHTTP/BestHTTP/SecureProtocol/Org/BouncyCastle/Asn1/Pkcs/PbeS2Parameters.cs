namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class PbeS2Parameters : Asn1Encodable
	{
		private readonly KeyDerivationFunc func;

		private readonly EncryptionScheme scheme;

		public KeyDerivationFunc KeyDerivationFunc => null;

		public EncryptionScheme EncryptionScheme => null;

		public static PbeS2Parameters GetInstance(object obj)
		{
			return null;
		}

		public PbeS2Parameters(KeyDerivationFunc keyDevFunc, EncryptionScheme encScheme)
		{
		}

		public PbeS2Parameters(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
