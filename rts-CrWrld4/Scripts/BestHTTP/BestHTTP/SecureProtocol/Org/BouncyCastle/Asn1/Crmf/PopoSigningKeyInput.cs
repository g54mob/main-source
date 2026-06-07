using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class PopoSigningKeyInput : Asn1Encodable
	{
		private readonly GeneralName sender;

		private readonly PKMacValue publicKeyMac;

		private readonly SubjectPublicKeyInfo publicKey;

		public virtual GeneralName Sender => null;

		public virtual PKMacValue PublicKeyMac => null;

		public virtual SubjectPublicKeyInfo PublicKey => null;

		private PopoSigningKeyInput(Asn1Sequence seq)
		{
		}

		public static PopoSigningKeyInput GetInstance(object obj)
		{
			return null;
		}

		public PopoSigningKeyInput(GeneralName sender, SubjectPublicKeyInfo spki)
		{
		}

		public PopoSigningKeyInput(PKMacValue pkmac, SubjectPublicKeyInfo spki)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
