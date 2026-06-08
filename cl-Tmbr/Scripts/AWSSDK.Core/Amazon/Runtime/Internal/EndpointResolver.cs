using System;
using System.Threading.Tasks;
using Amazon.Runtime.Endpoints;

namespace Amazon.Runtime.Internal
{
	public class EndpointResolver : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			return base.InvokeAsync<T>(executionContext);
		}

		protected void PreInvoke(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			if (requestContext.Request.Endpoint == null)
			{
				requestContext.Request.Endpoint = DetermineEndpoint(requestContext);
			}
		}

		public virtual Uri DetermineEndpoint(IRequestContext requestContext)
		{
			return DetermineEndpoint(requestContext.ClientConfig, requestContext.Request);
		}

		public static Uri DetermineEndpoint(IClientConfig config, IRequest request)
		{
			Uri endpoint = new Uri(config.DetermineServiceOperationEndpoint(new ServiceOperationEndpointParameters(request.OriginalRequest, request.AlternateEndpoint)).URL);
			return InjectHostPrefix(config, request, endpoint);
		}

		private static Uri InjectHostPrefix(IClientConfig config, IRequest request, Uri endpoint)
		{
			if (config.DisableHostPrefixInjection || string.IsNullOrEmpty(request.HostPrefix))
			{
				return endpoint;
			}
			UriBuilder uriBuilder = new UriBuilder(endpoint);
			uriBuilder.Host = request.HostPrefix + uriBuilder.Host;
			return uriBuilder.Uri;
		}
	}
}
