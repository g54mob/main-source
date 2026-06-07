using System;

namespace Muna
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	internal sealed class MonoPInvokeCallbackAttribute : Attribute
	{
		public MonoPInvokeCallbackAttribute(Type type)
		{
		}
	}
}
