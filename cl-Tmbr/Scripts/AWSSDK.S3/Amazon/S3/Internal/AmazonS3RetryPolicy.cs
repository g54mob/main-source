using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace Amazon.S3.Internal
{
	public class AmazonS3RetryPolicy : DefaultRetryPolicy
	{
		private const string AWS_KMS_Signature_Error = "AWS KMS managed keys require AWS Signature Version 4";

		internal static readonly ICollection<Type> RequestsWith200Error = new HashSet<Type>
		{
			typeof(AbortMultipartUploadRequest),
			typeof(CompleteMultipartUploadRequest),
			typeof(CopyObjectRequest),
			typeof(CopyPartRequest),
			typeof(CreateBucketMetadataTableConfigurationRequest),
			typeof(CreateSessionRequest),
			typeof(DeleteBucketRequest),
			typeof(DeleteBucketAnalyticsConfigurationRequest),
			typeof(DeleteBucketEncryptionRequest),
			typeof(DeleteBucketIntelligentTieringConfigurationRequest),
			typeof(DeleteBucketInventoryConfigurationRequest),
			typeof(DeleteBucketMetadataTableConfigurationRequest),
			typeof(DeleteBucketMetricsConfigurationRequest),
			typeof(DeleteBucketOwnershipControlsRequest),
			typeof(DeleteBucketPolicyRequest),
			typeof(DeleteBucketReplicationRequest),
			typeof(DeleteBucketTaggingRequest),
			typeof(DeleteBucketWebsiteRequest),
			typeof(DeleteCORSConfigurationRequest),
			typeof(DeleteLifecycleConfigurationRequest),
			typeof(DeleteObjectRequest),
			typeof(DeleteObjectsRequest),
			typeof(DeleteObjectTaggingRequest),
			typeof(DeletePublicAccessBlockRequest),
			typeof(GetBucketAccelerateConfigurationRequest),
			typeof(GetBucketAclRequest),
			typeof(GetBucketAnalyticsConfigurationRequest),
			typeof(GetBucketEncryptionRequest),
			typeof(GetBucketIntelligentTieringConfigurationRequest),
			typeof(GetBucketInventoryConfigurationRequest),
			typeof(GetBucketLocationRequest),
			typeof(GetBucketLoggingRequest),
			typeof(GetBucketMetadataTableConfigurationRequest),
			typeof(GetBucketMetricsConfigurationRequest),
			typeof(GetBucketNotificationRequest),
			typeof(GetBucketOwnershipControlsRequest),
			typeof(GetBucketPolicyRequest),
			typeof(GetBucketPolicyStatusRequest),
			typeof(GetBucketReplicationRequest),
			typeof(GetBucketRequestPaymentRequest),
			typeof(GetBucketTaggingRequest),
			typeof(GetBucketVersioningRequest),
			typeof(GetBucketWebsiteRequest),
			typeof(GetCORSConfigurationRequest),
			typeof(GetLifecycleConfigurationRequest),
			typeof(GetObjectAclRequest),
			typeof(GetObjectAttributesRequest),
			typeof(GetObjectLegalHoldRequest),
			typeof(GetObjectLockConfigurationRequest),
			typeof(GetObjectMetadataRequest),
			typeof(GetObjectRetentionRequest),
			typeof(GetObjectTaggingRequest),
			typeof(GetPublicAccessBlockRequest),
			typeof(HeadBucketRequest),
			typeof(InitiateMultipartUploadRequest),
			typeof(ListBucketAnalyticsConfigurationsRequest),
			typeof(ListBucketIntelligentTieringConfigurationsRequest),
			typeof(ListBucketInventoryConfigurationsRequest),
			typeof(ListBucketMetricsConfigurationsRequest),
			typeof(ListBucketsRequest),
			typeof(ListDirectoryBucketsRequest),
			typeof(ListMultipartUploadsRequest),
			typeof(ListObjectsRequest),
			typeof(ListObjectsV2Request),
			typeof(ListPartsRequest),
			typeof(ListVersionsRequest),
			typeof(PutBucketRequest),
			typeof(PutBucketAccelerateConfigurationRequest),
			typeof(PutBucketAclRequest),
			typeof(PutBucketAnalyticsConfigurationRequest),
			typeof(PutBucketEncryptionRequest),
			typeof(PutBucketIntelligentTieringConfigurationRequest),
			typeof(PutBucketInventoryConfigurationRequest),
			typeof(PutBucketLoggingRequest),
			typeof(PutBucketMetricsConfigurationRequest),
			typeof(PutBucketNotificationRequest),
			typeof(PutBucketOwnershipControlsRequest),
			typeof(PutBucketPolicyRequest),
			typeof(PutBucketReplicationRequest),
			typeof(PutBucketRequestPaymentRequest),
			typeof(PutBucketTaggingRequest),
			typeof(PutBucketVersioningRequest),
			typeof(PutBucketWebsiteRequest),
			typeof(PutCORSConfigurationRequest),
			typeof(PutLifecycleConfigurationRequest),
			typeof(PutObjectRequest),
			typeof(PutObjectAclRequest),
			typeof(PutObjectLegalHoldRequest),
			typeof(PutObjectLockConfigurationRequest),
			typeof(PutObjectRetentionRequest),
			typeof(PutObjectTaggingRequest),
			typeof(PutPublicAccessBlockRequest),
			typeof(RestoreObjectRequest),
			typeof(SelectObjectContentRequest),
			typeof(UploadPartRequest),
			typeof(WriteGetObjectResponseRequest)
		};

		public AmazonS3RetryPolicy(IClientConfig config)
			: base(config)
		{
		}

		public bool? RetryForExceptionSync(IExecutionContext executionContext, Exception exception)
		{
			return SharedRetryForExceptionSync(executionContext, exception, base.Logger, base.RetryForException);
		}

		internal static bool? SharedRetryForExceptionSync(IExecutionContext executionContext, Exception exception, ILogger logger, Func<IExecutionContext, Exception, bool> baseRetryForException)
		{
			if (exception is AmazonServiceException ex)
			{
				if (ex.StatusCode == HttpStatusCode.OK)
				{
					Type type = executionContext.RequestContext.OriginalRequest.GetType();
					if (RequestsWith200Error.Contains(type))
					{
						return true;
					}
				}
				if (ex.StatusCode == HttpStatusCode.BadRequest)
				{
					ServiceOperationEndpointParameters parameters = new ServiceOperationEndpointParameters(executionContext.RequestContext.OriginalRequest);
					if (new Uri(executionContext.RequestContext.ClientConfig.DetermineServiceOperationEndpoint(parameters).URL).Host.Equals("s3.amazonaws.com") && (ex.Message.Contains("AWS4-HMAC-SHA256") || ex.Message.Contains("AWS KMS managed keys require AWS Signature Version 4")))
					{
						logger.InfoFormat("Request {0}: the bucket you are attempting to access should be addressed using a region-specific endpoint. Additional calls will be made to attempt to determine the correct region to be used. For better performance configure your client to use the correct region.", executionContext.RequestContext.RequestName);
						IRequest request = executionContext.RequestContext.Request;
						AmazonS3Uri amazonS3Uri = new AmazonS3Uri(request.Endpoint);
						string uriString = string.Format(CultureInfo.InvariantCulture, "https://{0}.{1}", amazonS3Uri.Bucket, "s3-external-1.amazonaws.com");
						request.Endpoint = new Uri(uriString);
						if (ex.Message.Contains("AWS KMS managed keys require AWS Signature Version 4"))
						{
							request.SignatureVersion = SignatureVersion.SigV4;
							request.AuthenticationRegion = RegionEndpoint.USEast1.SystemName;
							executionContext.RequestContext.IsSigned = false;
						}
						return true;
					}
					return null;
				}
			}
			return baseRetryForException(executionContext, exception);
		}

		public override async Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception)
		{
			return await SharedRetryForExceptionAsync(executionContext, exception, RetryForExceptionSync, [DebuggerHidden] (IExecutionContext executionContext2, Exception exception2) => RetryForException(executionContext2, exception2)).ConfigureAwait(continueOnCapturedContext: false);
		}

		internal static async Task<bool> SharedRetryForExceptionAsync(IExecutionContext executionContext, Exception exception, Func<IExecutionContext, Exception, bool?> retryForExceptionSync, Func<IExecutionContext, Exception, bool> baseRetryForException)
		{
			bool? flag = retryForExceptionSync(executionContext, exception);
			if (flag.HasValue)
			{
				return flag.Value;
			}
			AmazonServiceException serviceException = exception as AmazonServiceException;
			string text = null;
			if (AmazonS3Uri.TryParseAmazonS3Uri(executionContext.RequestContext.Request.Endpoint, out var amazonS3Uri))
			{
				text = await BucketRegionDetector.DetectMismatchWithHeadBucketFallbackAsync(amazonS3Uri, serviceException, executionContext.RequestContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (text == null)
			{
				return baseRetryForException(executionContext, exception);
			}
			executionContext.RequestContext.Request.AuthenticationRegion = text;
			executionContext.RequestContext.IsSigned = false;
			return true;
		}
	}
}
