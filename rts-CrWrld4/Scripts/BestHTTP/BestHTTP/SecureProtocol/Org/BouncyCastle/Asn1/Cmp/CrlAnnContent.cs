using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CrlAnnContent : Asn1Encodable
	{
		private readonly Asn1Sequence content;

		private CrlAnnContent(Asn1Sequence seq)
		{
		}

		public static CrlAnnContent GetInstance(object obj)
		{
			return null;
		}

		public virtual CertificateList[] ToCertificateListArray()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
