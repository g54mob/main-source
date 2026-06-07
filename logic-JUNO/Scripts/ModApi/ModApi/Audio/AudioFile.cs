using UnityEngine;

namespace ModApi.Audio
{
	public class AudioFile
	{
		public AudioClip AudioClip { get; set; }

		public float DefaultVolume { get; set; }

		public float Dopplar { get; set; }

		public float MaxDistance { get; set; }

		public float MinDistance { get; set; }

		public string ResourcePath { get; set; }

		public AudioFile(string resourcePath)
		{
			ResourcePath = resourcePath;
		}
	}
}
