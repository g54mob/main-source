using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class SignerInfoGenerator
	{
		internal X509Certificate certificate;

		internal ISignatureFactory contentSigner;

		internal SignerIdentifier sigId;

		internal CmsAttributeTableGenerator signedGen;

		internal CmsAttributeTableGenerator unsignedGen;

		private bool isDirectSignature;

		internal SignerInfoGenerator(SignerIdentifier sigId, ISignatureFactory signerFactory)
		{
		}

		internal SignerInfoGenerator(SignerIdentifier sigId, ISignatureFactory signerFactory, bool isDirectSignature)
		{
		}

		internal SignerInfoGenerator(SignerIdentifier sigId, ISignatureFactory contentSigner, CmsAttributeTableGenerator signedGen, CmsAttributeTableGenerator unsignedGen)
		{
		}

		internal void setAssociatedCertificate(X509Certificate certificate)
		{
		}
	}
}
