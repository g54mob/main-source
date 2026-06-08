namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class XRef
	{
		public const string Prefix = "x";

		public const string NamespaceUri = "urn:schemas-castle-org:xml-reference";

		public static readonly XmlName Id = new XmlName("id", "urn:schemas-castle-org:xml-reference");

		public static readonly XmlName Ref = new XmlName("ref", "urn:schemas-castle-org:xml-reference");

		internal static readonly XmlNamespaceAttribute Namespace = new XmlNamespaceAttribute("urn:schemas-castle-org:xml-reference", "x")
		{
			Root = true
		};

		public static string GetId(this IXmlNode node)
		{
			return node.GetAttribute(Id);
		}

		public static void SetId(this IXmlCursor node, string id)
		{
			node.SetAttribute(Id, id);
		}

		public static string GetReference(this IXmlNode node)
		{
			return node.GetAttribute(Ref);
		}

		public static void SetReference(this IXmlCursor cursor, string id)
		{
			cursor.SetAttribute(Ref, id);
		}
	}
}
