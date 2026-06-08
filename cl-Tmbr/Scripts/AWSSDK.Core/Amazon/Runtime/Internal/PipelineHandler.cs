using System;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public abstract class PipelineHandler : IPipelineHandler
	{
		public virtual ILogger Logger { get; set; }

		public IPipelineHandler InnerHandler { get; set; }

		public IPipelineHandler OuterHandler { get; set; }

		public virtual void InvokeSync(IExecutionContext executionContext)
		{
			if (InnerHandler != null)
			{
				InnerHandler.InvokeSync(executionContext);
				return;
			}
			throw new InvalidOperationException("Cannot invoke InnerHandler. InnerHandler is not set.");
		}

		public virtual Task<T> InvokeAsync<T>(IExecutionContext executionContext) where T : AmazonWebServiceResponse, new()
		{
			if (InnerHandler != null)
			{
				return InnerHandler.InvokeAsync<T>(executionContext);
			}
			throw new InvalidOperationException("Cannot invoke InnerHandler. InnerHandler is not set.");
		}

		protected void LogMetrics(IExecutionContext executionContext)
		{
			RequestMetrics metrics = executionContext.RequestContext.Metrics;
			if (executionContext.RequestContext.ClientConfig.LogMetrics)
			{
				string errors = metrics.GetErrors();
				if (!string.IsNullOrEmpty(errors))
				{
					Logger.InfoFormat("Request metrics errors: {0}", errors);
				}
				Logger.InfoFormat("Request metrics: {0}", metrics);
			}
		}
	}
}
