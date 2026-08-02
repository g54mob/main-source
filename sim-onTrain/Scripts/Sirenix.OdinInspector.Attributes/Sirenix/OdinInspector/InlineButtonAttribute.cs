using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class InlineButtonAttribute : Attribute
	{
		public string Action;

		public string Label;

		public string ShowIf;

		private SdfIconType icon;

		private IconAlignment buttonIconAlignment;

		[Obsolete("Use the Action member instead.", false)]
		public string MemberMethod
		{
			get
			{
				return Action;
			}
			set
			{
				Action = value;
			}
		}

		public SdfIconType Icon
		{
			get
			{
				return icon;
			}
			set
			{
				icon = value;
				HasDefinedIcon = true;
			}
		}

		public IconAlignment IconAlignment
		{
			get
			{
				return buttonIconAlignment;
			}
			set
			{
				buttonIconAlignment = value;
				HasDefinedIconAlignment = true;
			}
		}

		public bool HasDefinedIcon { get; private set; }

		public bool HasDefinedIconAlignment { get; private set; }

		public InlineButtonAttribute(string action, string label = null)
		{
			Action = action;
			Label = label;
		}

		public InlineButtonAttribute(string action, SdfIconType icon, string label = null)
		{
			Action = action;
			Icon = icon;
			Label = label;
		}
	}
}
