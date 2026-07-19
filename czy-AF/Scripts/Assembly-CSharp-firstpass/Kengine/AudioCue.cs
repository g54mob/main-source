using System;
using UnityEngine;

namespace Kengine
{
	[Serializable]
	public class AudioCue
	{
		public AudioClip audioClip;

		[Range(1f, 10f)]
		public int frequency = 1;

		public float volume = 1f;

		public bool randomPitch = true;
	}
}
