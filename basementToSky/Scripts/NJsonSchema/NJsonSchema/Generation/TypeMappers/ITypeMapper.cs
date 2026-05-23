using System;

namespace NJsonSchema.Generation.TypeMappers
{
	public interface ITypeMapper
	{
		Type MappedType { get; }

		bool UseReference { get; }

		void GenerateSchema(JsonSchema schema, TypeMapperContext context);
	}
}
