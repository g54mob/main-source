namespace Castle.Components.DictionaryAdapter.Xml
{
	internal class XmlNodeSet<T> : SetProjection<T>, IXmlNodeSource
	{
		public IXmlNode Node => ((IXmlNodeSource)base.Adapter).Node;

		public XmlNodeSet(IXmlNode parentNode, IDictionaryAdapter parentObject, IXmlCollectionAccessor accessor)
			: base((ICollectionAdapter<T>)new XmlCollectionAdapter<T>(parentNode, parentObject, accessor))
		{
		}
	}
}
