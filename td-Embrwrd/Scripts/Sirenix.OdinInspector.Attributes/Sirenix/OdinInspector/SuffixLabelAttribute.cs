using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	public sealed class SuffixLabelAttribute : Attribute
	{
		public string Label;

		public bool Overlay;

		public string IconColor;

		private SdfIconType icon;

		[OdinDesignerBinding(new string[] { "icon", "HasDefinedIcon" })]
		[ShowInInspector]
		public SdfIconType Icon
		{
			get
			{
				return default(SdfIconType);
			}
			set
			{
			}
		}

		public bool HasDefinedIcon { get; private set; }

		public SuffixLabelAttribute(string label, bool overlay = false)
		{
		}

		public SuffixLabelAttribute(string label, SdfIconType icon, bool overlay = false)
		{
		}

		public SuffixLabelAttribute(SdfIconType icon)
		{
		}
	}
}
