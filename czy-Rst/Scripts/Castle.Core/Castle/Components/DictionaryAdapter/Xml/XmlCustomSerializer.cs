using System;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlCustomSerializer : XmlTypeSerializer
	{
		public static readonly XmlCustomSerializer Instance = new XmlCustomSerializer();

		public override XmlTypeKind Kind => XmlTypeKind.Complex;

		private XmlCustomSerializer()
		{
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			IXmlSerializable xmlSerializable = (IXmlSerializable)Activator.CreateInstance(node.ClrType);
			using XmlSubtreeReader reader = new XmlSubtreeReader(node, XmlDefaultSerializer.Root);
			xmlSerializable.ReadXml(reader);
			return xmlSerializable;
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			IXmlSerializable xmlSerializable = (IXmlSerializable)value;
			XmlRootAttribute root = XmlDefaultSerializer.Root;
			using XmlSubtreeWriter xmlSubtreeWriter = new XmlSubtreeWriter(node);
			xmlSubtreeWriter.WriteStartElement(string.Empty, root.ElementName, root.Namespace);
			xmlSerializable.WriteXml(xmlSubtreeWriter);
			xmlSubtreeWriter.WriteEndElement();
		}
	}
}
