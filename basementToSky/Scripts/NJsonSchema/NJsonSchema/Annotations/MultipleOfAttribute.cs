using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Property)]
	public class MultipleOfAttribute : Attribute
	{
		public decimal MultipleOf { get; private set; }

		public MultipleOfAttribute(double multipleOf)
		{
			MultipleOf = (decimal)multipleOf;
		}

		public MultipleOfAttribute(decimal multipleOf)
		{
			MultipleOf = multipleOf;
		}
	}
}
