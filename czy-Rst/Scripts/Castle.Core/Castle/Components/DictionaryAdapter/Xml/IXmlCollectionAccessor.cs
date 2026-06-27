using System.Collections;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlCollectionAccessor : IXmlAccessor
	{
		IXmlCursor SelectCollectionItems(IXmlNode parentNode, bool mutable);

		void GetCollectionItems(IXmlNode parentNode, IDictionaryAdapter parentObject, XmlReferenceManager references, IList values);
	}
}
