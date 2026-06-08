using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Amazon.S3.Transfer.Internal
{
	internal class OpenStreamCommand : BaseCommand
	{
		private IAmazonS3 _s3Client;

		private TransferUtilityOpenStreamRequest _request;

		private Stream _responseStream;

		internal Stream ResponseStream => _responseStream;

		public override object Return => ResponseStream;

		internal OpenStreamCommand(IAmazonS3 s3Client, TransferUtilityOpenStreamRequest request)
		{
			_s3Client = s3Client;
			_request = request;
		}

		private GetObjectRequest ConstructRequest()
		{
			if (!_request.IsSetBucketName())
			{
				throw new InvalidOperationException("The bucketName Specified is null or empty!");
			}
			if (!_request.IsSetKey())
			{
				throw new InvalidOperationException("The key Specified is null or empty!");
			}
			return ConvertToGetObjectRequest(_request);
		}

		public override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			GetObjectRequest request = ConstructRequest();
			_responseStream = (await _s3Client.GetObjectAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).ResponseStream;
		}
	}
}
