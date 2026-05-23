using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
	public class JsonSchemaAttribute : Attribute
	{
		public string Name { get; set; }

		public JsonObjectType Type { get; private set; }

		public string Format { get; set; }

		public Type ArrayItem { get; set; }

		public JsonSchemaAttribute()
		{
			Type = JsonObjectType.None;
		}

		public JsonSchemaAttribute(string name)
			: this()
		{
			Name = name;
		}

		public JsonSchemaAttribute(JsonObjectType type)
		{
			Type = type;
		}
	}
}
