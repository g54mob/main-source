using System;
using System.Reflection;

namespace Castle.DynamicProxy.Tokens
{
	public static class DelegateMethods
	{
		public static readonly MethodInfo CreateDelegate = typeof(Delegate).GetMethod("CreateDelegate", new Type[3]
		{
			typeof(Type),
			typeof(object),
			typeof(MethodInfo)
		});
	}
}
