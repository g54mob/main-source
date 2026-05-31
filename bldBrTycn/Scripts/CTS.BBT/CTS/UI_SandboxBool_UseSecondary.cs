namespace CTS
{
	public class UI_SandboxBool_UseSecondary : UI_SandboxBoolLevelSetting<LevelSettingsSecondaryMissions>
	{
		protected override bool GetValue(LevelSettingsSecondaryMissions obj)
		{
			return obj.UseMissions;
		}

		protected override void SetValue(LevelSettingsSecondaryMissions obj, bool value)
		{
			obj.UseMissions = value;
		}
	}
}
