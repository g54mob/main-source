using System;
using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlIgnoreBehaviorAccessor : XmlAccessor
	{
		private sealed class DummyContext : IXmlContext, IXmlNamespaceSource
		{
			public static DummyContext Instance = new DummyContext();

			public string ChildNamespaceUri => null;

			private DummyContext()
			{
			}

			public IXmlContext Clone()
			{
				return this;
			}

			public bool IsReservedNamespaceUri(string namespaceUri)
			{
				return false;
			}

			public XmlName GetDefaultXsiType(Type clrType)
			{
				return new XmlName("anyType", "http://www.w3.org/2001/XMLSchema");
			}

			public IEnumerable<IXmlIncludedType> GetIncludedTypes(Type baseType)
			{
				throw Error.NotSupported();
			}

			public void Enlist(CompiledXPath path)
			{
				throw Error.NotSupported();
			}

			public string GetElementPrefix(IXmlNode node, string namespaceUri)
			{
				throw Error.NotSupported();
			}

			public string GetAttributePrefix(IXmlNode node, string namespaceUri)
			{
				throw Error.NotSupported();
			}

			public void AddVariable(XPathVariableAttribute attribute)
			{
				throw Error.NotSupported();
			}

			public void AddFunction(XPathFunctionAttribute attribute)
			{
				throw Error.NotSupported();
			}
		}

		public static readonly XmlIgnoreBehaviorAccessor Instance = new XmlIgnoreBehaviorAccessor();

		public override bool IsIgnored => true;

		private XmlIgnoreBehaviorAccessor()
			: base(typeof(object), DummyContext.Instance)
		{
		}

		public override IXmlCollectionAccessor GetCollectionAccessor(Type itemType)
		{
			throw Error.NotSupported();
		}

		public override IXmlCursor SelectPropertyNode(IXmlNode node, bool mutable)
		{
			throw Error.NotSupported();
		}

		public override IXmlCursor SelectCollectionNode(IXmlNode node, bool mutable)
		{
			throw Error.NotSupported();
		}

		public override IXmlCursor SelectCollectionItems(IXmlNode node, bool mutable)
		{
			throw Error.NotSupported();
		}
	}
}
