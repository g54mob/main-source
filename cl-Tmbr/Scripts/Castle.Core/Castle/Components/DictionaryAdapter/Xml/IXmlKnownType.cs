using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlKnownType : IXmlIdentity
	{
		Type ClrType { get; }
	}
}
