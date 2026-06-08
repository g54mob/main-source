using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlKnownType : IXmlKnownType, IXmlIdentity
	{
		private readonly XmlName name;

		private readonly XmlName xsiType;

		private readonly Type clrType;

		public XmlName Name => name;

		public XmlName XsiType => xsiType;

		public Type ClrType => clrType;

		public XmlKnownType(XmlName name, XmlName xsiType, Type clrType)
		{
			if (name.LocalName == null)
			{
				throw Error.ArgumentNull("name.LocalName");
			}
			if (clrType == null)
			{
				throw Error.ArgumentNull("clrType");
			}
			this.name = name;
			this.xsiType = xsiType;
			this.clrType = clrType;
		}

		public XmlKnownType(string nameLocalName, string nameNamespaceUri, string xsiTypeLocalName, string xsiTypeNamespaceUri, Type clrType)
			: this(new XmlName(nameLocalName, nameNamespaceUri), new XmlName(xsiTypeLocalName, xsiTypeNamespaceUri), clrType)
		{
		}
	}
}
