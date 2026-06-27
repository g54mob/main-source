using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlAccessor
	{
		Type ClrType { get; }

		XmlTypeSerializer Serializer { get; }

		IXmlContext Context { get; }

		bool IsNillable { get; }

		bool IsReference { get; }

		object GetValue(IXmlNode node, IDictionaryAdapter parentObject, XmlReferenceManager references, bool nodeExists, bool orStub);

		void SetValue(IXmlCursor cursor, IDictionaryAdapter parentObject, XmlReferenceManager references, bool hasCurrent, object oldValue, ref object newValue);

		IXmlCollectionAccessor GetCollectionAccessor(Type itemType);
	}
}
