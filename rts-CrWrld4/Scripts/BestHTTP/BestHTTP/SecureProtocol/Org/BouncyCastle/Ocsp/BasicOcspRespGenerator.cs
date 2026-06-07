using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp
{
	public class BasicOcspRespGenerator
	{
		private class ResponseObject
		{
			internal CertificateID certId;

			internal CertStatus certStatus;

			internal DerGeneralizedTime thisUpdate;

			internal DerGeneralizedTime nextUpdate;

			internal X509Extensions extensions;

			public ResponseObject(CertificateID certId, CertificateStatus certStatus, DateTime thisUpdate, X509Extensions extensions)
			{
			}

			public ResponseObject(CertificateID certId, CertificateStatus certStatus, DateTime thisUpdate, DateTime nextUpdate, X509Extensions extensions)
			{
			}

			private ResponseObject(CertificateID certId, CertificateStatus certStatus, DerGeneralizedTime thisUpdate, DerGeneralizedTime nextUpdate, X509Extensions extensions)
			{
			}

			public SingleResponse ToResponse()
			{
				return null;
			}
		}

		private readonly IList list;

		private X509Extensions responseExtensions;

		private RespID responderID;

		public IEnumerable SignatureAlgNames => null;

		public BasicOcspRespGenerator(RespID responderID)
		{
		}

		public BasicOcspRespGenerator(AsymmetricKeyParameter publicKey)
		{
		}

		public void AddResponse(CertificateID certID, CertificateStatus certStatus)
		{
		}

		public void AddResponse(CertificateID certID, CertificateStatus certStatus, X509Extensions singleExtensions)
		{
		}

		public void AddResponse(CertificateID certID, CertificateStatus certStatus, DateTime nextUpdate, X509Extensions singleExtensions)
		{
		}

		public void AddResponse(CertificateID certID, CertificateStatus certStatus, DateTime thisUpdate, DateTime nextUpdate, X509Extensions singleExtensions)
		{
		}

		public void SetResponseExtensions(X509Extensions responseExtensions)
		{
		}

		private BasicOcspResp GenerateResponse(ISignatureFactory signatureCalculator, X509Certificate[] chain, DateTime producedAt)
		{
			return null;
		}

		public BasicOcspResp Generate(string signingAlgorithm, AsymmetricKeyParameter privateKey, X509Certificate[] chain, DateTime thisUpdate)
		{
			return null;
		}

		public BasicOcspResp Generate(string signingAlgorithm, AsymmetricKeyParameter privateKey, X509Certificate[] chain, DateTime producedAt, SecureRandom random)
		{
			return null;
		}

		public BasicOcspResp Generate(ISignatureFactory signatureCalculatorFactory, X509Certificate[] chain, DateTime producedAt)
		{
			return null;
		}
	}
}
