using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT
{
	public class MachineSoundManager : MonoBehaviour
	{
		private readonly Dictionary<AudioAsset, AudioSource> _currentlyPlayed = new Dictionary<AudioAsset, AudioSource>();

		public IEnumerator TryPlaySFXMachine(AudioAsset audioAsset, float retryDelay = 0.1f, int maxRetries = 3)
		{
			int attempts = 0;
			while (attempts < maxRetries)
			{
				if (_currentlyPlayed.ContainsKey(audioAsset))
				{
					StopAndRemoveAudioAsset(audioAsset);
				}
				AudioSource audioSource = MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(audioAsset, base.transform.position);
				if (audioSource != null)
				{
					_currentlyPlayed[audioAsset] = audioSource;
					break;
				}
				attempts++;
				yield return Coroutines.WaitForSeconds(retryDelay);
			}
		}

		public void CallPlaySFXMachine(AudioAsset audioAsset)
		{
			StartCoroutine(TryPlaySFXMachine(audioAsset));
		}

		public void StopAllSFXMachine()
		{
			if (_currentlyPlayed.Count == 0)
			{
				return;
			}
			foreach (AudioAsset item in new List<AudioAsset>(_currentlyPlayed.Keys))
			{
				StopAndRemoveAudioAsset(item);
			}
		}

		private void StopAndRemoveAudioAsset(AudioAsset audioAsset)
		{
			if ((bool)_currentlyPlayed[audioAsset])
			{
				_currentlyPlayed[audioAsset].mute = false;
			}
			if (_currentlyPlayed.Remove(audioAsset, out var value) && MonoSingleton<SoundManager>.Instance.ReleaseAudioSourceToPool(value) && value.isPlaying)
			{
				if (value.ignoreListenerPause)
				{
					value.ignoreListenerPause = false;
				}
				value.Stop();
			}
		}
	}
}
