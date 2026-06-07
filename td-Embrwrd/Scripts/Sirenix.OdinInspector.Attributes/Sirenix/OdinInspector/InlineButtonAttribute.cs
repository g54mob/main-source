using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class InlineButtonAttribute : Attribute
	{
		public string Action;

		public string Label;

		public string ShowIf;

		public string ButtonColor;

		public string TextColor;

		public SdfIconType Icon;

		public IconAlignment IconAlignment;

		[Obsolete("Use the Action member instead.", false)]
		public string MemberMethod
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public InlineButtonAttribute(string action, string label = null)
		{
		}

		public InlineButtonAttribute(string action, SdfIconType icon, string label = null)
		{
		}
	}
}
