using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class LayoutStartAttribute : LayoutAttribute
	{
		public LayoutStartAttribute(string layoutBy, ELayout layout = ELayout.Vertical, float marginTop = -1f, float marginBottom = -1f)
			: base(layoutBy, layout, keepGrouping: true, marginTop, marginBottom)
		{
		}
	}
}
