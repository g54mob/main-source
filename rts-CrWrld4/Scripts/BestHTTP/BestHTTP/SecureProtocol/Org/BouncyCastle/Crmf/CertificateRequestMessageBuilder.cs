using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public class CertificateRequestMessageBuilder
	{
		private readonly BigInteger _certReqId;

		private X509ExtensionsGenerator _extGenerator;

		private CertTemplateBuilder _templateBuilder;

		private IList _controls;

		private ISignatureFactory _popSigner;

		private PKMacBuilder _pkMacBuilder;

		private char[] _password;

		private GeneralName _sender;

		private int _popoType;

		private PopoPrivKey _popoPrivKey;

		private Asn1Null _popRaVerified;

		private PKMacValue _agreeMac;

		public CertificateRequestMessageBuilder(BigInteger certReqId)
		{
		}

		public CertificateRequestMessageBuilder SetPublicKey(SubjectPublicKeyInfo publicKeyInfo)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetIssuer(X509Name issuer)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetSubject(X509Name subject)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetSerialNumber(BigInteger serialNumber)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetValidity(Time notBefore, Time notAfter)
		{
			return null;
		}

		public CertificateRequestMessageBuilder AddExtension(DerObjectIdentifier oid, bool critical, Asn1Encodable value)
		{
			return null;
		}

		public CertificateRequestMessageBuilder AddExtension(DerObjectIdentifier oid, bool critical, byte[] value)
		{
			return null;
		}

		public CertificateRequestMessageBuilder AddControl(IControl control)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetProofOfPossessionSignKeySigner(ISignatureFactory popoSignatureFactory)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetProofOfPossessionSubsequentMessage(SubsequentMessage msg)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetProofOfPossessionSubsequentMessage(int type, SubsequentMessage msg)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetProofOfPossessionAgreeMac(PKMacValue macValue)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetProofOfPossessionRaVerified()
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetAuthInfoPKMAC(PKMacBuilder pkmacFactory, char[] password)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetAuthInfoSender(X509Name sender)
		{
			return null;
		}

		public CertificateRequestMessageBuilder SetAuthInfoSender(GeneralName sender)
		{
			return null;
		}

		public CertificateRequestMessage Build()
		{
			return null;
		}
	}
}
