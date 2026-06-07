using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using Utf8Json.Internal.Emit;

namespace Utf8Json.Resolvers.Internal
{
	internal static class DynamicObjectTypeBuilder
	{
		private struct DeserializeInfo
		{
			public MetaMember MemberInfo;

			public LocalBuilder LocalField;

			public LocalBuilder IsDeserializedField;
		}

		internal static class EmitInfo
		{
			internal static class JsonWriter
			{
				public static readonly MethodInfo GetEncodedPropertyNameWithBeginObject;

				public static readonly MethodInfo GetEncodedPropertyNameWithPrefixValueSeparator;

				public static readonly MethodInfo GetEncodedPropertyNameWithoutQuotation;

				public static readonly MethodInfo GetEncodedPropertyName;

				public static readonly MethodInfo WriteNull;

				public static readonly MethodInfo WriteRaw;

				public static readonly MethodInfo WriteBeginObject;

				public static readonly MethodInfo WriteEndObject;

				public static readonly MethodInfo WriteValueSeparator;

				static JsonWriter()
				{
				}
			}

			internal static class JsonReader
			{
				public static readonly MethodInfo ReadIsNull;

				public static readonly MethodInfo ReadIsBeginObjectWithVerify;

				public static readonly MethodInfo ReadIsEndObjectWithSkipValueSeparator;

				public static readonly MethodInfo ReadPropertyNameSegmentUnsafe;

				public static readonly MethodInfo ReadNextBlock;

				public static readonly MethodInfo GetBufferUnsafe;

				public static readonly MethodInfo GetCurrentOffsetUnsafe;

				static JsonReader()
				{
				}
			}

			internal static class JsonFormatterAttr
			{
				internal static readonly MethodInfo FormatterType;

				internal static readonly MethodInfo Arguments;
			}

			public static readonly ConstructorInfo ObjectCtor;

			public static readonly MethodInfo GetFormatterWithVerify;

			public static readonly ConstructorInfo InvalidOperationExceptionConstructor;

			public static readonly MethodInfo GetTypeFromHandle;

			public static readonly MethodInfo TypeGetProperty;

			public static readonly MethodInfo TypeGetField;

			public static readonly MethodInfo GetCustomAttributeJsonFormatterAttribute;

			public static readonly MethodInfo ActivatorCreateInstance;

			public static readonly MethodInfo GetUninitializedObject;

			public static readonly MethodInfo GetTypeMethod;

			public static readonly MethodInfo TypeEquals;

			public static readonly MethodInfo NongenericSerialize;

			public static MethodInfo Serialize(Type type)
			{
				return null;
			}

			public static MethodInfo Deserialize(Type type)
			{
				return null;
			}

			public static MethodInfo GetNullableHasValue(Type type)
			{
				return null;
			}
		}

		internal class Utf8JsonDynamicObjectResolverException : Exception
		{
			public Utf8JsonDynamicObjectResolverException(string message)
			{
			}
		}

		private static readonly Regex SubtractFullNameRegex;

		private static int nameSequence;

		private static HashSet<Type> ignoreTypes;

		private static HashSet<Type> jsonPrimitiveTypes;

		public static object BuildFormatterToAssembly<T>(DynamicAssembly assembly, IJsonFormatterResolver selfResolver, Func<string, string> nameMutator, bool excludeNull)
		{
			return null;
		}

		public static object BuildFormatterToDynamicMethod<T>(IJsonFormatterResolver selfResolver, Func<string, string> nameMutator, bool excludeNull, bool allowPrivate)
		{
			return null;
		}

		private static TypeInfo BuildType(DynamicAssembly assembly, Type type, Func<string, string> nameMutator, bool excludeNull)
		{
			return null;
		}

		public static object BuildAnonymousFormatter(Type type, Func<string, string> nameMutator, bool excludeNull, bool allowPrivate, bool isException)
		{
			return null;
		}

		private static Dictionary<MetaMember, FieldInfo> BuildConstructor(TypeBuilder builder, MetaType info, ConstructorInfo method, FieldBuilder stringByteKeysField, ILGenerator il, bool excludeNull, bool hasShouldSerialize)
		{
			return null;
		}

		private static Dictionary<MetaMember, FieldInfo> BuildCustomFormatterField(TypeBuilder builder, MetaType info, ILGenerator il)
		{
			return null;
		}

		private static void BuildSerialize(Type type, MetaType info, ILGenerator il, Action emitStringByteKeys, Func<int, MetaMember, bool> tryEmitLoadCustomFormatter, bool excludeNull, bool hasShouldSerialize, int firstArgIndex)
		{
		}

		private static void EmitSerializeValue(TypeInfo type, MetaMember member, ILGenerator il, int index, Func<int, MetaMember, bool> tryEmitLoadCustomFormatter, ArgumentField writer, ArgumentField argValue, ArgumentField argResolver)
		{
		}

		private static void BuildDeserialize(Type type, MetaType info, ILGenerator il, Func<int, MetaMember, bool> tryEmitLoadCustomFormatter, bool useGetUninitializedObject, int firstArgIndex)
		{
		}

		private static void EmitDeserializeValue(ILGenerator il, DeserializeInfo info, int index, Func<int, MetaMember, bool> tryEmitLoadCustomFormatter, ArgumentField reader, ArgumentField argResolver)
		{
		}

		private static LocalBuilder EmitNewObject(ILGenerator il, Type type, MetaType info, DeserializeInfo[] members, bool isSideEffectFreeType)
		{
			return null;
		}

		private static bool IsSideEffectFreeConstructorType(ConstructorInfo ctorInfo)
		{
			return false;
		}

		private static bool TryGetInterfaceEnumerableElementType(Type type, out Type elementType)
		{
			elementType = null;
			return false;
		}
	}
}
