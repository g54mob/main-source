namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlPropertyAccessor : IXmlAccessor
	{
		object GetPropertyValue(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, bool orStub);

		void SetPropertyValue(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, object oldValue, ref object newValue);
	}
}
