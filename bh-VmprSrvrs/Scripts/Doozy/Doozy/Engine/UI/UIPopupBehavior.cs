using System;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIPopupBehavior
	{
		public const bool DEFAULT_INSTANT_ANIMATION = false;

		public const bool DEFAULT_LOAD_SELECTED_PRESET_AT_RUNTIME = false;

		public UIAnimation Animation;

		public bool LoadSelectedPresetAtRuntime;

		public bool InstantAnimation;

		public UIAction OnFinished;

		public UIAction OnStart;

		public string PresetCategory;

		public string PresetName;

		private float m_progress;

		public static string DefaultPresetCategory => null;

		public static string DefaultPresetName => null;

		public bool HasAnimation => false;

		public bool HasAnimatorEvents => false;

		public bool HasEffect => false;

		public bool HasGameEvents => false;

		public bool HasSound => false;

		public bool HasUnityEvents => false;

		public UIPopupBehavior(AnimationType animationType)
		{
		}

		public void LoadPreset()
		{
		}

		public void LoadPreset(string presetCategory, string presetName)
		{
		}

		public void Reset(AnimationType animationType)
		{
		}
	}
}
