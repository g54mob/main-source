namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class SubjectKeyIdentifier : Asn1Encodable
	{
		private readonly byte[] keyIdentifier;

		public static SubjectKeyIdentifier GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static SubjectKeyIdentifier GetInstance(object obj)
		{
			return null;
		}

		public static SubjectKeyIdentifier FromExtensions(X509Extensions extensions)
		{
			return null;
		}

		public SubjectKeyIdentifier(byte[] keyID)
		{
		}

		public SubjectKeyIdentifier(Asn1OctetString keyID)
		{
		}

		public SubjectKeyIdentifier(SubjectPublicKeyInfo spki)
		{
		}

		public byte[] GetKeyIdentifier()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public static SubjectKeyIdentifier CreateSha1KeyIdentifier(SubjectPublicKeyInfo keyInfo)
		{
			return null;
		}

		public static SubjectKeyIdentifier CreateTruncatedSha1KeyIdentifier(SubjectPublicKeyInfo keyInfo)
		{
			return null;
		}

		private static byte[] GetDigest(SubjectPublicKeyInfo spki)
		{
			return null;
		}
	}
}
