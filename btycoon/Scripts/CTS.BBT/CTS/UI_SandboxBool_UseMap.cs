namespace CTS
{
	public class UI_SandboxBool_UseMap : UI_SandboxBoolLevelSetting<LevelSettingsUseMapLoader>
	{
		protected override bool GetValue(LevelSettingsUseMapLoader obj)
		{
			return obj.UseMap;
		}

		protected override void SetValue(LevelSettingsUseMapLoader obj, bool value)
		{
			obj.UseMap = value;
		}
	}
}
