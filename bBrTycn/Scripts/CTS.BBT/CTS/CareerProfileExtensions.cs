using System.Collections.Generic;
using CTS.Core;

namespace CTS
{
	public static class CareerProfileExtensions
	{
		public static int GetTotalMoney(this CareerProfile profile)
		{
			int num = 0;
			if ((bool)CTSSingleton<GameMode>.Instance && CTSSingleton<GameMode>.Instance.LevelInfo != null)
			{
				foreach (KeyValuePair<MapInfoSO, CareerProfile.LevelSave> item in profile.LevelProgress)
				{
					item.Deconstruct(out var key, out var value);
					MapInfoSO mapInfoSO = key;
					CareerProfile.LevelSave levelSave = value;
					num = ((!(mapInfoSO == CTSSingleton<GameMode>.Instance.LevelInfo)) ? (num + levelSave.Money) : (num + MonoSingleton<MoneyHandler>.Instance.CurrentMoney));
				}
			}
			else
			{
				foreach (CareerProfile.LevelSave value2 in profile.LevelProgress.Values)
				{
					num += value2.Money;
				}
			}
			return num;
		}
	}
}
