using System;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class ScoreSettings : CustomSettings<ScoreSettings>
	{
		[SerializeField]
		private bool m_throwDebugLogs;

		[Header("Score Values")]
		[SerializeField]
		private int m_minScore;

		[SerializeField]
		private int m_baseScore = 100;

		[SerializeField]
		private int m_maximumScore = 2000;

		[Header("Score Consequences")]
		[SerializeField]
		private ScoreConsequence m_spawnScoreOnScoreChanged;

		[Space]
		[SerializeField]
		private ScoreConsequence m_enteringShopPercentageOnScoreChanged;

		[Space]
		[SerializeField]
		private ScoreConsequence m_maxMoneyToSpendOnScoreChanged;

		[Header("Bills Score Malus")]
		[SerializeField]
		private Calculation m_rentBillScoreMalus;

		[SerializeField]
		private Calculation m_elecBillScoreMalus;

		[SerializeField]
		private Calculation m_salariesBillScoreMalus;

		[Header("Score Malus Dirt")]
		[SerializeField]
		private Calculation m_dropBoxScoreMalus;

		[SerializeField]
		private Calculation m_trashScoreMalus;

		[SerializeField]
		private Calculation m_stainScoreMalus;

		[Header("Score Reward Chart")]
		[SerializeField]
		private SimulatorScoreRewardChart m_simulatorScoreRewardChart;

		public static bool ThrowDebugLogs => CustomSettings<ScoreSettings>.I.m_throwDebugLogs;

		public static int MinScore => CustomSettings<ScoreSettings>.I.m_minScore;

		public static int BaseScore => CustomSettings<ScoreSettings>.I.m_baseScore;

		public static int MaxScore => CustomSettings<ScoreSettings>.I.m_maximumScore;

		public static ScoreConsequence SpawnScoreOnScoreChanged => CustomSettings<ScoreSettings>.I.m_spawnScoreOnScoreChanged;

		public static ScoreConsequence EnteringShopPercentageOnScoreChanged => CustomSettings<ScoreSettings>.I.m_enteringShopPercentageOnScoreChanged;

		public static ScoreConsequence MaxMoneyToSpendOnScoreChanged => CustomSettings<ScoreSettings>.I.m_maxMoneyToSpendOnScoreChanged;

		public static Calculation DropBoxScoreMalus => CustomSettings<ScoreSettings>.I.m_dropBoxScoreMalus;

		public static Calculation GetBillMalus(Bill bill)
		{
			if (!(bill is ElecBill))
			{
				if (!(bill is SalariesBill))
				{
					if (bill is RentBill)
					{
						return CustomSettings<ScoreSettings>.I.m_rentBillScoreMalus;
					}
					throw new ArgumentOutOfRangeException("bill", bill, null);
				}
				return CustomSettings<ScoreSettings>.I.m_salariesBillScoreMalus;
			}
			return CustomSettings<ScoreSettings>.I.m_elecBillScoreMalus;
		}

		public static Calculation GetDirtScoreMalus(DirtData.EType dirtType)
		{
			return dirtType switch
			{
				DirtData.EType.TRASH => CustomSettings<ScoreSettings>.I.m_trashScoreMalus, 
				DirtData.EType.STAIN => CustomSettings<ScoreSettings>.I.m_stainScoreMalus, 
				_ => throw new ArgumentOutOfRangeException("dirtType", dirtType, null), 
			};
		}

		public static Calculation GetScoreRewardCalculation(ESimulatorXPRewardEvent simulatorXpRewardEvent)
		{
			return CustomSettings<ScoreSettings>.I.m_simulatorScoreRewardChart[simulatorXpRewardEvent];
		}
	}
}
