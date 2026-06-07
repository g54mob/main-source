using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class TypeFilterAttribute : Attribute
	{
		public string MemberName;

		public string DropdownTitle;

		public TypeFilterAttribute(string memberName)
		{
			MemberName = memberName;
		}
	}
}
