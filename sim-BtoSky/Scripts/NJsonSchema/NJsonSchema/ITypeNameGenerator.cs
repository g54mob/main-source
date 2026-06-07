using System.Collections.Generic;

namespace NJsonSchema
{
	public interface ITypeNameGenerator
	{
		string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames);
	}
}
