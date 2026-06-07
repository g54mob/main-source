using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class LayoutCloseHereAttribute : Attribute, IPlayaAttribute, ISaintsLayout, ISaintsLayoutBase
	{
		public string LayoutBy { get; }

		public ELayout Layout { get; }

		public bool KeepGrouping { get; }

		public float MarginTop { get; }

		public float MarginBottom { get; }

		public LayoutCloseHereAttribute(ELayout layout = ELayout.Vertical, float marginTop = -1f, float marginBottom = -1f)
		{
			LayoutBy = ".";
			Layout = layout;
			KeepGrouping = false;
			MarginTop = marginTop;
			MarginBottom = marginBottom;
		}
	}
}
