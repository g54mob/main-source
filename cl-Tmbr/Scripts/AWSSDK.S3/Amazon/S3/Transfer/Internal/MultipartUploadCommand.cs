using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Internal;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Amazon.Util;

namespace Amazon.S3.Transfer.Internal
{
	internal class MultipartUploadCommand : BaseCommand
	{
		private IAmazonS3 _s3Client;

		private long _partSize;

		private int _totalNumberOfParts;

		private TransferUtilityConfig _config;

		private TransferUtilityUploadRequest _fileTransporterRequest;

		private List<UploadPartResponse> _uploadResponses = new List<UploadPartResponse>();

		private long _totalTransferredBytes;

		private Queue<UploadPartRequest> _partsToUpload = new Queue<UploadPartRequest>();

		private long _contentLength;

		private static Logger Logger => Logger.GetLogger(typeof(TransferUtility));

		public SemaphoreSlim AsyncThrottler { get; set; }

		internal MultipartUploadCommand(IAmazonS3 s3Client, TransferUtilityConfig config, TransferUtilityUploadRequest fileTransporterRequest)
		{
			_config = config;
			if (fileTransporterRequest.IsSetFilePath())
			{
				Logger.DebugFormat("Beginning upload of file {0}.", fileTransporterRequest.FilePath);
			}
			else
			{
				Logger.DebugFormat("Beginning upload of stream.");
			}
			_s3Client = s3Client;
			_fileTransporterRequest = fileTransporterRequest;
			_contentLength = _fileTransporterRequest.ContentLength;
			if (fileTransporterRequest.IsSetPartSize())
			{
				_partSize = fileTransporterRequest.PartSize;
			}
			else
			{
				_partSize = calculatePartSize(_contentLength);
			}
			if (fileTransporterRequest.InputStream != null && fileTransporterRequest.AutoResetStreamPosition && fileTransporterRequest.InputStream.CanSeek)
			{
				fileTransporterRequest.InputStream.Seek(0L, SeekOrigin.Begin);
			}
			Logger.DebugFormat("Upload part size {0}.", _partSize);
		}

		private static long calculatePartSize(long fileSize)
		{
			double num = Math.Ceiling((double)fileSize / 10000.0);
			if (num < (double)S3Constants.MinPartSize)
			{
				num = S3Constants.MinPartSize;
			}
			return (long)num;
		}

		private string determineContentType()
		{
			if (_fileTransporterRequest.IsSetContentType())
			{
				return _fileTransporterRequest.ContentType;
			}
			if (_fileTransporterRequest.IsSetFilePath() || _fileTransporterRequest.IsSetKey())
			{
				string extension = AWSSDKUtils.GetExtension(_fileTransporterRequest.FilePath);
				if (string.IsNullOrEmpty(extension) && _fileTransporterRequest.IsSetKey())
				{
					extension = AWSSDKUtils.GetExtension(_fileTransporterRequest.Key);
				}
				return AmazonS3Util.MimeTypeFromExtension(extension);
			}
			return null;
		}

		private int CalculateConcurrentServiceRequests()
		{
			int num = ((!_fileTransporterRequest.IsSetFilePath() || _s3Client is IAmazonS3Encryption) ? 1 : _config.ConcurrentServiceRequests);
			if (_totalNumberOfParts < num)
			{
				num = _totalNumberOfParts;
			}
			return num;
		}

		private CompleteMultipartUploadRequest ConstructCompleteMultipartUploadRequest(InitiateMultipartUploadResponse initResponse)
		{
			return ConstructCompleteMultipartUploadRequest(initResponse, skipPartValidation: false, null);
		}

		private CompleteMultipartUploadRequest ConstructCompleteMultipartUploadRequest(InitiateMultipartUploadResponse initResponse, bool skipPartValidation, RequestEventHandler requestEventHandler)
		{
			if (!skipPartValidation && _uploadResponses.Count != _totalNumberOfParts)
			{
				throw new InvalidOperationException($"Cannot complete multipart upload request. The total number of completed parts ({_uploadResponses.Count}) " + $"does not equal the total number of parts created ({_totalNumberOfParts}).");
			}
			CompleteMultipartUploadRequest completeMultipartUploadRequest = new CompleteMultipartUploadRequest
			{
				BucketName = _fileTransporterRequest.BucketName,
				Key = _fileTransporterRequest.Key,
				UploadId = initResponse.UploadId,
				IfNoneMatch = _fileTransporterRequest.IfNoneMatch,
				IfMatch = _fileTransporterRequest.IfMatch,
				RequestPayer = _fileTransporterRequest.RequestPayer,
				ChecksumType = initResponse.ChecksumType,
				ChecksumCRC32 = _fileTransporterRequest.ChecksumCRC32,
				ChecksumCRC32C = _fileTransporterRequest.ChecksumCRC32C,
				ChecksumCRC64NVME = _fileTransporterRequest.ChecksumCRC64NVME,
				ChecksumSHA1 = _fileTransporterRequest.ChecksumSHA1,
				ChecksumSHA256 = _fileTransporterRequest.ChecksumSHA256
			};
			if (_fileTransporterRequest.ServerSideEncryptionCustomerMethod != null && _fileTransporterRequest.ServerSideEncryptionCustomerMethod != ServerSideEncryptionCustomerMethod.None)
			{
				completeMultipartUploadRequest.SSECustomerAlgorithm = _fileTransporterRequest.ServerSideEncryptionCustomerMethod.ToString();
				completeMultipartUploadRequest.SSECustomerKey = _fileTransporterRequest.ServerSideEncryptionCustomerProvidedKey;
				completeMultipartUploadRequest.SSECustomerKeyMD5 = _fileTransporterRequest.ServerSideEncryptionCustomerProvidedKeyMD5 ?? initResponse.ServerSideEncryptionCustomerProvidedKeyMD5;
			}
			completeMultipartUploadRequest.AddPartETagsAndChecksums(_uploadResponses);
			if (_fileTransporterRequest.IsSetMpuObjectSize())
			{
				completeMultipartUploadRequest.MpuObjectSize = _fileTransporterRequest.MpuObjectSize;
			}
			if (requestEventHandler != null)
			{
				((IAmazonWebServiceRequest)completeMultipartUploadRequest).AddBeforeRequestHandler(requestEventHandler);
			}
			else
			{
				((IAmazonWebServiceRequest)completeMultipartUploadRequest).AddBeforeRequestHandler((RequestEventHandler)base.RequestEventHandler);
			}
			return completeMultipartUploadRequest;
		}

		private UploadPartRequest ConstructUploadPartRequest(int partNumber, long filePosition, InitiateMultipartUploadResponse initiateResponse)
		{
			UploadPartRequest uploadPartRequest = ConstructGenericUploadPartRequest(initiateResponse);
			uploadPartRequest.PartNumber = partNumber;
			uploadPartRequest.PartSize = _partSize;
			if (filePosition + _partSize >= _contentLength && _s3Client is IAmazonS3Encryption)
			{
				uploadPartRequest.IsLastPart = true;
				uploadPartRequest.PartSize = 0L;
			}
			ProgressHandler progressHandler = new ProgressHandler(UploadPartProgressEventCallback);
			((IAmazonWebServiceRequest)uploadPartRequest).StreamUploadProgressCallback = (EventHandler<StreamTransferProgressArgs>)Delegate.Combine(((IAmazonWebServiceRequest)uploadPartRequest).StreamUploadProgressCallback, new EventHandler<StreamTransferProgressArgs>(progressHandler.OnTransferProgress));
			((IAmazonWebServiceRequest)uploadPartRequest).AddBeforeRequestHandler((RequestEventHandler)base.RequestEventHandler);
			if (_fileTransporterRequest.IsSetFilePath())
			{
				uploadPartRequest.FilePosition = filePosition;
				uploadPartRequest.FilePath = _fileTransporterRequest.FilePath;
			}
			else
			{
				uploadPartRequest.InputStream = _fileTransporterRequest.InputStream;
			}
			return uploadPartRequest;
		}

		private UploadPartRequest ConstructGenericUploadPartRequest(InitiateMultipartUploadResponse initiateResponse)
		{
			UploadPartRequest uploadPartRequest = new UploadPartRequest
			{
				BucketName = _fileTransporterRequest.BucketName,
				Key = _fileTransporterRequest.Key,
				UploadId = initiateResponse.UploadId,
				ServerSideEncryptionCustomerMethod = _fileTransporterRequest.ServerSideEncryptionCustomerMethod,
				ServerSideEncryptionCustomerProvidedKey = _fileTransporterRequest.ServerSideEncryptionCustomerProvidedKey,
				ServerSideEncryptionCustomerProvidedKeyMD5 = _fileTransporterRequest.ServerSideEncryptionCustomerProvidedKeyMD5,
				DisableDefaultChecksumValidation = _fileTransporterRequest.DisableDefaultChecksumValidation,
				DisablePayloadSigning = _fileTransporterRequest.DisablePayloadSigning,
				ChecksumAlgorithm = _fileTransporterRequest.ChecksumAlgorithm,
				RequestPayer = _fileTransporterRequest.RequestPayer
			};
			if (initiateResponse.ServerSideEncryptionMethod == ServerSideEncryptionMethod.AWSKMS || initiateResponse.ServerSideEncryptionMethod == ServerSideEncryptionMethod.AWSKMSDSSE)
			{
				((IAmazonWebServiceRequest)uploadPartRequest).SignatureVersion = SignatureVersion.SigV4;
			}
			return uploadPartRequest;
		}

		private UploadPartRequest ConstructUploadPartRequestForNonSeekableStream(Stream inputStream, int partNumber, long partSize, bool isLastPart, InitiateMultipartUploadResponse initiateResponse)
		{
			UploadPartRequest uploadPartRequest = ConstructGenericUploadPartRequest(initiateResponse);
			uploadPartRequest.InputStream = inputStream;
			uploadPartRequest.PartNumber = partNumber;
			uploadPartRequest.PartSize = partSize;
			uploadPartRequest.IsLastPart = isLastPart;
			if (_fileTransporterRequest.ContentLength != -1)
			{
				ProgressHandler progressHandler = new ProgressHandler(UploadPartProgressEventCallback);
				((IAmazonWebServiceRequest)uploadPartRequest).StreamUploadProgressCallback = (EventHandler<StreamTransferProgressArgs>)Delegate.Combine(((IAmazonWebServiceRequest)uploadPartRequest).StreamUploadProgressCallback, new EventHandler<StreamTransferProgressArgs>(progressHandler.OnTransferProgress));
				((IAmazonWebServiceRequest)uploadPartRequest).AddBeforeRequestHandler((RequestEventHandler)base.RequestEventHandler);
			}
			return uploadPartRequest;
		}

		private InitiateMultipartUploadRequest ConstructInitiateMultipartUploadRequest()
		{
			return ConstructInitiateMultipartUploadRequest(null);
		}

		private InitiateMultipartUploadRequest ConstructInitiateMultipartUploadRequest(RequestEventHandler requestEventHandler)
		{
			InitiateMultipartUploadRequest initiateMultipartUploadRequest = new InitiateMultipartUploadRequest
			{
				BucketName = _fileTransporterRequest.BucketName,
				Key = _fileTransporterRequest.Key,
				CannedACL = _fileTransporterRequest.CannedACL,
				ContentType = determineContentType(),
				StorageClass = _fileTransporterRequest.StorageClass,
				ServerSideEncryptionMethod = _fileTransporterRequest.ServerSideEncryptionMethod,
				ServerSideEncryptionKeyManagementServiceKeyId = _fileTransporterRequest.ServerSideEncryptionKeyManagementServiceKeyId,
				ServerSideEncryptionCustomerMethod = _fileTransporterRequest.ServerSideEncryptionCustomerMethod,
				ServerSideEncryptionCustomerProvidedKey = _fileTransporterRequest.ServerSideEncryptionCustomerProvidedKey,
				ServerSideEncryptionCustomerProvidedKeyMD5 = _fileTransporterRequest.ServerSideEncryptionCustomerProvidedKeyMD5,
				TagSet = _fileTransporterRequest.TagSet,
				ChecksumAlgorithm = _fileTransporterRequest.ChecksumAlgorithm,
				ObjectLockLegalHoldStatus = _fileTransporterRequest.ObjectLockLegalHoldStatus,
				ObjectLockMode = _fileTransporterRequest.ObjectLockMode,
				RequestPayer = _fileTransporterRequest.RequestPayer
			};
			if (_fileTransporterRequest.IsSetObjectLockRetainUntilDate())
			{
				initiateMultipartUploadRequest.ObjectLockRetainUntilDate = _fileTransporterRequest.ObjectLockRetainUntilDate;
			}
			if (HasPrecalculatedChecksum(out var chosenAlgorithm))
			{
				initiateMultipartUploadRequest.ChecksumType = ChecksumType.FULL_OBJECT;
				if (!initiateMultipartUploadRequest.IsSetChecksumAlgorithm())
				{
					initiateMultipartUploadRequest.ChecksumAlgorithm = chosenAlgorithm;
					_fileTransporterRequest.ChecksumAlgorithm = chosenAlgorithm;
				}
			}
			else if (ShouldSetDefaultAlgorithm(initiateMultipartUploadRequest))
			{
				initiateMultipartUploadRequest.ChecksumAlgorithm = ChecksumUtils.DefaultAlgorithm.ToString();
				initiateMultipartUploadRequest.ChecksumType = ChecksumType.FULL_OBJECT;
			}
			if (requestEventHandler != null)
			{
				((IAmazonWebServiceRequest)initiateMultipartUploadRequest).AddBeforeRequestHandler(requestEventHandler);
			}
			else
			{
				((IAmazonWebServiceRequest)initiateMultipartUploadRequest).AddBeforeRequestHandler((RequestEventHandler)base.RequestEventHandler);
			}
			if (_fileTransporterRequest.Metadata != null && _fileTransporterRequest.Metadata.Count > 0)
			{
				initiateMultipartUploadRequest.Metadata = _fileTransporterRequest.Metadata;
			}
			if (_fileTransporterRequest.Headers != null && _fileTransporterRequest.Headers.Count > 0)
			{
				initiateMultipartUploadRequest.Headers = _fileTransporterRequest.Headers;
			}
			return initiateMultipartUploadRequest;
		}

		private void UploadPartProgressEventCallback(object sender, UploadProgressArgs e)
		{
			long transferred = Interlocked.Add(ref _totalTransferredBytes, e.IncrementTransferred - e.CompensationForRetry);
			UploadProgressArgs progressArgs = new UploadProgressArgs(e.IncrementTransferred, transferred, _contentLength, e.CompensationForRetry, _fileTransporterRequest.FilePath);
			_fileTransporterRequest.OnRaiseProgressEvent(progressArgs);
		}

		private bool ShouldSetDefaultAlgorithm(InitiateMultipartUploadRequest initRequest)
		{
			if (!initRequest.IsSetChecksumAlgorithm() && !AWSConfigsS3.DisableDefaultChecksumValidation && _fileTransporterRequest.DisableDefaultChecksumValidation != true)
			{
				return _s3Client.Config.RequestChecksumCalculation == RequestChecksumCalculation.WHEN_SUPPORTED;
			}
			return false;
		}

		private bool HasPrecalculatedChecksum(out ChecksumAlgorithm chosenAlgorithm)
		{
			chosenAlgorithm = null;
			if (_fileTransporterRequest.IsSetChecksumCRC64NVME())
			{
				chosenAlgorithm = ChecksumAlgorithm.CRC64NVME;
				return true;
			}
			if (_fileTransporterRequest.IsSetChecksumCRC32())
			{
				chosenAlgorithm = ChecksumAlgorithm.CRC32;
				return true;
			}
			if (_fileTransporterRequest.IsSetChecksumCRC32C())
			{
				chosenAlgorithm = ChecksumAlgorithm.CRC32C;
				return true;
			}
			if (_fileTransporterRequest.IsSetChecksumSHA1())
			{
				chosenAlgorithm = ChecksumAlgorithm.SHA1;
				return true;
			}
			if (_fileTransporterRequest.IsSetChecksumSHA256())
			{
				chosenAlgorithm = ChecksumAlgorithm.SHA256;
				return true;
			}
			return false;
		}

		public override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			if ((_fileTransporterRequest.InputStream != null && !_fileTransporterRequest.InputStream.CanSeek) || _fileTransporterRequest.ContentLength == -1)
			{
				await UploadUnseekableStreamAsync(_fileTransporterRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return;
			}
			InitiateMultipartUploadRequest request = ConstructInitiateMultipartUploadRequest();
			InitiateMultipartUploadResponse initResponse = await _s3Client.InitiateMultipartUploadAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			Logger.DebugFormat("Initiated upload: {0}", initResponse.UploadId);
			List<Task<UploadPartResponse>> pendingUploadPartTasks = new List<Task<UploadPartResponse>>();
			SemaphoreSlim localThrottler = null;
			CancellationTokenSource internalCts = null;
			try
			{
				Logger.DebugFormat("Queue up the UploadPartRequests to be executed");
				long num = 0L;
				int num2 = 1;
				while (num < _contentLength)
				{
					cancellationToken.ThrowIfCancellationRequested();
					UploadPartRequest item = ConstructUploadPartRequest(num2, num, initResponse);
					_partsToUpload.Enqueue(item);
					num += _partSize;
					num2++;
				}
				_totalNumberOfParts = _partsToUpload.Count;
				Logger.DebugFormat("Scheduling the {0} UploadPartRequests in the queue", _totalNumberOfParts);
				internalCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
				int initialCount = CalculateConcurrentServiceRequests();
				localThrottler = ((AsyncThrottler == null) ? new SemaphoreSlim(initialCount) : AsyncThrottler);
				foreach (UploadPartRequest uploadRequest in _partsToUpload)
				{
					await localThrottler.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					cancellationToken.ThrowIfCancellationRequested();
					if (!internalCts.IsCancellationRequested)
					{
						Task<UploadPartResponse> item2 = UploadPartAsync(uploadRequest, internalCts, localThrottler);
						pendingUploadPartTasks.Add(item2);
						continue;
					}
					break;
				}
				Logger.DebugFormat("Waiting for upload part requests to complete. ({0})", initResponse.UploadId);
				_uploadResponses = await BaseCommand.WhenAllOrFirstExceptionAsync(pendingUploadPartTasks, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				Logger.DebugFormat("Beginning completing multipart. ({0})", initResponse.UploadId);
				CompleteMultipartUploadRequest request2 = ConstructCompleteMultipartUploadRequest(initResponse);
				await _s3Client.CompleteMultipartUploadAsync(request2, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				Logger.DebugFormat("Done completing multipart. ({0})", initResponse.UploadId);
			}
			catch (Exception exception)
			{
				Logger.Error(exception, "Exception while uploading. ({0})", initResponse.UploadId);
				Cleanup(initResponse.UploadId, pendingUploadPartTasks);
				throw;
			}
			finally
			{
				internalCts?.Dispose();
				if (localThrottler != null && localThrottler != AsyncThrottler)
				{
					localThrottler.Dispose();
				}
				if (_fileTransporterRequest.InputStream != null && !_fileTransporterRequest.IsSetFilePath() && _fileTransporterRequest.AutoCloseStream)
				{
					_fileTransporterRequest.InputStream.Dispose();
				}
			}
		}

		private async Task<UploadPartResponse> UploadPartAsync(UploadPartRequest uploadRequest, CancellationTokenSource internalCts, SemaphoreSlim asyncThrottler)
		{
			try
			{
				return await _s3Client.UploadPartAsync(uploadRequest, internalCts.Token).ConfigureAwait(continueOnCapturedContext: false);
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

		private void Cleanup(string uploadId, List<Task<UploadPartResponse>> tasks)
		{
			try
			{
				Task[] tasks2 = tasks.ToArray();
				Task.WaitAll(tasks2, 5000);
			}
			catch (Exception ex)
			{
				Logger.InfoFormat("A timeout occured while waiting for all upload part request to complete as part of aborting the multipart upload : {0}", ex.Message);
			}
			AbortMultipartUpload(uploadId);
		}

		private void AbortMultipartUpload(string uploadId)
		{
			try
			{
				_s3Client.AbortMultipartUploadAsync(new AbortMultipartUploadRequest
				{
					BucketName = _fileTransporterRequest.BucketName,
					Key = _fileTransporterRequest.Key,
					RequestPayer = _fileTransporterRequest.RequestPayer,
					UploadId = uploadId
				}).Wait();
			}
			catch (Exception ex)
			{
				Logger.InfoFormat("Error attempting to abort multipart for key {0}: {1}", _fileTransporterRequest.Key, ex.Message);
			}
		}

		private async Task UploadUnseekableStreamAsync(TransferUtilityUploadRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			int READ_BUFFER_SIZE = _s3Client.Config.BufferSize;
			RequestEventHandler requestEventHandler = delegate(object o, RequestEventArgs args)
			{
				if (args is WebServiceRequestEventArgs e)
				{
					((IAmazonWebServiceRequest)e.Request).UserAgentDetails.AddFeature(UserAgentFeatureId.S3_TRANSFER);
					((IAmazonWebServiceRequest)e.Request).UserAgentDetails.AddUserAgentComponent("md/UploadNonSeekableStream");
				}
			};
			InitiateMultipartUploadRequest request2 = ConstructInitiateMultipartUploadRequest(requestEventHandler);
			InitiateMultipartUploadResponse initiateResponse = await _s3Client.InitiateMultipartUploadAsync(request2).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				long minPartSize = ((request == null || request.PartSize != 0) ? request.PartSize : S3Constants.MinPartSize);
				List<UploadPartResponse> uploadPartResponses = new List<UploadPartResponse>();
				byte[] readBuffer = ArrayPool<byte>.Shared.Rent(READ_BUFFER_SIZE);
				byte[] partBuffer = ArrayPool<byte>.Shared.Rent((int)minPartSize + readBuffer.Length);
				MemoryStream nextUploadBuffer = new MemoryStream(partBuffer);
				using Stream stream = request.InputStream;
				try
				{
					int partNumber = 1;
					int count = await stream.ReadAsync(readBuffer, 0, readBuffer.Length).ConfigureAwait(continueOnCapturedContext: false);
					int readAheadBytesCount;
					do
					{
						await nextUploadBuffer.WriteAsync(readBuffer, 0, count).ConfigureAwait(continueOnCapturedContext: false);
						readAheadBytesCount = await stream.ReadAsync(readBuffer, 0, readBuffer.Length).ConfigureAwait(continueOnCapturedContext: false);
						if (nextUploadBuffer.Position > minPartSize || readAheadBytesCount == 0)
						{
							if (nextUploadBuffer.Position == 0L && partNumber == 1)
							{
								nextUploadBuffer.Dispose();
								nextUploadBuffer = new MemoryStream();
							}
							bool isLastPart = readAheadBytesCount == 0;
							long partSize = nextUploadBuffer.Position;
							nextUploadBuffer.Position = 0L;
							UploadPartRequest request3 = ConstructUploadPartRequestForNonSeekableStream(nextUploadBuffer, partNumber, partSize, isLastPart, initiateResponse);
							UploadPartResponse item = await _s3Client.UploadPartAsync(request3).ConfigureAwait(continueOnCapturedContext: false);
							Logger.DebugFormat("Uploaded part {0}. (Last part = {1}, Part size = {2}, Upload Id: {3})", partNumber, isLastPart, partSize, initiateResponse.UploadId);
							uploadPartResponses.Add(item);
							partNumber++;
							nextUploadBuffer.Dispose();
							nextUploadBuffer = new MemoryStream(partBuffer);
						}
						count = readAheadBytesCount;
					}
					while (readAheadBytesCount > 0);
				}
				finally
				{
					ArrayPool<byte>.Shared.Return(partBuffer);
					ArrayPool<byte>.Shared.Return(readBuffer);
					nextUploadBuffer.Dispose();
				}
				_uploadResponses = uploadPartResponses;
				CompleteMultipartUploadRequest request4 = ConstructCompleteMultipartUploadRequest(initiateResponse, skipPartValidation: true, requestEventHandler);
				await _s3Client.CompleteMultipartUploadAsync(request4).ConfigureAwait(continueOnCapturedContext: false);
				Logger.DebugFormat("Completed multi part upload. (Part count: {0}, Upload Id: {1})", uploadPartResponses.Count, initiateResponse.UploadId);
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				await _s3Client.AbortMultipartUploadAsync(new AbortMultipartUploadRequest
				{
					BucketName = request.BucketName,
					Key = request.Key,
					RequestPayer = request.RequestPayer,
					UploadId = initiateResponse.UploadId
				}).ConfigureAwait(continueOnCapturedContext: false);
				Logger.Error(ex2, ex2.Message);
				ExceptionDispatchInfo.Capture((ex as Exception) ?? throw ex).Throw();
			}
		}
	}
}
