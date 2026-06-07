using System;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Styles;
using Febucci.TextAnimatorCore.Typing;

namespace Febucci.TextAnimatorCore.Settings
{
	[Serializable]
	public abstract class GlobalSettingsBase
	{
		public bool isAnimatingAppearances = true;

		public bool isAnimatingDisappearances = true;

		public bool isAnimatingBehaviors = true;

		public ParsingInfo parsingBehaviors = new ParsingInfo('<', '>');

		public ParsingInfo parsingAppearances = new ParsingInfo('{', '}');

		public ParsingInfo parsingDisappearances = new ParsingInfo('{', '}', '#');

		public abstract IEffectCurve FallbackStateCurve { get; }

		public abstract IEffectPlayback FallbackPlayback { get; }

		public abstract IDatabaseProvider<IEffectPlayback> GlobalPlaybacksDatabase { get; }

		public abstract IDatabaseProvider<IEffect> GlobalEffectsDatabase { get; }

		public abstract IDatabaseProvider<ITypewriterAction> GlobalActionsDatabase { get; }

		public abstract IDatabaseProvider<Style> GlobalStyleSheet { get; }
	}
}
