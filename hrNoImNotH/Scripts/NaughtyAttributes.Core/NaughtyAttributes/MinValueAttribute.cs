using System;

namespace NaughtyAttributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class MinValueAttribute : ValidatorAttribute
	{
		public float MinValue { get; private set; }

		public MinValueAttribute(float minValue)
		{
		}

		public MinValueAttribute(int minValue)
		{
		}
	}
}
