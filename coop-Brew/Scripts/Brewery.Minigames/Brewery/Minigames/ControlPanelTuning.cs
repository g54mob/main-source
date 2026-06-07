using System;
using UnityEngine;

namespace Brewery.Minigames
{
	[Serializable]
	public struct ControlPanelTuning
	{
		[Header("Duration")]
		[Tooltip("Round duration in seconds")]
		public float roundDurationSeconds;

		[Tooltip("Duration multiplier when overclock is active (< 1.0 = shorter round)")]
		public float overclockDurationMultiplier;

		[Header("Drift")]
		[Tooltip("Global multiplier on all meter drift rates")]
		public float baseDriftMultiplier;

		[Tooltip("Extra drift multiplier added when overclock is active")]
		public float overclockDriftBonus;

		[Header("Scoring")]
		[Tooltip("Score interval — how often (seconds) a scoring tick occurs")]
		public float scoreTickInterval;

		[Tooltip("Maximum score per scoring tick (before combo multiplier)")]
		public int maxTickScore;

		[Tooltip("Bonus score for sustaining all meters in perfect band for 2 seconds")]
		public int sustainedPerfectBonus;

		[Tooltip("Duration (seconds) of sustained perfect band needed for bonus")]
		public float sustainedPerfectDuration;

		[Tooltip("Bonus score for successfully weathering a chaos event")]
		public int eventSolveBonus;

		[Header("Combo")]
		[Tooltip("Combo thresholds: x2 at tier1, x3 at tier2, x4 at tier3")]
		public int comboTier1;

		public int comboTier2;

		public int comboTier3;

		[Tooltip("Number of consecutive good scoring ticks needed to increment combo")]
		public int goodTicksPerCombo;

		[Header("Events")]
		[Tooltip("Probability (0-1) of scheduling a chaos event per event slot")]
		public float eventProbability;

		[Tooltip("Minimum seconds before the first chaos event can occur")]
		public float firstEventDelay;

		[Tooltip("Minimum seconds between chaos events")]
		public float eventSpacing;

		[Header("Tier Thresholds")]
		public int tierBronzeScore;

		public int tierSilverScore;

		public int tierGoldScore;

		[Header("Bonus Rewards")]
		public float tier3BonusSeconds;

		public float tier2BonusSeconds;

		[Header("Rush Meter Contribution")]
		public int rushPerTier;

		public int rushPerComboDiv3;

		[Header("Quality Procs")]
		public float tier3QualityProcChance;

		public float tier3OverclockQualityProcChance;

		public static ControlPanelTuning Default => default(ControlPanelTuning);
	}
}
