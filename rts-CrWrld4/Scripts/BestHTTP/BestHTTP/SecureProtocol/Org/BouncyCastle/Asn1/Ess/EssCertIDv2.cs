using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ess
{
	public class EssCertIDv2 : Asn1Encodable
	{
		private readonly AlgorithmIdentifier hashAlgorithm;

		private readonly byte[] certHash;

		private readonly IssuerSerial issuerSerial;

		private static readonly AlgorithmIdentifier DefaultAlgID;

		public AlgorithmIdentifier HashAlgorithm => null;

		public IssuerSerial IssuerSerial => null;

		public static EssCertIDv2 GetInstance(object obj)
		{
			return null;
		}

		private EssCertIDv2(Asn1Sequence seq)
		{
		}

		public EssCertIDv2(byte[] certHash)
		{
		}

		public EssCertIDv2(AlgorithmIdentifier algId, byte[] certHash)
		{
		}

		public EssCertIDv2(byte[] certHash, IssuerSerial issuerSerial)
		{
		}

		public EssCertIDv2(AlgorithmIdentifier algId, byte[] certHash, IssuerSerial issuerSerial)
		{
		}

		public byte[] GetCertHash()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
