using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class DOTweenPlayEndAttribute : LayoutEndAttribute
	{
		public DOTweenPlayEndAttribute(string groupBy)
			: base(string.IsNullOrEmpty(groupBy) ? "__SAINTSFIELD_DOTWEEN_PLAY__" : (groupBy + "/__SAINTSFIELD_DOTWEEN_PLAY__"))
		{
		}
	}
}
