using System;

namespace Sirenix.OdinInspector
{
	public class CustomValueDrawerAttribute : Attribute
	{
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

		public CustomValueDrawerAttribute(string action)
		{
		}
	}
}
