using System;
using UnityEngine;

[Serializable]
public enum eTowerTier
{
	NONE = 0,
	[InspectorName("基本塔 (Tier 1)")]
	TIER_1 = 1,
	[InspectorName("中階塔 (Tier 2)")]
	TIER_2 = 2,
	[InspectorName("高階塔 (Tier 3)")]
	TIER_3 = 3,
	[InspectorName("稀有塔 (Tier 4)")]
	TIER_4 = 4
}
