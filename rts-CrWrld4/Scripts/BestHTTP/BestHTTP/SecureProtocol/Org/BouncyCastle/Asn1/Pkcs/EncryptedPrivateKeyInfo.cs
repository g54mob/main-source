using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class EncryptedPrivateKeyInfo : Asn1Encodable
	{
		private readonly AlgorithmIdentifier algId;

		private readonly Asn1OctetString data;

		public AlgorithmIdentifier EncryptionAlgorithm => null;

		private EncryptedPrivateKeyInfo(Asn1Sequence seq)
		{
		}

		public EncryptedPrivateKeyInfo(AlgorithmIdentifier algId, byte[] encoding)
		{
		}

		public static EncryptedPrivateKeyInfo GetInstance(object obj)
		{
			return null;
		}

		public byte[] GetEncryptedData()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
