using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Namotion.Reflection
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> GetAssignableToTypeName<T>(this IEnumerable<T> objects, string typeName, TypeNameStyle typeNameStyle = TypeNameStyle.FullName)
		{
			foreach (T @object in objects)
			{
				if (@object.GetType().IsAssignableToTypeName(typeName, typeNameStyle))
				{
					yield return @object;
				}
			}
		}

		public static T? FirstAssignableToTypeNameOrDefault<T>(this IEnumerable<T>? objects, string typeName, TypeNameStyle typeNameStyle = TypeNameStyle.FullName)
		{
			if (objects is T[] array)
			{
				T[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					T result = array2[i];
					if (result.GetType().IsAssignableToTypeName(typeName, typeNameStyle))
					{
						return result;
					}
				}
			}
			else if (objects != null)
			{
				foreach (T @object in objects)
				{
					if (@object.GetType().IsAssignableToTypeName(typeName, typeNameStyle))
					{
						return @object;
					}
				}
			}
			return default(T);
		}

		public static Type GetCommonBaseType(this IEnumerable<Type> types)
		{
			types = types.ToList();
			Type baseType = types.First();
			while (baseType != typeof(object) && baseType != null)
			{
				if (types.All((Type t) => baseType.GetTypeInfo().IsAssignableFrom(t.GetTypeInfo())))
				{
					return baseType;
				}
				baseType = baseType.GetTypeInfo().BaseType;
			}
			return typeof(object);
		}

		internal static T? GetSingleOrDefault<T>(this Attribute[] attributes)
		{
			T val = default(T);
			for (int i = 0; i < attributes.Length; i++)
			{
				if (attributes[i] is T val2)
				{
					if (val != null)
					{
						ThrowInvalidOperation();
					}
					val = val2;
				}
			}
			return val;
			static void ThrowInvalidOperation()
			{
				throw new InvalidOperationException("Found more than one element");
			}
		}
	}
}
