namespace CTS
{
	public class UI_SandboxInt_Money : UI_SandboxIntSliderLevelSetting<LevelSettingBaseMoney>
	{
		protected override int GetValue(LevelSettingBaseMoney obj)
		{
			return obj.Money;
		}

		protected override void SetValue(LevelSettingBaseMoney obj, int value)
		{
			obj.Money = value;
		}
	}
}
