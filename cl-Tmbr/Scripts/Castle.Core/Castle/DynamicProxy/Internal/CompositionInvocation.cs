using System;
using System.Reflection;

namespace Castle.DynamicProxy.Internal
{
	public abstract class CompositionInvocation : AbstractInvocation
	{
		protected object target;

		public override object InvocationTarget => target;

		public override MethodInfo MethodInvocationTarget => InvocationHelper.GetMethodOnObject(target, base.Method);

		public override Type TargetType => TypeUtil.GetTypeOrNull(target);

		protected CompositionInvocation(object target, object proxy, IInterceptor[] interceptors, MethodInfo proxiedMethod, object[] arguments)
			: base(proxy, interceptors, proxiedMethod, arguments)
		{
			this.target = target;
		}

		protected void EnsureValidProxyTarget(object newTarget)
		{
			if (newTarget == null)
			{
				throw new ArgumentNullException("newTarget");
			}
			if (newTarget != proxyObject)
			{
				return;
			}
			throw new InvalidOperationException("This is a DynamicProxy2 error: target of proxy has been set to the proxy itself. This would result in recursively calling proxy methods over and over again until stack overflow, which may destabilize your program.This usually signifies a bug in the calling code. Make sure no interceptor sets proxy as its own target.");
		}

		protected void EnsureValidTarget()
		{
			if (target == null)
			{
				ThrowOnNoTarget();
			}
			if (target != proxyObject)
			{
				return;
			}
			throw new InvalidOperationException("This is a DynamicProxy2 error: target of invocation has been set to the proxy itself. This may result in recursively calling the method over and over again until stack overflow, which may destabilize your program.This usually signifies a bug in the calling code. Make sure no interceptor sets proxy as its invocation target.");
		}
	}
}
