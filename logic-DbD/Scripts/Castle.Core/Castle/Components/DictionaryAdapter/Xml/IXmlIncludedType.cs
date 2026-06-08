using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlIncludedType
	{
		XmlName XsiType { get; }

		Type ClrType { get; }
	}
}
