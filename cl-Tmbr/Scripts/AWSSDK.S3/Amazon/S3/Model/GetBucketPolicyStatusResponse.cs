using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketPolicyStatusResponse : AmazonWebServiceResponse
	{
		private PolicyStatus policyStatus;

		public PolicyStatus PolicyStatus
		{
			get
			{
				return policyStatus;
			}
			set
			{
				policyStatus = value;
			}
		}

		internal bool IsSetPolicyStatus()
		{
			return policyStatus != null;
		}
	}
}
