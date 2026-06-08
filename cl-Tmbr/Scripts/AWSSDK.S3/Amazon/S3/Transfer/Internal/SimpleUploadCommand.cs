using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.S3.Model;

namespace Amazon.S3.Transfer.Internal
{
	internal class SimpleUploadCommand : BaseCommand
	{
		private IAmazonS3 _s3Client;

		private TransferUtilityConfig _config;

		private TransferUtilityUploadRequest _fileTransporterRequest;

		public SemaphoreSlim AsyncThrottler { get; set; }

		internal SimpleUploadCommand(IAmazonS3 s3Client, TransferUtilityConfig config, TransferUtilityUploadRequest fileTransporterRequest)
		{
			_s3Client = s3Client;
			_config = config;
			_fileTransporterRequest = fileTransporterRequest;
			_ = fileTransporterRequest.FilePath;
		}

		private PutObjectRequest ConstructRequest()
		{
			PutObjectRequest putObjectRequest = new PutObjectRequest
			{
				Headers = _fileTransporterRequest.Headers,
				BucketName = _fileTransporterRequest.BucketName,
				Key = _fileTransporterRequest.Key,
				CannedACL = _fileTransporterRequest.CannedACL,
				StorageClass = _fileTransporterRequest.StorageClass,
				AutoCloseStream = _fileTransporterRequest.AutoCloseStream,
				AutoResetStreamPosition = _fileTransporterRequest.AutoResetStreamPosition,
				ServerSideEncryptionMethod = _fileTransporterRequest.ServerSideEncryptionMethod,
				ServerSideEncryptionCustomerMethod = _fileTransporterRequest.ServerSideEncryptionCustomerMethod,
				ServerSideEncryptionCustomerProvidedKey = _fileTransporterRequest.ServerSideEncryptionCustomerProvidedKey,
				ServerSideEncryptionCustomerProvidedKeyMD5 = _fileTransporterRequest.ServerSideEncryptionCustomerProvidedKeyMD5,
				ServerSideEncryptionKeyManagementServiceKeyId = _fileTransporterRequest.ServerSideEncryptionKeyManagementServiceKeyId,
				IfNoneMatch = _fileTransporterRequest.IfNoneMatch,
				IfMatch = _fileTransporterRequest.IfMatch,
				Metadata = _fileTransporterRequest.Metadata,
				TagSet = _fileTransporterRequest.TagSet,
				DisableDefaultChecksumValidation = _fileTransporterRequest.DisableDefaultChecksumValidation,
				DisablePayloadSigning = _fileTransporterRequest.DisablePayloadSigning,
				ChecksumAlgorithm = _fileTransporterRequest.ChecksumAlgorithm,
				ChecksumCRC32 = _fileTransporterRequest.ChecksumCRC32,
				ChecksumCRC32C = _fileTransporterRequest.ChecksumCRC32C,
				ChecksumCRC64NVME = _fileTransporterRequest.ChecksumCRC64NVME,
				ChecksumSHA1 = _fileTransporterRequest.ChecksumSHA1,
				ChecksumSHA256 = _fileTransporterRequest.ChecksumSHA256,
				RequestPayer = _fileTransporterRequest.RequestPayer
			};
			if (!string.IsNullOrEmpty(_fileTransporterRequest.ContentType))
			{
				putObjectRequest.ContentType = _fileTransporterRequest.ContentType;
			}
			putObjectRequest.FilePath = _fileTransporterRequest.FilePath;
			ProgressHandler progressHandler = new ProgressHandler(PutObjectProgressEventCallback);
			((IAmazonWebServiceRequest)putObjectRequest).StreamUploadProgressCallback = (EventHandler<StreamTransferProgressArgs>)Delegate.Combine(((IAmazonWebServiceRequest)putObjectRequest).StreamUploadProgressCallback, new EventHandler<StreamTransferProgressArgs>(progressHandler.OnTransferProgress));
			((IAmazonWebServiceRequest)putObjectRequest).AddBeforeRequestHandler((RequestEventHandler)base.RequestEventHandler);
			putObjectRequest.InputStream = _fileTransporterRequest.InputStream;
			putObjectRequest.ObjectLockLegalHoldStatus = _fileTransporterRequest.ObjectLockLegalHoldStatus;
			putObjectRequest.ObjectLockMode = _fileTransporterRequest.ObjectLockMode;
			if (_fileTransporterRequest.IsSetObjectLockRetainUntilDate())
			{
				putObjectRequest.ObjectLockRetainUntilDate = _fileTransporterRequest.ObjectLockRetainUntilDate;
			}
			return putObjectRequest;
		}

		private void PutObjectProgressEventCallback(object sender, UploadProgressArgs e)
		{
			UploadProgressArgs progressArgs = new UploadProgressArgs(e.IncrementTransferred, e.TransferredBytes, e.TotalBytes, e.CompensationForRetry, _fileTransporterRequest.FilePath);
			_fileTransporterRequest.OnRaiseProgressEvent(progressArgs);
		}

		public override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			_ = 1;
			try
			{
				if (AsyncThrottler != null)
				{
					await AsyncThrottler.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				PutObjectRequest request = ConstructRequest();
				await _s3Client.PutObjectAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				if (AsyncThrottler != null)
				{
					AsyncThrottler.Release();
				}
			}
		}
	}
}
