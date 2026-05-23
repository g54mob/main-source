using System;
using System.Collections.Generic;

namespace NJsonSchema.Generation.TypeMappers
{
	public class TypeMapperContext
	{
		public Type Type { get; }

		public JsonSchemaGenerator JsonSchemaGenerator { get; }

		public JsonSchemaResolver JsonSchemaResolver { get; }

		public IEnumerable<Attribute> ParentAttributes { get; }

		public TypeMapperContext(Type type, JsonSchemaGenerator jsonSchemaGenerator, JsonSchemaResolver jsonSchemaResolver, IEnumerable<Attribute> parentAttributes)
		{
			Type = type;
			JsonSchemaGenerator = jsonSchemaGenerator;
			JsonSchemaResolver = jsonSchemaResolver;
			ParentAttributes = parentAttributes;
		}
	}
}
