using System;
using UnityEngine;

namespace Brewery.Minigames
{
	[Serializable]
	public struct CoolingCircuitTuning
	{
		[Header("Grid Layout")]
		public int gridRows;

		public int gridCols;

		[Tooltip("Number of hot (target) nodes to place")]
		public int hotNodeCount;

		[Tooltip("Number of coolant (source) nodes to place")]
		public int coolantNodeCount;

		[Header("Path Puzzle")]
		[Tooltip("Require 4-connected adjacency for path cells (no diagonals)")]
		public bool requireAdjacency;

		[Tooltip("Maximum cells allowed in a single path")]
		public int maxPathLength;

		[Tooltip("Score awarded per cell in a completed path")]
		public int pathScorePerCell;

		[Tooltip("Bonus score for completing a valid Hot<->Coolant path")]
		public int completionBonusPerPath;

		[Header("Scoring")]
		[Tooltip("Score for each valid hot-to-coolant connection")]
		public int connectionScore;

		[Tooltip("Bonus for connecting all hot nodes")]
		public int allConnectedBonus;

		[Tooltip("Score bonus per second remaining")]
		public int timeBonusPerSecond;

		[Tooltip("Penalty for attempting an invalid connection")]
		public int invalidConnectionPenalty;

		[Header("Overclock")]
		[Tooltip("Extra hot nodes added in overclock mode")]
		public int overclockExtraHotNodes;

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
		public float eventProbability;

		[Tooltip("Number of connections broken by ShortCircuit event")]
		public int shortCircuitCount;

		[Tooltip("Duration a coolant node is disabled by FrozenValve")]
		public float frozenValveDuration;

		[Tooltip("Time limit to connect an urgent overheat node")]
		public float overheatTimer;

		[Tooltip("Penalty if overheat node isn't connected in time")]
		public int overheatPenalty;

		[Header("Bonus Rewards")]
		public float tier3BonusSeconds;

		public float tier2BonusSeconds;

		[Header("Rush Meter Contribution")]
		public int rushPerTier;

		public int rushPerComboDiv3;

		[Header("Quality Procs")]
		public float tier3QualityProcChance;

		public float tier3OverclockQualityProcChance;

		public static CoolingCircuitTuning Default => default(CoolingCircuitTuning);
	}
}
