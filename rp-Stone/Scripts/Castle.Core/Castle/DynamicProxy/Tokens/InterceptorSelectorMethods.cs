using System.Reflection;

namespace Castle.DynamicProxy.Tokens
{
	public static class InterceptorSelectorMethods
	{
		public static readonly MethodInfo SelectInterceptors = typeof(IInterceptorSelector).GetMethod("SelectInterceptors", BindingFlags.Instance | BindingFlags.Public);
	}
}
