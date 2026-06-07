using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp
{
	public class OcspReqGenerator
	{
		private class RequestObject
		{
			internal CertificateID certId;

			internal X509Extensions extensions;

			public RequestObject(CertificateID certId, X509Extensions extensions)
			{
			}

			public Request ToRequest()
			{
				return null;
			}
		}

		private IList list;

		private GeneralName requestorName;

		private X509Extensions requestExtensions;

		public IEnumerable SignatureAlgNames => null;

		public void AddRequest(CertificateID certId)
		{
		}

		public void AddRequest(CertificateID certId, X509Extensions singleRequestExtensions)
		{
		}

		public void SetRequestorName(X509Name requestorName)
		{
		}

		public void SetRequestorName(GeneralName requestorName)
		{
		}

		public void SetRequestExtensions(X509Extensions requestExtensions)
		{
		}

		private OcspReq GenerateRequest(DerObjectIdentifier signingAlgorithm, AsymmetricKeyParameter privateKey, X509Certificate[] chain, SecureRandom random)
		{
			return null;
		}

		public OcspReq Generate()
		{
			return null;
		}

		public OcspReq Generate(string signingAlgorithm, AsymmetricKeyParameter privateKey, X509Certificate[] chain)
		{
			return null;
		}

		public OcspReq Generate(string signingAlgorithm, AsymmetricKeyParameter privateKey, X509Certificate[] chain, SecureRandom random)
		{
			return null;
		}
	}
}
