using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class RevRepContentBuilder
	{
		private readonly Asn1EncodableVector status;

		private readonly Asn1EncodableVector revCerts;

		private readonly Asn1EncodableVector crls;

		public virtual RevRepContentBuilder Add(PkiStatusInfo status)
		{
			return null;
		}

		public virtual RevRepContentBuilder Add(PkiStatusInfo status, CertId certId)
		{
			return null;
		}

		public virtual RevRepContentBuilder AddCrl(CertificateList crl)
		{
			return null;
		}

		public virtual RevRepContent Build()
		{
			return null;
		}
	}
}
