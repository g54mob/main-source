using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations;

namespace GameCreator.Runtime.Characters.Animim
{
	public sealed class StatePlayableBehaviour : TAnimimPlayableBehaviour
	{
		[field: NonSerialized]
		public int Layer { get; }

		[field: NonSerialized]
		public State State { get; }

		[field: NonSerialized]
		public bool IsExiting { get; private set; }

		[field: NonSerialized]
		public bool IsEntryClipComplete { get; private set; }

		[field: NonSerialized]
		public bool IsExitClipComplete { get; private set; }

		public StatePlayableBehaviour(AnimationClip animationClip, AvatarMask avatarMask, int layer, BlendMode blendMode, AnimimGraph animimGraph, ConfigState config)
			: base(avatarMask, blendMode, animimGraph, config)
		{
			State = null;
			Layer = layer;
			IsExiting = false;
			IsEntryClipComplete = true;
			IsExitClipComplete = false;
			base.AnimatorPlayable = AnimatorControllerPlayable.Create(animimGraph.Graph, TAnimimPlayableBehaviour.CreateController(animationClip));
		}

		public StatePlayableBehaviour(RuntimeAnimatorController rtc, AvatarMask avatarMask, int layer, BlendMode blendMode, AnimimGraph animimGraph, ConfigState config)
			: base(avatarMask, blendMode, animimGraph, config)
		{
			State = null;
			Layer = layer;
			IsExiting = false;
			IsEntryClipComplete = true;
			IsExitClipComplete = false;
			base.AnimatorPlayable = AnimatorControllerPlayable.Create(animimGraph.Graph, rtc);
		}

		public StatePlayableBehaviour(State state, int layer, BlendMode blendMode, AnimimGraph animimGraph, ConfigState config)
			: base(state.StateMask, blendMode, animimGraph, config)
		{
			IsExiting = false;
			IsEntryClipComplete = true;
			IsExitClipComplete = false;
			if (state.HasEntryClip)
			{
				IsEntryClipComplete = false;
				PlayEntryClip(animimGraph, state, config);
				m_Config.TransitionIn = 0f;
				m_Config.DelayIn += config.TransitionIn + 0.01f;
			}
			State = state;
			Layer = layer;
			base.AnimatorPlayable = AnimatorControllerPlayable.Create(animimGraph.Graph, state.StateController);
		}

		public StatePlayableBehaviour()
			: base(null, BlendMode.Blend, null, null)
		{
		}

		public override void Stop(float delay, float transitionOut)
		{
			IsExiting = true;
			if (State != null && State.HasEntryClip)
			{
				m_AnimimGraph.Gestures.Stop(State.EntryClip, delay, transitionOut);
			}
			if (State != null && State.HasExitClip)
			{
				PlayExitClip(new ConfigGesture(delay, State.ExitClip.length, 1f, State.ExitRootMotion, transitionOut, transitionOut));
				delay += transitionOut + 0.01f;
				transitionOut = 0f;
			}
			base.Stop(delay, transitionOut);
		}

		private async Task PlayEntryClip(AnimimGraph animimGraph, State state, ConfigState config)
		{
			await animimGraph.Gestures.CrossFade(state.EntryClip, state.EntryMask, m_BlendMode, new ConfigGesture(config.DelayIn, state.EntryClip.length, 1f, state.EntryRootMotion, config.TransitionIn, config.TransitionIn), stopPreviousGestures: false);
			IsEntryClipComplete = true;
		}

		private async Task PlayExitClip(ConfigGesture config)
		{
			await m_AnimimGraph.Gestures.CrossFade(State.ExitClip, State.ExitMask, m_BlendMode, config, stopPreviousGestures: false);
			IsExitClipComplete = true;
		}
	}
}
