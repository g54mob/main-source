using System;
using System.Collections.Generic;
using System.Reflection;
using NJsonSchema.References;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NJsonSchema
{
	public class OpenApiDiscriminator
	{
		private sealed class DiscriminatorMappingConverter : JsonConverter
		{
			public override bool CanConvert(Type objectType)
			{
				return true;
			}

			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				Dictionary<string, string> dictionary = serializer.Deserialize<Dictionary<string, string>>(reader);
				if (dictionary != null && existingValue != null)
				{
					IDictionary<string, JsonSchema> dictionary2 = (IDictionary<string, JsonSchema>)existingValue;
					dictionary2.Clear();
					foreach (KeyValuePair<string, string> item in dictionary)
					{
						JsonSchema jsonSchema = new JsonSchema();
						((IJsonReferenceBase)jsonSchema).ReferencePath = item.Value;
						dictionary2[item.Key] = jsonSchema;
					}
				}
				return existingValue;
			}

			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				if (value is IDictionary<string, JsonSchema> dictionary)
				{
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
					foreach (KeyValuePair<string, JsonSchema> item in dictionary)
					{
						dictionary2[item.Key] = ((IJsonReferenceBase)item.Value).ReferencePath;
					}
					JObject jObject = JObject.FromObject(dictionary2, serializer);
					writer.WriteToken(jObject.CreateReader());
				}
				else
				{
					writer.WriteValue((string?)null);
				}
			}
		}

		[JsonProperty("propertyName", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		public string PropertyName { get; set; }

		[JsonProperty("mapping", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		[JsonConverter(typeof(DiscriminatorMappingConverter))]
		public IDictionary<string, JsonSchema> Mapping { get; } = new Dictionary<string, JsonSchema>();

		[JsonIgnore]
		public object JsonInheritanceConverter { get; set; }

		public void AddMapping(Type type, JsonSchema schema)
		{
			dynamic jsonInheritanceConverter = JsonInheritanceConverter;
			MethodInfo methodInfo = JsonInheritanceConverter?.GetType().GetRuntimeMethod("GetDiscriminatorValue", new Type[1] { typeof(Type) });
			if (methodInfo != null)
			{
				dynamic discriminatorValue = jsonInheritanceConverter.GetDiscriminatorValue(type);
				Mapping[discriminatorValue] = new JsonSchema
				{
					Reference = schema.ActualSchema
				};
			}
			else
			{
				Mapping[type.Name] = new JsonSchema
				{
					Reference = schema.ActualSchema
				};
			}
		}
	}
}
