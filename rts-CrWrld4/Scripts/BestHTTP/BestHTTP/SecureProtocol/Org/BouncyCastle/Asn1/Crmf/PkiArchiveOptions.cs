namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class PkiArchiveOptions : Asn1Encodable, IAsn1Choice
	{
		public const int encryptedPrivKey = 0;

		public const int keyGenParameters = 1;

		public const int archiveRemGenPrivKey = 2;

		private readonly Asn1Encodable value;

		public virtual int Type => 0;

		public virtual Asn1Encodable Value => null;

		public static PkiArchiveOptions GetInstance(object obj)
		{
			return null;
		}

		private PkiArchiveOptions(Asn1TaggedObject tagged)
		{
		}

		public PkiArchiveOptions(EncryptedKey encKey)
		{
		}

		public PkiArchiveOptions(Asn1OctetString keyGenParameters)
		{
		}

		public PkiArchiveOptions(bool archiveRemGenPrivKey)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
