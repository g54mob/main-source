using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(10)]
	public class UI_SandboxSliderFloat_InitialAwareness : UI_SandboxFloatSliderLevelSetting<LevelSettingBaseAwareness>
	{
		protected override float GetValue(LevelSettingBaseAwareness obj)
		{
			return obj.Percent;
		}

		protected override void SetValue(LevelSettingBaseAwareness obj, float value)
		{
			obj.Percent = value;
		}
	}
}
