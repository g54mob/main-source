using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlEnumerationSerializer : XmlStringSerializer
	{
		public new static readonly XmlEnumerationSerializer Instance = new XmlEnumerationSerializer();

		public override XmlTypeKind Kind => XmlTypeKind.Simple;

		protected XmlEnumerationSerializer()
		{
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			return Enum.Parse(node.ClrType, node.Value, ignoreCase: true);
		}
	}
}
