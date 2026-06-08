using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public delegate TAccessor XmlAccessorFactory<TAccessor>(string name, Type type, IXmlContext context) where TAccessor : XmlAccessor;
}
