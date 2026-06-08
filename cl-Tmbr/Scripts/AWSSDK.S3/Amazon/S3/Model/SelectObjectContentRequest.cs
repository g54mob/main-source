using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class SelectObjectContentRequest : AmazonWebServiceRequest
	{
		private string expectedBucketOwner;

		public string BucketName { get; set; }

		public string Key { get; set; }

		public ServerSideEncryptionCustomerMethod ServerSideCustomerEncryptionMethod { get; set; }

		[AWSProperty(Sensitive = true)]
		public string ServerSideEncryptionCustomerProvidedKey { get; set; }

		public string ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

		public string Expression { get; set; }

		public ExpressionType ExpressionType { get; set; }

		public bool? RequestProgress { get; set; }

		public InputSerialization InputSerialization { get; set; }

		public OutputSerialization OutputSerialization { get; set; }

		public ScanRange ScanRange { get; set; }

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

		internal bool IsSetKey()
		{
			return Key != null;
		}

		internal bool IsSetServerSideCustomerEncryptionMethod()
		{
			return ServerSideCustomerEncryptionMethod != null;
		}

		internal bool IsSetServerSideEncryptionCustomerProvidedKey()
		{
			return ServerSideEncryptionCustomerProvidedKey != null;
		}

		internal bool IsSetServerSideEncryptionCustomerProvidedKeyMD5()
		{
			return ServerSideEncryptionCustomerProvidedKeyMD5 != null;
		}

		internal bool IsSetExpression()
		{
			return Expression != null;
		}

		internal bool IsSetExpressionType()
		{
			return ExpressionType != null;
		}

		internal bool IsSetRequestProgress()
		{
			return RequestProgress.HasValue;
		}

		internal bool IsSetInputSerialization()
		{
			return InputSerialization != null;
		}

		internal bool IsSetOutputSerialization()
		{
			return OutputSerialization != null;
		}

		internal bool IsSetScanRange()
		{
			return ScanRange != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
