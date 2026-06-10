using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Weather;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	public class DecayModifier : ModifierInstance, IObserver
	{
		private AttributeInstance decayAttribute;

		private AttributeType affectedAttributeType;

		private float baseValue;

		private float[] temperatureCoefficients;

		private bool isOnGround;

		private bool isUnderRoof;

		private bool underWater;

		private float currentTempCoefficient;

		private float currentWeatherCoefficient;

		private DecayModifiers decayModifier;

		private float previousTemperature = float.MinValue;

		private int lastThresholdIndex = -1;

		private WorldObject ownerWorldObject;

		private CreatureBase ownerCreatureBase;

		private VillageMap map;

		public bool IsOnGround => isOnGround;

		public bool IsUnderRoof => isUnderRoof;

		public bool UnderWater => underWater;

		public AttributeType AffectedAttributeType => affectedAttributeType;

		public DecayModifier(AttributeType attributeType, DecayModifiers decayModifier, VillageMap map, bool isOnGround, bool isUnderRoof, bool underWater, string tag)
			: base(ModifierType.Decay, tag)
		{
			this.map = map;
			this.decayModifier = decayModifier;
			currentWeatherCoefficient = 0f;
			affectedAttributeType = attributeType;
			temperatureCoefficients = decayModifier.TemperatureCoefficients;
			if (!underWater)
			{
				this.isOnGround = isOnGround;
				this.isUnderRoof = isUnderRoof;
				baseValue = decayModifier.GroundCoefficient;
			}
			else
			{
				baseValue = decayModifier.WaterCoefficient;
			}
			this.underWater = underWater;
		}

		public override bool PreInitChecks(StatsInstance instance, ModifierInstanceStack stack)
		{
			List<ModifierInstance> instances = instance.GetModifierInstanceStack(ModifierType.Decay).Instances;
			int i = 0;
			for (int count = instances.Count; i < count; i++)
			{
				DecayModifier decayModifier = (DecayModifier)instances[i];
				if (decayModifier != this && decayModifier.GetDecayAffectedAttributeType() == affectedAttributeType)
				{
					return false;
				}
			}
			return true;
		}

		public void SetUnderRoof(bool isUnderRoof)
		{
			this.isUnderRoof = isUnderRoof;
		}

		public void SetIsOnGround(bool isOnGround)
		{
			this.isOnGround = isOnGround;
		}

		public void SetUnderWater(bool underWater)
		{
			this.underWater = underWater;
		}

		public override List<string> GetInfo()
		{
			if (!isOnGround && currentTempCoefficient <= 0.001f && (isUnderRoof || currentWeatherCoefficient <= 0.001f))
			{
				return null;
			}
			string text = affectedAttributeType.ToString().ToLower();
			List<string> info = base.GetInfo();
			info.Add("effect_reason_time_" + text.ToLower());
			info.Add("effect_reason_attribute_" + text.ToLower());
			if (underWater && decayModifier.WaterCoefficient > 0f)
			{
				info.Add("effect_reason_water");
			}
			if (isOnGround && decayModifier.GroundCoefficient > 0f)
			{
				info.Add("effect_reason_ground");
			}
			if (currentTempCoefficient > 0f)
			{
				info.Add("effect_reason_temperature");
			}
			if (currentWeatherCoefficient > 0f && !isUnderRoof)
			{
				info.Add("effect_reason_weather");
			}
			return info;
		}

		public DecayModifierData GetUIData()
		{
			float groundCoefficient = ((isOnGround && decayModifier.GroundCoefficient > 0f) ? decayModifier.GroundCoefficient : 0f);
			float tempCoefficient = ((currentTempCoefficient > 0f) ? currentTempCoefficient : 0f);
			float weatherCoefficient = ((currentWeatherCoefficient > 0f && !isUnderRoof) ? currentWeatherCoefficient : 0f);
			float waterCoefficient = ((underWater && decayModifier.WaterCoefficient > 0f) ? decayModifier.WaterCoefficient : 0f);
			return new DecayModifierData(AffectedAttributeType, groundCoefficient, tempCoefficient, weatherCoefficient, waterCoefficient);
		}

		public override void Init(StatsInstance instance)
		{
			base.Init(instance);
			decayAttribute = instance.GetAttributeInstance(affectedAttributeType);
			base.AffectedAttributes.Add(decayAttribute);
			MonoSingleton<WeatherManager>.Instance.OnWeatherStartEvent += WeatherStartEvent;
			MonoSingleton<WeatherManager>.Instance.OnWeatherEndEvent += WeatherEndEvent;
			MonoSingleton<FixedCountTicker<DecayModifier>>.Instance.Attach(this, CheckTemperatureChange);
			MonoSingleton<GameEventSystemController>.Instance.GameEventStarted += OnGameEventStarted;
			MonoSingleton<GameEventSystemController>.Instance.GameEventEnded += OnGameEventEnded;
			WeatherEventInit();
			CheckTemperatureChange();
			GameEventsInit();
		}

		private void OnGameEventStarted(GameEventInstance eventInstance)
		{
			if (decayModifier?.WeatherModifiers != null && eventInstance != null && !(eventInstance.Blueprint == null) && decayModifier.WeatherModifiers.TryGetValue(eventInstance.Blueprint.GetID(), out var value))
			{
				currentWeatherCoefficient += value;
			}
		}

		private void OnGameEventEnded(GameEventInstance eventInstance)
		{
			if (decayModifier?.WeatherModifiers != null && eventInstance != null && !(eventInstance.Blueprint == null) && decayModifier.WeatherModifiers.TryGetValue(eventInstance.Blueprint.GetID(), out var value))
			{
				currentWeatherCoefficient -= value;
			}
		}

		private void CheckTemperatureChange()
		{
			if (map == null)
			{
				return;
			}
			float temperature = map.TemperatureManager.GetTemperature(GetOwnerPosition());
			if (Mathf.Abs(previousTemperature - temperature) >= 1f)
			{
				previousTemperature = temperature;
				int temperatureThresholdIndex = ResourcePileTemperatureManager.GetTemperatureThresholdIndex(temperature);
				if (lastThresholdIndex != temperatureThresholdIndex)
				{
					lastThresholdIndex = temperatureThresholdIndex;
					TemperatureChangeEvent(temperatureThresholdIndex);
				}
			}
		}

		public override void Apply()
		{
			float num = 0f;
			if (!underWater)
			{
				if (isOnGround)
				{
					num += baseValue;
				}
				num += currentTempCoefficient;
				if (!isUnderRoof)
				{
					num += currentWeatherCoefficient;
				}
			}
			else
			{
				num += baseValue;
			}
			decayAttribute.SetMultiplier(decayAttribute.Multiplier * num);
		}

		protected override void OnExpired()
		{
			map = null;
			if (MonoSingleton<WeatherManager>.IsInstantiated())
			{
				MonoSingleton<WeatherManager>.Instance.OnWeatherStartEvent -= WeatherStartEvent;
				MonoSingleton<WeatherManager>.Instance.OnWeatherEndEvent -= WeatherEndEvent;
			}
			if (MonoSingleton<FixedCountTicker<DecayModifier>>.IsInstantiated())
			{
				MonoSingleton<FixedCountTicker<DecayModifier>>.Instance.Detach(this);
			}
			if (MonoSingleton<GameEventSystemController>.IsInstantiated())
			{
				MonoSingleton<GameEventSystemController>.Instance.GameEventEnded -= OnGameEventEnded;
				MonoSingleton<GameEventSystemController>.Instance.GameEventStarted -= OnGameEventStarted;
			}
		}

		private Vec3Int GetOwnerPosition()
		{
			if (ownerWorldObject == null && ownerCreatureBase == null)
			{
				if (base.Owner.Owner is CreatureBase creatureBase)
				{
					ownerCreatureBase = creatureBase;
				}
				if (base.Owner.Owner is WorldObject worldObject)
				{
					ownerWorldObject = worldObject;
				}
			}
			if (ownerWorldObject != null)
			{
				return ownerWorldObject.GridDataPosition;
			}
			if (ownerCreatureBase != null)
			{
				return ownerCreatureBase.GetGridPosition();
			}
			return Vec3Int.zero;
		}

		private AttributeType GetDecayAffectedAttributeType()
		{
			return affectedAttributeType;
		}

		private void TemperatureChangeEvent(int thresholdIndex)
		{
			if (!HasExpired())
			{
				if (temperatureCoefficients == null)
				{
					currentTempCoefficient = 0f;
					return;
				}
				thresholdIndex = Mathf.Clamp(thresholdIndex, 0, temperatureCoefficients.Length);
				currentTempCoefficient = temperatureCoefficients[thresholdIndex];
				base.Owner.Update();
			}
		}

		private void GameEventsInit()
		{
			if (decayModifier == null || decayModifier.WeatherModifiers.Count == 0 || MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.RunningEvents.Count == 0)
			{
				return;
			}
			foreach (GameEventInstance runningEvent in MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.RunningEvents)
			{
				if (decayModifier.WeatherModifiers.TryGetValue(runningEvent.Blueprint.GetID(), out var value))
				{
					currentWeatherCoefficient += value;
				}
			}
		}

		private void WeatherEventInit()
		{
			if (decayModifier == null || decayModifier.WeatherModifiers.Count == 0 || MonoSingleton<WeatherManager>.Instance.GetCurrentEvent() == null || MonoSingleton<WeatherManager>.Instance.GetCurrentEvent().Events.Count == 0)
			{
				return;
			}
			currentWeatherCoefficient = 0f;
			foreach (WeatherEvent @event in MonoSingleton<WeatherManager>.Instance.GetCurrentEvent().Events)
			{
				if (decayModifier.WeatherModifiers.TryGetValue(@event.GetID(), out var value))
				{
					currentWeatherCoefficient += value;
				}
			}
		}

		private void WeatherStartEvent(WeatherEventInstance instance)
		{
			if (decayModifier?.WeatherModifiers != null && decayModifier.WeatherModifiers.Count != 0 && instance != null && !(instance.Blueprint == null) && instance.Blueprint.GetID() != null && decayModifier.WeatherModifiers.TryGetValue(instance.Blueprint.GetID(), out var value))
			{
				currentWeatherCoefficient += value;
			}
		}

		private void WeatherEndEvent(WeatherEventInstance instance)
		{
			if (decayModifier?.WeatherModifiers != null && decayModifier.WeatherModifiers.Count != 0 && instance != null && !(instance.Blueprint == null) && instance.Blueprint.GetID() != null && decayModifier.WeatherModifiers.TryGetValue(instance.Blueprint.GetID(), out var value))
			{
				currentWeatherCoefficient -= value;
			}
		}
	}
}
