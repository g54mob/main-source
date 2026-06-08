using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.S3.Model;

namespace Amazon.S3.Transfer.Internal
{
	internal abstract class BaseCommand
	{
		public virtual object Return => null;

		protected GetObjectRequest ConvertToGetObjectRequest(BaseDownloadRequest request)
		{
			GetObjectRequest getObjectRequest = new GetObjectRequest
			{
				BucketName = request.BucketName,
				Key = request.Key,
				VersionId = request.VersionId
			};
			((IAmazonWebServiceRequest)getObjectRequest).AddBeforeRequestHandler((RequestEventHandler)RequestEventHandler);
			if (request.IsSetModifiedSinceDate())
			{
				getObjectRequest.ModifiedSinceDate = request.ModifiedSinceDate;
			}
			if (request.IsSetUnmodifiedSinceDate())
			{
				getObjectRequest.UnmodifiedSinceDate = request.UnmodifiedSinceDate;
			}
			getObjectRequest.ServerSideEncryptionCustomerMethod = request.ServerSideEncryptionCustomerMethod;
			getObjectRequest.ServerSideEncryptionCustomerProvidedKey = request.ServerSideEncryptionCustomerProvidedKey;
			getObjectRequest.ServerSideEncryptionCustomerProvidedKeyMD5 = request.ServerSideEncryptionCustomerProvidedKeyMD5;
			getObjectRequest.ChecksumMode = request.ChecksumMode;
			getObjectRequest.RequestPayer = request.RequestPayer;
			return getObjectRequest;
		}

		protected void RequestEventHandler(object sender, RequestEventArgs args)
		{
			if (args is WebServiceRequestEventArgs e)
			{
				((IAmazonWebServiceRequest)e.Request).UserAgentDetails.AddFeature(UserAgentFeatureId.S3_TRANSFER);
				((IAmazonWebServiceRequest)e.Request).UserAgentDetails.AddUserAgentComponent("md/" + GetType().Name);
			}
		}

		public abstract Task ExecuteAsync(CancellationToken cancellationToken);

		protected static async Task<List<T>> WhenAllOrFirstExceptionAsync<T>(List<Task<T>> pendingTasks, CancellationToken cancellationToken)
		{
			int processed = 0;
			int total = pendingTasks.Count;
			List<T> responses = new List<T>();
			for (; processed < total; processed++)
			{
				cancellationToken.ThrowIfCancellationRequested();
				Task<T> completedTask = await Task.WhenAny(pendingTasks).ConfigureAwait(continueOnCapturedContext: false);
				responses.Add(await completedTask.ConfigureAwait(continueOnCapturedContext: false));
				pendingTasks.Remove(completedTask);
			}
			return responses;
		}

		protected static async Task WhenAllOrFirstExceptionAsync(List<Task> pendingTasks, CancellationToken cancellationToken)
		{
			int processed = 0;
			for (int total = pendingTasks.Count; processed < total; processed++)
			{
				cancellationToken.ThrowIfCancellationRequested();
				Task completedTask = await Task.WhenAny(pendingTasks).ConfigureAwait(continueOnCapturedContext: false);
				await completedTask.ConfigureAwait(continueOnCapturedContext: false);
				pendingTasks.Remove(completedTask);
			}
		}

		protected static async Task ExecuteCommandAsync(BaseCommand command, CancellationTokenSource internalCts, SemaphoreSlim throttler)
		{
			try
			{
				await command.ExecuteAsync(internalCts.Token).ConfigureAwait(continueOnCapturedContext: false);
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
				throttler.Release();
			}
		}
	}
}
