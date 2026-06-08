using System;
using System.Reflection;

namespace Castle.DynamicProxy.Internal
{
	public abstract class InheritanceInvocation : AbstractInvocation
	{
		private readonly Type targetType;

		public override object InvocationTarget => base.Proxy;

		public override MethodInfo MethodInvocationTarget => InvocationHelper.GetMethodOnType(targetType, base.Method);

		public override Type TargetType => targetType;

		protected InheritanceInvocation(Type targetType, object proxy, IInterceptor[] interceptors, MethodInfo proxiedMethod, object[] arguments)
			: base(proxy, interceptors, proxiedMethod, arguments)
		{
			this.targetType = targetType;
		}

		protected abstract override void InvokeMethodOnTarget();
	}
}
