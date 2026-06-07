using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[DontApplyToListElements]
	public sealed class HideIfAttribute : Attribute
	{
		public string MemberName;

		public object Value;

		public bool Animate;

		public HideIfAttribute(string memberName, bool animate = true)
		{
			MemberName = memberName;
			Animate = animate;
		}

		public HideIfAttribute(string memberName, object optionalValue, bool animate = true)
		{
			MemberName = memberName;
			Value = optionalValue;
			Animate = animate;
		}
	}
}
