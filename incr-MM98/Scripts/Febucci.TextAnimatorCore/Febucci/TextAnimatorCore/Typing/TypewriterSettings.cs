using System;

namespace Febucci.TextAnimatorCore.Typing
{
	[Serializable]
	public abstract class TypewriterSettings
	{
		public bool useTypeWriter = true;

		public StartTypewriterMode startTypewriterMode = StartTypewriterMode.AutomaticallyFromAllEvents;

		public bool hideAppearancesOnSkip;

		public bool hideDisappearancesOnSkip;

		public bool triggerEventsOnSkip;

		public bool resetTypingSpeedAtStartup = true;

		public DisappearanceOrientation disappearanceOrientation;

		public bool triggerShowedAfterEffectsEnd;

		public bool triggerDisappearedAfterEffectsEnd;
	}
}
