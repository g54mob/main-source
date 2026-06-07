using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	public static class ApplicationOptionsManager
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Load()
		{
			CustomSettings<GameplayApplicationOptions>.I.Load();
			CustomSettings<GraphicsApplicationOptions>.I.Load();
			CustomSettings<AudioApplicationOptions>.I.Load();
			CustomSettings<ControlsApplicationOptions>.I.Load();
			CustomSettings<AccessibilityApplicationOptions>.I.Load();
		}

		public static void Reset()
		{
			CustomSettings<GameplayApplicationOptions>.I.ResetSettings();
			CustomSettings<GraphicsApplicationOptions>.I.ResetSettings();
			CustomSettings<AudioApplicationOptions>.I.ResetSettings();
			CustomSettings<ControlsApplicationOptions>.I.ResetSettings();
			CustomSettings<AccessibilityApplicationOptions>.I.ResetSettings();
		}
	}
}
