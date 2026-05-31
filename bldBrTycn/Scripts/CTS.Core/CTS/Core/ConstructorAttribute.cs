using System;

namespace CTS.Core
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class ConstructorAttribute : Attribute
	{
		public string MethodName { get; }

		public ConstructorAttribute(string methodName)
		{
			MethodName = methodName;
		}
	}
}
