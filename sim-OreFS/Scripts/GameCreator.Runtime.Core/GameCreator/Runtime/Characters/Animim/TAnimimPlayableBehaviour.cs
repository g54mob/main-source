using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace GameCreator.Runtime.Characters.Animim
{
	public abstract class TAnimimPlayableBehaviour : PlayableBehaviour
	{
		private const string RTC_PATH = "GameCreator/AnimationClip";

		private static RuntimeAnimatorController RTC_ANIMATION;

		[NonSerialized]
		public Playable scriptPlayable;

		[NonSerialized]
		public AnimationLayerMixerPlayable mixerPlayable;

		[NonSerialized]
		protected readonly AvatarMask m_AvatarMask;

		[NonSerialized]
		protected readonly BlendMode m_BlendMode;

		[NonSerialized]
		protected readonly AnimimGraph m_AnimimGraph;

		[NonSerialized]
		protected readonly IConfig m_Config;

		[NonSerialized]
		private TAnimimOutput m_ParentOutput;

		[field: NonSerialized]
		protected AnimatorControllerPlayable AnimatorPlayable { get; set; }

		[field: NonSerialized]
		protected AnimFloat Weight { get; }

		[field: NonSerialized]
		protected double StartTime { get; }

		[field: NonSerialized]
		protected double ElapsedTime { get; private set; }

		[field: NonSerialized]
		protected EnablerFloat Duration { get; private set; }

		[field: NonSerialized]
		public bool IsComplete { get; private set; }

		[field: NonSerialized]
		public bool IsInDelay { get; private set; }

		public float CurrentWeight => Weight.Current;

		public float RootMotion
		{
			get
			{
				IConfig config = m_Config;
				if (config == null || !config.RootMotion)
				{
					return 0f;
				}
				return Weight.Current;
			}
		}

		public float Speed
		{
			get
			{
				return m_Config.Speed;
			}
			set
			{
				m_Config.Speed = value;
			}
		}

		protected TAnimimPlayableBehaviour(AvatarMask avatarMask, BlendMode blendMode, AnimimGraph animimGraph, IConfig config)
		{
			m_AvatarMask = avatarMask;
			m_BlendMode = blendMode;
			m_AnimimGraph = animimGraph;
			m_Config = config;
			StartTime = animimGraph.Character.Time.TimeAsDouble;
			ElapsedTime = 0.0;
			Weight = new AnimFloat(0f, m_Config.TransitionIn);
			Duration = new EnablerFloat(isEnabled: false, -1f);
			IsInDelay = true;
			IsComplete = false;
		}

		public override void OnPlayableCreate(Playable playable)
		{
			base.OnPlayableCreate(playable);
			scriptPlayable = playable;
			playable.SetSpeed(Speed);
			if (m_Config.Duration > float.Epsilon)
			{
				Duration.IsEnabled = true;
				Duration.Value = m_Config.Duration;
			}
		}

		public override void PrepareFrame(Playable playable, FrameData info)
		{
			base.PrepareFrame(playable, info);
			playable.SetSpeed(m_Config.Speed);
			UpdateFrame(ref playable);
			playable.GetInput(0).SetInputWeight(1, Weight.Current);
			if (playable.IsDone())
			{
				Playable input = playable.GetInput(0);
				Playable input2 = input.GetInput(0);
				Playable output = playable.GetOutput(0);
				input.DisconnectInput(0);
				output.DisconnectInput(0);
				output.ConnectInput(0, input2, 0);
				output.SetInputWeight(0, 1f);
				playable.Destroy();
				m_ParentOutput.OnDeleteChild(this);
				IsComplete = true;
			}
			if (AnimatorPlayable.IsValid() && !AnimatorPlayable.IsDone())
			{
				for (int i = 0; i < Phases.Count; i++)
				{
					float value = AnimatorPlayable.GetFloat(Phases.HASH_PHASES[i]);
					m_AnimimGraph.Phases.Set(i, value, Weight.Current);
				}
			}
		}

		private void UpdateFrame(ref Playable playable)
		{
			TimeMode time = m_AnimimGraph.Character.Time;
			if (time.TimeAsDouble - StartTime < (double)m_Config.DelayIn)
			{
				AnimatorPlayable.Pause();
				IsInDelay = true;
			}
			else
			{
				AnimatorPlayable.Play();
				IsInDelay = false;
				Weight.Target = m_Config.Weight;
				Weight.Smooth = m_Config.TransitionIn / m_Config.Speed;
				ElapsedTime += time.DeltaTime * m_Config.Speed;
			}
			if (m_Config.Duration > float.Epsilon)
			{
				float num = Math.Max(m_Config.Duration - m_Config.TransitionOut, m_Config.TransitionIn);
				if (ElapsedTime >= (double)num)
				{
					Weight.Target = 0f;
					Weight.Smooth = m_Config.TransitionOut / m_Config.Speed;
				}
			}
			Weight.UpdateWithDelta(time.DeltaTime);
			if (Duration.IsEnabled && ElapsedTime >= (double)Duration.Value)
			{
				playable.SetDone(value: true);
			}
		}

		public void Create(TAnimimOutput parentOutput)
		{
			m_ParentOutput = parentOutput;
			Playable input = scriptPlayable.GetInput(0);
			scriptPlayable.DisconnectInput(0);
			mixerPlayable = AnimationLayerMixerPlayable.Create(m_AnimimGraph.Graph, 2);
			mixerPlayable.ConnectInput(0, input, 0);
			mixerPlayable.ConnectInput(1, AnimatorPlayable, 0);
			scriptPlayable.ConnectInput(0, mixerPlayable, 0);
			scriptPlayable.SetInputWeight(0, 1f);
			if (m_AvatarMask != null)
			{
				mixerPlayable.SetLayerMaskFromAvatarMask(1u, m_AvatarMask);
			}
			mixerPlayable.SetLayerAdditive(1u, m_BlendMode == BlendMode.Additive);
			mixerPlayable.SetInputWeight(0, 1f);
			mixerPlayable.SetInputWeight(1, 0f);
		}

		public void Stop()
		{
			Stop(0f, m_Config.TransitionOut);
		}

		public virtual void Stop(float delay, float transitionOut)
		{
			if (IsInDelay)
			{
				AnimatorPlayable.SetDone(value: true);
				delay = 0f;
				transitionOut = 0f;
			}
			float num = (float)ElapsedTime + delay + transitionOut;
			m_Config.Duration = num;
			m_Config.TransitionOut = transitionOut;
			Duration.IsEnabled = true;
			Duration.Value = num;
		}

		public void ChangeWeight(float weight, float transition)
		{
			m_Config.Weight = weight;
			m_Config.TransitionIn = transition;
		}

		protected static AnimatorOverrideController CreateController(AnimationClip animationClip)
		{
			if (RTC_ANIMATION == null)
			{
				RTC_ANIMATION = Resources.Load<RuntimeAnimatorController>("GameCreator/AnimationClip");
			}
			return new AnimatorOverrideController(RTC_ANIMATION) { [RTC_ANIMATION.animationClips[0].name] = animationClip };
		}
	}
}
