using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class Signature : Asn1Encodable
	{
		internal AlgorithmIdentifier signatureAlgorithm;

		internal DerBitString signatureValue;

		internal Asn1Sequence certs;

		public AlgorithmIdentifier SignatureAlgorithm => null;

		public DerBitString SignatureValue => null;

		public Asn1Sequence Certs => null;

		public static Signature GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static Signature GetInstance(object obj)
		{
			return null;
		}

		public Signature(AlgorithmIdentifier signatureAlgorithm, DerBitString signatureValue)
		{
		}

		public Signature(AlgorithmIdentifier signatureAlgorithm, DerBitString signatureValue, Asn1Sequence certs)
		{
		}

		private Signature(Asn1Sequence seq)
		{
		}

		public byte[] GetSignatureOctets()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
