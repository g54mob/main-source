using System;
using System.Diagnostics;

namespace Animancer
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ThresholdLabelAttribute : Attribute
	{
		public ThresholdLabelAttribute(string label)
		{
		}
	}
}
