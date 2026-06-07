using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class LevelSettingHunterRaidKillWorkers : LevelSetting
	{
		[field: SerializeField]
		public bool Invincible { get; set; }

		public override void Apply()
		{
			CTSSingleton<HunterRaid>.Instance.CanKillWorkers = !Invincible;
		}
	}
}
