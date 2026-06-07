using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class PrivateKeyInfo : Asn1Encodable
	{
		private readonly DerInteger version;

		private readonly AlgorithmIdentifier privateKeyAlgorithm;

		private readonly Asn1OctetString privateKey;

		private readonly Asn1Set attributes;

		private readonly DerBitString publicKey;

		public virtual Asn1Set Attributes => null;

		public virtual bool HasPublicKey => false;

		public virtual AlgorithmIdentifier PrivateKeyAlgorithm => null;

		public virtual Asn1OctetString PrivateKeyData => null;

		public virtual DerBitString PublicKeyData => null;

		public static PrivateKeyInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static PrivateKeyInfo GetInstance(object obj)
		{
			return null;
		}

		private static int GetVersionValue(DerInteger version)
		{
			return 0;
		}

		public PrivateKeyInfo(AlgorithmIdentifier privateKeyAlgorithm, Asn1Encodable privateKey)
		{
		}

		public PrivateKeyInfo(AlgorithmIdentifier privateKeyAlgorithm, Asn1Encodable privateKey, Asn1Set attributes)
		{
		}

		public PrivateKeyInfo(AlgorithmIdentifier privateKeyAlgorithm, Asn1Encodable privateKey, Asn1Set attributes, byte[] publicKey)
		{
		}

		private PrivateKeyInfo(Asn1Sequence seq)
		{
		}

		public virtual Asn1Object ParsePrivateKey()
		{
			return null;
		}

		public virtual Asn1Object ParsePublicKey()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
