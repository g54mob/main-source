using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs
{
	public class X509CertificateEntry : Pkcs12Entry
	{
		private readonly X509Certificate cert;

		public X509Certificate Certificate => null;

		public X509CertificateEntry(X509Certificate cert)
			: base(null)
		{
		}

		[Obsolete]
		public X509CertificateEntry(X509Certificate cert, Hashtable attributes)
			: base(null)
		{
		}

		public X509CertificateEntry(X509Certificate cert, IDictionary attributes)
			: base(null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
