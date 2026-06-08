using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public abstract class PutWithACLRequest : AmazonWebServiceRequest
	{
		private List<S3Grant> _grants = (AWSConfigs.InitializeCollections ? new List<S3Grant>() : null);

		public List<S3Grant> Grants
		{
			get
			{
				return _grants;
			}
			set
			{
				_grants = value;
			}
		}
	}
}
