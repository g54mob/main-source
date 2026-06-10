using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Map;
using NSMedieval.Model.MapNew;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Weather;
using PostEffects;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class WeatherManager : MonoSingleton<WeatherManager>
	{
		public delegate void TemperatureChange();

		public delegate void TickEvent();

		public delegate void WeatherEventDelegate(WeatherEventInstance instance);

		[SerializeField]
		private ParticleGeometryGenerator snowEffect;

		[SerializeField]
		private ParticleGeometryGenerator snowDarkEffect;

		[SerializeField]
		private ParticleGeometryGenerator snowHeavyEffect;

		[SerializeField]
		private ParticleGeometryGenerator rainEffect;

		[SerializeField]
		private ParticleGeometryGenerator heavyRainEffect;

		[SerializeField]
		private ParticleGeometryGenerator hailstormEffect;

		[SerializeField]
		private ParticleGeometryGenerator hailstormImpactEffect;

		[SerializeField]
		private ParticleGeometryGenerator fogEffect;

		[SerializeField]
		private ParticleGeometryGenerator dustCloudsEffect;

		[SerializeField]
		private ParticleGeometryGenerator dustSpecsEffect;

		[SerializeField]
		private UIView weatherDebugView;

		[SerializeField]
		private Light sunLight;

		[SerializeField]
		private ContactShadows contactShadows;

		private bool debugWeatherInfo;

		private int[] eventsPacked;

		private Dictionary<WeatherEvent, int> eventBitMask;

		private Season currentSeason;

		private readonly FastNoise randomSeedNoise = new FastNoise();

		private string clearWeatherEventText = string.Empty;

		private readonly List<string> eventNameTextKeysList = new List<string>();

		private readonly List<string> eventNamesLocalizedList = new List<string>();

		private string eventNamesLocalized = string.Empty;

		private readonly Dictionary<string, int> animationLayerByName = new Dictionary<string, int>();

		private bool startedFromSave;

		private WorldDate dateAndTime;

		private bool overrideSunAngles;

		private readonly List<WeatherEventInstance> scheduledEvents = new List<WeatherEventInstance>();

		private HashSet<string> isEventRunning = new HashSet<string>();

		[SerializeField]
		private WeatherEventsAtHour[] weatherEvents;

		[SerializeField]
		private readonly List<WeatherEventInstance> eventsRunning = new List<WeatherEventInstance>();

		private WeatherOverrides overrides = new WeatherOverrides();

		[SerializeField]
		private Animator animator;

		private bool dayEffectorsStarted;

		private bool nightEffectorsStarted;

		private bool firstUpdateDone;

		private bool isGameLoaded;

		private float soilTemperature;

		private float waterTemperature;

		public float RainEffectWeight { get; private set; }

		public float SnowEffectWeight { get; private set; }

		public float FogEffectWeight { get; private set; }

		public float CloudEffectWeight { get; private set; }

		public float SoilTemperature => soilTemperature;

		public float WaterTemperature => waterTemperature;

		public Vector3 SunAngle { get; private set; }

		public float SunIntensity { get; private set; }

		public float SunSeasonAngle { get; private set; }

		public float SunDayOrNightAngle { get; private set; }

		public long SunriseTimeMinutes { get; private set; }

		public long SunsetTimeMinutes { get; private set; }

		public bool IsDay { get; private set; }

		public bool IsDusk { get; private set; }

		public bool IsDawn { get; private set; }

		public float DayPercent { get; private set; }

		public float NightPercent { get; private set; }

		public ParticleGeometryGenerator SnowEffect => snowEffect;

		public ParticleGeometryGenerator RainEffect => rainEffect;

		public ParticleGeometryGenerator FogEffect => fogEffect;

		public ParticleGeometryGenerator HeavyRainEffect => heavyRainEffect;

		public ParticleGeometryGenerator DustCloudsEffect => dustCloudsEffect;

		public ParticleGeometryGenerator DustSpecsEffect => dustSpecsEffect;

		public ParticleGeometryGenerator HailstormImpactEffect => hailstormImpactEffect;

		public ParticleGeometryGenerator HailstormEffect => hailstormEffect;

		public ParticleGeometryGenerator SnowDarkEffect => snowDarkEffect;

		public ParticleGeometryGenerator SnowHeavyEffect => snowHeavyEffect;

		private Animator Animator => animator;

		private WorldDate DateAndTime => dateAndTime;

		public string EventNamesLocalized
		{
			get
			{
				if (eventNameTextKeysList.Count != 0)
				{
					return eventNamesLocalized;
				}
				return clearWeatherEventText;
			}
		}

		private HashSet<string> EventRunning => isEventRunning ?? (isEventRunning = new HashSet<string>());

		private int MinutesInHour => DateAndTime.MinutesInHour;

		public bool DebugWeatherInfo => debugWeatherInfo;

		public WeatherOverrides Overrides => overrides;

		public bool OverrideSunAngles => overrideSunAngles;

		public event WeatherEventDelegate OnWeatherStartEvent;

		public event WeatherEventDelegate OnWeatherEndEvent;

		public event Action WeatherEventsGeneratedEvent;

		public event Action DayStartEvent;

		public event Action NightStartEvent;

		public event Action<WeatherEventInstance> GameLoadedEvent;

		public event WeatherEventDelegate ForceStartedEvent;

		public event TickEvent TickWeatherEvents;

		public bool IsEventRunning(string eventName)
		{
			return EventRunning.Contains(eventName);
		}

		public void SetEventRunning(WeatherEventInstance eventInstance)
		{
			if (!(eventInstance?.Blueprint == null))
			{
				if (!EventRunning.Contains(eventInstance.Blueprint.GetID()))
				{
					EventRunning.Add(eventInstance.Blueprint.GetID());
				}
				if (!eventsRunning.Contains(eventInstance))
				{
					eventsRunning.Add(eventInstance);
				}
			}
		}

		public void DebugSeekSeasonTime(float percent)
		{
			uint daysTotal = DateAndTime.DaysTotal;
			Season season = DateAndTime.Season;
			uint daysTotal2 = DateAndTime.DaysTotal;
			int num = (int)daysTotal2 - (int)daysTotal2 % DateAndTime.DaysInSeason;
			float num2 = percent * (float)DateAndTime.DaysInSeason;
			int minute = (int)(num2 % 1f * (float)MinutesInHour * (float)DateAndTime.HoursInDay);
			DateAndTime.DebugSeekSeason(num + Mathf.FloorToInt(num2), minute);
			MonoSingleton<WorldTimeManager>.Instance.OnDebugSeekTime(daysTotal, season);
		}

		public void DebugSetSeasonTime(int season, float percent)
		{
			uint daysTotal = DateAndTime.DaysTotal;
			Season season2 = DateAndTime.Season;
			float f = (float)(DateAndTime.DaysInSeason * season) + percent * (float)DateAndTime.DaysInSeason;
			DateAndTime.DebugSeekSeason(Mathf.FloorToInt(f), DateAndTime.MinutesSinceDay);
			MonoSingleton<WorldTimeManager>.Instance.OnDebugSeekTime(daysTotal, season2);
		}

		public void DebugSetDayTime(float percent)
		{
			uint daysTotal = DateAndTime.DaysTotal;
			Season season = DateAndTime.Season;
			float f = percent * (float)DateAndTime.MinutesInDay;
			DateAndTime.DebugSeekSeason((int)DateAndTime.DaysTotal, Mathf.FloorToInt(f));
			MonoSingleton<WorldTimeManager>.Instance.OnDebugSeekTime(daysTotal, season);
		}

		public void DebugToggleWeatherInfo()
		{
			debugWeatherInfo = !debugWeatherInfo;
		}

		public void OnStartEvent(WeatherEventInstance eventInstance)
		{
			if (!eventNameTextKeysList.Contains(eventInstance.Blueprint.TextKey))
			{
				eventNameTextKeysList.Add(eventInstance.Blueprint.TextKey);
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText(eventInstance.Blueprint.TextKey);
			if (!eventNamesLocalizedList.Contains(text))
			{
				eventNamesLocalizedList.Add(text);
			}
			eventNamesLocalized = string.Join(", ", eventNamesLocalizedList);
			this.OnWeatherStartEvent?.Invoke(eventInstance);
		}

		public void OnEndEvent(WeatherEventInstance eventInstance)
		{
			if (!MonoSingleton<WeatherManager>.IsApplicationIsQuitting() && eventInstance != null && !(eventInstance.Blueprint == null))
			{
				int num = eventNameTextKeysList.LastIndexOf(eventInstance.Blueprint.TextKey);
				if (num != -1)
				{
					eventNameTextKeysList.RemoveAt(num);
					eventNamesLocalizedList.RemoveAt(num);
				}
				eventNamesLocalized = string.Join(", ", eventNamesLocalizedList);
				this.OnWeatherEndEvent?.Invoke(eventInstance);
			}
		}

		public void ToggleDebugView()
		{
			weatherDebugView.gameObject.SetActive(!weatherDebugView.gameObject.activeSelf);
		}

		public bool IsDebugViewEnabled()
		{
			if (!weatherDebugView || weatherDebugView == null)
			{
				return false;
			}
			return weatherDebugView.gameObject.activeSelf;
		}

		public WeatherEventsAtHour GetCurrentEvent()
		{
			if (weatherEvents == null)
			{
				return null;
			}
			int num = (DateAndTime.Day - 1) * DateAndTime.HoursInDay + DateAndTime.HoursSinceDay;
			return weatherEvents[num];
		}

		public WeatherEventsAtHour GetEventInSeason(int seasonHour)
		{
			if (seasonHour < 0 || seasonHour >= weatherEvents.Length)
			{
				return null;
			}
			return weatherEvents[seasonHour];
		}

		public void SetAnimationLayerWeight(string animationName, float layerWeight)
		{
			if (!(Animator == null))
			{
				if (!animationLayerByName.ContainsKey(animationName))
				{
					animationLayerByName.Add(animationName, Animator.GetLayerIndex(animationName));
				}
				else if (animationLayerByName[animationName] == -1)
				{
					animationLayerByName[animationName] = Animator.GetLayerIndex(animationName);
				}
				int num = animationLayerByName[animationName];
				if (num != -1)
				{
					Animator.SetLayerWeight(num, layerWeight);
				}
				else
				{
					Log.Error("Animation layer not found: " + animationName, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WeatherManager.cs");
				}
			}
		}

		public void GenerateWeatherEventsGraph(ref Texture2D texture)
		{
			int hoursInSeason = DateAndTime.HoursInSeason;
			int num = Repository<WeatherEventRepository, WeatherEvent>.Instance.GetCount() + 1;
			if (texture == null || texture.width != hoursInSeason || texture.height != num)
			{
				texture = new Texture2D(hoursInSeason, num);
			}
			FastNoise fastNoise = new FastNoise();
			fastNoise.SetFrequency(25f);
			for (int i = 0; i < hoursInSeason; i++)
			{
				WeatherEventsAtHour weatherEventsAtHour = weatherEvents[i];
				int num2 = i / DateAndTime.HoursInDay;
				for (int j = 0; j < num; j++)
				{
					WeatherEvent item = ((j >= 1) ? Repository<WeatherEventRepository, WeatherEvent>.Instance.GetAt(j - 1) : null);
					Color color = Color.black;
					if (j == 0)
					{
						if (weatherEventsAtHour.Temperature < 0f)
						{
							float num3 = Mathf.Clamp01(Mathf.Abs(weatherEventsAtHour.Temperature) / 20f);
							color = Color.cyan * num3;
						}
						else
						{
							float v = Mathf.Clamp01(weatherEventsAtHour.Temperature / 35f);
							color = Color.HSVToRGB(0.15f, 0.75f, v);
						}
					}
					else if (weatherEventsAtHour.Events.Count > 0 && weatherEventsAtHour.Events.Contains(item))
					{
						color.r = Mathf.Abs(Mathf.Clamp(fastNoise.GetNoise(j, 0f, 0f) * 0.5f + 0.5f, 0f, 1f));
						color.g = Mathf.Abs(Mathf.Clamp(fastNoise.GetNoise(0f, j, 0f) * 0.5f + 0.5f, 0f, 1f));
						color.b = Mathf.Abs(Mathf.Clamp(fastNoise.GetNoise(0f, 0f, j) * 0.5f + 0.5f, 0f, 1f));
					}
					color.a = 0.95f;
					if (num2 % 2 == 0)
					{
						color = Color.Lerp(color, Color.cyan, 0.2f);
					}
					texture.SetPixel(i, j, color);
				}
			}
			texture.filterMode = FilterMode.Point;
			texture.Apply();
		}

		public void RemoveFromScheduledEvents(WeatherEventInstance we)
		{
			scheduledEvents.Remove(we);
		}

		public void OnTimeUpdate()
		{
			if (DateAndTime != null)
			{
				CheckApplySeasonChange();
				CalculateSeasonTemperatures(DateAndTime.MinutesTotalWithSeasonOffset, out soilTemperature, out waterTemperature);
				TemperatureUpdate();
			}
		}

		public void DebugForceWeatherEvent(string id)
		{
			long minutesTotal = DateAndTime.MinutesTotal;
			int num = DateAndTime.MinutesInHour * 5;
			ForceStartEvent(id, minutesTotal, num, removeScheduledParallelEvents: true);
		}

		public void SetOverrideSunAngles(float sunAngleX, float sunAngleY, float sunAngleZ, bool overrideSunAngles)
		{
			if (overrideSunAngles)
			{
				Quaternion quaternion = Quaternion.Euler(90f - sunAngleX, 0f, 0f);
				Quaternion quaternion2 = Quaternion.Euler(0f, 90f, 0f);
				Quaternion quaternion3 = Quaternion.Euler(sunAngleZ, 0f, 0f);
				Vector3 eulerAngles = (quaternion * quaternion2 * quaternion3).eulerAngles;
				SunAngle = eulerAngles;
			}
		}

		public void ForceStartEvent(string eventId, long startMinutes, long duration, bool removeScheduledParallelEvents)
		{
			WeatherEvent byID = Repository<WeatherEventRepository, WeatherEvent>.Instance.GetByID(eventId);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (byID == null)
			{
				messageBuilder = new FVLogDebugInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WeatherManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ForceStartEvent: event ");
					messageBuilder.AppendFormatted(eventId);
					messageBuilder.AppendLiteral(" does not exist.");
				}
				Log.Debug(messageBuilder);
				return;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WeatherManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Force starting event ");
				messageBuilder.AppendFormatted(eventId);
			}
			Log.Debug(messageBuilder);
			long endMinutes = DateAndTime.ClampMinutesInSeason(startMinutes + duration);
			WeatherEventInstance weatherEventInstance = new WeatherEventInstance(byID, (uint)startMinutes, (uint)endMinutes);
			scheduledEvents.Add(weatherEventInstance);
			uint num = DateAndTime.MinutesToSeasonHours(weatherEventInstance.StartTime);
			uint num2 = DateAndTime.MinutesToSeasonHours(weatherEventInstance.EndTime);
			for (uint num3 = num; num3 <= num2; num3++)
			{
				if (removeScheduledParallelEvents)
				{
					weatherEvents[num3].Events.Clear();
					eventsPacked[num3] = 0;
				}
				weatherEvents[num3].Events.Add(weatherEventInstance.Blueprint);
				eventsPacked[num3] |= eventBitMask[weatherEventInstance.Blueprint];
			}
			if (removeScheduledParallelEvents)
			{
				WeatherEventInstance[] array = scheduledEvents.Where((WeatherEventInstance e) => (e.StartTime >= startMinutes && e.StartTime <= endMinutes) || (e.EndTime >= startMinutes && e.EndTime <= endMinutes)).ToArray();
				foreach (WeatherEventInstance weatherEventInstance2 in array)
				{
					if (weatherEventInstance2 != weatherEventInstance)
					{
						weatherEventInstance2.ForceEnd();
					}
				}
			}
			this.ForceStartedEvent?.Invoke(weatherEventInstance);
		}

		public Vector3 GetSunDirection()
		{
			return Quaternion.Euler(SunAngle) * Vector3.forward;
		}

		private void OnHourUpdate()
		{
			if (!MonoSingleton<WeatherManager>.IsApplicationIsQuitting() && MonoSingleton<WeatherManager>.IsInstantiated())
			{
				TickDayNightEffectors();
			}
		}

		private void TickDayNightEffectors()
		{
			List<string> list = ListPool<string>.Get();
			List<string> list2 = ListPool<string>.Get();
			bool num = !dayEffectorsStarted && IsDay && DayPercent < DateAndTime.DayEffectorsEnd;
			bool flag = !nightEffectorsStarted && !IsDay && NightPercent < DateAndTime.NightEffectorsEnd;
			if (num)
			{
				dayEffectorsStarted = true;
				list.AddRange(DateAndTime.DayEffectors);
			}
			if (flag)
			{
				nightEffectorsStarted = true;
				list.AddRange(DateAndTime.NightEffectors);
			}
			bool num2 = dayEffectorsStarted && (!IsDay || (IsDay && DayPercent >= DateAndTime.DayEffectorsEnd));
			bool flag2 = nightEffectorsStarted && (IsDay || (!IsDay && NightPercent >= DateAndTime.NightEffectorsEnd));
			if (num2)
			{
				dayEffectorsStarted = false;
				list2.AddRange(DateAndTime.DayEffectors);
			}
			if (flag2)
			{
				nightEffectorsStarted = false;
				list2.AddRange(DateAndTime.NightEffectors);
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (string item in list)
			{
				map.GlobalEffectorsManager.RunEffectorOnDomain(item, runEffector: true, GlobalEffectorDomain.All);
			}
			foreach (string item2 in list2)
			{
				map.GlobalEffectorsManager.RunEffectorOnDomain(item2, runEffector: false, GlobalEffectorDomain.All);
			}
			ListPool<string>.Return(list);
			ListPool<string>.Return(list2);
		}

		public void OnGameSaving()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				return;
			}
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			if (currentVillageData == null)
			{
				return;
			}
			currentVillageData.WeatherOverrides = overrides;
			currentVillageData.ScheduledWeatherEvents = scheduledEvents;
			if (weatherEvents == null)
			{
				return;
			}
			Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();
			for (int i = 0; i < weatherEvents.Length; i++)
			{
				foreach (WeatherEvent @event in weatherEvents[i].Events)
				{
					if (!dictionary.ContainsKey(@event.GetID()))
					{
						dictionary.Add(@event.GetID(), new List<int>());
					}
					dictionary[@event.GetID()].Add(i);
				}
			}
			currentVillageData.WeatherEventsHourly = dictionary;
			float[] array = new float[weatherEvents.Length];
			for (int j = 0; j < weatherEvents.Length; j++)
			{
				array[j] = weatherEvents[j].Temperature;
			}
			currentVillageData.TemperatureHourly = array;
		}

		private void GenerateTemperatures()
		{
			GlobalSaveController.CurrentVillageData.TemperatureFirstInitDone = true;
			float a = 0f;
			float a2 = 0f;
			float b = 0f;
			float b2 = 0f;
			int num = 0;
			for (int i = 0; i < weatherEvents.Length; i++)
			{
				if (i % DateAndTime.HoursInDay == 0)
				{
					Season seasonForDay = GetSeasonForDay(num);
					Season seasonForDay2 = GetSeasonForDay(num + 1);
					int num2 = seasonForDay.GetHashCode() + (int)DateAndTime.Year;
					int num3 = seasonForDay2.GetHashCode() + (int)DateAndTime.Year;
					int num4 = num % DateAndTime.DaysInSeason;
					int num5 = (num + 1) % DateAndTime.DaysInSeason;
					GetMinMaxTemp(seasonForDay, num, out var minDay, out var maxDay, out var minNight, out var maxNight);
					a = RandomWithSeed(num4 * 2 + num2) * (maxDay - minDay) + minDay;
					a2 = RandomWithSeed(num4 * 2 + 1 + num2) * (maxNight - minNight) + minNight;
					GetMinMaxTemp(seasonForDay2, num5, out minDay, out maxDay, out minNight, out maxNight);
					b = RandomWithSeed(num5 * 2 + num3) * (maxDay - minDay) + minDay;
					b2 = RandomWithSeed(num5 * 2 + 1 + num3) * (maxNight - minNight) + minNight;
					num++;
				}
				float t = (float)(i % DateAndTime.HoursInDay) / (float)(DateAndTime.HoursInDay - 1);
				float dayTemperature = Mathf.Lerp(a, b, t);
				float nightTemperature = Mathf.Lerp(a2, b2, t);
				int num6 = i % DateAndTime.HoursInDay;
				float temperature = CalculateTemperatureTransition(dayTemperature, nightTemperature, num6);
				weatherEvents[i].SetTemperature(temperature);
			}
		}

		public float CalculateTemperatureTransition(float dayTemperature, float nightTemperature, float hoursSinceDay = -1f)
		{
			float num = ((hoursSinceDay >= 0f) ? hoursSinceDay : ((float)DateAndTime.HoursSinceDay)) / (float)(DateAndTime.HoursInDay - 1);
			float t = Mathf.Sin((1f - Mathf.Abs(num - 0.5f) * 2f - 0.5f) * MathF.PI) * 0.5f + 0.5f;
			return Mathf.Lerp(nightTemperature, dayTemperature, t);
		}

		public float GetSunIntensityClamped(float clampAngle)
		{
			return CalculateSunIntensity(clampAngle);
		}

		private void TemperatureUpdate()
		{
			if (!GlobalSaveController.CurrentVillageData.DateAndTime.IsOverrideTemperature)
			{
				float baseTemperatureCelsius = GetBaseTemperatureCelsius();
				DateAndTime.TemperatureCelsius = overrides.GetTemperature(baseTemperatureCelsius);
			}
		}

		public float GetBaseTemperatureCelsius()
		{
			int num = (DateAndTime.Day - 1) * DateAndTime.HoursInDay + DateAndTime.HoursSinceDay;
			return weatherEvents[num % weatherEvents.Length].Temperature + GetTemperatureDifferenceFromEventInstance();
		}

		public float GetBaseRainEffectWeight()
		{
			float result = 0f;
			foreach (WeatherEventInstance item in eventsRunning)
			{
				if (item.Blueprint.EventType == WeatherEvent.Type.Rain)
				{
					result = item.Weight;
				}
			}
			return result;
		}

		protected override void OnDestroy()
		{
			this.DayStartEvent = null;
			this.GameLoadedEvent = null;
			this.NightStartEvent = null;
			this.OnWeatherEndEvent = null;
			this.OnWeatherStartEvent = null;
			this.TickWeatherEvents = null;
			this.WeatherEventsGeneratedEvent = null;
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnSceneTick;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
			ResetShaderKeywords();
			base.OnDestroy();
		}

		private void ResetShaderKeywords()
		{
			string[] allWeatherShaderKeywords = WeatherEventInstance.AllWeatherShaderKeywords;
			for (int i = 0; i < allWeatherShaderKeywords.Length; i++)
			{
				Shader.DisableKeyword(allWeatherShaderKeywords[i]);
			}
			Shader.EnableKeyword(WeatherEventInstance.ClearWeatherShaderKeyword);
		}

		private void OnGameLoaded(bool fromSave)
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			isGameLoaded = true;
			startedFromSave = fromSave;
			CheckWeatherEventsInit();
			CreateEventsBitmask();
			if (fromSave)
			{
				currentSeason = DateAndTime.Season;
				overrides = GlobalSaveController.CurrentVillageData.WeatherOverrides;
				if (overrides == null)
				{
					overrides = new WeatherOverrides();
				}
				LoadWeatherEventsFromSave();
				foreach (WeatherEventInstance scheduledWeatherEvent in GlobalSaveController.CurrentVillageData.ScheduledWeatherEvents)
				{
					uint num = DateAndTime.MinutesToSeasonHours(scheduledWeatherEvent.StartTime);
					uint num2 = DateAndTime.MinutesToSeasonHours(scheduledWeatherEvent.EndTime);
					for (uint num3 = num; num3 <= num2; num3++)
					{
						weatherEvents[num3].Events.Clear();
						weatherEvents[num3].Events.Add(scheduledWeatherEvent.Blueprint);
						eventsPacked[num3] |= eventBitMask[scheduledWeatherEvent.Blueprint];
					}
				}
				eventNamesLocalized = string.Join(", ", eventNamesLocalizedList);
			}
			MonoSingleton<SceneController>.Instance.Tick += OnSceneTick;
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			clearWeatherEventText = MonoSingleton<LocalizationController>.Instance.GetText("weather_clear");
			OnTimeUpdate();
			OnHourUpdate();
			startedFromSave = false;
		}

		private void OnSceneTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("WeatherManager.Tick"))
			{
				EventRunning.Clear();
				eventsRunning.Clear();
				this.TickWeatherEvents?.Invoke();
			}
		}

		private void Start()
		{
			dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
			ResetShaderKeywords();
		}

		private void Update()
		{
			if (!isGameLoaded || Time.deltaTime < 0.001f)
			{
				return;
			}
			RainEffectWeight = 0f;
			SnowEffectWeight = 0f;
			FogEffectWeight = 0f;
			CloudEffectWeight = 0f;
			foreach (WeatherEventInstance item in eventsRunning)
			{
				if (item.Blueprint.EventType == WeatherEvent.Type.Rain)
				{
					RainEffectWeight = item.Weight;
				}
				else if (item.Blueprint.EventType == WeatherEvent.Type.Snow)
				{
					SnowEffectWeight = item.Weight;
				}
				else if (item.Blueprint.EventType == WeatherEvent.Type.Fog)
				{
					FogEffectWeight = item.Weight;
				}
				else if (item.Blueprint.EventType == WeatherEvent.Type.Cloud)
				{
					CloudEffectWeight = item.Weight;
				}
			}
			RainEffectWeight = Overrides.GetRainEffectWeight(RainEffectWeight);
			CloudEffectWeight = Mathf.Max(CloudEffectWeight * 0.4f, RainEffectWeight * 0.6f, SnowEffectWeight, FogEffectWeight * 0.2f);
			uint num = dateAndTime.DaysTotal + (uint)dateAndTime.StartSeasonOffset;
			long currentMinutes = DateAndTime.MinutesTotalWithSeasonOffset;
			long day = num;
			CalculateSunriseSunsetAbsolute(in day, out var sunriseMinute, out var sunsetMinute, out var sunAngle);
			SunriseTimeMinutes = sunriseMinute;
			SunsetTimeMinutes = sunsetMinute;
			float num2 = Mathf.Clamp01(((float)(currentMinutes - sunriseMinute) + DateAndTime.MinuteFract) / (float)(sunsetMinute - sunriseMinute));
			float nightPercent = 0f;
			if (num2 >= 1f || num2 <= 0f)
			{
				long sunriseMinute2;
				float sunAngle2;
				if (currentMinutes > sunriseMinute)
				{
					CalculateSunriseSunsetAbsolute((long)(num + 1), out sunriseMinute2, out day, out sunAngle2);
				}
				else
				{
					sunriseMinute2 = sunriseMinute;
					CalculateSunriseSunsetAbsolute((long)(num - 1), out sunriseMinute, out sunsetMinute, out sunAngle2);
				}
				nightPercent = ((float)(currentMinutes - sunsetMinute) + DateAndTime.MinuteFract) / (float)(sunriseMinute2 - sunsetMinute);
			}
			bool isDay = IsDay;
			IsDay = num2 > 0f && num2 < 1f;
			DayPercent = num2;
			NightPercent = nightPercent;
			IsDusk = IsDay && DayPercent > DateAndTime.DayEffectorsEnd;
			IsDawn = !IsDay && NightPercent > DateAndTime.NightEffectorsEnd;
			float num3 = Mathf.Sin(NightPercent * MathF.PI);
			if (num3 > 0f)
			{
				float moonAngle = GetMoonAngle(in currentMinutes, DateAndTime.MinuteFract);
				SunSeasonAngle = Mathf.Lerp(sunAngle, moonAngle, num3);
			}
			else
			{
				SunSeasonAngle = sunAngle;
			}
			float num4;
			float num5;
			if (IsDay)
			{
				num4 = 17f;
				num5 = DayPercent;
			}
			else
			{
				num4 = 40f;
				num5 = 1f - NightPercent;
			}
			SunDayOrNightAngle = num4 + num5 * (180f - num4 * 2f);
			Quaternion quaternion = Quaternion.Euler(90f - SunSeasonAngle, 0f, 0f);
			Quaternion quaternion2 = Quaternion.Euler(0f, 90f, 0f);
			Quaternion quaternion3 = Quaternion.Euler(SunDayOrNightAngle, 0f, 0f);
			Vector3 eulerAngles = (quaternion * quaternion2 * quaternion3).eulerAngles;
			if (!overrideSunAngles)
			{
				SunAngle = eulerAngles;
			}
			SunIntensity = CalculateSunIntensity(30f);
			if (!firstUpdateDone)
			{
				CalculateSeasonTemperatures(DateAndTime.MinutesTotalWithSeasonOffset, out soilTemperature, out waterTemperature);
			}
			if (!firstUpdateDone || isDay != IsDay)
			{
				if (IsDay)
				{
					this.DayStartEvent?.Invoke();
				}
				else
				{
					this.NightStartEvent?.Invoke();
				}
			}
			if (sunLight != null)
			{
				float num6 = 15f;
				float num7 = 90f;
				float t = (Mathf.Clamp((SunDayOrNightAngle < num7) ? SunDayOrNightAngle : (num7 - (SunDayOrNightAngle - num7)), num6, num7) - num6) / (num7 - num6);
				sunLight.shadowBias = Mathf.Lerp(0.9f, 0.3f, t);
				contactShadows.RejectionDepth = Mathf.Lerp(0.3f, 0.1f, t);
			}
			firstUpdateDone = true;
		}

		public void CalculateSunriseSunsetAbsolute(in long day, out long sunriseMinute, out long sunsetMinute, out float sunAngle)
		{
			int index = Mathf.FloorToInt((float)day / (float)DateAndTime.DaysInSeason) % DateAndTime.SeasonsCount;
			CalculateSunriseSunset(DateAndTime.Seasons[index], (float)(day % DateAndTime.DaysInSeason) / (float)DateAndTime.DaysInSeason, out var sunriseHour, out var sunsetHour, out sunAngle);
			sunsetMinute = day * dateAndTime.MinutesInDay + (long)(sunsetHour * (float)DateAndTime.MinutesInHour);
			sunriseMinute = day * dateAndTime.MinutesInDay + (long)(sunriseHour * (float)DateAndTime.MinutesInHour);
		}

		public void CalculateSunriseSunset(in Season currentSeason, in float currentSeasonPercent, out float sunriseHour, out float sunsetHour, out float sunAngle)
		{
			Season season = DateAndTime.PrevSeason(currentSeason);
			Season season2 = DateAndTime.NextSeason(currentSeason);
			float num = currentSeasonPercent;
			NSMedieval.Model.MapNew.Map mapBlueprint = GlobalSaveController.CurrentVillageData.MapBlueprint;
			float sunAngleFromBlueprint = GetSunAngleFromBlueprint(mapBlueprint, currentSeason);
			if (num < 0.5f)
			{
				float sunAngleFromBlueprint2 = GetSunAngleFromBlueprint(mapBlueprint, season);
				float t = Mathf.Clamp01(0.5f + num);
				sunriseHour = Mathf.Lerp(season.SunriseHour, currentSeason.SunriseHour, t);
				sunsetHour = Mathf.Lerp(season.SunsetHour, currentSeason.SunsetHour, t);
				sunAngle = Mathf.Lerp(sunAngleFromBlueprint2, sunAngleFromBlueprint, t);
			}
			else
			{
				float sunAngleFromBlueprint3 = GetSunAngleFromBlueprint(mapBlueprint, season2);
				float t2 = Mathf.Clamp01(num - 0.5f);
				sunriseHour = Mathf.Lerp(currentSeason.SunriseHour, season2.SunriseHour, t2);
				sunsetHour = Mathf.Lerp(currentSeason.SunsetHour, season2.SunsetHour, t2);
				sunAngle = Mathf.Lerp(sunAngleFromBlueprint, sunAngleFromBlueprint3, t2);
			}
		}

		public float CalculateGrassGrowSpeed(in Season currentSeason, in float currentSeasonPercent)
		{
			Season season = DateAndTime.PrevSeason(currentSeason);
			Season season2 = DateAndTime.NextSeason(currentSeason);
			if (currentSeasonPercent < 0.5f)
			{
				return Mathf.Lerp(season.GrassGrowSpeed, currentSeason.GrassGrowSpeed, Mathf.Clamp01(0.5f + currentSeasonPercent));
			}
			return Mathf.Lerp(currentSeason.GrassGrowSpeed, season2.GrassGrowSpeed, Mathf.Clamp01(currentSeasonPercent - 0.5f));
		}

		public void CalculateSeasonTemperatures(in long currentMinutes, out float soilTemperature, out float waterTemperature)
		{
			NSMedieval.Model.MapNew.Map mapBlueprint = GlobalSaveController.CurrentVillageData.MapBlueprint;
			Season seasonForMinutes = DateAndTime.GetSeasonForMinutes(in currentMinutes);
			float num = (float)(currentMinutes % DateAndTime.MinutesInSeason) / (float)DateAndTime.MinutesInSeason;
			GetSeasonTemperaturesFromBlueprint(mapBlueprint, seasonForMinutes, out var num2, out var num3);
			if (num < 0.5f)
			{
				Season season = DateAndTime.PrevSeason(seasonForMinutes);
				GetSeasonTemperaturesFromBlueprint(mapBlueprint, season, out var a, out var a2);
				float t = Mathf.Clamp01(0.5f + num);
				soilTemperature = Mathf.Lerp(a, num2, t);
				waterTemperature = Mathf.Lerp(a2, num3, t);
			}
			else
			{
				Season season2 = DateAndTime.NextSeason(seasonForMinutes);
				GetSeasonTemperaturesFromBlueprint(mapBlueprint, season2, out var b, out var b2);
				float t2 = Mathf.Clamp01(num - 0.5f);
				soilTemperature = Mathf.Lerp(num2, b, t2);
				waterTemperature = Mathf.Lerp(num3, b2, t2);
			}
		}

		public float GetMoonAngle(in long currentMinutes, in float minutesFract)
		{
			Season seasonForMinutes = DateAndTime.GetSeasonForMinutes(in currentMinutes);
			float num = ((float)(currentMinutes % DateAndTime.MinutesInSeason) + minutesFract) / (float)DateAndTime.MinutesInSeason;
			Season season = DateAndTime.PrevSeason(seasonForMinutes);
			Season season2 = DateAndTime.NextSeason(seasonForMinutes);
			NSMedieval.Model.MapNew.Map mapBlueprint = GlobalSaveController.CurrentVillageData.MapBlueprint;
			float moonAngleFromBlueprint = GetMoonAngleFromBlueprint(mapBlueprint, seasonForMinutes);
			if (num < 0.5f)
			{
				float moonAngleFromBlueprint2 = GetMoonAngleFromBlueprint(mapBlueprint, season);
				float t = Mathf.Clamp01(0.5f + num);
				return Mathf.Lerp(moonAngleFromBlueprint2, moonAngleFromBlueprint, t);
			}
			float moonAngleFromBlueprint3 = GetMoonAngleFromBlueprint(mapBlueprint, season2);
			float t2 = Mathf.Clamp01(num - 0.5f);
			return Mathf.Lerp(moonAngleFromBlueprint, moonAngleFromBlueprint3, t2);
		}

		private float GetSunAngleFromBlueprint(NSMedieval.Model.MapNew.Map mapTypeBlueprint, Season currentSeason)
		{
			Season season = mapTypeBlueprint?.GetSeasonOverride(currentSeason);
			if (season == null)
			{
				season = currentSeason;
			}
			if (season.SunAngle == 0f)
			{
				return currentSeason.SunAngle;
			}
			return season.SunAngle;
		}

		private float GetMoonAngleFromBlueprint(NSMedieval.Model.MapNew.Map mapTypeBlueprint, Season currentSeason)
		{
			Season season = mapTypeBlueprint?.GetSeasonOverride(currentSeason);
			if (season == null)
			{
				season = currentSeason;
			}
			if (season.MoonAngle == 0f)
			{
				return currentSeason.MoonAngle;
			}
			return season.MoonAngle;
		}

		private static void GetSeasonTemperaturesFromBlueprint(NSMedieval.Model.MapNew.Map mapTypeBlueprint, Season currentSeason, out float soilTemperature, out float waterTemperature)
		{
			Season season = mapTypeBlueprint?.GetSeasonOverride(currentSeason) ?? currentSeason;
			soilTemperature = season.SoilTemperature;
			waterTemperature = season.WaterTemperature;
		}

		private float GetTemperatureDifferenceFromEventInstance()
		{
			float num = 0f;
			uint num2 = (uint)dateAndTime.MinutesTotal;
			foreach (WeatherEventInstance scheduledEvent in scheduledEvents)
			{
				if (scheduledEvent.ShouldStart(num2) && !scheduledEvent.IsPassed(num2))
				{
					num += scheduledEvent.GetTemperatureDifference(num2);
				}
			}
			return num;
		}

		private float CalculateSunIntensity(float clampAngle)
		{
			float num = 1f / Mathf.Sin(MathF.PI / 180f * clampAngle);
			return Mathf.Clamp01(Mathf.Abs(GetSunDirection().y * num)) * (IsDay ? 1f : 0f) * (1f - CloudEffectWeight) * overrides.GetSunStrengthMultiplier();
		}

		private Season GetSeasonForDay(int day)
		{
			if (day >= DateAndTime.DaysInSeason)
			{
				return DateAndTime.NextSeason(currentSeason);
			}
			return currentSeason;
		}

		private void CreateEventsBitmask()
		{
			eventBitMask = new Dictionary<WeatherEvent, int>();
			int num = 0;
			foreach (WeatherEvent allItem in Repository<WeatherEventRepository, WeatherEvent>.Instance.GetAllItems())
			{
				int value = 1 << num;
				eventBitMask.Add(allItem, value);
				num++;
			}
		}

		private float RandomWithSeed(int seed)
		{
			return Mathf.Abs(randomSeedNoise.GetNoise(seed, 0f) * 5f) % 1f;
		}

		private void GetMinMaxTemp(Season season, int day, out float minDay, out float maxDay, out float minNight, out float maxNight)
		{
			float num = Mathf.Clamp01((float)day / (float)DateAndTime.DaysInSeason);
			if (num >= 1f)
			{
				num -= 1f;
				season = DateAndTime.NextSeason(season);
			}
			Season season2 = DateAndTime.PrevSeason(season);
			Season season3 = DateAndTime.NextSeason(season);
			NSMedieval.Model.MapNew.Map mapBlueprint = GlobalSaveController.CurrentVillageData.MapBlueprint;
			FloatRange dayTemperatureRange = GetDayTemperatureRange(mapBlueprint, season);
			FloatRange nightTemperatureRange = GetNightTemperatureRange(mapBlueprint, season);
			if (num < 0.5f)
			{
				FloatRange dayTemperatureRange2 = GetDayTemperatureRange(mapBlueprint, season2);
				FloatRange nightTemperatureRange2 = GetNightTemperatureRange(mapBlueprint, season2);
				float t = Mathf.Clamp01(0.5f + num);
				minDay = Mathf.Lerp(dayTemperatureRange2.Min, dayTemperatureRange.Min, t);
				maxDay = Mathf.Lerp(dayTemperatureRange2.Max, dayTemperatureRange.Max, t);
				minNight = Mathf.Lerp(nightTemperatureRange2.Min, nightTemperatureRange.Min, t);
				maxNight = Mathf.Lerp(nightTemperatureRange2.Max, nightTemperatureRange.Max, t);
			}
			else
			{
				FloatRange dayTemperatureRange3 = GetDayTemperatureRange(mapBlueprint, season3);
				FloatRange nightTemperatureRange3 = GetNightTemperatureRange(mapBlueprint, season3);
				float t2 = Mathf.Clamp01(num - 0.5f);
				minDay = Mathf.Lerp(dayTemperatureRange.Min, dayTemperatureRange3.Min, t2);
				maxDay = Mathf.Lerp(dayTemperatureRange.Max, dayTemperatureRange3.Max, t2);
				minNight = Mathf.Lerp(nightTemperatureRange.Min, nightTemperatureRange3.Min, t2);
				maxNight = Mathf.Lerp(nightTemperatureRange.Max, nightTemperatureRange3.Max, t2);
			}
		}

		private FloatRange GetDayTemperatureRange(NSMedieval.Model.MapNew.Map mapTypeBlueprint, Season currentSeason)
		{
			Season season = mapTypeBlueprint?.GetSeasonOverride(currentSeason);
			if (season == null)
			{
				season = currentSeason;
			}
			return season.DayTemperatureRange;
		}

		private FloatRange GetNightTemperatureRange(NSMedieval.Model.MapNew.Map mapTypeBlueprint, Season currentSeason)
		{
			Season season = mapTypeBlueprint?.GetSeasonOverride(currentSeason);
			if (season == null)
			{
				season = currentSeason;
			}
			return season.NightTemperatureRange;
		}

		private void CheckApplySeasonChange()
		{
			Season season = DateAndTime.Season;
			if (currentSeason == null || currentSeason.Name == null || string.Compare(currentSeason.Name, season.Name, StringComparison.Ordinal) != 0)
			{
				currentSeason = season;
				if (!startedFromSave)
				{
					GenerateTemperatures();
					AddEventsForSeason(season);
				}
				this.WeatherEventsGeneratedEvent?.Invoke();
			}
		}

		private void LoadWeatherEventsFromSave()
		{
			bool flag = !GlobalSaveController.CurrentVillageData.TemperatureFirstInitDone;
			if (flag)
			{
				GenerateTemperatures();
			}
			float[] temperatureHourly = GlobalSaveController.CurrentVillageData.TemperatureHourly;
			for (int i = 0; i < weatherEvents.Length; i++)
			{
				eventsPacked[i] = 0;
				weatherEvents[i].Events.Clear();
				if (!flag)
				{
					weatherEvents[i].SetTemperature(temperatureHourly[Math.Min(i, temperatureHourly.Length - 1)]);
				}
			}
			foreach (KeyValuePair<string, List<int>> item in GlobalSaveController.CurrentVillageData.WeatherEventsHourly)
			{
				foreach (int item2 in item.Value)
				{
					if (item2 >= weatherEvents.Length)
					{
						continue;
					}
					WeatherEvent byID = Repository<WeatherEventRepository, WeatherEvent>.Instance.GetByID(item.Key);
					if (!weatherEvents[item2].TryAddEvent(byID))
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WeatherManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Cannot add weather event ");
							messageBuilder.AppendFormatted(item.Key);
							messageBuilder.AppendLiteral(" after load.");
						}
						Log.Warning(messageBuilder);
					}
					else
					{
						int num = eventBitMask[byID];
						eventsPacked[item2] |= num;
					}
				}
			}
			scheduledEvents.Clear();
			scheduledEvents.AddRange(GlobalSaveController.CurrentVillageData.ScheduledWeatherEvents);
			eventNameTextKeysList.Clear();
			eventNamesLocalizedList.Clear();
			uint time = (uint)DateAndTime.MinutesTotal;
			foreach (WeatherEventInstance scheduledEvent in scheduledEvents)
			{
				scheduledEvent.InitAfterLoad();
				if (scheduledEvent.ShouldStart(time))
				{
					eventNameTextKeysList.Add(scheduledEvent.Blueprint.TextKey);
					string text = MonoSingleton<LocalizationController>.Instance.GetText(scheduledEvent.Blueprint.TextKey);
					eventNamesLocalizedList.Add(text);
					this.GameLoadedEvent?.Invoke(scheduledEvent);
				}
			}
		}

		private void CheckWeatherEventsInit()
		{
			if (weatherEvents == null)
			{
				weatherEvents = new WeatherEventsAtHour[DateAndTime.HoursInSeason + DateAndTime.HoursInDay];
				for (int i = 0; i < weatherEvents.Length; i++)
				{
					weatherEvents[i] = new WeatherEventsAtHour(i);
				}
				eventsPacked = new int[DateAndTime.HoursInSeason + DateAndTime.HoursInDay];
			}
		}

		private void AddEventsForSeason(Season season)
		{
			Dictionary<WeatherEvent, int> dictionary = new Dictionary<WeatherEvent, int>();
			List<WeatherEvent> list = new List<WeatherEvent>();
			foreach (WeatherEventSetting weatherEvent in season.WeatherEvents)
			{
				WeatherEvent byID = Repository<WeatherEventRepository, WeatherEvent>.Instance.GetByID(weatherEvent.WeatherEvent);
				if (byID == null)
				{
					Log.Error("WeatherEvent not found with id: " + weatherEvent.WeatherEvent, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WeatherManager.cs");
					continue;
				}
				int value = (int)(weatherEvent.Chance * (float)DateAndTime.HoursInSeason / 100f);
				dictionary.Add(byID, value);
				list.Add(byID);
			}
			for (int i = 0; i < eventsPacked.Length; i++)
			{
				eventsPacked[i] = 0;
				weatherEvents[i].ClearEvents();
			}
			int hashCode = GlobalSaveController.CurrentVillageData.MapSeed.GetHashCode();
			foreach (WeatherEvent item in list)
			{
				foreach (int randomArrayForWeatherEvent in GetRandomArrayForWeatherEvents(hashCode + list.IndexOf(item) + (int)DateAndTime.Year + DateAndTime.Season.GetHashCode(), DateAndTime.HoursInSeason))
				{
					if (randomArrayForWeatherEvent + DateAndTime.HoursTotal > item.SkipFirstHours && weatherEvents[randomArrayForWeatherEvent].TryAddEvent(item))
					{
						int num = eventBitMask[item];
						eventsPacked[randomArrayForWeatherEvent] |= num;
						dictionary[item]--;
						if (dictionary[item] <= 0)
						{
							break;
						}
					}
				}
			}
			CreateWeatherEventInstances();
		}

		private void CreateWeatherEventInstances()
		{
			uint daysTotal = DateAndTime.DaysTotal;
			uint num = daysTotal - daysTotal % (uint)DateAndTime.DaysInSeason;
			num *= (uint)DateAndTime.MinutesInDay;
			foreach (WeatherEvent allItem in Repository<WeatherEventRepository, WeatherEvent>.Instance.GetAllItems())
			{
				int num2 = eventBitMask[allItem];
				for (int i = 0; i < weatherEvents.Length; i++)
				{
					if ((eventsPacked[i] & num2) == 0)
					{
						continue;
					}
					int j;
					for (j = i + 1; j < eventsPacked.Length && (eventsPacked[j] & num2) != 0; j++)
					{
					}
					int num3 = UnityEngine.Random.Range(0, 50);
					int num4 = UnityEngine.Random.Range(0, 30);
					uint num5 = (uint)Math.Max(0, i * MinutesInHour + num3) + num;
					uint num6 = (uint)Math.Max(0, j * MinutesInHour - num4) + num;
					if (num6 <= num5 || Mathf.Abs(num6 - num5) < (float)allItem.MinDurationMinutes)
					{
						for (int k = i; k < j; k++)
						{
							weatherEvents[k].RemoveEvent(allItem);
							eventsPacked[k] &= ~eventBitMask[allItem];
						}
						i = j;
					}
					else
					{
						WeatherEventInstance item = new WeatherEventInstance(allItem, num5, num6);
						scheduledEvents.Add(item);
						i = j;
					}
				}
			}
		}

		private static IEnumerable<int> GetRandomArrayForWeatherEvents(int seed, int length)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < length; i++)
			{
				list.Add(i);
			}
			FastNoise noise = new FastNoise(seed);
			noise.SetFractalOctaves(2);
			noise.SetFrequency(0.15f);
			list.Sort((int a, int b) => (int)((noise.GetSimplexFractal(a, 0f) - noise.GetSimplexFractal(b, 0f)) * 100f));
			return list;
		}
	}
}
