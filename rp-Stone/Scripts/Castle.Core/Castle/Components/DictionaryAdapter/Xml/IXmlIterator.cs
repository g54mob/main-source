namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlIterator : IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual
	{
		bool MoveNext();
	}
}
