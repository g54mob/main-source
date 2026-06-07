using System;

namespace ExternalPropertyAttributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class MaxValueAttribute : ValidatorAttribute
	{
		public float MaxValue { get; private set; }

		public MaxValueAttribute(float maxValue)
		{
		}

		public MaxValueAttribute(int maxValue)
		{
		}
	}
}
