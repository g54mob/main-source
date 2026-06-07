using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public sealed class CustomContextMenuAttribute : Attribute
	{
		public string MenuItem;

		public string Action;

		[Obsolete]
		public string MethodName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CustomContextMenuAttribute(string menuItem, string action)
		{
		}
	}
}
