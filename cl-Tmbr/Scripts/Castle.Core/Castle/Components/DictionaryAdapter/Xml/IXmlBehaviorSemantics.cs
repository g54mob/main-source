using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlBehaviorSemantics<T>
	{
		string GetLocalName(T behavior);

		string GetNamespaceUri(T behavior);

		Type GetClrType(T behavior);
	}
}
