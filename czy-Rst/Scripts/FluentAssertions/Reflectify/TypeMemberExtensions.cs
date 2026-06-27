using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflectify
{
	internal static class TypeMemberExtensions
	{
		private static readonly ConcurrentDictionary<(Type Type, MemberKind Kind), Reflector> ReflectorCache = new ConcurrentDictionary<(Type, MemberKind), Reflector>();

		public static PropertyInfo[] GetProperties(this Type type, MemberKind kind)
		{
			return GetFor(type, kind).Properties;
		}

		public static PropertyInfo FindProperty(this Type type, string propertyName, MemberKind memberVisibility)
		{
			if ((propertyName == null || propertyName == "") ? true : false)
			{
				throw new ArgumentException("The property name cannot be null or empty", "propertyName");
			}
			return Array.Find(type.GetProperties(memberVisibility), (PropertyInfo p) => p.Name == propertyName || p.Name.EndsWith("." + propertyName, StringComparison.Ordinal));
		}

		public static FieldInfo[] GetFields(this Type type, MemberKind kind)
		{
			return GetFor(type, kind).Fields;
		}

		public static FieldInfo FindField(this Type type, string fieldName, MemberKind memberVisibility)
		{
			if ((fieldName == null || fieldName == "") ? true : false)
			{
				throw new ArgumentException("The field name cannot be null or empty", "fieldName");
			}
			return Array.Find(type.GetFields(memberVisibility), (FieldInfo p) => p.Name == fieldName);
		}

		public static MemberInfo[] GetMembers(this Type type, MemberKind kind)
		{
			return GetFor(type, kind).Members;
		}

		private static Reflector GetFor(Type typeToReflect, MemberKind kind)
		{
			return ReflectorCache.GetOrAdd((typeToReflect, kind), ((Type Type, MemberKind Kind) key) => new Reflector(key.Type, key.Kind));
		}

		public static MethodInfo FindMethod(this Type type, string methodName, MemberKind kind, params Type[] parameterTypes)
		{
			if ((methodName == null || methodName == "") ? true : false)
			{
				throw new ArgumentException("The method name cannot be null or empty", "methodName");
			}
			BindingFlags bindingAttr = kind.ToBindingFlags() | BindingFlags.Instance | BindingFlags.Static;
			return type.GetMethods(bindingAttr).SingleOrDefault((MethodInfo m) => m.Name == methodName && HasSameParameters(parameterTypes, m));
		}

		public static MethodInfo FindParameterlessMethod(this Type type, string methodName, MemberKind memberKind)
		{
			return type.FindMethod(methodName, memberKind);
		}

		private static bool HasSameParameters(Type[] parameterTypes, MethodInfo method)
		{
			if (parameterTypes.Length == 0)
			{
				return true;
			}
			return (from p in method.GetParameters()
				select p.ParameterType).SequenceEqual(parameterTypes);
		}

		public static bool HasMethod(this Type type, string methodName, MemberKind memberKind, params Type[] parameterTypes)
		{
			return (object)type.FindMethod(methodName, memberKind, parameterTypes) != null;
		}

		public static PropertyInfo FindIndexer(this Type type, MemberKind memberKind, params Type[] parameterTypes)
		{
			BindingFlags bindingAttr = memberKind.ToBindingFlags() | BindingFlags.Instance | BindingFlags.Static;
			return type.GetProperties(bindingAttr).SingleOrDefault((PropertyInfo p) => p.IsIndexer() && (from i in p.GetIndexParameters()
				select i.ParameterType).SequenceEqual(parameterTypes));
		}

		public static MethodInfo FindExplicitConversionOperator(this Type type, Type sourceType, Type targetType)
		{
			return type.GetConversionOperators(sourceType, targetType, (string name) => name == "op_Explicit").SingleOrDefault();
		}

		public static MethodInfo FindImplicitConversionOperator(this Type type, Type sourceType, Type targetType)
		{
			return type.GetConversionOperators(sourceType, targetType, (string name) => name == "op_Implicit").SingleOrDefault();
		}

		private static IEnumerable<MethodInfo> GetConversionOperators(this Type type, Type sourceType, Type targetType, Func<string, bool> predicate)
		{
			return type.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(delegate(MethodInfo m)
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
	}
}
