using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Tsp
{
	public class MessageImprint : Asn1Encodable
	{
		private readonly AlgorithmIdentifier hashAlgorithm;

		private readonly byte[] hashedMessage;

		public AlgorithmIdentifier HashAlgorithm => null;

		public static MessageImprint GetInstance(object obj)
		{
			return null;
		}

		private MessageImprint(Asn1Sequence seq)
		{
		}

		public MessageImprint(AlgorithmIdentifier hashAlgorithm, byte[] hashedMessage)
		{
		}

		public byte[] GetHashedMessage()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
