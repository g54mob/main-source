using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class DisableIfAttribute : Attribute
	{
		public string Condition;

		public object Value;

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

		public DisableIfAttribute(string condition)
		{
		}

		public DisableIfAttribute(string condition, object optionalValue)
		{
		}
	}
}
