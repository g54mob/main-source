using System;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.BuiltIn;
using Febucci.TextAnimatorForUnity.Effects.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Febucci.TextAnimatorForUnity.Effects
{
	public abstract class ManagedEffectScriptable<TState, TStateParams> : ManagedEffectScriptable<TState, TStateParams, DefaultPhase, DefaultPhaseParams> where TState : struct, IEffectState
	{
		protected override DefaultPhase CreatePhase(DefaultPhaseParams parameters)
		{
			return new DefaultPhase(parameters.charOffset, parameters.wordOffset, parameters.speed);
		}
	}
	public abstract class ManagedEffectScriptable<TState, TStateParams, TPhase, TPhaseParams> : ManagedEffectScriptableBase where TState : struct, IEffectState where TPhase : struct, IEffectPhase
	{
		[Serializable]
		private sealed class EffectContentWrapper : IEffectContent
		{
			[SerializeField]
			internal TStateParams stateParams;

			[SerializeField]
			internal TPhaseParams phaseParams;

			[SerializeField]
			private EffectCurveScriptableBase stateCurve;

			[SerializeField]
			private EffectPlaybackScriptableBase playback;

			internal ManagedEffectScriptable<TState, TStateParams, TPhase, TPhaseParams> parent;

			public IEffectCurve StateCurve => stateCurve;

			public IEffectPlayback Playback => playback;

			public IEffectState CreateState()
			{
				return parent.CreateState(stateParams);
			}

			public IEffectPhase CreatePhase()
			{
				return parent.CreatePhase(phaseParams);
			}
		}

		[SerializeField]
		private string tagId;

		[SerializeField]
		private EffectPresetSettings effectSettings = new EffectPresetSettings
		{
			bakeCurves = true
		};

		[SerializeField]
		private EffectContentWrapper appearance;

		[SerializeField]
		[FormerlySerializedAs("persistant")]
		private EffectContentWrapper persistent;

		[SerializeField]
		private EffectContentWrapper disappearance;

		public override IEffectContent Appearance => appearance;

		public override IEffectContent Persistent => persistent;

		public override IEffectContent Disappearance => disappearance;

		public override EffectPresetSettings Settings => effectSettings;

		public override string TagID
		{
			get
			{
				return tagId;
			}
			set
			{
				tagId = value;
			}
		}

		private void OnEnable()
		{
			if (appearance != null)
			{
				appearance.parent = this;
			}
			if (persistent != null)
			{
				persistent.parent = this;
			}
			if (disappearance != null)
			{
				disappearance.parent = this;
			}
		}

		protected abstract TState CreateState(TStateParams parameters);

		protected abstract TPhase CreatePhase(TPhaseParams parameters);

		public override void Initialize()
		{
			OnEnable();
			base.Initialize();
		}
	}
}
