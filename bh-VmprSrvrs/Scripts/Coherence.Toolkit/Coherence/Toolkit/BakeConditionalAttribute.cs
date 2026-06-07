using System;

namespace Coherence.Toolkit
{
	[AttributeUsage(AttributeTargets.Class)]
	public class BakeConditionalAttribute : Attribute
	{
		public string Condition;

		public BakeConditionalAttribute(string condition)
		{
		}
	}
}
