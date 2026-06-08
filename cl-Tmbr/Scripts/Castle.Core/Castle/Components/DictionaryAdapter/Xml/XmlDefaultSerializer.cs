using System;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlDefaultSerializer : XmlTypeSerializer
	{
		private readonly XmlSerializer serializer;

		public static readonly XmlRootAttribute Root = new XmlRootAttribute
		{
			ElementName = "Root",
			Namespace = string.Empty
		};

		public override XmlTypeKind Kind => XmlTypeKind.Complex;

		public XmlDefaultSerializer(Type type)
		{
			serializer = new XmlSerializer(type, Root);
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			using XmlSubtreeReader xmlReader = new XmlSubtreeReader(node, Root);
			return serializer.CanDeserialize(xmlReader) ? serializer.Deserialize(xmlReader) : null;
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			using XmlSubtreeWriter xmlWriter = new XmlSubtreeWriter(node);
			serializer.Serialize(xmlWriter, value);
		}
	}
}
