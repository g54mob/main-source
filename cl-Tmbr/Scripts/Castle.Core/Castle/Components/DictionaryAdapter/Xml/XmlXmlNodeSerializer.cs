using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlXmlNodeSerializer : XmlTypeSerializer
	{
		public static readonly XmlXmlNodeSerializer Instance = new XmlXmlNodeSerializer();

		public override XmlTypeKind Kind => XmlTypeKind.Complex;

		private XmlXmlNodeSerializer()
		{
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			IRealizable<XmlNode> realizable = node.AsRealizable<XmlNode>();
			if (realizable == null || !realizable.IsReal)
			{
				return null;
			}
			return realizable.Value;
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			XmlNode xmlNode = (XmlNode)value;
			using XmlSubtreeWriter w = new XmlSubtreeWriter(node);
			xmlNode.WriteTo(w);
		}
	}
}
