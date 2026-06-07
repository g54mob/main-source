using System;
using UnityEngine;

namespace Brewery.Minigames
{
	[Serializable]
	public struct BoilBeatsTuning
	{
		[Header("Tempo")]
		[Tooltip("Minimum BPM for generated beat tracks")]
		public int bpmMin;

		[Tooltip("Maximum BPM for generated beat tracks")]
		public int bpmMax;

		[Tooltip("BPM increase when overclock is active")]
		public int overclockBpmBonus;

		[Header("Timing Windows (milliseconds)")]
		[Tooltip("Perfect hit window in ms (e.g., 40 means +/-40ms)")]
		public int perfectWindowMs;

		[Tooltip("Good hit window in ms")]
		public int goodWindowMs;

		[Tooltip("Perfect window reduction in overclock mode (ms)")]
		public int overclockPerfectReduction;

		[Header("Kernel Keys — Multi-Lane")]
		[Tooltip("Number of input lanes (6 = Q/W/E/A/S/D)")]
		public int laneCount;

		[Tooltip("Perfect window in ms for Kernel Keys mode")]
		public int perfectWindowMsKK;

		[Tooltip("Good window in ms for Kernel Keys mode")]
		public int goodWindowMsKK;

		[Tooltip("Probability (0-1) of syncopated (off-beat) notes")]
		public float syncopationProbability;

		[Tooltip("Input buffer duration in ms — early inputs queue and resolve against upcoming beats")]
		public int inputBufferMs;

		[Header("Kernel Keys — Event Scores")]
		[Tooltip("Score for successfully completing a Chord event")]
		public int chordScore;

		[Tooltip("Score for successfully completing a Roll event")]
		public int rollScore;

		[Tooltip("Score for successfully completing a Hold event")]
		public int holdScore;

		[Tooltip("Duration window for Roll events in seconds")]
		public float rollWindowSeconds;

		[Tooltip("Required hold duration for Hold events in seconds")]
		public float holdDurationSeconds;

		[Header("Kernel Keys — Anti-Fatigue")]
		[Tooltip("Per-lane phase offset range in seconds (randomized per lane)")]
		public float lanePhaseOffsetRange;

		[Header("Scoring")]
		public int perfectScore;

		public int goodScore;

		public int missScore;

		public int eventSuccessScore;

		[Header("Combo")]
		[Tooltip("Combo thresholds for multiplier tiers: x1 at 0, x2 at tier1, x3 at tier2, x4 at tier3")]
		public int comboTier1;

		public int comboTier2;

		public int comboTier3;

		[Header("Events")]
		[Tooltip("Probability (0-1) of a chaos event on any given beat")]
		public float eventProbability;

		[Tooltip("Bubble burst bonus tap window in seconds")]
		public float bubbleBurstWindowSeconds;

		[Header("Beat Generation")]
		[Tooltip("Delay before the first beat starts (seconds)")]
		public float firstBeatDelay;

		[Tooltip("How far ahead of activation chaos events telegraph (seconds)")]
		public float eventTelegraphSeconds;

		[Tooltip("Probability (0-1) that a beat slot is a rest instead of a note")]
		public float beatRestProbability;

		[Header("Duration")]
		[Tooltip("Minigame round duration in seconds")]
		public float roundDurationSeconds;

		[Header("Tier Thresholds")]
		public int tierBronzeScore;

		public int tierSilverScore;

		public int tierGoldScore;

		[Header("Bonus Rewards")]
		[Tooltip("Extra seconds for tier 3 (Gold) perfect streak")]
		public float tier3BonusSeconds;

		[Tooltip("Extra seconds for tier 2 (Silver)")]
		public float tier2BonusSeconds;

		[Header("Rush Meter Contribution")]
		[Tooltip("Rush points per tier level")]
		public int rushPerTier;

		[Tooltip("Rush points per 3 max combo")]
		public int rushPerComboDiv3;

		[Header("Quality Procs")]
		[Tooltip("Chance of quality proc at Gold tier (0-1)")]
		public float tier3QualityProcChance;

		[Tooltip("Chance of quality proc at Gold tier with overclock (0-1)")]
		public float tier3OverclockQualityProcChance;

		public static BoilBeatsTuning Default => default(BoilBeatsTuning);
	}
}
