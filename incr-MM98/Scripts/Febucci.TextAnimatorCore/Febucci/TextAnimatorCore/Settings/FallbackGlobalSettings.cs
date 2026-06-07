using Febucci.TextAnimatorCore.BuiltIn;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Styles;
using Febucci.TextAnimatorCore.Typing;

namespace Febucci.TextAnimatorCore.Settings
{
	internal sealed class FallbackGlobalSettings : GlobalSettingsBase
	{
		public override IEffectCurve FallbackStateCurve { get; } = default(SineCurve);

		public override IEffectPlayback FallbackPlayback { get; } = new SimplePlayback
		{
			stillDuration = 1f
		};

		public override IDatabaseProvider<IEffectPlayback> GlobalPlaybacksDatabase => null;

		public override IDatabaseProvider<IEffect> GlobalEffectsDatabase => null;

		public override IDatabaseProvider<ITypewriterAction> GlobalActionsDatabase => null;

		public override IDatabaseProvider<Style> GlobalStyleSheet => null;
	}
}
