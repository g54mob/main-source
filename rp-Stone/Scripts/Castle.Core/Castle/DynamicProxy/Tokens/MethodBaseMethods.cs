using System;
using System.Reflection;

namespace Castle.DynamicProxy.Tokens
{
	public static class MethodBaseMethods
	{
		public static readonly MethodInfo GetMethodFromHandle = typeof(MethodBase).GetMethod("GetMethodFromHandle", new Type[2]
		{
			typeof(RuntimeMethodHandle),
			typeof(RuntimeTypeHandle)
		});
	}
}
