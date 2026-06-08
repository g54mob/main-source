namespace Castle.Components.DictionaryAdapter.Xml
{
	internal class XmlNodeList<T> : ListProjection<T>, IXmlNodeSource
	{
		public IXmlNode Node => ((IXmlNodeSource)base.Adapter).Node;

		public XmlNodeList(IXmlNode parentNode, IDictionaryAdapter parentObject, IXmlCollectionAccessor accessor)
			: base((ICollectionAdapter<T>)new XmlCollectionAdapter<T>(parentNode, parentObject, accessor))
		{
		}
	}
}
