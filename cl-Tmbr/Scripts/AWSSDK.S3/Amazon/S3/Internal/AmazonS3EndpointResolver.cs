using System;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal;
using Amazon.S3.Endpoints;
using Amazon.S3.Model;
using Amazon.Util;

namespace Amazon.S3.Internal
{
	public class AmazonS3EndpointResolver : BaseEndpointResolver
	{
		protected override void ServiceSpecificHandler(IExecutionContext executionContext, EndpointParameters parameters)
		{
			if (parameters["Bucket"] != null)
			{
				executionContext.RequestContext.Request.CanonicalResourcePrefix = "/" + parameters["Bucket"];
			}
			if (executionContext.RequestContext.Request.Headers.TryGetValue("x-amz-server-side-encryption", out var value) && (string.Equals(value, ServerSideEncryptionMethod.AWSKMS.Value, StringComparison.Ordinal) || string.Equals(value, ServerSideEncryptionMethod.AWSKMSDSSE.Value, StringComparison.Ordinal)))
			{
				executionContext.RequestContext.Request.SignatureVersion = SignatureVersion.SigV4;
			}
			BaseEndpointResolver.InjectHostPrefix(executionContext.RequestContext);
		}

		protected override EndpointParameters MapEndpointsParameters(IRequestContext requestContext)
		{
			AmazonS3Config amazonS3Config = (AmazonS3Config)requestContext.ClientConfig;
			S3EndpointParameters s3EndpointParameters = new S3EndpointParameters();
			s3EndpointParameters.Region = requestContext.Request.AlternateEndpoint?.SystemName ?? amazonS3Config.RegionEndpoint?.SystemName;
			s3EndpointParameters.UseFIPS = amazonS3Config.UseFIPSEndpoint;
			s3EndpointParameters.UseDualStack = amazonS3Config.UseDualstackEndpoint;
			s3EndpointParameters.Endpoint = amazonS3Config.ServiceURL;
			s3EndpointParameters.ForcePathStyle = amazonS3Config.ForcePathStyle;
			s3EndpointParameters.Accelerate = amazonS3Config.UseAccelerateEndpoint;
			s3EndpointParameters.UseGlobalEndpoint = amazonS3Config.USEast1RegionalEndpointValue == S3UsEast1RegionalEndpointValue.Legacy;
			s3EndpointParameters.DisableMultiRegionAccessPoints = amazonS3Config.DisableMultiregionAccessPoints;
			s3EndpointParameters.UseArnRegion = amazonS3Config.UseArnRegion;
			if (amazonS3Config.RegionEndpoint == null && !string.IsNullOrEmpty(amazonS3Config.ServiceURL))
			{
				if (!string.IsNullOrEmpty(amazonS3Config.AuthenticationRegion))
				{
					s3EndpointParameters.Region = amazonS3Config.AuthenticationRegion;
				}
				else
				{
					string systemName = AWSSDKUtils.DetermineRegion(amazonS3Config.ServiceURL);
					s3EndpointParameters.Region = RegionEndpoint.GetBySystemName(systemName).SystemName;
				}
			}
			if (s3EndpointParameters.Region == "us-east-1-regional")
			{
				s3EndpointParameters.Region = "us-east-1";
			}
			if (requestContext.Request.AlternateEndpoint != null)
			{
				s3EndpointParameters.Region = requestContext.Request.AlternateEndpoint.SystemName;
			}
			if (requestContext.Request.RequestName == "GetPreSignedUrlRequest")
			{
				GetPreSignedUrlRequest getPreSignedUrlRequest = (GetPreSignedUrlRequest)requestContext.Request.OriginalRequest;
				s3EndpointParameters.Bucket = getPreSignedUrlRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetACLRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetACLRequest getACLRequest = (GetACLRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getACLRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutACLRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutACLRequest putACLRequest = (PutACLRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putACLRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "AbortMultipartUploadRequest")
			{
				AbortMultipartUploadRequest abortMultipartUploadRequest = (AbortMultipartUploadRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = abortMultipartUploadRequest.BucketName;
				s3EndpointParameters.Key = abortMultipartUploadRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "CompleteMultipartUploadRequest")
			{
				CompleteMultipartUploadRequest completeMultipartUploadRequest = (CompleteMultipartUploadRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = completeMultipartUploadRequest.BucketName;
				s3EndpointParameters.Key = completeMultipartUploadRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "CopyObjectRequest")
			{
				s3EndpointParameters.DisableS3ExpressSessionAuth = true;
				CopyObjectRequest copyObjectRequest = (CopyObjectRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = copyObjectRequest.DestinationBucket;
				s3EndpointParameters.Key = copyObjectRequest.DestinationKey;
				s3EndpointParameters.CopySource = copyObjectRequest.SourceKey;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "CopyPartRequest")
			{
				s3EndpointParameters.DisableS3ExpressSessionAuth = true;
				CopyPartRequest copyPartRequest = (CopyPartRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = copyPartRequest.DestinationBucket;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "CreateBucketMetadataTableConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				CreateBucketMetadataTableConfigurationRequest createBucketMetadataTableConfigurationRequest = (CreateBucketMetadataTableConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = createBucketMetadataTableConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "CreateSessionRequest")
			{
				s3EndpointParameters.DisableS3ExpressSessionAuth = true;
				CreateSessionRequest createSessionRequest = (CreateSessionRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = createSessionRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketRequest deleteBucketRequest = (DeleteBucketRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketAnalyticsConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketAnalyticsConfigurationRequest deleteBucketAnalyticsConfigurationRequest = (DeleteBucketAnalyticsConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketAnalyticsConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketEncryptionRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketEncryptionRequest deleteBucketEncryptionRequest = (DeleteBucketEncryptionRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketEncryptionRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketIntelligentTieringConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketIntelligentTieringConfigurationRequest deleteBucketIntelligentTieringConfigurationRequest = (DeleteBucketIntelligentTieringConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketIntelligentTieringConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketInventoryConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketInventoryConfigurationRequest deleteBucketInventoryConfigurationRequest = (DeleteBucketInventoryConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketInventoryConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketMetadataTableConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketMetadataTableConfigurationRequest deleteBucketMetadataTableConfigurationRequest = (DeleteBucketMetadataTableConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketMetadataTableConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketMetricsConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketMetricsConfigurationRequest deleteBucketMetricsConfigurationRequest = (DeleteBucketMetricsConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketMetricsConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketOwnershipControlsRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketOwnershipControlsRequest deleteBucketOwnershipControlsRequest = (DeleteBucketOwnershipControlsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketOwnershipControlsRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketPolicyRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketPolicyRequest deleteBucketPolicyRequest = (DeleteBucketPolicyRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketPolicyRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketReplicationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketReplicationRequest deleteBucketReplicationRequest = (DeleteBucketReplicationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketReplicationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketTaggingRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketTaggingRequest deleteBucketTaggingRequest = (DeleteBucketTaggingRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketTaggingRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteBucketWebsiteRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteBucketWebsiteRequest deleteBucketWebsiteRequest = (DeleteBucketWebsiteRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteBucketWebsiteRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteCORSConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteCORSConfigurationRequest deleteCORSConfigurationRequest = (DeleteCORSConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteCORSConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteLifecycleConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeleteLifecycleConfigurationRequest deleteLifecycleConfigurationRequest = (DeleteLifecycleConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteLifecycleConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteObjectRequest")
			{
				DeleteObjectRequest deleteObjectRequest = (DeleteObjectRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteObjectRequest.BucketName;
				s3EndpointParameters.Key = deleteObjectRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteObjectsRequest")
			{
				DeleteObjectsRequest deleteObjectsRequest = (DeleteObjectsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteObjectsRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeleteObjectTaggingRequest")
			{
				DeleteObjectTaggingRequest deleteObjectTaggingRequest = (DeleteObjectTaggingRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deleteObjectTaggingRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "DeletePublicAccessBlockRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				DeletePublicAccessBlockRequest deletePublicAccessBlockRequest = (DeletePublicAccessBlockRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = deletePublicAccessBlockRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketAccelerateConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketAccelerateConfigurationRequest getBucketAccelerateConfigurationRequest = (GetBucketAccelerateConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketAccelerateConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketAclRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketAclRequest getBucketAclRequest = (GetBucketAclRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketAclRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketAnalyticsConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketAnalyticsConfigurationRequest getBucketAnalyticsConfigurationRequest = (GetBucketAnalyticsConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketAnalyticsConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketEncryptionRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketEncryptionRequest getBucketEncryptionRequest = (GetBucketEncryptionRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketEncryptionRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketIntelligentTieringConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketIntelligentTieringConfigurationRequest getBucketIntelligentTieringConfigurationRequest = (GetBucketIntelligentTieringConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketIntelligentTieringConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketInventoryConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketInventoryConfigurationRequest getBucketInventoryConfigurationRequest = (GetBucketInventoryConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketInventoryConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketLocationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketLocationRequest getBucketLocationRequest = (GetBucketLocationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketLocationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketLoggingRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketLoggingRequest getBucketLoggingRequest = (GetBucketLoggingRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketLoggingRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketMetadataTableConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketMetadataTableConfigurationRequest getBucketMetadataTableConfigurationRequest = (GetBucketMetadataTableConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketMetadataTableConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketMetricsConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketMetricsConfigurationRequest getBucketMetricsConfigurationRequest = (GetBucketMetricsConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketMetricsConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketNotificationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketNotificationRequest getBucketNotificationRequest = (GetBucketNotificationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketNotificationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketOwnershipControlsRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketOwnershipControlsRequest getBucketOwnershipControlsRequest = (GetBucketOwnershipControlsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketOwnershipControlsRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketPolicyRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketPolicyRequest getBucketPolicyRequest = (GetBucketPolicyRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketPolicyRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketPolicyStatusRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketPolicyStatusRequest getBucketPolicyStatusRequest = (GetBucketPolicyStatusRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketPolicyStatusRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketReplicationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketReplicationRequest getBucketReplicationRequest = (GetBucketReplicationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketReplicationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketRequestPaymentRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketRequestPaymentRequest getBucketRequestPaymentRequest = (GetBucketRequestPaymentRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketRequestPaymentRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketTaggingRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketTaggingRequest getBucketTaggingRequest = (GetBucketTaggingRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketTaggingRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketVersioningRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketVersioningRequest getBucketVersioningRequest = (GetBucketVersioningRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketVersioningRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetBucketWebsiteRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetBucketWebsiteRequest getBucketWebsiteRequest = (GetBucketWebsiteRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getBucketWebsiteRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetCORSConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetCORSConfigurationRequest getCORSConfigurationRequest = (GetCORSConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getCORSConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetLifecycleConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetLifecycleConfigurationRequest getLifecycleConfigurationRequest = (GetLifecycleConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getLifecycleConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectRequest")
			{
				GetObjectRequest getObjectRequest = (GetObjectRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectRequest.BucketName;
				s3EndpointParameters.Key = getObjectRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectAclRequest")
			{
				GetObjectAclRequest getObjectAclRequest = (GetObjectAclRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectAclRequest.BucketName;
				s3EndpointParameters.Key = getObjectAclRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectAttributesRequest")
			{
				GetObjectAttributesRequest getObjectAttributesRequest = (GetObjectAttributesRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectAttributesRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectLegalHoldRequest")
			{
				GetObjectLegalHoldRequest getObjectLegalHoldRequest = (GetObjectLegalHoldRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectLegalHoldRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectLockConfigurationRequest")
			{
				GetObjectLockConfigurationRequest getObjectLockConfigurationRequest = (GetObjectLockConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectLockConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectMetadataRequest")
			{
				GetObjectMetadataRequest getObjectMetadataRequest = (GetObjectMetadataRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectMetadataRequest.BucketName;
				s3EndpointParameters.Key = getObjectMetadataRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectRetentionRequest")
			{
				GetObjectRetentionRequest getObjectRetentionRequest = (GetObjectRetentionRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectRetentionRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectTaggingRequest")
			{
				GetObjectTaggingRequest getObjectTaggingRequest = (GetObjectTaggingRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectTaggingRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetObjectTorrentRequest")
			{
				GetObjectTorrentRequest getObjectTorrentRequest = (GetObjectTorrentRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getObjectTorrentRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "GetPublicAccessBlockRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				GetPublicAccessBlockRequest getPublicAccessBlockRequest = (GetPublicAccessBlockRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = getPublicAccessBlockRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "HeadBucketRequest")
			{
				HeadBucketRequest headBucketRequest = (HeadBucketRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = headBucketRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "InitiateMultipartUploadRequest")
			{
				InitiateMultipartUploadRequest initiateMultipartUploadRequest = (InitiateMultipartUploadRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = initiateMultipartUploadRequest.BucketName;
				s3EndpointParameters.Key = initiateMultipartUploadRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListBucketAnalyticsConfigurationsRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				ListBucketAnalyticsConfigurationsRequest listBucketAnalyticsConfigurationsRequest = (ListBucketAnalyticsConfigurationsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listBucketAnalyticsConfigurationsRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListBucketIntelligentTieringConfigurationsRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				ListBucketIntelligentTieringConfigurationsRequest listBucketIntelligentTieringConfigurationsRequest = (ListBucketIntelligentTieringConfigurationsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listBucketIntelligentTieringConfigurationsRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListBucketInventoryConfigurationsRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				ListBucketInventoryConfigurationsRequest listBucketInventoryConfigurationsRequest = (ListBucketInventoryConfigurationsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listBucketInventoryConfigurationsRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListBucketMetricsConfigurationsRequest")
			{
				ListBucketMetricsConfigurationsRequest listBucketMetricsConfigurationsRequest = (ListBucketMetricsConfigurationsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listBucketMetricsConfigurationsRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListDirectoryBucketsRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListMultipartUploadsRequest")
			{
				ListMultipartUploadsRequest listMultipartUploadsRequest = (ListMultipartUploadsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listMultipartUploadsRequest.BucketName;
				s3EndpointParameters.Prefix = listMultipartUploadsRequest.Prefix;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListObjectsRequest")
			{
				ListObjectsRequest listObjectsRequest = (ListObjectsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listObjectsRequest.BucketName;
				s3EndpointParameters.Prefix = listObjectsRequest.Prefix;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListObjectsV2Request")
			{
				ListObjectsV2Request listObjectsV2Request = (ListObjectsV2Request)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listObjectsV2Request.BucketName;
				s3EndpointParameters.Prefix = listObjectsV2Request.Prefix;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListPartsRequest")
			{
				ListPartsRequest listPartsRequest = (ListPartsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listPartsRequest.BucketName;
				s3EndpointParameters.Key = listPartsRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "ListVersionsRequest")
			{
				ListVersionsRequest listVersionsRequest = (ListVersionsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = listVersionsRequest.BucketName;
				s3EndpointParameters.Prefix = listVersionsRequest.Prefix;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketRequest")
			{
				s3EndpointParameters.DisableAccessPoints = true;
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketRequest putBucketRequest = (PutBucketRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketAccelerateConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketAccelerateConfigurationRequest putBucketAccelerateConfigurationRequest = (PutBucketAccelerateConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketAccelerateConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketAclRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketAclRequest putBucketAclRequest = (PutBucketAclRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketAclRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketAnalyticsConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketAnalyticsConfigurationRequest putBucketAnalyticsConfigurationRequest = (PutBucketAnalyticsConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketAnalyticsConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketEncryptionRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketEncryptionRequest putBucketEncryptionRequest = (PutBucketEncryptionRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketEncryptionRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketIntelligentTieringConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketIntelligentTieringConfigurationRequest putBucketIntelligentTieringConfigurationRequest = (PutBucketIntelligentTieringConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketIntelligentTieringConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketInventoryConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketInventoryConfigurationRequest putBucketInventoryConfigurationRequest = (PutBucketInventoryConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketInventoryConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketLoggingRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketLoggingRequest putBucketLoggingRequest = (PutBucketLoggingRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketLoggingRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketMetricsConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketMetricsConfigurationRequest putBucketMetricsConfigurationRequest = (PutBucketMetricsConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketMetricsConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketNotificationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketNotificationRequest putBucketNotificationRequest = (PutBucketNotificationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketNotificationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketOwnershipControlsRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketOwnershipControlsRequest putBucketOwnershipControlsRequest = (PutBucketOwnershipControlsRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketOwnershipControlsRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketPolicyRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketPolicyRequest putBucketPolicyRequest = (PutBucketPolicyRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketPolicyRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketReplicationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketReplicationRequest putBucketReplicationRequest = (PutBucketReplicationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketReplicationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketRequestPaymentRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketRequestPaymentRequest putBucketRequestPaymentRequest = (PutBucketRequestPaymentRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketRequestPaymentRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketTaggingRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketTaggingRequest putBucketTaggingRequest = (PutBucketTaggingRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketTaggingRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketVersioningRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketVersioningRequest putBucketVersioningRequest = (PutBucketVersioningRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketVersioningRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutBucketWebsiteRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutBucketWebsiteRequest putBucketWebsiteRequest = (PutBucketWebsiteRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putBucketWebsiteRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutCORSConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutCORSConfigurationRequest putCORSConfigurationRequest = (PutCORSConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putCORSConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutLifecycleConfigurationRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutLifecycleConfigurationRequest putLifecycleConfigurationRequest = (PutLifecycleConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putLifecycleConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutObjectRequest")
			{
				PutObjectRequest putObjectRequest = (PutObjectRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putObjectRequest.BucketName;
				s3EndpointParameters.Key = putObjectRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutObjectAclRequest")
			{
				PutObjectAclRequest putObjectAclRequest = (PutObjectAclRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putObjectAclRequest.BucketName;
				s3EndpointParameters.Key = putObjectAclRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutObjectLegalHoldRequest")
			{
				PutObjectLegalHoldRequest putObjectLegalHoldRequest = (PutObjectLegalHoldRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putObjectLegalHoldRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutObjectLockConfigurationRequest")
			{
				PutObjectLockConfigurationRequest putObjectLockConfigurationRequest = (PutObjectLockConfigurationRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putObjectLockConfigurationRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutObjectRetentionRequest")
			{
				PutObjectRetentionRequest putObjectRetentionRequest = (PutObjectRetentionRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putObjectRetentionRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutObjectTaggingRequest")
			{
				PutObjectTaggingRequest putObjectTaggingRequest = (PutObjectTaggingRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putObjectTaggingRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "PutPublicAccessBlockRequest")
			{
				s3EndpointParameters.UseS3ExpressControlEndpoint = true;
				PutPublicAccessBlockRequest putPublicAccessBlockRequest = (PutPublicAccessBlockRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = putPublicAccessBlockRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "RestoreObjectRequest")
			{
				RestoreObjectRequest restoreObjectRequest = (RestoreObjectRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = restoreObjectRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "SelectObjectContentRequest")
			{
				SelectObjectContentRequest selectObjectContentRequest = (SelectObjectContentRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = selectObjectContentRequest.BucketName;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "UploadPartRequest")
			{
				UploadPartRequest uploadPartRequest = (UploadPartRequest)requestContext.OriginalRequest;
				s3EndpointParameters.Bucket = uploadPartRequest.BucketName;
				s3EndpointParameters.Key = uploadPartRequest.Key;
				return s3EndpointParameters;
			}
			if (requestContext.RequestName == "WriteGetObjectResponseRequest")
			{
				s3EndpointParameters.UseObjectLambdaEndpoint = true;
				return s3EndpointParameters;
			}
			return s3EndpointParameters;
		}
	}
}
