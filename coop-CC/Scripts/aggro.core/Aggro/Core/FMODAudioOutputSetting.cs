using FMODUnity;

namespace Aggro.Core
{
	public sealed class FMODAudioOutputSetting : AggroSettingBase
	{
		public int driverIndex { get; private set; }

		public override void SetToDefault()
		{
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
			RuntimeManager.CoreSystem.setDriver(driverIndex);
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
			RuntimeManager.CoreSystem.getDriver(out var driver);
			driverIndex = driver;
		}

		public void SetDriverIndex(int driverIndex)
		{
			this.driverIndex = driverIndex;
		}
	}
}
