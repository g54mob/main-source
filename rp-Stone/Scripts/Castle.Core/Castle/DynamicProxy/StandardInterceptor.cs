using System;

namespace Castle.DynamicProxy
{
	[Serializable]
	public class StandardInterceptor : MarshalByRefObject, IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			PreProceed(invocation);
			PerformProceed(invocation);
			PostProceed(invocation);
		}

		protected virtual void PerformProceed(IInvocation invocation)
		{
			invocation.Proceed();
		}

		protected virtual void PreProceed(IInvocation invocation)
		{
		}

		protected virtual void PostProceed(IInvocation invocation)
		{
		}
	}
}
