namespace CTS
{
	public class UI_SandboxBool_UseCircumstancial : UI_SandboxBoolLevelSetting<LevelSettingsCircumstantialMissions>
	{
		protected override bool GetValue(LevelSettingsCircumstantialMissions obj)
		{
			return obj.UseMissions;
		}

		protected override void SetValue(LevelSettingsCircumstantialMissions obj, bool value)
		{
			obj.UseMissions = value;
		}
	}
}
