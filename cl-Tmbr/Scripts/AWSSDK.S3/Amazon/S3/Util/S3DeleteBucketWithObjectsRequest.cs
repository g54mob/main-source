using System;

namespace Amazon.S3.Util
{
	internal class S3DeleteBucketWithObjectsRequest
	{
		public string BucketName { get; set; }

		public IAmazonS3 S3Client { get; set; }

		public S3DeleteBucketWithObjectsOptions DeleteOptions { get; set; }

		public Action<S3DeleteBucketWithObjectsUpdate> UpdateCallback { get; set; }
	}
}
