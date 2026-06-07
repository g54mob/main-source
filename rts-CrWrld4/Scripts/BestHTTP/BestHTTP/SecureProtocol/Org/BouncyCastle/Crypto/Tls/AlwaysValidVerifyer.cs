using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class AlwaysValidVerifyer : ICertificateVerifyer
	{
		public bool IsValid(Uri targetUri, X509CertificateStructure[] certs)
		{
			return false;
		}
	}
}
