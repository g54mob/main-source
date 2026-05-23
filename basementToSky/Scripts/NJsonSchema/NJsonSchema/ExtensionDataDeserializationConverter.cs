using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NJsonSchema
{
	internal sealed class ExtensionDataDeserializationConverter : JsonConverter
	{
		public override bool CanRead => true;

		public override bool CanWrite => false;

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.Null)
			{
				IJsonExtensionObject jsonExtensionObject = (IJsonExtensionObject)Activator.CreateInstance(objectType);
				serializer.Populate(reader, jsonExtensionObject);
				DeserializeExtensionDataSchemas(jsonExtensionObject, serializer);
				return jsonExtensionObject;
			}
			reader.Skip();
			return null;
		}

		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		internal void DeserializeExtensionDataSchemas(IJsonExtensionObject extensionObject, JsonSerializer serializer)
		{
			if (extensionObject.ExtensionData != null)
			{
				KeyValuePair<string, object>[] array = extensionObject.ExtensionData.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					KeyValuePair<string, object> keyValuePair = array[i];
					extensionObject.ExtensionData[keyValuePair.Key] = TryDeserializeValueSchemas(keyValuePair.Value, serializer);
				}
			}
		}

		private object TryDeserializeValueSchemas(object value, JsonSerializer serializer)
		{
			if (value is JObject jObject)
			{
				if (jObject.Property("type") != null || jObject.Property("properties") != null)
				{
					try
					{
						return jObject.ToObject<JsonSchema>(serializer);
					}
					catch
					{
					}
				}
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				{
					foreach (JProperty item in jObject.Properties())
					{
						dictionary[item.Name] = TryDeserializeValueSchemas(item.Value, serializer);
					}
					return dictionary;
				}
			}
			if (value is JArray source)
			{
				return source.Select((JToken i) => TryDeserializeValueSchemas(i, serializer)).ToArray();
			}
			if (value is JValue jValue)
			{
				return jValue.Value;
			}
			return value;
		}
	}
}
