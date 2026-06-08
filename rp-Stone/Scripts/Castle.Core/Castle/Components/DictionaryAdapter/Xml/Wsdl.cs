namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class Wsdl
	{
		public const string Prefix = "wsdl";

		public const string NamespaceUri = "http://microsoft.com/wsdl/types/";

		internal static readonly XmlNamespaceAttribute Namespace = new XmlNamespaceAttribute("http://microsoft.com/wsdl/types/", "wsdl")
		{
			Root = true
		};
	}
}
