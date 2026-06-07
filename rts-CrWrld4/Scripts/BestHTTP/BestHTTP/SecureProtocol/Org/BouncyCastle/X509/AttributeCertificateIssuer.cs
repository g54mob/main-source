using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public class AttributeCertificateIssuer : IX509Selector, ICloneable
	{
		internal readonly Asn1Encodable form;

		public AttributeCertificateIssuer(AttCertIssuer issuer)
		{
		}

		public AttributeCertificateIssuer(X509Name principal)
		{
		}

		private object[] GetNames()
		{
			return null;
		}

		public X509Name[] GetPrincipals()
		{
			return null;
		}

		private bool MatchesDN(X509Name subject, GeneralNames targets)
		{
			return false;
		}

		public object Clone()
		{
			return null;
		}

		public bool Match(X509Certificate x509Cert)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Match(object obj)
		{
			return false;
		}
	}
}
