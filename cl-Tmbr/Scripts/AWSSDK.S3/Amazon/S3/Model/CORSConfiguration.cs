using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class CORSConfiguration
	{
		private List<CORSRule> rules = (AWSConfigs.InitializeCollections ? new List<CORSRule>() : null);

		public List<CORSRule> Rules
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
