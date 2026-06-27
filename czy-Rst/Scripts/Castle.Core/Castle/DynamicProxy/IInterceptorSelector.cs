using System;
using System.Reflection;

namespace Castle.DynamicProxy
{
	public interface IInterceptorSelector
	{
		IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors);
	}
}
