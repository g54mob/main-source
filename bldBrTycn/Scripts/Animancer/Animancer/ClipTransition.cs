using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public class ClipTransition : AnimancerTransition<ClipState>, ClipState.ITransition, ITransition<ClipState>, ITransition, IHasKey, IPolymorphic, IMotion, IAnimationClipCollection, ICopyable<ClipTransition>
	{
		public const string ClipFieldName = "_Clip";

		[SerializeField]
		[Tooltip("The animation to play")]
		private AnimationClip _Clip;

		[SerializeField]
		[Tooltip("How fast the animation will play, e.g:\n• 0x = paused\n• 1x = normal speed\n• -2x = double speed backwards\n• Disabled = keep previous speed\n• Middle Click = reset to default value")]
		private float _Speed = 1f;

		[SerializeField]
		[Tooltip("• Enabled = use FadeMode.FromStart and always restart at this time.\n• Disabled = use FadeMode.FixedSpeed and continue from the current time if already playing.\n• x = Normalized, s = Seconds, f = Frame")]
		private float _NormalizedStartTime = float.NaN;

		public AnimationClip Clip
		{
			get
			{
				return _Clip;
			}
			set
			{
				_Clip = value;
			}
		}

		public override UnityEngine.Object MainObject => _Clip;

		public override object Key => _Clip;

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

		public override FadeMode FadeMode
		{
			get
			{
				if (!float.IsNaN(_NormalizedStartTime))
				{
					return FadeMode.FromStart;
				}
				return FadeMode.FixedSpeed;
			}
		}

		public virtual float Length
		{
			get
			{
				if (!IsValid)
				{
					return 0f;
				}
				float normalizedEndTime = base.Events.NormalizedEndTime;
				normalizedEndTime = ((!float.IsNaN(normalizedEndTime)) ? normalizedEndTime : AnimancerEvent.Sequence.GetDefaultNormalizedEndTime(_Speed));
				float num = ((!float.IsNaN(_NormalizedStartTime)) ? _NormalizedStartTime : AnimancerEvent.Sequence.GetDefaultNormalizedStartTime(_Speed));
				return _Clip.length * (normalizedEndTime - num);
			}
		}

		public override bool IsValid
		{
			get
			{
				if (_Clip != null)
				{
					return !_Clip.legacy;
				}
				return false;
			}
		}

		public override bool IsLooping
		{
			get
			{
				if (_Clip != null)
				{
					return _Clip.isLooping;
				}
				return false;
			}
		}

		public override float MaximumDuration
		{
			get
			{
				if (!(_Clip != null))
				{
					return 0f;
				}
				return _Clip.length;
			}
		}

		public virtual float AverageAngularSpeed
		{
			get
			{
				if (!(_Clip != null))
				{
					return 0f;
				}
				return _Clip.averageAngularSpeed;
			}
		}

		public virtual Vector3 AverageVelocity
		{
			get
			{
				if (!(_Clip != null))
				{
					return default(Vector3);
				}
				return _Clip.averageSpeed;
			}
		}

		public override ClipState CreateState()
		{
			return base.State = new ClipState(_Clip);
		}

		public override void Apply(AnimancerState state)
		{
			AnimancerTransition<ClipState>.ApplyDetails(state, _Speed, _NormalizedStartTime);
			base.Apply(state);
		}

		public virtual void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			clips.Gather(_Clip);
		}

		public virtual void CopyFrom(ClipTransition copyFrom)
		{
			CopyFrom((AnimancerTransition<ClipState>)copyFrom);
			if (copyFrom == null)
			{
				_Clip = null;
				_Speed = 1f;
				_NormalizedStartTime = float.NaN;
			}
			else
			{
				_Clip = copyFrom._Clip;
				_Speed = copyFrom._Speed;
				_NormalizedStartTime = copyFrom._NormalizedStartTime;
			}
		}
	}
}
