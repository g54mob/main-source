using System;
using NJsonSchema.Converters;

namespace NJsonSchema.Generation.SchemaProcessors
{
	public class DiscriminatorSchemaProcessor : ISchemaProcessor
	{
		public Type BaseType { get; }

		public string Discriminator { get; }

		public DiscriminatorSchemaProcessor(Type baseType)
			: this(baseType, JsonInheritanceConverter.DefaultDiscriminatorName)
		{
		}

		public DiscriminatorSchemaProcessor(Type baseType, string discriminator)
		{
			BaseType = baseType;
			Discriminator = discriminator;
		}

		public void Process(SchemaProcessorContext context)
		{
			if (context.ContextualType.OriginalType == BaseType)
			{
				JsonSchema schema = context.Schema;
				schema.Discriminator = Discriminator;
				schema.Properties[Discriminator] = new JsonSchemaProperty
				{
					Type = JsonObjectType.String,
					IsRequired = true
				};
			}
		}
	}
}
