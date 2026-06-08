using System.IO;
using System.Threading.Tasks;
using Amazon.Runtime.EventStreams.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Telemetry.Metrics;
using Amazon.Runtime.Telemetry.Tracing;

namespace Amazon.Runtime.Internal
{
	public class Signer : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			await PreInvokeAsync(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected static void PreInvoke(IExecutionContext executionContext)
		{
			if (ShouldSign(executionContext.RequestContext))
			{
				SignRequest(executionContext.RequestContext);
				executionContext.RequestContext.IsSigned = true;
			}
		}

		protected static async Task PreInvokeAsync(IExecutionContext executionContext)
		{
			if (ShouldSign(executionContext.RequestContext))
			{
				await SignRequestAsync(executionContext.RequestContext).ConfigureAwait(continueOnCapturedContext: false);
				executionContext.RequestContext.IsSigned = true;
			}
		}

		private static bool ShouldSign(IRequestContext requestContext)
		{
			if (requestContext.IsSigned)
			{
				return requestContext.ClientConfig.ResignRetries;
			}
			return true;
		}

		public static void SignRequest(IRequestContext requestContext)
		{
			if (requestContext.Identity == null && requestContext.Signer.RequiresCredentials)
			{
				return;
			}
			using (requestContext.Metrics.StartEvent(Metric.RequestSigningTime))
			{
				using (MetricsUtilities.MeasureDuration(requestContext, "client.call.auth.signing_duration"))
				{
					ImmutableCredentials immutableCredentials = null;
					if (requestContext.Identity is AWSCredentials aWSCredentials)
					{
						using (TracingUtilities.CreateSpan(requestContext, "CredentialsRetrieval"))
						{
							using (MetricsUtilities.MeasureDuration(requestContext, "client.call.auth.resolve_identity_duration"))
							{
								using (requestContext.Metrics.StartEvent(Metric.CredentialsRequestTime))
								{
									immutableCredentials = aWSCredentials.GetCredentials();
								}
							}
						}
					}
					if (immutableCredentials != null && immutableCredentials.UseToken && !(requestContext.Signer is NullSigner) && !(requestContext.Signer is BearerTokenSigner))
					{
						switch (requestContext.Signer.Protocol)
						{
						case ClientProtocol.QueryStringProtocol:
							requestContext.Request.Parameters["SecurityToken"] = immutableCredentials.Token;
							break;
						case ClientProtocol.RestProtocol:
							requestContext.Request.Headers["x-amz-security-token"] = immutableCredentials.Token;
							break;
						default:
							throw new InvalidDataException("Cannot determine protocol");
						}
					}
					if (!string.IsNullOrEmpty(immutableCredentials?.AccountId))
					{
						requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.RESOLVED_ACCOUNT_ID);
					}
					requestContext.Signer.Sign(requestContext.Request, requestContext.ClientConfig, requestContext.Metrics, requestContext.Identity);
					if (requestContext.Request.EventStreamPublisher != null)
					{
						IEventSigner eventSigner = requestContext.Signer.CreateEventSigner(requestContext.Identity, requestContext.Request.DeterminedSigningRegion, requestContext.ClientConfig.AuthenticationServiceName, requestContext.Request.AWS4SignerResult.Signature);
						requestContext.Request.HttpRequestStreamPublisher = new EventSignerHttpRequestStreamPublisher(requestContext.Request.EventStreamPublisher, eventSigner);
					}
				}
			}
		}

		private static async Task SignRequestAsync(IRequestContext requestContext)
		{
			if (requestContext.Identity == null && requestContext.Signer.RequiresCredentials)
			{
				return;
			}
			using (requestContext.Metrics.StartEvent(Metric.RequestSigningTime))
			{
				using (MetricsUtilities.MeasureDuration(requestContext, "client.call.auth.signing_duration"))
				{
					ImmutableCredentials immutableCredentials = null;
					if (requestContext.Identity is AWSCredentials aWSCredentials)
					{
						using (TracingUtilities.CreateSpan(requestContext, "CredentialsRetrieval"))
						{
							using (MetricsUtilities.MeasureDuration(requestContext, "client.call.auth.resolve_identity_duration"))
							{
								using (requestContext.Metrics.StartEvent(Metric.CredentialsRequestTime))
								{
									immutableCredentials = await aWSCredentials.GetCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
								}
							}
						}
					}
					if (immutableCredentials != null && immutableCredentials.UseToken && !(requestContext.Signer is NullSigner) && !(requestContext.Signer is BearerTokenSigner))
					{
						switch (requestContext.Signer.Protocol)
						{
						case ClientProtocol.QueryStringProtocol:
							requestContext.Request.Parameters["SecurityToken"] = immutableCredentials.Token;
							break;
						case ClientProtocol.RestProtocol:
							requestContext.Request.Headers["x-amz-security-token"] = immutableCredentials.Token;
							break;
						default:
							throw new InvalidDataException("Cannot determine protocol");
						}
					}
					if (!string.IsNullOrEmpty(immutableCredentials?.AccountId))
					{
						requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.RESOLVED_ACCOUNT_ID);
					}
					await requestContext.Signer.SignAsync(requestContext.Request, requestContext.ClientConfig, requestContext.Metrics, requestContext.Identity).ConfigureAwait(continueOnCapturedContext: false);
					if (requestContext.Request.EventStreamPublisher != null)
					{
						IEventSigner eventSigner = requestContext.Signer.CreateEventSigner(requestContext.Identity, requestContext.Request.DeterminedSigningRegion, requestContext.ClientConfig.AuthenticationServiceName, requestContext.Request.AWS4SignerResult.Signature);
						requestContext.Request.HttpRequestStreamPublisher = new EventSignerHttpRequestStreamPublisher(requestContext.Request.EventStreamPublisher, eventSigner);
					}
				}
			}
		}
	}
}
