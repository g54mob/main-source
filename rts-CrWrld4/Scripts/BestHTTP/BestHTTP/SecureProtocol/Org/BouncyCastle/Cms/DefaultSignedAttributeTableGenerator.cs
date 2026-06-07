using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class DefaultSignedAttributeTableGenerator : CmsAttributeTableGenerator
	{
		private readonly IDictionary table;

		public DefaultSignedAttributeTableGenerator()
		{
		}

		public DefaultSignedAttributeTableGenerator(AttributeTable attributeTable)
		{
		}

		protected virtual Hashtable createStandardAttributeTable(IDictionary parameters)
		{
			return null;
		}

		private void DoCreateStandardAttributeTable(IDictionary parameters, IDictionary std)
		{
		}

		public virtual AttributeTable GetAttributes(IDictionary parameters)
		{
			return null;
		}
	}
}
