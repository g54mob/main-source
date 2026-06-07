using UnityEngine;

namespace CTS.ScriptableSettings
{
	[CreateAssetMenu(menuName = "CTS/Settings/Target Framerate Prefs Setting")]
	public class TargetFramerateSetting : IntSetting
	{
		public override string GetCurrentValueName()
		{
			if (_currentValue <= 0)
			{
				return "Uncapped";
			}
			return base.GetCurrentValueName();
		}
	}
}
