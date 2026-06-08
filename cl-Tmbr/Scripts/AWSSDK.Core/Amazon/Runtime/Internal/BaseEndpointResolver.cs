using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Telemetry.Metrics;

namespace Amazon.Runtime.Internal
{
	public class BaseEndpointResolver : PipelineHandler
	{
		private static readonly string[] SupportedAuthSchemas = new string[3] { "sigv4-s3express", "sigv4", "sigv4a" };

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

		protected virtual void PreInvoke(IExecutionContext executionContext)
		{
			using (MetricsUtilities.MeasureDuration(executionContext.RequestContext, "client.call.resolve_endpoint_duration"))
			{
				ProcessRequestHandlers(executionContext);
			}
		}

		public virtual void ProcessRequestHandlers(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			EndpointParameters parameters = MapEndpointsParameters(requestContext);
			IClientConfig clientConfig = requestContext.ClientConfig;
			Endpoint endpoint = GetEndpoint(executionContext, parameters);
			requestContext.Request.Endpoint = new Uri(endpoint.URL);
			requestContext.Request.EndpointAttributes = endpoint.Attributes;
			if (clientConfig.UseHttp && string.IsNullOrEmpty(requestContext.ClientConfig.ServiceURL))
			{
				UriBuilder uriBuilder = new UriBuilder(requestContext.Request.Endpoint)
				{
					Scheme = Uri.UriSchemeHttp,
					Port = (requestContext.Request.Endpoint.IsDefaultPort ? (-1) : requestContext.Request.Endpoint.Port)
				};
				requestContext.Request.Endpoint = uriBuilder.Uri;
			}
			if (!string.IsNullOrEmpty(requestContext.ClientConfig.ServiceURL))
			{
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.ENDPOINT_OVERRIDE);
			}
			SetAuthenticationAndHeaders(requestContext.Request, endpoint);
			ServiceSpecificHandler(executionContext, parameters);
			if (!string.IsNullOrEmpty(clientConfig.AuthenticationRegion))
			{
				requestContext.Request.AuthenticationRegion = clientConfig.AuthenticationRegion;
			}
		}

		public virtual Endpoint GetEndpoint(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			EndpointParameters parameters = MapEndpointsParameters(requestContext);
			return GetEndpoint(executionContext, parameters);
		}

		private Endpoint GetEndpoint(IExecutionContext executionContext, EndpointParameters parameters)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			IClientConfig clientConfig = requestContext.ClientConfig;
			Endpoint endpoint = null;
			if (GlobalEndpoints.Provider != null)
			{
				endpoint = GlobalEndpoints.Provider.ResolveEndpoint(requestContext.ServiceMetaData?.ServiceId, parameters);
			}
			else if (endpoint == null && clientConfig.EndpointProvider != null)
			{
				endpoint = clientConfig.EndpointProvider.ResolveEndpoint(parameters);
			}
			if (!endpoint.URL.EndsWith("/") && (string.IsNullOrEmpty(requestContext.Request.ResourcePath) || requestContext.Request.ResourcePath == "/"))
			{
				endpoint.URL += "/";
			}
			return endpoint;
		}

		protected virtual void ServiceSpecificHandler(IExecutionContext executionContext, EndpointParameters parameters)
		{
		}

		private static void SetAuthenticationAndHeaders(IRequest request, Endpoint endpoint)
		{
			if (endpoint.Attributes != null)
			{
				IList list = (IList)endpoint.Attributes["authSchemes"];
				if (list != null)
				{
					bool flag = false;
					bool flag2 = list.Count > 1;
					foreach (PropertyBag item in list)
					{
						string text = (string)item["name"];
						if (!SupportedAuthSchemas.Contains(text))
						{
							continue;
						}
						switch (text)
						{
						case "sigv4-s3express":
						case "sigv4":
						{
							request.SignatureVersion = SignatureVersion.SigV4;
							string text3 = (string)item["signingRegion"];
							if (!string.IsNullOrEmpty(text3))
							{
								request.AuthenticationRegion = text3;
							}
							ApplyCommonSchema(request, item);
							break;
						}
						case "sigv4a":
						{
							if (flag2 && !IsCrtDependencyAvailable())
							{
								continue;
							}
							request.SignatureVersion = SignatureVersion.SigV4a;
							string[] value = ((List<object>)item["signingRegionSet"]).OfType<string>().ToArray();
							string text2 = string.Join(",", value);
							if (!string.IsNullOrEmpty(text2))
							{
								request.AuthenticationRegion = text2;
							}
							ApplyCommonSchema(request, item);
							break;
						}
						}
						flag = true;
						break;
					}
					if (!flag && list.Count > 0)
					{
						throw new AmazonClientException("Cannot find supported authentication schema");
					}
				}
			}
			if (endpoint.Headers == null)
			{
				return;
			}
			foreach (KeyValuePair<string, IList<string>> header in endpoint.Headers)
			{
				request.Headers[header.Key] = string.Join(",", header.Value.ToArray());
			}
		}

		private static void ApplyCommonSchema(IRequest request, PropertyBag schema)
		{
			string text = (string)schema["signingName"];
			if (!string.IsNullOrEmpty(text))
			{
				request.OverrideSigningServiceName = text;
			}
			object obj = schema["disableDoubleEncoding"];
			if (obj != null)
			{
				request.UseDoubleEncoding = !(bool)obj;
			}
		}

		private static bool IsCrtDependencyAvailable()
		{
			try
			{
				return new AWS4aSignerCRTWrapper() != null;
			}
			catch (AWSCommonRuntimeException)
			{
				return false;
			}
		}

		protected static void InjectHostPrefix(IRequestContext requestContext)
		{
			if (!requestContext.ClientConfig.DisableHostPrefixInjection && !string.IsNullOrEmpty(requestContext.Request.HostPrefix))
			{
				UriBuilder uriBuilder = new UriBuilder(requestContext.Request.Endpoint);
				uriBuilder.Host = requestContext.Request.HostPrefix + uriBuilder.Host;
				requestContext.Request.Endpoint = uriBuilder.Uri;
			}
		}

		protected virtual EndpointParameters MapEndpointsParameters(IRequestContext requestContext)
		{
			return null;
		}
	}
}
