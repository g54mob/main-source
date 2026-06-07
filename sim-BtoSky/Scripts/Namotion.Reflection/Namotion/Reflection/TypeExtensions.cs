using System;
using System.Linq;
using System.Reflection;

namespace Namotion.Reflection
{
	public static class TypeExtensions
	{
		public static bool IsAssignableToTypeName(this CachedType type, string typeName, TypeNameStyle typeNameStyle)
		{
			return type.OriginalType.IsAssignableToTypeName(typeName, typeNameStyle);
		}

		public static bool IsAssignableToTypeName(this Type type, string typeName, TypeNameStyle typeNameStyle)
		{
			if (typeNameStyle == TypeNameStyle.Name && type.Name == typeName)
			{
				return true;
			}
			if (typeNameStyle == TypeNameStyle.FullName && type.FullName == typeName)
			{
				return true;
			}
			if (type.InheritsFromTypeName(typeName, typeNameStyle))
			{
				return true;
			}
			Type[] interfaces = type.GetInterfaces();
			foreach (Type type2 in interfaces)
			{
				if ((typeNameStyle == TypeNameStyle.Name && type2.Name == typeName) || (typeNameStyle == TypeNameStyle.FullName && type2.FullName == typeName))
				{
					return true;
				}
			}
			return false;
		}

		public static bool InheritsFromTypeName(this Type type, string typeName, TypeNameStyle typeNameStyle)
		{
			Type baseType = type.GetTypeInfo().BaseType;
			while (baseType != null)
			{
				if (typeNameStyle == TypeNameStyle.Name && baseType.Name == typeName)
				{
					return true;
				}
				if (typeNameStyle == TypeNameStyle.FullName && baseType.FullName == typeName)
				{
					return true;
				}
				baseType = baseType.GetTypeInfo().BaseType;
			}
			return false;
		}

		public static Type? GetEnumerableItemType(this Type type)
		{
			Type elementType = type.GetElementType();
			if (elementType != null)
			{
				return elementType;
			}
			ContextualMethodInfo contextualMethodInfo = type.ToContextualType().Methods.SingleOrDefault((ContextualMethodInfo m) => m.Name == "GetEnumerator");
			if (contextualMethodInfo != null)
			{
				Type[] genericTypeArgumentsOfTypeOrBaseTypes = type.GetGenericTypeArgumentsOfTypeOrBaseTypes();
				if (genericTypeArgumentsOfTypeOrBaseTypes != null && genericTypeArgumentsOfTypeOrBaseTypes.Length == 1)
				{
					return genericTypeArgumentsOfTypeOrBaseTypes[0];
				}
				ContextualParameterInfo returnParameter = contextualMethodInfo.ReturnParameter;
				if (returnParameter != null && returnParameter.GenericArguments.Length == 1)
				{
					return returnParameter.GenericArguments[0];
				}
			}
			return null;
		}

		private static Type[] GetGenericTypeArgumentsOfTypeOrBaseTypes(this Type type)
		{
			Type[] genericTypeArguments = type.GenericTypeArguments;
			while (type != null && type != typeof(object) && genericTypeArguments.Length == 0)
			{
				type = type.GetTypeInfo().BaseType;
				if (type != null)
				{
					genericTypeArguments = type.GenericTypeArguments;
				}
			}
			return genericTypeArguments;
		}

		public static string GetDisplayName(this Type type)
		{
			CachedType cachedType = type.ToCachedType();
			if (cachedType.Type.IsConstructedGenericType)
			{
				return GetName(cachedType).FirstToken('`') + "Of" + string.Join("And", cachedType.GenericArguments.Select((CachedType a) => a.OriginalType.GetDisplayName()));
			}
			return GetName(cachedType);
		}

		private static string GetName(CachedType cType)
		{
			if (!(cType.TypeName == "Int16"))
			{
				if (!(cType.TypeName == "Int32"))
				{
					if (!(cType.TypeName == "Int64"))
					{
						return GetNullableDisplayName(cType, cType.TypeName);
					}
					return GetNullableDisplayName(cType, "Long");
				}
				return GetNullableDisplayName(cType, "Integer");
			}
			return GetNullableDisplayName(cType, "Short");
		}

		private static string GetNullableDisplayName(CachedType type, string actual)
		{
			return (type.IsNullableType ? "Nullable" : "") + actual;
		}
	}
}
