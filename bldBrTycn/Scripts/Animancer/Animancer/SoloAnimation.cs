using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animancer
{
	[AddComponentMenu("Animancer/Solo Animation")]
	[DefaultExecutionOrder(-5000)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/SoloAnimation")]
	public class SoloAnimation : MonoBehaviour, IAnimationClipSource
	{
		public const int DefaultExecutionOrder = -5000;

		[SerializeField]
		[Tooltip("The Animator component which this script controls")]
		private Animator _Animator;

		[SerializeField]
		[Tooltip("The animation that will be played")]
		private AnimationClip _Clip;

		private PlayableGraph _Graph;

		private AnimationClipPlayable _Playable;

		private bool _IsPlaying;

		[SerializeField]
		[Tooltip("The speed at which the animation plays (default 1)")]
		private float _Speed = 1f;

		[SerializeField]
		[Tooltip("Determines whether Foot IK will be applied to the model (if it is Humanoid)")]
		private bool _FootIK;

		public Animator Animator
		{
			get
			{
				return _Animator;
			}
			set
			{
				_Animator = value;
				if (IsInitialized)
				{
					Play();
				}
			}
		}

		public AnimationClip Clip
		{
			get
			{
				return _Clip;
			}
			set
			{
				_Clip = value;
				if (IsInitialized)
				{
					Play();
				}
			}
		}

		public bool StopOnDisable
		{
			get
			{
				return !_Animator.keepAnimatorStateOnDisable;
			}
			set
			{
				_Animator.keepAnimatorStateOnDisable = !value;
			}
		}

		public bool IsPlaying
		{
			get
			{
				return _IsPlaying;
			}
			set
			{
				_IsPlaying = value;
				if (value)
				{
					if (!IsInitialized)
					{
						Play();
					}
					else
					{
						_Graph.Play();
					}
				}
				else if (IsInitialized)
				{
					_Graph.Stop();
				}
			}
		}

		public float Speed
		{
			get
			{
				return _Speed;
			}
			set
			{
				_Speed = value;
				_Playable.SetSpeed(value);
				IsPlaying = value != 0f;
			}
		}

		public bool FootIK
		{
			get
			{
				return _FootIK;
			}
			set
			{
				_FootIK = value;
				_Playable.SetApplyFootIK(value);
			}
		}

		public float Time
		{
			get
			{
				return (float)_Playable.GetTime();
			}
			set
			{
				_Playable.SetTime(value);
				_Playable.SetTime(value);
				IsPlaying = true;
			}
		}

		public float NormalizedTime
		{
			get
			{
				return Time / _Clip.length;
			}
			set
			{
				Time = value * _Clip.length;
			}
		}

		public bool IsInitialized => _Graph.IsValid();

		public void Play()
		{
			Play(_Clip);
		}

		public void Play(AnimationClip clip)
		{
			if (!(clip == null) && !(_Animator == null))
			{
				if (_Graph.IsValid())
				{
					_Graph.Destroy();
				}
				_Playable = AnimationPlayableUtilities.PlayClip(_Animator, clip, out _Graph);
				_Playable.SetSpeed(_Speed);
				if (!_FootIK)
				{
					_Playable.SetApplyFootIK(value: false);
				}
				if (!clip.isLooping)
				{
					_Playable.SetDuration(clip.length);
				}
				_IsPlaying = true;
			}
		}

		protected virtual void OnEnable()
		{
			IsPlaying = true;
		}

		protected virtual void Update()
		{
			if (IsPlaying)
			{
				if (_Graph.IsDone())
				{
					IsPlaying = false;
				}
				else if (_Speed < 0f && Time <= 0f)
				{
					IsPlaying = false;
					Time = 0f;
				}
			}
		}

		protected virtual void OnDisable()
		{
			IsPlaying = false;
			if (IsInitialized && StopOnDisable)
			{
				_Playable.SetTime(0.0);
				_Playable.SetTime(0.0);
			}
		}

		protected virtual void OnDestroy()
		{
			if (IsInitialized)
			{
				_Graph.Destroy();
			}
		}

		public void GetAnimationClips(List<AnimationClip> clips)
		{
			if (_Clip != null)
			{
				clips.Add(_Clip);
			}
		}
	}
}
