using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlCursor : IXmlIterator, IXmlNode, IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual
	{
		void Reset();

		void MoveTo(IXmlNode node);

		void MoveToEnd();

		void Create(Type type);

		void Coerce(Type type);

		void Remove();

		void RemoveAllNext();
	}
}
