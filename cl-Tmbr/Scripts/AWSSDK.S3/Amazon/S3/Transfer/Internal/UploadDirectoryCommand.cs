using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3.Internal;

namespace Amazon.S3.Transfer.Internal
{
	internal class UploadDirectoryCommand : BaseCommand
	{
		private TransferUtilityUploadDirectoryRequest _request;

		private TransferUtility _utility;

		private TransferUtilityConfig _config;

		private int _totalNumberOfFiles;

		private int _numberOfFilesUploaded;

		private long _totalBytes;

		private long _transferredBytes;

		public bool UploadFilesConcurrently { get; set; }

		internal UploadDirectoryCommand(TransferUtility utility, TransferUtilityConfig config, TransferUtilityUploadDirectoryRequest request)
		{
			_utility = utility;
			_request = request;
			_config = config;
		}

		private TransferUtilityUploadRequest ConstructRequest(string basePath, string filepath, string prefix)
		{
			string text = filepath.Substring(basePath.Length);
			text = text.Replace("\\", "/");
			if (text.StartsWith("/", StringComparison.Ordinal))
			{
				text = text.Substring(1);
			}
			text = prefix + text;
			TransferUtilityUploadRequest transferUtilityUploadRequest = new TransferUtilityUploadRequest
			{
				BucketName = _request.BucketName,
				Key = text,
				FilePath = filepath,
				CannedACL = _request.CannedACL,
				Metadata = _request.Metadata,
				ContentType = _request.ContentType,
				StorageClass = _request.StorageClass,
				ServerSideEncryptionMethod = _request.ServerSideEncryptionMethod,
				ServerSideEncryptionKeyManagementServiceKeyId = _request.ServerSideEncryptionKeyManagementServiceKeyId,
				ServerSideEncryptionCustomerMethod = _request.ServerSideEncryptionCustomerMethod,
				ServerSideEncryptionCustomerProvidedKey = _request.ServerSideEncryptionCustomerProvidedKey,
				ServerSideEncryptionCustomerProvidedKeyMD5 = _request.ServerSideEncryptionCustomerProvidedKeyMD5,
				TagSet = _request.TagSet,
				ObjectLockLegalHoldStatus = _request.ObjectLockLegalHoldStatus,
				ObjectLockMode = _request.ObjectLockMode,
				DisablePayloadSigning = _request.DisablePayloadSigning,
				RequestPayer = _request.RequestPayer,
				DisableDefaultChecksumValidation = _request.DisableDefaultChecksumValidation,
				ChecksumAlgorithm = _request.ChecksumAlgorithm
			};
			if (_request.IsSetObjectLockRetainUntilDate())
			{
				transferUtilityUploadRequest.ObjectLockRetainUntilDate = _request.ObjectLockRetainUntilDate;
			}
			transferUtilityUploadRequest.UploadProgressEvent += UploadProgressEventCallback;
			_request.RaiseUploadDirectoryFileRequestEvent(transferUtilityUploadRequest);
			return transferUtilityUploadRequest;
		}

		private string GetKeyPrefix()
		{
			string text = string.Empty;
			if (_request.IsSetKeyPrefix())
			{
				text = _request.KeyPrefix;
				text = text.Replace("\\", "/");
				if (text.StartsWith("/", StringComparison.Ordinal))
				{
					text = text.Substring(1);
				}
				if (!text.EndsWith("/", StringComparison.Ordinal))
				{
					text += "/";
				}
			}
			return text;
		}

		private void UploadProgressEventCallback(object sender, UploadProgressArgs e)
		{
			long transferredBytes = Interlocked.Add(ref _transferredBytes, e.IncrementTransferred - e.CompensationForRetry);
			int numberOfFilesUploaded = _numberOfFilesUploaded;
			if (e.TransferredBytes == e.TotalBytes)
			{
				numberOfFilesUploaded = Interlocked.Increment(ref _numberOfFilesUploaded);
			}
			UploadDirectoryProgressArgs uploadDirectoryProgressArgs = null;
			uploadDirectoryProgressArgs = ((!_request.UploadFilesConcurrently) ? new UploadDirectoryProgressArgs(numberOfFilesUploaded, _totalNumberOfFiles, transferredBytes, _totalBytes, e.FilePath, e.TransferredBytes, e.TotalBytes) : new UploadDirectoryProgressArgs(numberOfFilesUploaded, _totalNumberOfFiles, transferredBytes, _totalBytes, null, 0L, 0L));
			_request.OnRaiseProgressEvent(uploadDirectoryProgressArgs);
		}

		public override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			string prefix = GetKeyPrefix();
			string basePath = new DirectoryInfo(_request.Directory).FullName;
			string[] array = await GetFiles(basePath, _request.SearchPattern, _request.SearchOption, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			_totalNumberOfFiles = array.Length;
			SemaphoreSlim asyncThrottler = null;
			SemaphoreSlim loopThrottler = null;
			CancellationTokenSource internalCts = null;
			try
			{
				List<Task> pendingTasks = new List<Task>();
				loopThrottler = (UploadFilesConcurrently ? new SemaphoreSlim(_config.ConcurrentServiceRequests) : new SemaphoreSlim(1));
				asyncThrottler = ((_utility.S3Client is IAmazonS3Encryption) ? null : new SemaphoreSlim(_config.ConcurrentServiceRequests));
				internalCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
				string[] array2 = array;
				foreach (string filepath in array2)
				{
					await loopThrottler.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					cancellationToken.ThrowIfCancellationRequested();
					if (internalCts.IsCancellationRequested)
					{
						break;
					}
					TransferUtilityUploadRequest request = ConstructRequest(basePath, filepath, prefix);
					Task item = BaseCommand.ExecuteCommandAsync(_utility.GetUploadCommand(request, asyncThrottler), internalCts, loopThrottler);
					pendingTasks.Add(item);
				}
				await BaseCommand.WhenAllOrFirstExceptionAsync(pendingTasks, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				internalCts.Dispose();
				loopThrottler.Dispose();
				asyncThrottler?.Dispose();
			}
		}

		private Task<string[]> GetFiles(string path, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken)
		{
			return Task.Run(delegate
			{
				string[] files = Directory.GetFiles(path, searchPattern, searchOption);
				string[] array = files;
				foreach (string fileName in array)
				{
					_totalBytes += new FileInfo(fileName).Length;
				}
				return files;
			}, cancellationToken);
		}
	}
}
