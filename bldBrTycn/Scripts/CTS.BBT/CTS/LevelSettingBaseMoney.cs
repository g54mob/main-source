using CTS.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Base Money")]
	public class LevelSettingBaseMoney : LevelSetting
	{
		[field: FormerlySerializedAs("_money")]
		[field: SerializeField]
		public int Money { get; set; }

		public override void Apply()
		{
			if (GameMode.IsNewGame)
			{
				MonoSingleton<MoneyHandler>.Instance.SetStartingMoneyWithDifficulty(Money);
			}
		}
	}
}
