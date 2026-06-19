using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Sentry.Internal.Extensions
{
	[JsonSerializable(typeof(GrowableArray<int>))]
	[JsonSerializable(typeof(Dictionary<string, bool>))]
	[JsonSerializable(typeof(Dictionary<string, object>))]
	[GeneratedCode("System.Text.Json.SourceGeneration", "6.0.8.26907")]
	internal class SentryJsonContext : JsonSerializerContext
	{
		private JsonTypeInfo<int>? _Int32;

		private JsonTypeInfo<GrowableArray<int>>? _GrowableArrayInt32;

		private JsonTypeInfo<string>? _String;

		private JsonTypeInfo<bool>? _Boolean;

		private JsonTypeInfo<Dictionary<string, bool>>? _DictionaryStringBoolean;

		private JsonTypeInfo<object>? _Object;

		private JsonTypeInfo<Dictionary<string, object>>? _DictionaryStringObject;

		private static SentryJsonContext? s_defaultContext;

		public JsonTypeInfo<int> Int32
		{
			get
			{
				if (_Int32 == null)
				{
					JsonConverter runtimeProvidedCustomConverter;
					if (base.Options.Converters.Count > 0 && (runtimeProvidedCustomConverter = GetRuntimeProvidedCustomConverter(typeof(int))) != null)
					{
						_Int32 = JsonMetadataServices.CreateValueInfo<int>(base.Options, runtimeProvidedCustomConverter);
					}
					else
					{
						_Int32 = JsonMetadataServices.CreateValueInfo<int>(base.Options, JsonMetadataServices.Int32Converter);
					}
				}
				return _Int32;
			}
		}

		public JsonTypeInfo<GrowableArray<int>> GrowableArrayInt32
		{
			get
			{
				if (_GrowableArrayInt32 == null)
				{
					JsonConverter runtimeProvidedCustomConverter;
					if (base.Options.Converters.Count > 0 && (runtimeProvidedCustomConverter = GetRuntimeProvidedCustomConverter(typeof(GrowableArray<int>))) != null)
					{
						_GrowableArrayInt32 = JsonMetadataServices.CreateValueInfo<GrowableArray<int>>(base.Options, runtimeProvidedCustomConverter);
					}
					else
					{
						JsonCollectionInfoValues<GrowableArray<int>> collectionInfo = new JsonCollectionInfoValues<GrowableArray<int>>
						{
							ObjectCreator = () => default(GrowableArray<int>),
							KeyInfo = null,
							ElementInfo = Int32,
							NumberHandling = JsonNumberHandling.Strict,
							SerializeHandler = GrowableArrayInt32SerializeHandler
						};
						_GrowableArrayInt32 = JsonMetadataServices.CreateIEnumerableInfo<GrowableArray<int>, int>(base.Options, collectionInfo);
					}
				}
				return _GrowableArrayInt32;
			}
		}

		public JsonTypeInfo<string> String
		{
			get
			{
				if (_String == null)
				{
					JsonConverter runtimeProvidedCustomConverter;
					if (base.Options.Converters.Count > 0 && (runtimeProvidedCustomConverter = GetRuntimeProvidedCustomConverter(typeof(string))) != null)
					{
						_String = JsonMetadataServices.CreateValueInfo<string>(base.Options, runtimeProvidedCustomConverter);
					}
					else
					{
						_String = JsonMetadataServices.CreateValueInfo<string>(base.Options, JsonMetadataServices.StringConverter);
					}
				}
				return _String;
			}
		}

		public JsonTypeInfo<bool> Boolean
		{
			get
			{
				if (_Boolean == null)
				{
					JsonConverter runtimeProvidedCustomConverter;
					if (base.Options.Converters.Count > 0 && (runtimeProvidedCustomConverter = GetRuntimeProvidedCustomConverter(typeof(bool))) != null)
					{
						_Boolean = JsonMetadataServices.CreateValueInfo<bool>(base.Options, runtimeProvidedCustomConverter);
					}
					else
					{
						_Boolean = JsonMetadataServices.CreateValueInfo<bool>(base.Options, JsonMetadataServices.BooleanConverter);
					}
				}
				return _Boolean;
			}
		}

		public JsonTypeInfo<Dictionary<string, bool>> DictionaryStringBoolean
		{
			get
			{
				if (_DictionaryStringBoolean == null)
				{
					JsonConverter runtimeProvidedCustomConverter;
					if (base.Options.Converters.Count > 0 && (runtimeProvidedCustomConverter = GetRuntimeProvidedCustomConverter(typeof(Dictionary<string, bool>))) != null)
					{
						_DictionaryStringBoolean = JsonMetadataServices.CreateValueInfo<Dictionary<string, bool>>(base.Options, runtimeProvidedCustomConverter);
					}
					else
					{
						JsonCollectionInfoValues<Dictionary<string, bool>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, bool>>
						{
							ObjectCreator = () => new Dictionary<string, bool>(),
							KeyInfo = String,
							ElementInfo = Boolean,
							NumberHandling = JsonNumberHandling.Strict,
							SerializeHandler = DictionaryStringBooleanSerializeHandler
						};
						_DictionaryStringBoolean = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, bool>, string, bool>(base.Options, collectionInfo);
					}
				}
				return _DictionaryStringBoolean;
			}
		}

		public JsonTypeInfo<object> Object
		{
			get
			{
				if (_Object == null)
				{
					JsonConverter runtimeProvidedCustomConverter;
					if (base.Options.Converters.Count > 0 && (runtimeProvidedCustomConverter = GetRuntimeProvidedCustomConverter(typeof(object))) != null)
					{
						_Object = JsonMetadataServices.CreateValueInfo<object>(base.Options, runtimeProvidedCustomConverter);
					}
					else
					{
						_Object = JsonMetadataServices.CreateValueInfo<object>(base.Options, JsonMetadataServices.ObjectConverter);
					}
				}
				return _Object;
			}
		}

		public JsonTypeInfo<Dictionary<string, object>> DictionaryStringObject
		{
			get
			{
				if (_DictionaryStringObject == null)
				{
					JsonConverter runtimeProvidedCustomConverter;
					if (base.Options.Converters.Count > 0 && (runtimeProvidedCustomConverter = GetRuntimeProvidedCustomConverter(typeof(Dictionary<string, object>))) != null)
					{
						_DictionaryStringObject = JsonMetadataServices.CreateValueInfo<Dictionary<string, object>>(base.Options, runtimeProvidedCustomConverter);
					}
					else
					{
						JsonCollectionInfoValues<Dictionary<string, object>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, object>>
						{
							ObjectCreator = () => new Dictionary<string, object>(),
							KeyInfo = String,
							ElementInfo = Object,
							NumberHandling = JsonNumberHandling.Strict,
							SerializeHandler = null
						};
						_DictionaryStringObject = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, object>, string, object>(base.Options, collectionInfo);
					}
				}
				return _DictionaryStringObject;
			}
		}

		private static JsonSerializerOptions s_defaultOptions { get; } = new JsonSerializerOptions
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.Never,
			IgnoreReadOnlyFields = false,
			IgnoreReadOnlyProperties = false,
			IncludeFields = false,
			WriteIndented = false
		};

		public static SentryJsonContext Default => s_defaultContext ?? (s_defaultContext = new SentryJsonContext(new JsonSerializerOptions(s_defaultOptions)));

		protected override JsonSerializerOptions? GeneratedSerializerOptions { get; } = s_defaultOptions;

		private static void GrowableArrayInt32SerializeHandler(Utf8JsonWriter writer, GrowableArray<int> value)
		{
			writer.WriteStartArray();
			foreach (int item in value)
			{
				writer.WriteNumberValue(item);
			}
			writer.WriteEndArray();
		}

		private static void DictionaryStringBooleanSerializeHandler(Utf8JsonWriter writer, Dictionary<string, bool>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			foreach (KeyValuePair<string, bool> item in value)
			{
				writer.WriteBoolean(item.Key, item.Value);
			}
			writer.WriteEndObject();
		}

		public SentryJsonContext()
			: base(null)
		{
		}

		public SentryJsonContext(JsonSerializerOptions options)
			: base(options)
		{
		}

		private JsonConverter? GetRuntimeProvidedCustomConverter(Type type)
		{
			IList<JsonConverter> converters = base.Options.Converters;
			for (int i = 0; i < converters.Count; i++)
			{
				JsonConverter jsonConverter = converters[i];
				if (!jsonConverter.CanConvert(type))
				{
					continue;
				}
				if (jsonConverter is JsonConverterFactory jsonConverterFactory)
				{
					jsonConverter = jsonConverterFactory.CreateConverter(type, base.Options);
					if (jsonConverter == null || jsonConverter is JsonConverterFactory)
					{
						throw new InvalidOperationException($"The converter '{jsonConverterFactory.GetType()}' cannot return null or a JsonConverterFactory instance.");
					}
				}
				return jsonConverter;
			}
			return null;
		}

		public override JsonTypeInfo GetTypeInfo(Type type)
		{
			if (type == typeof(GrowableArray<int>))
			{
				return GrowableArrayInt32;
			}
			if (type == typeof(Dictionary<string, bool>))
			{
				return DictionaryStringBoolean;
			}
			if (type == typeof(Dictionary<string, object>))
			{
				return DictionaryStringObject;
			}
			return null;
		}
	}
}
