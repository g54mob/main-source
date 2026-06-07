using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class X509ExtensionsGenerator
	{
		private IDictionary extensions;

		private IList extOrdering;

		public bool IsEmpty => false;

		public void Reset()
		{
		}

		public void AddExtension(DerObjectIdentifier oid, bool critical, Asn1Encodable extValue)
		{
		}

		public void AddExtension(DerObjectIdentifier oid, bool critical, byte[] extValue)
		{
		}

		public X509Extensions Generate()
		{
			return null;
		}
	}
}
