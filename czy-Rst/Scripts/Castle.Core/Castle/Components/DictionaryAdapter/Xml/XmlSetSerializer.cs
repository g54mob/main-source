using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlSetSerializer : XmlCollectionSerializer
	{
		public static readonly XmlSetSerializer Instance = new XmlSetSerializer();

		public override Type ListTypeConstructor => typeof(XmlNodeSet<>);

		protected XmlSetSerializer()
		{
		}
	}
}
