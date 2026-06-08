namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlIdentity
	{
		XmlName Name { get; }

		XmlName XsiType { get; }
	}
}
