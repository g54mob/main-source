namespace CTS
{
	public class UI_SandboxBool_BaseStock : UI_SandboxBoolLevelSetting<LevelSettingsUseBaseStock>
	{
		protected override bool GetValue(LevelSettingsUseBaseStock obj)
		{
			return obj.UseBaseStorage;
		}

		protected override void SetValue(LevelSettingsUseBaseStock obj, bool value)
		{
			obj.UseBaseStorage = value;
		}
	}
}
