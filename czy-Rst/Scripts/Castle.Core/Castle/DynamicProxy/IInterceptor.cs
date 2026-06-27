namespace Castle.DynamicProxy
{
	public interface IInterceptor
	{
		void Intercept(IInvocation invocation);
	}
}
