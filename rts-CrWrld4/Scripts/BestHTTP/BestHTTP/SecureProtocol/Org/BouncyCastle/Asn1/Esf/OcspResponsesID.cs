namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class OcspResponsesID : Asn1Encodable
	{
		private readonly OcspIdentifier ocspIdentifier;

		private readonly OtherHash ocspRepHash;

		public OcspIdentifier OcspIdentifier => null;

		public OtherHash OcspRepHash => null;

		public static OcspResponsesID GetInstance(object obj)
		{
			return null;
		}

		private OcspResponsesID(Asn1Sequence seq)
		{
		}

		public OcspResponsesID(OcspIdentifier ocspIdentifier)
		{
		}

		public OcspResponsesID(OcspIdentifier ocspIdentifier, OtherHash ocspRepHash)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
