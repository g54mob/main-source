using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[IncludeMyAttributes]
	[ShowInInspector]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class ResponsiveButtonGroupAttribute : PropertyGroupAttribute
	{
		public ButtonSizes DefaultButtonSize;

		public bool UniformLayout;

		public ResponsiveButtonGroupAttribute(string group = "_DefaultResponsiveButtonGroup")
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
