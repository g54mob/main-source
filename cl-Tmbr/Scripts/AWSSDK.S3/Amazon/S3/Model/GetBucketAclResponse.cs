using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketAclResponse : AmazonWebServiceResponse
	{
		private List<S3Grant> _grants = (AWSConfigs.InitializeCollections ? new List<S3Grant>() : null);

		private Owner _owner;

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

		public Owner Owner
		{
			get
			{
				return _owner;
			}
			set
			{
				_owner = value;
			}
		}

		internal bool IsSetGrants()
		{
			if (_grants != null)
			{
				if (_grants.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetOwner()
		{
			return _owner != null;
		}
	}
}
