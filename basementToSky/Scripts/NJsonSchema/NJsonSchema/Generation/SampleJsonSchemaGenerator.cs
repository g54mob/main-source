using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Generation
{
	public class SampleJsonSchemaGenerator
	{
		public JsonSchema Generate(string json)
		{
			JToken token = JsonConvert.DeserializeObject<JToken>(json, new JsonSerializerSettings
			{
				DateFormatHandling = DateFormatHandling.IsoDateFormat
			});
			JsonSchema jsonSchema = new JsonSchema();
			Generate(token, jsonSchema, jsonSchema, "Anonymous");
			return jsonSchema;
		}

		public JsonSchema Generate(Stream stream)
		{
			using StreamReader reader = new StreamReader(stream);
			using JsonTextReader reader2 = new JsonTextReader(reader);
			JsonSerializer jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
			{
				DateFormatHandling = DateFormatHandling.IsoDateFormat
			});
			JToken token = jsonSerializer.Deserialize<JToken>(reader2);
			JsonSchema jsonSchema = new JsonSchema();
			Generate(token, jsonSchema, jsonSchema, "Anonymous");
			return jsonSchema;
		}

		private void Generate(JToken token, JsonSchema schema, JsonSchema rootSchema, string typeNameHint)
		{
			if (schema != rootSchema && token.Type == JTokenType.Object)
			{
				JsonSchema jsonSchema = null;
				if (token is JObject jObject)
				{
					IEnumerable<JProperty> properties = jObject.Properties();
					jsonSchema = rootSchema.Definitions.Select((KeyValuePair<string, JsonSchema> t) => t.Value).FirstOrDefault((JsonSchema s) => s.Type == JsonObjectType.Object && properties.All((JProperty p) => s.Properties.ContainsKey(p.Name)));
				}
				if (jsonSchema == null)
				{
					jsonSchema = new JsonSchema();
					AddSchemaDefinition(rootSchema, jsonSchema, typeNameHint);
				}
				schema.Reference = jsonSchema;
				GenerateWithoutReference(token, jsonSchema, rootSchema, typeNameHint);
			}
			else
			{
				GenerateWithoutReference(token, schema, rootSchema, typeNameHint);
			}
		}

		private void GenerateWithoutReference(JToken token, JsonSchema schema, JsonSchema rootSchema, string typeNameHint)
		{
			if (token != null)
			{
				switch (token.Type)
				{
				case JTokenType.Object:
					GenerateObject(token, schema, rootSchema);
					break;
				case JTokenType.Array:
					GenerateArray(token, schema, rootSchema, typeNameHint);
					break;
				case JTokenType.Date:
					schema.Type = JsonObjectType.String;
					schema.Format = ((token.Value<DateTime>() == token.Value<DateTime>().Date) ? "date" : "date-time");
					break;
				case JTokenType.String:
					schema.Type = JsonObjectType.String;
					break;
				case JTokenType.Boolean:
					schema.Type = JsonObjectType.Boolean;
					break;
				case JTokenType.Integer:
					schema.Type = JsonObjectType.Integer;
					break;
				case JTokenType.Float:
					schema.Type = JsonObjectType.Number;
					break;
				case JTokenType.Bytes:
					schema.Type = JsonObjectType.String;
					schema.Format = "byte";
					break;
				case JTokenType.TimeSpan:
					schema.Type = JsonObjectType.String;
					schema.Format = "duration";
					break;
				case JTokenType.Guid:
					schema.Type = JsonObjectType.String;
					schema.Format = "guid";
					break;
				case JTokenType.Uri:
					schema.Type = JsonObjectType.String;
					schema.Format = "uri";
					break;
				}
				if (schema.Type == JsonObjectType.String && Regex.IsMatch(token.Value<string>(), "^[0-2][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]$"))
				{
					schema.Format = "date";
				}
				if (schema.Type == JsonObjectType.String && Regex.IsMatch(token.Value<string>(), "^[0-2][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9] [0-9][0-9]:[0-9][0-9](:[0-9][0-9])?$"))
				{
					schema.Format = "date-time";
				}
				if (schema.Type == JsonObjectType.String && Regex.IsMatch(token.Value<string>(), "^[0-9][0-9]:[0-9][0-9](:[0-9][0-9])?$"))
				{
					schema.Format = "duration";
				}
			}
		}

		private void GenerateObject(JToken token, JsonSchema schema, JsonSchema rootSchema)
		{
			schema.Type = JsonObjectType.Object;
			foreach (JProperty item in ((JObject)token).Properties())
			{
				JsonSchemaProperty jsonSchemaProperty = new JsonSchemaProperty();
				string input = ((item.Value.Type == JTokenType.Array) ? ConversionUtilities.Singularize(item.Name) : item.Name);
				string typeNameHint = ConversionUtilities.ConvertToUpperCamelCase(input, firstCharacterMustBeAlpha: true);
				Generate(item.Value, jsonSchemaProperty, rootSchema, typeNameHint);
				schema.Properties[item.Name] = jsonSchemaProperty;
			}
		}

		private void GenerateArray(JToken token, JsonSchema schema, JsonSchema rootSchema, string typeNameHint)
		{
			schema.Type = JsonObjectType.Array;
			List<JsonSchema> list = ((JArray)token).Select(delegate(JToken item)
			{
				JsonSchema jsonSchema = new JsonSchema();
				GenerateWithoutReference(item, jsonSchema, rootSchema, typeNameHint);
				return jsonSchema;
			}).ToList();
			if (list.Count == 0)
			{
				schema.Item = new JsonSchema();
			}
			else if ((from s in list
				group s by s.Type).Count() == 1)
			{
				MergeAndAssignItemSchemas(rootSchema, schema, list, typeNameHint);
			}
			else
			{
				schema.Item = list.First();
			}
		}

		private void MergeAndAssignItemSchemas(JsonSchema rootSchema, JsonSchema schema, List<JsonSchema> itemSchemas, string typeNameHint)
		{
			JsonSchema jsonSchema = itemSchemas.First();
			JsonSchema jsonSchema2 = new JsonSchema
			{
				Type = jsonSchema.Type
			};
			if (jsonSchema.Type == JsonObjectType.Object)
			{
				foreach (IGrouping<string, KeyValuePair<string, JsonSchemaProperty>> item in from p in itemSchemas.SelectMany((JsonSchema s) => s.Properties)
					group p by p.Key)
				{
					jsonSchema2.Properties[item.Key] = item.First().Value;
				}
			}
			AddSchemaDefinition(rootSchema, jsonSchema2, typeNameHint);
			schema.Item = new JsonSchema
			{
				Reference = jsonSchema2
			};
		}

		private void AddSchemaDefinition(JsonSchema rootSchema, JsonSchema schema, string typeNameHint)
		{
			if (string.IsNullOrEmpty(typeNameHint) || rootSchema.Definitions.ContainsKey(typeNameHint))
			{
				rootSchema.Definitions["Anonymous" + (rootSchema.Definitions.Count + 1)] = schema;
			}
			else
			{
				rootSchema.Definitions[typeNameHint] = schema;
			}
		}
	}
}
