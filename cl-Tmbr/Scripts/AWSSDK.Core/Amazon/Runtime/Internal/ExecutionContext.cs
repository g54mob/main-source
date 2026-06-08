using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime.Internal
{
	public class ExecutionContext : IExecutionContext
	{
		public IRequestContext RequestContext { get; private set; }

		public IResponseContext ResponseContext { get; private set; }

		public ExecutionContext(bool enableMetrics, ISigner clientSigner)
		{
			RequestContext = new RequestContext(enableMetrics, clientSigner);
			ResponseContext = new ResponseContext();
		}

		public ExecutionContext(IRequestContext requestContext, IResponseContext responseContext)
		{
			RequestContext = requestContext;
			ResponseContext = responseContext;
		}
	}
}
