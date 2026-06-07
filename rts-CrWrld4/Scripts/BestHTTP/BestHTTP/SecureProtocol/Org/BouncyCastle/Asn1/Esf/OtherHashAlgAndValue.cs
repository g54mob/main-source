using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class OtherHashAlgAndValue : Asn1Encodable
	{
		private readonly AlgorithmIdentifier hashAlgorithm;

		private readonly Asn1OctetString hashValue;

		public AlgorithmIdentifier HashAlgorithm => null;

		public static OtherHashAlgAndValue GetInstance(object obj)
		{
			return null;
		}

		private OtherHashAlgAndValue(Asn1Sequence seq)
		{
		}

		public OtherHashAlgAndValue(AlgorithmIdentifier hashAlgorithm, byte[] hashValue)
		{
		}

		public OtherHashAlgAndValue(AlgorithmIdentifier hashAlgorithm, Asn1OctetString hashValue)
		{
		}

		public byte[] GetHashValue()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
