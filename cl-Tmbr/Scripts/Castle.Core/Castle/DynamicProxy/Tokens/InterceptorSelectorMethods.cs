using System.Reflection;

namespace Castle.DynamicProxy.Tokens
{
	internal static class InterceptorSelectorMethods
	{
		public static readonly MethodInfo SelectInterceptors = typeof(IInterceptorSelector).GetMethod("SelectInterceptors", BindingFlags.Instance | BindingFlags.Public);
	}
}
