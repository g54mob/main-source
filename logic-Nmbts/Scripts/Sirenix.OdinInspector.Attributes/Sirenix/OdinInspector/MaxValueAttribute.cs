using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class MaxValueAttribute : Attribute
	{
		public double MaxValue;

		public string Expression;

		public MaxValueAttribute(double maxValue)
		{
			MaxValue = maxValue;
		}

		public MaxValueAttribute(string expression)
		{
			Expression = expression;
		}
	}
}
