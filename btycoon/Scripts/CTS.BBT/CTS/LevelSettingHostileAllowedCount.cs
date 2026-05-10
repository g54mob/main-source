using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Hostile Allowed Count")]
	public class LevelSettingHostileAllowedCount : LevelSetting
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float _allowedPercent;

		public override void Apply()
		{
			CTSSingleton<HostileCharacterSpawner>.Instance.SetAllowedCount(_allowedPercent);
		}
	}
}
