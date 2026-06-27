using System;

namespace Castle.DynamicProxy
{
	public interface IChangeProxyTarget
	{
		void ChangeInvocationTarget(object target);

		[Obsolete("Use ((IProxyTargetAccessor)invocation.Proxy).DynProxySetTarget(target) instead.")]
		void ChangeProxyTarget(object target);
	}
}
