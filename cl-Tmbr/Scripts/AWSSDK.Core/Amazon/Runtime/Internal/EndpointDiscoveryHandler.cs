using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Amazon.Util;

namespace Amazon.Runtime.Internal
{
	public class EndpointDiscoveryHandler : PipelineHandler
	{
		private const int INVALID_ENDPOINT_EXCEPTION_STATUSCODE = 421;

		public override void InvokeSync(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			Uri endpoint = requestContext.Request.Endpoint;
			ImmutableCredentials credentials = null;
			if (requestContext.Identity is AWSCredentials aWSCredentials)
			{
				credentials = aWSCredentials.GetCredentials();
			}
			PreInvoke(executionContext, credentials);
			try
			{
				base.InvokeSync(executionContext);
			}
			catch (Exception exception)
			{
				if (IsInvalidEndpointException(exception))
				{
					EvictCacheKeyForRequest(requestContext, endpoint, credentials);
				}
				throw;
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			Uri regionalEndpoint = requestContext.Request.Endpoint;
			ImmutableCredentials immutableCredentials = null;
			if (requestContext.Identity is AWSCredentials aWSCredentials)
			{
				immutableCredentials = await aWSCredentials.GetCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			PreInvoke(executionContext, immutableCredentials);
			try
			{
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception source)
			{
				ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(source);
				if (IsInvalidEndpointException(exceptionDispatchInfo.SourceException))
				{
					EvictCacheKeyForRequest(requestContext, regionalEndpoint, immutableCredentials);
				}
				exceptionDispatchInfo.Throw();
			}
			throw new AmazonClientException("Neither a response was returned nor an exception was thrown in the Runtime EndpointDiscoveryResolver.");
		}

		protected static void PreInvoke(IExecutionContext executionContext, ImmutableCredentials credentials)
		{
			DiscoverEndpoints(executionContext.RequestContext, evictCacheKey: false, credentials);
		}

		public static void EvictCacheKeyForRequest(IRequestContext requestContext, Uri regionalEndpoint, ImmutableCredentials credentials)
		{
			DiscoverEndpoints(requestContext, evictCacheKey: true, credentials);
			requestContext.Request.Endpoint = regionalEndpoint;
		}

		public static void DiscoverEndpoints(IRequestContext requestContext, bool evictCacheKey, ImmutableCredentials credentials)
		{
			IEnumerable<DiscoveryEndpointBase> enumerable = ProcessEndpointDiscovery(requestContext, evictCacheKey, requestContext.Request.Endpoint, credentials);
			if (enumerable == null)
			{
				return;
			}
			foreach (DiscoveryEndpointBase item in enumerable)
			{
				if (item.Address != null)
				{
					requestContext.Request.Endpoint = new Uri(item.Address);
					break;
				}
			}
		}

		private static IEnumerable<DiscoveryEndpointBase> ProcessEndpointDiscovery(IRequestContext requestContext, bool evictCacheKey, Uri evictUri, ImmutableCredentials credentials)
		{
			InvokeOptionsBase options = requestContext.Options;
			if (options.EndpointDiscoveryMarshaller != null && options.EndpointOperation != null && credentials != null)
			{
				EndpointDiscoveryDataBase endpointDiscoveryDataBase = options.EndpointDiscoveryMarshaller.Marshall(requestContext.OriginalRequest);
				string operationName = string.Empty;
				if (endpointDiscoveryDataBase.Identifiers != null && endpointDiscoveryDataBase.Identifiers.Count > 0)
				{
					operationName = AWSSDKUtils.ExtractOperationName(requestContext.RequestName);
				}
				return options.EndpointOperation(new EndpointOperationContext(credentials.AccessKey, operationName, endpointDiscoveryDataBase, evictCacheKey, evictUri));
			}
			return null;
		}

		private static bool IsInvalidEndpointException(Exception exception)
		{
			if (exception is AmazonServiceException { StatusCode: HttpStatusCode.MisdirectedRequest })
			{
				return true;
			}
			return false;
		}
	}
}
