using System;
using UnityEngine;

namespace Brewery.Minigames
{
	[Serializable]
	public struct FoamFrenzyTuning
	{
		[Header("Meter Rise Rates")]
		[Tooltip("Foam rise per second (base rate)")]
		public float foamRiseRate;

		[Tooltip("Pressure rise per second (base rate)")]
		public float pressureRiseRate;

		[Tooltip("Extra pressure rise per second from foam level")]
		public float foamRiseFromPressure;

		[Header("Player Actions")]
		[Tooltip("Foam reduced per tap (stir)")]
		public float stirReduction;

		[Tooltip("Pressure reduced per second while holding (vent)")]
		public float ventRate;

		[Header("Safe Zones (0-1 range)")]
		[Tooltip("Lower bound of safe zone")]
		public float safeZoneLow;

		[Tooltip("Upper bound of safe zone")]
		public float safeZoneHigh;

		[Tooltip("Lower bound of perfect zone (within safe zone)")]
		public float perfectLow;

		[Tooltip("Upper bound of perfect zone (within safe zone)")]
		public float perfectHigh;

		[Header("Scoring")]
		[Tooltip("Score per tick when both meters in safe zone")]
		public int safeZoneTickScore;

		[Tooltip("Score per tick when both meters in perfect zone")]
		public int perfectZoneTickScore;

		[Tooltip("Penalty when foam or pressure overflows (>0.9)")]
		public int overflowPenalty;

		[Header("Overclock")]
		[Tooltip("Rise rate multiplier when overclock is active")]
		public float overclockRiseMultiplier;

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

		[Header("Events")]
		[Tooltip("Probability (0-1) of a chaos event at each interval")]
		public float eventProbability;

		[Tooltip("Duration of BubbleSurge event (foam rise x2)")]
		public float bubbleSurgeDuration;

		[Tooltip("Instant pressure added by PressurePop event")]
		public float pressurePopAmount;

		[Tooltip("Duration of StickyFoam event (stir effectiveness halved)")]
		public float stickyFoamDuration;

		[Header("Bonus Rewards")]
		public float tier3BonusSeconds;

		public float tier2BonusSeconds;

		[Header("Rush Meter Contribution")]
		public int rushPerTier;

		public int rushPerComboDiv3;

		[Header("Quality Procs")]
		public float tier3QualityProcChance;

		public float tier3OverclockQualityProcChance;

		public static FoamFrenzyTuning Default => default(FoamFrenzyTuning);
	}
}
