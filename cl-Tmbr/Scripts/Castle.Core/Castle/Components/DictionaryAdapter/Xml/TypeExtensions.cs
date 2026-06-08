using System;
using System.Linq;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class TypeExtensions
	{
		public static Type NonNullable(this Type type)
		{
			if (!type.IsGenericType || !(type.GetGenericTypeDefinition() == typeof(Nullable<>)))
			{
				return type;
			}
			return type.GetGenericArguments()[0];
		}

		public static Type GetCollectionItemType(this Type type)
		{
			if (type.IsArray)
			{
				return type.GetElementType();
			}
			if (type.IsGenericType)
			{
				return type.GetGenericArguments().Single();
			}
			throw Error.NotCollectionType("type");
		}

		public static Type GetComponentType(this object obj)
		{
			if (obj is IDictionaryAdapter dictionaryAdapter)
			{
				return dictionaryAdapter.Meta.Type;
			}
			return obj.GetType();
		}

		internal static bool IsCustomSerializable(this Type type)
		{
			return typeof(IXmlSerializable).IsAssignableFrom(type);
		}
	}
}
