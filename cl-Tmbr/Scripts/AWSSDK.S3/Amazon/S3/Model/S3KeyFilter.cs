using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class S3KeyFilter
	{
		private List<FilterRule> filterRules = (AWSConfigs.InitializeCollections ? new List<FilterRule>() : null);

		public List<FilterRule> FilterRules
		{
			get
			{
				return filterRules;
			}
			set
			{
				filterRules = value;
			}
		}

		internal bool IsSetFilterRules()
		{
			if (filterRules != null)
			{
				if (filterRules.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}
	}
}
