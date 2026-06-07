using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Coherence.Toolkit
{
	internal static class TypeUtils
	{
		private class TypeData
		{
			public SchemaType schemaType;

			public Type bindingType;

			public string schemaComponentFieldName;
		}

		private static Type[] obscuredTypes;

		private static readonly Dictionary<SchemaType, TypeData> typeDataList;

		private static readonly Dictionary<Type, TypeData> typeHash;

		private static readonly Dictionary<Type, string> niceTypeHash;

		private static readonly Dictionary<string, Type> schemaTypeToCSharp;

		private static readonly Dictionary<SchemaType, int> schemaTypeToFieldSize;

		private static readonly Dictionary<string, Field.Type> schemaTypeToInputType;

		private static readonly Dictionary<Field.Type, SchemaType> inputTypeToSchemaType;

		private static Dictionary<Type, bool> nonBindableTypeResultCache;

		private static readonly Dictionary<string, Type> memoizedTypeCache;

		private static readonly Regex oldValueParamRegex;

		private static readonly Regex newValueParamRegex;

		private static Dictionary<string, string> tidyAssemblyTypeNames;

		internal static readonly string CommandArgsPrefix;

		internal static readonly string CommandArgsSuffix;

		public static int GetFieldOffsetForSchemaType(SchemaType type)
		{
			return 0;
		}

		public static Type GetCSharpTypeForSchemaType(string type)
		{
			return null;
		}

		public static Field.Type GetInputTypeForSchemaType(string type)
		{
			return default(Field.Type);
		}

		public static SchemaType GetSchemaTypeForInputType(Field.Type type)
		{
			return default(SchemaType);
		}

		public static string GetStringifiedBitMask(int bitMask)
		{
			return null;
		}

		public static string GetNiceTypeString(Type t)
		{
			return null;
		}

		public static bool IsMethodCompatible(MethodInfo methodInfo)
		{
			return false;
		}

		public static SchemaType GetSchemaType(Type t)
		{
			return default(SchemaType);
		}

		public static bool IsObscuredType(Type t)
		{
			return false;
		}

		public static bool IsNonBindableType(Type t)
		{
			return false;
		}

		public static bool IsTypeSupported(Type t)
		{
			return false;
		}

		internal static string TidyAssemblyTypeName(string assemblyTypeName)
		{
			return null;
		}

		internal static string CommandName(Type targetScriptType, string methodName)
		{
			return null;
		}

		internal static string CommandNameWithSignatureSuffix(string commandName, IReadOnlyCollection<Type> arguments, bool prettify = false)
		{
			return null;
		}

		private static string ObjectTypesAsString(IReadOnlyCollection<Type> types, bool prettify = false)
		{
			return null;
		}

		internal static T GetFieldValue<T>(object obj, string fieldName, BindingFlags flags)
		{
			return default(T);
		}

		public static Type GetFieldOrPropertyType(MemberInfo memberInfo)
		{
			return null;
		}

		public static bool IsValidBinding(this FieldInfo fi)
		{
			return false;
		}

		public static bool IsValidBinding(this PropertyInfo pi)
		{
			return false;
		}

		private static bool IsValidBinding(this MethodInfo mi)
		{
			return false;
		}

		public static bool IsValidBinding(this MemberInfo memberInfo)
		{
			return false;
		}

		public static BindingState GetBindingState(this MethodInfo mi)
		{
			return default(BindingState);
		}

		public static Type GetMemoizedType(string tidyAssemblyTypeName)
		{
			return null;
		}

		public static string CheckCallbackParameterOrder(MethodInfo callbackMethod)
		{
			return null;
		}

		public static bool IsBindingSupportingCallbacks(Type memberBindingType)
		{
			return false;
		}

		public static bool CallbackHasValidSignature(MethodInfo methodInfo, Type memberBindingType)
		{
			return false;
		}

		public static bool IsUnsigned(Type type)
		{
			return false;
		}

		public static Type GetBindingType(Type fieldOrPropertyType)
		{
			return null;
		}

		public static string GetSchemaFieldName(Type fieldOrPropertyType)
		{
			return null;
		}
	}
}
