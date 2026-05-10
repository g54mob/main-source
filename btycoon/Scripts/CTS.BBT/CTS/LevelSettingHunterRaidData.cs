using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Hunter Raid Data")]
	public class LevelSettingHunterRaidData : LevelSetting
	{
		[SerializeField]
		[Expandable]
		private HunterRaidData _raidData;

		public override void Apply()
		{
			CTSSingleton<HunterRaid>.Instance.SetRaidData(_raidData);
		}
	}
}
