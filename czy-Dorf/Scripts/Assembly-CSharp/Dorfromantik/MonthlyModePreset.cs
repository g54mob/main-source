using System;
using System.Collections.Generic;

namespace Dorfromantik
{
	public class MonthlyModePreset : GameModePreset
	{
		private Dictionary<string, string> configStringByMonth = new Dictionary<string, string> { { "202203", "000000" } };

		public override string GetConfigString()
		{
			string key = DateTime.Now.ToString("yyyyMM");
			if (configStringByMonth.ContainsKey(key))
			{
				return configStringByMonth[key];
			}
			return "0";
		}

		public override int GetSeed()
		{
			return DateTime.Now.Year * 10 + DateTime.Now.Month;
		}
	}
}
