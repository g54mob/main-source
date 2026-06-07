using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class AttributeTable
	{
		private readonly IDictionary attributes;

		public Attribute Item => null;

		public int Count => 0;

		[Obsolete]
		public AttributeTable(Hashtable attrs)
		{
		}

		public AttributeTable(IDictionary attrs)
		{
		}

		public AttributeTable(Asn1EncodableVector v)
		{
		}

		public AttributeTable(Asn1Set s)
		{
		}

		public AttributeTable(Attributes attrs)
		{
		}

		private void AddAttribute(Attribute a)
		{
		}

		public Attribute Get(DerObjectIdentifier oid)
		{
			return null;
		}

		public Asn1EncodableVector GetAll(DerObjectIdentifier oid)
		{
			return null;
		}

		public IDictionary ToDictionary()
		{
			return null;
		}

		public Hashtable ToHashtable()
		{
			return null;
		}

		public Asn1EncodableVector ToAsn1EncodableVector()
		{
			return null;
		}

		public Attributes ToAttributes()
		{
			return null;
		}

		public AttributeTable Add(DerObjectIdentifier attrType, Asn1Encodable attrValue)
		{
			return null;
		}

		public AttributeTable Remove(DerObjectIdentifier attrType)
		{
			return null;
		}
	}
}
