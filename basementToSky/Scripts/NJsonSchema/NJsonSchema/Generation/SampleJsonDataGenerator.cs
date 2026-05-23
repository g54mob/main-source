using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Generation
{
	public class SampleJsonDataGenerator
	{
		private readonly SampleJsonDataGeneratorSettings _settings;

		public SampleJsonDataGenerator()
		{
			_settings = new SampleJsonDataGeneratorSettings();
		}

		public SampleJsonDataGenerator(SampleJsonDataGeneratorSettings settings)
		{
			_settings = settings;
		}

		public JToken Generate(JsonSchema schema)
		{
			Stack<JsonSchema> stack = new Stack<JsonSchema>();
			stack.Push(schema);
			return Generate(schema, stack);
		}

		private JToken Generate(JsonSchema schema, Stack<JsonSchema> schemaStack)
		{
			JsonSchemaProperty property = schema as JsonSchemaProperty;
			schema = schema.ActualSchema;
			try
			{
				schemaStack.Push(schema);
				if (schemaStack.Count((JsonSchema s) => s == schema) > _settings.MaxRecursionLevel)
				{
					return null;
				}
				if (schema.Type.IsObject() || GetPropertiesToGenerate(schema.AllOf).Any())
				{
					IEnumerable<JsonSchema> schemas = new JsonSchema[1] { schema }.Concat(schema.AllOf.Select((JsonSchema x) => x.ActualSchema));
					IEnumerable<KeyValuePair<string, JsonSchemaProperty>> propertiesToGenerate = GetPropertiesToGenerate(schemas);
					JObject jObject = new JObject();
					foreach (KeyValuePair<string, JsonSchemaProperty> item in propertiesToGenerate)
					{
						jObject[item.Key] = Generate(item.Value, schemaStack);
					}
					return jObject;
				}
				if (schema.Default != null)
				{
					return JToken.FromObject(schema.Default);
				}
				if (schema.Type.IsArray())
				{
					if (schema.Item != null)
					{
						JArray jArray = new JArray();
						JToken jToken = Generate(schema.Item, schemaStack);
						if (jToken != null)
						{
							jArray.Add(jToken);
						}
						return jArray;
					}
					if (schema.Items.Count > 0)
					{
						JArray jArray2 = new JArray();
						foreach (JsonSchema item2 in schema.Items)
						{
							jArray2.Add(Generate(item2, schemaStack));
						}
						return jArray2;
					}
				}
				else
				{
					if (schema.IsEnumeration)
					{
						return JToken.FromObject(schema.Enumeration.First());
					}
					if (schema.Type.IsInteger())
					{
						return HandleIntegerType(schema);
					}
					if (schema.Type.IsNumber())
					{
						return HandleNumberType(schema);
					}
					if (schema.Type.IsString())
					{
						return HandleStringType(schema, property);
					}
					if (schema.Type.IsBoolean())
					{
						return JToken.FromObject(false);
					}
				}
				return null;
			}
			finally
			{
				schemaStack.Pop();
			}
		}

		private JToken HandleNumberType(JsonSchema schema)
		{
			if (schema.ExclusiveMinimumRaw != null)
			{
				return JToken.FromObject((decimal)((double)float.Parse(schema.Minimum.ToString()) + 0.1));
			}
			if (schema.ExclusiveMinimum.HasValue)
			{
				return JToken.FromObject(decimal.Parse(schema.ExclusiveMinimum.ToString()));
			}
			if (schema.Minimum.HasValue)
			{
				return decimal.Parse(schema.Minimum.ToString());
			}
			return JToken.FromObject(0.0);
		}

		private JToken HandleIntegerType(JsonSchema schema)
		{
			if (schema.ExclusiveMinimumRaw != null)
			{
				return JToken.FromObject(Convert.ToInt32(schema.ExclusiveMinimumRaw));
			}
			if (schema.ExclusiveMinimum.HasValue)
			{
				return JToken.FromObject(Convert.ToInt32(schema.ExclusiveMinimum));
			}
			if (schema.Minimum.HasValue)
			{
				return Convert.ToInt32(schema.Minimum);
			}
			return JToken.FromObject(0);
		}

		private JToken HandleStringType(JsonSchema schema, JsonSchemaProperty property)
		{
			if (schema.Format == "date")
			{
				return JToken.FromObject(DateTimeOffset.UtcNow.ToString("yyyy-MM-dd"));
			}
			if (schema.Format == "date-time")
			{
				return JToken.FromObject(DateTimeOffset.UtcNow.ToString("o"));
			}
			if (property != null)
			{
				return JToken.FromObject(property.Name);
			}
			return JToken.FromObject("");
		}

		private IEnumerable<KeyValuePair<string, JsonSchemaProperty>> GetPropertiesToGenerate(IEnumerable<JsonSchema> schemas)
		{
			return schemas.SelectMany(GetPropertiesToGenerate);
		}

		private IEnumerable<KeyValuePair<string, JsonSchemaProperty>> GetPropertiesToGenerate(JsonSchema schema)
		{
			if (_settings.GenerateOptionalProperties)
			{
				return schema.ActualProperties;
			}
			ICollection<string> required = schema.RequiredProperties;
			return schema.ActualProperties.Where((KeyValuePair<string, JsonSchemaProperty> x) => required.Contains(x.Key));
		}
	}
}
