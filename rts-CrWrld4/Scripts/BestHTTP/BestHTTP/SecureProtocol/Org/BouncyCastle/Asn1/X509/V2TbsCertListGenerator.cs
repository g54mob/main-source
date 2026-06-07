using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class V2TbsCertListGenerator
	{
		private DerInteger version;

		private AlgorithmIdentifier signature;

		private X509Name issuer;

		private Time thisUpdate;

		private Time nextUpdate;

		private X509Extensions extensions;

		private IList crlEntries;

		public void SetSignature(AlgorithmIdentifier signature)
		{
		}

		public void SetIssuer(X509Name issuer)
		{
		}

		public void SetThisUpdate(DerUtcTime thisUpdate)
		{
		}

		public void SetNextUpdate(DerUtcTime nextUpdate)
		{
		}

		public void SetThisUpdate(Time thisUpdate)
		{
		}

		public void SetNextUpdate(Time nextUpdate)
		{
		}

		public void AddCrlEntry(Asn1Sequence crlEntry)
		{
		}

		public void AddCrlEntry(DerInteger userCertificate, DerUtcTime revocationDate, int reason)
		{
		}

		public void AddCrlEntry(DerInteger userCertificate, Time revocationDate, int reason)
		{
		}

		public void AddCrlEntry(DerInteger userCertificate, Time revocationDate, int reason, DerGeneralizedTime invalidityDate)
		{
		}

		public void AddCrlEntry(DerInteger userCertificate, Time revocationDate, X509Extensions extensions)
		{
		}

		public void SetExtensions(X509Extensions extensions)
		{
		}

		public TbsCertificateList GenerateTbsCertList()
		{
			return null;
		}
	}
}
