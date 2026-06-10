using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Dictionary;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tools.Math;
using NSMedieval.Tutorial;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("StatsInstance", "")]
	public class StatsInstance : ISerializationCallbackReceiver, IGameDisposable, IDisposable, IFVSerializable
	{
		[SerializeField]
		private SerializableAttributeDictionary attributes;

		[SerializeField]
		private SerializableStatDictionary stats;

		[SerializeField]
		private readonly List<ActiveEffectorInfo> activeEffectors = new List<ActiveEffectorInfo>();

		[SerializeField]
		private bool isInitialized;

		[SerializeField]
		private string repositoryName;

		[SerializeField]
		private string statsModelId;

		[SerializeField]
		private SerializableHashSet<string> bannedEffectors = new SerializableHashSet<string>();

		[SerializeField]
		private SerializableHashSet<string> allowedEffectors = new SerializableHashSet<string>();

		private List<ModifierInstanceStack> attributeModifiers;

		private IStatsOwner owner;

		private AnimalInstance ownerAnimalInstance;

		private HumanoidInstance ownerHumanoidInstance;

		private StatsEventController controller;

		private bool savedEffectorsFired;

		private List<StatEffector> delayedEffectorStartEvent;

		private List<StatEffector> delayedEffectorStackEvent;

		private Dictionary<string, float> goalPriorityModifiers;

		private Dictionary<string, float> goalFixedPriorities;

		private StatsModel statsModelCache;

		private CreatureBase affectionTarget;

		private WorldDate dateCache;

		[FormerlySerializedAs("isStatsInitialized")]
		public bool isStatsRegistered;

		public bool NeedTickEffectors { get; private set; }

		public bool HasDisposed { get; protected set; }

		public SerializableAttributeDictionary AttributesSerDict => attributes;

		public Dictionary<AttributeType, AttributeInstance> Attributes => attributes.Dictionary;

		public IStatsOwner Owner => owner;

		public string RepositoryName => repositoryName;

		public bool SavedEffectorsFired => savedEffectorsFired;

		public StatsEventController Controller
		{
			get
			{
				if (controller == null)
				{
					controller = new StatsEventController();
				}
				return controller;
			}
		}

		public HumanoidInstance OwnerHumanoidInstance => ownerHumanoidInstance;

		public AnimalInstance OwnerAnimalInstance => ownerAnimalInstance;

		public bool IsGeneratedFromRepository => repositoryName != null;

		public IEnumerable<KeyValuePair<StatType, StatInstance>> Stats => stats.Dictionary;

		public StatsModel StatsModel
		{
			get
			{
				if (statsModelCache == null && !string.IsNullOrEmpty(statsModelId))
				{
					statsModelCache = Repository<StatsModelRepository, StatsModel>.Instance.GetByID(statsModelId);
				}
				return statsModelCache;
			}
		}

		public CreatureBase AffectionTarget => affectionTarget;

		public event Action<StatEffector> OnEffectorStartEvent;

		public event Action<StatEffector> OnInstantEffectorStartEvent;

		public event Action<StatEffector> OnEffectorStackEvent;

		public event Action<StatEffector> OnEffectorEndEvent;

		public event Action OnStatsUpdatedEvent;

		public event Action<IGameDisposable> OnDisposedEvent;

		public StatsInstance(IStatsOwner owner)
		{
			SetOwner(owner);
			repositoryName = null;
			dateCache = GlobalSaveController.CurrentVillageData.DateAndTime;
		}

		public StatsInstance(IStatsOwner owner, string repoName)
		{
			SetOwner(owner);
			repositoryName = repoName;
			dateCache = GlobalSaveController.CurrentVillageData.DateAndTime;
		}

		public StatsInstance(IStatsOwner owner, StatsModel statsModel)
		{
			SetOwner(owner);
			repositoryName = null;
			statsModelId = statsModel.GetID();
			statsModelCache = statsModel;
			dateCache = GlobalSaveController.CurrentVillageData.DateAndTime;
		}

		public void GenerateInstancesFromRepository()
		{
			if (!IsGeneratedFromRepository)
			{
				return;
			}
			attributeModifiers = new List<ModifierInstanceStack>();
			attributes = SerializableDictionary<AttributeType, AttributeInstance>.CreateNew<SerializableAttributeDictionary>();
			stats = SerializableDictionary<StatType, StatInstance>.CreateNew<SerializableStatDictionary>();
			foreach (Attribute allItem in Repository<AttributeRepository, Attribute>.Instance.GetAllItems())
			{
				attributes.Dictionary.Add(allItem.Type, new AttributeInstance(allItem.Type, this));
			}
			foreach (Stat item in Repository<StatRepository, Stat>.Instance.GetAll(repositoryName))
			{
				stats.Dictionary.Add(item.Type, new StatInstance(item.Type, this));
			}
		}

		public void GenerateFromStatsModel()
		{
			if (StatsModel == null)
			{
				return;
			}
			attributeModifiers = new List<ModifierInstanceStack>();
			attributes = SerializableDictionary<AttributeType, AttributeInstance>.CreateNew<SerializableAttributeDictionary>();
			stats = SerializableDictionary<StatType, StatInstance>.CreateNew<SerializableStatDictionary>();
			foreach (Attribute allItem in Repository<AttributeRepository, Attribute>.Instance.GetAllItems())
			{
				attributes.Dictionary.Add(allItem.Type, new AttributeInstance(allItem.Type, this));
			}
			foreach (Stat stat in StatsModel.Stats)
			{
				stats.Dictionary.Add(stat.Type, new StatInstance(stat, this));
			}
		}

		public void AddMissingStats()
		{
			foreach (Stat stat in StatsModel.Stats)
			{
				if (stat != null && !stats.Dictionary.ContainsKey(stat.Type))
				{
					StatInstance value = new StatInstance(stat, this);
					stats.Dictionary.Add(stat.Type, value);
				}
			}
		}

		public void AddStatInstance(StatInstance statInstance)
		{
			if (!stats.Dictionary.ContainsKey(statInstance.Type))
			{
				stats.Dictionary.Add(statInstance.Type, statInstance);
			}
		}

		public void CopyValues(StatsInstance from)
		{
			if (from?.stats?.Dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<StatType, StatInstance> item in from.stats.Dictionary)
			{
				stats.Dictionary[item.Key]?.SetCurrent(item.Value.Current);
			}
		}

		public void AddMissingAttributes(IEnumerable<Attribute> attributesEnum)
		{
			int num = 0;
			foreach (Attribute item in attributesEnum)
			{
				if (item.Type != AttributeType.None && !Attributes.ContainsKey(item.Type))
				{
					num++;
					Attributes.Add(item.Type, new AttributeInstance(item.Type, this));
				}
			}
			if (num > 0)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(" attributes ware missing in saved stats, but ware added.");
				}
				Log.Info(messageBuilder);
			}
		}

		public void Initialize(bool forceReInit = false)
		{
			if (owner == null)
			{
				Log.Error("No owner set!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
			}
			bool flag = Owner is CreatureBase;
			if (Owner != null && !flag)
			{
				int num = activeEffectors.RemoveAll((ActiveEffectorInfo item) => item.WoundInfo != null);
				if (num > 0)
				{
					Log.Warning("Found and resolved possible save corruption. Non-creature agent had wound effectors in it. This is not allowed. Effectors removed: " + num + " | " + Owner, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				}
			}
			if (attributeModifiers == null && !isInitialized)
			{
				attributeModifiers = new List<ModifierInstanceStack>();
			}
			List<StatType> list = null;
			foreach (KeyValuePair<StatType, StatInstance> item in stats.Dictionary)
			{
				item.Value.Initialize(this, !isInitialized || forceReInit);
				if (item.Value == null || item.Value.Blueprint == null)
				{
					list = ((list == null) ? new List<StatType>() : list);
					list.Add(item.Key);
				}
			}
			if (list != null && list.Count > 0)
			{
				foreach (StatType item2 in list)
				{
					stats.Dictionary.Remove(item2);
				}
			}
			if (isInitialized)
			{
				SetAttributesOwner();
			}
			else
			{
				savedEffectorsFired = true;
			}
			NeedTickEffectors = !(owner is ResourcePileInstance);
			if (!isStatsRegistered)
			{
				isStatsRegistered = true;
				MonoSingleton<StatsUpdateManager>.Instance.RegisterStat(this);
			}
			Update();
			if (isInitialized)
			{
				FireSavedEffectors();
			}
			isInitialized = true;
		}

		public AttributeInstance GetAttributeInstance(AttributeType type)
		{
			if (attributes == null || attributes.Dictionary == null)
			{
				return null;
			}
			attributes.Dictionary.TryGetValue(type, out var value);
			return value;
		}

		public void SetOwner(IStatsOwner owner)
		{
			this.owner = owner;
			ownerAnimalInstance = this.owner as AnimalInstance;
			ownerHumanoidInstance = this.owner as HumanoidInstance;
			if (dateCache == null)
			{
				dateCache = GlobalSaveController.CurrentVillageData.DateAndTime;
			}
		}

		public void SetOwnerOnStats()
		{
			foreach (KeyValuePair<StatType, StatInstance> item in stats.Dictionary)
			{
				item.Value.SetOwner(this);
			}
			SetAttributesOwner();
		}

		public void SetAttributesOwner()
		{
			List<KeyValuePair<AttributeType, AttributeInstance>> list = new List<KeyValuePair<AttributeType, AttributeInstance>>();
			foreach (KeyValuePair<AttributeType, AttributeInstance> item in attributes.Dictionary)
			{
				if (Enum.IsDefined(typeof(AttributeType), item.Key))
				{
					item.Value.SetOwner(this);
				}
				else
				{
					list.Add(item);
				}
			}
			foreach (KeyValuePair<AttributeType, AttributeInstance> item2 in list)
			{
				attributes.Dictionary.Remove(item2.Key);
			}
		}

		public void SetDateCache(WorldDate date)
		{
			dateCache = date;
		}

		public void BanEffector(string name)
		{
			if (bannedEffectors == null)
			{
				bannedEffectors = new SerializableHashSet<string>();
			}
			if (!bannedEffectors.Set.Contains(name))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ban effector ");
					messageBuilder.AppendFormatted(name);
					messageBuilder.AppendLiteral(" added.");
				}
				Log.Trace(messageBuilder);
				bannedEffectors.Set.Add(name);
			}
		}

		public void UnBanEffector(string name)
		{
			if (bannedEffectors != null && bannedEffectors.Set.Contains(name))
			{
				bannedEffectors.Set.Remove(name);
			}
		}

		public void AllowEffector(string name)
		{
			if (allowedEffectors == null)
			{
				allowedEffectors = new SerializableHashSet<string>();
			}
			if (!allowedEffectors.Set.Contains(name))
			{
				allowedEffectors.Set.Add(name);
			}
		}

		public void UnAllowEffector(string name)
		{
			if (allowedEffectors != null && allowedEffectors.Set.Contains(name))
			{
				allowedEffectors.Set.Remove(name);
			}
		}

		public void ResetActiveEffectorsStartTime(long startTime)
		{
			for (int i = 0; i < activeEffectors.Count; i++)
			{
				ActiveEffectorInfo value = new ActiveEffectorInfo(activeEffectors[i], startTime);
				activeEffectors[i] = value;
			}
		}

		public ModifierInstanceStack GetModifierInstanceStack(ModifierType type)
		{
			return attributeModifiers.Find((ModifierInstanceStack entiry) => entiry.Type == type);
		}

		public ReadOnlyCollection<ModifierInstanceStack> GetModifierInstanceStack()
		{
			return attributeModifiers.AsReadOnly();
		}

		public bool HasAttributeModifier(ModifierType type)
		{
			ModifierInstanceStack modifierInstanceStack = attributeModifiers.Find((ModifierInstanceStack entiry) => entiry.Type == type);
			if (modifierInstanceStack != null)
			{
				return modifierInstanceStack.Instances.Count > 0;
			}
			return false;
		}

		public StatInstance GetStat(StatType type)
		{
			return stats?.Dictionary.GetValueOrDefault(type);
		}

		public bool StartAffectionEffector(string effectorId, CreatureBase target)
		{
			affectionTarget = target;
			if (StartEffector(effectorId))
			{
				affectionTarget = null;
				return true;
			}
			affectionTarget = null;
			return false;
		}

		public float GetGoalPriorityModifierValue(string goalName)
		{
			if (goalPriorityModifiers == null)
			{
				goalPriorityModifiers = new Dictionary<string, float>();
			}
			if (!goalPriorityModifiers.TryGetValue(goalName, out var value))
			{
				return 0f;
			}
			return value;
		}

		internal void AddGoalPriorityModifier(string goalName, float value)
		{
			if (!HasDisposed)
			{
				if (goalPriorityModifiers == null)
				{
					goalPriorityModifiers = new Dictionary<string, float>();
				}
				if (!goalPriorityModifiers.TryGetValue(goalName, out var value2))
				{
					goalPriorityModifiers.Add(goalName, value);
				}
				else
				{
					goalPriorityModifiers[goalName] = value2 + value;
				}
				if (owner is IGoapAgentOwner goapAgentOwner)
				{
					goapAgentOwner.GetGoapAgent()?.GoalScheduler?.UpdatePrioritiesDelayed();
				}
			}
		}

		internal void ModifyGoalPreference(string goalPreferenceId, int value)
		{
			if (ownerHumanoidInstance != null)
			{
				ownerHumanoidInstance.GoalPreferences.ModifyGoalPreference(new StringIntPair(goalPreferenceId, value));
			}
		}

		public void ClearForceGoalEnableStateModifier(string id)
		{
			if (owner is IGoapAgentOwner goapAgentOwner)
			{
				goapAgentOwner.GetGoapAgent()?.GoalScheduler?.RemoveForceEnableState(id);
			}
		}

		public void AddForceGoalEnableStateModifier(string id, bool state)
		{
			if (owner is IGoapAgentOwner goapAgentOwner)
			{
				goapAgentOwner.GetGoapAgent()?.GoalScheduler?.AddForceEnableState(id, state);
			}
		}

		public float GetGoalFixedPriority(string goalName)
		{
			if (goalFixedPriorities == null)
			{
				goalFixedPriorities = new Dictionary<string, float>();
			}
			if (!goalFixedPriorities.TryGetValue(goalName, out var value))
			{
				return 0f;
			}
			return value;
		}

		internal void AddGoalFixedPriority(string goalName, float value)
		{
			if (!HasDisposed)
			{
				if (goalFixedPriorities == null)
				{
					goalFixedPriorities = new Dictionary<string, float>();
				}
				if (!goalFixedPriorities.TryGetValue(goalName, out var _))
				{
					goalFixedPriorities.Add(goalName, value);
				}
				else
				{
					goalFixedPriorities[goalName] = value;
				}
				if (owner is IGoapAgentOwner goapAgentOwner)
				{
					goapAgentOwner.GetGoapAgent()?.GoalScheduler?.UpdatePrioritiesDelayed();
				}
			}
		}

		internal void RemoveGoalFixedPriority(string goalName)
		{
			if (!HasDisposed && goalFixedPriorities != null && goalFixedPriorities.ContainsKey(goalName))
			{
				goalFixedPriorities.Remove(goalName);
				if (owner is IGoapAgentOwner goapAgentOwner)
				{
					goapAgentOwner.GetGoapAgent()?.GoalScheduler?.UpdatePrioritiesDelayed();
				}
			}
		}

		public bool StartEffector(string effectorId, float durationModifier = 1f, bool startingAfterDeserialize = false)
		{
			try
			{
				return StartEffectorPrivate(effectorId, durationModifier, startingAfterDeserialize);
			}
			catch (Exception ex)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Effector ");
					messageBuilder.AppendFormatted(effectorId);
					messageBuilder.AppendLiteral(" threw exception on start. Stat's owner is ");
					messageBuilder.AppendFormatted(owner);
				}
				Log.Error(messageBuilder);
				Log.Error(ex.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				throw;
			}
		}

		private bool StartEffectorPrivate(string effectorId, float durationModifier = 1f, bool startingAfterDeserialize = false)
		{
			if (HasDisposed)
			{
				return false;
			}
			if (MonoSingleton<AnimalController>.IsApplicationIsQuitting())
			{
				return false;
			}
			if (bannedEffectors?.Set?.Contains(effectorId) == true)
			{
				return false;
			}
			if (string.IsNullOrEmpty(effectorId))
			{
				return false;
			}
			if (!Repository<EffectorRepository, StatEffector>.Instance.TryGetValue(effectorId, out var model))
			{
				return false;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(52, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Starting effector '");
				messageBuilder.AppendFormatted(effectorId);
				messageBuilder.AppendLiteral("' with duration ");
				messageBuilder.AppendFormatted(model.Duration);
				messageBuilder.AppendLiteral(" hours for agent ");
				messageBuilder.AppendFormatted(owner);
			}
			Log.Trace(messageBuilder);
			if (model.TriggerFailChance > 0f && NSMedieval.Tools.Math.Random.Range(0f, 1f) < model.TriggerFailChance)
			{
				return false;
			}
			if (model.IsDisabled)
			{
				if (allowedEffectors != null)
				{
					SerializableHashSet<string> serializableHashSet = allowedEffectors;
					if (serializableHashSet == null || serializableHashSet.Set.Contains(effectorId))
					{
						goto IL_0125;
					}
				}
				return false;
			}
			goto IL_0125;
			IL_0125:
			if (model.IsInstant)
			{
				foreach (EffectorBase instance in model.Instances)
				{
					if (!startingAfterDeserialize || !instance.DontRestartAfterDeserialization)
					{
						instance?.Start(this);
					}
				}
				this.OnInstantEffectorStartEvent?.Invoke(model);
				return true;
			}
			if (model.Category != null)
			{
				foreach (ActiveEffectorInfo item in activeEffectors.IterateInReverseDynamic())
				{
					if (item.Category != null && item.Category.Equals(model.Category) && !item.Name.Equals(effectorId))
					{
						EndEffector(item.Name);
					}
				}
			}
			int firstIndexOfEffector = GetFirstIndexOfEffector(effectorId);
			ActiveEffectorInfo value;
			if (firstIndexOfEffector == -1)
			{
				ActiveEffectorInfo activeEffectorInfo = new ActiveEffectorInfo(model, model.Category, 0, dateCache.MinutesTotal, model.Duration, durationModifier);
				value = activeEffectorInfo;
				activeEffectors.Add(activeEffectorInfo);
				ExecuteEffectorStartEvent(model);
			}
			else
			{
				value = activeEffectors[firstIndexOfEffector];
				if (model.MaxStack >= 0 && value.StackCount >= model.MaxStack)
				{
					if (model is StatEffectorWound statEffectorWound)
					{
						value = new ActiveEffectorInfo(model, model.Category, value.StackCount, dateCache.MinutesTotal, model.Duration, durationModifier);
						int firstIndexOfEffector2 = GetFirstIndexOfEffector(effectorId);
						activeEffectors[firstIndexOfEffector2] = value;
						foreach (EffectorBase item2 in statEffectorWound.InstancesOnRepeat)
						{
							if (!startingAfterDeserialize || !item2.DontRestartAfterDeserialization)
							{
								item2.Start(this);
							}
						}
						ExecuteEffectorStackEvent(model);
					}
					return false;
				}
				value = new ActiveEffectorInfo(model, model.Category, value.StackCount + 1, dateCache.MinutesTotal, model.Duration, durationModifier);
				int firstIndexOfEffector3 = GetFirstIndexOfEffector(effectorId);
				activeEffectors[firstIndexOfEffector3] = value;
				ExecuteEffectorStackEvent(model);
			}
			if (value.StackCount > 0)
			{
				foreach (EffectorBase instance2 in model.Instances)
				{
					if (!startingAfterDeserialize || !instance2.DontRestartAfterDeserialization)
					{
						instance2.Stack(this, (float)(value.StackCount + 1) * model.StackMultiplier);
					}
				}
				Update();
				return true;
			}
			foreach (EffectorBase instance3 in model.Instances)
			{
				if (!startingAfterDeserialize || !instance3.DontRestartAfterDeserialization)
				{
					instance3.Start(this);
				}
			}
			Update();
			return true;
		}

		public void StartEffectors(IEnumerable<string> effectorsToStart)
		{
			if (effectorsToStart == null)
			{
				return;
			}
			foreach (string item in effectorsToStart)
			{
				StartEffector(item);
			}
		}

		public void EndEffectors(IEnumerable<string> effectorsToEnd)
		{
			if (effectorsToEnd == null)
			{
				return;
			}
			foreach (string item in effectorsToEnd)
			{
				EndEffector(item);
			}
		}

		public void EndEffector(string name)
		{
			int firstIndexOfEffector = GetFirstIndexOfEffector(name);
			if (firstIndexOfEffector == -1)
			{
				return;
			}
			StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(name);
			ActiveEffectorInfo activeEffectorInfo = activeEffectors[firstIndexOfEffector];
			long num = dateCache.MinutesTotal - activeEffectorInfo.StartTime;
			if (num < 0)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(63, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Start time of effector ");
					messageBuilder.AppendFormatted(name);
					messageBuilder.AppendLiteral(" (");
					messageBuilder.AppendFormatted(byID.Category);
					messageBuilder.AppendLiteral(") is in the future. Stopping effector.");
				}
				Log.Warning(messageBuilder);
			}
			if (num >= 0 && byID.Duration > -1f && (float)num < byID.Duration)
			{
				return;
			}
			activeEffectors.RemoveAt(firstIndexOfEffector);
			foreach (EffectorBase instance in byID.Instances)
			{
				instance.End(this);
			}
			this.OnEffectorEndEvent?.Invoke(byID);
		}

		public void EndEffector(ref ActiveEffectorInfo activeEffectorInfo, int indexOfEffector)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(41, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Effector expired '");
				messageBuilder.AppendFormatted(activeEffectorInfo.Blueprint.GetID());
				messageBuilder.AppendLiteral("', ending it for owner ");
				messageBuilder.AppendFormatted(owner);
			}
			Log.Trace(messageBuilder);
			long num = dateCache.MinutesTotal - activeEffectorInfo.StartTime;
			if (num < 0)
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(63, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Start time of effector ");
					messageBuilder2.AppendFormatted(activeEffectorInfo.Name);
					messageBuilder2.AppendLiteral(" (");
					messageBuilder2.AppendFormatted(activeEffectorInfo.Blueprint.Category);
					messageBuilder2.AppendLiteral(") is in the future. Stopping effector.");
				}
				Log.Warning(messageBuilder2);
			}
			if (num >= 0 && activeEffectorInfo.Blueprint.Duration > -1f && (float)num < activeEffectorInfo.Blueprint.Duration)
			{
				return;
			}
			activeEffectors.RemoveAt(indexOfEffector);
			foreach (EffectorBase instance in activeEffectorInfo.Blueprint.Instances)
			{
				instance.End(this);
			}
			this.OnEffectorEndEvent?.Invoke(activeEffectorInfo.Blueprint);
		}

		public void Update(float stepTime = 0f)
		{
			if (GlobalSaveController.CurrentVillageData == null)
			{
				return;
			}
			if (owner == null)
			{
				Log.Error("No owner set!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				if (HasDisposed)
				{
					Log.Error("No owner set and StatsInstance was disposed!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				}
			}
			else
			{
				if (HasDisposed || owner.HasDisposed || (TutorialManager.IsTutorialActive && MonoSingleton<TutorialManager>.Instance.PreventWorldTimeTick && MonoSingleton<TutorialManager>.Instance.BlockStatUpdate(owner)))
				{
					return;
				}
				if (stepTime <= 0f)
				{
					foreach (AttributeInstance value in attributes.Dictionary.Values)
					{
						value.ResetMultiplier();
					}
					for (int i = 0; i < attributeModifiers.Count; i++)
					{
						attributeModifiers[i].Update(0f, this);
					}
					{
						foreach (KeyValuePair<StatType, StatInstance> item in stats.Dictionary)
						{
							item.Value.ApplyAttributes();
							if (item.Value.IsAtMinimum())
							{
								Controller.FireStatEvent(StatEventType.MinimumValueReached, item.Value);
							}
							if (HasDisposed)
							{
								break;
							}
						}
						return;
					}
				}
				foreach (AttributeInstance value2 in attributes.Dictionary.Values)
				{
					value2.ResetMultiplier();
				}
				for (int j = 0; j < attributeModifiers.Count; j++)
				{
					attributeModifiers[j].Update(stepTime, this);
				}
				foreach (KeyValuePair<StatType, StatInstance> item2 in stats.Dictionary)
				{
					bool disableShaker = item2.Value.DisableShaker;
					item2.Value.DisableShaker = true;
					item2.Value.ApplyAttributes();
					if (item2.Value.Update(stepTime))
					{
						Controller.FireStatEvent(StatEventType.ValueUpdated, item2.Value);
						if (item2.Value.IsAtMinimum())
						{
							Controller.FireStatEvent(StatEventType.MinimumValueReached, item2.Value);
						}
					}
					item2.Value.DisableShaker = disableShaker;
					if (HasDisposed)
					{
						break;
					}
				}
				this.OnStatsUpdatedEvent?.Invoke();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEffectorActive(string name)
		{
			return GetFirstIndexOfEffector(name) != -1;
		}

		public void Dispose()
		{
			if (HasDisposed)
			{
				return;
			}
			if (MonoSingleton<StatsUpdateManager>.IsInstantiated())
			{
				MonoSingleton<StatsUpdateManager>.Instance.UnregisterStat(this);
			}
			HasDisposed = true;
			this.OnEffectorStackEvent = null;
			this.OnEffectorStartEvent = null;
			this.OnStatsUpdatedEvent = null;
			if (controller != null)
			{
				controller.Dispose();
				controller = null;
			}
			if (attributeModifiers != null)
			{
				foreach (ModifierInstanceStack attributeModifier in attributeModifiers)
				{
					attributeModifier?.EndNow(hasDisposed: true);
				}
				attributeModifiers.Clear();
			}
			if (Repository<EffectorRepository, StatEffector>.IsInstantiated())
			{
				for (int num = activeEffectors.Count - 1; num >= 0; num--)
				{
					if (Repository<EffectorRepository, StatEffector>.Instance.TryGetValue(activeEffectors[num].Name, out var model))
					{
						for (int num2 = model.Instances.Count - 1; num2 >= 0; num2--)
						{
							model.Instances[num2]?.End(this);
						}
					}
				}
			}
			foreach (StatInstance value in stats.Dictionary.Values)
			{
				value.SetOwner(null);
				value.Dispose();
			}
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnEffectorStartEvent = null;
			this.OnInstantEffectorStartEvent = null;
			this.OnEffectorStackEvent = null;
			this.OnEffectorEndEvent = null;
			this.OnStatsUpdatedEvent = null;
			this.OnDisposedEvent = null;
			if (attributeModifiers != null)
			{
				foreach (ModifierInstanceStack attributeModifier2 in attributeModifiers)
				{
					attributeModifier2.Instances.Clear();
				}
				attributeModifiers.Clear();
			}
			stats.Dictionary.Clear();
			stats.Keys = null;
			stats.Values = null;
			stats = null;
			activeEffectors.Clear();
			foreach (AttributeInstance value2 in attributes.Dictionary.Values)
			{
				value2.SetOwner(null);
			}
			delayedEffectorStackEvent?.Clear();
			delayedEffectorStartEvent?.Clear();
			delayedEffectorStackEvent = null;
			delayedEffectorStartEvent = null;
			owner = null;
			ownerAnimalInstance = null;
			ownerHumanoidInstance = null;
			statsModelCache = null;
			isStatsRegistered = false;
		}

		public HashSet<string> GetBannedEffectors()
		{
			return bannedEffectors?.Set;
		}

		public HashSet<string> GetAllowedEffectors()
		{
			return allowedEffectors?.Set;
		}

		public List<ActiveEffectorInfo> GetActiveEffectors()
		{
			return activeEffectors;
		}

		public void SetActiveEffectors(IEnumerable<ActiveEffectorInfo> newInfo)
		{
			activeEffectors.Clear();
			activeEffectors.AddRange(newInfo);
			FireSavedEffectors();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ActiveEffectorInfo GetEffectorByIndex(int index)
		{
			return activeEffectors[index];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetFirstIndexOfEffector(string name)
		{
			int count = activeEffectors.Count;
			for (int i = 0; i < count; i++)
			{
				if (activeEffectors[i].Name.Equals(name))
				{
					return i;
				}
			}
			return -1;
		}

		internal void AddAttributeModifier(ModifierInstance modifier)
		{
			if (!HasDisposed)
			{
				ModifierInstanceStack modifierInstanceStack = attributeModifiers.Find((ModifierInstanceStack item) => item.Type == modifier.Type);
				if (modifierInstanceStack == null)
				{
					modifierInstanceStack = new ModifierInstanceStack(modifier.Type);
					attributeModifiers.Add(modifierInstanceStack);
				}
				modifier.Init(this);
				modifier.Update(0f);
				modifier.Apply();
				modifierInstanceStack.Add(modifier);
				Controller.FireEvent(StatEventType.AttributeModiferAdded, modifier);
				OptimizedUpdate();
			}
		}

		internal void RemoveAttributeModifier(ModifierType type, string tag)
		{
			if (HasDisposed)
			{
				return;
			}
			ModifierInstanceStack modifierInstanceStack = attributeModifiers.Find((ModifierInstanceStack entiry) => entiry.Type == type);
			if (modifierInstanceStack == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(tag))
			{
				ModifierInstance modifierInstance = modifierInstanceStack.Remove(tag);
				if (modifierInstance != null)
				{
					OptimizedUpdate();
					Controller.FireEvent(StatEventType.AttributeModiferRemoved, modifierInstance);
				}
				return;
			}
			foreach (ModifierInstance instance in modifierInstanceStack.Instances)
			{
				Controller.FireEvent(StatEventType.AttributeModiferRemoved, instance);
			}
			modifierInstanceStack.EndNow();
			attributeModifiers.Remove(modifierInstanceStack);
			OptimizedUpdate();
		}

		protected void SetAttributes(Dictionary<AttributeType, AttributeInstance> attributes)
		{
			this.attributes = SerializableDictionary<AttributeType, AttributeInstance>.CreateNew<SerializableAttributeDictionary>();
			this.attributes.Dictionary = attributes;
		}

		protected void SetAttributeModifiers(List<ModifierInstanceStack> attributeModifiers)
		{
			this.attributeModifiers = attributeModifiers;
		}

		protected void SetStats(Dictionary<StatType, StatInstance> stats)
		{
			this.stats = SerializableDictionary<StatType, StatInstance>.CreateNew<SerializableStatDictionary>();
			this.stats.Dictionary = stats;
		}

		private void OptimizedUpdate()
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "the_update", delegate
			{
				Update();
			});
		}

		private void FireSavedEffectors()
		{
			List<ActiveEffectorInfo> list = new List<ActiveEffectorInfo>(activeEffectors);
			activeEffectors.Clear();
			foreach (ActiveEffectorInfo item in list)
			{
				StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(item.Name);
				bool isEnabled;
				if (byID == null)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Effector ");
						messageBuilder.AppendFormatted(item.Name);
						messageBuilder.AppendLiteral(" saved in save, but does not exist anymore!");
					}
					Log.Info(messageBuilder);
				}
				else
				{
					if (byID.DontSave)
					{
						continue;
					}
					int num = Math.Max(item.StackCount, 0);
					for (int i = 0; i <= num; i++)
					{
						StartEffector(item.Name, item.DurationModifier, startingAfterDeserialize: true);
					}
					int firstIndexOfEffector = GetFirstIndexOfEffector(item.Name);
					if (firstIndexOfEffector == -1)
					{
						FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(44, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("FireSavedEffectors: effector ");
							messageBuilder2.AppendFormatted(item.Name);
							messageBuilder2.AppendLiteral(" not found for ");
							messageBuilder2.AppendFormatted(Owner);
						}
						Log.Warning(messageBuilder2);
						continue;
					}
					ActiveEffectorInfo activeEffectorInfo = activeEffectors[firstIndexOfEffector];
					if (item.WoundInfo != null && item.WoundInfo.Blueprint == null)
					{
						Log.Info("Wound effector blueprint missing. Probably removed", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
						if (activeEffectorInfo.Blueprint == null || !(activeEffectorInfo.Blueprint is StatEffectorWound))
						{
							Log.Info("Removing effector instance.", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
							activeEffectors.RemoveAt(firstIndexOfEffector);
							continue;
						}
					}
					activeEffectorInfo = new ActiveEffectorInfo(activeEffectorInfo.Blueprint, activeEffectorInfo.Category, activeEffectorInfo.StackCount, item.StartTime, activeEffectorInfo.Duration, item.DurationModifier, item.WoundInfo);
					activeEffectors[firstIndexOfEffector] = activeEffectorInfo;
				}
			}
			if (activeEffectors.Count > 0)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					if (!HasDisposed && stats != null && Stats != null)
					{
						foreach (KeyValuePair<StatType, StatInstance> stat in Stats)
						{
							stat.Value.ForceRefreshThresholdEffectors();
						}
					}
				});
			}
			savedEffectorsFired = true;
			FireQueuedEffectorEvents();
		}

		private void ExecuteEffectorStackEvent(StatEffector effector)
		{
			if (!savedEffectorsFired)
			{
				if (delayedEffectorStackEvent == null)
				{
					delayedEffectorStackEvent = new List<StatEffector>();
				}
				delayedEffectorStackEvent.Add(effector);
			}
			else
			{
				this.OnEffectorStackEvent?.Invoke(effector);
			}
		}

		private void ExecuteEffectorStartEvent(StatEffector effector)
		{
			if (!savedEffectorsFired)
			{
				if (delayedEffectorStartEvent == null)
				{
					delayedEffectorStartEvent = new List<StatEffector>();
				}
				delayedEffectorStartEvent.Add(effector);
			}
			else
			{
				this.OnEffectorStartEvent?.Invoke(effector);
			}
		}

		private void FireQueuedEffectorEvents()
		{
			if (delayedEffectorStartEvent != null && delayedEffectorStartEvent.Count > 0)
			{
				foreach (StatEffector item in delayedEffectorStartEvent)
				{
					if (GetFirstIndexOfEffector(item.GetID()) != -1)
					{
						this.OnEffectorStartEvent?.Invoke(item);
					}
				}
				delayedEffectorStartEvent = null;
			}
			if (delayedEffectorStackEvent == null || delayedEffectorStackEvent.Count <= 0)
			{
				return;
			}
			foreach (StatEffector item2 in delayedEffectorStackEvent)
			{
				if (GetFirstIndexOfEffector(item2.GetID()) != -1)
				{
					this.OnEffectorStackEvent?.Invoke(item2);
				}
			}
			delayedEffectorStackEvent = null;
		}

		public void HandleEffectorTimers(long currentTimeMinutes, int minutesInHour)
		{
			int num = 0;
			string text = null;
			try
			{
				for (int num2 = activeEffectors.Count - 1; num2 >= 0; num2--)
				{
					if (num2 < activeEffectors.Count)
					{
						ActiveEffectorInfo activeEffectorInfo = activeEffectors[num2];
						num = num2;
						text = activeEffectorInfo.Name;
						if (activeEffectorInfo.WoundInfo != null && activeEffectorInfo.WoundInfo.Blueprint != null)
						{
							if (WoundUtils.Tick(this, activeEffectorInfo.WoundInfo))
							{
								EndEffector(activeEffectorInfo.Name);
							}
						}
						else if (!(activeEffectorInfo.Duration <= 0f) && (float)(currentTimeMinutes - activeEffectorInfo.StartTime) > activeEffectorInfo.Duration * (float)minutesInHour)
						{
							EndEffector(ref activeEffectorInfo, num2);
						}
					}
				}
			}
			catch (Exception)
			{
				if (text == null)
				{
					Log.Error("Effector thrown exception DEFAULT", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
					throw;
				}
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(47, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Effector thrown exception at effector ");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral(", owner: ");
					messageBuilder.AppendFormatted(Owner);
				}
				Log.Error(messageBuilder);
				if (num > -1)
				{
					activeEffectors.RemoveAt(num);
				}
				throw;
			}
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("attributes", attributes);
			serializer.Write("stats", stats);
			serializer.Write("activeEffectors", activeEffectors);
			serializer.Write("isInitialized", isInitialized);
			serializer.Write("repositoryName", repositoryName);
			serializer.Write("statsModelId", statsModelId);
		}

		public void OnBeforeSerialize()
		{
			if (attributeModifiers == null)
			{
				return;
			}
			foreach (var (modifierInstanceStack, index) in attributeModifiers.IterateInReverseDynamicWithIndex())
			{
				if (modifierInstanceStack == null || modifierInstanceStack.Instances.Count == 0)
				{
					attributeModifiers.RemoveAt(index);
				}
			}
		}

		public StatsInstance(FVDeserializer deserializer)
		{
			attributes = deserializer.ReadObject<SerializableAttributeDictionary>("attributes");
			stats = deserializer.ReadObject<SerializableStatDictionary>("stats");
			activeEffectors = deserializer.ReadObjectList<ActiveEffectorInfo>("activeEffectors");
			isInitialized = deserializer.ReadBool("isInitialized");
			repositoryName = deserializer.ReadString("repositoryName");
			statsModelId = deserializer.ReadString("statsModelId");
			OnAfterDeserialize();
		}

		public void OnAfterDeserialize()
		{
			if (!isInitialized || stats == null)
			{
				if (stats == null)
				{
					Log.Error("Error deserializing stats!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsInstance.cs");
				}
				return;
			}
			attributeModifiers = new List<ModifierInstanceStack>();
			if (activeEffectors.Count > 0)
			{
				activeEffectors.RemoveAll((ActiveEffectorInfo item) => item.Blueprint == null || item.Blueprint.DontSave);
			}
		}
	}
}
