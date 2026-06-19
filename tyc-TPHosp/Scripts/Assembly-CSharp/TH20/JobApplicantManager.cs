#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	public class JobApplicantManager : MustCallDestroy, IGameEventsBase
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public JobApplicantPool.Config DoctorConfig;

			public JobApplicantPool.Config NurseConfig;

			public JobApplicantPool.Config JanitorConfig;

			public JobApplicantPool.Config AssistantConfig;

			public SharedInstance<StaffDatabase> StaffDatabase;

			public SharedInstance<QualificationDefinitionList> Qualifications;

			public float[] RecruitmentFeePercentage = new float[5] { 10f, 10f, 10f, 10f, 10f };

			public JobApplicantPool.Config GetPoolConfig(StaffDefinition.Type type)
			{
				return type switch
				{
					StaffDefinition.Type.Doctor => DoctorConfig, 
					StaffDefinition.Type.Nurse => NurseConfig, 
					StaffDefinition.Type.Assistant => AssistantConfig, 
					StaffDefinition.Type.Janitor => JanitorConfig, 
					_ => throw new ArgumentOutOfRangeException("type", type, null), 
				};
			}
		}

		public Action<JobApplicantPool, JobApplicant> OnJobApplicantAdded;

		public Action<JobApplicantPool, JobApplicant> OnJobApplicantRemoved;

		private Config _config;

		private readonly Level _level;

		private readonly PrestigeTracker _prestigeTracker;

		private readonly ReputationTracker _reputationTracker;

		private readonly CharacterNameGenerator _nameGenerator;

		private Dictionary<StaffDefinition.Type, JobApplicantPool> _jobApplicantPools;

		private WeightedList<QualificationDefinition> _qualifications;

		private readonly CharacterTraitsManager _characterTraitsManager;

		private float _energyStaffApplicantRateModifier;

		public float EnergyStaffApplicantRateModifier
		{
			get
			{
				return _energyStaffApplicantRateModifier;
			}
			set
			{
				_energyStaffApplicantRateModifier = value;
			}
		}

		public WeightedList<QualificationDefinition> Qualifications => _qualifications;

		public JobApplicantManager(Config config, Level level, PrestigeTracker prestigeTracker, ReputationTracker reputationTracker, CharacterNameGenerator nameGenerator, CharacterTraitsManager characterTraitsManager)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_config = config;
			_level = level;
			_prestigeTracker = prestigeTracker;
			_reputationTracker = reputationTracker;
			_nameGenerator = nameGenerator;
			_characterTraitsManager = characterTraitsManager;
			RegisterEvents();
			InitialiseQualifications();
			InitialisePools();
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnAddQualification = (Action<QualificationDefinition, int>)Delegate.Combine(characterEvents.OnAddQualification, new Action<QualificationDefinition, int>(AddQualification));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnRemoveQualification = (Action<QualificationDefinition>)Delegate.Combine(characterEvents2.OnRemoveQualification, new Action<QualificationDefinition>(RemoveQualification));
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			MarketingManager marketingManager2 = _level.MarketingManager;
			marketingManager2.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Combine(marketingManager2.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnAddQualification = (Action<QualificationDefinition, int>)Delegate.Remove(characterEvents.OnAddQualification, new Action<QualificationDefinition, int>(AddQualification));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnRemoveQualification = (Action<QualificationDefinition>)Delegate.Remove(characterEvents2.OnRemoveQualification, new Action<QualificationDefinition>(RemoveQualification));
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			MarketingManager marketingManager2 = _level.MarketingManager;
			marketingManager2.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Remove(marketingManager2.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			base.Destroy();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
			foreach (KeyValuePair<QualificationDefinition, int> item in _qualifications.List)
			{
				_level.Debug_RegisterAssignQualification(item.Key);
			}
		}

		public void VerifyEvents()
		{
			OnJobApplicantAdded.VerifyIsNull();
			OnJobApplicantRemoved.VerifyIsNull();
		}

		public string Debug_GetAllQualifications()
		{
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder();
			KeyValuePair<QualificationDefinition, int>[] array = _qualifications.List.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<QualificationDefinition, int> keyValuePair = array[i];
				builder.AppendFormat("{0} '{1}'\n", i, keyValuePair.Key.NameLocalised);
			}
			string result = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return result;
		}

		private void InitialisePools()
		{
			_jobApplicantPools = new Dictionary<StaffDefinition.Type, JobApplicantPool>();
			StaffDefinition.Type[] allTypes = StaffDefinition.AllTypes;
			foreach (StaffDefinition.Type type in allTypes)
			{
				JobApplicantPool.Config poolConfig = _config.GetPoolConfig(type);
				JobApplicantPool jobApplicantPool = new JobApplicantPool(poolConfig, this, _config.StaffDatabase.Instance.GetDefinition(type), _prestigeTracker, _reputationTracker, _nameGenerator);
				int num = (int)((float)poolConfig.GetMaximumSize(_prestigeTracker) * poolConfig.InitialPercentageToFill);
				_jobApplicantPools.Add(type, jobApplicantPool);
				for (int j = 0; j < num; j++)
				{
					jobApplicantPool.AddApplicant(_config.RecruitmentFeePercentage, _qualifications, _characterTraitsManager, _level.Metagame, _level);
				}
			}
		}

		private void InitialiseQualifications()
		{
			_qualifications = new WeightedList<QualificationDefinition>();
			if (_config.Qualifications != null && _config.Qualifications.Instance != null)
			{
				QualificationDefinitionList.Entry[] entries = _config.Qualifications.Instance._entries;
				foreach (QualificationDefinitionList.Entry entry in entries)
				{
					AddQualification(entry.Definition.Instance, entry.Weight);
				}
			}
		}

		public void Update(float deltaTime, bool hireMenuClosed)
		{
			bool canSpawnMoreStaff = _level.CharacterManager.CanSpawnMoreStaff;
			foreach (KeyValuePair<StaffDefinition.Type, JobApplicantPool> jobApplicantPool in _jobApplicantPools)
			{
				jobApplicantPool.Value.Update(deltaTime, _config.RecruitmentFeePercentage, _qualifications, _characterTraitsManager, _level.Metagame, _level, hireMenuClosed, canSpawnMoreStaff);
			}
		}

		public JobApplicantPool GetJobApplicantPool(StaffDefinition.Type staffType)
		{
			return _jobApplicantPools[staffType];
		}

		private void AddQualification(QualificationDefinition definition, int weight)
		{
			if (_qualifications.Contains(definition))
			{
				Logging.Error(LogChannels.JobApplicant, "Qualification {0} is already added", definition.NameLocalised);
			}
			else
			{
				_qualifications.Add(definition, weight);
				_level.Debug_RegisterAssignQualification(definition);
			}
		}

		private void RemoveQualification(QualificationDefinition definition)
		{
			if (!_qualifications.Remove(definition))
			{
				Logging.Error(LogChannels.JobApplicant, "Trying to remove qualification {0} that isn't in the list", definition.NameLocalised);
			}
		}

		private void OnCampaignStarted(MarketingCampaignComponent component)
		{
			if (component.ActiveCampaign is RecruitmentMarketingCampaignDefinition recruitmentMarketingCampaignDefinition)
			{
				GetJobApplicantPool(recruitmentMarketingCampaignDefinition.GetStaffType()).MarketingCampaigns.Add(component);
			}
		}

		private void OnCampaignEnded(MarketingCampaignComponent component, bool cancelled)
		{
			if (component.ActiveCampaign is RecruitmentMarketingCampaignDefinition recruitmentMarketingCampaignDefinition)
			{
				GetJobApplicantPool(recruitmentMarketingCampaignDefinition.GetStaffType()).MarketingCampaigns.Remove(component);
			}
		}

		public void OnConfigChanged(Config config)
		{
			if (config == null || config == _config)
			{
				return;
			}
			_config = config;
			InitialiseQualifications();
			foreach (JobApplicantPool value in _jobApplicantPools.Values)
			{
				value.OnConfigChanged(_config);
			}
		}
	}
}
