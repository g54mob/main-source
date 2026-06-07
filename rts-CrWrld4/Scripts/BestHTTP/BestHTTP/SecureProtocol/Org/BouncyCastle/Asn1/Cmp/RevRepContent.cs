using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class RevRepContent : Asn1Encodable
	{
		private readonly Asn1Sequence status;

		private readonly Asn1Sequence revCerts;

		private readonly Asn1Sequence crls;

		private RevRepContent(Asn1Sequence seq)
		{
		}

		public static RevRepContent GetInstance(object obj)
		{
			return null;
		}

		public virtual PkiStatusInfo[] GetStatus()
		{
			return null;
		}

		public virtual CertId[] GetRevCerts()
		{
			return null;
		}

		public virtual CertificateList[] GetCrls()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
