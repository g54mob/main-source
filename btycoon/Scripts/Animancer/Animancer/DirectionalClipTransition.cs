using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	[Serializable]
	public class DirectionalClipTransition : ClipTransition, ICopyable<DirectionalClipTransition>
	{
		[SerializeField]
		[Tooltip("The animations which used to determine the Clip")]
		private DirectionalAnimationSet _AnimationSet;

		public ref DirectionalAnimationSet AnimationSet => ref _AnimationSet;

		public override UnityEngine.Object MainObject => _AnimationSet;

		public void SetDirection(Vector2 direction)
		{
			base.Clip = _AnimationSet.GetClip(direction);
		}

		public void SetDirection(int direction)
		{
			base.Clip = _AnimationSet.GetClip(direction);
		}

		public void SetDirection(DirectionalAnimationSet.Direction direction)
		{
			base.Clip = _AnimationSet.GetClip(direction);
		}

		public void SetDirection(DirectionalAnimationSet8.Direction direction)
		{
			base.Clip = _AnimationSet.GetClip((int)direction);
		}

		public override void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			base.GatherAnimationClips(clips);
			clips.GatherFromSource(_AnimationSet);
		}

		public virtual void CopyFrom(DirectionalClipTransition copyFrom)
		{
			base.CopyFrom(copyFrom);
			if (copyFrom == null)
			{
				_AnimationSet = null;
			}
			else
			{
				_AnimationSet = copyFrom._AnimationSet;
			}
		}
	}
}
