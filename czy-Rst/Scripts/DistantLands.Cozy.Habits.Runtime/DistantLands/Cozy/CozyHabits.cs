using System;
using System.Collections.Generic;
using System.Linq;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyHabits : CozyDateOverride
	{
		[Serializable]
		public class Day
		{
			public Weekday weekday;

			[ModifiedDate]
			public ModifiedDate date;

			public CozyHabitProfile[] events;
		}

		[Serializable]
		public struct ModifiedDate
		{
			public int day;

			public int month;

			public int year;

			public MeridiemTime time;

			public string GetName()
			{
				return $"{day + 1}/{month + 1}/{year}";
			}

			public ModifiedDate(int _day, int _month, int _year)
			{
				day = _day;
				month = _month;
				year = _year;
				time = new MeridiemTime(0, 0);
			}

			public ModifiedDate(int _day, int _month, int _year, MeridiemTime _meridiemTime)
			{
				day = _day;
				month = _month;
				year = _year;
				time = _meridiemTime;
			}

			public static bool operator >(ModifiedDate a, ModifiedDate b)
			{
				if (a.year > b.year)
				{
					return true;
				}
				if (a.month > b.month && a.year == b.year)
				{
					return true;
				}
				if (a.day > b.day && a.month == b.month && a.year == b.year)
				{
					return true;
				}
				return false;
			}

			public static bool operator <(ModifiedDate a, ModifiedDate b)
			{
				if (a.year < b.year)
				{
					return true;
				}
				if (a.month < b.month && a.year == b.year)
				{
					return true;
				}
				if (a.day < b.day && a.month == b.month && a.year == b.year)
				{
					return true;
				}
				return false;
			}

			public static ModifiedDate operator -(ModifiedDate a, int b)
			{
				if ((bool)CozyWeather.instance.GetModule<CozyHabits>().profile)
				{
					HabitsYearProfile profile = CozyWeather.instance.GetModule<CozyHabits>().profile;
					a.day -= b;
					while (a.day < 0)
					{
						a.month--;
						if (a.month < 0)
						{
							a.month = profile.months.Count - 1;
							a.year--;
						}
						a.day += profile.months[a.month].daysInMonth;
					}
					return a;
				}
				return new ModifiedDate(a.day - b, a.month, a.year);
			}

			public static ModifiedDate operator +(ModifiedDate a, int b)
			{
				if ((bool)CozyWeather.instance.GetModule<CozyHabits>().profile)
				{
					HabitsYearProfile profile = CozyWeather.instance.GetModule<CozyHabits>().profile;
					a.day += b;
					while (a.day >= profile.months[a.month].daysInMonth)
					{
						a.day -= profile.months[a.month].daysInMonth;
						a.month++;
						if (a.month >= profile.months.Count)
						{
							a.month = 0;
							a.year++;
						}
					}
					return a;
				}
				return new ModifiedDate(a.day + b, a.month, a.year);
			}

			public static bool operator <=(ModifiedDate a, ModifiedDate b)
			{
				if (a.day != b.day || a.month != b.month || a.year != b.year)
				{
					return a < b;
				}
				return true;
			}

			public static bool operator >=(ModifiedDate a, ModifiedDate b)
			{
				if (a.day != b.day || a.month != b.month || a.year != b.year)
				{
					return a > b;
				}
				return true;
			}
		}

		public enum Weekday
		{
			sunday = 0,
			monday = 1,
			tuesday = 2,
			wednesday = 3,
			thursday = 4,
			friday = 5,
			saturday = 6
		}

		public enum Calendar
		{
			red = 1,
			orange = 2,
			yellow = 4,
			green = 8,
			lightBlue = 0x10,
			blue = 0x20,
			purple = 0x40,
			pink = 0x80,
			white = 0x100,
			grey = 0x200
		}

		[SerializeField]
		private bool selection;

		[SerializeField]
		private bool monthView;

		[SerializeField]
		private bool weekView;

		[SerializeField]
		private bool dayView;

		public HabitsYearProfile profile;

		[Weekday(WeekdayAttribute.TitleStyle.fullDayName, 30, true, false)]
		public Day currentDay = new Day
		{
			date = new ModifiedDate(0, 0, 0)
		};

		[Weekday(WeekdayAttribute.TitleStyle.weekdayInitial, 24, false, true)]
		public Day[] currentWeek;

		public Day[] currentMonth;

		private int yearLength;

		public int simpleDate;

		public float dayPercent;

		public override void InitializeModule()
		{
			base.InitializeModule();
			if ((bool)base.weatherSphere.timeModule)
			{
				base.weatherSphere.timeModule.overrideDate = this;
			}
		}

		private void OnStart()
		{
			SetupVariables();
		}

		public static Color CalendarColor(Calendar calendar)
		{
			return calendar switch
			{
				Calendar.red => new Color(0.9098039f, 19f / 51f, 0.36078432f), 
				Calendar.orange => new Color(0.9411765f, 0.5294118f, 0f), 
				Calendar.yellow => new Color(1f, 40f / 51f, 29f / 85f), 
				Calendar.green => new Color(41f / 85f, 40f / 51f, 44f / 85f), 
				Calendar.blue => new Color(0.2f, 0.29411766f, 40f / 51f), 
				Calendar.purple => new Color(28f / 51f, 26f / 85f, 0.7058824f), 
				Calendar.grey => new Color(0.5f, 0.5f, 0.5f), 
				Calendar.white => new Color(1f, 1f, 1f), 
				Calendar.lightBlue => new Color(32f / 85f, 0.7058824f, 0.83137256f), 
				Calendar.pink => new Color(44f / 51f, 59f / 85f, 0.79607844f), 
				_ => Color.white, 
			};
		}

		public static string GetWeekdayNameFromInt(int id)
		{
			return id switch
			{
				0 => "S", 
				1 => "M", 
				2 => "T", 
				3 => "W", 
				4 => "T", 
				5 => "F", 
				6 => "S", 
				_ => "", 
			};
		}

		public void SetupVariables()
		{
			FormatDate();
			yearLength = profile.GetYearLength();
			currentDay.events = ObserveDailySchedule(currentDay);
			GetCurrentWeek();
			GetCurrentMonth();
		}

		public CozyHabitProfile[] ObserveDailySchedule(Day day)
		{
			List<CozyHabitProfile> list = new List<CozyHabitProfile>();
			foreach (CozyHabitProfile @event in profile.events)
			{
				if (@event == null)
				{
					continue;
				}
				ModifiedDate modifiedDate = ((@event.repeatStyle != CozyHabitProfile.RepeatStyle.never) ? new ModifiedDate(@event.startDate.day, @event.startDate.month, 0) : @event.startDate);
				ModifiedDate modifiedDate2 = ((@event.repeatStyle != CozyHabitProfile.RepeatStyle.never) ? new ModifiedDate(@event.endDate.day, @event.endDate.month, 0) : @event.endDate);
				ModifiedDate modifiedDate3 = ((@event.repeatStyle != CozyHabitProfile.RepeatStyle.never) ? new ModifiedDate(day.date.day, day.date.month, 0) : day.date);
				if ((!(modifiedDate <= modifiedDate3) || !(modifiedDate2 >= modifiedDate3)) && @event.dateRange)
				{
					continue;
				}
				switch (@event.repeatStyle)
				{
				case CozyHabitProfile.RepeatStyle.never:
					if (@event.dateRange)
					{
						if (@event.startDate.day <= day.date.day && @event.endDate.day >= day.date.day && @event.startDate.month <= day.date.month && @event.endDate.month >= day.date.month)
						{
							list.Add(@event);
						}
					}
					else if (@event.startDate.day == day.date.day && @event.startDate.month == day.date.month && @event.startDate.year == day.date.year)
					{
						list.Add(@event);
					}
					break;
				case CozyHabitProfile.RepeatStyle.annually:
					if (@event.dateRange)
					{
						if (modifiedDate.day == modifiedDate3.day && modifiedDate.month == modifiedDate3.month)
						{
							list.Add(@event);
						}
					}
					else if (modifiedDate.day <= modifiedDate3.day && modifiedDate2.day >= modifiedDate3.day && modifiedDate.month <= modifiedDate3.month && modifiedDate2.month >= modifiedDate3.month)
					{
						list.Add(@event);
					}
					break;
				case CozyHabitProfile.RepeatStyle.monthly:
				{
					bool num;
					if (!@event.dateRange)
					{
						num = modifiedDate.day == modifiedDate3.day;
					}
					else
					{
						if (modifiedDate.day > modifiedDate3.day)
						{
							break;
						}
						num = modifiedDate2.day >= modifiedDate3.day;
					}
					if (num)
					{
						list.Add(@event);
					}
					break;
				}
				case CozyHabitProfile.RepeatStyle.everyOtherDay:
					if ((ConvertToSimpleDate(modifiedDate3, includeYear: true) - ConvertToSimpleDate(modifiedDate, includeYear: true)) % 2 == 0)
					{
						list.Add(@event);
					}
					break;
				case CozyHabitProfile.RepeatStyle.daily:
					list.Add(@event);
					break;
				case CozyHabitProfile.RepeatStyle.weekdays:
					if (day.weekday == Weekday.monday || day.weekday == Weekday.tuesday || day.weekday == Weekday.wednesday || day.weekday == Weekday.thursday || day.weekday == Weekday.friday)
					{
						list.Add(@event);
					}
					break;
				case CozyHabitProfile.RepeatStyle.weekends:
					if (day.weekday == Weekday.saturday || day.weekday == Weekday.sunday)
					{
						list.Add(@event);
					}
					break;
				case CozyHabitProfile.RepeatStyle.weekly:
					if (@event.weekday == day.weekday)
					{
						list.Add(@event);
					}
					break;
				}
			}
			list = ((IEnumerable<CozyHabitProfile>)list).OrderBy((Func<CozyHabitProfile, float>)((CozyHabitProfile habitTime) => habitTime.startTime)).ToList();
			return list.ToArray();
		}

		public void GetCurrentWeek()
		{
			List<Day> list = new List<Day>();
			ModifiedDate modifiedDate = currentDay.date - (int)currentDay.weekday;
			for (int i = 0; i < 7; i++)
			{
				Day day = new Day
				{
					date = modifiedDate + i,
					weekday = (Weekday)i
				};
				day.events = ObserveDailySchedule(day);
				list.Add(day);
			}
			currentWeek = list.ToArray();
		}

		public void GetCurrentMonth()
		{
			if (!(profile == null))
			{
				List<Day> list = new List<Day>();
				ModifiedDate modifiedDate = currentDay.date - currentDay.date.day;
				int num = ConvertToSimpleDate(modifiedDate, includeYear: true);
				for (int i = 0; i < profile.months[modifiedDate.month].daysInMonth; i++)
				{
					Day day = new Day
					{
						date = modifiedDate + i,
						weekday = GetWeekday(num + i)
					};
					day.events = ObserveDailySchedule(day);
					list.Add(day);
				}
				currentMonth = list.ToArray();
			}
		}

		private void Update()
		{
			if (!(profile == null))
			{
				if (yearLength == 0)
				{
					SetupVariables();
				}
				if (!Application.isPlaying)
				{
					FormatDate();
					currentDay.events = ObserveDailySchedule(currentDay);
					GetCurrentWeek();
					GetCurrentMonth();
				}
				yearPercentage = (float)simpleDate / (float)yearLength;
				ManageEvents();
			}
		}

		public int ConvertToSimpleDate(ModifiedDate date, bool includeYear)
		{
			int num = 0;
			if (includeYear)
			{
				num += date.year * yearLength;
			}
			for (int i = 0; i < date.month; i++)
			{
				num += profile.months[i].daysInMonth;
			}
			return num + date.day;
		}

		public void ManageEvents()
		{
			if (base.weatherSphere.dayPercentage < dayPercent && base.weatherSphere.dayPercentage < 0.05f)
			{
				dayPercent = 0f;
			}
			CozyHabitProfile[] events = currentDay.events;
			foreach (CozyHabitProfile cozyHabitProfile in events)
			{
				bool num;
				if (!cozyHabitProfile.overnight)
				{
					if (!((float)cozyHabitProfile.startTime <= base.weatherSphere.dayPercentage))
					{
						goto IL_015d;
					}
					num = (float)cozyHabitProfile.endTime >= dayPercent;
				}
				else
				{
					if ((float)cozyHabitProfile.startTime <= base.weatherSphere.dayPercentage)
					{
						goto IL_00b8;
					}
					num = (float)cozyHabitProfile.endTime >= dayPercent;
				}
				if (num)
				{
					goto IL_00b8;
				}
				goto IL_015d;
				IL_015d:
				if (cozyHabitProfile.runHabitOnEnd && cozyHabitProfile.isEventRunning)
				{
					cozyHabitProfile.RaiseOnEnd();
				}
				cozyHabitProfile.isEventRunning = false;
				continue;
				IL_00b8:
				if (cozyHabitProfile.runHabitContinuously)
				{
					if ((bool)base.weatherSphere.weatherModule)
					{
						if (!cozyHabitProfile.cancelIfWeatherIsPlaying.Contains(base.weatherSphere.weatherModule.ecosystem.currentWeather))
						{
							cozyHabitProfile.RaiseOnUpdate();
						}
					}
					else
					{
						cozyHabitProfile.RaiseOnUpdate();
					}
				}
				if (cozyHabitProfile.runHabitOnStart && !cozyHabitProfile.isEventRunning)
				{
					if ((bool)base.weatherSphere.weatherModule)
					{
						if (!cozyHabitProfile.cancelIfWeatherIsPlaying.Contains(base.weatherSphere.weatherModule.ecosystem.currentWeather))
						{
							cozyHabitProfile.RaiseOnStart();
						}
					}
					else
					{
						cozyHabitProfile.RaiseOnStart();
					}
				}
				cozyHabitProfile.isEventRunning = true;
			}
			dayPercent = base.weatherSphere.dayPercentage;
		}

		private void FormatDate()
		{
			simpleDate = ConvertToSimpleDate(currentDay.date, includeYear: false);
			while (currentDay.date.day < 0)
			{
				currentDay.date.month--;
				if (currentDay.date.month < 0)
				{
					currentDay.date.month = profile.months.Count - 1;
					currentDay.date.year--;
				}
				currentDay.date.day += profile.months[currentDay.date.month].daysInMonth;
			}
			while (currentDay.date.day >= profile.months[currentDay.date.month].daysInMonth)
			{
				currentDay.date.day -= profile.months[currentDay.date.month].daysInMonth;
				currentDay.date.month++;
				if (currentDay.date.month >= profile.months.Count)
				{
					currentDay.date.month = 0;
					currentDay.date.year++;
				}
			}
			currentDay.weekday = GetWeekday(ConvertToSimpleDate(currentDay.date, includeYear: true));
		}

		public Weekday GetWeekday(int day)
		{
			return (Weekday)ClampWithLoop((int)((int)((float)day - Mathf.Floor(day / 7) * 7f) + profile.startDay), 0, 6);
		}

		public override float GetCurrentYearPercentage()
		{
			return yearPercentage;
		}

		public override float GetCurrentYearPercentage(float inTime)
		{
			return ((float)simpleDate + Mathf.Round(inTime)) / (float)yearLength;
		}

		public override float DayAndTime()
		{
			return (float)simpleDate + (float)base.weatherSphere.timeModule.currentTime;
		}

		public override void ChangeDay(int days)
		{
			CozyHabitProfile[] events = currentDay.events;
			foreach (CozyHabitProfile cozyHabitProfile in events)
			{
				if (cozyHabitProfile.allDay)
				{
					cozyHabitProfile.RaiseOnEnd();
				}
			}
			currentDay.date.day += days;
			FormatDate();
			currentDay.events = ObserveDailySchedule(currentDay);
			base.weatherSphere.events.RaiseOnDayChange();
			if ((bool)base.weatherSphere.timeModule)
			{
				base.weatherSphere.timeModule.currentDay = simpleDate;
				base.weatherSphere.timeModule.currentYear = currentDay.date.year;
			}
			if ((bool)base.weatherSphere.timeModule.transit)
			{
				base.weatherSphere.timeModule.transit.GetModifiedDayPercent();
			}
			events = currentDay.events;
			foreach (CozyHabitProfile cozyHabitProfile2 in events)
			{
				if (cozyHabitProfile2.allDay)
				{
					cozyHabitProfile2.RaiseOnStart();
				}
			}
		}

		public static int ClampWithLoop(int value, int minValue, int maxValue)
		{
			int num = maxValue - minValue + 1;
			while (value < minValue)
			{
				value += num;
			}
			while (value > maxValue)
			{
				value -= num;
			}
			return value;
		}

		public override int DaysPerYear()
		{
			return yearLength;
		}
	}
}
