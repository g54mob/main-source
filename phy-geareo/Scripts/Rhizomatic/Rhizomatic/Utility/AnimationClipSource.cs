using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.Utility
{
	public class AnimationClipSource : MonoBehaviour, IAnimationClipSource
	{
		public List<AnimationClip> clips;

		public void GetAnimationClips(List<AnimationClip> results)
		{
		}
	}
}
