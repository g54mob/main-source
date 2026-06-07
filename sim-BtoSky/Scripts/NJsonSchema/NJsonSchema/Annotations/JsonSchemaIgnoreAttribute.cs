using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
	public class JsonSchemaIgnoreAttribute : Attribute
	{
	}
}
