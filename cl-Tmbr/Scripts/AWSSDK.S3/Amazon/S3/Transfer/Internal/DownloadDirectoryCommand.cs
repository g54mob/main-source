using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3.Internal;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Amazon.Util.Internal;

namespace Amazon.S3.Transfer.Internal
{
	internal class DownloadDirectoryCommand : BaseCommand
	{
		private readonly IAmazonS3 _s3Client;

		private readonly TransferUtilityDownloadDirectoryRequest _request;

		private readonly bool _skipEncryptionInstructionFiles;

		private int _totalNumberOfFilesToDownload;

		private int _numberOfFilesDownloaded;

		private long _totalBytes;

		private long _transferredBytes;

		private string _currentFile;

		private TransferUtilityConfig _config;

		public bool DownloadFilesConcurrently { get; set; }

		internal DownloadDirectoryCommand(IAmazonS3 s3Client, TransferUtilityDownloadDirectoryRequest request)
		{
			if (s3Client == null)
			{
				throw new ArgumentNullException("s3Client");
			}
			_s3Client = s3Client;
			_request = request;
			_skipEncryptionInstructionFiles = s3Client is IAmazonS3Encryption;
		}

		private void downloadedProgressEventCallback(object sender, WriteObjectProgressArgs e)
		{
			long transferredBytes = Interlocked.Add(ref _transferredBytes, e.IncrementTransferred);
			int numberOfFilesDownloaded = _numberOfFilesDownloaded;
			if (e.IsCompleted)
			{
				numberOfFilesDownloaded = Interlocked.Increment(ref _numberOfFilesDownloaded);
			}
			DownloadDirectoryProgressArgs downloadDirectoryProgressArgs = null;
			downloadDirectoryProgressArgs = ((!_request.DownloadFilesConcurrently) ? new DownloadDirectoryProgressArgs(numberOfFilesDownloaded, _totalNumberOfFilesToDownload, transferredBytes, _totalBytes, _currentFile, e.TransferredBytes, e.TotalBytes) : new DownloadDirectoryProgressArgs(numberOfFilesDownloaded, _totalNumberOfFilesToDownload, transferredBytes, _totalBytes, null, 0L, 0L));
			_request.OnRaiseProgressEvent(downloadDirectoryProgressArgs);
		}

		private void EnsureDirectoryExists(DirectoryInfo directory)
		{
			if (!directory.Exists)
			{
				EnsureDirectoryExists(directory.Parent);
				directory.Create();
			}
		}

		private TransferUtilityDownloadRequest ConstructTransferUtilityDownloadRequest(S3Object s3Object, int prefixLength)
		{
			TransferUtilityDownloadRequest transferUtilityDownloadRequest = new TransferUtilityDownloadRequest();
			transferUtilityDownloadRequest.BucketName = _request.BucketName;
			transferUtilityDownloadRequest.Key = s3Object.Key;
			string path = s3Object.Key.Substring(prefixLength).Replace('/', Path.DirectorySeparatorChar);
			transferUtilityDownloadRequest.FilePath = Path.Combine(_request.LocalDirectory, path);
			transferUtilityDownloadRequest.ServerSideEncryptionCustomerMethod = _request.ServerSideEncryptionCustomerMethod;
			transferUtilityDownloadRequest.ServerSideEncryptionCustomerProvidedKey = _request.ServerSideEncryptionCustomerProvidedKey;
			transferUtilityDownloadRequest.ServerSideEncryptionCustomerProvidedKeyMD5 = _request.ServerSideEncryptionCustomerProvidedKeyMD5;
			transferUtilityDownloadRequest.RequestPayer = _request.RequestPayer;
			if (!InternalSDKUtils.IsFilePathRootedWithDirectoryPath(transferUtilityDownloadRequest.FilePath, _request.LocalDirectory))
			{
				throw new AmazonClientException("The file " + transferUtilityDownloadRequest.FilePath + " is not allowed outside of the target directory " + _request.LocalDirectory + ".");
			}
			transferUtilityDownloadRequest.WriteObjectProgressEvent += downloadedProgressEventCallback;
			return transferUtilityDownloadRequest;
		}

		private ListObjectsV2Request ConstructListObjectRequestV2()
		{
			ListObjectsV2Request listObjectsV2Request = new ListObjectsV2Request();
			listObjectsV2Request.BucketName = _request.BucketName;
			listObjectsV2Request.Prefix = _request.S3Directory;
			listObjectsV2Request.Prefix = listObjectsV2Request.Prefix.Replace('\\', '/');
			if (!_request.DisableSlashCorrection && !listObjectsV2Request.Prefix.EndsWith("/", StringComparison.Ordinal))
			{
				listObjectsV2Request.Prefix += "/";
			}
			if (listObjectsV2Request.Prefix.StartsWith("/", StringComparison.Ordinal))
			{
				if (listObjectsV2Request.Prefix.Length == 1)
				{
					listObjectsV2Request.Prefix = "";
				}
				else
				{
					listObjectsV2Request.Prefix = listObjectsV2Request.Prefix.Substring(1);
				}
			}
			listObjectsV2Request.RequestPayer = _request.RequestPayer;
			return listObjectsV2Request;
		}

		private ListObjectsRequest ConstructListObjectRequest()
		{
			ListObjectsRequest listObjectsRequest = new ListObjectsRequest();
			listObjectsRequest.BucketName = _request.BucketName;
			listObjectsRequest.Prefix = _request.S3Directory;
			listObjectsRequest.Prefix = listObjectsRequest.Prefix.Replace('\\', '/');
			if (!_request.DisableSlashCorrection && !listObjectsRequest.Prefix.EndsWith("/", StringComparison.Ordinal))
			{
				listObjectsRequest.Prefix += "/";
			}
			if (listObjectsRequest.Prefix.StartsWith("/", StringComparison.Ordinal))
			{
				if (listObjectsRequest.Prefix.Length == 1)
				{
					listObjectsRequest.Prefix = "";
				}
				else
				{
					listObjectsRequest.Prefix = listObjectsRequest.Prefix.Substring(1);
				}
			}
			listObjectsRequest.RequestPayer = _request.RequestPayer;
			return listObjectsRequest;
		}

		private void ValidateRequest()
		{
			if (!_request.IsSetBucketName())
			{
				throw new InvalidOperationException("The bucketName Specified is null or empty!");
			}
			if (!_request.IsSetS3Directory())
			{
				throw new InvalidOperationException("The S3Directory Specified is null or empty!");
			}
			if (!_request.IsSetLocalDirectory())
			{
				throw new InvalidOperationException("The LocalDirectory Specified is null or empty!");
			}
			if (File.Exists(_request.S3Directory))
			{
				throw new InvalidOperationException("A file already exists with the same name indicated by LocalDirectory!");
			}
		}

		private bool IsInstructionFile(string key)
		{
			if (_skipEncryptionInstructionFiles)
			{
				return AmazonS3Util.IsInstructionFile(key);
			}
			return false;
		}

		private bool ShouldDownload(S3Object s3o)
		{
			if (_request.IsSetModifiedSinceDate() && s3o.LastModified.GetValueOrDefault() <= _request.ModifiedSinceDate.ToUniversalTime())
			{
				return false;
			}
			if (_request.IsSetUnmodifiedSinceDate() && s3o.LastModified.GetValueOrDefault() > _request.UnmodifiedSinceDate.ToUniversalTime())
			{
				return false;
			}
			if (IsInstructionFile(s3o.Key))
			{
				return false;
			}
			return true;
		}

		internal DownloadDirectoryCommand(IAmazonS3 s3Client, TransferUtilityDownloadDirectoryRequest request, TransferUtilityConfig config)
			: this(s3Client, request)
		{
			_config = config;
		}

		public override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			ValidateRequest();
			EnsureDirectoryExists(new DirectoryInfo(_request.LocalDirectory));
			string listRequestPrefix;
			List<S3Object> objs;
			try
			{
				ListObjectsRequest listObjectsRequest = ConstructListObjectRequest();
				listRequestPrefix = listObjectsRequest.Prefix;
				objs = await GetS3ObjectsToDownloadAsync(listObjectsRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (AmazonS3Exception ex)
			{
				if (ex.StatusCode != HttpStatusCode.NotImplemented)
				{
					throw;
				}
				ListObjectsV2Request listObjectsV2Request = ConstructListObjectRequestV2();
				listRequestPrefix = listObjectsV2Request.Prefix;
				objs = await GetS3ObjectsToDownloadV2Async(listObjectsV2Request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			_totalNumberOfFilesToDownload = objs.Count;
			SemaphoreSlim asyncThrottler = null;
			CancellationTokenSource internalCts = null;
			try
			{
				asyncThrottler = (DownloadFilesConcurrently ? new SemaphoreSlim(_config.ConcurrentServiceRequests) : new SemaphoreSlim(1));
				internalCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
				List<Task> pendingTasks = new List<Task>();
				foreach (S3Object s3o in objs)
				{
					if (!s3o.Key.EndsWith("/", StringComparison.Ordinal))
					{
						await asyncThrottler.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						cancellationToken.ThrowIfCancellationRequested();
						if (internalCts.IsCancellationRequested)
						{
							break;
						}
						int num = listRequestPrefix.Length;
						if (_request.DisableSlashCorrection && !listRequestPrefix.EndsWith("/"))
						{
							num = listRequestPrefix.LastIndexOf("/") + 1;
						}
						_currentFile = s3o.Key.Substring(num);
						TransferUtilityDownloadRequest request = ConstructTransferUtilityDownloadRequest(s3o, num);
						Task item = BaseCommand.ExecuteCommandAsync(new DownloadCommand(_s3Client, request), internalCts, asyncThrottler);
						pendingTasks.Add(item);
					}
				}
				await BaseCommand.WhenAllOrFirstExceptionAsync(pendingTasks, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				internalCts.Dispose();
				asyncThrottler.Dispose();
			}
		}

		private async Task<List<S3Object>> GetS3ObjectsToDownloadAsync(ListObjectsRequest listRequest, CancellationToken cancellationToken)
		{
			List<S3Object> objs = new List<S3Object>();
			do
			{
				ListObjectsResponse listObjectsResponse = await _s3Client.ListObjectsAsync(listRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (listObjectsResponse.S3Objects != null)
				{
					foreach (S3Object s3Object in listObjectsResponse.S3Objects)
					{
						if (ShouldDownload(s3Object))
						{
							_totalBytes += s3Object.Size.GetValueOrDefault();
							objs.Add(s3Object);
						}
					}
				}
				listRequest.Marker = listObjectsResponse.NextMarker;
			}
			while (!string.IsNullOrEmpty(listRequest.Marker));
			return objs;
		}

		private async Task<List<S3Object>> GetS3ObjectsToDownloadV2Async(ListObjectsV2Request listRequestV2, CancellationToken cancellationToken)
		{
			List<S3Object> objs = new List<S3Object>();
			do
			{
				ListObjectsV2Response listObjectsV2Response = await _s3Client.ListObjectsV2Async(listRequestV2, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (listObjectsV2Response.S3Objects != null)
				{
					foreach (S3Object s3Object in listObjectsV2Response.S3Objects)
					{
						if (ShouldDownload(s3Object))
						{
							_totalBytes += s3Object.Size.GetValueOrDefault();
							objs.Add(s3Object);
						}
					}
				}
				listRequestV2.ContinuationToken = listObjectsV2Response.NextContinuationToken;
			}
			while (!string.IsNullOrEmpty(listRequestV2.ContinuationToken));
			return objs;
		}
	}
}
