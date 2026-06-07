using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class DefaultAuthenticatedAttributeTableGenerator : CmsAttributeTableGenerator
	{
		private readonly IDictionary table;

		public DefaultAuthenticatedAttributeTableGenerator()
		{
		}

		public DefaultAuthenticatedAttributeTableGenerator(AttributeTable attributeTable)
		{
		}

		protected virtual IDictionary CreateStandardAttributeTable(IDictionary parameters)
		{
			return null;
		}

		public virtual AttributeTable GetAttributes(IDictionary parameters)
		{
			return null;
		}
	}
}
