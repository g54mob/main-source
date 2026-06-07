using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs
{
	public class Pkcs10CertificationRequest : CertificationRequest
	{
		protected static readonly IDictionary algorithms;

		protected static readonly IDictionary exParams;

		protected static readonly IDictionary keyAlgorithms;

		protected static readonly IDictionary oids;

		protected static readonly ISet noParams;

		static Pkcs10CertificationRequest()
		{
		}

		private static RsassaPssParameters CreatePssParams(AlgorithmIdentifier hashAlgId, int saltSize)
		{
			return null;
		}

		protected Pkcs10CertificationRequest()
		{
		}

		public Pkcs10CertificationRequest(byte[] encoded)
		{
		}

		public Pkcs10CertificationRequest(Asn1Sequence seq)
		{
		}

		public Pkcs10CertificationRequest(Stream input)
		{
		}

		public Pkcs10CertificationRequest(string signatureAlgorithm, X509Name subject, AsymmetricKeyParameter publicKey, Asn1Set attributes, AsymmetricKeyParameter signingKey)
		{
		}

		public Pkcs10CertificationRequest(ISignatureFactory signatureFactory, X509Name subject, AsymmetricKeyParameter publicKey, Asn1Set attributes, AsymmetricKeyParameter signingKey)
		{
		}

		public Pkcs10CertificationRequest(ISignatureFactory signatureFactory, X509Name subject, AsymmetricKeyParameter publicKey, Asn1Set attributes)
		{
		}

		private void Init(ISignatureFactory signatureFactory, X509Name subject, AsymmetricKeyParameter publicKey, Asn1Set attributes)
		{
		}

		public AsymmetricKeyParameter GetPublicKey()
		{
			return null;
		}

		public bool Verify()
		{
			return false;
		}

		public bool Verify(AsymmetricKeyParameter publicKey)
		{
			return false;
		}

		public bool Verify(IVerifierFactoryProvider verifierProvider)
		{
			return false;
		}

		public bool Verify(IVerifierFactory verifier)
		{
			return false;
		}

		private void SetSignatureParameters(ISigner signature, Asn1Encodable asn1Params)
		{
		}

		internal static string GetSignatureName(AlgorithmIdentifier sigAlgId)
		{
			return null;
		}

		private static string GetDigestAlgName(DerObjectIdentifier digestAlgOID)
		{
			return null;
		}
	}
}
