using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Habits/Habits Year", order = 361)]
	public class HabitsYearProfile : ScriptableObject
	{
		[Serializable]
		public struct Month
		{
			public string displayName;

			public int daysInMonth;
		}

		public List<CozyHabitProfile> events = new List<CozyHabitProfile>();

		public CozyHabits.Weekday startDay;

		public List<Month> months;

		public int GetDayOfMonth(int day)
		{
			int result = day;
			int num = 0;
			while (day > months[num].daysInMonth)
			{
				day -= months[num].daysInMonth;
				num++;
				if (num == months.Count)
				{
					num = 0;
				}
			}
			return result;
		}

		public int GetYearLength()
		{
			int num = 0;
			foreach (Month month in months)
			{
				num += month.daysInMonth;
			}
			return num;
		}
	}
}
