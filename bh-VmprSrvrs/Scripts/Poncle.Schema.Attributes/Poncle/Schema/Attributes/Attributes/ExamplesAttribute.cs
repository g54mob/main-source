using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ExamplesAttribute : Attribute
	{
		public ExamplesAttribute(params int[] examples)
		{
		}

		public ExamplesAttribute(params float[] examples)
		{
		}

		public ExamplesAttribute(params bool[] examples)
		{
		}

		public ExamplesAttribute(params string[] examples)
		{
		}
	}
}
