using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class OwnershipControls
	{
		private List<OwnershipControlsRule> rules = (AWSConfigs.InitializeCollections ? new List<OwnershipControlsRule>() : null);

		public List<OwnershipControlsRule> Rules
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
	}
}
