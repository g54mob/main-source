using System;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Model;

namespace Amazon.S3.Internal
{
	public class AmazonS3ExceptionHandler : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			try
			{
				base.InvokeSync(executionContext);
			}
			catch (Exception exception)
			{
				HandleException(executionContext, exception);
				throw;
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			try
			{
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				HandleException(executionContext, exception);
				throw;
			}
		}

		protected virtual void HandleException(IExecutionContext executionContext, Exception exception)
		{
			if (executionContext.RequestContext.OriginalRequest is PutObjectRequest { InputStream: HashStream inputStream } putObjectRequest)
			{
				putObjectRequest.InputStream = inputStream.GetNonWrapperBaseStream();
			}
			if (executionContext.RequestContext.OriginalRequest is UploadPartRequest { InputStream: HashStream inputStream2 } uploadPartRequest)
			{
				uploadPartRequest.InputStream = inputStream2.GetNonWrapperBaseStream();
			}
			AmazonS3Client.CleanupRequest(executionContext.RequestContext.OriginalRequest);
		}
	}
}
