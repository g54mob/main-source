using UnityEngine;

namespace Aggro.Core
{
	public sealed class FullScreenModeSetting : AggroSettingBase
	{
		public FullScreenMode mode { get; private set; }

		public override void SetToDefault()
		{
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
			Screen.SetResolution(Screen.width, Screen.height, mode);
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
			mode = Screen.fullScreenMode;
		}

		public void SetMode(FullScreenMode mode)
		{
			this.mode = mode;
		}
	}
}
