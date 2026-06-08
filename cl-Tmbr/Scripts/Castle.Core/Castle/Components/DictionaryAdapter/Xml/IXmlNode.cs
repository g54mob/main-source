using System;
using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlNode : IXmlKnownType, IXmlIdentity, IRealizableSource, IVirtual
	{
		bool IsElement { get; }

		bool IsAttribute { get; }

		bool IsNil { get; set; }

		string Value { get; set; }

		string Xml { get; }

		IXmlNode Parent { get; }

		IXmlNamespaceSource Namespaces { get; }

		object UnderlyingObject { get; }

		CompiledXPath Path { get; }

		string GetAttribute(XmlName name);

		void SetAttribute(XmlName name, string value);

		string LookupPrefix(string namespaceUri);

		string LookupNamespaceUri(string prefix);

		void DefineNamespace(string prefix, string namespaceUri, bool root);

		bool UnderlyingPositionEquals(IXmlNode node);

		IXmlNode Save();

		IXmlCursor SelectSelf(Type clrType);

		IXmlCursor SelectChildren(IXmlKnownTypeMap knownTypes, IXmlNamespaceSource namespaces, CursorFlags flags);

		IXmlIterator SelectSubtree();

		IXmlCursor Select(CompiledXPath path, IXmlIncludedTypeMap includedTypes, IXmlNamespaceSource namespaces, CursorFlags flags);

		object Evaluate(CompiledXPath path);

		void Clear();

		XmlReader ReadSubtree();

		XmlWriter WriteAttributes();

		XmlWriter WriteChildren();
	}
}
