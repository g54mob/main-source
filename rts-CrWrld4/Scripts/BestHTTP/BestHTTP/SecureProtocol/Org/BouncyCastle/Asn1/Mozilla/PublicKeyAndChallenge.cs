using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Mozilla
{
	public class PublicKeyAndChallenge : Asn1Encodable
	{
		private Asn1Sequence pkacSeq;

		private SubjectPublicKeyInfo spki;

		private DerIA5String challenge;

		public SubjectPublicKeyInfo SubjectPublicKeyInfo => null;

		public DerIA5String Challenge => null;

		public static PublicKeyAndChallenge GetInstance(object obj)
		{
			return null;
		}

		public PublicKeyAndChallenge(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
