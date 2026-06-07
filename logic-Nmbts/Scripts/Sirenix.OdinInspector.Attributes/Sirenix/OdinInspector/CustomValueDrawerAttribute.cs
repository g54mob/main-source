using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class CustomValueDrawerAttribute : Attribute
	{
		public string MethodName;

		public CustomValueDrawerAttribute(string methodName)
		{
			MethodName = methodName;
		}
	}
}
