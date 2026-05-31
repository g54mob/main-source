using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animancer
{
	public class ClipState : AnimancerState
	{
		public interface ITransition : ITransition<ClipState>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		private AnimationClip _Clip;

		public override AnimationClip Clip
		{
			get
			{
				return _Clip;
			}
			set
			{
				ChangeMainObject(ref _Clip, value);
			}
		}

		public override Object MainObject
		{
			get
			{
				return _Clip;
			}
			set
			{
				Clip = (AnimationClip)value;
			}
		}

		public override float Length => _Clip.length;

		public override bool IsLooping => _Clip.isLooping;

		public override Vector3 AverageVelocity => _Clip.averageSpeed;

		public override bool ApplyAnimatorIK
		{
			get
			{
				if (_Playable.IsValid())
				{
					return ((AnimationClipPlayable)_Playable).GetApplyPlayableIK();
				}
				return false;
			}
			set
			{
				((AnimationClipPlayable)_Playable).SetApplyPlayableIK(value);
			}
		}

		public override bool ApplyFootIK
		{
			get
			{
				if (_Playable.IsValid())
				{
					return ((AnimationClipPlayable)_Playable).GetApplyFootIK();
				}
				return false;
			}
			set
			{
				((AnimationClipPlayable)_Playable).SetApplyFootIK(value);
			}
		}

		public ClipState(AnimationClip clip)
		{
			_Clip = clip;
		}

		protected override void CreatePlayable(out Playable playable)
		{
			playable = AnimationClipPlayable.Create(base.Root._Graph, _Clip);
		}

		public override void Destroy()
		{
			_Clip = null;
			base.Destroy();
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			ClipState clipState = new ClipState(_Clip);
			clipState.SetNewCloneRoot(root);
			((ICopyable<AnimancerState>)clipState).CopyFrom((AnimancerState)this);
			return clipState;
		}
	}
}
