using System;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlAttributeBehaviorAccessor : XmlNodeAccessor, IConfigurable<XmlAttributeAttribute>
	{
		internal static readonly XmlAccessorFactory<XmlAttributeBehaviorAccessor> Factory = (string name, Type type, IXmlContext context) => new XmlAttributeBehaviorAccessor(name, type, context);

		public XmlAttributeBehaviorAccessor(string name, Type type, IXmlContext context)
			: base(name, type, context)
		{
			if (base.Serializer.Kind != XmlTypeKind.Simple)
			{
				throw Error.NotSupported();
			}
		}

		public void Configure(XmlAttributeAttribute attribute)
		{
			ConfigureLocalName(attribute.AttributeName);
			ConfigureNamespaceUri(attribute.Namespace);
		}

		public override void ConfigureNillable(bool nillable)
		{
		}

		public override void ConfigureReference(bool isReference)
		{
		}

		public override IXmlCollectionAccessor GetCollectionAccessor(Type itemType)
		{
			throw Error.NotSupported();
		}

		public override IXmlCursor SelectPropertyNode(IXmlNode node, bool mutable)
		{
			return node.SelectChildren(this, base.Context, CursorFlags.Attributes.MutableIf(mutable));
		}

		public override IXmlCursor SelectCollectionNode(IXmlNode node, bool mutable)
		{
			throw Error.NotSupported();
		}
	}
}
