namespace CTS
{
	public class UI_SandboxSliderInt_BaseTechPoints : UI_SandboxIntSliderLevelSetting<LevelSettingBaseTechPoints>
	{
		protected override int GetValue(LevelSettingBaseTechPoints obj)
		{
			return obj.Value;
		}

		protected override void SetValue(LevelSettingBaseTechPoints obj, int value)
		{
			obj.Value = value;
		}
	}
}
