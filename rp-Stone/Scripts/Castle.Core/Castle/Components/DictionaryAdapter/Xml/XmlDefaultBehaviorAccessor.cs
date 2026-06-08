using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlDefaultBehaviorAccessor : XmlNodeAccessor
	{
		internal static readonly XmlAccessorFactory<XmlDefaultBehaviorAccessor> Factory = (string name, Type type, IXmlContext context) => new XmlDefaultBehaviorAccessor(name, type, context);

		public XmlDefaultBehaviorAccessor(Type type, IXmlContext context)
			: base(type, context)
		{
		}

		public XmlDefaultBehaviorAccessor(string name, Type type, IXmlContext context)
			: base(name, type, context)
		{
		}

		public override IXmlCursor SelectPropertyNode(IXmlNode node, bool mutable)
		{
			CursorFlags flags = ((base.Serializer.Kind != XmlTypeKind.Simple) ? CursorFlags.Elements : CursorFlags.AllNodes);
			return node.SelectChildren(base.KnownTypes, base.Context, flags.MutableIf(mutable));
		}

		public override IXmlCursor SelectCollectionNode(IXmlNode node, bool mutable)
		{
			return SelectPropertyNode(node, mutable);
		}

		public override IXmlCursor SelectCollectionItems(IXmlNode node, bool mutable)
		{
			CursorFlags flags = CursorFlags.Elements | CursorFlags.Multiple;
			return node.SelectChildren(base.KnownTypes, base.Context, flags.MutableIf(mutable));
		}
	}
}
