using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sentry.Extensibility;
using Sentry.Internal.JsonConverters;

namespace Sentry.Internal.Extensions
{
	internal static class JsonExtensions
	{
		private static readonly JsonConverter[] DefaultConverters;

		private static List<JsonConverter> CustomConverters;

		private static JsonSerializerOptions SerializerOptions;

		private static JsonSerializerOptions AltSerializerOptions;

		private static List<JsonSerializerContext> DefaultSerializerContexts;

		private static List<JsonSerializerContext> ReferencePreservingSerializerContexts;

		private static List<Func<JsonSerializerOptions, JsonSerializerContext>> JsonSerializerContextBuilders;

		internal static bool JsonPreserveReferences { get; set; }

		static JsonExtensions()
		{
			DefaultConverters = new JsonConverter[5]
			{
				new SentryJsonConverter(),
				new IntPtrJsonConverter(),
				new IntPtrNullableJsonConverter(),
				new UIntPtrJsonConverter(),
				new UIntPtrNullableJsonConverter()
			};
			CustomConverters = new List<JsonConverter>();
			JsonPreserveReferences = true;
			SerializerOptions = null;
			AltSerializerOptions = null;
			DefaultSerializerContexts = new List<JsonSerializerContext>();
			ReferencePreservingSerializerContexts = new List<JsonSerializerContext>();
			JsonSerializerContextBuilders = new List<Func<JsonSerializerOptions, JsonSerializerContext>>
			{
				(JsonSerializerOptions options) => new SentryJsonContext(options)
			};
			ResetSerializerOptions();
		}

		private static JsonSerializerOptions BuildOptions(bool preserveReferences)
		{
			JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
			if (preserveReferences)
			{
				jsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
			}
			JsonConverter[] defaultConverters = DefaultConverters;
			foreach (JsonConverter item in defaultConverters)
			{
				jsonSerializerOptions.Converters.Add(item);
			}
			foreach (JsonConverter customConverter in CustomConverters)
			{
				jsonSerializerOptions.Converters.Add(customConverter);
			}
			return jsonSerializerOptions;
		}

		internal static void AddJsonSerializerContext<T>(Func<JsonSerializerOptions, T> jsonSerializerContextBuilder) where T : JsonSerializerContext
		{
			JsonSerializerContextBuilders.Add(jsonSerializerContextBuilder);
			ResetSerializerOptions();
		}

		internal static void ResetSerializerOptions()
		{
			SerializerOptions = BuildOptions(preserveReferences: false);
			AltSerializerOptions = BuildOptions(preserveReferences: true);
			DefaultSerializerContexts.Clear();
			ReferencePreservingSerializerContexts.Clear();
			foreach (Func<JsonSerializerOptions, JsonSerializerContext> jsonSerializerContextBuilder in JsonSerializerContextBuilders)
			{
				DefaultSerializerContexts.Add(jsonSerializerContextBuilder(BuildOptions(preserveReferences: false)));
				ReferencePreservingSerializerContexts.Add(jsonSerializerContextBuilder(BuildOptions(preserveReferences: true)));
			}
		}

		internal static void AddJsonConverter(JsonConverter converter)
		{
			if (CustomConverters.Contains(converter))
			{
				return;
			}
			try
			{
				CustomConverters.Add(converter);
				ResetSerializerOptions();
			}
			catch (InvalidOperationException)
			{
			}
		}

		public static void Deconstruct(this JsonProperty jsonProperty, out string name, out JsonElement value)
		{
			name = jsonProperty.Name;
			value = jsonProperty.Value;
		}

		public static Dictionary<string, object?>? GetDictionaryOrNull(this JsonElement json)
		{
			if (json.ValueKind != JsonValueKind.Object)
			{
				return null;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (JsonProperty item in json.EnumerateObject())
			{
				item.Deconstruct(out string name, out JsonElement value);
				string key = name;
				JsonElement json2 = value;
				dictionary[key] = json2.GetDynamicOrNull();
			}
			return dictionary;
		}

		public static Dictionary<string, TValue>? GetDictionaryOrNull<TValue>(this JsonElement json, Func<JsonElement, TValue> factory) where TValue : ISentryJsonSerializable?
		{
			if (json.ValueKind != JsonValueKind.Object)
			{
				return null;
			}
			Dictionary<string, TValue> dictionary = new Dictionary<string, TValue>();
			foreach (JsonProperty item in json.EnumerateObject())
			{
				item.Deconstruct(out string name, out JsonElement value);
				string key = name;
				JsonElement arg = value;
				dictionary[key] = factory(arg);
			}
			return dictionary;
		}

		public static Dictionary<string, string?>? GetStringDictionaryOrNull(this JsonElement json)
		{
			if (json.ValueKind != JsonValueKind.Object)
			{
				return null;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.Ordinal);
			foreach (JsonProperty item in json.EnumerateObject())
			{
				item.Deconstruct(out string name, out JsonElement value);
				string key = name;
				JsonElement jsonElement = value;
				dictionary[key] = jsonElement.GetString();
			}
			return dictionary;
		}

		public static JsonElement? GetPropertyOrNull(this JsonElement json, string name)
		{
			if (json.ValueKind != JsonValueKind.Object)
			{
				return null;
			}
			if (json.TryGetProperty(name, out var value))
			{
				JsonValueKind valueKind = value.ValueKind;
				if (valueKind != JsonValueKind.Undefined && valueKind != JsonValueKind.Null)
				{
					return value;
				}
			}
			return null;
		}

		public static object? GetDynamicOrNull(this JsonElement json)
		{
			return json.ValueKind switch
			{
				JsonValueKind.True => true, 
				JsonValueKind.False => false, 
				JsonValueKind.Number => json.GetNumber(), 
				JsonValueKind.String => json.GetString(), 
				JsonValueKind.Array => json.EnumerateArray().Select(GetDynamicOrNull).ToArray(), 
				JsonValueKind.Object => json.GetDictionaryOrNull(), 
				_ => null, 
			};
		}

		private static object? GetNumber(this JsonElement json)
		{
			double num = json.GetDouble();
			if (num != 0.0)
			{
				return num;
			}
			if (json.TryGetInt64(out var value))
			{
				return value;
			}
			return double.Parse(json.ToString(), CultureInfo.InvariantCulture);
		}

		public static long? GetHexAsLong(this JsonElement json)
		{
			if (json.ValueKind == JsonValueKind.Number)
			{
				return json.GetInt64();
			}
			string text = json.GetString();
			if (text == null)
			{
				return null;
			}
			string text2 = text;
			string s = text2.Substring(2, text2.Length - 2);
			if (text.StartsWith("0x") && long.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
			{
				return result;
			}
			throw new FormatException();
		}

		public static string GetStringOrThrow(this JsonElement json)
		{
			return json.GetString() ?? throw new InvalidOperationException("JSON string is null.");
		}

		public static void WriteDictionaryValue(this Utf8JsonWriter writer, IEnumerable<KeyValuePair<string, object?>>? dic, IDiagnosticLogger? logger, bool includeNullValues = true)
		{
			if (dic != null)
			{
				writer.WriteStartObject();
				string key;
				object value;
				if (includeNullValues)
				{
					foreach (KeyValuePair<string, object> item in dic)
					{
						PolyfillExtensions.Deconstruct(item, out key, out value);
						string propertyName = key;
						object value2 = value;
						writer.WriteDynamic(propertyName, value2, logger);
					}
				}
				else
				{
					foreach (KeyValuePair<string, object> item2 in dic)
					{
						PolyfillExtensions.Deconstruct(item2, out key, out value);
						string propertyName2 = key;
						object obj = value;
						if (obj != null)
						{
							writer.WriteDynamic(propertyName2, obj, logger);
						}
					}
				}
				writer.WriteEndObject();
			}
			else
			{
				writer.WriteNullValue();
			}
		}

		public static void WriteDictionaryValue<TValue>(this Utf8JsonWriter writer, IEnumerable<KeyValuePair<string, TValue>>? dic, IDiagnosticLogger? logger, bool includeNullValues = true) where TValue : ISentryJsonSerializable?
		{
			if (dic != null)
			{
				writer.WriteStartObject();
				foreach (var (propertyName, val2) in dic)
				{
					if (val2 != null)
					{
						writer.WriteSerializable(propertyName, val2, logger);
					}
					else if (includeNullValues)
					{
						writer.WriteNull(propertyName);
					}
				}
				writer.WriteEndObject();
			}
			else
			{
				writer.WriteNullValue();
			}
		}

		public static void WriteStringDictionaryValue(this Utf8JsonWriter writer, IEnumerable<KeyValuePair<string, string?>>? dic)
		{
			if (dic != null)
			{
				writer.WriteStartObject();
				foreach (var (propertyName, value) in dic)
				{
					writer.WriteString(propertyName, value);
				}
				writer.WriteEndObject();
			}
			else
			{
				writer.WriteNullValue();
			}
		}

		public static void WriteDictionary(this Utf8JsonWriter writer, string propertyName, IEnumerable<KeyValuePair<string, object?>>? dic, IDiagnosticLogger? logger)
		{
			writer.WritePropertyName(propertyName);
			writer.WriteDictionaryValue(dic, logger);
		}

		public static void WriteDictionary<TValue>(this Utf8JsonWriter writer, string propertyName, IEnumerable<KeyValuePair<string, TValue>>? dic, IDiagnosticLogger? logger) where TValue : ISentryJsonSerializable?
		{
			writer.WritePropertyName(propertyName);
			writer.WriteDictionaryValue(dic, logger);
		}

		public static void WriteStringDictionary(this Utf8JsonWriter writer, string propertyName, IEnumerable<KeyValuePair<string, string?>>? dic)
		{
			writer.WritePropertyName(propertyName);
			writer.WriteStringDictionaryValue(dic);
		}

		public static void WriteArrayValue<T>(this Utf8JsonWriter writer, IEnumerable<T>? arr, IDiagnosticLogger? logger)
		{
			if (arr != null)
			{
				writer.WriteStartArray();
				foreach (T item in arr)
				{
					writer.WriteDynamicValue(item, logger);
				}
				writer.WriteEndArray();
			}
			else
			{
				writer.WriteNullValue();
			}
		}

		public static void WriteArray<T>(this Utf8JsonWriter writer, string propertyName, IEnumerable<T>? arr, IDiagnosticLogger? logger)
		{
			writer.WritePropertyName(propertyName);
			writer.WriteArrayValue(arr, logger);
		}

		public static void WriteStringArrayValue(this Utf8JsonWriter writer, IEnumerable<string?>? arr)
		{
			if (arr != null)
			{
				writer.WriteStartArray();
				foreach (string item in arr)
				{
					writer.WriteStringValue(item);
				}
				writer.WriteEndArray();
			}
			else
			{
				writer.WriteNullValue();
			}
		}

		public static void WriteStringArray(this Utf8JsonWriter writer, string propertyName, IEnumerable<string?>? arr)
		{
			writer.WritePropertyName(propertyName);
			writer.WriteStringArrayValue(arr);
		}

		public static void WriteSerializableValue(this Utf8JsonWriter writer, ISentryJsonSerializable value, IDiagnosticLogger? logger)
		{
			value.WriteTo(writer, logger);
		}

		public static void WriteSerializable(this Utf8JsonWriter writer, string propertyName, ISentryJsonSerializable value, IDiagnosticLogger? logger)
		{
			writer.WritePropertyName(propertyName);
			writer.WriteSerializableValue(value, logger);
		}

		public static void WriteDynamicValue(this Utf8JsonWriter writer, object? value, IDiagnosticLogger? logger)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			if (value is ISentryJsonSerializable value2)
			{
				writer.WriteSerializableValue(value2, logger);
				return;
			}
			if (value is IEnumerable<KeyValuePair<string, string>> dic)
			{
				writer.WriteStringDictionaryValue(dic);
				return;
			}
			if (value is IEnumerable<KeyValuePair<string, object>> dic2)
			{
				writer.WriteDictionaryValue(dic2, logger);
				return;
			}
			if (value is string value3)
			{
				writer.WriteStringValue(value3);
				return;
			}
			if (value is bool value4)
			{
				writer.WriteBooleanValue(value4);
				return;
			}
			if (value is int value5)
			{
				writer.WriteNumberValue(value5);
				return;
			}
			if (value is long value6)
			{
				writer.WriteNumberValue(value6);
				return;
			}
			if (value is double value7)
			{
				writer.WriteNumberValue(value7);
				return;
			}
			if (value is DateTime value8)
			{
				writer.WriteStringValue(value8);
				return;
			}
			if (value is DateTimeOffset value9)
			{
				writer.WriteStringValue(value9);
				return;
			}
			if (value is TimeSpan timeSpan)
			{
				writer.WriteStringValue(timeSpan.ToString("g", CultureInfo.InvariantCulture));
				return;
			}
			if (value is IFormattable formattable)
			{
				writer.WriteStringValue(formattable.ToString(null, CultureInfo.InvariantCulture));
				return;
			}
			if (value.GetType().ToString() == "System.RuntimeType")
			{
				writer.WriteStringValue(value.ToString());
				return;
			}
			if (!JsonPreserveReferences)
			{
				InternalSerialize(writer, value);
				return;
			}
			try
			{
				byte[] array = InternalSerializeToUtf8Bytes(value);
				writer.WriteRawValue(array);
			}
			catch (JsonException)
			{
				InternalSerialize(writer, value, preserveReferences: true);
			}
		}

		internal static string ToUtf8Json(this object value, bool preserveReferences = false)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream);
			InternalSerialize(utf8JsonWriter, value, preserveReferences);
			utf8JsonWriter.Flush();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}

		private static JsonSerializerContext GetSerializerContext(Type type, bool preserveReferences = false)
		{
			List<JsonSerializerContext> list = (preserveReferences ? ReferencePreservingSerializerContexts : DefaultSerializerContexts);
			return list.FirstOrDefault((JsonSerializerContext c) => c.GetTypeInfo(type) != null) ?? list[0];
		}

		private static byte[] InternalSerializeToUtf8Bytes(object value)
		{
			return JitSerializeToUtf8Bytes();
			[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "Non-trimmable code is avoided at runtime")]
			[UnconditionalSuppressMessage("AOT", "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.", Justification = "Non-trimmable code is avoided at runtime")]
			byte[] JitSerializeToUtf8Bytes()
			{
				return JsonSerializer.SerializeToUtf8Bytes(value, SerializerOptions);
			}
		}

		private static void InternalSerialize(Utf8JsonWriter writer, object value, bool preserveReferences = false)
		{
			JitSerialize();
			[UnconditionalSuppressMessage("AOT", "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.", Justification = "Non-trimmable code is avoided at runtime")]
			[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "Non-trimmable code is avoided at runtime")]
			void JitSerialize()
			{
				JsonSerializerOptions options = (preserveReferences ? AltSerializerOptions : SerializerOptions);
				JsonSerializer.Serialize(writer, value, options);
			}
		}

		public static void WriteDynamic(this Utf8JsonWriter writer, string propertyName, object? value, IDiagnosticLogger? logger)
		{
			writer.WritePropertyName(propertyName);
			int currentDepth = writer.CurrentDepth;
			try
			{
				writer.WriteDynamicValue(value, logger);
			}
			catch (Exception exception)
			{
				logger?.LogError(exception, "Failed to serialize object for property '{0}'. Original depth: {1}, current depth: {2}", propertyName, currentDepth, writer.CurrentDepth);
				try
				{
					writer.WriteStartObject();
				}
				catch (InvalidOperationException)
				{
				}
				while (currentDepth < writer.CurrentDepth)
				{
					writer.WriteEndObject();
				}
			}
		}

		public static void WriteBooleanIfNotNull(this Utf8JsonWriter writer, string propertyName, bool? value)
		{
			if (value.HasValue)
			{
				writer.WriteBoolean(propertyName, value.Value);
			}
		}

		public static void WriteBooleanIfTrue(this Utf8JsonWriter writer, string propertyName, bool? value)
		{
			if (value ?? false)
			{
				writer.WriteBoolean(propertyName, value.Value);
			}
		}

		public static void WriteNumberIfNotNull(this Utf8JsonWriter writer, string propertyName, short? value)
		{
			if (value.HasValue)
			{
				writer.WriteNumber(propertyName, value.Value);
			}
		}

		public static void WriteNumberIfNotNull(this Utf8JsonWriter writer, string propertyName, int? value)
		{
			if (value.HasValue)
			{
				writer.WriteNumber(propertyName, value.Value);
			}
		}

		public static void WriteNumberIfNotNull(this Utf8JsonWriter writer, string propertyName, long? value)
		{
			if (value.HasValue)
			{
				writer.WriteNumber(propertyName, value.Value);
			}
		}

		public static void WriteNumberIfNotNull(this Utf8JsonWriter writer, string propertyName, float? value)
		{
			if (value.HasValue)
			{
				writer.WriteNumber(propertyName, value.Value);
			}
		}

		public static void WriteNumberIfNotNull(this Utf8JsonWriter writer, string propertyName, double? value)
		{
			if (value.HasValue)
			{
				writer.WriteNumber(propertyName, value.Value);
			}
		}

		public static void WriteNumberIfNotZero(this Utf8JsonWriter writer, string propertyName, short value)
		{
			if (value != 0)
			{
				writer.WriteNumber(propertyName, value);
			}
		}

		public static void WriteNumberIfNotZero(this Utf8JsonWriter writer, string propertyName, int value)
		{
			if (value != 0)
			{
				writer.WriteNumber(propertyName, value);
			}
		}

		public static void WriteNumberIfNotZero(this Utf8JsonWriter writer, string propertyName, long value)
		{
			if (value != 0L)
			{
				writer.WriteNumber(propertyName, value);
			}
		}

		public static void WriteNumberIfNotZero(this Utf8JsonWriter writer, string propertyName, float value)
		{
			if (value != 0f)
			{
				writer.WriteNumber(propertyName, value);
			}
		}

		public static void WriteNumberIfNotZero(this Utf8JsonWriter writer, string propertyName, double value)
		{
			if (value != 0.0)
			{
				writer.WriteNumber(propertyName, value);
			}
		}

		public static void WriteStringIfNotWhiteSpace(this Utf8JsonWriter writer, string propertyName, string? value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				writer.WriteString(propertyName, value);
			}
		}

		public static void WriteStringIfNotNull(this Utf8JsonWriter writer, string propertyName, DateTimeOffset? value)
		{
			if (value.HasValue)
			{
				writer.WriteString(propertyName, value.Value);
			}
		}

		public static void WriteSerializableIfNotNull(this Utf8JsonWriter writer, string propertyName, ISentryJsonSerializable? value, IDiagnosticLogger? logger)
		{
			if (value != null)
			{
				writer.WriteSerializable(propertyName, value, logger);
			}
		}

		public static void WriteDictionaryIfNotEmpty(this Utf8JsonWriter writer, string propertyName, IEnumerable<KeyValuePair<string, object?>>? dic, IDiagnosticLogger? logger)
		{
			IReadOnlyDictionary<string, object> readOnlyDictionary = (dic as IReadOnlyDictionary<string, object>) ?? dic?.ToDict();
			if (readOnlyDictionary != null && readOnlyDictionary.Count > 0)
			{
				writer.WriteDictionary(propertyName, readOnlyDictionary, logger);
			}
		}

		public static void WriteDictionaryIfNotEmpty<TValue>(this Utf8JsonWriter writer, string propertyName, IEnumerable<KeyValuePair<string, TValue>>? dic, IDiagnosticLogger? logger) where TValue : ISentryJsonSerializable?
		{
			IReadOnlyDictionary<string, TValue> readOnlyDictionary = (dic as IReadOnlyDictionary<string, TValue>) ?? dic?.ToDict();
			if (readOnlyDictionary != null && readOnlyDictionary.Count > 0)
			{
				writer.WriteDictionary(propertyName, readOnlyDictionary, logger);
			}
		}

		public static void WriteStringDictionaryIfNotEmpty(this Utf8JsonWriter writer, string propertyName, IEnumerable<KeyValuePair<string, string?>>? dic)
		{
			IReadOnlyDictionary<string, string> readOnlyDictionary = (dic as IReadOnlyDictionary<string, string>) ?? dic?.ToDict();
			if (readOnlyDictionary != null && readOnlyDictionary.Count > 0)
			{
				writer.WriteStringDictionary(propertyName, readOnlyDictionary);
			}
		}

		public static void WriteArrayIfNotEmpty<T>(this Utf8JsonWriter writer, string propertyName, IEnumerable<T>? arr, IDiagnosticLogger? logger)
		{
			IReadOnlyList<T> readOnlyList = (arr as IReadOnlyList<T>) ?? arr?.ToArray();
			if (readOnlyList != null && readOnlyList.Count > 0)
			{
				writer.WriteArray(propertyName, readOnlyList, logger);
			}
		}

		public static void WriteStringArrayIfNotEmpty(this Utf8JsonWriter writer, string propertyName, IEnumerable<string?>? arr)
		{
			IReadOnlyList<string> readOnlyList = (arr as IReadOnlyList<string>) ?? arr?.ToArray();
			if (readOnlyList != null && readOnlyList.Count > 0)
			{
				writer.WriteStringArray(propertyName, readOnlyList);
			}
		}

		public static void WriteDynamicIfNotNull(this Utf8JsonWriter writer, string propertyName, object? value, IDiagnosticLogger? logger)
		{
			if (value != null)
			{
				writer.WriteDynamic(propertyName, value, logger);
			}
		}

		public static void WriteString(this Utf8JsonWriter writer, string propertyName, IEnumeration? value)
		{
			if (value == null)
			{
				writer.WriteNull(propertyName);
			}
			else
			{
				writer.WriteString(propertyName, value.Value);
			}
		}
	}
}
