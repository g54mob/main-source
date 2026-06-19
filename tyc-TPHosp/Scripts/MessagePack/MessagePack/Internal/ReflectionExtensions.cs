using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MessagePack.Internal
{
	internal static class ReflectionExtensions
	{
		public static bool IsNullable(this TypeInfo type)
		{
			if (type.IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(Nullable<>);
			}
			return false;
		}

		public static bool IsPublic(this TypeInfo type)
		{
			return type.IsPublic;
		}

		public static bool IsAnonymous(this TypeInfo type)
		{
			if (type.GetCustomAttribute<CompilerGeneratedAttribute>() != null && type.IsGenericType && type.Name.Contains("AnonymousType") && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$")))
			{
				return (type.Attributes & TypeAttributes.NotPublic) == 0;
			}
			return false;
		}

		public static bool IsIndexer(this PropertyInfo propertyInfo)
		{
			return propertyInfo.GetIndexParameters().Length != 0;
		}
	}
}
