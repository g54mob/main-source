namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class Holder : Asn1Encodable
	{
		internal readonly IssuerSerial baseCertificateID;

		internal readonly GeneralNames entityName;

		internal readonly ObjectDigestInfo objectDigestInfo;

		private readonly int version;

		public int Version => 0;

		public IssuerSerial BaseCertificateID => null;

		public GeneralNames EntityName => null;

		public ObjectDigestInfo ObjectDigestInfo => null;

		public static Holder GetInstance(object obj)
		{
			return null;
		}

		public Holder(Asn1TaggedObject tagObj)
		{
		}

		private Holder(Asn1Sequence seq)
		{
		}

		public Holder(IssuerSerial baseCertificateID)
		{
		}

		public Holder(IssuerSerial baseCertificateID, int version)
		{
		}

		public Holder(GeneralNames entityName)
		{
		}

		public Holder(GeneralNames entityName, int version)
		{
		}

		public Holder(ObjectDigestInfo objectDigestInfo)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
