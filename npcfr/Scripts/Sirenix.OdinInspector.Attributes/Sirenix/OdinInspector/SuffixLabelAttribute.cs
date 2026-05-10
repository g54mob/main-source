using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	public sealed class SuffixLabelAttribute : Attribute
	{
		public string Label;

		public bool Overlay;

		[ColorResolver]
		public string IconColor;

		private SdfIconType icon;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "icon", "HasDefinedIcon" })]
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
