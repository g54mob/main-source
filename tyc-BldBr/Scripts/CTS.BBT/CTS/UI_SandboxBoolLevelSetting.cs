using UnityEngine;

namespace CTS
{
	public abstract class UI_SandboxBoolLevelSetting<T> : UI_SandboxBool<T> where T : LevelSetting
	{
		protected override T GetObject()
		{
			if (!_profileCreator.Settings.TryGet<T>(out var outSetting))
			{
				outSetting = ScriptableObject.CreateInstance<T>();
				_profileCreator.Settings.AddSetting(outSetting);
			}
			return outSetting;
		}
	}
}
