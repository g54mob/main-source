using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Castle.Core.Internal
{
	public static class AttributesUtil
	{
		private static readonly AttributeUsageAttribute DefaultAttributeUsage = new AttributeUsageAttribute(AttributeTargets.All);

		public static T GetAttribute<T>(this Type type) where T : Attribute
		{
			return type.GetAttributes<T>().FirstOrDefault();
		}

		public static IEnumerable<T> GetAttributes<T>(this Type type) where T : Attribute
		{
			object[] customAttributes = type.GetCustomAttributes(typeof(T), inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				yield return (T)customAttributes[i];
			}
		}

		public static T GetAttribute<T>(this MemberInfo member) where T : Attribute
		{
			return member.GetAttributes<T>().FirstOrDefault();
		}

		public static IEnumerable<T> GetAttributes<T>(this MemberInfo member) where T : Attribute
		{
			object[] customAttributes = member.GetCustomAttributes(typeof(T), inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				yield return (T)customAttributes[i];
			}
		}

		public static T GetTypeAttribute<T>(this Type type) where T : Attribute
		{
			T val = type.GetAttribute<T>();
			if (val == null)
			{
				Type[] interfaces = type.GetInterfaces();
				for (int i = 0; i < interfaces.Length; i++)
				{
					val = interfaces[i].GetTypeAttribute<T>();
					if (val != null)
					{
						break;
					}
				}
			}
			return val;
		}

		public static T[] GetTypeAttributes<T>(Type type) where T : Attribute
		{
			T[] array = type.GetAttributes<T>().ToArray();
			if (array.Length == 0)
			{
				Type[] interfaces = type.GetInterfaces();
				for (int i = 0; i < interfaces.Length; i++)
				{
					array = GetTypeAttributes<T>(interfaces[i]);
					if (array.Length != 0)
					{
						break;
					}
				}
			}
			return array;
		}

		public static AttributeUsageAttribute GetAttributeUsage(this Type attributeType)
		{
			AttributeUsageAttribute[] array = attributeType.GetCustomAttributes<AttributeUsageAttribute>(inherit: true).ToArray();
			if (array.Length == 0)
			{
				return DefaultAttributeUsage;
			}
			return array[0];
		}

		public static Type GetTypeConverter(MemberInfo member)
		{
			TypeConverterAttribute attribute = member.GetAttribute<TypeConverterAttribute>();
			if (attribute != null)
			{
				return Type.GetType(attribute.ConverterTypeName);
			}
			return null;
		}
	}
}
