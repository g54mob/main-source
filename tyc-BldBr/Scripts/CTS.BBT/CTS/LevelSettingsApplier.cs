using CTS.Core;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(10000)]
	public class LevelSettingsApplier : MonoBehaviour
	{
		public LevelSettingsList CustomSettings { get; set; }

		private void Awake()
		{
			MapInfoSO levelInfo = CTSSingleton<GameMode>.Instance.LevelInfo;
			LevelSettingsList.ClearKeys();
			CustomSettings?.ApplyAll();
			if (CTSSingleton<LevelSettings>.Instance.Settings.TryGetValue(levelInfo, out var value) && !(value == null))
			{
				if (value.ModeSettings.TryGetValue(GetCurrentGameMode(), out var value2))
				{
					value2.ApplyAll();
				}
				if ((bool)value.BaseSettings)
				{
					value.BaseSettings.ApplyAll();
				}
			}
		}

		private EGameMode GetCurrentGameMode()
		{
			return GameMode.StartMode;
		}
	}
}
