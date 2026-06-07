namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class EncryptedData : Asn1Encodable
	{
		private readonly DerInteger version;

		private readonly EncryptedContentInfo encryptedContentInfo;

		private readonly Asn1Set unprotectedAttrs;

		public virtual DerInteger Version => null;

		public virtual EncryptedContentInfo EncryptedContentInfo => null;

		public virtual Asn1Set UnprotectedAttrs => null;

		public static EncryptedData GetInstance(object obj)
		{
			return null;
		}

		public EncryptedData(EncryptedContentInfo encInfo)
		{
		}

		public EncryptedData(EncryptedContentInfo encInfo, Asn1Set unprotectedAttrs)
		{
		}

		private EncryptedData(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
