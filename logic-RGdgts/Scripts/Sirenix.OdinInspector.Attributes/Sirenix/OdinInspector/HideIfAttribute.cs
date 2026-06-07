using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class HideIfAttribute : Attribute
	{
		public string Condition;

		public object Value;

		public bool Animate;

		[Obsolete]
		public string MemberName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public HideIfAttribute(string condition, bool animate = true)
		{
		}

		public HideIfAttribute(string condition, object optionalValue, bool animate = true)
		{
		}
	}
}
