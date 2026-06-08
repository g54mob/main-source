using System;
using System.Reflection;

namespace Castle.DynamicProxy.Tokens
{
	public static class TypeMethods
	{
		public static readonly MethodInfo GetTypeFromHandle = typeof(Type).GetMethod("GetTypeFromHandle");

		public static readonly MethodInfo StaticGetType = typeof(Type).GetMethod("GetType", new Type[3]
		{
			typeof(string),
			typeof(bool),
			typeof(bool)
		});
	}
}
