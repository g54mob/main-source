using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class LayoutDisableIfAttribute : LayoutReadOnlyAttribute
	{
		public LayoutDisableIfAttribute(params object[] by)
			: base(by)
		{
		}
	}
}
