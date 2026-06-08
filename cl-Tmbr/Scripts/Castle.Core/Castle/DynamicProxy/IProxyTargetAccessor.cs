namespace Castle.DynamicProxy
{
	public interface IProxyTargetAccessor
	{
		object DynProxyGetTarget();

		void DynProxySetTarget(object target);

		IInterceptor[] GetInterceptors();
	}
}
