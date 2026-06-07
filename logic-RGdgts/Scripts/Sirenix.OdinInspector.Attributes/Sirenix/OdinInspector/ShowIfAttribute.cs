using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class ShowIfAttribute : Attribute
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

		public ShowIfAttribute(string condition, bool animate = true)
		{
		}

		public ShowIfAttribute(string condition, object optionalValue, bool animate = true)
		{
		}
	}
}
