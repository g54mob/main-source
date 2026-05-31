using UnityEngine;

namespace CTS
{
	public abstract class UI_SandboxFloatSliderLevelSetting<TSetting> : UI_SandboxFloatSlider<TSetting> where TSetting : LevelSetting
	{
		protected override TSetting GetObject()
		{
			if (!_profileCreator.Settings.TryGet<TSetting>(out var outSetting))
			{
				outSetting = ScriptableObject.CreateInstance<TSetting>();
				_profileCreator.Settings.AddSetting(outSetting);
			}
			return outSetting;
		}
	}
}
