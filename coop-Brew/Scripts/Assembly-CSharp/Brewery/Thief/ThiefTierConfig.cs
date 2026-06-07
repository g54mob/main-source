using System;
using UnityEngine;

namespace Brewery.Thief
{
	[Serializable]
	public class ThiefTierConfig
	{
		[Tooltip("Day number when this tier activates (1 = first day).")]
		public int dayThreshold;

		[Tooltip("Number of stealers spawned at this tier.")]
		[Range(0f, 10f)]
		public int stealerCount;

		[Tooltip("Number of defenders spawned at this tier.")]
		[Range(0f, 10f)]
		public int defenderCount;

		[Tooltip("Optional: Display name for this tier (for debug).")]
		public string tierName;

		public int TotalCount => 0;

		public ThiefTierConfig()
		{
		}

		public ThiefTierConfig(int day, int stealers, int defenders, string name = "")
		{
		}
	}
}
