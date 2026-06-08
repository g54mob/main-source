using System.Collections.Generic;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Internal
{
	public class AmazonS3Metadata : IServiceMetadata
	{
		public string ServiceId => "S3";

		public IDictionary<string, string> OperationNameMapping => new Dictionary<string, string>(13)
		{
			{ "PutBucket", "CreateBucket" },
			{ "InitiateMultipartUpload", "CreateMultipartUpload" },
			{ "DeleteCORSConfiguration", "DeleteBucketCors" },
			{ "DeleteLifecycleConfiguration", "DeleteBucketLifecycle" },
			{ "GetCORSConfiguration", "GetBucketCors" },
			{ "GetLifecycleConfiguration", "GetBucketLifecycleConfiguration" },
			{ "GetBucketNotification", "GetBucketNotificationConfiguration" },
			{ "GetObjectMetadata", "HeadObject" },
			{ "ListVersions", "ListObjectVersions" },
			{ "PutCORSConfiguration", "PutBucketCors" },
			{ "PutLifecycleConfiguration", "PutBucketLifecycleConfiguration" },
			{ "PutBucketNotification", "PutBucketNotificationConfiguration" },
			{ "CopyPart", "UploadPartCopy" }
		};
	}
}
