using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class ServerSideEncryptionConfiguration
	{
		private List<ServerSideEncryptionRule> serverSideEncryptionRules = (AWSConfigs.InitializeCollections ? new List<ServerSideEncryptionRule>() : null);

		public List<ServerSideEncryptionRule> ServerSideEncryptionRules
		{
			get
			{
				return serverSideEncryptionRules;
			}
			set
			{
				serverSideEncryptionRules = value;
			}
		}

		internal bool IsSetServerSideEncryptionRules()
		{
			if (serverSideEncryptionRules != null)
			{
				if (serverSideEncryptionRules.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}
	}
}
