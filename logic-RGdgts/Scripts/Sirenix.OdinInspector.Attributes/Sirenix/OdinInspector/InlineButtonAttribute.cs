using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class InlineButtonAttribute : Attribute
	{
		public string Action;

		public string Label;

		public string ShowIf;

		[Obsolete]
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
	}
}
