using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public abstract class ControllerTransition<TState> : AnimancerTransition<TState>, IAnimationClipCollection, ICopyable<ControllerTransition<TState>> where TState : ControllerState
	{
		[SerializeField]
		private RuntimeAnimatorController _Controller;

		[SerializeField]
		[Tooltip("Determines what each layer does when ControllerState.Stop is called.\n• If empty, all layers will reset to their default state.\n• If this array is smaller than the layer count, any additional layers will use the last value in this array.")]
		private ControllerState.ActionOnStop[] _ActionsOnStop;

		public ref RuntimeAnimatorController Controller => ref _Controller;

		public override UnityEngine.Object MainObject => _Controller;

		public ref ControllerState.ActionOnStop[] ActionsOnStop => ref _ActionsOnStop;

		public override float MaximumDuration
		{
			get
			{
				if (_Controller == null)
				{
					return 0f;
				}
				float num = 0f;
				AnimationClip[] animationClips = _Controller.animationClips;
				for (int i = 0; i < animationClips.Length; i++)
				{
					float length = animationClips[i].length;
					if (num < length)
					{
						num = length;
					}
				}
				return num;
			}
		}

		public override bool IsValid => _Controller != null;

		public static implicit operator RuntimeAnimatorController(ControllerTransition<TState> transition)
		{
			return transition?._Controller;
		}

		public override void Apply(AnimancerState state)
		{
			if (state is ControllerState controllerState)
			{
				controllerState.ActionsOnStop = _ActionsOnStop;
			}
			base.Apply(state);
		}

		void IAnimationClipCollection.GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			if (_Controller != null)
			{
				clips.Gather(_Controller.animationClips);
			}
		}

		public virtual void CopyFrom(ControllerTransition<TState> copyFrom)
		{
			CopyFrom((AnimancerTransition<TState>)copyFrom);
			if (copyFrom == null)
			{
				_Controller = null;
				_ActionsOnStop = Array.Empty<ControllerState.ActionOnStop>();
			}
			else
			{
				_Controller = copyFrom._Controller;
				_ActionsOnStop = copyFrom._ActionsOnStop;
			}
		}
	}
	[Serializable]
	public class ControllerTransition : ControllerTransition<ControllerState>, ControllerState.ITransition, ITransition<ControllerState>, ITransition, IHasKey, IPolymorphic, ICopyable<ControllerTransition>
	{
		public override ControllerState CreateState()
		{
			return base.State = new ControllerState(base.Controller, base.ActionsOnStop);
		}

		public ControllerTransition()
		{
		}

		public ControllerTransition(RuntimeAnimatorController controller)
		{
			base.Controller = controller;
		}

		public static implicit operator ControllerTransition(RuntimeAnimatorController controller)
		{
			return new ControllerTransition(controller);
		}

		public virtual void CopyFrom(ControllerTransition copyFrom)
		{
			CopyFrom((ControllerTransition<ControllerState>)copyFrom);
		}
	}
}
