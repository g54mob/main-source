using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Internal
{
	public class AmazonS3AdaptiveRetryPolicy : AdaptiveRetryPolicy
	{
		public AmazonS3AdaptiveRetryPolicy(IClientConfig config)
			: base(config)
		{
		}

		public bool? RetryForExceptionSync(IExecutionContext executionContext, Exception exception)
		{
			return AmazonS3RetryPolicy.SharedRetryForExceptionSync(executionContext, exception, base.Logger, base.RetryForException);
		}

		public override async Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception)
		{
			return await AmazonS3RetryPolicy.SharedRetryForExceptionAsync(executionContext, exception, RetryForExceptionSync, [DebuggerHidden] (IExecutionContext executionContext2, Exception exception2) => RetryForException(executionContext2, exception2)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
