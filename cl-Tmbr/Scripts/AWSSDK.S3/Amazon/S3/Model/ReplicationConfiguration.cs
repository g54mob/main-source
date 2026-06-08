using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class ReplicationConfiguration
	{
		private string role;

		private List<ReplicationRule> rules = (AWSConfigs.InitializeCollections ? new List<ReplicationRule>() : null);

		public string Role
		{
			get
			{
				return role;
			}
			set
			{
				role = value;
			}
		}

		public List<ReplicationRule> Rules
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

		internal bool IsSetRole()
		{
			return !string.IsNullOrEmpty(role);
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
