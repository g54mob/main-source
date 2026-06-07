using System;
using System.Linq;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Challenge Years", menuName = "Motorways/Challenges/Year Of Challenges", order = 2)]
	public class YearOfChallenges : ScriptableObject
	{
		public ulong seed;

		public int year = 2022;

		public MonthOfDailyChallenges[] monthsOfDailyChallenges = new MonthOfDailyChallenges[12];

		public PrecalculatedTimedChallengeData[] weeklyChallenges = new PrecalculatedTimedChallengeData[52];

		public DateTime MondayOfFirstWeek
		{
			get
			{
				DateTime result = new DateTime(year, 1, 1);
				if (result.DayOfWeek == DayOfWeek.Monday)
				{
					return result;
				}
				int num = (int)(result.DayOfWeek - 1);
				num = (num % 7 + 7) % 7;
				return result.AddDays(7 - num);
			}
		}

		public PrecalculatedTimedChallengeData GetChallengesOnDay(DateTime dateTime)
		{
			MonthOfDailyChallenges monthOfDailyChallenges;
			if (Diagnostics.Verify(monthsOfDailyChallenges.Length >= dateTime.Month, "There are only {0} months' of challenges, and current month is {1}", monthsOfDailyChallenges.Length, dateTime.Month))
			{
				monthOfDailyChallenges = monthsOfDailyChallenges[dateTime.Month - 1];
			}
			else if (Diagnostics.Verify(monthsOfDailyChallenges.Length != 0, "No challenge months at all!! Returning empty challenge object."))
			{
				monthOfDailyChallenges = monthsOfDailyChallenges.Last();
			}
			else
			{
				monthOfDailyChallenges = new MonthOfDailyChallenges();
				monthOfDailyChallenges.dailyChallenges = new PrecalculatedTimedChallengeData[1]
				{
					new PrecalculatedTimedChallengeData
					{
						name = "Fallback Challenge",
						city = MapDefinition.CityNames.Wellington,
						challenges = Array.Empty<ChallengeData>()
					}
				};
			}
			if (Diagnostics.Verify(monthOfDailyChallenges.dailyChallenges.Length >= dateTime.Day, "No challenges found for day {0} of month {1}!", dateTime.Day, dateTime.Month))
			{
				return monthOfDailyChallenges.dailyChallenges[dateTime.Day - 1];
			}
			if (Diagnostics.Verify(monthOfDailyChallenges.dailyChallenges.Length != 0))
			{
				return monthOfDailyChallenges.dailyChallenges.Last();
			}
			return new PrecalculatedTimedChallengeData
			{
				name = "Fallback Challenge",
				city = MapDefinition.CityNames.Wellington,
				challenges = Array.Empty<ChallengeData>()
			};
		}

		public PrecalculatedTimedChallengeData GetChallengesOnWeekOfDay(DateTime dateTime)
		{
			if (Diagnostics.Verify(dateTime >= MondayOfFirstWeek, "Trying to get a weekly challenge of a day before the first monday of the year!"))
			{
				int num = dateTime.DayOfYear - MondayOfFirstWeek.DayOfYear;
				int num2 = num / 7;
				if (Diagnostics.Verify(num2 < weeklyChallenges.Length, "Somehow calculated {0} as the week index? Had {1} days between {2} and {3}", num2, num, dateTime, MondayOfFirstWeek))
				{
					return weeklyChallenges[num2];
				}
				return weeklyChallenges[weeklyChallenges.Length - 1];
			}
			return weeklyChallenges[0];
		}
	}
}
