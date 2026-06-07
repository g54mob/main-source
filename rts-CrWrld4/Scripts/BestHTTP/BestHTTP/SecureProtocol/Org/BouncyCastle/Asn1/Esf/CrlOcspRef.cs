namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class CrlOcspRef : Asn1Encodable
	{
		private readonly CrlListID crlids;

		private readonly OcspListID ocspids;

		private readonly OtherRevRefs otherRev;

		public CrlListID CrlIDs => null;

		public OcspListID OcspIDs => null;

		public OtherRevRefs OtherRev => null;

		public static CrlOcspRef GetInstance(object obj)
		{
			return null;
		}

		private CrlOcspRef(Asn1Sequence seq)
		{
		}

		public CrlOcspRef(CrlListID crlids, OcspListID ocspids, OtherRevRefs otherRev)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
