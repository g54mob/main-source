using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public class X509V1CertificateGenerator
	{
		private V1TbsCertificateGenerator tbsGen;

		private DerObjectIdentifier sigOID;

		private AlgorithmIdentifier sigAlgId;

		private string signatureAlgorithm;

		public IEnumerable SignatureAlgNames => null;

		public void Reset()
		{
		}

		public void SetSerialNumber(BigInteger serialNumber)
		{
		}

		public void SetIssuerDN(X509Name issuer)
		{
		}

		public void SetNotBefore(DateTime date)
		{
		}

		public void SetNotAfter(DateTime date)
		{
		}

		public void SetSubjectDN(X509Name subject)
		{
		}

		public void SetPublicKey(AsymmetricKeyParameter publicKey)
		{
		}

		public void SetSignatureAlgorithm(string signatureAlgorithm)
		{
		}

		public X509Certificate Generate(AsymmetricKeyParameter privateKey)
		{
			return null;
		}

		public X509Certificate Generate(AsymmetricKeyParameter privateKey, SecureRandom random)
		{
			return null;
		}

		public X509Certificate Generate(ISignatureFactory signatureCalculatorFactory)
		{
			return null;
		}

		private X509Certificate GenerateJcaObject(TbsCertificateStructure tbsCert, AlgorithmIdentifier sigAlg, byte[] signature)
		{
			return null;
		}
	}
}
