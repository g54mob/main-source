using System;
using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlContext : XmlContextBase, IXmlContext, IXmlNamespaceSource
	{
		private readonly XmlMetadata metadata;

		public string ChildNamespaceUri => metadata.ChildNamespaceUri;

		public XmlContext(XmlMetadata metadata)
		{
			if (metadata == null)
			{
				throw Error.ArgumentNull("metadata");
			}
			this.metadata = metadata;
		}

		protected XmlContext(XmlContext parent)
			: base(parent)
		{
			metadata = parent.metadata;
		}

		public IXmlContext Clone()
		{
			return new XmlContext(this);
		}

		public bool IsReservedNamespaceUri(string namespaceUri)
		{
			return metadata.IsReservedNamespaceUri(namespaceUri);
		}

		public XmlName GetDefaultXsiType(Type clrType)
		{
			return metadata.GetDefaultXsiType(clrType);
		}

		public IEnumerable<IXmlIncludedType> GetIncludedTypes(Type baseType)
		{
			return metadata.GetIncludedTypes(baseType);
		}
	}
}
