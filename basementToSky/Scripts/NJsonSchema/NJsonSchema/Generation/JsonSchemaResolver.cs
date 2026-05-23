using System;
using System.Collections.Generic;

namespace NJsonSchema.Generation
{
	public class JsonSchemaResolver : JsonSchemaAppender
	{
		private readonly Dictionary<string, JsonSchema> _mappings = new Dictionary<string, JsonSchema>();

		private readonly JsonSchemaGeneratorSettings _settings;

		public IEnumerable<JsonSchema> Schemas => _mappings.Values;

		public JsonSchemaResolver(object rootObject, JsonSchemaGeneratorSettings settings)
			: base(rootObject, settings.TypeNameGenerator)
		{
			_settings = settings;
		}

		public bool HasSchema(Type type, bool isIntegerEnumeration)
		{
			return _mappings.ContainsKey(GetTypeKey(type, isIntegerEnumeration));
		}

		public JsonSchema GetSchema(Type type, bool isIntegerEnumeration)
		{
			return _mappings[GetTypeKey(type, isIntegerEnumeration)];
		}

		public virtual void AddSchema(Type type, bool isIntegerEnumeration, JsonSchema schema)
		{
			if (schema.GetType() != typeof(JsonSchema))
			{
				throw new InvalidOperationException("Added schema is not a JsonSchema4 instance.");
			}
			if (schema != base.RootObject)
			{
				AppendSchema(schema, _settings.SchemaNameGenerator.Generate(type));
			}
			_mappings.Add(GetTypeKey(type, isIntegerEnumeration), schema);
		}

		protected virtual string GetTypeKey(Type type, bool isIntegerEnum)
		{
			return type.FullName + (isIntegerEnum ? ":Integer" : string.Empty);
		}
	}
}
