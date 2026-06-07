using System;
using Febucci.TextAnimatorCore.Time;

namespace Febucci.TextAnimatorCore.Settings
{
	[Serializable]
	public class AnimatorSettings
	{
		public bool isResettingTimeOnNewText = true;

		public DefaultEffectsMode defaultEffectsMode = DefaultEffectsMode.Constant;

		public TimeScale timeScale;

		public string[] defaultBehaviorTags;

		public string[] defaultAppearanceTags;

		public string[] defaultDisappearanceTags;

		public bool isAnimatingBehaviors = true;

		public bool isAnimatingAppearances = true;

		public bool isAnimatingDisappearances = true;

		public bool useDynamicScaling = true;

		public float referenceFontSize = 12f;
	}
}
