using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs
{
	public abstract class Pkcs12Entry
	{
		private readonly IDictionary attributes;

		public Asn1Encodable Item => null;

		public Asn1Encodable Item => null;

		public IEnumerable BagAttributeKeys => null;

		protected internal Pkcs12Entry(IDictionary attributes)
		{
		}

		public Asn1Encodable GetBagAttribute(DerObjectIdentifier oid)
		{
			return null;
		}

		public Asn1Encodable GetBagAttribute(string oid)
		{
			return null;
		}

		public IEnumerator GetBagAttributeKeys()
		{
			return null;
		}
	}
}
