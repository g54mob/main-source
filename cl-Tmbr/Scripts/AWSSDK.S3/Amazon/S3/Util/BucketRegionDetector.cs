using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Model;

namespace Amazon.S3.Util
{
	public static class BucketRegionDetector
	{
		private const int BucketRegionCacheMaxEntries = 300;

		private const string AuthorizationHeaderMalformedErrorCode = "AuthorizationHeaderMalformed";

		public static LruCache<string, RegionEndpoint> BucketRegionCache { get; private set; }

		static BucketRegionDetector()
		{
			BucketRegionCache = new LruCache<string, RegionEndpoint>(300);
		}

		internal static string GetCorrectRegion(AmazonS3Uri requestedBucketUri, HttpStatusCode headBucketStatusCode, string xAmzBucketRegionHeaderValue)
		{
			if (xAmzBucketRegionHeaderValue != null && headBucketStatusCode == HttpStatusCode.BadRequest)
			{
				return CheckRegionAndUpdateCache(requestedBucketUri, xAmzBucketRegionHeaderValue);
			}
			return null;
		}

		private static string GetCorrectRegion(AmazonS3Uri requestedBucketUri, AmazonServiceException serviceException)
		{
			string text = null;
			string text2 = null;
			if (serviceException is AmazonS3Exception ex)
			{
				if (string.Equals(ex.ErrorCode, "AuthorizationHeaderMalformed", StringComparison.Ordinal))
				{
					text = CheckRegionAndUpdateCache(requestedBucketUri, ex.Region);
				}
				if (text == null && ex.InnerException is HttpErrorResponseException { Response: not null } ex2 && ex2.Response.IsHeaderPresent("x-amz-bucket-region"))
				{
					text2 = CheckRegionAndUpdateCache(requestedBucketUri, ex2.Response.GetHeaderValue("x-amz-bucket-region"));
				}
			}
			return text ?? text2;
		}

		private static string CheckRegionAndUpdateCache(AmazonS3Uri requestedBucketUri, string actualRegion)
		{
			string a = ((requestedBucketUri.Region == null) ? null : requestedBucketUri.Region.SystemName);
			if (actualRegion != null && !string.Equals(a, actualRegion, StringComparison.Ordinal))
			{
				BucketRegionCache.AddOrUpdate(requestedBucketUri.Bucket, RegionEndpoint.GetBySystemName(actualRegion));
				return actualRegion;
			}
			return null;
		}

		private static string GetHeadBucketPreSignedUrl(string bucketName, IRequestContext requestContext)
		{
			using AmazonS3Client amazonS3Client = GetUsEast1ClientFromCredentials(requestContext.ClientConfig.DefaultAWSCredentials);
			if (requestContext.ClientConfig is AmazonS3Config amazonS3Config)
			{
				(amazonS3Client.Config as AmazonS3Config).S3ExpressCredentialProvider = amazonS3Config.S3ExpressCredentialProvider;
			}
			GetPreSignedUrlRequest getPreSignedUrlRequest = new GetPreSignedUrlRequest
			{
				BucketName = bucketName,
				Verb = HttpVerb.HEAD,
				Protocol = Protocol.HTTP
			};
			ServiceOperationEndpointParameters parameters = new ServiceOperationEndpointParameters(getPreSignedUrlRequest);
			Endpoint endpoint = amazonS3Client.Config.DetermineServiceOperationEndpoint(parameters);
			getPreSignedUrlRequest.Expires = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(endpoint.URL).AddDays(1.0);
			return amazonS3Client.GetPreSignedURLInternal(getPreSignedUrlRequest);
		}

		private static AmazonS3Client GetUsEast1ClientFromCredentials(AWSCredentials credentials)
		{
			return new AmazonS3Client(credentials, RegionEndpoint.USEast1);
		}

		internal static async Task<string> DetectMismatchWithHeadBucketFallbackAsync(AmazonS3Uri requestedBucketUri, AmazonServiceException serviceException, IRequestContext requestContext)
		{
			string text = GetCorrectRegion(requestedBucketUri, serviceException);
			if (text == null)
			{
				text = CheckRegionAndUpdateCache(requestedBucketUri, await GetBucketRegionNoPipelineAsync(requestedBucketUri.Bucket, requestContext).ConfigureAwait(continueOnCapturedContext: false));
			}
			return text;
		}

		private static async Task<string> GetBucketRegionNoPipelineAsync(string bucketName, IRequestContext requestContext)
		{
			string headBucketPreSignedUrl = GetHeadBucketPreSignedUrl(bucketName, requestContext);
			using AmazonS3Client s3Client = GetUsEast1ClientFromCredentials(requestContext.ClientConfig.DefaultAWSCredentials);
			return (await AmazonS3HttpUtil.GetHeadAsync(s3Client, s3Client.Config, headBucketPreSignedUrl, "x-amz-bucket-region").ConfigureAwait(continueOnCapturedContext: false)).HeaderValue;
		}
	}
}
