using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class HorizontalGroupAttribute : PropertyGroupAttribute
	{
		private const int DefaultHorizontalGroupGap = 3;

		public float Width;

		public float MarginLeft;

		public float MarginRight;

		public float PaddingLeft;

		public float PaddingRight;

		public float MinWidth;

		public float MaxWidth;

		public float Gap;

		public string Title;

		public bool DisableAutomaticLabelWidth;

		public float LabelWidth;

		public HorizontalGroupAttribute(string group, float width = 0f, int marginLeft = 0, int marginRight = 0, float order = 0f)
			: base(null, 0f)
		{
		}

		public HorizontalGroupAttribute(float width = 0f, int marginLeft = 0, int marginRight = 0, float order = 0f)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
