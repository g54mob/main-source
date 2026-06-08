using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Telemetry;
using Amazon.Runtime.Telemetry.Metrics;
using Amazon.Runtime.Telemetry.Tracing;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal
{
	public class HttpHandler<TRequestContent> : PipelineHandler, IDisposable
	{
		private bool _disposed;

		private IHttpRequestFactory<TRequestContent> _requestFactory;

		public object CallbackSender { get; private set; }

		public HttpHandler(IHttpRequestFactory<TRequestContent> requestFactory, object callbackSender)
		{
			_requestFactory = requestFactory;
			CallbackSender = callbackSender;
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			IHttpRequest<TRequestContent> httpRequest = null;
			try
			{
				SetMetrics(executionContext.RequestContext);
				SetUserAgentHeader(executionContext.RequestContext);
				IRequest request = executionContext.RequestContext.Request;
				httpRequest = CreateWebRequest(executionContext.RequestContext);
				httpRequest.SetRequestHeaders(request.Headers);
				using (executionContext.RequestContext.Metrics.StartEvent(Metric.HttpRequestTime))
				{
					using TraceSpan traceSpan = TracingUtilities.CreateSpan(executionContext.RequestContext, "HttpRequest");
					using (MetricsUtilities.MeasureDuration(executionContext.RequestContext, "client.call.attempt_duration"))
					{
						if (request.HasRequestBody())
						{
							try
							{
								TRequestContent requestContent = httpRequest.GetRequestContent();
								WriteContentToRequestBody(requestContent, httpRequest, executionContext.RequestContext);
							}
							catch (Exception exception)
							{
								CompleteFailedRequest(httpRequest);
								traceSpan.CaptureException(exception);
								throw;
							}
						}
						executionContext.ResponseContext.HttpResponse = httpRequest.GetResponse();
						RecordHttpTelemetryData(executionContext, traceSpan, request);
					}
				}
			}
			finally
			{
				httpRequest?.Dispose();
			}
		}

		private static void CompleteFailedRequest(IHttpRequest<TRequestContent> httpRequest)
		{
			try
			{
				IWebResponseData webResponseData = null;
				try
				{
					webResponseData = httpRequest.GetResponse();
				}
				catch (WebException ex)
				{
					if (ex.Response != null)
					{
						ex.Response.Dispose();
					}
				}
				catch (HttpErrorResponseException ex2)
				{
					if (ex2.Response != null && ex2.Response.ResponseBody != null)
					{
						ex2.Response.ResponseBody.Dispose();
					}
				}
				finally
				{
					if (webResponseData != null && webResponseData.ResponseBody != null)
					{
						webResponseData.ResponseBody.Dispose();
					}
				}
			}
			catch
			{
			}
		}

		private static void RecordHttpTelemetryData(IExecutionContext executionContext, TraceSpan traceSpan, IRequest request)
		{
			IWebResponseData httpResponse = executionContext.ResponseContext.HttpResponse;
			Attributes attributes = new Attributes();
			attributes.Set("server.address", request.Endpoint.Host + ":" + request.Endpoint.Port);
			traceSpan.SetAttribute("http.method", request.HttpMethod);
			traceSpan.SetAttribute("http.status_code", (int)httpResponse.StatusCode);
			if (long.TryParse(request.GetHeaderValue("Content-Length"), out var result) && result > 0)
			{
				traceSpan.SetAttribute("http.request_content_length", result);
				MetricsUtilities.AddMonotonicCounterValue(executionContext.RequestContext, "client.http.bytes_sent", "By", result, attributes);
			}
			if (httpResponse.ContentLength > 0)
			{
				MetricsUtilities.AddMonotonicCounterValue(executionContext.RequestContext, "client.http.bytes_received", "By", httpResponse.ContentLength, attributes);
			}
			traceSpan.SetAttribute("http.response_content_length", httpResponse.ContentLength);
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			bool _exceptionBeingThrown = false;
			IHttpRequest<TRequestContent> httpRequest = null;
			try
			{
				SetMetrics(executionContext.RequestContext);
				SetUserAgentHeader(executionContext.RequestContext);
				IRequest wrappedRequest = executionContext.RequestContext.Request;
				httpRequest = CreateWebRequest(executionContext.RequestContext);
				httpRequest.SetRequestHeaders(wrappedRequest.Headers);
				using (executionContext.RequestContext.Metrics.StartEvent(Metric.HttpRequestTime))
				{
					using TraceSpan traceSpan = TracingUtilities.CreateSpan(executionContext.RequestContext, "HttpRequest");
					using (MetricsUtilities.MeasureDuration(executionContext.RequestContext, "client.call.attempt_duration"))
					{
						if (wrappedRequest.HasRequestBody())
						{
							ExceptionDispatchInfo edi = null;
							try
							{
								WriteContentToRequestBody(await httpRequest.GetRequestContentAsync().ConfigureAwait(continueOnCapturedContext: false), httpRequest, executionContext.RequestContext);
							}
							catch (Exception ex)
							{
								traceSpan.CaptureException(ex);
								edi = ExceptionDispatchInfo.Capture(ex);
							}
							if (edi != null)
							{
								await CompleteFailedRequest(executionContext, httpRequest).ConfigureAwait(continueOnCapturedContext: false);
								edi.Throw();
							}
						}
						IWebResponseData httpResponse = await httpRequest.GetResponseAsync(executionContext.RequestContext.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						executionContext.ResponseContext.HttpResponse = httpResponse;
						RecordHttpTelemetryData(executionContext, traceSpan, wrappedRequest);
					}
				}
				return null;
			}
			catch
			{
				_exceptionBeingThrown = true;
				throw;
			}
			finally
			{
				if (httpRequest != null && (_exceptionBeingThrown || executionContext.RequestContext.Request.HttpRequestStreamPublisher == null))
				{
					httpRequest.Dispose();
				}
			}
		}

		private static async Task CompleteFailedRequest(IExecutionContext executionContext, IHttpRequest<TRequestContent> httpRequest)
		{
			IWebResponseData iwrd = null;
			try
			{
				iwrd = await httpRequest.GetResponseAsync(executionContext.RequestContext.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch
			{
			}
			finally
			{
				if (iwrd != null && iwrd.ResponseBody != null)
				{
					iwrd.ResponseBody.Dispose();
				}
			}
		}

		private static void SetMetrics(IRequestContext requestContext)
		{
			requestContext.Metrics.AddProperty(Metric.ServiceName, requestContext.Request.ServiceName);
			requestContext.Metrics.AddProperty(Metric.ServiceEndpoint, requestContext.Request.Endpoint);
			requestContext.Metrics.AddProperty(Metric.MethodName, requestContext.Request.RequestName);
		}

		private void WriteContentToRequestBody(TRequestContent requestContent, IHttpRequest<TRequestContent> httpRequest, IRequestContext requestContext)
		{
			IRequest request = requestContext.Request;
			if (requestContext.Request.HttpRequestStreamPublisher != null)
			{
				requestContext.RequestStreamHandle = httpRequest.SetupHttpRequestStreamPublisher(requestContext.Request.Headers, requestContext.Request.HttpRequestStreamPublisher);
				return;
			}
			if (request.Content != null && request.Content.Length != 0)
			{
				byte[] content = request.Content;
				requestContext.Metrics.AddProperty(Metric.RequestSize, content.Length);
				httpRequest.WriteToRequestBody(requestContent, content, requestContext.Request.Headers);
				return;
			}
			Stream stream;
			if (request.ContentStream == null)
			{
				stream = new MemoryStream();
				stream.Write(request.Content, 0, request.Content.Length);
				stream.Position = 0L;
			}
			else
			{
				stream = request.ContentStream;
			}
			EventHandler<StreamTransferProgressArgs> streamUploadProgressCallback = ((IAmazonWebServiceRequest)request.OriginalRequest).StreamUploadProgressCallback;
			if (streamUploadProgressCallback != null)
			{
				stream = httpRequest.SetupProgressListeners(stream, requestContext.ClientConfig.ProgressUpdateInterval, CallbackSender, streamUploadProgressCallback);
			}
			Stream inputStream = GetInputStream(requestContext, stream, request);
			httpRequest.WriteToRequestBody(requestContent, inputStream, requestContext.Request.Headers, requestContext);
		}

		protected virtual IHttpRequest<TRequestContent> CreateWebRequest(IRequestContext requestContext)
		{
			IRequest request = requestContext.Request;
			Uri requestUri = AmazonServiceClient.ComposeUrl(request);
			IHttpRequest<TRequestContent> httpRequest = _requestFactory.CreateHttpRequest(requestUri);
			httpRequest.ConfigureRequest(requestContext);
			httpRequest.Method = request.HttpMethod;
			if (request.MayContainRequestBody())
			{
				byte[] array = request.Content;
				if (request.SetContentFromParameters || (array == null && request.ContentStream == null))
				{
					if (!request.UseQueryString)
					{
						string parametersAsString = AWSSDKUtils.GetParametersAsString(request);
						array = (request.Content = Encoding.UTF8.GetBytes(parametersAsString));
						request.SetContentFromParameters = true;
					}
					else
					{
						request.Content = ArrayEx.Empty<byte>();
					}
				}
				if (array != null)
				{
					request.Headers["Content-Length"] = array.Length.ToString(CultureInfo.InvariantCulture);
					return httpRequest;
				}
				if (request.ContentStream != null && request.ContentStream.CanSeek && !request.Headers.ContainsKey("Content-Length"))
				{
					request.Headers["Content-Length"] = request.ContentStream.Length.ToString(CultureInfo.InvariantCulture);
				}
			}
			return httpRequest;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				if (_requestFactory != null)
				{
					_requestFactory.Dispose();
				}
				_disposed = true;
			}
		}

		private static Stream GetInputStream(IRequestContext requestContext, Stream originalStream, IRequest wrappedRequest)
		{
			bool num = wrappedRequest.UseChunkEncoding && (wrappedRequest.AWS4SignerResult != null || wrappedRequest.AWS4aSignerResult != null);
			bool flag = wrappedRequest.Headers.ContainsKey("transfer-encoding") && wrappedRequest.Headers["transfer-encoding"] == "chunked";
			IDictionary<string, string> trailingHeaders = wrappedRequest.TrailingHeaders;
			bool flag2 = trailingHeaders != null && trailingHeaders.Count > 0;
			if (num || flag)
			{
				AWSSigningResultBase aWSSigningResultBase = ((wrappedRequest.AWS4aSignerResult == null) ? ((AWSSigningResultBase)wrappedRequest.AWS4SignerResult) : ((AWSSigningResultBase)wrappedRequest.AWS4aSignerResult));
				if (aWSSigningResultBase != null)
				{
					if (flag2)
					{
						return new ChunkedUploadWrapperStream(originalStream, requestContext.ClientConfig.BufferSize, aWSSigningResultBase, wrappedRequest.SelectedChecksum, wrappedRequest.TrailingHeaders);
					}
					return new ChunkedUploadWrapperStream(originalStream, requestContext.ClientConfig.BufferSize, aWSSigningResultBase);
				}
			}
			if (flag2)
			{
				if (wrappedRequest.SelectedChecksum != CoreChecksumAlgorithm.NONE)
				{
					return new TrailingHeadersWrapperStream(originalStream, wrappedRequest.TrailingHeaders, wrappedRequest.SelectedChecksum);
				}
				return new TrailingHeadersWrapperStream(originalStream, wrappedRequest.TrailingHeaders);
			}
			return originalStream;
		}

		private void SetUserAgentHeader(IRequestContext requestContext)
		{
			if (requestContext.Request.SignatureVersion == SignatureVersion.SigV4a)
			{
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.SIGV4A_SIGNING);
			}
			string text = requestContext.UserAgentDetails.GenerateUserAgentWithMetrics();
			Logger.DebugFormat("User-Agent Header: {0}", text);
			if (requestContext.ClientConfig.UseAlternateUserAgentHeader)
			{
				requestContext.Request.Headers["x-amz-user-agent"] = text;
			}
			else
			{
				requestContext.Request.Headers["User-Agent"] = text;
			}
		}
	}
}
