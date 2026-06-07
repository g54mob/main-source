using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	public class ButtonAttribute : ShowInInspectorAttribute
	{
		[PropertyOrder(-10f)]
		public string Name;

		[PropertyOrder(-9f)]
		public ButtonStyle Style;

		public bool Expanded;

		public bool DisplayParameters;

		public bool DirtyOnClick;

		[PropertyOrder(-8f)]
		public SdfIconType Icon;

		private int buttonHeight;

		private bool drawResult;

		private bool drawResultIsSet;

		private bool stretch;

		private IconAlignment buttonIconAlignment;

		private float buttonAlignment;

		[PropertyOrder(-6f)]
		[ShowInInspector]
		[ButtonHeightSelector]
		[OdinDesignerBinding(new string[] { "buttonHeight", "HasDefinedButtonHeight" })]
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

		[PropertyOrder(-7f)]
		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "buttonIconAlignment", "HasDefinedButtonIconAlignment" })]
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

		[PropertyOrder(-5f)]
		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "buttonAlignment", "HasDefinedButtonAlignment" })]
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

		[PropertyOrder(-4f)]
		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "stretch", "HasDefinedStretch" })]
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

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "drawResult", "drawResultIsSet" })]
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
