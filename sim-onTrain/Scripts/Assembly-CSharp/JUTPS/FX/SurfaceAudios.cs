using System;
using System.Collections.Generic;
using UnityEngine;

namespace JUTPS.FX
{
	[Serializable]
	public class SurfaceAudios
	{
		public string SurfaceTag;

		public List<AudioClip> AudioClips = new List<AudioClip>(4);

		public static void PlayRandomAudio(AudioSource audioSource, List<SurfaceAudios> SurfaceAudioClips, string surfaceTag = "Untagged")
		{
			for (int i = 0; i < SurfaceAudioClips.Count; i++)
			{
				if (SurfaceAudioClips[i].SurfaceTag == surfaceTag)
				{
					audioSource.PlayOneShot(SurfaceAudioClips[i].AudioClips[UnityEngine.Random.Range(0, SurfaceAudioClips.Count)]);
				}
			}
		}
	}
}
