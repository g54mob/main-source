using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	public sealed class SuffixLabelAttribute : Attribute
	{
		public string Label;

		public bool Overlay;

		public SuffixLabelAttribute(string label, bool overlay = false)
		{
			Label = label;
			Overlay = overlay;
		}
	}
}
