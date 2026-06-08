using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketTaggingResponse : AmazonWebServiceResponse
	{
		private List<Tag> tagSet = (AWSConfigs.InitializeCollections ? new List<Tag>() : null);

		public List<Tag> TagSet
		{
			get
			{
				return tagSet;
			}
			set
			{
				tagSet = value;
			}
		}

		internal bool IsSetTagSet()
		{
			if (tagSet != null)
			{
				if (tagSet.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}
	}
}
