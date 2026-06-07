using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public class X509V2AttributeCertificateGenerator
	{
		private readonly X509ExtensionsGenerator extGenerator;

		private V2AttributeCertificateInfoGenerator acInfoGen;

		private DerObjectIdentifier sigOID;

		private AlgorithmIdentifier sigAlgId;

		private string signatureAlgorithm;

		public IEnumerable SignatureAlgNames => null;

		public void Reset()
		{
		}

		public void SetHolder(AttributeCertificateHolder holder)
		{
		}

		public void SetIssuer(AttributeCertificateIssuer issuer)
		{
		}

		public void SetSerialNumber(BigInteger serialNumber)
		{
		}

		public void SetNotBefore(DateTime date)
		{
		}

		public void SetNotAfter(DateTime date)
		{
		}

		public void SetSignatureAlgorithm(string signatureAlgorithm)
		{
		}

		public void AddAttribute(X509Attribute attribute)
		{
		}

		public void SetIssuerUniqueId(bool[] iui)
		{
		}

		public void AddExtension(string oid, bool critical, Asn1Encodable extensionValue)
		{
		}

		public void AddExtension(string oid, bool critical, byte[] extensionValue)
		{
		}

		public IX509AttributeCertificate Generate(AsymmetricKeyParameter privateKey)
		{
			return null;
		}

		public IX509AttributeCertificate Generate(AsymmetricKeyParameter privateKey, SecureRandom random)
		{
			return null;
		}

		public IX509AttributeCertificate Generate(ISignatureFactory signatureCalculatorFactory)
		{
			return null;
		}
	}
}
