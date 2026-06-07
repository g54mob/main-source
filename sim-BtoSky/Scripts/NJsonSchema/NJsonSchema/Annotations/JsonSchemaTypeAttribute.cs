using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false)]
	public class JsonSchemaTypeAttribute : Attribute
	{
		public Type Type { get; }

		public bool IsNullable
		{
			get
			{
				return IsNullableRaw == true;
			}
			set
			{
				IsNullableRaw = value;
			}
		}

		public bool? IsNullableRaw { get; internal set; }

		public JsonSchemaTypeAttribute(Type type)
		{
			Type = type;
		}
	}
}
