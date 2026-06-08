using System;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryAdapterFactory
	{
		T GetAdapter<T>(IDictionary dictionary);

		object GetAdapter(Type type, IDictionary dictionary);

		object GetAdapter(Type type, IDictionary dictionary, PropertyDescriptor descriptor);

		T GetAdapter<T>(NameValueCollection nameValues);

		object GetAdapter(Type type, NameValueCollection nameValues);

		T GetAdapter<T>(XmlNode xmlNode);

		object GetAdapter(Type type, XmlNode xmlNode);

		DictionaryAdapterMeta GetAdapterMeta(Type type);

		DictionaryAdapterMeta GetAdapterMeta(Type type, PropertyDescriptor descriptor);

		DictionaryAdapterMeta GetAdapterMeta(Type type, DictionaryAdapterMeta other);
	}
}
