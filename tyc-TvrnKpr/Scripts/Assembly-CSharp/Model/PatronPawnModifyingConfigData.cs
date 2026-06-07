using System;
using Gh.Tk.Story.Config;

namespace Model
{
	[Serializable]
	public class PatronPawnModifyingConfigData : IPatronPawnModifyingConfig, IPatronPawnModifyingFilterConfig
	{
		public bool deletePawns { get; set; }

		public bool removeAllNonBasicNeeds { get; set; }

		public bool disableImpromptuOptionalNeeds { get; set; }

		public string[] removeNeeds { get; set; }

		public string[] forceNeeds { get; set; }

		public SecondaryNeedConfig[] secondaryNeeds { get; set; }

		public bool removeReputationRequirements { get; set; }

		public string[] traits { get; set; }

		public string[] conversationThemes { get; set; }

		public int minTier { get; set; }

		public int maxTier { get; set; }

		public int percentageAffected { get; set; }
	}
}
