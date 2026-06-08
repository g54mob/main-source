using System.Reflection;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Tokens
{
	public static class TypeUtilMethods
	{
		public static readonly MethodInfo Sort = typeof(TypeUtil).GetMethod("Sort", BindingFlags.Static | BindingFlags.Public);

		public static readonly MethodInfo GetTypeOrNull = typeof(TypeUtil).GetMethod("GetTypeOrNull", BindingFlags.Static | BindingFlags.Public);
	}
}
