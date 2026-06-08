using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class ReplicationRuleAndOperator
	{
		private string prefix;

		private List<Tag> tags = (AWSConfigs.InitializeCollections ? new List<Tag>() : null);

		public string Prefix
		{
			get
			{
				return prefix;
			}
			set
			{
				prefix = value;
			}
		}

		public List<Tag> Tags
		{
			get
			{
				return tags;
			}
			set
			{
				tags = value;
			}
		}

		internal bool IsSetPrefix()
		{
			return !string.IsNullOrEmpty(prefix);
		}

		internal bool IsSetTags()
		{
			if (tags != null)
			{
				if (tags.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}
	}
}
