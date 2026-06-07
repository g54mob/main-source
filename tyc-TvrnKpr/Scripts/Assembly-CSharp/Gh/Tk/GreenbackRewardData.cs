using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class GreenbackRewardData
	{
		public string Id { get; set; }

		public string RewardKey { get; set; }

		public List<GreenbackCardData> Cards { get; set; }

		public int StarTokens { get; set; }

		public int StarTokenPrevious { get; set; }

		public string RewardReason { get; set; }

		public DateTime ClaimedAt { get; set; }

		public bool Unpacked { get; set; }

		public int GetStarTokensDelta()
		{
			return 0;
		}

		public string GetDisplayReason()
		{
			return null;
		}
	}
}
