using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class SysXmlExtensions
	{
		public static void DefineNamespace(this XmlElement node, string prefix, string namespaceUri)
		{
			XmlAttribute xmlAttribute = node.OwnerDocument.CreateAttribute("xmlns", prefix, "http://www.w3.org/2000/xmlns/");
			xmlAttribute.Value = namespaceUri;
			node.SetAttributeNode(xmlAttribute);
		}

		public static bool IsNamespace(this XmlAttribute attribute)
		{
			if (!(attribute.Prefix == "xmlns"))
			{
				if (string.IsNullOrEmpty(attribute.Prefix))
				{
					return attribute.LocalName == "xmlns";
				}
				return false;
			}
			return true;
		}

		public static XmlElement FindRoot(this XmlElement node)
		{
			while (node.ParentNode is XmlElement xmlElement)
			{
				node = xmlElement;
			}
			return node;
		}

		public static bool IsXsiType(this XmlAttribute attribute)
		{
			if (attribute.LocalName == Xsi.Type.LocalName)
			{
				return attribute.NamespaceURI == "http://www.w3.org/2001/XMLSchema-instance";
			}
			return false;
		}
	}
}
