using System;

namespace NJsonSchema.Generation
{
	public interface ISchemaNameGenerator
	{
		string Generate(Type type);
	}
}
