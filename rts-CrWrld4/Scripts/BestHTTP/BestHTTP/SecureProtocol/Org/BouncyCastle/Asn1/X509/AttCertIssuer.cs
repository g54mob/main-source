namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class AttCertIssuer : Asn1Encodable, IAsn1Choice
	{
		internal readonly Asn1Encodable obj;

		internal readonly Asn1Object choiceObj;

		public Asn1Encodable Issuer => null;

		public static AttCertIssuer GetInstance(object obj)
		{
			return null;
		}

		public static AttCertIssuer GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public AttCertIssuer(GeneralNames names)
		{
		}

		public AttCertIssuer(V2Form v2Form)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
