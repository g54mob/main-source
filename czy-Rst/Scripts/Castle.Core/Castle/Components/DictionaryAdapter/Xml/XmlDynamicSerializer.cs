namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlDynamicSerializer : XmlTypeSerializer
	{
		public static readonly XmlDynamicSerializer Instance = new XmlDynamicSerializer();

		public override XmlTypeKind Kind => XmlTypeKind.Simple;

		protected XmlDynamicSerializer()
		{
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			if (!(node.ClrType == typeof(object)))
			{
				return XmlTypeSerializer.For(node.ClrType).GetValue(node, parent, accessor);
			}
			return new object();
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			if (node.ClrType != typeof(object))
			{
				XmlTypeSerializer.For(node.ClrType).SetValue(node, parent, accessor, oldValue, ref value);
			}
			else
			{
				node.Clear();
			}
		}
	}
}
