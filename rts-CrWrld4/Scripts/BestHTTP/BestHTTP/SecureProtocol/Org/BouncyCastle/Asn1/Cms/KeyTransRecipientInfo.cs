using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class KeyTransRecipientInfo : Asn1Encodable
	{
		private DerInteger version;

		private RecipientIdentifier rid;

		private AlgorithmIdentifier keyEncryptionAlgorithm;

		private Asn1OctetString encryptedKey;

		public DerInteger Version => null;

		public RecipientIdentifier RecipientIdentifier => null;

		public AlgorithmIdentifier KeyEncryptionAlgorithm => null;

		public Asn1OctetString EncryptedKey => null;

		public KeyTransRecipientInfo(RecipientIdentifier rid, AlgorithmIdentifier keyEncryptionAlgorithm, Asn1OctetString encryptedKey)
		{
		}

		public KeyTransRecipientInfo(Asn1Sequence seq)
		{
		}

		public static KeyTransRecipientInfo GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
