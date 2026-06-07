using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class LayoutEndAttribute : Attribute, IPlayaAttribute, ISaintsLayout, ISaintsLayoutBase
	{
		public string LayoutBy { get; }

		public ELayout Layout => ELayout.Vertical;

		public bool KeepGrouping => false;

		public float MarginTop { get; }

		public float MarginBottom { get; }

		public LayoutEndAttribute(string layoutBy = null, float marginTop = -1f, float marginBottom = -1f)
		{
			LayoutBy = layoutBy?.Trim('/');
			MarginTop = marginTop;
			MarginBottom = marginBottom;
		}
	}
}
