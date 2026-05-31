using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Interim Refresh Timer")]
	public class LevelSettingInterimRefreshTimer : LevelSetting
	{
		[SerializeField]
		private int _refreshCooldown = 10;

		public override void Apply()
		{
			MonoSingleton<InterimAgency>.Instance.SetRefreshCooldown(_refreshCooldown);
		}
	}
}
