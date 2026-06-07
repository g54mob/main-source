using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[Serializable]
	public class FootstepCustomEffect
	{
		[Tooltip("The name of the custom footstep effect - used to identify which custom effect will be used by matching names.")]
		public string customName = "";

		[Tooltip("Audio clips used for this custom footstep effect.")]
		public List<AudioClip> audioClips = new List<AudioClip>();

		[Tooltip("Prefabs used for this custom footstep effect.")]
		public List<FootstepPrefab> prefabs = new List<FootstepPrefab>();

		public virtual AudioClip GetClip()
		{
			if (audioClips.Count > 0)
			{
				return audioClips[UnityEngine.Random.Range(0, audioClips.Count - 1)];
			}
			return null;
		}

		public virtual FootstepPrefab GetPrefab()
		{
			if (prefabs.Count > 0)
			{
				return prefabs[UnityEngine.Random.Range(0, prefabs.Count - 1)];
			}
			return null;
		}
	}
}
