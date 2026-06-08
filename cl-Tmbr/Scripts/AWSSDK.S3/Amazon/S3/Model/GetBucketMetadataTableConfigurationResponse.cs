using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketMetadataTableConfigurationResponse : AmazonWebServiceResponse
	{
		private GetBucketMetadataTableConfigurationResult getBucketMetadataTableConfigurationResult;

		public GetBucketMetadataTableConfigurationResult GetBucketMetadataTableConfigurationResult
		{
			get
			{
				return getBucketMetadataTableConfigurationResult;
			}
			set
			{
				getBucketMetadataTableConfigurationResult = value;
			}
		}
	}
}
