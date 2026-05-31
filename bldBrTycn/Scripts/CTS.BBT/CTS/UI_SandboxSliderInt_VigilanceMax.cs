namespace CTS
{
	public class UI_SandboxSliderInt_VigilanceMax : UI_SandboxIntSliderLevelSetting<LevelSettingsVigilanceData>
	{
		protected override int GetValue(LevelSettingsVigilanceData obj)
		{
			return obj.VigilanceForRaid;
		}

		protected override void SetValue(LevelSettingsVigilanceData obj, int value)
		{
			obj.VigilanceForRaid = value;
		}
	}
}
