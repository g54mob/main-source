using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketOwnershipControlsResponse : AmazonWebServiceResponse
	{
		private OwnershipControls ownershipControls;

		public OwnershipControls OwnershipControls
		{
			get
			{
				if (ownershipControls == null)
				{
					ownershipControls = new OwnershipControls();
				}
				return ownershipControls;
			}
			set
			{
				ownershipControls = value;
			}
		}
	}
}
