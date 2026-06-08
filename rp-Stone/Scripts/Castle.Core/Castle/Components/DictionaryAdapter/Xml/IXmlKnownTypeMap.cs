using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlKnownTypeMap
	{
		IXmlKnownType Default { get; }

		bool TryGet(IXmlIdentity xmlNode, out IXmlKnownType knownType);

		bool TryGet(Type clrType, out IXmlKnownType knownType);
	}
}
