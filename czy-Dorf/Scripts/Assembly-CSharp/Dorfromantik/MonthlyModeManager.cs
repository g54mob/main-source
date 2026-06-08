using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class MonthlyModeManager : ScriptableObject
	{
		[SerializeField]
		private CustomModeConfiguration customModeConfiguration;

		private Dictionary<int, Dictionary<int, string>> configStringByYearAndMonth = new Dictionary<int, Dictionary<int, string>> { 
		{
			2022,
			new Dictionary<int, string>
			{
				{ 1, "BDC7Db-1b2mkZ-0JNmtZ" },
				{ 2, "022022-1ntG32-1GK2cf" },
				{ 3, "9S8T2K-0cxCJz-1Bn6PQ" },
				{ 4, "6D338f-1b58pM-1G1ygz" },
				{ 5, "4LkmZj-1YjBYd-16d2Jq" },
				{ 6, "7ysMdd-1b52R9-0JFDPk" },
				{ 7, "Cxm4SZ-2fJmCw-2gRsn6" },
				{ 8, "4NyHtb-0cxQFZ-1rZgBb" },
				{ 9, "Cxm4SZ-2cs70X-2RcnMf" },
				{ 10, "1KzrZV-1b5909-1Gc6YL" },
				{ 11, "3gwVKj-0XSmt9-2jqTFb" },
				{ 12, "52mZsC-127CCK-0JNmtZ" }
			}
		} };

		public string GetCurrentConfigString()
		{
			int key = customModeConfiguration.year;
			int num = customModeConfiguration.month;
			bool flag = false;
			if (!configStringByYearAndMonth.ContainsKey(key))
			{
				key = 2022;
				flag = true;
			}
			if (!configStringByYearAndMonth[key].ContainsKey(num))
			{
				num %= configStringByYearAndMonth[key].Count;
				flag = true;
			}
			string text = configStringByYearAndMonth[key][num];
			if (flag)
			{
				text = $"{customModeConfiguration.month:00}{customModeConfiguration.year:0000}{text.Substring(6, text.Length - 6)}";
			}
			return text;
		}

		public bool HasConfigurationFor(int year, int month)
		{
			if (!configStringByYearAndMonth.ContainsKey(year))
			{
				return false;
			}
			if (!configStringByYearAndMonth[year].ContainsKey(month))
			{
				return false;
			}
			return true;
		}

		public int GetCurrentLocalSwitchSeason(bool useActualTime = false)
		{
			if (useActualTime)
			{
				DateTime now = DateTime.Now;
				return DateToSwitchSeason(now.Year, now.Month);
			}
			return DateToSwitchSeason(customModeConfiguration.year, customModeConfiguration.month);
		}

		public int DateToSwitchSeason(int year, int month)
		{
			return (year - 2022) * 12 + month - 8;
		}

		public int[] SwitchSeasonToDate(int switchSeason)
		{
			return new int[2]
			{
				Mathf.FloorToInt(switchSeason) + 2022,
				(switchSeason + 7) % 12 + 1
			};
		}
	}
}
