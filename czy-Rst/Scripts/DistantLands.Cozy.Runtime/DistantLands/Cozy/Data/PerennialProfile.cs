using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Perennial Profile", order = 361)]
	public class PerennialProfile : CozyProfile
	{
		[Serializable]
		public class Month
		{
			public string name;

			public int days;
		}

		public enum DefaultYear
		{
			January = 0,
			February = 1,
			March = 2,
			April = 3,
			May = 4,
			June = 5,
			July = 6,
			August = 7,
			September = 8,
			October = 9,
			November = 10,
			December = 11
		}

		public enum TimeDivisors
		{
			Early = 0,
			Mid = 1,
			Late = 2
		}

		public bool pauseTime;

		[Tooltip("Should this profile use a series of months for a more realistic year.")]
		public bool realisticYear;

		[Tooltip("Should this profile use a longer year every 4th year.")]
		public bool useLeapYear;

		[Tooltip("Should this system reset the time when it loads?")]
		public bool resetTimeOnStart;

		[Tooltip("The time that this system should start at when the scene is loaded.")]
		public MeridiemTime startTime = new MeridiemTime(9, 0);

		[Tooltip("Specifies the amount of in-game minutes that pass in a real-world second.")]
		public float timeMovementSpeed = 1f;

		[Tooltip("Change the rate at which time moves based on the current time.")]
		public bool modulateTimeSpeed = true;

		[Tooltip("Changes the time speed based on the day percentage.")]
		public AnimationCurve timeSpeedMultiplier;

		[Tooltip("Will the day move to the next day at 12:00 midnight")]
		public bool progressDay = true;

		[MonthList]
		public Month[] standardYear = new Month[12]
		{
			new Month
			{
				days = 31,
				name = "January"
			},
			new Month
			{
				days = 28,
				name = "Febraury"
			},
			new Month
			{
				days = 31,
				name = "March"
			},
			new Month
			{
				days = 30,
				name = "April"
			},
			new Month
			{
				days = 31,
				name = "May"
			},
			new Month
			{
				days = 30,
				name = "June"
			},
			new Month
			{
				days = 31,
				name = "July"
			},
			new Month
			{
				days = 31,
				name = "August"
			},
			new Month
			{
				days = 30,
				name = "September"
			},
			new Month
			{
				days = 31,
				name = "October"
			},
			new Month
			{
				days = 30,
				name = "Novemeber"
			},
			new Month
			{
				days = 31,
				name = "December"
			}
		};

		[MonthList]
		public Month[] leapYear = new Month[12]
		{
			new Month
			{
				days = 31,
				name = "January"
			},
			new Month
			{
				days = 29,
				name = "Febraury"
			},
			new Month
			{
				days = 31,
				name = "March"
			},
			new Month
			{
				days = 30,
				name = "April"
			},
			new Month
			{
				days = 31,
				name = "May"
			},
			new Month
			{
				days = 30,
				name = "June"
			},
			new Month
			{
				days = 31,
				name = "July"
			},
			new Month
			{
				days = 31,
				name = "August"
			},
			new Month
			{
				days = 30,
				name = "September"
			},
			new Month
			{
				days = 31,
				name = "October"
			},
			new Month
			{
				days = 30,
				name = "Novemeber"
			},
			new Month
			{
				days = 31,
				name = "December"
			}
		};

		public int daysPerYear = 48;

		public int GetRealisticDaysPerYear(int currentYear)
		{
			int num = 0;
			Month[] array = ((useLeapYear && currentYear % 4 == 0) ? leapYear : standardYear);
			foreach (Month month in array)
			{
				num += month.days;
			}
			return num;
		}
	}
}
