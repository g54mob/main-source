using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Amazon.Util;

namespace Amazon.S3.Internal
{
	public class AmazonS3ResponseHandler : PipelineHandler
	{
		private static char[] etagTrimChars = new char[1] { '"' };

		public override void InvokeSync(IExecutionContext executionContext)
		{
			base.InvokeSync(executionContext);
			PostInvoke(executionContext);
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			T result = await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			PostInvoke(executionContext);
			return result;
		}

		protected virtual void PostInvoke(IExecutionContext executionContext)
		{
			ProcessResponseHandlers(executionContext);
		}

		private static void ProcessResponseHandlers(IExecutionContext executionContext)
		{
			AmazonWebServiceResponse response = executionContext.ResponseContext.Response;
			IRequest request = executionContext.RequestContext.Request;
			bool flag = HasSSEHeaders(executionContext.ResponseContext.HttpResponse);
			if (response is GetObjectResponse getObjectResponse)
			{
				GetObjectRequest getObjectRequest = request.OriginalRequest as GetObjectRequest;
				getObjectResponse.BucketName = getObjectRequest.BucketName;
				getObjectResponse.Key = getObjectRequest.Key;
				if (!string.IsNullOrEmpty(getObjectResponse.ETag) && !getObjectResponse.ETag.Contains("-") && !flag && getObjectRequest.ByteRange == null && !request.IsDirectoryBucket())
				{
					HashStream responseStream = new MD5Stream(expectedHash: AWSSDKUtils.HexStringToBytes(getObjectResponse.ETag.Trim(etagTrimChars)), baseStream: getObjectResponse.ResponseStream, expectedLength: getObjectResponse.ContentLength);
					getObjectResponse.ResponseStream = responseStream;
				}
			}
			if (response is DeleteObjectsResponse { DeleteErrors: not null } deleteObjectsResponse && deleteObjectsResponse.DeleteErrors.Count > 0)
			{
				throw new DeleteObjectsException(deleteObjectsResponse);
			}
			PutObjectResponse putObjectResponse = response as PutObjectResponse;
			if (request.OriginalRequest is PutObjectRequest { InputStream: MD5Stream inputStream } putObjectRequest)
			{
				if (putObjectResponse != null && !flag)
				{
					inputStream.CalculateHash();
					CompareHashes(putObjectResponse.ETag, inputStream.CalculatedHash);
				}
				putObjectRequest.InputStream = inputStream.GetNonWrapperBaseStream();
			}
			if (response is ListObjectsResponse { IsTruncated: var isTruncated } listObjectsResponse && isTruncated == true && string.IsNullOrEmpty(listObjectsResponse.NextMarker))
			{
				List<S3Object> s3Objects = listObjectsResponse.S3Objects;
				if (s3Objects != null && s3Objects.Count > 0)
				{
					listObjectsResponse.NextMarker = listObjectsResponse.S3Objects?.Last().Key;
				}
			}
			UploadPartRequest uploadPartRequest = request.OriginalRequest as UploadPartRequest;
			UploadPartResponse uploadPartResponse = response as UploadPartResponse;
			if (uploadPartRequest != null)
			{
				if (uploadPartResponse != null)
				{
					uploadPartResponse.PartNumber = uploadPartRequest.PartNumber;
				}
				if (uploadPartRequest.InputStream is MD5Stream mD5Stream)
				{
					if (uploadPartResponse != null && !flag)
					{
						mD5Stream.CalculateHash();
						CompareHashes(uploadPartResponse.ETag, mD5Stream.CalculatedHash);
					}
					uploadPartRequest.InputStream = mD5Stream.GetNonWrapperBaseStream();
				}
			}
			if (response is CopyPartResponse copyPartResponse)
			{
				copyPartResponse.PartNumber = ((CopyPartRequest)request.OriginalRequest).PartNumber;
			}
			AmazonS3Client.CleanupRequest(request.OriginalRequest);
		}

		private static bool HasSSEHeaders(IWebResponseData webResponseData)
		{
			bool num = !string.IsNullOrEmpty(webResponseData.GetHeaderValue("x-amz-server-side-encryption-customer-algorithm"));
			bool flag = !string.IsNullOrEmpty(webResponseData.GetHeaderValue("x-amz-server-side-encryption-aws-kms-key-id"));
			return num || flag;
		}

		private static void CompareHashes(string etag, byte[] hash)
		{
			if (!string.IsNullOrEmpty(etag) && hash != null && hash.Length != 0 && !etag.Contains("-"))
			{
				etag = etag.Trim(etagTrimChars);
				string b = AWSSDKUtils.ToHex(hash, lowercase: false);
				if (!string.Equals(etag, b, StringComparison.OrdinalIgnoreCase))
				{
					throw new AmazonClientException("Expected hash not equal to calculated hash");
				}
			}
		}
	}
}
