using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class LayoutHideIfAttribute : LayoutShowIfAttribute
	{
		public LayoutHideIfAttribute(params object[] by)
			: base((EMode)0, by)
		{
		}

		public LayoutHideIfAttribute(EMode editorMode, params object[] by)
			: base(editorMode, by)
		{
		}
	}
}
