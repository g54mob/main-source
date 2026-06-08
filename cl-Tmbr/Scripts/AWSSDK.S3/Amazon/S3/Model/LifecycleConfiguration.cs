using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class LifecycleConfiguration
	{
		private List<LifecycleRule> rules = (AWSConfigs.InitializeCollections ? new List<LifecycleRule>() : null);

		public List<LifecycleRule> Rules
		{
			get
			{
				return rules;
			}
			set
			{
				rules = value;
			}
		}

		internal bool IsSetRules()
		{
			if (rules != null)
			{
				if (rules.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}
	}
}
