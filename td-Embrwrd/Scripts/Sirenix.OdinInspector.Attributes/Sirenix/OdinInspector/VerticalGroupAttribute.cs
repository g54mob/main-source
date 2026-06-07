using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class VerticalGroupAttribute : PropertyGroupAttribute
	{
		public float PaddingTop;

		public float PaddingBottom;

		public VerticalGroupAttribute(string groupId, float order = 0f)
			: base(null, 0f)
		{
		}

		public VerticalGroupAttribute(float order = 0f)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
