using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public class CertificateRequestMessage
	{
		public static readonly int popRaVerified;

		public static readonly int popSigningKey;

		public static readonly int popKeyEncipherment;

		public static readonly int popKeyAgreement;

		private readonly CertReqMsg certReqMsg;

		private readonly Controls controls;

		public bool HasControls => false;

		public bool HasProofOfPossession => false;

		public int ProofOfPossession => 0;

		public bool HasSigningKeyProofOfPossessionWithPkMac => false;

		private static CertReqMsg ParseBytes(byte[] encoding)
		{
			return null;
		}

		public CertificateRequestMessage(byte[] encoded)
		{
		}

		public CertificateRequestMessage(CertReqMsg certReqMsg)
		{
		}

		public CertReqMsg ToAsn1Structure()
		{
			return null;
		}

		public CertTemplate GetCertTemplate()
		{
			return null;
		}

		public bool HasControl(DerObjectIdentifier objectIdentifier)
		{
			return false;
		}

		public IControl GetControl(DerObjectIdentifier type)
		{
			return null;
		}

		public AttributeTypeAndValue FindControl(DerObjectIdentifier type)
		{
			return null;
		}

		public bool IsValidSigningKeyPop(IVerifierFactoryProvider verifierProvider)
		{
			return false;
		}

		private bool verifySignature(IVerifierFactoryProvider verifierFactoryProvider, PopoSigningKey signKey)
		{
			return false;
		}

		public byte[] GetEncoded()
		{
			return null;
		}
	}
}
