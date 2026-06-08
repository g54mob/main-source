using System;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal
{
	public class ErrorCallbackHandler : PipelineHandler
	{
		public Action<IExecutionContext, Exception> OnError { get; set; }

		public override void InvokeSync(IExecutionContext executionContext)
		{
			try
			{
				base.InvokeSync(executionContext);
			}
			catch (Exception exception)
			{
				HandleException(executionContext, exception);
				throw;
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			try
			{
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				HandleException(executionContext, exception);
				throw;
			}
		}

		protected void HandleException(IExecutionContext executionContext, Exception exception)
		{
			OnError(executionContext, exception);
		}
	}
}
