using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	public interface IAnimationClipCollection
	{
		void GatherAnimationClips(ICollection<AnimationClip> clips);
	}
}
