namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlStringSerializer : XmlTypeSerializer
	{
		public static readonly XmlStringSerializer Instance = new XmlStringSerializer();

		public override XmlTypeKind Kind => XmlTypeKind.Simple;

		protected XmlStringSerializer()
		{
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			return node.Value;
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			node.Value = value.ToString();
		}
	}
}
