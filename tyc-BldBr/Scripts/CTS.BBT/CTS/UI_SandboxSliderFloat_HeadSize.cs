namespace CTS
{
	public class UI_SandboxSliderFloat_HeadSize : UI_SandboxFloatSliderLevelSetting<LevelSettingsHeadSize>
	{
		protected override float GetValue(LevelSettingsHeadSize obj)
		{
			return obj.HeadSize;
		}

		protected override void SetValue(LevelSettingsHeadSize obj, float value)
		{
			obj.HeadSize = value;
		}
	}
}
