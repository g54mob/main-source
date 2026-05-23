using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
	public class JsonSchemaExtensionDataAttribute : Attribute, IJsonSchemaExtensionDataAttribute
	{
		public string Key { get; }

		public object Value { get; }

		public JsonSchemaExtensionDataAttribute(string key, object value)
		{
			Key = key;
			Value = value;
		}
	}
}
