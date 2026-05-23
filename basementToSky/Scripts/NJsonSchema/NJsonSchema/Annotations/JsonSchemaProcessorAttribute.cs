using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class JsonSchemaProcessorAttribute : Attribute
	{
		public Type Type { get; set; }

		public object[] Parameters { get; set; }

		public JsonSchemaProcessorAttribute(Type type, params object[] parameters)
		{
			Type = type;
			Parameters = parameters;
		}
	}
}
