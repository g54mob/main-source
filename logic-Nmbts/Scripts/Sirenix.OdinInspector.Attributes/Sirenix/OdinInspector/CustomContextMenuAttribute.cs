using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class CustomContextMenuAttribute : Attribute
	{
		public string MenuItem;

		public string MethodName;

		public CustomContextMenuAttribute(string menuItem, string methodName)
		{
			MenuItem = menuItem;
			MethodName = methodName;
		}
	}
}
