using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class JsonSchemaPatternPropertiesAttribute : Attribute
	{
		public string RegularExpression { get; }

		public Type Type { get; }

		public JsonSchemaPatternPropertiesAttribute(string regularExpression)
			: this(regularExpression, null)
		{
		}

		public JsonSchemaPatternPropertiesAttribute(string regularExpression, Type type)
		{
			RegularExpression = regularExpression;
			Type = type;
		}
	}
}
