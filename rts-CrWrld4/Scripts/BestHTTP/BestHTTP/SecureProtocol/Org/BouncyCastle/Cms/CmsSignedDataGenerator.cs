using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsSignedDataGenerator : CmsSignedGenerator
	{
		private class SignerInf
		{
			private readonly CmsSignedGenerator outer;

			private readonly ISignatureFactory sigCalc;

			private readonly SignerIdentifier signerIdentifier;

			private readonly string digestOID;

			private readonly string encOID;

			private readonly CmsAttributeTableGenerator sAttr;

			private readonly CmsAttributeTableGenerator unsAttr;

			private readonly BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable baseSignedTable;

			internal AlgorithmIdentifier DigestAlgorithmID => null;

			internal CmsAttributeTableGenerator SignedAttributes => null;

			internal CmsAttributeTableGenerator UnsignedAttributes => null;

			internal SignerInf(CmsSignedGenerator outer, AsymmetricKeyParameter key, SignerIdentifier signerIdentifier, string digestOID, string encOID, CmsAttributeTableGenerator sAttr, CmsAttributeTableGenerator unsAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable baseSignedTable)
			{
			}

			internal SignerInf(CmsSignedGenerator outer, ISignatureFactory sigCalc, SignerIdentifier signerIdentifier, CmsAttributeTableGenerator sAttr, CmsAttributeTableGenerator unsAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable baseSignedTable)
			{
			}

			internal SignerInfo ToSignerInfo(DerObjectIdentifier contentType, CmsProcessable content, SecureRandom random)
			{
				return null;
			}
		}

		private static readonly CmsSignedHelper Helper;

		private readonly IList signerInfs;

		public CmsSignedDataGenerator()
		{
		}

		public CmsSignedDataGenerator(SecureRandom rand)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string digestOID)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string encryptionOID, string digestOID)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string digestOID)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string encryptionOID, string digestOID)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string digestOID, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string encryptionOID, string digestOID, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string digestOID, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string encryptionOID, string digestOID, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string digestOID, CmsAttributeTableGenerator signedAttrGen, CmsAttributeTableGenerator unsignedAttrGen)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string encryptionOID, string digestOID, CmsAttributeTableGenerator signedAttrGen, CmsAttributeTableGenerator unsignedAttrGen)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string digestOID, CmsAttributeTableGenerator signedAttrGen, CmsAttributeTableGenerator unsignedAttrGen)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string encryptionOID, string digestOID, CmsAttributeTableGenerator signedAttrGen, CmsAttributeTableGenerator unsignedAttrGen)
		{
		}

		public void AddSignerInfoGenerator(SignerInfoGenerator signerInfoGenerator)
		{
		}

		private void doAddSigner(AsymmetricKeyParameter privateKey, SignerIdentifier signerIdentifier, string encryptionOID, string digestOID, CmsAttributeTableGenerator signedAttrGen, CmsAttributeTableGenerator unsignedAttrGen, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable baseSignedTable)
		{
		}

		public CmsSignedData Generate(CmsProcessable content)
		{
			return null;
		}

		public CmsSignedData Generate(string signedContentType, CmsProcessable content, bool encapsulate)
		{
			return null;
		}

		public CmsSignedData Generate(CmsProcessable content, bool encapsulate)
		{
			return null;
		}

		public SignerInformationStore GenerateCounterSigners(SignerInformation signer)
		{
			return null;
		}
	}
}
