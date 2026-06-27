namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlComponentSerializer : XmlTypeSerializer
	{
		public static readonly XmlComponentSerializer Instance = new XmlComponentSerializer();

		public override XmlTypeKind Kind => XmlTypeKind.Complex;

		public override bool CanGetStub => true;

		protected XmlComponentSerializer()
		{
		}

		public override object GetStub(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			XmlAdapter adapter = new XmlAdapter(node, XmlAdapter.For(parent).References);
			return parent.CreateChildAdapter(accessor.ClrType, adapter);
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			XmlAdapter adapter = new XmlAdapter(node.Save(), XmlAdapter.For(parent).References);
			return parent.CreateChildAdapter(node.ClrType, adapter);
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			if (!(value is IDictionaryAdapter dictionaryAdapter))
			{
				throw Error.NotDictionaryAdapter("value");
			}
			XmlAdapter xmlAdapter = XmlAdapter.For(dictionaryAdapter, required: false);
			if (xmlAdapter == null || !node.PositionEquals(xmlAdapter.Node))
			{
				XmlAdapter xmlAdapter2 = new XmlAdapter(node.Save(), XmlAdapter.For(parent).References);
				if (xmlAdapter != null)
				{
					xmlAdapter2.References.UnionWith(xmlAdapter.References);
				}
				IDictionaryAdapter dictionaryAdapter2 = (IDictionaryAdapter)parent.CreateChildAdapter(node.ClrType, xmlAdapter2);
				dictionaryAdapter.CopyTo(dictionaryAdapter2);
				value = dictionaryAdapter2;
			}
		}
	}
}
