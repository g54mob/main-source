using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class GreenbackUserInventory
	{
		public List<GreenbackCardData> CardsCollection { get; set; }

		public int StarTokens { get; set; }

		public List<GreenbackRewardData> RewardLog { get; set; }

		public List<string> ImportedCodes { get; set; }

		public List<string> AuthoredCodes { get; set; }

		public DateTime LastModified { get; set; }

		public int FormatVersion { get; set; }
	}
}
