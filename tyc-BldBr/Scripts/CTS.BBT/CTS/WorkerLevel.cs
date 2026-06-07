using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class WorkerLevel : CTSBehaviour
	{
		private static WorkerLevelsData _data;

		[SerializeField]
		[Inject(false)]
		private AgentStatistics _agentStatistics;

		private NumericStatistic _level;

		private NumericStatistic _experience;

		private NumericStatistic _experienceMultiplicator;

		[SerializeField]
		private bool _debug;

		public static WorkerLevelsData Data
		{
			get
			{
				if (!_data)
				{
					_data = Resources.LoadAll<WorkerLevelsData>("Scriptables\\WorkerConfigs")[0];
				}
				return _data;
			}
		}

		public bool Paused { get; set; }

		[field: Inject(false)]
		public Worker Worker { get; private set; }

		public int CurrentLevel
		{
			get
			{
				return _level?.IntValue ?? 0;
			}
			private set
			{
				_level.Value = value;
			}
		}

		public float CurrentXP
		{
			get
			{
				return _experience.Value;
			}
			private set
			{
				_experience.Value = value;
			}
		}

		public float ToNextLevelUnitInterval
		{
			get
			{
				if (!Data.GetLevelRequiredExperience(CurrentLevel, out var requiredExperience))
				{
					return 0f;
				}
				if (!Data.GetLevelRequiredExperience(CurrentLevel + 1, out var requiredExperience2))
				{
					return 1f;
				}
				return Mathf.InverseLerp(requiredExperience, requiredExperience2, CurrentXP);
			}
		}

		public event Action LeveledUp;

		public event Action<float> ExperienceAdded;

		public static event Action<Agent> LevelingUp;

		public static event Action MaxLevelReach;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			LeveledUp += PlayLevelUPVFX;
		}

		protected override void OnDisabled()
		{
			LeveledUp -= PlayLevelUPVFX;
		}

		public void SetStartLevel(int startLevel)
		{
			_agentStatistics.TryGetNumericStatistic(EAgentStatistics.Level, out _level);
			_agentStatistics.TryGetNumericStatistic(EAgentStatistics.Experience, out _experience);
			_agentStatistics.TryGetNumericStatistic(EAgentStatistics.ExperienceMultiplicator, out _experienceMultiplicator);
			LeveledUp -= PlayLevelUPVFX;
			CurrentLevel = 1;
			SetExperience(Data.Levels[startLevel].RequiredExperience);
			LeveledUp += PlayLevelUPVFX;
		}

		private void PlayLevelUPVFX()
		{
			WorkerLevel.LevelingUp?.Invoke(Worker);
			Worker.Animator.Events.TriggerVFX(VFXList.LevelUp);
		}

		public void SetExperience(float experience)
		{
			_experience.Value = experience;
			CheckForLevelUp();
		}

		public void AddExperience(float experienceToAdd)
		{
			if (!Paused)
			{
				if (experienceToAdd < 0f)
				{
					Debug.LogError("[WorkerLevel] XP added can't be under '0'");
					return;
				}
				_experience.AddToValue(experienceToAdd * _experienceMultiplicator.Value);
				this.ExperienceAdded?.Invoke(experienceToAdd);
				CheckForLevelUp();
			}
		}

		public void AddChoreAchievementExperience()
		{
			AddExperience(Data.WorkerExperienceSources[EWorkerExperienceSource.ChoreAchievement]);
		}

		public void AddBloodSuctionExperience(int bloodQuality)
		{
			AddExperience(bloodQuality * Data.WorkerExperienceSources[EWorkerExperienceSource.BloodSuctionMultiplier]);
		}

		private void CheckForLevelUp()
		{
			while (Data.CanLevelUp(CurrentLevel, CurrentXP))
			{
				LevelUp();
				if (!Data.HasLevel(CurrentLevel + 1))
				{
					WorkerLevel.MaxLevelReach?.Invoke();
				}
			}
		}

		private void LevelUp()
		{
			CurrentLevel++;
			Worker.Characteristics.CharacteristicsLevelUp();
			this.LeveledUp?.Invoke();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AddExperienceToLevelUp()
		{
			if (Data.GetLevelRequiredExperience(CurrentLevel + 1, out var requiredExperience))
			{
				AddExperience(requiredExperience - CurrentXP);
			}
		}

		public bool CanUpgradeToNextLevel(int p_currentLevel, int p_currentXP)
		{
			int num = p_currentLevel - 2;
			if (num >= 0 && num < Data.Levels.Count)
			{
				return (float)p_currentXP >= Data.Levels[num].RequiredExperience;
			}
			return false;
		}

		public float GetXPCostForUpgrade(int p_currentLevel)
		{
			int num = p_currentLevel - 1;
			if (num >= 0 && num < Data.Levels.Count)
			{
				return Data.Levels[num].RequiredExperience;
			}
			return 0f;
		}
	}
}
