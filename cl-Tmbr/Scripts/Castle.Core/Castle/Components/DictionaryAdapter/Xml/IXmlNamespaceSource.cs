namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlNamespaceSource
	{
		string GetElementPrefix(IXmlNode node, string namespaceUri);

		string GetAttributePrefix(IXmlNode node, string namespaceUri);
	}
}
