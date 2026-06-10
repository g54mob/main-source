using System;
using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class SoundPlayer : SelfInstancingMonoSingleton<SoundPlayer>
	{
		[Serializable]
		internal class SoundEffect
		{
			public AudioClip clip;

			[Tooltip("You can use this to quickly normalize the audio clip before it is affected by global volume")]
			public float defaultVolume;
		}

		private const float soundFatiguePreventionTime = 0.05f;

		private static float lastPlayedHoverSoundSeconds;

		[Tooltip("(Optional) You can assign an audio slider for the browser to listen to, this will automatically adjust the volume of the audio clips being played in the Browser. You can also use the SetVolume(float) method to change the volume manually.")]
		public Slider audioSlider;

		[SerializeField]
		private SoundEffect SoundClick;

		[SerializeField]
		private SoundEffect SoundHover;

		private AudioSource aud;

		private void Start()
		{
		}

		public static void AttachAudioSlider(Slider slider)
		{
		}

		public static void SetVolume(float volume)
		{
		}

		public static AudioSource AudioSource()
		{
			return null;
		}

		private void PlaySound(SoundEffect sfx)
		{
		}

		public static void PlayClick()
		{
		}

		public static void PlayHover()
		{
		}
	}
}
