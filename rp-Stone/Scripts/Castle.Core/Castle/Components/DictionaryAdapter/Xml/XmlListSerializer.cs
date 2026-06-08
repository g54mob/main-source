using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlListSerializer : XmlCollectionSerializer
	{
		public static readonly XmlListSerializer Instance = new XmlListSerializer();

		public override Type ListTypeConstructor => typeof(XmlNodeList<>);

		protected XmlListSerializer()
		{
		}
	}
}
