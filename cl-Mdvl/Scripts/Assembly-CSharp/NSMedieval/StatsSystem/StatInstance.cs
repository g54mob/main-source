using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("StatInstance", "")]
	public class StatInstance : ISerializationCallbackReceiver, IFVSerializable
	{
		private class AttributeModifiersCache
		{
			public class AttributeBaseCache
			{
				private float baseValue;

				private List<AttributeInstance> instances = new List<AttributeInstance>();

				public float BaseValue => baseValue;

				public List<AttributeInstance> Instances => instances;

				public AttributeBaseCache(float baseValue)
				{
					this.baseValue = baseValue;
				}

				public float CalculateValue()
				{
					if (instances == null || instances.Count == 0)
					{
						return baseValue;
					}
					float num = baseValue;
					for (int i = 0; i < instances.Count; i++)
					{
						AttributeInstance attributeInstance = instances[i];
						if (attributeInstance.Blueprint.ShouldApply(num))
						{
							num *= attributeInstance.Value;
						}
					}
					return num;
				}

				public void Dispose()
				{
					foreach (AttributeInstance instance in instances)
					{
						instance.Dispose();
					}
					instances.Clear();
				}
			}

			private readonly List<AttributeBaseCache> min = new List<AttributeBaseCache>();

			private readonly List<AttributeBaseCache> max = new List<AttributeBaseCache>();

			private readonly List<AttributeBaseCache> step = new List<AttributeBaseCache>();

			private readonly List<AttributeBaseCache> threshold = new List<AttributeBaseCache>();

			private readonly List<AttributeBaseCache> target = new List<AttributeBaseCache>();

			public List<AttributeBaseCache> Min => min;

			public List<AttributeBaseCache> Max => max;

			public List<AttributeBaseCache> Step => step;

			public List<AttributeBaseCache> Threshold => threshold;

			public List<AttributeBaseCache> Target => target;

			public void Dispose()
			{
				foreach (AttributeBaseCache item in min)
				{
					item.Dispose();
				}
				foreach (AttributeBaseCache item2 in max)
				{
					item2.Dispose();
				}
				foreach (AttributeBaseCache item3 in step)
				{
					item3.Dispose();
				}
				foreach (AttributeBaseCache item4 in threshold)
				{
					item4.Dispose();
				}
				foreach (AttributeBaseCache item5 in target)
				{
					item5.Dispose();
				}
				min.Clear();
				max.Clear();
				step.Clear();
				threshold.Clear();
				target.Clear();
			}

			public AttributeModifiersCache(Stat blueprint, StatsInstance statsInstance)
			{
				foreach (StatAttributeElement item in blueprint.Min)
				{
					AttributeBaseCache attributeBaseCache = new AttributeBaseCache(item.BaseValue);
					if (item.Attributes != null)
					{
						AttributeType[] attributes = item.Attributes;
						foreach (AttributeType type in attributes)
						{
							AttributeInstance attributeInstance = statsInstance.GetAttributeInstance(type);
							if (attributeInstance != null)
							{
								attributeBaseCache.Instances.Add(attributeInstance);
							}
						}
					}
					min.Add(attributeBaseCache);
				}
				foreach (StatAttributeElement item2 in blueprint.Max)
				{
					AttributeBaseCache attributeBaseCache2 = new AttributeBaseCache(item2.BaseValue);
					if (item2.Attributes != null)
					{
						AttributeType[] attributes = item2.Attributes;
						foreach (AttributeType type2 in attributes)
						{
							AttributeInstance attributeInstance2 = statsInstance.GetAttributeInstance(type2);
							if (attributeInstance2 != null)
							{
								attributeBaseCache2.Instances.Add(attributeInstance2);
							}
						}
					}
					max.Add(attributeBaseCache2);
				}
				foreach (StatAttributeElement item3 in blueprint.Step)
				{
					AttributeBaseCache attributeBaseCache3 = new AttributeBaseCache(item3.BaseValue);
					if (item3.Attributes != null)
					{
						AttributeType[] attributes = item3.Attributes;
						foreach (AttributeType type3 in attributes)
						{
							AttributeInstance attributeInstance3 = statsInstance.GetAttributeInstance(type3);
							if (attributeInstance3 != null)
							{
								attributeBaseCache3.Instances.Add(attributeInstance3);
							}
						}
					}
					step.Add(attributeBaseCache3);
				}
				if (blueprint.Target != null)
				{
					foreach (StatAttributeElement item4 in blueprint.Target)
					{
						AttributeBaseCache attributeBaseCache4 = new AttributeBaseCache(item4.BaseValue);
						if (item4.Attributes != null)
						{
							AttributeType[] attributes = item4.Attributes;
							foreach (AttributeType type4 in attributes)
							{
								AttributeInstance attributeInstance4 = statsInstance.GetAttributeInstance(type4);
								if (attributeInstance4 != null)
								{
									attributeBaseCache4.Instances.Add(attributeInstance4);
								}
							}
						}
						target.Add(attributeBaseCache4);
					}
				}
				if (blueprint.ThresholdAttributes == null)
				{
					return;
				}
				foreach (StatAttributeElement thresholdAttribute in blueprint.ThresholdAttributes)
				{
					AttributeBaseCache attributeBaseCache5 = new AttributeBaseCache(thresholdAttribute.BaseValue);
					if (thresholdAttribute.Attributes != null)
					{
						AttributeType[] attributes = thresholdAttribute.Attributes;
						foreach (AttributeType type5 in attributes)
						{
							AttributeInstance attributeInstance5 = statsInstance.GetAttributeInstance(type5);
							if (attributeInstance5 != null)
							{
								attributeBaseCache5.Instances.Add(attributeInstance5);
							}
						}
					}
					threshold.Add(attributeBaseCache5);
				}
			}
		}

		[SerializeField]
		private StatType type;

		[SerializeField]
		private float current;

		[SerializeField]
		private bool isDisabled;

		private bool isLocked;

		[SerializeField]
		private SerializableHashSet<StatThresholdTrigger> activeThresholdTriggerEffects = new SerializableHashSet<StatThresholdTrigger>();

		[NonSerialized]
		private float min;

		[NonSerialized]
		private float max;

		[NonSerialized]
		private float target;

		[NonSerialized]
		private float step;

		[NonSerialized]
		private float thresholdMultiplier = 1f;

		[NonSerialized]
		private Stat blueprint;

		[NonSerialized]
		private AttributeModifiersCache attributesCache;

		[NonSerialized]
		private StatsInstance statsInstance;

		[NonSerialized]
		private StatTrend statTrend;

		[NonSerialized]
		private bool fireMinimumReachedEvent;

		public bool DisableShaker { get; set; }

		public float Min => min;

		public float Max => max;

		public float Current => current;

		public float Step => step;

		public float Target => target;

		public float ThresholdMultiplier => thresholdMultiplier;

		public StatType Type => type;

		public StatsInstance Owner => statsInstance;

		public SerializableHashSet<StatThresholdTrigger> ActiveThresholdTriggerEffects => activeThresholdTriggerEffects;

		public Stat Blueprint
		{
			get
			{
				if (blueprint == null)
				{
					InitBlueprint();
				}
				return blueprint;
			}
		}

		public StatTrend StatTrend => statTrend;

		public bool IsDisabled => isDisabled;

		public bool IsLocked => isLocked;

		public StatInstance(Stat blueprint, StatsInstance statsInstance)
		{
			type = blueprint.Type;
			this.blueprint = blueprint;
			current = this.blueprint.InitialValue;
			this.statsInstance = statsInstance;
			isDisabled = this.blueprint.IsDisabled;
		}

		public StatInstance(StatType type, StatsInstance statsInstance)
		{
			this.type = type;
			blueprint = Repository<StatRepository, Stat>.Instance.GetByID(statsInstance.RepositoryName, type.ToString());
			current = blueprint.InitialValue;
			this.statsInstance = statsInstance;
			isDisabled = blueprint.IsDisabled;
		}

		public void Dispose()
		{
			activeThresholdTriggerEffects.Set?.Clear();
			activeThresholdTriggerEffects = null;
			attributesCache?.Dispose();
			attributesCache = null;
			statsInstance = null;
		}

		public void Initialize(StatsInstance owner, bool forceReInit)
		{
			if (statsInstance == null || forceReInit)
			{
				statsInstance = owner;
				if (Blueprint == null && Owner.RepositoryName != null)
				{
					Log.Warning("Could not initialize stat blueprint.", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatInstance.cs");
					return;
				}
				CacheAttributes();
				statTrend = StatTrend.None;
				RefreshSavedThresholdTriggerEffects();
			}
		}

		public int GetCurrentThresholdIndex()
		{
			return activeThresholdTriggerEffects.Set.Count;
		}

		public void ForceCurrentValue(float value)
		{
			if (!IsDisabled && !IsLocked)
			{
				current = value;
			}
		}

		public void SetCurrent(float value)
		{
			if (IsDisabled || IsLocked)
			{
				return;
			}
			float num = current;
			bool flag = IsAtMinimum();
			current = Mathf.Clamp(value, min, max);
			statTrend = StatTrend.None;
			if (current != num && Owner != null)
			{
				statTrend = ((current > num) ? StatTrend.Up : StatTrend.Down);
				Owner.Controller.FireStatEvent(StatEventType.ValueUpdated, this);
				if (!flag && IsAtMinimum() && !fireMinimumReachedEvent)
				{
					fireMinimumReachedEvent = true;
					Owner?.Controller?.FireStatEvent(StatEventType.MinimumValueReached, this);
				}
				if (Owner?.Controller != null)
				{
					CheckAndFireThresholdTriggers();
				}
			}
		}

		public void AddCurrent(float value)
		{
			if (!IsDisabled && !IsLocked)
			{
				SetCurrent(current + value);
			}
		}

		public bool IsAtMinimum()
		{
			return IsAtMinimum(current);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsAtMinimum(float value)
		{
			if (Mathf.RoundToInt(value) <= Mathf.RoundToInt(Min))
			{
				return Max > 0f;
			}
			return false;
		}

		public bool IsAtMaximum()
		{
			return current >= max;
		}

		public void SetBlueprint(Stat blueprint)
		{
			this.blueprint = blueprint;
			if (statsInstance != null)
			{
				CacheAttributes();
				ApplyAttributes();
			}
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void ForceRefreshThresholdEffectors()
		{
			CheckAndFireThresholdTriggers();
		}

		public void ReTriggerThresholdEffectors()
		{
			foreach (StatThresholdTrigger item in activeThresholdTriggerEffects.Set)
			{
				string[] effectors = item.Effectors;
				foreach (string text in effectors)
				{
					if (!statsInstance.IsEffectorActive(text))
					{
						statsInstance.StartEffector(text);
					}
				}
			}
		}

		internal void ApplyAttributes()
		{
			thresholdMultiplier = 0f;
			min = 0f;
			max = 0f;
			step = 0f;
			target = 0f;
			if (attributesCache == null)
			{
				CacheAttributes();
			}
			for (int i = 0; i < attributesCache.Min.Count; i++)
			{
				min += attributesCache.Min[i].CalculateValue();
			}
			for (int j = 0; j < attributesCache.Max.Count; j++)
			{
				max += attributesCache.Max[j].CalculateValue();
			}
			for (int k = 0; k < attributesCache.Step.Count; k++)
			{
				step += attributesCache.Step[k].CalculateValue();
			}
			for (int l = 0; l < attributesCache.Threshold.Count; l++)
			{
				thresholdMultiplier += attributesCache.Threshold[l].CalculateValue();
			}
			if (thresholdMultiplier == 0f)
			{
				thresholdMultiplier = 1f;
			}
			if (attributesCache.Target != null)
			{
				foreach (AttributeModifiersCache.AttributeBaseCache item in attributesCache.Target)
				{
					target += item.CalculateValue();
				}
				if (float.IsNaN(target))
				{
					target = 0f;
				}
				target = Mathf.Clamp(target, min, max);
			}
			if (current > max)
			{
				current = max;
			}
		}

		internal void SetOwner(StatsInstance owner)
		{
			statsInstance = owner;
		}

		internal void SetLocked(bool isLocked)
		{
			this.isLocked = isLocked;
		}

		internal void SetDisabled(bool isDisabled)
		{
			this.isDisabled = isDisabled;
			if (!this.isDisabled)
			{
				return;
			}
			foreach (StatThresholdTrigger item in activeThresholdTriggerEffects.Set)
			{
				item.EndEffects(statsInstance, skipDurationEffectors: true);
			}
			activeThresholdTriggerEffects.Set.Clear();
		}

		internal bool Update(float deltaTime)
		{
			if (IsDisabled || IsLocked)
			{
				return false;
			}
			if (current > max)
			{
				current = max;
			}
			float a = current;
			if (!HandleStatTarget(deltaTime))
			{
				SetCurrent(Mathf.Clamp(current + step * deltaTime, min, max));
			}
			fireMinimumReachedEvent = false;
			CheckAndFireThresholdTriggers();
			return !Mathf.Approximately(a, current);
		}

		internal void InitAsCustomStat()
		{
			CacheAttributes();
			ApplyAttributes();
		}

		private bool HandleStatTarget(float deltaTime)
		{
			if (Blueprint.Target == null || Blueprint.Target.Count == 0)
			{
				return false;
			}
			if (Mathf.Abs(current - target) <= 0.5f)
			{
				return true;
			}
			if (target > current && step < 0f)
			{
				step = Mathf.Abs(step);
			}
			else if (target < current && step > 0f)
			{
				step *= -1f;
			}
			SetCurrent(Mathf.Clamp(current + step * deltaTime, min, max));
			return true;
		}

		private void InitBlueprint()
		{
			if (Owner?.StatsModel != null)
			{
				blueprint = Owner.StatsModel.GetByType(Type);
			}
			if (!(blueprint != null) && Owner?.RepositoryName != null)
			{
				blueprint = Repository<StatRepository, Stat>.Instance.GetByID(Owner.RepositoryName, Type.ToString());
			}
		}

		private void CheckAndFireThresholdTriggers()
		{
			if (statsInstance == null || statsInstance.HasDisposed || Blueprint?.ThresholdTriggers == null || IsDisabled)
			{
				return;
			}
			CheckExactThresholdTriggers();
			StatThresholdTrigger[] thresholdTriggers = Blueprint.ThresholdTriggers;
			foreach (StatThresholdTrigger trigger in thresholdTriggers)
			{
				if (trigger?.Effectors == null)
				{
					continue;
				}
				if ((float)(int)current <= (float)trigger.Trigger * thresholdMultiplier)
				{
					if (!activeThresholdTriggerEffects.Set.Contains(trigger))
					{
						MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
						{
							trigger.StartEffects(statsInstance);
						});
						activeThresholdTriggerEffects.Set.Add(trigger);
					}
					continue;
				}
				if (!activeThresholdTriggerEffects.Set.Contains(trigger))
				{
					if (statsInstance != null && trigger.Effectors.Any((string item) => statsInstance.IsEffectorActive(item)))
					{
						trigger.EndEffects(statsInstance, skipDurationEffectors: true);
					}
					continue;
				}
				trigger.EndEffects(statsInstance, skipDurationEffectors: true);
				activeThresholdTriggerEffects.Set.Remove(trigger);
				if (activeThresholdTriggerEffects.Set.Count <= 0)
				{
					continue;
				}
				foreach (StatThresholdTrigger item in new HashSet<StatThresholdTrigger>(activeThresholdTriggerEffects.Set))
				{
					if ((float)(int)current <= (float)item.Trigger * thresholdMultiplier)
					{
						item.RestartEffectors(statsInstance);
					}
				}
			}
		}

		private StatThresholdTrigger GetCurrentTrigger()
		{
			for (int i = 1; i < Blueprint.ThresholdTriggers.Length; i++)
			{
				if ((float)Blueprint.ThresholdTriggers[i].Trigger * thresholdMultiplier <= current)
				{
					return Blueprint.ThresholdTriggers[i - 1];
				}
			}
			return Blueprint.ThresholdTriggers.LastOrDefault();
		}

		private void CheckExactThresholdTriggers()
		{
			StatThresholdTrigger currentTrigger = GetCurrentTrigger();
			StatThresholdTrigger[] thresholdTriggers = Blueprint.ThresholdTriggers;
			string[] bannedEffectors;
			foreach (StatThresholdTrigger statThresholdTrigger in thresholdTriggers)
			{
				if (statThresholdTrigger != currentTrigger)
				{
					bannedEffectors = statThresholdTrigger.BannedEffectors;
					foreach (string name in bannedEffectors)
					{
						statsInstance.UnBanEffector(name);
					}
					bannedEffectors = statThresholdTrigger.AllowedEffectors;
					foreach (string name2 in bannedEffectors)
					{
						statsInstance.UnAllowEffector(name2);
					}
				}
			}
			bannedEffectors = currentTrigger.Perks;
			if (bannedEffectors != null && bannedEffectors.Length > 0)
			{
				bannedEffectors = currentTrigger.Perks;
				foreach (string perkId in bannedEffectors)
				{
					statsInstance.OwnerHumanoidInstance.TryAddNewPerk(perkId);
				}
			}
			bannedEffectors = currentTrigger.BannedEffectors;
			foreach (string name3 in bannedEffectors)
			{
				statsInstance.BanEffector(name3);
			}
			bannedEffectors = currentTrigger.AllowedEffectors;
			foreach (string name4 in bannedEffectors)
			{
				statsInstance.AllowEffector(name4);
			}
		}

		private void RefreshSavedThresholdTriggerEffects()
		{
			if (activeThresholdTriggerEffects.Set.Count == 0)
			{
				return;
			}
			HashSet<StatThresholdTrigger> hashSet = new HashSet<StatThresholdTrigger>();
			foreach (StatThresholdTrigger trigger in activeThresholdTriggerEffects.Set)
			{
				if (trigger == null)
				{
					Log.Warning("Tried to load saved trigger which is NULL. Skipping...", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatInstance.cs");
					continue;
				}
				if (trigger.Name == null)
				{
					Log.Warning("Tried to load saved trigger with no name. Skipping...", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatInstance.cs");
					continue;
				}
				StatThresholdTrigger statThresholdTrigger = Blueprint.ThresholdTriggers.FirstOrDefault((StatThresholdTrigger item) => item.Name.Equals(trigger.Name));
				if (statThresholdTrigger == null)
				{
					Log.Warning("Refreshing saved threshold trigger problem. Trigger name: '" + trigger.Name + "' not found in blueprint", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatInstance.cs");
				}
				else
				{
					hashSet.Add(statThresholdTrigger);
				}
			}
			activeThresholdTriggerEffects.Set = hashSet;
		}

		private void CacheAttributes()
		{
			attributesCache = new AttributeModifiersCache(Blueprint, statsInstance);
		}

		public float GetNormalizedPercentage()
		{
			if (current == 0f && min == 0f && max == 0f)
			{
				return 1f;
			}
			return (current - min) / (max - min);
		}

		public void SetNormalizedPercentage(float percentage)
		{
			if (!IsDisabled)
			{
				current = percentage * (max - min) + min;
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.WriteEnum("type", type);
			serializer.Write("current", current);
			serializer.Write("activeThresholdTriggerEffects", activeThresholdTriggerEffects.Set);
			serializer.Write("isLocked", isLocked);
		}

		public StatInstance(FVDeserializer deserializer)
		{
			type = deserializer.ReadEnum("type", StatType.None);
			current = deserializer.ReadFloat("current");
			activeThresholdTriggerEffects.Set = deserializer.ReadObjectHashSet<StatThresholdTrigger>("activeThresholdTriggerEffects");
			isLocked = deserializer.ReadBool("isLocked");
		}
	}
}
