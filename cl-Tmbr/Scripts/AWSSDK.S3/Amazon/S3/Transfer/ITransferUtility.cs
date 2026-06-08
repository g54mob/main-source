using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.S3.Transfer
{
	public interface ITransferUtility : IDisposable
	{
		IAmazonS3 S3Client { get; }

		Task UploadAsync(string filePath, string bucketName, CancellationToken cancellationToken = default(CancellationToken));

		Task UploadAsync(string filePath, string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken));

		Task UploadAsync(Stream stream, string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken));

		Task UploadAsync(TransferUtilityUploadRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task AbortMultipartUploadsAsync(string bucketName, DateTime initiatedDate, CancellationToken cancellationToken = default(CancellationToken));

		Task DownloadAsync(TransferUtilityDownloadRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<Stream> OpenStreamAsync(string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken));

		Task<Stream> OpenStreamAsync(TransferUtilityOpenStreamRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task UploadDirectoryAsync(string directory, string bucketName, CancellationToken cancellationToken = default(CancellationToken));

		Task UploadDirectoryAsync(string directory, string bucketName, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default(CancellationToken));

		Task UploadDirectoryAsync(TransferUtilityUploadDirectoryRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task DownloadDirectoryAsync(string bucketName, string s3Directory, string localDirectory, CancellationToken cancellationToken = default(CancellationToken));

		Task DownloadDirectoryAsync(TransferUtilityDownloadDirectoryRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task DownloadAsync(string filePath, string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken));

		void UploadDirectory(string directory, string bucketName);

		void UploadDirectory(string directory, string bucketName, string searchPattern, SearchOption searchOption);

		void UploadDirectory(TransferUtilityUploadDirectoryRequest request);

		void Upload(string filePath, string bucketName);

		void Upload(string filePath, string bucketName, string key);

		void Upload(Stream stream, string bucketName, string key);

		void Upload(TransferUtilityUploadRequest request);

		Stream OpenStream(string bucketName, string key);

		Stream OpenStream(TransferUtilityOpenStreamRequest request);

		void Download(string filePath, string bucketName, string key);

		void Download(TransferUtilityDownloadRequest request);

		void DownloadDirectory(string bucketName, string s3Directory, string localDirectory);

		void DownloadDirectory(TransferUtilityDownloadDirectoryRequest request);

		void AbortMultipartUploads(string bucketName, DateTime initiatedDate);
	}
}
