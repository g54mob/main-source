using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class YearlyTargetsManager : MustCallDestroy
	{
		public enum TargetType
		{
			CurePatients = 1,
			TrainStaff = 2
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public List<TargetDefinition> Targets = new List<TargetDefinition>();
		}

		public class TargetDefinition
		{
			public TargetType TargetType;

			public int MaxTargetValue;

			public int MaxMoneyAward;

			public int MaxSilverAward;

			public int MaxReputationAward;
		}

		public class Target
		{
			public TargetType TargetType;

			public int TargetValue;

			public int MoneyAward;

			public int SilverAward;

			public int ReputationAward;
		}

		private readonly Config _config;

		private readonly LevelStatsDatabase _levelStatsDatabase;

		private readonly FinanceManager _financeManager;

		private readonly ReputationTracker _reputationTracker;

		[DontSave]
		private Metagame _metagame;

		public Dictionary<TargetType, Target> ActiveTargets = new Dictionary<TargetType, Target>();

		public List<TargetDefinition> TargetDefinitions => _config.Targets;

		public YearlyTargetsManager(Config config, LevelStatsDatabase levelStatsDatabase, FinanceManager financeManager, ReputationTracker reputationTracker, Metagame metagame)
		{
			_config = config;
			_levelStatsDatabase = levelStatsDatabase;
			_financeManager = financeManager;
			_reputationTracker = reputationTracker;
			_metagame = metagame;
			LevelStatsDatabase levelStatsDatabase2 = _levelStatsDatabase;
			levelStatsDatabase2.OnYearCompleted = (Action<LevelStatsDatabase.YearStats>)Delegate.Combine(levelStatsDatabase2.OnYearCompleted, new Action<LevelStatsDatabase.YearStats>(OnYearCompleted));
		}

		public void RestoreFromSave(Metagame metagame)
		{
			_metagame = metagame;
		}

		private void OnYearCompleted(LevelStatsDatabase.YearStats yearStats)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (Target value in ActiveTargets.Values)
			{
				if (value.TargetValue == 0)
				{
					continue;
				}
				switch (value.TargetType)
				{
				case TargetType.CurePatients:
					if (yearStats.NumberOfTreatmentCures >= value.TargetValue)
					{
						num += value.MoneyAward;
						num2 += value.SilverAward;
						num3 += value.ReputationAward;
					}
					break;
				case TargetType.TrainStaff:
					if (yearStats.NumberOfStaffTrained >= value.TargetValue)
					{
						num += value.MoneyAward;
						num2 += value.SilverAward;
						num3 += value.ReputationAward;
					}
					break;
				}
			}
			if (num > 0)
			{
				_financeManager.OnMoneyAwarded.InvokeSafe(num);
			}
			if (num2 > 0)
			{
				_metagame.AwardSilver(num2);
			}
			if (num3 > 0)
			{
				_reputationTracker.AwardReputation(num3);
			}
		}

		public string GetReadableNameOfTarget(TargetType targetType, int targetValue)
		{
			return targetType switch
			{
				TargetType.CurePatients => $"Cure {targetValue} Patients", 
				TargetType.TrainStaff => $"Train {targetValue} Staff Members", 
				_ => string.Empty, 
			};
		}

		public void SetActiveTarget(TargetDefinition targetDefintion, int targetValue)
		{
			if (!ActiveTargets.TryGetValue(targetDefintion.TargetType, out var value))
			{
				value = new Target();
				ActiveTargets[targetDefintion.TargetType] = value;
			}
			value.TargetType = targetDefintion.TargetType;
			value.TargetValue = targetValue;
			float num = (float)targetValue / (float)targetDefintion.MaxTargetValue;
			value.MoneyAward = Mathf.RoundToInt(num * (float)targetDefintion.MaxMoneyAward);
			value.SilverAward = Mathf.RoundToInt(num * (float)targetDefintion.MaxSilverAward);
			value.ReputationAward = Mathf.RoundToInt(num * (float)targetDefintion.MaxReputationAward);
		}

		public override void Destroy()
		{
			LevelStatsDatabase levelStatsDatabase = _levelStatsDatabase;
			levelStatsDatabase.OnYearCompleted = (Action<LevelStatsDatabase.YearStats>)Delegate.Remove(levelStatsDatabase.OnYearCompleted, new Action<LevelStatsDatabase.YearStats>(OnYearCompleted));
			base.Destroy();
		}
	}
}
