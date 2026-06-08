using System;
using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlContext : IXmlNamespaceSource
	{
		string ChildNamespaceUri { get; }

		IXmlContext Clone();

		XmlName GetDefaultXsiType(Type clrType);

		IEnumerable<IXmlIncludedType> GetIncludedTypes(Type baseType);

		bool IsReservedNamespaceUri(string namespaceUri);

		void AddVariable(XPathVariableAttribute attribute);

		void AddFunction(XPathFunctionAttribute attribute);

		void Enlist(CompiledXPath path);
	}
}
