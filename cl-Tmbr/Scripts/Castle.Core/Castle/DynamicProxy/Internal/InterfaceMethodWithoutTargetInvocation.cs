using System;
using System.ComponentModel;
using System.Reflection;

namespace Castle.DynamicProxy.Internal
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InterfaceMethodWithoutTargetInvocation : AbstractInvocation
	{
		public override object InvocationTarget => null;

		public override MethodInfo MethodInvocationTarget => null;

		public override Type TargetType => null;

		public InterfaceMethodWithoutTargetInvocation(object target, object proxy, IInterceptor[] interceptors, MethodInfo proxiedMethod, object[] arguments)
			: base(proxy, interceptors, proxiedMethod, arguments)
		{
		}

		protected override void InvokeMethodOnTarget()
		{
			ThrowOnNoTarget();
		}
	}
}
