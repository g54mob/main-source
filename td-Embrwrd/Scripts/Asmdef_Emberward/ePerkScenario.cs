using System;

[Flags]
public enum ePerkScenario
{
	NONE = 0,
	ENDLESS_FOR_ROUND_END = 1,
	ANOMALY_LEVEL = 2,
	CHARACTER_ONLY = 4,
	INFERNO_SHARD = 8,
	SKELETON_KING = 0x10,
	ENDLESS_GLOBAL = 0x20
}
