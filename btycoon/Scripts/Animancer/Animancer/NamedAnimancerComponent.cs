using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	[AddComponentMenu("Animancer/Named Animancer Component")]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/NamedAnimancerComponent")]
	public class NamedAnimancerComponent : AnimancerComponent
	{
		[SerializeField]
		[Tooltip("If true, the 'Default Animation' will be automatically played by OnEnable")]
		private bool _PlayAutomatically = true;

		[SerializeField]
		[Tooltip("Animations in this array will be automatically registered by Awake as states that can be retrieved using their name")]
		private AnimationClip[] _Animations;

		public ref bool PlayAutomatically => ref _PlayAutomatically;

		public AnimationClip[] Animations
		{
			get
			{
				return _Animations;
			}
			set
			{
				_Animations = value;
				base.States.CreateIfNew(value);
			}
		}

		public AnimationClip DefaultAnimation
		{
			get
			{
				if (!_Animations.IsNullOrEmpty())
				{
					return _Animations[0];
				}
				return null;
			}
			set
			{
				if (_Animations.IsNullOrEmpty())
				{
					_Animations = new AnimationClip[1] { value };
				}
				else
				{
					_Animations[0] = value;
				}
			}
		}

		protected virtual void Awake()
		{
			if (TryGetAnimator())
			{
				base.States.CreateIfNew(_Animations);
			}
		}

		protected override void OnEnable()
		{
			if (!TryGetAnimator())
			{
				return;
			}
			base.OnEnable();
			if (_PlayAutomatically && !_Animations.IsNullOrEmpty())
			{
				AnimationClip animationClip = _Animations[0];
				if (animationClip != null)
				{
					Play(animationClip);
				}
			}
		}

		public override object GetKey(AnimationClip clip)
		{
			return clip.name;
		}

		public override void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			base.GatherAnimationClips(clips);
			clips.Gather(_Animations);
		}
	}
}
