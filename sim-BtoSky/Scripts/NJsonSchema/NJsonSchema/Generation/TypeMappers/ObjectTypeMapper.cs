using System;

namespace NJsonSchema.Generation.TypeMappers
{
	public class ObjectTypeMapper : ITypeMapper
	{
		private readonly Func<JsonSchemaGenerator, JsonSchemaResolver, JsonSchema> _schemaFactory;

		public Type MappedType { get; }

		public bool UseReference => true;

		public ObjectTypeMapper(Type mappedType, JsonSchema schema)
			: this(mappedType, (JsonSchemaGenerator schemaGenerator, JsonSchemaResolver schemaResolver) => schema)
		{
		}

		public ObjectTypeMapper(Type mappedType, Func<JsonSchemaGenerator, JsonSchemaResolver, JsonSchema> schemaFactory)
		{
			_schemaFactory = schemaFactory;
			MappedType = mappedType;
		}

		public void GenerateSchema(JsonSchema schema, TypeMapperContext context)
		{
			if (!context.JsonSchemaResolver.HasSchema(MappedType, isIntegerEnumeration: false))
			{
				context.JsonSchemaResolver.AddSchema(MappedType, isIntegerEnumeration: false, _schemaFactory(context.JsonSchemaGenerator, context.JsonSchemaResolver));
			}
			schema.Reference = context.JsonSchemaResolver.GetSchema(MappedType, isIntegerEnumeration: false);
		}
	}
}
