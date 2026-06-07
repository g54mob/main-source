using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class PasswordRecipientInfo : Asn1Encodable
	{
		private readonly DerInteger version;

		private readonly AlgorithmIdentifier keyDerivationAlgorithm;

		private readonly AlgorithmIdentifier keyEncryptionAlgorithm;

		private readonly Asn1OctetString encryptedKey;

		public DerInteger Version => null;

		public AlgorithmIdentifier KeyDerivationAlgorithm => null;

		public AlgorithmIdentifier KeyEncryptionAlgorithm => null;

		public Asn1OctetString EncryptedKey => null;

		public PasswordRecipientInfo(AlgorithmIdentifier keyEncryptionAlgorithm, Asn1OctetString encryptedKey)
		{
		}

		public PasswordRecipientInfo(AlgorithmIdentifier keyDerivationAlgorithm, AlgorithmIdentifier keyEncryptionAlgorithm, Asn1OctetString encryptedKey)
		{
		}

		public PasswordRecipientInfo(Asn1Sequence seq)
		{
		}

		public static PasswordRecipientInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static PasswordRecipientInfo GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
