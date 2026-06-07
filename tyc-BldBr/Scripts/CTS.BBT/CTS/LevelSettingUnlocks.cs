using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Package Unlocks")]
	public class LevelSettingUnlocks : LevelSetting
	{
		[SerializeField]
		private EUnlockKey _keys;

		public override void Apply()
		{
			UnlockingManager.AddUnlockKey(_keys);
		}
	}
}
