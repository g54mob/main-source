using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	public class JsonSchemaAbstractAttribute : Attribute
	{
		public bool IsAbstract { get; }

		public JsonSchemaAbstractAttribute()
		{
			IsAbstract = true;
		}

		public JsonSchemaAbstractAttribute(bool isAbstract)
		{
			IsAbstract = isAbstract;
		}
	}
}
