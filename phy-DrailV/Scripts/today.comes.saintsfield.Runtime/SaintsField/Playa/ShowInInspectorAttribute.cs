using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public class ShowInInspectorAttribute : Attribute, IPlayaAttribute
	{
	}
}
