using System;
using Namotion.Reflection;

namespace NJsonSchema.Generation
{
	public class SchemaProcessorContext
	{
		[Obsolete("Use ContextualType to obtain this instead.")]
		public Type Type => ContextualType.OriginalType;

		public ContextualType ContextualType { get; }

		public JsonSchema Schema { get; }

		public JsonSchemaResolver Resolver { get; }

		public JsonSchemaGenerator Generator { get; }

		public JsonSchemaGeneratorSettings Settings { get; }

		public SchemaProcessorContext(ContextualType contextualType, JsonSchema schema, JsonSchemaResolver resolver, JsonSchemaGenerator generator, JsonSchemaGeneratorSettings settings)
		{
			ContextualType = contextualType;
			Schema = schema;
			Resolver = resolver;
			Generator = generator;
			Settings = settings;
		}
	}
}
