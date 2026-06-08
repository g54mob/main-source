using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketPolicyRequest : AmazonWebServiceRequest
	{
		private ChecksumAlgorithm _checksumAlgorithm;

		private bool? confirmRemoveSelfBucketAccess;

		private string expectedBucketOwner;

		public string BucketName { get; set; }

		public ChecksumAlgorithm ChecksumAlgorithm
		{
			get
			{
				return _checksumAlgorithm;
			}
			set
			{
				_checksumAlgorithm = value;
			}
		}

		public string ContentMD5 { get; set; }

		public string Policy { get; set; }

		public bool? ConfirmRemoveSelfBucketAccess
		{
			get
			{
				return confirmRemoveSelfBucketAccess;
			}
			set
			{
				confirmRemoveSelfBucketAccess = value;
			}
		}

		protected override bool IncludeSHA256Header => false;

		public string ExpectedBucketOwner
		{
			get
			{
				return expectedBucketOwner;
			}
			set
			{
				expectedBucketOwner = value;
			}
		}

		internal bool IsSetBucket()
		{
			return BucketName != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetContentMD5()
		{
			return ContentMD5 != null;
		}

		internal bool IsSetPolicy()
		{
			return Policy != null;
		}

		internal bool IsSetConfirmRemoveSelfBucketAccess()
		{
			return confirmRemoveSelfBucketAccess.HasValue;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
