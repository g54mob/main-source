namespace CTS
{
	public class UI_SandboxBool_KillWorkers : UI_SandboxBoolLevelSetting<LevelSettingHunterRaidKillWorkers>
	{
		protected override bool GetValue(LevelSettingHunterRaidKillWorkers obj)
		{
			return obj.Invincible;
		}

		protected override void SetValue(LevelSettingHunterRaidKillWorkers obj, bool value)
		{
			obj.Invincible = value;
		}
	}
}
