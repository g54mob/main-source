using System;
using System.ComponentModel;
using System.Reflection;

namespace Castle.DynamicProxy.Internal
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InheritanceInvocationWithoutTarget : InheritanceInvocation
	{
		public InheritanceInvocationWithoutTarget(Type targetType, object proxy, IInterceptor[] interceptors, MethodInfo proxiedMethod, object[] arguments)
			: base(targetType, proxy, interceptors, proxiedMethod, arguments)
		{
		}

		protected override void InvokeMethodOnTarget()
		{
			ThrowOnNoTarget();
		}
	}
}
