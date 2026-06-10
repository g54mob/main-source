using System;
using System.Collections.Generic;
using Managers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.TimeHelpers;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("AlterWeatherPhase", "")]
	public class AlterWeatherPhase : GameEventLinearPhaseBase
	{
		[SerializeField]
		protected TimeInterval timeInterval;

		[SerializeField]
		protected float targetTemperature;

		[SerializeField]
		protected float targetTemperatureNight;

		[SerializeField]
		private uint newsMessageId;

		[SerializeField]
		private bool shouldStartFire;

		[SerializeField]
		private bool fireStarted;

		[SerializeField]
		private long startFireTimestamp;

		private const string fvs_timeInterval = "timeInterval";

		private const string fvs_targetTemperature = "targetTemperature";

		private const string fvs_targetTemperatureNight = "targetTemperatureNight";

		private const string fvs_newsMessageId = "newsMessageId";

		protected float TimeProgress => timeInterval.TimeProgress;

		protected float DurationHours => (float)timeInterval.DurationMinutes / (float)GameEventPhaseBase.MinutesInHour;

		public AlterWeatherPhase()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
		}

		public override bool OnStart()
		{
			System.Random random = new System.Random();
			shouldStartFire = base.Blueprint.StartFireChance > 0f && random.NextDouble() <= (double)base.Blueprint.StartFireChance;
			if (shouldStartFire)
			{
				WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
				long nextNoon = dateAndTime.GetNextNoon(dateAndTime.MinutesTotal);
				startFireTimestamp = nextNoon - dateAndTime.MinutesInHour + random.Next(0, dateAndTime.MinutesInHour * 2);
			}
			targetTemperature = base.Blueprint.TemperatureRange.Random(random);
			targetTemperatureNight = base.Blueprint.TemperatureRangeNight.Random(random);
			int randomDurationMinutes = base.Blueprint.GetRandomDurationMinutes();
			timeInterval = TimeInterval.FromNowMinutes(randomDurationMinutes);
			MonoSingleton<WeatherManager>.Instance.Overrides.IsActive = true;
			if (MonoSingleton<GameSpeedManager>.Instance.CurrentSpeedIndex > GameSpeedIndex.Normal)
			{
				MonoSingleton<GameSpeedManager>.Instance.SetSpeedNormal();
			}
			if (base.EventInstance.Blueprint.Dialogs != null && base.EventInstance.Blueprint.Dialogs.Count > 0)
			{
				newsMessageId = GameEventUtil.PublishNews(base.EventInstance, 0);
			}
			UpdateWarningTooltip();
			Subscribe();
			return true;
		}

		private void Subscribe()
		{
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
		}

		private void OnHourUpdate()
		{
			UpdateWarningTooltip();
		}

		private void UpdateWarningTooltip()
		{
			base.WarningTooltipPrefixLines.Clear();
			string text = MonoSingleton<LocalizationController>.Instance.GetText("event_tooltip_started");
			string text2 = MonoSingleton<LocalizationController>.Instance.GetText("event_tooltip_lasts");
			base.WarningTooltipPrefixLines.Add(text + ": " + GameEventPhaseBase.DateTime.GetLocalizedDateString());
			string text3 = ((timeInterval.HoursSinceStart != 0) ? UiUtils.GetTimeFormatByHours(timeInterval.HoursSinceStart) : ("0" + MonoSingleton<LocalizationController>.Instance.GetText("general_hour_short")));
			base.WarningTooltipPrefixLines.Add(text2 + ": " + text3);
			RefreshWarningTooltip();
		}

		public override void OnLoaded(bool fromSave)
		{
			Subscribe();
			UpdateWarningTooltip();
			if (fromSave && TimeProgress > 0f && TimeProgress < 1f && base.Blueprint.AnimationLayer != null && !base.Blueprint.AnimationLayer.Equals(string.Empty))
			{
				MonoSingleton<WeatherManager>.Instance.SetAnimationLayerWeight(base.Blueprint.AnimationLayer, CalculateAnimationLayerWeight());
			}
		}

		protected override bool TickShouldEnd()
		{
			if (shouldStartFire && startFireTimestamp > 0 && !fireStarted && GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal >= startFireTimestamp)
			{
				fireStarted = true;
				StartFireOnTheHottestPlant();
			}
			if (!base.Blueprint.AnimationLayer.Equals(string.Empty))
			{
				MonoSingleton<WeatherManager>.Instance.SetAnimationLayerWeight(base.Blueprint.AnimationLayer, CalculateAnimationLayerWeight());
			}
			float temperature = CalculateTemperatureOverride();
			MonoSingleton<WeatherManager>.Instance.Overrides.SetTemperature(temperature);
			float sunStrengthMultiplier = CalculateSunStrengthMultiplier();
			MonoSingleton<WeatherManager>.Instance.Overrides.SetSunStrengthMultiplier(sunStrengthMultiplier);
			return timeInterval.HasEnded;
		}

		private static void StartFireOnTheHottestPlant()
		{
			Dictionary<PlantMapResourceInstance, NSMedieval.Views.Resources.PlantMapResourceView>.KeyCollection keys = MonoSingleton<PlantResourceManager>.Instance.InstanceView.Keys;
			float num = 0f;
			PlantMapResourceInstance plantMapResourceInstance = null;
			foreach (PlantMapResourceInstance item in keys)
			{
				if (item != null && !item.HasDisposed && !item.IsOnFire)
				{
					float temperature = item.Map.TemperatureManager.GetTemperature(item.GetNode().Index);
					if (plantMapResourceInstance == null || temperature > num)
					{
						plantMapResourceInstance = item;
						num = temperature;
					}
				}
			}
			plantMapResourceInstance?.Map.FireSimLogic.SetFireData(plantMapResourceInstance.GetNode().Index, 0.33f);
		}

		public override void OnEnd()
		{
			Unsubscribe();
			if (base.Blueprint.AnimationLayer != null && !base.Blueprint.AnimationLayer.Equals(string.Empty))
			{
				MonoSingleton<WeatherManager>.Instance.SetAnimationLayerWeight(base.Blueprint.AnimationLayer, 0f);
			}
			MonoSingleton<WeatherManager>.Instance.Overrides.IsActive = false;
			MonoSingleton<NewsManager>.Instance.Remove(newsMessageId);
		}

		protected float CalculateTemperatureOverride()
		{
			float baseTemperatureCelsius = MonoSingleton<WeatherManager>.Instance.GetBaseTemperatureCelsius();
			if (base.Blueprint == null || base.Blueprint.TemperatureRange == null)
			{
				return baseTemperatureCelsius;
			}
			if (base.Blueprint.TemperatureRange.EqualsMinMax(GameEvent.DefaultInstance.TemperatureRange) && base.Blueprint.TemperatureRangeNight.EqualsMinMax(GameEvent.DefaultInstance.TemperatureRangeNight))
			{
				return baseTemperatureCelsius;
			}
			float num = MonoSingleton<WeatherManager>.Instance.CalculateTemperatureTransition(targetTemperature, targetTemperatureNight);
			if (base.Blueprint.TemperatureAdditive)
			{
				num += baseTemperatureCelsius;
			}
			return Mathf.Lerp(baseTemperatureCelsius, num, CalculateAnimationLayerWeight(0.3f));
		}

		protected float CalculateSunStrengthMultiplier()
		{
			return Mathf.Lerp(1f, base.Blueprint.SunStrengthMultiplier, CalculateAnimationLayerWeight(0.3f));
		}

		protected float CalculateAnimationLayerWeight(float fadeSpeed = 0.4f)
		{
			float num = (float)timeInterval.DurationMinutes / (float)GameEventPhaseBase.MinutesInHour;
			return Mathf.Clamp01(Mathf.Sin(TimeProgress * MathF.PI) * fadeSpeed * num);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("timeInterval", timeInterval);
			serializer.Write("targetTemperature", targetTemperature);
			serializer.Write("targetTemperatureNight", targetTemperatureNight);
			serializer.Write("newsMessageId", newsMessageId);
			serializer.Write("shouldStartFire", shouldStartFire);
			serializer.Write("fireStarted", fireStarted);
			serializer.Write("startFireTimestamp", startFireTimestamp);
		}

		public AlterWeatherPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			timeInterval = deserializer.ReadObject<TimeInterval>("timeInterval");
			targetTemperature = deserializer.ReadFloat("targetTemperature");
			targetTemperatureNight = deserializer.ReadFloat("targetTemperatureNight");
			newsMessageId = deserializer.ReadUInt("newsMessageId");
			shouldStartFire = deserializer.ReadBool("shouldStartFire");
			fireStarted = deserializer.ReadBool("fireStarted");
			startFireTimestamp = deserializer.ReadLong("startFireTimestamp", 0L);
		}
	}
}
