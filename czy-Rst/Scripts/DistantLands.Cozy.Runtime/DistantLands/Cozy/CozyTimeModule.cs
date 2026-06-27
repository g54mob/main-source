using System;
using System.Collections;
using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyTimeModule : CozyModule
	{
		public CozyTransitModule transit;

		public PerennialProfile perennialProfile;

		public CozyDateOverride overrideDate;

		[Range(0f, 1f)]
		public float yearPercentage;

		public bool transitioningTime;

		[FormerlySerializedAs("m_DayPercentage")]
		[CozySearchable(new string[] { })]
		public MeridiemTime currentTime = 0f;

		[CozySearchable(new string[] { })]
		public int currentDay;

		[CozySearchable(new string[] { })]
		public int currentYear;

		public CozyTimeModule parentModule;

		public float modifiedDayPercentage
		{
			get
			{
				if (!transit)
				{
					return currentTime;
				}
				return transit.ModifyDayPercentage(currentTime) / 360f;
			}
		}

		public int AbsoluteDay => currentDay + DaysPerYear * currentYear;

		public int DaysPerYear
		{
			get
			{
				if ((bool)overrideDate)
				{
					return overrideDate.DaysPerYear();
				}
				if (perennialProfile.realisticYear)
				{
					return perennialProfile.GetRealisticDaysPerYear(currentYear);
				}
				return perennialProfile.daysPerYear;
			}
		}

		public float modifiedTimeSpeed => perennialProfile.timeMovementSpeed * (float)((!perennialProfile.pauseTime) ? 1 : 0) * (perennialProfile.modulateTimeSpeed ? perennialProfile.timeSpeedMultiplier.Evaluate(currentTime) : 1f) / 1440f;

		public override void InitializeModule()
		{
			base.InitializeModule();
			base.weatherSphere.timeModule = this;
		}

		internal override bool CheckIfModuleCanBeRemoved(out string warning)
		{
			if (base.weatherSphere.GetModule<CozyTransitModule>() != null)
			{
				warning = "Transit Module";
				return false;
			}
			warning = "";
			return true;
		}

		internal override bool CheckIfModuleCanBeAdded(out string warning)
		{
			if (base.weatherSphere.GetModule<SystemTimeModule>() != null)
			{
				warning = "System Time Module";
				return false;
			}
			warning = "";
			return true;
		}

		private void Start()
		{
			SetupTime();
		}

		private void Update()
		{
			if (base.weatherSphere.timeModule == null)
			{
				base.weatherSphere.timeModule = this;
			}
			ManageTime();
			yearPercentage = GetCurrentYearPercentage();
		}

		private void SetupTime()
		{
			if (perennialProfile.resetTimeOnStart)
			{
				currentTime = perennialProfile.startTime;
			}
			if (perennialProfile.realisticYear)
			{
				perennialProfile.daysPerYear = perennialProfile.GetRealisticDaysPerYear(currentYear);
			}
		}

		private void ConstrainTime()
		{
			if ((float)currentTime >= 1f)
			{
				currentTime = (float)currentTime - 1f;
				ChangeDay(1);
				base.weatherSphere.events.RaiseOnDayChange();
			}
			if ((float)currentTime < 0f)
			{
				currentTime = (float)currentTime + 1f;
				ChangeDay(-1);
				base.weatherSphere.events.RaiseOnDayChange();
			}
		}

		private void ChangeDay(int change)
		{
			if ((bool)overrideDate)
			{
				overrideDate.ChangeDay(change);
			}
			else if (perennialProfile.progressDay)
			{
				currentDay += change;
				if (currentDay >= perennialProfile.daysPerYear)
				{
					currentDay -= perennialProfile.daysPerYear;
					currentYear++;
					base.weatherSphere.events.RaiseOnYearChange();
				}
				if (currentDay < 0)
				{
					currentDay += perennialProfile.daysPerYear;
					currentYear--;
					base.weatherSphere.events.RaiseOnYearChange();
				}
			}
		}

		[Obsolete("GetDaysPerYear() is deprecated. Please use DaysPerYear instead.")]
		public int GetDaysPerYear()
		{
			if ((bool)overrideDate)
			{
				return overrideDate.DaysPerYear();
			}
			if (perennialProfile.realisticYear)
			{
				return perennialProfile.GetRealisticDaysPerYear(currentYear);
			}
			return perennialProfile.daysPerYear;
		}

		public void GetSunTransitTime(out MeridiemTime sunrise, out MeridiemTime sunset)
		{
			if ((bool)transit)
			{
				transit.GetSunTransitTime(out sunrise, out sunset);
				return;
			}
			sunrise = 0.25f;
			sunset = 0.75f;
		}

		public float GetCurrentYearPercentage()
		{
			if ((bool)overrideDate)
			{
				return overrideDate.GetCurrentYearPercentage();
			}
			return DayAndTime() / (float)DaysPerYear;
		}

		public float GetCurrentYearPercentage(float inTIme)
		{
			if ((bool)overrideDate)
			{
				return overrideDate.GetCurrentYearPercentage(inTIme);
			}
			return (DayAndTime() + inTIme) / (float)perennialProfile.daysPerYear;
		}

		public float DayAndTime()
		{
			if ((bool)overrideDate)
			{
				return overrideDate.DayAndTime();
			}
			return (float)currentDay + (float)currentTime;
		}

		public void ManageTime()
		{
			if (Application.isPlaying && !perennialProfile.pauseTime)
			{
				currentTime = (float)currentTime + modifiedTimeSpeed * Time.deltaTime;
			}
			ConstrainTime();
		}

		public void SkipTime(MeridiemTime timeToSkip)
		{
			currentTime = (float)currentTime + (float)timeToSkip;
			if ((bool)base.weatherSphere.GetModule<CozyAmbienceModule>())
			{
				base.weatherSphere.GetModule<CozyAmbienceModule>().SkipTime(timeToSkip);
			}
			foreach (CozySystem system in base.weatherSphere.systems)
			{
				system.SkipTime(timeToSkip);
			}
		}

		public void SkipTime(MeridiemTime timeToSkip, int daysToSkip)
		{
			currentTime = (float)currentTime + (float)timeToSkip;
			currentDay += daysToSkip;
			if ((bool)base.weatherSphere.GetModule<CozyAmbienceModule>())
			{
				base.weatherSphere.GetModule<CozyAmbienceModule>().SkipTime((float)timeToSkip + (float)daysToSkip);
			}
			foreach (CozySystem system in base.weatherSphere.systems)
			{
				system.SkipTime((float)timeToSkip + (float)daysToSkip);
			}
		}

		public void SetHour(int hour)
		{
			currentTime = new MeridiemTime(hour, currentTime.minutes, currentTime.seconds, currentTime.milliseconds);
		}

		public void SetMinute(int minute)
		{
			currentTime = new MeridiemTime(currentTime.hours, minute, currentTime.seconds, currentTime.milliseconds);
		}

		public string MonthTitle(float month)
		{
			if (perennialProfile.realisticYear)
			{
				GetCurrentMonth(out var monthName, out var monthDay, out var _);
				return monthName + " " + monthDay;
			}
			float num = Mathf.Floor(month * 12f);
			float num2 = perennialProfile.daysPerYear / 12;
			float num3 = DayAndTime() - num * num2;
			PerennialProfile.DefaultYear defaultYear = (PerennialProfile.DefaultYear)num;
			PerennialProfile.TimeDivisors timeDivisors = PerennialProfile.TimeDivisors.Mid;
			timeDivisors = ((!(num3 / num2 < 0.33f)) ? ((!(num3 / num2 > 0.66f)) ? PerennialProfile.TimeDivisors.Mid : PerennialProfile.TimeDivisors.Late) : PerennialProfile.TimeDivisors.Early);
			return $"{timeDivisors} {defaultYear}";
		}

		public void GetCurrentMonth(out string monthName, out int monthDay, out float monthPercentage)
		{
			int num = currentDay;
			int num2 = 0;
			while (num > ((perennialProfile.useLeapYear && currentYear % 4 == 0) ? perennialProfile.leapYear[num2].days : perennialProfile.standardYear[num2].days))
			{
				num -= ((perennialProfile.useLeapYear && currentYear % 4 == 0) ? perennialProfile.leapYear[num2].days : perennialProfile.standardYear[num2].days);
				num2++;
				if (num2 >= ((perennialProfile.useLeapYear && currentYear % 4 == 0) ? perennialProfile.leapYear.Length : perennialProfile.standardYear.Length))
				{
					break;
				}
			}
			PerennialProfile.Month month = ((perennialProfile.useLeapYear && currentYear % 4 == 0) ? perennialProfile.leapYear[num2] : perennialProfile.standardYear[num2]);
			monthName = month.name;
			monthDay = num;
			monthPercentage = month.days;
		}

		public void TransitionTime(float timeToSkip, float time)
		{
			StartCoroutine(TransitionTime(currentTime, timeToSkip, time));
		}

		private IEnumerator TransitionTime(float startDayPercentage, float timeToSkip, float time)
		{
			transitioningTime = true;
			float t = time;
			_ = timeToSkip % 1f;
			Mathf.Floor(timeToSkip);
			float transitionSpeed = timeToSkip / time;
			while (t > 0f)
			{
				_ = t / time;
				yield return new WaitForEndOfFrame();
				currentTime = (float)currentTime + Time.deltaTime * transitionSpeed;
				t -= Time.deltaTime;
			}
			transitioningTime = false;
		}
	}
}
