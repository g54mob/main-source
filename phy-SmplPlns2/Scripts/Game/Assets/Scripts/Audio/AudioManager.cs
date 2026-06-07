using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	public static class AudioManager
	{
		private static Dictionary<string, AudioSource> _trackedSounds = new Dictionary<string, AudioSource>();

		public static void ClearTrackedSounds()
		{
			_trackedSounds.Clear();
		}

		public static AudioSource CreateAudioSource(AudioFile audioFile, GameObject gameObjectToApplyAudioSourceTo)
		{
			AudioSource audioSource = ((!(gameObjectToApplyAudioSourceTo == null)) ? gameObjectToApplyAudioSourceTo.AddComponent<AudioSource>() : Camera.main.gameObject.AddComponent<AudioSource>());
			audioSource.clip = audioFile.Resource;
			audioSource.volume = audioFile.DefaultVolume;
			audioSource.spatialBlend = 1f;
			audioSource.outputAudioMixerGroup = audioFile.MixerGroup;
			return audioSource;
		}

		public static void PlaySound(AudioFile audioFile, Vector3? position)
		{
			PlaySound(audioFile, position, audioFile.DefaultVolume);
		}

		public static void PlaySound(AudioFile audioFile, Vector3? position, float volume, float delay = 0f, float pitch = 1f)
		{
			PlaySound(audioFile, position, volume, string.Empty, delay, pitch);
		}

		public static void PlayTrackedSound(AudioFile audioFile, Vector3 position, float volume, string soundId = null)
		{
			if (string.IsNullOrEmpty(soundId))
			{
				soundId = audioFile.Id ?? audioFile.Resource.name;
			}
			AudioSource value = null;
			if (_trackedSounds.TryGetValue(soundId, out value))
			{
				if (volume > value.volume)
				{
					value = PlaySound(audioFile, position, volume, soundId);
					_trackedSounds[soundId] = value;
				}
			}
			else
			{
				value = PlaySound(audioFile, position, volume, soundId);
				_trackedSounds[soundId] = value;
			}
		}

		public static void TrackedSoundFinished(string soundId)
		{
			_trackedSounds.Remove(soundId);
		}

		private static AudioSource PlaySound(AudioFile audioFile, Vector3? position, float volume, string trackedSoundId, float delay = 0f, float pitch = 1f)
		{
			float spacial = 0f;
			if (!position.HasValue)
			{
				position = Camera.main?.transform.position ?? Vector3.zero;
			}
			else
			{
				spacial = 1f;
			}
			GameObject gameObject = new GameObject("OneShotAudio");
			gameObject.transform.position = position.Value;
			gameObject.AddComponent<OneShotAudioScript>().TrackedSoundId = trackedSoundId;
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			AudioStore.SetupAudioSource(audioSource, audioFile, audioFile.Resource, loop: false, autoPlay: true, spacial);
			audioSource.volume = volume;
			audioSource.pitch = pitch;
			if (delay > 0f)
			{
				audioSource.PlayDelayed(delay);
			}
			else
			{
				audioSource.Play();
			}
			return audioSource;
		}
	}
}
