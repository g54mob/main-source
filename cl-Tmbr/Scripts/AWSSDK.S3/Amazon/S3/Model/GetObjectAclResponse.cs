using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetObjectAclResponse : AmazonWebServiceResponse
	{
		private List<S3Grant> _grants = (AWSConfigs.InitializeCollections ? new List<S3Grant>() : null);

		private Owner _owner;

		private RequestCharged _requestCharged;

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

		public RequestCharged RequestCharged
		{
			get
			{
				return _requestCharged;
			}
			set
			{
				_requestCharged = value;
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

		internal bool IsSetRequestCharged()
		{
			return !string.IsNullOrEmpty(_requestCharged);
		}
	}
}
