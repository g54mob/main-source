using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class LevelSettingHunterRaidDestroyMachines : LevelSetting
	{
		[field: SerializeField]
		public bool Enabled { get; set; } = true;

		public override void Apply()
		{
			CTSSingleton<HunterRaid>.Instance.CanDestroyMachines = Enabled;
		}
	}
}
