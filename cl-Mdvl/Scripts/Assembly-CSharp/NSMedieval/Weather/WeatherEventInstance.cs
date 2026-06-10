using System;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Weather
{
	[Serializable]
	[FVSerializableKey("WeatherEventInstance", "")]
	public class WeatherEventInstance : IFVSerializable
	{
		public static readonly string ClearWeatherShaderKeyword = "_GLOBAL_WEATHER_NONE";

		public static readonly string[] AllWeatherShaderKeywords = new string[2] { "_GLOBAL_WEATHER_RAIN_ON", "_GLOBAL_WEATHER_SNOW_ON" };

		[SerializeField]
		private WeatherEvent blueprint;

		[SerializeField]
		private uint start;

		[SerializeField]
		private uint end;

		[SerializeField]
		private float percent;

		[NonSerialized]
		private bool firstTick = true;

		[SerializeField]
		private string blueprintId;

		[NonSerialized]
		private float weight;

		public float Weight => weight;

		public uint StartTime => start;

		public uint EndTime => end;

		public WeatherEvent Blueprint => blueprint;

		public WeatherEventInstance(WeatherEvent blueprint, uint start, uint end)
		{
			this.start = start;
			this.end = end;
			this.blueprint = blueprint;
			blueprintId = blueprint.GetID();
			MonoSingleton<WeatherManager>.Instance.TickWeatherEvents += OnTick;
		}

		public WeatherEventInstance()
		{
		}

		public void InitAfterLoad()
		{
			ReloadBlueprint();
			MonoSingleton<WeatherManager>.Instance.TickWeatherEvents += OnTick;
			if (ShouldStart((uint)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal))
			{
				SetKeywordsOnStart();
			}
		}

		public uint GetDuration()
		{
			return end - start;
		}

		public bool IsPassed(uint time)
		{
			return time > end;
		}

		public bool ShouldStart(uint time)
		{
			return time >= start;
		}

		public void ForceEnd()
		{
			Log.Debug("Force ending event " + blueprintId, "C:\\GIT\\dev\\Assets\\Scripts\\Weather\\WeatherEventInstance.cs");
			OnEnd();
			Destroy();
		}

		public void OnTick()
		{
			uint num = (uint)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
			if (IsPassed(num) || (ShouldStart(num) && ShouldBeIgnored()))
			{
				if (!firstTick)
				{
					OnEnd();
				}
				Destroy();
			}
			else if (ShouldStart(num))
			{
				if (firstTick)
				{
					firstTick = false;
					OnStart();
				}
				MonoSingleton<WeatherManager>.Instance.SetEventRunning(this);
				float minuteFract = GlobalSaveController.CurrentVillageData.DateAndTime.MinuteFract;
				weight = GetEffectFadeValue((double)num + (double)minuteFract);
				MonoSingleton<WeatherManager>.Instance.SetAnimationLayerWeight(Blueprint.AnimationName, weight);
			}
		}

		private void ReloadBlueprint()
		{
			WeatherEvent weatherEvent = null;
			if (!string.IsNullOrEmpty(blueprintId))
			{
				weatherEvent = Repository<WeatherEventRepository, WeatherEvent>.Instance.GetByID(blueprintId);
			}
			else if (blueprint != null)
			{
				weatherEvent = Repository<WeatherEventRepository, WeatherEvent>.Instance.GetByID(blueprint.GetID());
			}
			if (weatherEvent != null)
			{
				blueprint = weatherEvent;
			}
		}

		private bool ShouldBeIgnored()
		{
			if (Blueprint.IgnoredWhenGameEventsRunning == null || Blueprint.IgnoredWhenGameEventsRunning.Count == 0)
			{
				return false;
			}
			return Blueprint.IgnoredWhenGameEventsRunning.Any((string eventId) => MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning(eventId));
		}

		public float GetTemperatureDifference(uint totalMinutes)
		{
			percent = (float)(totalMinutes - start) / (float)(end - start);
			return blueprint.TemperatureAdd * Mathf.Sin(percent * MathF.PI);
		}

		private float GetEffectFadeValue(double totalMinutes)
		{
			float num = 1f;
			percent = (float)(totalMinutes - (double)start) / (float)(end - start);
			if (blueprint.FadeInHours != -1f)
			{
				float num2 = Mathf.Min((float)GetDuration() / 2f, blueprint.FadeInHours * (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour);
				float num3 = Mathf.Clamp((float)(totalMinutes - (double)start), 0f, num2) / num2;
				num *= num3;
			}
			else if ((double)percent < 0.5)
			{
				num *= 1f - Mathf.Abs(percent - 0.5f) * 2f;
			}
			if (blueprint.FadeOutHours != -1f)
			{
				float num4 = Mathf.Min((float)GetDuration() / 2f, blueprint.FadeOutHours * (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour);
				float num5 = ((totalMinutes > (double)((float)end - num4)) ? (1f - (float)Math.Abs((double)((float)end - num4) - totalMinutes) / num4) : 1f);
				num *= num5;
			}
			else if ((double)percent > 0.5)
			{
				num *= 1f - Mathf.Abs(percent - 0.5f) * 2f;
			}
			return Mathf.Clamp01(num);
		}

		private void Destroy()
		{
			if (MonoSingleton<WeatherManager>.IsInstantiated())
			{
				MonoSingleton<WeatherManager>.Instance.TickWeatherEvents -= OnTick;
				MonoSingleton<WeatherManager>.Instance.SetAnimationLayerWeight(Blueprint.AnimationName, 0f);
				MonoSingleton<WeatherManager>.Instance.RemoveFromScheduledEvents(this);
			}
		}

		private void OnStart()
		{
			RunEffectors(run: true);
			MonoSingleton<WeatherManager>.Instance.OnStartEvent(this);
			SetKeywordsOnStart();
		}

		private void OnEnd()
		{
			RunEffectors(run: false);
			MonoSingleton<WeatherManager>.Instance.OnEndEvent(this);
			SetKeywordsOnEnd();
		}

		private void RunEffectors(bool run)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (string effector in blueprint.Effectors)
			{
				map.GlobalEffectorsManager.RunEffectorOnDomain(effector, run, GlobalEffectorDomain.All);
			}
		}

		private void SetKeywordsOnStart()
		{
			if (blueprint.EnableKeywordOnStart == null || blueprint.EnableKeywordOnStart.Count == 0)
			{
				return;
			}
			Shader.DisableKeyword(ClearWeatherShaderKeyword);
			string[] allWeatherShaderKeywords = AllWeatherShaderKeywords;
			foreach (string text in allWeatherShaderKeywords)
			{
				if (!blueprint.EnableKeywordOnStart.Contains(text))
				{
					Shader.DisableKeyword(text);
				}
			}
			foreach (string item in blueprint.EnableKeywordOnStart)
			{
				Shader.EnableKeyword(item);
			}
		}

		private void SetKeywordsOnEnd()
		{
			if (blueprint.EnableKeywordOnStart != null && blueprint.EnableKeywordOnStart.Count != 0)
			{
				string[] allWeatherShaderKeywords = AllWeatherShaderKeywords;
				for (int i = 0; i < allWeatherShaderKeywords.Length; i++)
				{
					Shader.DisableKeyword(allWeatherShaderKeywords[i]);
				}
				Shader.EnableKeyword(ClearWeatherShaderKeyword);
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprint", blueprint.GetID());
			serializer.Write("start", start);
			serializer.Write("end", end);
			serializer.Write("percent", percent);
			serializer.Write("blueprintId", blueprintId);
		}

		public WeatherEventInstance(FVDeserializer deserializer)
		{
			string id = deserializer.ReadString("blueprint");
			blueprint = Repository<WeatherEventRepository, WeatherEvent>.Instance.GetByID(id);
			start = deserializer.ReadUInt("start");
			end = deserializer.ReadUInt("end");
			percent = deserializer.ReadFloat("percent");
			blueprintId = deserializer.ReadString("blueprintId");
		}
	}
}
