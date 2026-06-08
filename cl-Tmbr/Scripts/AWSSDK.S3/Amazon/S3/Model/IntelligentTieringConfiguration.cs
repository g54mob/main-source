using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class IntelligentTieringConfiguration
	{
		private string intelligentTieringId;

		private IntelligentTieringFilter intelligentTieringFilter;

		private IntelligentTieringStatus status;

		private List<Tiering> tierings = (AWSConfigs.InitializeCollections ? new List<Tiering>() : null);

		public string IntelligentTieringId
		{
			get
			{
				return intelligentTieringId;
			}
			set
			{
				intelligentTieringId = value;
			}
		}

		public IntelligentTieringFilter IntelligentTieringFilter
		{
			get
			{
				return intelligentTieringFilter;
			}
			set
			{
				intelligentTieringFilter = value;
			}
		}

		public IntelligentTieringStatus Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}
		}

		public List<Tiering> Tierings
		{
			get
			{
				return tierings;
			}
			set
			{
				tierings = value;
			}
		}

		internal bool IsSetIntelligentTieringId()
		{
			return !string.IsNullOrEmpty(intelligentTieringId);
		}

		internal bool IsSetIntelligentTieringFilter()
		{
			return intelligentTieringFilter != null;
		}

		internal bool IsSetStatus()
		{
			return status != null;
		}

		internal bool IsSetTieringList()
		{
			if (tierings != null)
			{
				if (tierings.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}
	}
}
