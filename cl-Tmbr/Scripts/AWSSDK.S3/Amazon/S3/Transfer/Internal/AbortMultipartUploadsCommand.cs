using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.S3.Model;

namespace Amazon.S3.Transfer.Internal
{
	internal class AbortMultipartUploadsCommand : BaseCommand
	{
		private IAmazonS3 _s3Client;

		private string _bucketName;

		private DateTime _initiatedDate;

		private TransferUtilityConfig _config;

		internal AbortMultipartUploadsCommand(IAmazonS3 s3Client, string bucketName, DateTime initiateDate)
		{
			_s3Client = s3Client;
			_bucketName = bucketName;
			_initiatedDate = initiateDate;
		}

		private ListMultipartUploadsRequest ConstructListMultipartUploadsRequest(ListMultipartUploadsResponse listResponse)
		{
			ListMultipartUploadsRequest listMultipartUploadsRequest = new ListMultipartUploadsRequest();
			listMultipartUploadsRequest.BucketName = _bucketName;
			listMultipartUploadsRequest.KeyMarker = listResponse.KeyMarker;
			listMultipartUploadsRequest.UploadIdMarker = listResponse.NextUploadIdMarker;
			((IAmazonWebServiceRequest)listMultipartUploadsRequest).AddBeforeRequestHandler((RequestEventHandler)base.RequestEventHandler);
			return listMultipartUploadsRequest;
		}

		private AbortMultipartUploadRequest ConstructAbortMultipartUploadRequest(MultipartUpload upload)
		{
			AbortMultipartUploadRequest abortMultipartUploadRequest = new AbortMultipartUploadRequest();
			abortMultipartUploadRequest.BucketName = _bucketName;
			abortMultipartUploadRequest.Key = upload.Key;
			abortMultipartUploadRequest.UploadId = upload.UploadId;
			((IAmazonWebServiceRequest)abortMultipartUploadRequest).AddBeforeRequestHandler((RequestEventHandler)base.RequestEventHandler);
			return abortMultipartUploadRequest;
		}

		internal AbortMultipartUploadsCommand(IAmazonS3 s3Client, string bucketName, DateTime initiateDate, TransferUtilityConfig config)
		{
			_s3Client = s3Client;
			_bucketName = bucketName;
			_initiatedDate = initiateDate;
			_config = config;
		}

		public override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			if (string.IsNullOrEmpty(_bucketName))
			{
				throw new InvalidOperationException("The bucketName specified is null or empty!");
			}
			SemaphoreSlim asyncThrottler = null;
			CancellationTokenSource internalCts = null;
			try
			{
				asyncThrottler = new SemaphoreSlim(_config.ConcurrentServiceRequests);
				internalCts = new CancellationTokenSource();
				CancellationToken internalCancellationToken = internalCts.Token;
				ListMultipartUploadsResponse listResponse = new ListMultipartUploadsResponse();
				List<Task<AbortMultipartUploadResponse>> pendingTasks = new List<Task<AbortMultipartUploadResponse>>();
				do
				{
					ListMultipartUploadsRequest request = ConstructListMultipartUploadsRequest(listResponse);
					listResponse = await _s3Client.ListMultipartUploadsAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (listResponse.MultipartUploads == null)
					{
						continue;
					}
					foreach (MultipartUpload upload in listResponse.MultipartUploads)
					{
						cancellationToken.ThrowIfCancellationRequested();
						if (!internalCancellationToken.IsCancellationRequested)
						{
							if (upload.Initiated < _initiatedDate)
							{
								await asyncThrottler.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
								AbortMultipartUploadRequest abortRequest = ConstructAbortMultipartUploadRequest(upload);
								Task<AbortMultipartUploadResponse> item = AbortAsync(abortRequest, internalCts, cancellationToken, asyncThrottler);
								pendingTasks.Add(item);
							}
							continue;
						}
						break;
					}
				}
				while (listResponse.IsTruncated == true);
				await BaseCommand.WhenAllOrFirstExceptionAsync(pendingTasks, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				internalCts?.Dispose();
				asyncThrottler?.Dispose();
			}
		}

		private async Task<AbortMultipartUploadResponse> AbortAsync(AbortMultipartUploadRequest abortRequest, CancellationTokenSource internalCts, CancellationToken cancellationToken, SemaphoreSlim asyncThrottler)
		{
			try
			{
				return await _s3Client.AbortMultipartUploadAsync(abortRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				if (!(ex is OperationCanceledException))
				{
					internalCts.Cancel();
				}
				throw;
			}
			finally
			{
				asyncThrottler.Release();
			}
		}
	}
}
