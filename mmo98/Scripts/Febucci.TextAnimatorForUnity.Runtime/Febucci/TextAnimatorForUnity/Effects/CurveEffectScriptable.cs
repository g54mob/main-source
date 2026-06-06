using System;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.BuiltIn;
using Febucci.TextAnimatorForUnity.Effects.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Special/Curve", fileName = "Curve Effect")]
	internal sealed class CurveEffectScriptable : ManagedEffectScriptableBase
	{
		[Serializable]
		private class CurveEffectContent : IEffectContent
		{
			[SerializeField]
			private CurveEffectParameters state;

			[SerializeField]
			private DefaultPhaseParams phase;

			[SerializeField]
			private EffectPlaybackScriptableBase playback;

			[SerializeField]
			private EffectCurveScriptableBase curve;

			private static readonly Febucci.TextAnimatorCore.BuiltIn.LinearCurve FallbackCurve;

			public IEffectPlayback Playback => playback;

			public IEffectCurve StateCurve
			{
				get
				{
					if (!(curve != null))
					{
						return FallbackCurve;
					}
					return curve;
				}
			}

			public IEffectPhase CreatePhase()
			{
				return new DefaultPhase(phase.charOffset, phase.wordOffset, phase.speed);
			}

			public IEffectState CreateState()
			{
				return new CurveEffectState(state);
			}
		}

		[SerializeField]
		private string tagID;

		[SerializeField]
		private EffectPresetSettings settings;

		[SerializeField]
		private CurveEffectContent appearance;

		[SerializeField]
		private CurveEffectContent persistent;

		[SerializeField]
		private CurveEffectContent disappearance;

		public override string TagID
		{
			get
			{
				return tagID;
			}
			set
			{
				tagID = value;
			}
		}

		public override IEffectContent Appearance => appearance;

		public override IEffectContent Disappearance => disappearance;

		public override IEffectContent Persistent => persistent;

		public override EffectPresetSettings Settings => settings;
	}
}
