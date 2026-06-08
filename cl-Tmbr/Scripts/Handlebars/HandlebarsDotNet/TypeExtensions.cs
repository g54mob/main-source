using System;
using System.Reflection;

namespace HandlebarsDotNet
{
	internal static class TypeExtensions
	{
		public static bool IsAssignableToGenericType(this Type givenType, Type genericType, out Type resolvedType)
		{
			while (true)
			{
				Type[] interfaces = givenType.GetInterfaces();
				for (int i = 0; i < interfaces.Length; i++)
				{
					resolvedType = interfaces[i];
					if (resolvedType.GetTypeInfo().IsGenericType && resolvedType.GetGenericTypeDefinition() == genericType)
					{
						return true;
					}
				}
				if (givenType.GetTypeInfo().IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
				{
					resolvedType = givenType;
					return true;
				}
				Type baseType = givenType.GetTypeInfo().BaseType;
				if (baseType == null)
				{
					break;
				}
				givenType = baseType;
			}
			resolvedType = null;
			return false;
		}
	}
}
