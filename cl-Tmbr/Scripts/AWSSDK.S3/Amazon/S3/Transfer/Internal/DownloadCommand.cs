using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Model;
using Amazon.Util;

namespace Amazon.S3.Transfer.Internal
{
	internal class DownloadCommand : BaseCommand
	{
		private static int MAX_BACKOFF_IN_MILLISECONDS = (int)TimeSpan.FromSeconds(30.0).TotalMilliseconds;

		private IAmazonS3 _s3Client;

		private TransferUtilityDownloadRequest _request;

		private static Logger Logger => Logger.GetLogger(typeof(TransferUtility));

		internal DownloadCommand(IAmazonS3 s3Client, TransferUtilityDownloadRequest request)
		{
			_s3Client = s3Client;
			_request = request;
		}

		private void ValidateRequest()
		{
			if (!_request.IsSetBucketName())
			{
				throw new InvalidOperationException("The BucketName specified is null or empty!");
			}
			if (!_request.IsSetKey())
			{
				throw new InvalidOperationException("The Key specified is null or empty!");
			}
		}

		private void OnWriteObjectProgressEvent(object sender, WriteObjectProgressArgs e)
		{
			_request.OnRaiseProgressEvent(e);
		}

		private static bool HandleException(Exception exception, int retries, int maxRetries)
		{
			bool flag = true;
			if (exception is IOException)
			{
				if (retries < maxRetries)
				{
					Logger.InfoFormat("Encountered an IOException. Retrying, retry {0} of {1}.", retries, maxRetries);
					return true;
				}
				flag = false;
			}
			if (!flag)
			{
				Logger.Error(exception, "Encountered a {0}. Reached maximum retries {1} of {2}.", exception.GetType().Name, retries, maxRetries);
				return false;
			}
			Logger.Error(exception, "Encountered a non retryable {0}, rethrowing exception.", exception.GetType().Name);
			return false;
		}

		private static void WaitBeforeRetry(int retries)
		{
			AWSSDKUtils.Sleep(Math.Min((int)(Math.Pow(4.0, retries) * 100.0), MAX_BACKOFF_IN_MILLISECONDS));
		}

		private static ByteRange ByteRangeRemainingForDownload(string filepath)
		{
			ByteRange byteRange = new ByteRange(0L, long.MaxValue);
			if (File.Exists(filepath))
			{
				FileInfo fileInfo = new FileInfo(filepath);
				byteRange.Start = fileInfo.Length;
			}
			return byteRange;
		}

		public override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			ValidateRequest();
			GetObjectRequest getRequest = ConvertToGetObjectRequest(_request);
			int maxRetries = _s3Client.Config.MaxErrorRetry;
			int retries = 0;
			string mostRecentETag = null;
			bool shouldRetry;
			do
			{
				shouldRetry = false;
				if (retries != 0)
				{
					ByteRange byteRange = ByteRangeRemainingForDownload(_request.FilePath);
					getRequest.ByteRange = byteRange;
				}
				try
				{
					using (GetObjectResponse response = await _s3Client.GetObjectAsync(getRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
					{
						if (!string.IsNullOrEmpty(mostRecentETag) && !string.Equals(mostRecentETag, response.ETag))
						{
							mostRecentETag = response.ETag;
							getRequest.ByteRange = null;
							retries = 0;
							shouldRetry = true;
							WaitBeforeRetry(retries);
							continue;
						}
						mostRecentETag = response.ETag;
						if (retries == 0)
						{
							response.WriteObjectProgressEvent += OnWriteObjectProgressEvent;
							await response.WriteResponseStreamToFileAsync(_request.FilePath, append: false, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
						else
						{
							response.WriteObjectProgressEvent += OnWriteObjectProgressEvent;
							await response.WriteResponseStreamToFileAsync(_request.FilePath, append: true, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
					}
					goto IL_036d;
				}
				catch (Exception ex)
				{
					retries++;
					shouldRetry = HandleExceptionForHttpClient(ex, retries, maxRetries);
					if (!shouldRetry)
					{
						if (ex is IOException)
						{
							throw;
						}
						if (!(ex.InnerException is IOException))
						{
							if (ex is AmazonServiceException || ex is AmazonClientException)
							{
								throw;
							}
							throw new AmazonServiceException(ex);
						}
						ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
					}
					goto IL_036d;
				}
				IL_036d:
				WaitBeforeRetry(retries);
			}
			while (shouldRetry);
		}

		private static bool HandleExceptionForHttpClient(Exception exception, int retries, int maxRetries)
		{
			if (AWSHttpClient.IsHttpInnerException(exception))
			{
				Exception innerException = exception.InnerException;
				if (innerException is IOException)
				{
					return HandleException(innerException, retries, maxRetries);
				}
				return false;
			}
			return HandleException(exception, retries, maxRetries);
		}
	}
}
