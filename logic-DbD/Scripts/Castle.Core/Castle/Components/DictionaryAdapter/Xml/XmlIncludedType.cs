using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlIncludedType : IXmlIncludedType
	{
		private readonly XmlName xsiType;

		private readonly Type clrType;

		public XmlName XsiType => xsiType;

		public Type ClrType => clrType;

		public XmlIncludedType(XmlName xsiType, Type clrType)
		{
			if (xsiType.LocalName == null)
			{
				throw Error.ArgumentNull("xsiType.LocalName");
			}
			if (clrType == null)
			{
				throw Error.ArgumentNull("clrType");
			}
			this.xsiType = xsiType;
			this.clrType = clrType;
		}

		public XmlIncludedType(string localName, string namespaceUri, Type clrType)
			: this(new XmlName(localName, namespaceUri), clrType)
		{
		}
	}
}
