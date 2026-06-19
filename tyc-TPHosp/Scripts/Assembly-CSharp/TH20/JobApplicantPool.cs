using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class JobApplicantPool
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public float InitialPercentageToFill = 0.75f;

			[FullInspector.InspectorName("Time Until Next Applicant Min")]
			[SerializeField]
			private float TimeUntilNextApplicant = 10f;

			[SerializeField]
			private float TimeUntilNextApplicantMax = 5f;

			public float TimeUntilRemoveApplicant = 20f;

			public float MarketingBoostMultiplier = 1f;

			public int[] RankWeights = new int[5];

			public int MinJobApplicantSlots = 4;

			public int ChanceOfEmptyTrainingSlot = 50;

			public int GetMaximumSize(PrestigeTracker prestigeTracker)
			{
				return MinJobApplicantSlots + prestigeTracker.Data.ExtraJobApplicantSlots;
			}

			public int GetMaximumSizePossible(PrestigeTracker prestigeTracker)
			{
				return MinJobApplicantSlots + prestigeTracker.MaximumExtraJobApplicantSlots;
			}

			public float GetTimeUntilNextApplicant(ReputationTracker reputationTracker)
			{
				return Mathf.Lerp(TimeUntilNextApplicant, TimeUntilNextApplicantMax, reputationTracker.OverallReputation);
			}
		}

		private Config _config;

		private readonly JobApplicantManager _jobApplicantManager;

		private readonly StaffDefinition _staffDefinition;

		private readonly PrestigeTracker _prestigeTracker;

		private readonly ReputationTracker _reputationTracker;

		private readonly CharacterNameGenerator _nameGenerator;

		private float _nextApplicantTime;

		private float _nextApplicantTimeElapsed;

		private float _removeApplicantTimer;

		private WeightedList<int> _rankWeights;

		public Action<float> OnNextApplicantProgressUpdated;

		public List<MarketingCampaignComponent> MarketingCampaigns { get; private set; }

		public List<JobApplicant> Applicants { get; private set; }

		public JobApplicantPool(Config config, JobApplicantManager jobApplicantManager, StaffDefinition staffDefinition, PrestigeTracker prestigeTracker, ReputationTracker reputationTracker, CharacterNameGenerator nameGenerator)
		{
			_config = config;
			_jobApplicantManager = jobApplicantManager;
			_staffDefinition = staffDefinition;
			_nameGenerator = nameGenerator;
			_prestigeTracker = prestigeTracker;
			_reputationTracker = reputationTracker;
			Applicants = new List<JobApplicant>();
			MarketingCampaigns = new List<MarketingCampaignComponent>();
			InitialiseRankWeight();
		}

		private void InitialiseRankWeight()
		{
			_rankWeights = new WeightedList<int>();
			for (int i = 0; i < _config.RankWeights.Length; i++)
			{
				_rankWeights.Add(i, _config.RankWeights[i]);
			}
		}

		public int MaximumSize()
		{
			return _config.GetMaximumSize(_prestigeTracker);
		}

		public int MaximumSizePossible()
		{
			return _config.GetMaximumSizePossible(_prestigeTracker);
		}

		public float NextApplicantProgress()
		{
			if (!(_nextApplicantTime > 0f))
			{
				return 0f;
			}
			return _nextApplicantTimeElapsed / _nextApplicantTime;
		}

		public float NextApplicantProgressRemainingTime()
		{
			return Mathf.Max(0f, _nextApplicantTime - _nextApplicantTimeElapsed);
		}

		public void AddApplicant(float[] recruitmentFeePercentage, WeightedList<QualificationDefinition> qualifications, CharacterTraitsManager traitsManager, Metagame metagame, Level level)
		{
			int num = _rankWeights.Choose(0, RandomUtils.GlobalRandomInstance);
			JobApplicant jobApplicant = new JobApplicant(_staffDefinition, _nameGenerator, recruitmentFeePercentage[num], _config.ChanceOfEmptyTrainingSlot, num, qualifications, traitsManager, metagame, level);
			Applicants.Add(jobApplicant);
			_jobApplicantManager.OnJobApplicantAdded.InvokeSafe(this, jobApplicant);
		}

		public void RemoveApplicant(JobApplicant applicant)
		{
			Applicants.Remove(applicant);
			_jobApplicantManager.OnJobApplicantRemoved.InvokeSafe(this, applicant);
		}

		public void Update(float deltaTime, float[] recruitmentFeePercentage, WeightedList<QualificationDefinition> qualifications, CharacterTraitsManager traitsManager, Metagame metagame, Level level, bool hireMenuClosed, bool canSpawnMoreStaff)
		{
			if (canSpawnMoreStaff)
			{
				_nextApplicantTimeElapsed += deltaTime;
			}
			_nextApplicantTime = _config.GetTimeUntilNextApplicant(_reputationTracker) / (GetMarketingCampaignMultiplier() + _jobApplicantManager.EnergyStaffApplicantRateModifier);
			if (_nextApplicantTimeElapsed >= _nextApplicantTime)
			{
				int num = MaximumSize();
				if (Applicants.Count < num)
				{
					AddApplicant(recruitmentFeePercentage, BoostedQualifications(qualifications), traitsManager, metagame, level);
				}
				_nextApplicantTimeElapsed -= _nextApplicantTime;
			}
			OnNextApplicantProgressUpdated.InvokeSafe(NextApplicantProgress());
			_removeApplicantTimer += deltaTime;
			if (_removeApplicantTimer >= _config.TimeUntilRemoveApplicant)
			{
				if (Applicants.Count != 0 && hireMenuClosed)
				{
					RemoveApplicant(Applicants[0]);
				}
				_removeApplicantTimer -= _config.TimeUntilRemoveApplicant;
			}
		}

		private float GetMarketingCampaignMultiplier()
		{
			float num = 1f;
			foreach (MarketingCampaignComponent marketingCampaign in MarketingCampaigns)
			{
				num += marketingCampaign.CalculateJobPoolMultiplier();
			}
			return num;
		}

		private WeightedList<QualificationDefinition> BoostedQualifications(WeightedList<QualificationDefinition> qualifications)
		{
			if (MarketingCampaigns.Count == 0)
			{
				return qualifications;
			}
			WeightedList<QualificationDefinition> weightedList = new WeightedList<QualificationDefinition>();
			foreach (KeyValuePair<QualificationDefinition, int> item in qualifications.List)
			{
				weightedList.Add(item.Key, item.Value);
			}
			foreach (MarketingCampaignComponent marketingCampaign in MarketingCampaigns)
			{
				if (marketingCampaign.ActiveCampaign is RecruitmentMarketingCampaignDefinition recruitmentMarketingCampaignDefinition && recruitmentMarketingCampaignDefinition.Qualification != null && recruitmentMarketingCampaignDefinition.Qualification.Instance != null)
				{
					QualificationDefinition instance = recruitmentMarketingCampaignDefinition.Qualification.Instance;
					float num = marketingCampaign.TotalStaffMarketingSkill() * _config.MarketingBoostMultiplier;
					int num2 = weightedList.List[instance];
					weightedList.List[instance] = (int)((float)num2 * num * recruitmentMarketingCampaignDefinition.QualificationWeightMultiplier);
				}
			}
			return weightedList;
		}

		public int GetSlotUnlockLevel(int slot)
		{
			return _prestigeTracker.FindLevelFromJobApplicantSlot(slot - _config.MinJobApplicantSlots);
		}

		public void OnConfigChanged(JobApplicantManager.Config config)
		{
			Config poolConfig = config.GetPoolConfig(_staffDefinition._type);
			if (poolConfig != _config)
			{
				_config = poolConfig;
				InitialiseRankWeight();
			}
		}
	}
}
