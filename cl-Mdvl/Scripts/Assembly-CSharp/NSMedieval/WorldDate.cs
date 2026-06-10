using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	[FVSerializableKey("WorldDate", "")]
	public class WorldDate : IFVSerializable
	{
		[SerializeField]
		private volatile uint days;

		[SerializeField]
		private volatile ushort minutes;

		[SerializeField]
		private volatile ushort startingYear;

		private float minuteFract;

		private volatile int minutesInDay;

		private volatile int daysInSeason;

		private volatile int seasonsCount;

		private volatile int minutesInHour;

		private volatile int hoursInSeason;

		private volatile int minutesInSeason;

		private volatile int minutesInYear;

		private DateTimeSettings dateTimeSettings;

		private bool dateTimeInit;

		private bool isOverrideTemperature;

		private float overrideTemperatureValue;

		private float temperatureCelsius;

		[SerializeField]
		private int startSeasonOffset;

		private float yearCycle;

		public static int GameStartHour { get; set; }

		public static int GameStartSeason { get; set; }

		public bool IsOverrideTemperature => isOverrideTemperature;

		private DateTimeSettings DateTimeSettings
		{
			get
			{
				if (dateTimeInit)
				{
					return dateTimeSettings;
				}
				dateTimeInit = true;
				dateTimeSettings = Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>();
				return dateTimeSettings;
			}
		}

		public int StartSeasonOffset => startSeasonOffset;

		public int MinutesInDay
		{
			get
			{
				if (minutesInDay == 0)
				{
					minutesInDay = DateTimeSettings.MinutesInDay();
				}
				return minutesInDay;
			}
		}

		public int HoursInDay => DateTimeSettings.HoursInDay;

		public int DaysInSeason
		{
			get
			{
				if (daysInSeason == 0)
				{
					daysInSeason = DateTimeSettings.DaysInSeason;
				}
				return daysInSeason;
			}
		}

		public int SeasonsCount
		{
			get
			{
				if (seasonsCount == 0)
				{
					seasonsCount = DateTimeSettings.Seasons.Count;
				}
				return seasonsCount;
			}
		}

		public int MinutesInHour
		{
			get
			{
				if (minutesInHour == 0)
				{
					minutesInHour = DateTimeSettings.MinutesInHour;
				}
				return minutesInHour;
			}
		}

		public int HoursInSeason
		{
			get
			{
				if (hoursInSeason == 0)
				{
					hoursInSeason = DateTimeSettings.HoursInDay * DateTimeSettings.DaysInSeason;
				}
				return hoursInSeason;
			}
		}

		public int MinutesInSeason
		{
			get
			{
				if (minutesInSeason == 0)
				{
					minutesInSeason = HoursInSeason * MinutesInHour;
				}
				return minutesInSeason;
			}
		}

		public int MinutesInYear
		{
			get
			{
				if (minutesInYear == 0)
				{
					minutesInYear = HoursInSeason * MinutesInHour * SeasonsCount;
				}
				return minutesInYear;
			}
		}

		public float TemperatureCelsius
		{
			get
			{
				if (!isOverrideTemperature)
				{
					return temperatureCelsius;
				}
				return overrideTemperatureValue;
			}
			set
			{
				temperatureCelsius = value;
			}
		}

		public long SeasonStartMinutes => (DaysTotal - DaysTotal % DaysInSeason) * MinutesInDay;

		public uint Year => startingYear + (uint)((int)days + startSeasonOffset) / (uint)(DaysInSeason * SeasonsCount);

		public Season Season => DateTimeSettings.Seasons[(int)((startSeasonOffset + days) / DaysInSeason) % SeasonsCount];

		public float SeasonPercent => ((float)((Day - 1) * HoursInDay + HoursSinceDay) + (float)MinutesSinceHour / (float)MinutesInHour) / (float)HoursInSeason;

		public uint DaysTotal => days;

		public int DayOfYear => (int)(DaysTotal + startSeasonOffset) % DaysInYear;

		public int Day => (int)(days % (uint)DaysInSeason + 1);

		public int HoursSinceDay => minutes / MinutesInHour;

		public uint HoursTotalZero => (uint)(MinutesTotal / MinutesInHour - GlobalSaveController.CurrentVillageData.Scenario.StartHour);

		public uint HoursTotal => (uint)(MinutesTotal / MinutesInHour);

		public int DaysInYear => daysInSeason * seasonsCount;

		public int MinutesSinceHour => minutes % MinutesInHour;

		public int MinutesSinceDay => minutes;

		public long MinutesTotal => days * MinutesInDay + minutes;

		public long MinutesTotalWithSeasonOffset => (days + startSeasonOffset) * MinutesInDay + minutes;

		public long CurrentTimeTutorialAware
		{
			get
			{
				if (!TutorialManager.IsTutorialActive)
				{
					return MinutesTotal;
				}
				return WorldTimeManager.UnityTimeLong;
			}
		}

		public float MinuteFract => minuteFract;

		public string[] DayEffectors => DateTimeSettings.DayEffectors;

		public string[] NightEffectors => DateTimeSettings.NightEffectors;

		public float DayEffectorsEnd => DateTimeSettings.DayEffectorsEnd;

		public float NightEffectorsEnd => DateTimeSettings.NightEffectorsEnd;

		public float YearCycle => yearCycle;

		public List<Season> Seasons => DateTimeSettings.Seasons;

		public bool IsNightTime
		{
			get
			{
				if (!((float)HoursSinceDay > Season.SunsetHour))
				{
					return (float)HoursSinceDay < Season.SunriseHour;
				}
				return true;
			}
		}

		public WorldDate(object callerObject)
		{
			System.Random random = GetRandom();
			startingYear = (ushort)DateTimeSettings.StartingYearRange.Random(random);
			startSeasonOffset = GameStartSeason * DaysInSeason;
			minutes = (ushort)(DateTimeSettings.MinutesInHour * GameStartHour);
			UpdateYearCycle();
		}

		public WorldDate(DateTimeSettings dateTimeSettings)
		{
			dateTimeInit = true;
			this.dateTimeSettings = dateTimeSettings;
			System.Random random = GetRandom();
			startingYear = (ushort)DateTimeSettings.StartingYearRange.Random(random);
			startSeasonOffset = GameStartSeason * DaysInSeason;
			minutes = (ushort)(DateTimeSettings.MinutesInHour * GameStartHour);
			UpdateYearCycle();
		}

		public void ForceUpdateYearCycle()
		{
			UpdateYearCycle();
		}

		private System.Random GetRandom()
		{
			int num = 0;
			if (MonoSingleton<GlobalSaveController>.IsInstantiated() && GlobalSaveController.CurrentVillageData != null && GlobalSaveController.CurrentVillageData.MapSeed != null)
			{
				num = GlobalSaveController.CurrentVillageData.MapSeed.GetHashCode();
			}
			if (num != 0)
			{
				return new System.Random();
			}
			return new System.Random(num);
		}

		public static float ConvertCelsiusTemperature(float celsiusTemperature, TemperatureUnitsType units, bool baseValue = true)
		{
			switch (units)
			{
			case TemperatureUnitsType.Fahrenheit:
				if (baseValue)
				{
					return celsiusTemperature * 1.8f + 32f;
				}
				return celsiusTemperature * 1.8f;
			case TemperatureUnitsType.Kelvin:
				return celsiusTemperature + 273.15f;
			default:
				return celsiusTemperature;
			}
		}

		public static string GetLocalizedTemperature(float celsiusTemperature)
		{
			return $"{ConvertCelsiusTemperature(celsiusTemperature, MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits):F1}{GetLocalizedTemperatureUnitSymbol()}";
		}

		public static string GetLocalizedTemperatureRelative(float celsiusTemperature)
		{
			return $"{ConvertCelsiusTemperature(celsiusTemperature, MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits, baseValue: false):F1}{GetLocalizedTemperatureUnitSymbol()}";
		}

		public static string GetLocalizedTemperatureUnitSymbol()
		{
			return MonoSingleton<LocalizationController>.Instance.GetTemperatureUnitsSymbol(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits);
		}

		public void SetMinutesTotal(uint minutesTotal)
		{
			days = (uint)(minutesTotal / MinutesInDay);
			minutes = (ushort)(minutesTotal % MinutesInDay);
			UpdateYearCycle();
		}

		public int DaysToMinutes(int days)
		{
			return days * MinutesInDay;
		}

		public int HoursToMinutes(int hours)
		{
			return hours * MinutesInHour;
		}

		public void AddMinute(ushort secondsCount = 1)
		{
			if (!TutorialManager.IsTutorialActive || !MonoSingleton<TutorialManager>.Instance.PreventWorldTimeTick)
			{
				minutes += secondsCount;
				if (minutes >= MinutesInDay)
				{
					minutes = 0;
					AddDay();
				}
				else
				{
					UpdateYearCycle();
				}
			}
		}

		public void DebugSeekSeason(int day, int minute)
		{
			days = (uint)day;
			minutes = (ushort)minute;
			UpdateYearCycle();
		}

		private void UpdateYearCycle()
		{
			yearCycle = ((float)DateTimeSettings.Seasons.IndexOf(Season) + SeasonPercent) / 4f;
		}

		private void AddDay()
		{
			if (days < DateTimeSettings.MaxDays)
			{
				days++;
				UpdateYearCycle();
			}
		}

		public Season NextSeason(Season currentSeason)
		{
			return DateTimeSettings.Seasons[(currentSeason.Index + 1) % DateTimeSettings.Seasons.Count];
		}

		public Season PrevSeason(Season currentSeason)
		{
			return DateTimeSettings.Seasons[(currentSeason.Index + DateTimeSettings.Seasons.Count - 1) % DateTimeSettings.Seasons.Count];
		}

		public uint MinutesToSeasonHours(uint minutesTotal)
		{
			return minutesTotal / (uint)MinutesInHour % (uint)HoursInSeason;
		}

		public void DebugOverrideTemperatureOutside(bool shouldOverride, float temperatureOutside = 0f)
		{
			isOverrideTemperature = shouldOverride;
			overrideTemperatureValue = temperatureOutside;
		}

		public void SetMinuteFractionalPart(float minuteFract)
		{
			this.minuteFract = minuteFract;
		}

		public TraderStockModifiersContainer GetStockModifiersForCurrentSeason()
		{
			return DateTimeSettings.StockModifiersBySeason.FirstOrDefault((TraderStockModifiersContainer modifier) => Season.Name.Equals(modifier.GetID()));
		}

		public Season GetSeasonForMinutes(in long minutes)
		{
			int index = Mathf.FloorToInt((float)(minutes % MinutesInYear) / (float)MinutesInSeason);
			return Seasons[index];
		}

		public string GetLocalizedDateString()
		{
			return string.Format("{0}, {1}, {2}", MonoSingleton<LocalizationController>.Instance.GetText("general_" + GlobalSaveController.CurrentVillageData.DateAndTime.Season.Name), UiUtils.GetLocalizedDay(), Year);
		}

		public long ClampMinutesInSeason(long minutes)
		{
			return Math.Clamp(minutes, SeasonStartMinutes, SeasonStartMinutes + (uint)MinutesInSeason);
		}

		public string GetSeasonDayLocalized(int dayInYear)
		{
			dayInYear--;
			int index = dayInYear / daysInSeason % seasonsCount;
			Season season = Seasons[index];
			int num = dayInYear % daysInSeason + 1;
			return string.Format("{0} {1}", ("general_" + season.Name).ToLocalized(), num);
		}

		public long GetNextNoon(long minutes)
		{
			long num = days * minutesInDay + minutesInDay / 2;
			if (minutes > num)
			{
				num += minutesInDay;
			}
			return num;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("days", days);
			serializer.Write("minutes", minutes);
			serializer.Write("startingYear", startingYear);
			serializer.Write("startSeasonOffset", startSeasonOffset);
		}

		public WorldDate(FVDeserializer deserializer)
		{
			days = deserializer.ReadUInt("days");
			minutes = deserializer.ReadUShort("minutes", 0);
			startingYear = deserializer.ReadUShort("startingYear", 0);
			startSeasonOffset = deserializer.ReadInt("startSeasonOffset");
			UpdateYearCycle();
		}
	}
}
