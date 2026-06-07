using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public class ProofOfPossessionSigningKeyBuilder
	{
		private CertRequest _certRequest;

		private SubjectPublicKeyInfo _pubKeyInfo;

		private GeneralName _name;

		private PKMacValue _publicKeyMAC;

		public ProofOfPossessionSigningKeyBuilder(CertRequest certRequest)
		{
		}

		public ProofOfPossessionSigningKeyBuilder(SubjectPublicKeyInfo pubKeyInfo)
		{
		}

		public ProofOfPossessionSigningKeyBuilder SetSender(GeneralName name)
		{
			return null;
		}

		public ProofOfPossessionSigningKeyBuilder SetPublicKeyMac(PKMacBuilder generator, char[] password)
		{
			return null;
		}

		public PopoSigningKey Build(ISignatureFactory signer)
		{
			return null;
		}
	}
}
