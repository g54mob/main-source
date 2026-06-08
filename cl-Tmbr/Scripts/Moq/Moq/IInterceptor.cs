namespace Moq
{
	internal interface IInterceptor
	{
		void Intercept(Invocation invocation);
	}
}
