namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class Xsd
	{
		public const string Prefix = "xsd";

		public const string NamespaceUri = "http://www.w3.org/2001/XMLSchema";

		internal static readonly XmlNamespaceAttribute Namespace = new XmlNamespaceAttribute("http://www.w3.org/2001/XMLSchema", "xsd")
		{
			Root = true
		};
	}
}
