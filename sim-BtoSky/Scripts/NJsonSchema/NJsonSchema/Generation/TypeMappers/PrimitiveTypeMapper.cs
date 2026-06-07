using System;

namespace NJsonSchema.Generation.TypeMappers
{
	public class PrimitiveTypeMapper : ITypeMapper
	{
		private readonly Action<JsonSchema> _transformer;

		public Type MappedType { get; }

		public bool UseReference { get; }

		public PrimitiveTypeMapper(Type mappedType, Action<JsonSchema> transformer)
		{
			_transformer = transformer;
			MappedType = mappedType;
		}

		public void GenerateSchema(JsonSchema schema, TypeMapperContext context)
		{
			_transformer(schema);
		}
	}
}
