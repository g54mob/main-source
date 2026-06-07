using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class PopoSigningKey : Asn1Encodable
	{
		private readonly PopoSigningKeyInput poposkInput;

		private readonly AlgorithmIdentifier algorithmIdentifier;

		private readonly DerBitString signature;

		public virtual PopoSigningKeyInput PoposkInput => null;

		public virtual AlgorithmIdentifier AlgorithmIdentifier => null;

		public virtual DerBitString Signature => null;

		private PopoSigningKey(Asn1Sequence seq)
		{
		}

		public static PopoSigningKey GetInstance(object obj)
		{
			return null;
		}

		public static PopoSigningKey GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public PopoSigningKey(PopoSigningKeyInput poposkIn, AlgorithmIdentifier aid, DerBitString signature)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
