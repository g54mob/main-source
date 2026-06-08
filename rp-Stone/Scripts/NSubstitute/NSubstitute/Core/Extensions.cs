using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	internal static class Extensions
	{
		public static bool IsCompatibleWith(this object? instance, Type type)
		{
			Type type2 = (type.IsByRef ? type.GetElementType() : type);
			if (instance != null)
			{
				return type2.IsInstanceOfType(instance);
			}
			return TypeCanBeNull(type2);
		}

		public static string Join(this IEnumerable<string> strings, string separator)
		{
			return string.Join(separator, strings);
		}

		public static bool IsDelegate(this Type type)
		{
			return type.GetTypeInfo().IsSubclassOf(typeof(MulticastDelegate));
		}

		public static MethodInfo GetInvokeMethod(this Type type)
		{
			return type.GetMethod("Invoke") ?? throw new SubstituteInternalException("Expected delegate type");
		}

		private static bool TypeCanBeNull(Type type)
		{
			if (type.GetTypeInfo().IsValueType)
			{
				return Nullable.GetUnderlyingType(type) != null;
			}
			return true;
		}

		public static string GetNonMangledTypeName(this Type type)
		{
			if (!type.GetTypeInfo().IsGenericType && !type.IsNested)
			{
				return type.Name;
			}
			Type[] genericTypeArguments = type.GetGenericArguments();
			int alreadyHandledGenericArgumentsCount = 0;
			StringBuilder resultTypeName = new StringBuilder();
			AppendTypeNameRecursively(type);
			return resultTypeName.ToString();
			void AppendTypeNameRecursively(Type currentType)
			{
				Type declaringType = currentType.DeclaringType;
				if (declaringType != null)
				{
					AppendTypeNameRecursively(declaringType);
					resultTypeName.Append('+');
				}
				resultTypeName.Append(GetTypeNameWithoutGenericArity(currentType));
				string[] array = (from t in genericTypeArguments.Take(currentType.GetGenericArguments().Length).Skip(alreadyHandledGenericArgumentsCount)
					select t.GetNonMangledTypeName()).ToArray();
				if (array.Length != 0)
				{
					alreadyHandledGenericArgumentsCount += array.Length;
					resultTypeName.Append('<');
					resultTypeName.Append(array.Join(", "));
					resultTypeName.Append('>');
				}
			}
			static string GetTypeNameWithoutGenericArity(Type type2)
			{
				string name = type2.Name;
				int num = name.IndexOf('`');
				if (num <= -1)
				{
					return name;
				}
				return name.Substring(0, num);
			}
		}

		public static T[] AsArray<T>(this IEnumerable<T> sequence)
		{
			if (!(sequence is T[] result))
			{
				return sequence.ToArray();
			}
			return result;
		}
	}
}
