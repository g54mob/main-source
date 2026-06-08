using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlIncludedTypeMap
	{
		IXmlIncludedType Default { get; }

		bool TryGet(XmlName xsiType, out IXmlIncludedType includedType);

		bool TryGet(Type clrType, out IXmlIncludedType includedType);
	}
}
