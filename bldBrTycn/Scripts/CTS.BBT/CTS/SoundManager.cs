using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.Pool;

namespace CTS
{
	public class SoundManager : MonoSingleton<SoundManager>
	{
		[Header("AudioSource Pool")]
		[SerializeField]
		private int _initialPoolSize = 20;

		[SerializeField]
		private GameObject _audioSourcePrefab;

		private ObjectPool<AudioSource> _audioSourcePool;

		private HashSet<AudioSource> _activeSources = new HashSet<AudioSource>();

		private bool _isChangingScene;

		public event Action OnLoadingFinished;

		protected override void SingletonAwake()
		{
			_audioSourcePool = new ObjectPool<AudioSource>(CreateNewAudioSource, OnTakenFromPool, OnReleasedToPool, OnDestroyAudioSource, collectionCheck: true, _initialPoolSize);
			LoadingScreen.EndLoadingScreen += LoadingScreen_EndLoadingScreen;
			LoadingScreen.StartloadingScreen += LoadingScreen_StartloadingScreen;
			_isChangingScene = false;
		}

		protected override void OnSingletonDestroy()
		{
			LoadingScreen.EndLoadingScreen -= LoadingScreen_EndLoadingScreen;
			LoadingScreen.StartloadingScreen -= LoadingScreen_StartloadingScreen;
		}

		private AudioSource CreateNewAudioSource()
		{
			GameObject obj = UnityEngine.Object.Instantiate(_audioSourcePrefab, base.transform);
			obj.SetActive(value: false);
			return obj.GetComponent<AudioSource>();
		}

		private void OnReleasedToPool(AudioSource audioSource)
		{
			if (!audioSource.GetComponent<AudioSourceTime>().IsPausing)
			{
				audioSource.gameObject.SetActive(value: false);
				_activeSources.Remove(audioSource);
			}
		}

		private void OnTakenFromPool(AudioSource audioSource)
		{
			audioSource.gameObject.SetActive(value: true);
			_activeSources.Add(audioSource);
		}

		private void OnDestroyAudioSource(AudioSource audioSource)
		{
			UnityEngine.Object.Destroy(audioSource.gameObject);
		}

		private IEnumerator MonitorAudioSource(AudioSource source)
		{
			AudioSourceTime audioSourceTime = source.GetComponent<AudioSourceTime>();
			while (source.isPlaying || audioSourceTime.IsPausing)
			{
				yield return null;
			}
			ReleaseAudioSourceToPool(source);
		}

		public AudioSource PlayAudioAsset(AudioAsset audioAsset)
		{
			if (audioAsset == null)
			{
				Debug.LogWarning("[SoundManager] Attempted to play a null AudioAsset. Aborting.");
				return null;
			}
			if (_isChangingScene)
			{
				return null;
			}
			AudioSource audioSource = _audioSourcePool.Get();
			audioSource.PlaySoundAsset(audioAsset);
			StartCoroutine(MonitorAudioSource(audioSource));
			return audioSource;
		}

		public AudioSource PlaySpatializedAudioAsset(AudioAsset audioAsset, Vector3 position)
		{
			if (audioAsset == null)
			{
				Debug.LogWarning("[SoundManager] Attempted to play a null AudioAsset. Aborting.");
				return null;
			}
			if (_isChangingScene)
			{
				return null;
			}
			AudioSource audioSource = _audioSourcePool.Get();
			audioSource.transform.position = position;
			audioSource.PlaySoundAsset(audioAsset);
			StartCoroutine(MonitorAudioSource(audioSource));
			return audioSource;
		}

		public bool ReleaseAudioSourceToPool(AudioSource audioSource)
		{
			if (audioSource != null && _activeSources.Contains(audioSource))
			{
				if (audioSource.gameObject.activeSelf)
				{
					_audioSourcePool.Release(audioSource);
				}
				_activeSources.Remove(audioSource);
				return true;
			}
			return false;
		}

		private void LoadingScreen_StartloadingScreen()
		{
			_isChangingScene = true;
		}

		private void LoadingScreen_EndLoadingScreen()
		{
			_isChangingScene = false;
			this.OnLoadingFinished?.Invoke();
		}
	}
}
