using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace Amazon.S3.Internal.S3Express
{
	public class S3ExpressPreSigner : PipelineHandler
	{
		private const string S3ExpressSessionHeader = "x-amz-s3session-token";

		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		protected static void PreInvoke(IExecutionContext executionContext)
		{
			AmazonS3Config config = (AmazonS3Config)executionContext.RequestContext.ClientConfig;
			if (ShouldSign(executionContext.RequestContext, config))
			{
				PreSignRequest(executionContext.RequestContext, config);
			}
		}

		private static bool ShouldSign(IRequestContext requestContext, AmazonS3Config config)
		{
			if (requestContext.Request.UseS3ExpressSessionAuth())
			{
				return !config.DisableS3ExpressSessionAuth;
			}
			return false;
		}

		private static void PreSignRequest(IRequestContext requestContext, AmazonS3Config config)
		{
			SessionCredentials sessionCredentials = config.S3ExpressCredentialProvider.ResolveSessionCredentials(GetRequestBucketName(requestContext.Request));
			if (sessionCredentials != null)
			{
				requestContext.Request.Headers["x-amz-s3session-token"] = sessionCredentials.SessionToken;
				requestContext.Identity = new BasicAWSCredentials(sessionCredentials.AccessKeyId, sessionCredentials.SecretAccessKey);
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			await PreInvokeAsync(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected static async Task PreInvokeAsync(IExecutionContext executionContext)
		{
			AmazonS3Config config = (AmazonS3Config)executionContext.RequestContext.ClientConfig;
			if (ShouldSign(executionContext.RequestContext, config))
			{
				await PreSignRequestAsync(executionContext.RequestContext, config).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private static async Task PreSignRequestAsync(IRequestContext requestContext, AmazonS3Config config)
		{
			SessionCredentials sessionCredentials = await config.S3ExpressCredentialProvider.ResolveSessionCredentialsAsync(GetRequestBucketName(requestContext.Request)).ConfigureAwait(continueOnCapturedContext: false);
			if (sessionCredentials != null)
			{
				requestContext.Request.Headers["x-amz-s3session-token"] = sessionCredentials.SessionToken;
				requestContext.Identity = new BasicAWSCredentials(sessionCredentials.AccessKeyId, sessionCredentials.SecretAccessKey);
			}
		}

		private static string GetRequestBucketName(IRequest request)
		{
			return new AmazonS3Uri(request.Endpoint).Bucket;
		}
	}
}
