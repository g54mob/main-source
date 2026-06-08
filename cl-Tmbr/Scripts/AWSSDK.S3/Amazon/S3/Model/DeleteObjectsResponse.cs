using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class DeleteObjectsResponse : AmazonWebServiceResponse
	{
		private List<DeletedObject> deleted = (AWSConfigs.InitializeCollections ? new List<DeletedObject>() : null);

		private List<DeleteError> errors = (AWSConfigs.InitializeCollections ? new List<DeleteError>() : null);

		private RequestCharged requestCharged;

		public List<DeletedObject> DeletedObjects
		{
			get
			{
				return deleted;
			}
			set
			{
				deleted = value;
			}
		}

		public List<DeleteError> DeleteErrors
		{
			get
			{
				return errors;
			}
			set
			{
				errors = value;
			}
		}

		public RequestCharged RequestCharged
		{
			get
			{
				return requestCharged;
			}
			set
			{
				requestCharged = value;
			}
		}

		internal bool IsSetDeletedObjects()
		{
			if (deleted != null)
			{
				if (deleted.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetDeleteErrors()
		{
			if (errors != null)
			{
				if (errors.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetRequestCharged()
		{
			return requestCharged != null;
		}
	}
}
