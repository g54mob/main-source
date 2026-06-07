using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ParadoxNotion
{
	public static class ReflectionTools
	{
		public enum MethodType
		{
			Normal = 0,
			PropertyAccessor = 1,
			Event = 2,
			Operator = 3
		}

		[CompilerGenerated]
		private sealed class _003CRTGetAttributesRecursive_003Ed__97<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Type type;

			public Type _003C_003E3__type;

			private Type _003Ccurrent_003E5__2;

			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(T);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRTGetAttributesRecursive_003Ed__97(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public const BindingFlags FLAGS_ALL = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

		public const BindingFlags FLAGS_ALL_DECLARED = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		private static Assembly[] _loadedAssemblies;

		private static Type[] _allTypes;

		private static object[] _tempArgs;

		private static Dictionary<string, Type> _typesMap;

		private static Dictionary<Type, Type[]> _subTypesMap;

		private static Dictionary<MethodBase, MethodType> _methodSpecialType;

		private static Dictionary<Type, string> _typeFriendlyName;

		private static Dictionary<Type, string> _typeFriendlyNameCompileSafe;

		private static Dictionary<MethodBase, string> _methodSignatures;

		private static Dictionary<Type, ConstructorInfo[]> _typeConstructors;

		private static Dictionary<Type, MethodInfo[]> _typeMethods;

		private static Dictionary<Type, FieldInfo[]> _typeFields;

		private static Dictionary<Type, PropertyInfo[]> _typeProperties;

		private static Dictionary<Type, EventInfo[]> _typeEvents;

		private static Dictionary<MemberInfo, object[]> _memberAttributes;

		private static Dictionary<MemberInfo, bool> _obsoleteCache;

		private static Dictionary<Type, MethodInfo[]> _typeExtensions;

		private static Dictionary<Type, Type[]> _genericArgsTypeCache;

		private static Dictionary<MethodInfo, Type[]> _genericArgsMathodCache;

		public static readonly Dictionary<string, string> op_FriendlyNamesLong;

		public static readonly Dictionary<string, string> op_FriendlyNamesShort;

		public static readonly Dictionary<string, string> op_CSharpAliases;

		public const string METHOD_SPECIAL_NAME_GET = "get_";

		public const string METHOD_SPECIAL_NAME_SET = "set_";

		public const string METHOD_SPECIAL_NAME_ADD = "add_";

		public const string METHOD_SPECIAL_NAME_REMOVE = "remove_";

		public const string METHOD_SPECIAL_NAME_OP = "op_";

		private static Assembly[] loadedAssemblies => null;

		static ReflectionTools()
		{
		}

		public static void FlushMem()
		{
		}

		public static Type GetType(string typeFullName)
		{
			return null;
		}

		public static Type GetType(string typeFullName, Type fallbackAssignable)
		{
			return null;
		}

		public static Type GetType(string typeFullName, bool fallbackNoNamespace = false, Type fallbackAssignable = null)
		{
			return null;
		}

		private static Type GetTypeDirect(string typeFullName)
		{
			return null;
		}

		private static Type TryResolveGenericType(string typeFullName, bool fallbackNoNamespace = false, Type fallbackAssignable = null)
		{
			return null;
		}

		private static Type TryResolveDeserializeFromAttribute(string typeName)
		{
			return null;
		}

		private static Type TryResolveWithoutNamespace(string typeName, Type fallbackAssignable = null)
		{
			return null;
		}

		public static Type[] GetAllTypes(bool includeObsolete)
		{
			return null;
		}

		public static Type[] GetImplementationsOf(Type baseType)
		{
			return null;
		}

		public static object[] SingleTempArgsArray(object arg)
		{
			return null;
		}

		public static MethodType GetMethodSpecialType(this MethodBase method)
		{
			return default(MethodType);
		}

		public static string FriendlyName(this Type t, bool compileSafe = false)
		{
			return null;
		}

		public static string FriendlyName(this MemberInfo info)
		{
			return null;
		}

		public static string FriendlyName(this MethodBase method)
		{
			return null;
		}

		public static string FriendlyName(this MethodBase method, out MethodType specialNameType)
		{
			specialNameType = default(MethodType);
			return null;
		}

		public static string SignatureName(this MethodBase method)
		{
			return null;
		}

		public static string FriendlyTypeName(string fullName)
		{
			return null;
		}

		public static Type RTReflectedOrDeclaredType(this MemberInfo member)
		{
			return null;
		}

		public static bool RTIsAssignableFrom(this Type type, Type other)
		{
			return false;
		}

		public static bool RTIsAssignableTo(this Type type, Type other)
		{
			return false;
		}

		public static bool RTIsAbstract(this Type type)
		{
			return false;
		}

		public static bool RTIsValueType(this Type type)
		{
			return false;
		}

		public static bool RTIsArray(this Type type)
		{
			return false;
		}

		public static bool RTIsInterface(this Type type)
		{
			return false;
		}

		public static bool RTIsSubclassOf(this Type type, Type other)
		{
			return false;
		}

		public static bool RTIsGenericParameter(this Type type)
		{
			return false;
		}

		public static bool RTIsGenericType(this Type type)
		{
			return false;
		}

		public static MethodInfo RTGetGetMethod(this PropertyInfo prop)
		{
			return null;
		}

		public static MethodInfo RTGetSetMethod(this PropertyInfo prop)
		{
			return null;
		}

		public static MethodInfo RTGetDelegateMethodInfo(this Delegate del)
		{
			return null;
		}

		public static Type RTMakeGenericType(this Type type, params Type[] typeArgs)
		{
			return null;
		}

		public static Type[] RTGetEmptyTypes()
		{
			return null;
		}

		public static Type RTGetElementType(this Type type)
		{
			return null;
		}

		public static bool RTIsByRef(this Type type)
		{
			return false;
		}

		public static Type[] RTGetGenericArguments(this Type type)
		{
			return null;
		}

		public static Type[] RTGetGenericArguments(this MethodInfo method)
		{
			return null;
		}

		public static object CreateObject(this Type type)
		{
			return null;
		}

		public static object CreateObjectUninitialized(this Type type)
		{
			return null;
		}

		public static ConstructorInfo RTGetDefaultConstructor(this Type type)
		{
			return null;
		}

		public static ConstructorInfo RTGetConstructor(this Type type, Type[] paramTypes)
		{
			return null;
		}

		private static bool MemberResolvedFromDeserializeAttribute(MemberInfo member, string targetName)
		{
			return false;
		}

		public static MethodInfo RTGetMethod(this Type type, string name)
		{
			return null;
		}

		public static MethodInfo RTGetMethod(this Type type, string name, Type[] paramTypes, Type returnType = null, Type[] genericArgumentTypes = null)
		{
			return null;
		}

		public static FieldInfo RTGetField(this Type type, string name, bool includePrivateBase = false)
		{
			return null;
		}

		public static PropertyInfo RTGetProperty(this Type type, string name)
		{
			return null;
		}

		public static MemberInfo RTGetFieldOrProp(this Type type, string name)
		{
			return null;
		}

		public static EventInfo RTGetEvent(this Type type, string name)
		{
			return null;
		}

		public static object RTGetFieldOrPropValue(this MemberInfo member, object instance, int index = -1)
		{
			return null;
		}

		public static void RTSetFieldOrPropValue(this MemberInfo member, object instance, object value, int index = -1)
		{
		}

		public static ConstructorInfo[] RTGetConstructors(this Type type)
		{
			return null;
		}

		public static MethodInfo[] RTGetMethods(this Type type)
		{
			return null;
		}

		public static FieldInfo[] RTGetFields(this Type type)
		{
			return null;
		}

		public static PropertyInfo[] RTGetProperties(this Type type)
		{
			return null;
		}

		public static EventInfo[] RTGetEvents(this Type type)
		{
			return null;
		}

		public static bool RTIsDefined<T>(this Type type, bool inherited)
		{
			return false;
		}

		public static bool RTIsDefined(this Type type, Type attributeType, bool inherited)
		{
			return false;
		}

		public static T RTGetAttribute<T>(this Type type, bool inherited)
		{
			return default(T);
		}

		public static Attribute RTGetAttribute(this Type type, Type attributeType, bool inherited)
		{
			return null;
		}

		public static object[] RTGetAllAttributes(this MemberInfo member)
		{
			return null;
		}

		public static bool RTIsDefined<T>(this MemberInfo member, bool inherited)
		{
			return false;
		}

		public static bool RTIsDefined(this MemberInfo member, Type attributeType, bool inherited)
		{
			return false;
		}

		public static T RTGetAttribute<T>(this MemberInfo member, bool inherited)
		{
			return default(T);
		}

		public static Attribute RTGetAttribute(this MemberInfo member, Type attributeType, bool inherited)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRTGetAttributesRecursive_003Ed__97<>))]
		public static IEnumerable<T> RTGetAttributesRecursive<T>(this Type type)
		{
			return null;
		}

		public static ParameterInfo[] RTGetDelegateTypeParameters(this Type delegateType)
		{
			return null;
		}

		public static T RTCreateDelegate<T>(this MethodInfo method, object instance)
		{
			return default(T);
		}

		public static Delegate RTCreateDelegate(this MethodInfo method, Type type, object instance)
		{
			return null;
		}

		public static Delegate ConvertDelegate(Delegate originalDelegate, Type targetDelegateType)
		{
			return null;
		}

		public static bool IsReadOnly(this FieldInfo field)
		{
			return false;
		}

		public static bool IsConstant(this FieldInfo field)
		{
			return false;
		}

		public static bool IsStatic(this EventInfo info)
		{
			return false;
		}

		public static bool IsStatic(this PropertyInfo info)
		{
			return false;
		}

		public static bool IsParams(this ParameterInfo parameter, ParameterInfo[] parameters)
		{
			return false;
		}

		public static bool IsObsolete(this MemberInfo member, bool inherited = true)
		{
			return false;
		}

		public static PropertyInfo GetBaseDefinition(this PropertyInfo propertyInfo)
		{
			return null;
		}

		public static FieldInfo GetBaseDefinition(this FieldInfo fieldInfo)
		{
			return null;
		}

		public static MethodInfo[] GetExtensionMethods(this Type targetType)
		{
			return null;
		}

		public static bool IsExtensionMethod(this MethodInfo method)
		{
			return false;
		}

		public static bool IsPropertyAccessor(this MethodInfo method)
		{
			return false;
		}

		public static bool IsIndexerProperty(this PropertyInfo property)
		{
			return false;
		}

		public static bool IsAutoProperty(this PropertyInfo property)
		{
			return false;
		}

		public static PropertyInfo GetAccessorProperty(this MethodInfo method)
		{
			return null;
		}

		public static bool IsEnumerableCollection(this Type type)
		{
			return false;
		}

		public static Type GetEnumerableElementType(this Type type)
		{
			return null;
		}

		public static Type GetSingleGenericArgument(this Type type)
		{
			return null;
		}

		public static Type GetFirstGenericParameterConstraintType(this Type type)
		{
			return null;
		}

		public static Type GetFirstGenericParameterConstraintType(this MethodInfo method)
		{
			return null;
		}

		public static bool TryMakeGeneric(this Type def, Type argType, out Type result)
		{
			result = null;
			return false;
		}

		public static bool TryMakeGeneric(this MethodInfo def, Type argType, out MethodInfo result)
		{
			result = null;
			return false;
		}

		public static Array Resize(this Array array, int newSize)
		{
			return null;
		}

		public static bool TryConvert(Type fromType, Type toType, out UnaryExpression exp)
		{
			exp = null;
			return false;
		}

		public static void DigFields(object root, Predicate<FieldInfo> move, Action<object> push, Action<object> pop)
		{
		}

		public static Func<T, TResult> GetFieldGetter<T, TResult>(FieldInfo info)
		{
			return null;
		}

		public static Action<T, TValue> GetFieldSetter<T, TValue>(FieldInfo info)
		{
			return null;
		}
	}
}
