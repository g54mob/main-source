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
			AttachAudioSlider(audioSlider);
		}

		public static void AttachAudioSlider(Slider slider)
		{
			if (!(slider == null))
			{
				slider.onValueChanged.RemoveListener(SetVolume);
				slider.onValueChanged.AddListener(SetVolume);
			}
		}

		public static void SetVolume(float volume)
		{
			if (MonoSingleton<Browser>.SingletonIsInstantiated())
			{
				SharedUi.settings.volume = volume;
			}
		}

		public static AudioSource AudioSource()
		{
			if (SelfInstancingMonoSingleton<SoundPlayer>.Instance.aud == null)
			{
				SelfInstancingMonoSingleton<SoundPlayer>.Instance.aud = SelfInstancingMonoSingleton<SoundPlayer>.Instance.gameObject.AddComponent<AudioSource>();
			}
			return SelfInstancingMonoSingleton<SoundPlayer>.Instance.aud;
		}

		private void PlaySound(SoundEffect sfx)
		{
			if (!(SharedUi.settings == null) && sfx != null && !(lastPlayedHoverSoundSeconds + 0.05f > Time.realtimeSinceStartup))
			{
				lastPlayedHoverSoundSeconds = Time.realtimeSinceStartup;
				AudioSource().PlayOneShot(sfx.clip, sfx.defaultVolume * SharedUi.settings.volume);
			}
		}

		public static void PlayClick()
		{
			SelfInstancingMonoSingleton<SoundPlayer>.Instance.PlaySound(SelfInstancingMonoSingleton<SoundPlayer>.Instance.SoundClick);
		}

		public static void PlayHover()
		{
			SelfInstancingMonoSingleton<SoundPlayer>.Instance.PlaySound(SelfInstancingMonoSingleton<SoundPlayer>.Instance.SoundHover);
		}
	}
}
