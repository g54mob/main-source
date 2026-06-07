using System;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Styles;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorForUnity.Actions;
using Febucci.TextAnimatorForUnity.Effects;
using Febucci.TextAnimatorForUnity.Styles;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	public class UnityGlobalSettings : GlobalSettingsBase
	{
		[SerializeField]
		private EffectPlaybackScriptableBase fallbackPlayback;

		[SerializeField]
		private EffectCurveScriptableBase fallbackStateCurve;

		[SerializeField]
		private AnimationsDatabase globalEffectsDatabase;

		[SerializeField]
		private ActionDatabase globalActionsDatabase;

		[SerializeField]
		private StyleSheetScriptable globalStyleSheet;

		[SerializeField]
		private PlaybacksDatabase globalPlaybacksDatabase;

		public override IEffectPlayback FallbackPlayback => fallbackPlayback;

		public override IEffectCurve FallbackStateCurve => fallbackStateCurve;

		public override IDatabaseProvider<IEffect> GlobalEffectsDatabase => globalEffectsDatabase;

		public override IDatabaseProvider<ITypewriterAction> GlobalActionsDatabase => globalActionsDatabase;

		public override IDatabaseProvider<Style> GlobalStyleSheet => globalStyleSheet;

		public override IDatabaseProvider<IEffectPlayback> GlobalPlaybacksDatabase => globalPlaybacksDatabase;
	}
}
