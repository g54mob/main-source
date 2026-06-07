using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class EnableIfAttribute : Attribute
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

		public EnableIfAttribute(string condition)
		{
		}

		public EnableIfAttribute(string condition, object optionalValue)
		{
		}
	}
}
