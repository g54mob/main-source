using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[IncludeMyAttributes]
	[ShowInInspector]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class ButtonGroupAttribute : PropertyGroupAttribute
	{
		public int ButtonHeight;

		private IconAlignment buttonIconAlignment;

		private int buttonAlignment;

		private bool stretch;

		public IconAlignment IconAlignment
		{
			get
			{
				return default(IconAlignment);
			}
			set
			{
			}
		}

		public int ButtonAlignment
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool Stretch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool HasDefinedButtonIconAlignment { get; private set; }

		public bool HasDefinedButtonAlignment { get; private set; }

		public bool HasDefinedStretch { get; private set; }

		public ButtonGroupAttribute(string group = "_DefaultGroup", float order = 0f)
			: base(null, 0f)
		{
		}
	}
}
