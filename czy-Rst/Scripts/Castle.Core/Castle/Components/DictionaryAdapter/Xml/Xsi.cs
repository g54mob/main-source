namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class Xsi
	{
		public const string Prefix = "xsi";

		public const string NamespaceUri = "http://www.w3.org/2001/XMLSchema-instance";

		public const string NilValue = "true";

		public static readonly XmlName Type = new XmlName("type", "http://www.w3.org/2001/XMLSchema-instance");

		public static readonly XmlName Nil = new XmlName("nil", "http://www.w3.org/2001/XMLSchema-instance");

		internal static readonly XmlNamespaceAttribute Namespace = new XmlNamespaceAttribute("http://www.w3.org/2001/XMLSchema-instance", "xsi")
		{
			Root = true
		};

		public static XmlName GetXsiType(this IXmlNode node)
		{
			string attribute = node.GetAttribute(Type);
			if (attribute == null)
			{
				return XmlName.Empty;
			}
			XmlName result = XmlName.ParseQName(attribute);
			if (result.NamespaceUri != null)
			{
				string namespaceUri = node.LookupNamespaceUri(result.NamespaceUri);
				result = result.WithNamespaceUri(namespaceUri);
			}
			return result;
		}

		public static void SetXsiType(this IXmlNode node, XmlName xsiType)
		{
			if (xsiType.NamespaceUri != null)
			{
				string attributePrefix = node.Namespaces.GetAttributePrefix(node, xsiType.NamespaceUri);
				xsiType = xsiType.WithNamespaceUri(attributePrefix);
			}
			node.SetAttribute(Type, xsiType.ToString());
		}

		public static bool IsXsiNil(this IXmlNode node)
		{
			return node.GetAttribute(Nil) == "true";
		}

		public static void SetXsiNil(this IXmlNode node, bool nil)
		{
			string value;
			if (nil)
			{
				node.Clear();
				value = "true";
			}
			else
			{
				value = null;
			}
			node.SetAttribute(Nil, value);
		}
	}
}
