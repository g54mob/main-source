using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Google.Protobuf.Reflection;

namespace Google.Protobuf
{
	public sealed class JsonParser
	{
		public sealed class Settings
		{
			public static Settings Default { get; }

			public int RecursionLimit { get; }

			public TypeRegistry TypeRegistry { get; }

			public bool IgnoreUnknownFields { get; }

			static Settings()
			{
			}

			private Settings(int recursionLimit, TypeRegistry typeRegistry, bool ignoreUnknownFields)
			{
			}

			public Settings(int recursionLimit)
			{
			}

			public Settings(int recursionLimit, TypeRegistry typeRegistry)
			{
			}

			public Settings WithIgnoreUnknownFields(bool ignoreUnknownFields)
			{
				return null;
			}

			public Settings WithRecursionLimit(int recursionLimit)
			{
				return null;
			}

			public Settings WithTypeRegistry(TypeRegistry typeRegistry)
			{
				return null;
			}
		}

		private static readonly Regex TimestampRegex;

		private static readonly Regex DurationRegex;

		private static readonly int[] SubsecondScalingFactors;

		private static readonly char[] FieldMaskPathSeparators;

		private static readonly EnumDescriptor NullValueDescriptor;

		private static readonly JsonParser defaultInstance;

		private static readonly Dictionary<string, Action<JsonParser, IMessage, JsonTokenizer>> WellKnownTypeHandlers;

		private readonly Settings settings;

		public static JsonParser Default => null;

		private static void MergeWrapperField(JsonParser parser, IMessage message, JsonTokenizer tokenizer)
		{
		}

		public JsonParser(Settings settings)
		{
		}

		internal void Merge(IMessage message, string json)
		{
		}

		internal void Merge(IMessage message, TextReader jsonReader)
		{
		}

		private void Merge(IMessage message, JsonTokenizer tokenizer)
		{
		}

		private void MergeField(IMessage message, FieldDescriptor field, JsonTokenizer tokenizer)
		{
		}

		private void MergeRepeatedField(IMessage message, FieldDescriptor field, JsonTokenizer tokenizer)
		{
		}

		private void MergeMapField(IMessage message, FieldDescriptor field, JsonTokenizer tokenizer)
		{
		}

		private static bool IsGoogleProtobufValueField(FieldDescriptor field)
		{
			return false;
		}

		private static bool IsGoogleProtobufNullValueField(FieldDescriptor field)
		{
			return false;
		}

		private object ParseSingleValue(FieldDescriptor field, JsonTokenizer tokenizer)
		{
			return null;
		}

		public T Parse<T>(string json) where T : IMessage, new()
		{
			return default(T);
		}

		public T Parse<T>(TextReader jsonReader) where T : IMessage, new()
		{
			return default(T);
		}

		public IMessage Parse(string json, MessageDescriptor descriptor)
		{
			return null;
		}

		public IMessage Parse(TextReader jsonReader, MessageDescriptor descriptor)
		{
			return null;
		}

		private void MergeStructValue(IMessage message, JsonTokenizer tokenizer)
		{
		}

		private void MergeStruct(IMessage message, JsonTokenizer tokenizer)
		{
		}

		private void MergeAny(IMessage message, JsonTokenizer tokenizer)
		{
		}

		private void MergeWellKnownTypeAnyBody(IMessage body, JsonTokenizer tokenizer)
		{
		}

		private static object ParseMapKey(FieldDescriptor field, string keyText)
		{
			return null;
		}

		private static object ParseSingleNumberValue(FieldDescriptor field, JsonToken token)
		{
			return null;
		}

		private static void CheckInteger(double value)
		{
		}

		private static object ParseSingleStringValue(FieldDescriptor field, string text)
		{
			return null;
		}

		private static IMessage NewMessageForField(FieldDescriptor field)
		{
			return null;
		}

		private static T ParseNumericString<T>(string text, Func<string, NumberStyles, IFormatProvider, T> parser)
		{
			return default(T);
		}

		private static void ValidateInfinityAndNan(string text, bool isPositiveInfinity, bool isNegativeInfinity, bool isNaN)
		{
		}

		private static void MergeTimestamp(IMessage message, JsonToken token)
		{
		}

		private static void MergeDuration(IMessage message, JsonToken token)
		{
		}

		private static void MergeFieldMask(IMessage message, JsonToken token)
		{
		}

		private static string ToSnakeCase(string text)
		{
			return null;
		}
	}
}
