using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Animancer
{
	[Serializable]
	public class PlayableAssetTransition : AnimancerTransition<PlayableAssetState>, PlayableAssetState.ITransition, ITransition<PlayableAssetState>, ITransition, IHasKey, IPolymorphic, IAnimationClipCollection, ICopyable<PlayableAssetTransition>
	{
		[SerializeField]
		[Tooltip("The asset to play")]
		private PlayableAsset _Asset;

		[SerializeField]
		[Tooltip("How fast the animation will play, e.g:\n• 0x = paused\n• 1x = normal speed\n• -2x = double speed backwards\n• Disabled = keep previous speed\n• Middle Click = reset to default value")]
		private float _Speed = 1f;

		[SerializeField]
		[Tooltip("• Enabled = use FadeMode.FromStart and always restart at this time.\n• Disabled = use FadeMode.FixedSpeed and continue from the current time if already playing.\n• x = Normalized, s = Seconds, f = Frame")]
		private float _NormalizedStartTime = float.NaN;

		[SerializeField]
		[Tooltip("The objects controlled by each of the tracks in the Asset")]
		[NonReorderable]
		private UnityEngine.Object[] _Bindings;

		public ref PlayableAsset Asset => ref _Asset;

		public override UnityEngine.Object MainObject => _Asset;

		public override object Key => _Asset;

		public override float Speed
		{
			get
			{
				return _Speed;
			}
			set
			{
				_Speed = value;
			}
		}

		public override float NormalizedStartTime
		{
			get
			{
				return _NormalizedStartTime;
			}
			set
			{
				_NormalizedStartTime = value;
			}
		}

		public ref UnityEngine.Object[] Bindings => ref _Bindings;

		public override float MaximumDuration
		{
			get
			{
				if (!(_Asset != null))
				{
					return 0f;
				}
				return (float)_Asset.duration;
			}
		}

		public override bool IsValid => _Asset != null;

		public override PlayableAssetState CreateState()
		{
			base.State = new PlayableAssetState(_Asset);
			base.State.SetBindings(_Bindings);
			return base.State;
		}

		public override void Apply(AnimancerState state)
		{
			AnimancerTransition<PlayableAssetState>.ApplyDetails(state, _Speed, _NormalizedStartTime);
			base.Apply(state);
		}

		void IAnimationClipCollection.GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			clips.GatherFromAsset(_Asset);
		}

		public virtual void CopyFrom(PlayableAssetTransition copyFrom)
		{
			CopyFrom((AnimancerTransition<PlayableAssetState>)copyFrom);
			if (copyFrom == null)
			{
				_Asset = null;
				_Speed = 1f;
				_NormalizedStartTime = float.NaN;
				_Bindings = null;
			}
			else
			{
				_Asset = copyFrom._Asset;
				_Speed = copyFrom._Speed;
				_NormalizedStartTime = copyFrom._NormalizedStartTime;
				AnimancerUtilities.CopyExactArray(copyFrom._Bindings, ref _Bindings);
			}
		}
	}
}
