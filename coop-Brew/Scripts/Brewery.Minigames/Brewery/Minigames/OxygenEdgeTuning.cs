using System;
using UnityEngine;

namespace Brewery.Minigames
{
	[Serializable]
	public struct OxygenEdgeTuning
	{
		[Header("Needle Motion")]
		[Tooltip("Base oscillation speed (cycles per second)")]
		public float baseNeedleSpeed;

		[Tooltip("Speed increase per second (accelerating difficulty)")]
		public float speedIncreaseRate;

		[Tooltip("Extra base speed in overclock mode")]
		public float overclockSpeedBonus;

		[Header("Sweet Spot")]
		[Tooltip("Width of the sweet spot zone (0-1 range)")]
		public float sweetSpotWidth;

		[Tooltip("How often the sweet spot shifts position (seconds)")]
		public float sweetSpotShiftInterval;

		[Tooltip("Width of the perfect center within the sweet spot")]
		public float perfectCenterWidth;

		[Header("Scoring")]
		[Tooltip("Score for tapping in the perfect center")]
		public int centerScore;

		[Tooltip("Score for tapping in the sweet spot (but not center)")]
		public int edgeScore;

		[Tooltip("Penalty for tapping outside the sweet spot")]
		public int missPenalty;

		[Header("Overclock")]
		[Tooltip("Sweet spot width reduction in overclock mode")]
		public float overclockSweetSpotReduction;

		[Header("Combo")]
		public int comboTier1;

		public int comboTier2;

		public int comboTier3;

		[Header("Duration")]
		public float roundDurationSeconds;

		[Header("Tier Thresholds")]
		public int tierBronzeScore;

		public int tierSilverScore;

		public int tierGoldScore;

		[Header("Magnetism")]
		[Tooltip("Radius (0-1) around sweet spot edge where a tap counts as edge hit")]
		public float magnetismRadius;

		[Header("Grace Band")]
		[Tooltip("Score for tapping just outside the sweet spot (within magnetismRadius)")]
		public int graceScore;

		[Header("Adaptive Difficulty")]
		[Tooltip("Number of consecutive misses before adaptive slowdown kicks in")]
		public int adaptiveStreakThreshold;

		[Tooltip("Speed multiplier applied after N consecutive misses (e.g. 0.7 = 30% slower)")]
		public float adaptiveSlowdownFactor;

		[Header("Streak Assist")]
		[Tooltip("Sweet spot width expansion factor during streak assist")]
		public float streakAssistExpansion;

		[Header("Ghost Needle")]
		[Tooltip("How much the ghost needle lags behind the real needle (0-1 blend per second)")]
		public float ghostNeedleLagSpeed;

		[Header("Events")]
		public float eventProbability;

		[Tooltip("Duration of ContaminationAlert (sweet spot shrinks)")]
		public float contaminationDuration;

		[Tooltip("Sweet spot shrink factor during contamination (0-1)")]
		public float contaminationShrink;

		[Tooltip("Duration of FoamKickback (needle speed spike)")]
		public float foamKickbackDuration;

		[Tooltip("Needle speed multiplier during FoamKickback")]
		public float foamKickbackSpeedMult;

		[Tooltip("Duration of PerfectWindow (sweet spot expands)")]
		public float perfectWindowDuration;

		[Tooltip("Sweet spot expansion multiplier during PerfectWindow")]
		public float perfectWindowExpansion;

		[Header("Bonus Rewards")]
		public float tier3BonusSeconds;

		public float tier2BonusSeconds;

		[Header("Rush Meter Contribution")]
		public int rushPerTier;

		public int rushPerComboDiv3;

		[Header("Quality Procs")]
		public float tier3QualityProcChance;

		public float tier3OverclockQualityProcChance;

		public static OxygenEdgeTuning Default => default(OxygenEdgeTuning);
	}
}
