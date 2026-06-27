using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Reflectify
{
	internal static class TypeMetaDataExtensions
	{
		public static bool IsDerivedFromOpenGeneric(this Type type, Type openGenericType)
		{
			if (type == openGenericType)
			{
				return false;
			}
			Type type2 = type;
			while ((object)type2 != null)
			{
				if (type2.IsGenericType && type2.GetGenericTypeDefinition() == openGenericType)
				{
					return true;
				}
				type2 = type2.BaseType;
			}
			return false;
		}

		public static Type[] GetClosedGenericInterfaces(this Type type, Type openGenericType)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == openGenericType)
			{
				return new Type[1] { type };
			}
			return (from t in type.GetInterfaces()
				where t.GetInterfaces().Any((Type x) => x.IsGenericType && x.GetGenericTypeDefinition() == openGenericType)
				select t).ToArray();
		}

		public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
		{
			return type.IsDefined(typeof(TAttribute), inherit: false);
		}

		public static bool HasAttribute<TAttribute>(this Type type, Func<TAttribute, bool> predicate) where TAttribute : Attribute
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return type.GetCustomAttributes<TAttribute>(inherit: false).Any(predicate);
		}

		public static bool HasAttributeInHierarchy<TAttribute>(this Type type) where TAttribute : Attribute
		{
			return type.IsDefined(typeof(TAttribute), inherit: true);
		}

		public static bool HasAttributeInHierarchy<TAttribute>(this Type type, Func<TAttribute, bool> predicate) where TAttribute : Attribute
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return type.GetCustomAttributes<TAttribute>(inherit: true).Any(predicate);
		}

		public static TAttribute[] GetMatchingAttributes<TAttribute>(this Type type) where TAttribute : Attribute
		{
			return (TAttribute[])type.GetCustomAttributes<TAttribute>(inherit: true);
		}

		public static TAttribute[] GetMatchingAttributes<TAttribute>(this Type type, Func<TAttribute, bool> predicate) where TAttribute : Attribute
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return type.GetCustomAttributes<TAttribute>(inherit: true).Where(predicate).ToArray();
		}

		public static bool OverridesEquals(this Type type)
		{
			MethodInfo method = type.GetMethod("Equals", new Type[1] { typeof(object) });
			if ((object)method != null)
			{
				return method.GetBaseDefinition().DeclaringType != method.DeclaringType;
			}
			return false;
		}

		public static bool IsSameOrInherits(this Type actualType, Type expectedType)
		{
			if (!(actualType == expectedType) && !expectedType.IsAssignableFrom(actualType))
			{
				Type baseType = actualType.BaseType;
				if ((object)baseType != null && baseType.IsGenericType)
				{
					return actualType.BaseType.GetGenericTypeDefinition() == expectedType;
				}
				return false;
			}
			return true;
		}

		public static bool IsCompilerGenerated(this Type type)
		{
			if (!type.IsRecord() && !type.IsAnonymous())
			{
				return type.IsTuple();
			}
			return true;
		}

		public static bool HasFriendlyName(this Type type)
		{
			if (!type.IsAnonymous())
			{
				return !type.IsTuple();
			}
			return false;
		}

		public static bool IsTuple(this Type type)
		{
			if (!type.IsGenericType)
			{
				return false;
			}
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (!(genericTypeDefinition == typeof(ValueTuple<>)) && !(genericTypeDefinition == typeof(ValueTuple<, >)) && !(genericTypeDefinition == typeof(ValueTuple<, , >)) && !(genericTypeDefinition == typeof(ValueTuple<, , , >)) && !(genericTypeDefinition == typeof(ValueTuple<, , , , >)) && !(genericTypeDefinition == typeof(ValueTuple<, , , , , >)) && !(genericTypeDefinition == typeof(ValueTuple<, , , , , , >)) && (!(genericTypeDefinition == typeof(ValueTuple<, , , , , , , >)) || !type.GetGenericArguments()[7].IsTuple()) && !(genericTypeDefinition == typeof(Tuple<>)) && !(genericTypeDefinition == typeof(Tuple<, >)) && !(genericTypeDefinition == typeof(Tuple<, , >)) && !(genericTypeDefinition == typeof(Tuple<, , , >)) && !(genericTypeDefinition == typeof(Tuple<, , , , >)) && !(genericTypeDefinition == typeof(Tuple<, , , , , >)) && !(genericTypeDefinition == typeof(Tuple<, , , , , , >)))
			{
				if (genericTypeDefinition == typeof(Tuple<, , , , , , , >))
				{
					return type.GetGenericArguments()[7].IsTuple();
				}
				return false;
			}
			return true;
		}

		public static bool IsAnonymous(this Type type)
		{
			if (!type.FullName.Contains("AnonymousType"))
			{
				return false;
			}
			return type.HasAttribute<CompilerGeneratedAttribute>();
		}

		public static bool IsRecord(this Type type)
		{
			if (!type.IsRecordClass())
			{
				return type.IsRecordStruct();
			}
			return true;
		}

		public static bool IsRecordClass(this Type type)
		{
			if ((object)type.GetMethod("<Clone>$", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public) != null)
			{
				PropertyInfo property = type.GetProperty("EqualityContract", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
				if ((object)property == null)
				{
					return false;
				}
				return property.GetMethod?.HasAttribute<CompilerGeneratedAttribute>() == true;
			}
			return false;
		}

		public static bool IsRecordStruct(this Type type)
		{
			if (type.BaseType == typeof(ValueType) && (object)type.GetMethod("PrintMembers", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[1] { typeof(StringBuilder) }, null) != null)
			{
				return type.GetMethod("op_Equality", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public, null, new Type[2] { type, type }, null)?.HasAttribute<CompilerGeneratedAttribute>() ?? false;
			}
			return false;
		}

		public static bool IsKeyValuePair(this Type type)
		{
			if (type.IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(KeyValuePair<, >);
			}
			return false;
		}
	}
}
