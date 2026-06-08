using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.Audio;

namespace GRP
{
	public class AudioView : View<AudioViewable>
	{
		public AudioClip clip;

		public AudioMixerGroup output;

		public AudioSource customAudioSource;

		public AudioSource audioSource { get; private set; }

		protected override void OnViewCreated()
		{
		}

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		protected override void OnRender()
		{
		}

		public void Play()
		{
		}

		public void PlayOneShot(AudioClip clip, float volumeScale)
		{
		}
	}
}
