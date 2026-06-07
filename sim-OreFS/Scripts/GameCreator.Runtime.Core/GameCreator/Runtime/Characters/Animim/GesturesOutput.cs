using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Playables;

namespace GameCreator.Runtime.Characters.Animim
{
	public class GesturesOutput : TAnimimOutput
	{
		[NonSerialized]
		private readonly List<GesturePlayableBehaviour> m_ActiveList;

		internal override float RootMotion
		{
			get
			{
				float num = 0f;
				foreach (GesturePlayableBehaviour active in m_ActiveList)
				{
					num = Math.Max(num, active.RootMotion);
				}
				return num;
			}
		}

		public bool IsPlaying => m_ActiveList.Count > 0;

		public float CurrentWeight
		{
			get
			{
				if (!IsPlaying)
				{
					return 0f;
				}
				return m_ActiveList[0].CurrentWeight;
			}
		}

		public GesturesOutput(AnimimGraph animimGraph)
			: base(animimGraph)
		{
			m_ActiveList = new List<GesturePlayableBehaviour>();
		}

		public GesturesOutput()
			: base(null)
		{
			m_ActiveList = new List<GesturePlayableBehaviour>();
		}

		public async Task CrossFade(AnimationClip animationClip, AvatarMask avatarMask, BlendMode blendMode, ConfigGesture config, bool stopPreviousGestures)
		{
			GesturePlayableBehaviour template = new GesturePlayableBehaviour(animationClip, avatarMask, blendMode, m_AnimimGraph, config);
			ScriptPlayable<GesturePlayableBehaviour> gesturePlayable = ScriptPlayable<GesturePlayableBehaviour>.Create(m_AnimimGraph.Graph, template, 1);
			GesturePlayableBehaviour behavior = Play(ref gesturePlayable, config, stopPreviousGestures);
			while (!behavior.IsComplete && !ApplicationManager.IsExiting)
			{
				await Task.Yield();
			}
		}

		public void Stop(float delay, float transitionOut)
		{
			foreach (GesturePlayableBehaviour active in m_ActiveList)
			{
				active.Stop(delay, transitionOut);
			}
		}

		public void Stop(AnimationClip animationClip, float delay, float transitionOut)
		{
			if (animationClip == null)
			{
				return;
			}
			int hashCode = animationClip.GetHashCode();
			foreach (GesturePlayableBehaviour active in m_ActiveList)
			{
				if (active.AnimationClipHash == hashCode)
				{
					active.Stop(delay, transitionOut);
				}
			}
		}

		public void SetSpeed(AnimationClip animationClip, float speed)
		{
			if (animationClip == null)
			{
				return;
			}
			int hashCode = animationClip.GetHashCode();
			foreach (GesturePlayableBehaviour active in m_ActiveList)
			{
				if (active.AnimationClipHash == hashCode)
				{
					active.Speed = speed;
				}
			}
		}

		private GesturePlayableBehaviour Play(ref ScriptPlayable<GesturePlayableBehaviour> gesturePlayable, ConfigGesture config, bool stopPreviousGestures)
		{
			if (stopPreviousGestures)
			{
				Stop(config.DelayIn + config.TransitionIn + 0.01f, 0f);
			}
			Playable input = base.ScriptPlayable.GetInput(0);
			base.ScriptPlayable.DisconnectInput(0);
			gesturePlayable.ConnectInput(0, input, 0);
			gesturePlayable.SetInputWeight(0, 1f);
			base.ScriptPlayable.ConnectInput(0, gesturePlayable, 0);
			base.ScriptPlayable.SetInputWeight(0, 1f);
			GesturePlayableBehaviour behaviour = gesturePlayable.GetBehaviour();
			m_ActiveList.Add(behaviour);
			behaviour.Create(this);
			return behaviour;
		}

		internal override void OnDeleteChild(TAnimimPlayableBehaviour playableBehaviour)
		{
			GesturePlayableBehaviour item = playableBehaviour as GesturePlayableBehaviour;
			m_ActiveList.Remove(item);
		}
	}
}
