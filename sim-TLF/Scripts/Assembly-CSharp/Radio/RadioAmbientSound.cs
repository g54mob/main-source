using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JSAM;
using UnityEngine;

namespace Radio
{
	public class RadioAmbientSound : MonoBehaviour
	{
		[Tooltip("JSAM key for this ambient sound")]
		[SerializeField]
		private SoundFileObject _ambientSound;

		[Tooltip("Condition that enables this layer (OR logic). None = always active while radio is On")]
		[SerializeField]
		private RadioCondition activationCondition;

		[Tooltip("Play during NoSignal state regardless of condition")]
		[SerializeField]
		private bool playOnNoSignal;

		[Range(0f, 1f)]
		[SerializeField]
		private float volume = 0.3f;

		[Tooltip("Fade in/out duration in seconds")]
		[SerializeField]
		private float fadeDuration = 0.5f;

		private bool _isPlaying;

		private RadioConditionProcessor _conditions;

		private CancellationTokenSource _fadeCts;

		public void Init(RadioConditionProcessor conditionProcessor)
		{
			_conditions = conditionProcessor;
		}

		public void Evaluate(RadioState state, RadioCondition activeConditions)
		{
			int num = state switch
			{
				RadioState.Off => 0, 
				RadioState.NoSignal => playOnNoSignal ? 1 : 0, 
				RadioState.On => (activationCondition == RadioCondition.None || (activeConditions & activationCondition) != 0) ? 1 : 0, 
				_ => 0, 
			};
			if (num != 0 && !_isPlaying)
			{
				StartAmbient();
			}
			if (num == 0 && _isPlaying)
			{
				StopAmbient();
			}
		}

		private void StartAmbient()
		{
			if (_ambientSound == null)
			{
				return;
			}
			try
			{
				AudioManager.PlaySound(_ambientSound, base.transform);
				_isPlaying = true;
				FadeTo(volume).Forget();
			}
			catch (Exception ex)
			{
				Debug.LogWarning($"[RadioAmbient] Failed to play '{_ambientSound}': {ex.Message}");
			}
		}

		private void StopAmbient()
		{
			_isPlaying = false;
			FadeAndStop().Forget();
		}

		private async UniTaskVoid FadeTo(float target)
		{
			CancelFade();
			_fadeCts = new CancellationTokenSource();
			CancellationToken ct = _fadeCts.Token;
			float start = ((_ambientSound != null) ? _ambientSound.relativeVolume : 0f);
			float elapsed = 0f;
			while (elapsed < fadeDuration && !ct.IsCancellationRequested)
			{
				if (_ambientSound != null)
				{
					_ambientSound.relativeVolume = Mathf.Lerp(start, target, elapsed / fadeDuration);
				}
				elapsed += Time.deltaTime;
				await UniTask.Yield(ct).SuppressCancellationThrow();
			}
			if (!ct.IsCancellationRequested && _ambientSound != null)
			{
				_ambientSound.relativeVolume = target;
			}
		}

		private async UniTaskVoid FadeAndStop()
		{
			if (_ambientSound == null)
			{
				return;
			}
			CancelFade();
			_fadeCts = new CancellationTokenSource();
			CancellationToken ct = _fadeCts.Token;
			float start = _ambientSound.relativeVolume;
			float elapsed = 0f;
			while (elapsed < fadeDuration && !ct.IsCancellationRequested)
			{
				if (_ambientSound != null)
				{
					_ambientSound.relativeVolume = Mathf.Lerp(start, 0f, elapsed / fadeDuration);
				}
				elapsed += Time.deltaTime;
				await UniTask.Yield(ct).SuppressCancellationThrow();
			}
			if (!(_ambientSound != null))
			{
				return;
			}
			try
			{
				AudioManager.StopSoundIfPlaying(_ambientSound);
			}
			catch
			{
			}
		}

		private void CancelFade()
		{
			_fadeCts?.Cancel();
			_fadeCts?.Dispose();
			_fadeCts = null;
		}

		private void OnDisable()
		{
			CancelFade();
			try
			{
				AudioManager.StopSoundIfPlaying(_ambientSound);
			}
			catch
			{
			}
			_isPlaying = false;
		}
	}
}
