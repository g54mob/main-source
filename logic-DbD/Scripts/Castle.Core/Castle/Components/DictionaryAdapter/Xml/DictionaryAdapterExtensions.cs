using System;
using System.Collections;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class DictionaryAdapterExtensions
	{
		private const string XmlAccessorKey = "XmlAccessor";

		private const string XmlMetaKey = "XmlMeta";

		private const string XmlTypeKey = "XmlType";

		public static object CreateChildAdapter(this IDictionaryAdapter parent, Type type, XmlAdapter adapter)
		{
			return parent.CreateChildAdapter(type, adapter, null);
		}

		public static object CreateChildAdapter(this IDictionaryAdapter parent, Type type, XmlAdapter adapter, IDictionary dictionary)
		{
			if (dictionary == null)
			{
				dictionary = new Hashtable();
			}
			PropertyDescriptor propertyDescriptor = parent.Meta.CreateDescriptor();
			parent.This.Descriptor.CopyBehaviors(propertyDescriptor);
			propertyDescriptor.AddBehavior(adapter);
			return parent.This.Factory.GetAdapter(type, dictionary, propertyDescriptor);
		}

		public static bool HasAccessor(this PropertyDescriptor property)
		{
			return property.ExtendedProperties.Contains("XmlAccessor");
		}

		public static XmlAccessor GetAccessor(this PropertyDescriptor property)
		{
			return (XmlAccessor)property.ExtendedProperties["XmlAccessor"];
		}

		public static void SetAccessor(this PropertyDescriptor property, XmlAccessor accessor)
		{
			property.ExtendedProperties["XmlAccessor"] = accessor;
		}

		public static bool HasXmlMeta(this DictionaryAdapterMeta meta)
		{
			return meta.ExtendedProperties.Contains("XmlMeta");
		}

		public static XmlMetadata GetXmlMeta(this DictionaryAdapterMeta meta)
		{
			return (XmlMetadata)meta.ExtendedProperties["XmlMeta"];
		}

		public static void SetXmlMeta(this DictionaryAdapterMeta meta, XmlMetadata xmlMeta)
		{
			meta.ExtendedProperties["XmlMeta"] = xmlMeta;
		}

		public static bool HasXmlType(this DictionaryAdapterMeta meta)
		{
			return meta.ExtendedProperties.Contains("XmlType");
		}

		public static string GetXmlType(this DictionaryAdapterMeta meta)
		{
			return (string)meta.ExtendedProperties["XmlType"];
		}

		public static void SetXmlType(this DictionaryAdapterMeta meta, string value)
		{
			meta.ExtendedProperties["XmlType"] = value;
		}
	}
}
