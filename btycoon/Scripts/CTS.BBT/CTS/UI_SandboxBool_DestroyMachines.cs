namespace CTS
{
	public class UI_SandboxBool_DestroyMachines : UI_SandboxBoolLevelSetting<LevelSettingHunterRaidDestroyMachines>
	{
		protected override bool GetValue(LevelSettingHunterRaidDestroyMachines obj)
		{
			return obj.Enabled;
		}

		protected override void SetValue(LevelSettingHunterRaidDestroyMachines obj, bool value)
		{
			obj.Enabled = value;
		}
	}
}
