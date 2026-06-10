using System;
using System.Collections.Generic;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State.Timers;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village;

namespace NSMedieval.State
{
	public class WarmthInstance : IGameDisposable, IDisposable
	{
		private Func<List<EquipmentInstance>> getEquipments;

		private IntRange warmthLevels;

		private WarmthBase warmthBase;

		private Action warmthLevelChange;

		private Timer updateTimer;

		private StatsInstance owner;

		private HashSet<string> activeEffects = new HashSet<string>();

		private float minTemperatureFromEffector;

		private float maxTemperatureFromEffector;

		private FloatRange currentWarmthRange;

		private float optimalRangeCacheMin;

		private float optimalRangeCacheMax;

		public float OptimalRangeCacheMin => optimalRangeCacheMin;

		public float OptimalRangeCacheMax => optimalRangeCacheMax;

		public float MinTemperatureFromEffector => minTemperatureFromEffector;

		public float MaxTemperatureFromEffector => maxTemperatureFromEffector;

		public bool HasDisposed { get; protected set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		public WarmthInstance(StatsInstance owner, Func<List<EquipmentInstance>> getEquipments, WarmthBase warmthBase)
		{
			this.owner = owner;
			this.getEquipments = getEquipments;
			this.warmthBase = warmthBase;
			warmthLevels = GetCurrentWarmthLevels();
			DateTimeSettings data = Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>();
			updateTimer = new Timer((float)(int)data.MinutesInHour / (float)(int)data.StatsUpdatePerHour);
			updateTimer.AddCallback(UpdateWarmth);
			updateTimer.SetRestartOnEnd(value: true);
			HandleEffectors();
		}

		public void AddToEffectorMinMaxTemperature(float min, float max)
		{
			minTemperatureFromEffector += min;
			maxTemperatureFromEffector += max;
		}

		public FloatRange GetWarmthModifiers()
		{
			float num = minTemperatureFromEffector;
			float num2 = maxTemperatureFromEffector;
			foreach (EquipmentInstance item in getEquipments())
			{
				if (item.Blueprint.WarmthModifier != null)
				{
					num += item.Blueprint.WarmthModifier.Min;
					num2 += item.Blueprint.WarmthModifier.Max;
				}
			}
			if (currentWarmthRange == null)
			{
				currentWarmthRange = new FloatRange(num, num2);
			}
			else
			{
				currentWarmthRange.Min = num;
				currentWarmthRange.Max = num2;
			}
			return currentWarmthRange;
		}

		public FloatRange GetCapWarmthModifier()
		{
			float num = 0f;
			float num2 = 0f;
			foreach (EquipmentInstance item in getEquipments())
			{
				if (item.Blueprint.WarmthModifier != null && item.Blueprint.EquipmentSlots == EquipmentSlotType.Head)
				{
					num += item.Blueprint.WarmthModifier.Min;
					num2 += item.Blueprint.WarmthModifier.Max;
				}
			}
			return new FloatRange(num, num2);
		}

		public FloatRange GetClothesWarmthModifier()
		{
			float num = 0f;
			float num2 = 0f;
			foreach (EquipmentInstance item in getEquipments())
			{
				if (item.Blueprint.WarmthModifier != null && item.Blueprint.EquipmentSlots == EquipmentSlotType.Body)
				{
					num += item.Blueprint.WarmthModifier.Min;
					num2 += item.Blueprint.WarmthModifier.Max;
				}
			}
			return new FloatRange(num, num2);
		}

		public void AddWarmthChangeListener(Action warmthLevelChange)
		{
			this.warmthLevelChange = (Action)Delegate.Combine(this.warmthLevelChange, warmthLevelChange);
		}

		public void RemoveWarmthChangeListener(Action warmthLevelChange)
		{
			this.warmthLevelChange = (Action)Delegate.Remove(this.warmthLevelChange, warmthLevelChange);
		}

		public IntRange GetCurrentWarmthLevels()
		{
			float ownerTemperature = GetOwnerTemperature();
			int min = -1;
			int max = -1;
			FloatRange warmthModifiers = GetWarmthModifiers();
			for (int i = 0; i < warmthBase.ColdThresholds.Count; i++)
			{
				if ((float)warmthBase.ColdThresholds[i].Trigger + warmthModifiers.Min >= ownerTemperature)
				{
					min = i;
				}
			}
			for (int j = 0; j < warmthBase.HotTresholds.Count; j++)
			{
				if ((float)warmthBase.HotTresholds[j].Trigger + warmthModifiers.Max <= ownerTemperature)
				{
					max = j;
				}
			}
			optimalRangeCacheMin = warmthModifiers.Min + (float)warmthBase.ColdThresholds[0].Trigger + 1f;
			optimalRangeCacheMax = warmthModifiers.Max + (float)warmthBase.HotTresholds[0].Trigger - 1f;
			return new IntRange(min, max);
		}

		public void UpdateWarmth()
		{
			IntRange currentWarmthLevels = GetCurrentWarmthLevels();
			if (warmthLevels.Min != currentWarmthLevels.Min || warmthLevels.Max != currentWarmthLevels.Max)
			{
				warmthLevels = currentWarmthLevels;
				warmthLevelChange?.Invoke();
				HandleEffectors();
			}
		}

		public void Dispose()
		{
			updateTimer.Dispose();
			updateTimer = null;
			HasDisposed = true;
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnDisposedEvent = null;
			owner = null;
			getEquipments = null;
			warmthLevelChange = null;
			activeEffects.Clear();
			activeEffects = null;
			warmthLevels = null;
			currentWarmthRange = null;
			warmthBase = null;
		}

		private void HandleEffectors()
		{
			activeEffects.Clear();
			if (warmthLevels.Min > -1)
			{
				for (int i = 0; i < warmthLevels.Min + 1; i++)
				{
					string[] effectors = warmthBase.ColdThresholds[i].Effectors;
					foreach (string text in effectors)
					{
						activeEffects.Add(text);
						if (!owner.IsEffectorActive(text))
						{
							owner.StartEffector(text);
						}
					}
				}
			}
			if (warmthLevels.Max > -1)
			{
				for (int k = 0; k < warmthLevels.Max + 1; k++)
				{
					string[] effectors = warmthBase.HotTresholds[k].Effectors;
					foreach (string text2 in effectors)
					{
						activeEffects.Add(text2);
						if (!owner.IsEffectorActive(text2))
						{
							owner.StartEffector(text2);
						}
					}
				}
			}
			EndEffectors(warmthBase.HotTresholds);
			EndEffectors(warmthBase.ColdThresholds);
		}

		private void EndEffectors(List<StatThresholdTrigger> triggers)
		{
			foreach (StatThresholdTrigger trigger in triggers)
			{
				string[] effectors = trigger.Effectors;
				foreach (string text in effectors)
				{
					if (!activeEffects.Contains(text))
					{
						owner.EndEffector(text);
					}
				}
			}
		}

		private float GetOwnerTemperature()
		{
			if (owner.Owner is CreatureBase creatureBase)
			{
				Vec3Int gridPosition = GridUtils.GetGridPosition(creatureBase.GetPosition());
				if (creatureBase.Map?.TemperatureManager != null)
				{
					return creatureBase.Map.TemperatureManager.GetTemperature(gridPosition);
				}
				return 0f;
			}
			if (owner.Owner is WorldObject worldObject)
			{
				if (worldObject.Map?.TemperatureManager != null)
				{
					return worldObject.Map.TemperatureManager.GetTemperature(worldObject.GridDataPosition);
				}
				return 0f;
			}
			return GlobalSaveController.CurrentVillageData.DateAndTime.TemperatureCelsius;
		}
	}
}
