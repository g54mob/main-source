using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlSelfAccessor : XmlAccessor
	{
		internal static readonly XmlAccessorFactory<XmlSelfAccessor> Factory = (string name, Type type, IXmlContext context) => new XmlSelfAccessor(type, context);

		public XmlSelfAccessor(Type clrType, IXmlContext context)
			: base(clrType, context)
		{
		}

		public override void ConfigureNillable(bool nillable)
		{
		}

		public override IXmlCursor SelectPropertyNode(IXmlNode parentNode, bool mutable)
		{
			return parentNode.SelectSelf(base.ClrType);
		}
	}
}
