using System.Collections.Generic;
using System.Linq;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlMetadataBehavior : DictionaryBehaviorAttribute, IDictionaryMetaInitializer, IDictionaryBehavior
	{
		public static readonly XmlMetadataBehavior Default = new XmlMetadataBehavior();

		private readonly HashSet<string> reservedNamespaceUris = new HashSet<string> { "http://www.w3.org/2000/xmlns/", "http://www.w3.org/2001/XMLSchema-instance", "urn:schemas-castle-org:xml-reference" };

		public IEnumerable<string> ReservedNamespaceUris => reservedNamespaceUris.ToArray();

		public XmlMetadataBehavior AddReservedNamespaceUri(string uri)
		{
			reservedNamespaceUris.Add(uri);
			return this;
		}

		void IDictionaryMetaInitializer.Initialize(IDictionaryAdapterFactory factory, DictionaryAdapterMeta meta)
		{
			meta.SetXmlMeta(new XmlMetadata(meta, reservedNamespaceUris));
		}

		bool IDictionaryMetaInitializer.ShouldHaveBehavior(object behavior)
		{
			if (!(behavior is XmlDefaultsAttribute) && !(behavior is XmlNamespaceAttribute) && !(behavior is XPathVariableAttribute))
			{
				return behavior is XPathFunctionAttribute;
			}
			return true;
		}
	}
}
