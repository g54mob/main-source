using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.Runtime.Internal
{
	public class RedirectHandler : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			do
			{
				base.InvokeSync(executionContext);
			}
			while (HandleRedirect(executionContext));
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			T result;
			do
			{
				result = await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			while (HandleRedirect(executionContext));
			return result;
		}

		private bool HandleRedirect(IExecutionContext executionContext)
		{
			IWebResponseData httpResponse = executionContext.ResponseContext.HttpResponse;
			if (httpResponse.StatusCode >= HttpStatusCode.MultipleChoices && httpResponse.StatusCode < HttpStatusCode.BadRequest)
			{
				if (httpResponse.StatusCode == HttpStatusCode.TemporaryRedirect && httpResponse.IsHeaderPresent("location"))
				{
					IRequestContext requestContext = executionContext.RequestContext;
					string headerValue = httpResponse.GetHeaderValue("location");
					requestContext.Metrics.AddProperty(Metric.RedirectLocation, headerValue);
					if (executionContext.RequestContext.Request.IsRequestStreamRewindable() && !string.IsNullOrEmpty(headerValue))
					{
						FinalizeForRedirect(executionContext, headerValue);
						if (httpResponse.ResponseBody != null)
						{
							httpResponse.ResponseBody.Dispose();
						}
						return true;
					}
				}
				executionContext.ResponseContext.HttpResponse = null;
				throw new HttpErrorResponseException(httpResponse);
			}
			return false;
		}

		protected virtual void FinalizeForRedirect(IExecutionContext executionContext, string redirectedLocation)
		{
			Logger.InfoFormat("Request {0} is being redirected to {1}.", executionContext.RequestContext.RequestName, redirectedLocation);
			Uri uri = new Uri(redirectedLocation);
			IRequestContext requestContext = executionContext.RequestContext;
			if (uri.IsDefaultPort)
			{
				requestContext.Request.Endpoint = new UriBuilder(uri.Scheme, uri.Host).Uri;
			}
			else
			{
				requestContext.Request.Endpoint = new UriBuilder(uri.Scheme, uri.Host, uri.Port).Uri;
			}
			RetryHandler.PrepareForRetry(executionContext.RequestContext);
		}
	}
}
