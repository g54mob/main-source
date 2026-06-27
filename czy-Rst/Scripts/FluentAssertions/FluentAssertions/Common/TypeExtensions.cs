using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using FluentAssertions.Equivalency;
using Reflectify;

namespace FluentAssertions.Common
{
	internal static class TypeExtensions
	{
		private const BindingFlags PublicInstanceMembersFlag = BindingFlags.Instance | BindingFlags.Public;

		private const BindingFlags AllStaticAndInstanceMembersFlag = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		private static readonly ConcurrentDictionary<Type, bool> HasValueSemanticsCache = new ConcurrentDictionary<Type, bool>();

		private static readonly ConcurrentDictionary<Type, bool> TypeIsRecordCache = new ConcurrentDictionary<Type, bool>();

		public static bool IsDecoratedWith<TAttribute>(this Type type) where TAttribute : Attribute
		{
			return type.IsDefined(typeof(TAttribute), inherit: false);
		}

		public static bool IsDecoratedWith<TAttribute>(this MemberInfo type) where TAttribute : Attribute
		{
			return Attribute.IsDefined(type, typeof(TAttribute), inherit: false);
		}

		public static bool IsDecoratedWithOrInherit<TAttribute>(this Type type) where TAttribute : Attribute
		{
			return type.IsDefined(typeof(TAttribute), inherit: true);
		}

		public static bool IsDecoratedWithOrInherit<TAttribute>(this MemberInfo type) where TAttribute : Attribute
		{
			return Attribute.IsDefined(type, typeof(TAttribute), inherit: true);
		}

		public static bool IsDecoratedWith<TAttribute>(this Type type, Expression<Func<TAttribute, bool>> isMatchingAttributePredicate) where TAttribute : Attribute
		{
			return GetCustomAttributes(type, isMatchingAttributePredicate).Any();
		}

		public static bool IsDecoratedWith<TAttribute>(this MemberInfo type, Expression<Func<TAttribute, bool>> isMatchingAttributePredicate) where TAttribute : Attribute
		{
			return GetCustomAttributes(type, isMatchingAttributePredicate).Any();
		}

		public static bool IsDecoratedWithOrInherit<TAttribute>(this Type type, Expression<Func<TAttribute, bool>> isMatchingAttributePredicate) where TAttribute : Attribute
		{
			return GetCustomAttributes(type, isMatchingAttributePredicate, inherit: true).Any();
		}

		public static IEnumerable<TAttribute> GetMatchingAttributes<TAttribute>(this Type type) where TAttribute : Attribute
		{
			return type.GetCustomAttributes<TAttribute>();
		}

		public static IEnumerable<TAttribute> GetMatchingAttributes<TAttribute>(this Type type, Expression<Func<TAttribute, bool>> isMatchingAttributePredicate) where TAttribute : Attribute
		{
			return GetCustomAttributes(type, isMatchingAttributePredicate);
		}

		public static IEnumerable<TAttribute> GetMatchingOrInheritedAttributes<TAttribute>(this Type type) where TAttribute : Attribute
		{
			return type.GetCustomAttributes<TAttribute>(inherit: true);
		}

		public static IEnumerable<TAttribute> GetMatchingOrInheritedAttributes<TAttribute>(this Type type, Expression<Func<TAttribute, bool>> isMatchingAttributePredicate) where TAttribute : Attribute
		{
			return GetCustomAttributes(type, isMatchingAttributePredicate, inherit: true);
		}

		public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this MemberInfo type, bool inherit = false) where TAttribute : Attribute
		{
			return CustomAttributeExtensions.GetCustomAttributes<TAttribute>(type, inherit);
		}

		private static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(MemberInfo type, Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, bool inherit = false) where TAttribute : Attribute
		{
			Func<TAttribute, bool> predicate = isMatchingAttributePredicate.Compile();
			return type.GetCustomAttributes<TAttribute>(inherit).Where(predicate);
		}

		private static TAttribute[] GetCustomAttributes<TAttribute>(this Type type, bool inherit = false) where TAttribute : Attribute
		{
			return (TAttribute[])type.GetCustomAttributes(typeof(TAttribute), inherit);
		}

		private static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(Type type, Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, bool inherit = false) where TAttribute : Attribute
		{
			Func<TAttribute, bool> predicate = isMatchingAttributePredicate.Compile();
			return type.GetCustomAttributes<TAttribute>(inherit).Where(predicate);
		}

		public static bool IsEquivalentTo(this IMember property, IMember otherProperty)
		{
			if (property.DeclaringType.IsSameOrInherits(otherProperty.DeclaringType) || otherProperty.DeclaringType.IsSameOrInherits(property.DeclaringType))
			{
				return property.Expectation.Name == otherProperty.Expectation.Name;
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
				where t.IsGenericType && t.GetGenericTypeDefinition() == openGenericType
				select t).ToArray();
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

		public static PropertyInfo FindProperty(this Type type, string propertyName, MemberVisibility memberVisibility)
		{
			return Array.Find(type.GetProperties(memberVisibility.ToMemberKind()), (PropertyInfo p) => p.Name == propertyName || p.Name.EndsWith("." + propertyName, StringComparison.Ordinal));
		}

		public static FieldInfo FindField(this Type type, string fieldName, MemberVisibility memberVisibility)
		{
			return Array.Find(type.GetFields(memberVisibility.ToMemberKind()), (FieldInfo p) => p.Name == fieldName);
		}

		public static bool IsCSharpAbstract(this Type type)
		{
			if (type.IsAbstract)
			{
				return !type.IsSealed;
			}
			return false;
		}

		public static bool IsCSharpSealed(this Type type)
		{
			if (type.IsSealed)
			{
				return !type.IsAbstract;
			}
			return false;
		}

		public static bool IsCSharpStatic(this Type type)
		{
			if (type.IsSealed)
			{
				return type.IsAbstract;
			}
			return false;
		}

		public static MethodInfo GetMethod(this Type type, string methodName, IEnumerable<Type> parameterTypes)
		{
			return type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SingleOrDefault((MethodInfo m) => m.Name == methodName && (from p in m.GetParameters()
				select p.ParameterType).SequenceEqual(parameterTypes));
		}

		public static bool HasMethod(this Type type, string methodName, IEnumerable<Type> parameterTypes)
		{
			return (object)type.GetMethod(methodName, parameterTypes) != null;
		}

		public static MethodInfo GetParameterlessMethod(this Type type, string methodName)
		{
			return type.GetMethod(methodName, Enumerable.Empty<Type>());
		}

		public static PropertyInfo FindPropertyByName(this Type type, string propertyName)
		{
			return type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static bool HasExplicitlyImplementedProperty(this Type type, Type interfaceType, string propertyName)
		{
			bool num = type.HasParameterlessMethod(interfaceType.FullName + ".get_" + propertyName);
			bool flag = (object)type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SingleOrDefault((MethodInfo m) => m.Name == interfaceType.FullName + ".set_" + propertyName && m.GetParameters().Length == 1) != null;
			return num || flag;
		}

		private static bool HasParameterlessMethod(this Type type, string methodName)
		{
			return (object)type.GetParameterlessMethod(methodName) != null;
		}

		public static PropertyInfo GetIndexerByParameterTypes(this Type type, IEnumerable<Type> parameterTypes)
		{
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SingleOrDefault((PropertyInfo p) => p.IsIndexer() && (from i in p.GetIndexParameters()
				select i.ParameterType).SequenceEqual(parameterTypes));
		}

		public static bool IsIndexer(this PropertyInfo member)
		{
			return member.GetIndexParameters().Length != 0;
		}

		public static ConstructorInfo GetConstructor(this Type type, IEnumerable<Type> parameterTypes)
		{
			return type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SingleOrDefault((ConstructorInfo m) => (from p in m.GetParameters()
				select p.ParameterType).SequenceEqual(parameterTypes));
		}

		private static IEnumerable<MethodInfo> GetConversionOperators(this Type type, Type sourceType, Type targetType, Func<string, bool> predicate)
		{
			return type.GetMethods().Where(delegate(MethodInfo m)
			{
				if (m.IsPublic && m.IsStatic && m.IsSpecialName && m.ReturnType == targetType && predicate(m.Name))
				{
					ParameterInfo[] parameters = m.GetParameters();
					if (parameters != null && parameters.Length == 1)
					{
						return parameters[0].ParameterType == sourceType;
					}
				}
				return false;
			});
		}

		public static bool IsAssignableToOpenGeneric(this Type type, Type definition)
		{
			if (definition.IsInterface)
			{
				return type.IsImplementationOfOpenGeneric(definition);
			}
			if (!(type == definition))
			{
				return type.IsDerivedFromOpenGeneric(definition);
			}
			return true;
		}

		private static bool IsImplementationOfOpenGeneric(this Type type, Type definition)
		{
			if (type.IsInterface && type.IsGenericType && type.GetGenericTypeDefinition() == definition)
			{
				return true;
			}
			return type.GetInterfaces().Any((Type i) => i.IsGenericType && i.GetGenericTypeDefinition() == definition);
		}

		public static bool IsDerivedFromOpenGeneric(this Type type, Type definition)
		{
			if (type == definition)
			{
				return false;
			}
			Type type2 = type;
			while ((object)type2 != null)
			{
				if (type2.IsGenericType && type2.GetGenericTypeDefinition() == definition)
				{
					return true;
				}
				type2 = type2.BaseType;
			}
			return false;
		}

		public static bool IsUnderNamespace(this Type type, string @namespace)
		{
			if (!IsGlobalNamespace() && !IsExactNamespace())
			{
				return IsParentNamespace();
			}
			return true;
			bool IsExactNamespace()
			{
				if (IsNamespacePrefix())
				{
					return type.Namespace.Length == @namespace.Length;
				}
				return false;
			}
			bool IsGlobalNamespace()
			{
				return @namespace == null;
			}
			bool IsNamespacePrefix()
			{
				return type.Namespace?.StartsWith(@namespace, StringComparison.Ordinal) ?? false;
			}
			bool IsParentNamespace()
			{
				if (IsNamespacePrefix())
				{
					return type.Namespace[@namespace.Length] == '.';
				}
				return false;
			}
		}

		public static bool IsSameOrInherits(this Type actualType, Type expectedType)
		{
			if (!(actualType == expectedType))
			{
				return expectedType.IsAssignableFrom(actualType);
			}
			return true;
		}

		public static MethodInfo GetExplicitConversionOperator(this Type type, Type sourceType, Type targetType)
		{
			return type.GetConversionOperators(sourceType, targetType, (string name) => name == "op_Explicit").SingleOrDefault();
		}

		public static MethodInfo GetImplicitConversionOperator(this Type type, Type sourceType, Type targetType)
		{
			return type.GetConversionOperators(sourceType, targetType, (string name) => name == "op_Implicit").SingleOrDefault();
		}

		public static bool HasValueSemantics(this Type type)
		{
			return HasValueSemanticsCache.GetOrAdd(type, (Type t) => t.OverridesEquals() && !t.IsAnonymous() && !t.IsTuple() && !IsKeyValuePair(t));
		}

		private static bool IsTuple(this Type type)
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

		private static bool IsAnonymous(this Type type)
		{
			if (!SystemExtensions.Contains(type.FullName, "AnonymousType", StringComparison.Ordinal))
			{
				return false;
			}
			return type.IsDecoratedWith<CompilerGeneratedAttribute>();
		}

		public static bool IsRecord(this Type type)
		{
			return TypeIsRecordCache.GetOrAdd(type, (Type t) => t.IsRecordClass() || t.IsRecordStruct());
		}

		private static bool IsRecordClass(this Type type)
		{
			if ((object)type.GetMethod("<Clone>$", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public) != null)
			{
				PropertyInfo property = type.GetProperty("EqualityContract", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
				if ((object)property == null)
				{
					return false;
				}
				return property.GetMethod?.IsDecoratedWith<CompilerGeneratedAttribute>() == true;
			}
			return false;
		}

		private static bool IsRecordStruct(this Type type)
		{
			if (type.BaseType == typeof(ValueType) && (object)type.GetMethod("PrintMembers", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[1] { typeof(StringBuilder) }, null) != null)
			{
				return type.GetMethod("op_Equality", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public, null, new Type[2] { type, type }, null)?.IsDecoratedWith<CompilerGeneratedAttribute>() ?? false;
			}
			return false;
		}

		private static bool IsKeyValuePair(Type type)
		{
			if (type.IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(KeyValuePair<, >);
			}
			return false;
		}

		public static Type NullableOrActualType(this Type type)
		{
			if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				type = type.GetGenericArguments()[0];
			}
			return type;
		}
	}
}
