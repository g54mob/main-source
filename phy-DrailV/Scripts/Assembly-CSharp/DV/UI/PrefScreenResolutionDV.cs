using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class PrefScreenResolutionDV : PreferenceValues<int>
	{
		public PrefScreenResolutionDV(string name, int defaultValue, int initialValue)
			: base(name, defaultValue, initialValue)
		{
		}

		public override void Apply()
		{
			ScreenResolutionOptions instance = SingletonBehaviour<ScreenResolutionOptions>.Instance;
			int num = instance.SupportedResolutions.Length - 1;
			if (latestValue < 0 || latestValue > num)
			{
				Debug.LogWarning($"Selected screen resolution index {(object)latestValue} is out of range [0-{num}], clamping it to avoid error.");
				latestValue = Mathf.Clamp(latestValue, 0, num);
			}
			Vector2Int vector2Int = instance.SupportedResolutions[(int)latestValue];
			Debug.Log($"Setting preference for resolution to {vector2Int.x}x{vector2Int.y}");
			GamePreferences.Set(Preferences.ScreenResolutionWidth, vector2Int.x);
			GamePreferences.Set(Preferences.ScreenResolutionHeight, vector2Int.y);
			base.Apply();
		}
	}
}
