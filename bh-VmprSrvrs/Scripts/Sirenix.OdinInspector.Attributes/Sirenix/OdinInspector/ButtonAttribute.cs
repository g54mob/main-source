using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	public class ButtonAttribute : ShowInInspectorAttribute
	{
		public string Name;

		public ButtonStyle Style;

		public bool Expanded;

		public bool DisplayParameters;

		public bool DirtyOnClick;

		public SdfIconType Icon;

		private int buttonHeight;

		private bool drawResult;

		private bool drawResultIsSet;

		private bool stretch;

		private IconAlignment buttonIconAlignment;

		private float buttonAlignment;

		public int ButtonHeight
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

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

		public float ButtonAlignment
		{
			get
			{
				return 0f;
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

		public bool DrawResult
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DrawResultIsSet => false;

		public bool HasDefinedButtonHeight { get; private set; }

		public bool HasDefinedIcon => false;

		public bool HasDefinedButtonIconAlignment { get; private set; }

		public bool HasDefinedButtonAlignment { get; private set; }

		public bool HasDefinedStretch { get; private set; }

		public ButtonAttribute()
		{
		}

		public ButtonAttribute(ButtonSizes size)
		{
		}

		public ButtonAttribute(int buttonSize)
		{
		}

		public ButtonAttribute(string name)
		{
		}

		public ButtonAttribute(string name, ButtonSizes buttonSize)
		{
		}

		public ButtonAttribute(string name, int buttonSize)
		{
		}

		public ButtonAttribute(ButtonStyle parameterBtnStyle)
		{
		}

		public ButtonAttribute(int buttonSize, ButtonStyle parameterBtnStyle)
		{
		}

		public ButtonAttribute(ButtonSizes size, ButtonStyle parameterBtnStyle)
		{
		}

		public ButtonAttribute(string name, ButtonStyle parameterBtnStyle)
		{
		}

		public ButtonAttribute(string name, ButtonSizes buttonSize, ButtonStyle parameterBtnStyle)
		{
		}

		public ButtonAttribute(string name, int buttonSize, ButtonStyle parameterBtnStyle)
		{
		}

		public ButtonAttribute(SdfIconType icon, IconAlignment iconAlignment)
		{
		}

		public ButtonAttribute(SdfIconType icon)
		{
		}

		public ButtonAttribute(SdfIconType icon, string name)
		{
		}
	}
}
