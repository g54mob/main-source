using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Telemetry;
using Amazon.Runtime.Telemetry.Tracing;
using Amazon.S3.Transfer.Internal;

namespace Amazon.S3.Transfer
{
	public class TransferUtility : ITransferUtility, IDisposable
	{
		private readonly string S3TransferTracerScope = "S3.Transfer";

		private TransferUtilityConfig _config;

		private IAmazonS3 _s3Client;

		private bool _shouldDispose;

		private bool _isDisposed;

		private HashSet<string> blockedServiceNames = new HashSet<string> { "s3-object-lambda" };

		private static Logger Logger => Logger.GetLogger(typeof(ITransferUtility));

		public IAmazonS3 S3Client => _s3Client;

		public TransferUtility(string awsAccessKeyId, string awsSecretAccessKey)
			: this(new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey))
		{
			_shouldDispose = true;
		}

		public TransferUtility(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
			: this(new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, region))
		{
			_shouldDispose = true;
		}

		public TransferUtility(string awsAccessKeyId, string awsSecretAccessKey, TransferUtilityConfig config)
			: this(new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey), config)
		{
			_shouldDispose = true;
		}

		public TransferUtility(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region, TransferUtilityConfig config)
			: this(new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, region), config)
		{
			_shouldDispose = true;
		}

		public TransferUtility(IAmazonS3 s3Client)
			: this(s3Client, new TransferUtilityConfig())
		{
		}

		public TransferUtility(IAmazonS3 s3Client, TransferUtilityConfig config)
		{
			_s3Client = s3Client;
			_config = config;
		}

		public TransferUtility()
			: this(new AmazonS3Client())
		{
			_shouldDispose = true;
		}

		public TransferUtility(RegionEndpoint region)
			: this(new AmazonS3Client(region))
		{
			_shouldDispose = true;
		}

		public TransferUtility(TransferUtilityConfig config)
			: this(new AmazonS3Client(), config)
		{
			_shouldDispose = true;
			_config = config;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing && _s3Client != null && _shouldDispose)
				{
					_s3Client.Dispose();
					_s3Client = null;
				}
				_isDisposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void CheckForBlockedArn(string bucketName, string command)
		{
			if (Arn.IsArn(bucketName))
			{
				Arn arn = Arn.Parse(bucketName);
				if (blockedServiceNames.Contains(arn.Service) && arn.IsService("s3-object-lambda"))
				{
					throw new AmazonS3Exception(command + " does not support S3 Object Lambda resources");
				}
			}
		}

		private static TransferUtilityUploadRequest ConstructUploadRequest(string filePath, string bucketName)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException("filePath");
			}
			return new TransferUtilityUploadRequest
			{
				BucketName = bucketName,
				FilePath = filePath
			};
		}

		private static TransferUtilityUploadRequest ConstructUploadRequest(string filePath, string bucketName, string key)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException("filePath");
			}
			return new TransferUtilityUploadRequest
			{
				BucketName = bucketName,
				Key = key,
				FilePath = filePath
			};
		}

		private static TransferUtilityUploadRequest ConstructUploadRequest(Stream stream, string bucketName, string key)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentNullException("key");
			}
			return new TransferUtilityUploadRequest
			{
				BucketName = bucketName,
				Key = key,
				InputStream = stream
			};
		}

		internal BaseCommand GetUploadCommand(TransferUtilityUploadRequest request)
		{
			validate(request);
			if (IsMultipartUpload(request))
			{
				return new MultipartUploadCommand(_s3Client, _config, request);
			}
			return new SimpleUploadCommand(_s3Client, _config, request);
		}

		private bool IsMultipartUpload(TransferUtilityUploadRequest request)
		{
			if (request.ContentLength <= 0 && request.InputStream != null && !request.InputStream.CanSeek)
			{
				return true;
			}
			return request.ContentLength >= _config.MinSizeBeforePartUpload;
		}

		private static void validate(TransferUtilityUploadRequest request)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			if (!request.IsSetBucketName())
			{
				throw new InvalidOperationException("Please specify BucketName to PUT an object into Amazon S3.");
			}
			if (!request.IsSetFilePath() && !request.IsSetInputStream())
			{
				throw new InvalidOperationException("Please specify either a Filename or provide a Stream to PUT an object into Amazon S3.");
			}
			if (!request.IsSetKey())
			{
				if (!request.IsSetFilePath())
				{
					throw new ArgumentException("The Key property must be specified when using a Stream to upload into Amazon S3.");
				}
				request.Key = Path.GetFileName(request.FilePath);
			}
			if (request.IsSetFilePath() && !File.Exists(request.FilePath))
			{
				throw new ArgumentException("The file indicated by the FilePath property does not exist!");
			}
		}

		private static TransferUtilityDownloadRequest ConstructDownloadRequest(string filePath, string bucketName, string key)
		{
			return new TransferUtilityDownloadRequest
			{
				BucketName = bucketName,
				Key = key,
				FilePath = filePath
			};
		}

		private static TransferUtilityDownloadDirectoryRequest ConstructDownloadDirectoryRequest(string bucketName, string s3Directory, string localDirectory)
		{
			return new TransferUtilityDownloadDirectoryRequest
			{
				BucketName = bucketName,
				S3Directory = s3Directory,
				LocalDirectory = localDirectory
			};
		}

		private static void validate(TransferUtilityUploadDirectoryRequest request)
		{
			if (!request.IsSetDirectory())
			{
				throw new InvalidOperationException("Directory not specified");
			}
			if (!request.IsSetBucketName())
			{
				throw new InvalidOperationException("BucketName not specified");
			}
			if (!Directory.Exists(request.Directory))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The directory {0} does not exists!", request.Directory));
			}
		}

		private static TransferUtilityUploadDirectoryRequest ConstructUploadDirectoryRequest(string directory, string bucketName)
		{
			return new TransferUtilityUploadDirectoryRequest
			{
				BucketName = bucketName,
				Directory = directory
			};
		}

		private static TransferUtilityUploadDirectoryRequest ConstructUploadDirectoryRequest(string directory, string bucketName, string searchPattern, SearchOption searchOption)
		{
			return new TransferUtilityUploadDirectoryRequest
			{
				BucketName = bucketName,
				Directory = directory,
				SearchPattern = searchPattern,
				SearchOption = searchOption
			};
		}

		private TraceSpan CreateSpan(string methodName, Attributes initialAttributes = null, SpanKind spanKind = SpanKind.INTERNAL, SpanContext parentContext = null)
		{
			if (initialAttributes == null)
			{
				initialAttributes = new Attributes();
			}
			string text = ExtractOperationName(methodName);
			initialAttributes.Set("rpc.method", text);
			initialAttributes.Set("rpc.system", "aws-api");
			initialAttributes.Set("rpc.service", S3TransferTracerScope);
			string name = "TransferUtility." + text;
			return _s3Client.Config.TelemetryProvider.TracerProvider.GetTracer("AWSSDK." + S3TransferTracerScope).CreateSpan(name, initialAttributes, spanKind, parentContext);
		}

		private string ExtractOperationName(string methodName)
		{
			if (methodName.EndsWith("Async", StringComparison.Ordinal))
			{
				return methodName.Substring(0, methodName.Length - 5);
			}
			return methodName;
		}

		public async Task UploadAsync(string filePath, string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			TransferUtilityUploadRequest request = ConstructUploadRequest(filePath, bucketName);
			await UploadAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task UploadAsync(string filePath, string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			TransferUtilityUploadRequest request = ConstructUploadRequest(filePath, bucketName, key);
			await UploadAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task UploadAsync(Stream stream, string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			TransferUtilityUploadRequest request = ConstructUploadRequest(stream, bucketName, key);
			await UploadAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task UploadAsync(TransferUtilityUploadRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (CreateSpan("UploadAsync", null, SpanKind.CLIENT))
			{
				CheckForBlockedArn(request.BucketName, "Upload");
				await GetUploadCommand(request, null).ExecuteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public async Task AbortMultipartUploadsAsync(string bucketName, DateTime initiatedDate, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (CreateSpan("AbortMultipartUploadsAsync", null, SpanKind.CLIENT))
			{
				CheckForBlockedArn(bucketName, "AbortMultipartUploads");
				await new AbortMultipartUploadsCommand(_s3Client, bucketName, initiatedDate, _config).ExecuteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public async Task DownloadAsync(TransferUtilityDownloadRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (CreateSpan("DownloadAsync", null, SpanKind.CLIENT))
			{
				CheckForBlockedArn(request.BucketName, "Download");
				await new DownloadCommand(_s3Client, request).ExecuteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public async Task<Stream> OpenStreamAsync(string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			TransferUtilityOpenStreamRequest request = new TransferUtilityOpenStreamRequest
			{
				BucketName = bucketName,
				Key = key
			};
			return await OpenStreamAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Stream> OpenStreamAsync(TransferUtilityOpenStreamRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (CreateSpan("OpenStreamAsync", null, SpanKind.CLIENT))
			{
				CheckForBlockedArn(request.BucketName, "OpenStream");
				OpenStreamCommand command = new OpenStreamCommand(_s3Client, request);
				await command.ExecuteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return command.ResponseStream;
			}
		}

		internal BaseCommand GetUploadCommand(TransferUtilityUploadRequest request, SemaphoreSlim asyncThrottler)
		{
			validate(request);
			if (IsMultipartUpload(request))
			{
				return new MultipartUploadCommand(_s3Client, _config, request)
				{
					AsyncThrottler = asyncThrottler
				};
			}
			return new SimpleUploadCommand(_s3Client, _config, request)
			{
				AsyncThrottler = asyncThrottler
			};
		}

		public async Task UploadDirectoryAsync(string directory, string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			TransferUtilityUploadDirectoryRequest request = ConstructUploadDirectoryRequest(directory, bucketName);
			await UploadDirectoryAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task UploadDirectoryAsync(string directory, string bucketName, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default(CancellationToken))
		{
			TransferUtilityUploadDirectoryRequest request = ConstructUploadDirectoryRequest(directory, bucketName, searchPattern, searchOption);
			await UploadDirectoryAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task UploadDirectoryAsync(TransferUtilityUploadDirectoryRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (CreateSpan("UploadDirectoryAsync", null, SpanKind.CLIENT))
			{
				CheckForBlockedArn(request.BucketName, "UploadDirectory");
				validate(request);
				await new UploadDirectoryCommand(this, _config, request)
				{
					UploadFilesConcurrently = request.UploadFilesConcurrently
				}.ExecuteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public async Task DownloadDirectoryAsync(string bucketName, string s3Directory, string localDirectory, CancellationToken cancellationToken = default(CancellationToken))
		{
			TransferUtilityDownloadDirectoryRequest request = ConstructDownloadDirectoryRequest(bucketName, s3Directory, localDirectory);
			await DownloadDirectoryAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task DownloadDirectoryAsync(TransferUtilityDownloadDirectoryRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (CreateSpan("DownloadDirectoryAsync", null, SpanKind.CLIENT))
			{
				CheckForBlockedArn(request.BucketName, "DownloadDirectory");
				await new DownloadDirectoryCommand(_s3Client, request, _config)
				{
					DownloadFilesConcurrently = request.DownloadFilesConcurrently
				}.ExecuteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public async Task DownloadAsync(string filePath, string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			TransferUtilityDownloadRequest request = ConstructDownloadRequest(filePath, bucketName, key);
			await DownloadAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public void UploadDirectory(string directory, string bucketName)
		{
			try
			{
				UploadDirectoryAsync(directory, bucketName).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void UploadDirectory(string directory, string bucketName, string searchPattern, SearchOption searchOption)
		{
			try
			{
				UploadDirectoryAsync(directory, bucketName, searchPattern, searchOption).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void UploadDirectory(TransferUtilityUploadDirectoryRequest request)
		{
			try
			{
				UploadDirectoryAsync(request).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void Upload(string filePath, string bucketName)
		{
			try
			{
				UploadAsync(filePath, bucketName).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void Upload(string filePath, string bucketName, string key)
		{
			try
			{
				UploadAsync(filePath, bucketName, key).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void Upload(Stream stream, string bucketName, string key)
		{
			try
			{
				UploadAsync(stream, bucketName, key).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void Upload(TransferUtilityUploadRequest request)
		{
			try
			{
				UploadAsync(request).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public Stream OpenStream(string bucketName, string key)
		{
			try
			{
				return OpenStreamAsync(bucketName, key).Result;
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
				return null;
			}
		}

		public Stream OpenStream(TransferUtilityOpenStreamRequest request)
		{
			try
			{
				return OpenStreamAsync(request).Result;
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
				return null;
			}
		}

		public void Download(string filePath, string bucketName, string key)
		{
			try
			{
				DownloadAsync(filePath, bucketName, key).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void Download(TransferUtilityDownloadRequest request)
		{
			try
			{
				DownloadAsync(request).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void DownloadDirectory(string bucketName, string s3Directory, string localDirectory)
		{
			try
			{
				DownloadDirectoryAsync(bucketName, s3Directory, localDirectory).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void DownloadDirectory(TransferUtilityDownloadDirectoryRequest request)
		{
			try
			{
				DownloadDirectoryAsync(request).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}

		public void AbortMultipartUploads(string bucketName, DateTime initiatedDate)
		{
			try
			{
				AbortMultipartUploadsAsync(bucketName, initiatedDate).Wait();
			}
			catch (AggregateException ex)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			}
		}
	}
}
