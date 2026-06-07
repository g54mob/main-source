using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	public class JsonSchemaFlattenAttribute : Attribute
	{
		public bool Flatten { get; }

		public JsonSchemaFlattenAttribute()
		{
			Flatten = true;
		}

		public JsonSchemaFlattenAttribute(bool flatten)
		{
			Flatten = flatten;
		}
	}
}
