using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Amazon.Util;

namespace Amazon.S3.Internal
{
	public class AmazonS3PreMarshallHandler : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			return base.InvokeAsync<T>(executionContext);
		}

		protected virtual void PreInvoke(IExecutionContext executionContext)
		{
			ProcessPreRequestHandlers(executionContext);
		}

		private static void ProcessPreRequestHandlers(IExecutionContext executionContext)
		{
			AmazonWebServiceRequest originalRequest = executionContext.RequestContext.OriginalRequest;
			IClientConfig clientConfig = executionContext.RequestContext.ClientConfig;
			if (originalRequest is PutObjectRequest putObjectRequest)
			{
				if (putObjectRequest.InputStream != null && !string.IsNullOrEmpty(putObjectRequest.FilePath))
				{
					throw new ArgumentException("Please specify one of either an InputStream or a FilePath to be PUT as an S3 object.");
				}
				if (!string.IsNullOrEmpty(putObjectRequest.ContentBody) && !string.IsNullOrEmpty(putObjectRequest.FilePath))
				{
					throw new ArgumentException("Please specify one of either a FilePath or the ContentBody to be PUT as an S3 object.");
				}
				if (putObjectRequest.InputStream != null && !string.IsNullOrEmpty(putObjectRequest.ContentBody))
				{
					throw new ArgumentException("Please specify one of either an InputStream or the ContentBody to be PUT as an S3 object.");
				}
				if (!putObjectRequest.Headers.IsSetContentType())
				{
					string text = null;
					if (!string.IsNullOrEmpty(putObjectRequest.FilePath))
					{
						text = AWSSDKUtils.GetExtension(putObjectRequest.FilePath);
					}
					if (string.IsNullOrEmpty(text) && putObjectRequest.IsSetKey())
					{
						text = AWSSDKUtils.GetExtension(putObjectRequest.Key);
					}
					if (!string.IsNullOrEmpty(text))
					{
						putObjectRequest.Headers.ContentType = AmazonS3Util.MimeTypeFromExtension(text);
					}
				}
				if (putObjectRequest.InputStream != null && putObjectRequest.AutoResetStreamPosition && putObjectRequest.InputStream.CanSeek)
				{
					putObjectRequest.InputStream.Seek(0L, SeekOrigin.Begin);
				}
				if (!string.IsNullOrEmpty(putObjectRequest.FilePath))
				{
					putObjectRequest.SetupForFilePath();
				}
				else if (putObjectRequest.InputStream == null)
				{
					if (string.IsNullOrEmpty(putObjectRequest.Headers.ContentType))
					{
						putObjectRequest.Headers.ContentType = "text/plain";
					}
					byte[] bytes = Encoding.UTF8.GetBytes(putObjectRequest.ContentBody ?? "");
					putObjectRequest.InputStream = new MemoryStream(bytes);
				}
			}
			if (originalRequest is PutBucketRequest { UseClientRegion: not false } putBucketRequest && (!putBucketRequest.IsSetPutBucketConfiguration() || !putBucketRequest.PutBucketConfiguration.IsSetLocation()) && !putBucketRequest.IsSetBucketRegionName() && !putBucketRequest.IsSetBucketRegion())
			{
				string text2 = DetermineBucketRegionCode(clientConfig, originalRequest);
				if (text2 == "us-east-1")
				{
					text2 = null;
				}
				else if (text2 == "eu-west-1")
				{
					text2 = "EU";
				}
				putBucketRequest.BucketRegion = text2;
			}
			if (originalRequest is DeleteBucketRequest { UseClientRegion: not false } deleteBucketRequest && !deleteBucketRequest.IsSetBucketRegion())
			{
				string text3 = DetermineBucketRegionCode(clientConfig, originalRequest);
				if (text3 == "us-east-1")
				{
					text3 = null;
				}
				if (text3 != null)
				{
					deleteBucketRequest.BucketRegion = text3;
				}
			}
			if (originalRequest is UploadPartRequest uploadPartRequest)
			{
				if (uploadPartRequest.InputStream != null && !string.IsNullOrEmpty(uploadPartRequest.FilePath))
				{
					throw new ArgumentException("Please specify one of either a InputStream or a FilePath to be PUT as an S3 object.");
				}
				if (uploadPartRequest.IsSetFilePath())
				{
					uploadPartRequest.SetupForFilePath();
				}
			}
			if (originalRequest is InitiateMultipartUploadRequest initiateMultipartUploadRequest && !initiateMultipartUploadRequest.Headers.IsSetContentType())
			{
				string extension = AWSSDKUtils.GetExtension(initiateMultipartUploadRequest.Key);
				if (!string.IsNullOrEmpty(extension))
				{
					initiateMultipartUploadRequest.Headers.ContentType = AmazonS3Util.MimeTypeFromExtension(extension);
				}
			}
		}

		private static string DetermineBucketRegionCode(IClientConfig config, AmazonWebServiceRequest request)
		{
			if (config.RegionEndpoint != null && string.IsNullOrEmpty(config.ServiceURL))
			{
				return config.RegionEndpoint.SystemName;
			}
			ServiceOperationEndpointParameters parameters = new ServiceOperationEndpointParameters(request);
			return AWSSDKUtils.DetermineRegion(config.DetermineServiceOperationEndpoint(parameters).URL);
		}
	}
}
