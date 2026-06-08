namespace Castle.Components.DictionaryAdapter.Xml
{
	internal struct XmlCollectionItem<T>
	{
		public readonly IXmlNode Node;

		public readonly T Value;

		public readonly bool HasValue;

		public XmlCollectionItem(IXmlNode node)
			: this(node, default(T), hasValue: false)
		{
		}

		public XmlCollectionItem(IXmlNode node, T value)
			: this(node, value, hasValue: true)
		{
		}

		private XmlCollectionItem(IXmlNode node, T value, bool hasValue)
		{
			Node = node;
			Value = value;
			HasValue = hasValue;
		}

		public XmlCollectionItem<T> WithValue(T value)
		{
			return new XmlCollectionItem<T>(Node, value);
		}
	}
}
