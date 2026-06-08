using System;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal
{
	public class CallbackHandler : PipelineHandler
	{
		public Action<IExecutionContext> OnPreInvoke { get; set; }

		public Action<IExecutionContext> OnPostInvoke { get; set; }

		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
			PostInvoke(executionContext);
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			T result = await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			PostInvoke(executionContext);
			return result;
		}

		protected void PreInvoke(IExecutionContext executionContext)
		{
			RaiseOnPreInvoke(executionContext);
		}

		protected void PostInvoke(IExecutionContext executionContext)
		{
			RaiseOnPostInvoke(executionContext);
		}

		private void RaiseOnPreInvoke(IExecutionContext context)
		{
			if (OnPreInvoke != null)
			{
				OnPreInvoke(context);
			}
		}

		private void RaiseOnPostInvoke(IExecutionContext context)
		{
			if (OnPostInvoke != null)
			{
				OnPostInvoke(context);
			}
		}
	}
}
