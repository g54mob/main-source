using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;

namespace Jundroo.Juicy
{
	public class WidgetContextSound
	{
		private AudioSource _audioSource;

		private float _lastSoundFinished;

		private int _lastSoundPriority;

		private float _lastSoundStarted;

		private IResourceLoader _resourceLoader;

		public WidgetContextSound(AudioSource audioSource, IResourceLoader resourceLoader)
		{
			_audioSource = audioSource;
			_resourceLoader = resourceLoader;
		}

		public void PlaySound(SoundData sound, float volumeMultiplier = 1f)
		{
			float num = _lastSoundStarted + ((sound.MinimumDelay > 0f) ? sound.MinimumDelay : 0.05f);
			if (sound.Priority < _lastSoundPriority)
			{
				num = Mathf.Max(_lastSoundFinished, num);
			}
			else if (sound.Priority > _lastSoundPriority)
			{
				num = 0f;
			}
			if (Time.unscaledTime >= num)
			{
				AudioClip audioClip = _resourceLoader.LoadAudioClip(sound.Path);
				if (audioClip != null)
				{
					_audioSource.pitch = Random.Range(1f - sound.PitchVariation / 2f, 1f + sound.PitchVariation / 2f);
					_audioSource.PlayOneShot(audioClip, sound.Volume * volumeMultiplier * WidgetContext.GlobalSoundVolume);
					_lastSoundStarted = Time.unscaledTime;
					_lastSoundFinished = _lastSoundStarted + audioClip.length;
					_lastSoundPriority = sound.Priority;
				}
			}
		}
	}
}
