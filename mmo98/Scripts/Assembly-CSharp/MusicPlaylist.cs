using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using LitMotion;
using R3;
using UnityEngine;

public class MusicPlaylist : IDisposable
{
	private const float RestartThreshold = 3f;

	private const float CrossFade = 1.25f;

	private bool _isTransitioning;

	private float _musicVolume;

	private float _activeFade;

	private float _inactiveFade;

	private List<AudioClip> _playlist;

	private AudioSource _activeSource;

	private AudioSource _inactiveSource;

	private AudioSource _timeSource;

	private List<int> _shuffleQueue = new List<int>();

	private CancellationTokenSource _commandCts;

	private readonly CancellationToken _lifetimeToken;

	private readonly IDisposable _volumeSubscription;

	private readonly AudioSource _sourceA;

	private readonly AudioSource _sourceB;

	private readonly ReactiveProperty<AudioClip> _currentClip = new ReactiveProperty<AudioClip>(null);

	private readonly ReactiveProperty<int> _currentIndex = new ReactiveProperty<int>(0);

	private readonly ReactiveProperty<float> _currentDuration = new ReactiveProperty<float>(0f);

	private readonly ReactiveProperty<float> _currentTime = new ReactiveProperty<float>(0f);

	private readonly ReactiveProperty<bool> _isPaused = new ReactiveProperty<bool>(value: false);

	private readonly ReactiveProperty<bool> _isLooping = new ReactiveProperty<bool>(value: false);

	private readonly ReactiveProperty<bool> _isShuffling = new ReactiveProperty<bool>(value: false);

	public readonly ReadOnlyReactiveProperty<float> CurrentProgress;

	public ReadOnlyReactiveProperty<AudioClip> CurrentClip => _currentClip;

	public ReadOnlyReactiveProperty<int> CurrentIndex => _currentIndex;

	public ReadOnlyReactiveProperty<float> CurrentDuration => _currentDuration;

	public ReadOnlyReactiveProperty<float> CurrentTime => _currentTime;

	public ReadOnlyReactiveProperty<bool> IsPaused => _isPaused;

	public ReadOnlyReactiveProperty<bool> IsLooping => _isLooping;

	public ReadOnlyReactiveProperty<bool> IsShuffling => _isShuffling;

	public MusicPlaylist(AudioSource sourceA, AudioSource sourceB, ReadOnlyReactiveProperty<float> volumeObservable, CancellationToken lifetimeToken)
	{
		_sourceA = sourceA;
		_sourceB = sourceB;
		_activeSource = _sourceA;
		_inactiveSource = _sourceB;
		_volumeSubscription = volumeObservable.Subscribe(ApplyVolume);
		_lifetimeToken = lifetimeToken;
		CurrentProgress = _currentTime.Normalized(_currentDuration).DistinctUntilChanged().ToReadOnlyReactiveProperty(0f);
		_commandCts = CancellationTokenSource.CreateLinkedTokenSource(_lifetimeToken);
		TimeLoopAsync().Forget();
	}

	public void GetOutputData(float[] samples, int channel)
	{
		_timeSource.GetOutputData(samples, channel);
	}

	public void GetSpectrumData(float[] samples, int channel, FFTWindow window)
	{
		_timeSource.GetSpectrumData(samples, channel, window);
	}

	public void Dispose()
	{
		_playlist = null;
		_commandCts?.Cancel();
		_commandCts?.Dispose();
		_commandCts = null;
		_volumeSubscription?.Dispose();
		StopInternal(stopSources: true);
		_currentClip.Dispose();
		_currentTime.Dispose();
		_currentDuration.Dispose();
		_currentIndex.Dispose();
		_isPaused.Dispose();
		_isLooping.Dispose();
		_isShuffling.Dispose();
	}

	private void ApplyVolume(float volume)
	{
		ApplyVolumeFade(volume, _activeFade, _inactiveFade);
	}

	private void ApplyActiveFade(float activeFade)
	{
		ApplyVolumeFade(_musicVolume, activeFade, _inactiveFade);
	}

	private void ApplyInactiveFade(float inactiveFade)
	{
		ApplyVolumeFade(_musicVolume, _activeFade, inactiveFade);
	}

	private void ApplyFade(float activeFade, float inactiveFade)
	{
		ApplyVolumeFade(_musicVolume, activeFade, inactiveFade);
	}

	private void ApplyVolumeFade(float volume, float activeFade, float inactiveFade)
	{
		_musicVolume = Mathf.Clamp01(volume);
		_activeFade = Mathf.Clamp01(activeFade);
		_inactiveFade = Mathf.Clamp01(inactiveFade);
		_activeSource.volume = _activeFade * _musicVolume;
		_inactiveSource.volume = _inactiveFade * _musicVolume;
	}

	public void PlayPlaylist(List<AudioClip> clips, bool restartFromBeginning)
	{
		if (clips == null || clips.Count == 0)
		{
			Debug.LogWarning("MusicPlaylist:PlayPlaylist called with empty playlist.");
			return;
		}
		CancelCommandsAndResetCts();
		StopInternal(stopSources: true);
		_playlist = clips;
		_currentIndex.Value = ((!restartFromBeginning) ? Mathf.Clamp(_currentIndex.Value, 0, clips.Count - 1) : 0);
		_isPaused.Value = false;
		_isTransitioning = false;
		RebuildShuffleQueue(_currentIndex.Value);
		PlayIndexImmediate(_currentIndex.Value);
		AutoAdvanceLoopAsync(_commandCts.Token).Forget();
	}

	public void Stop()
	{
		CancelCommandsAndResetCts();
		StopInternal(stopSources: true);
		_playlist = null;
		_isPaused.Value = false;
		_isTransitioning = false;
		SetNowPlaying(null, 0, resetTime: true);
	}

	public void Pause()
	{
		if (_playlist != null && !_isPaused.Value)
		{
			_isPaused.Value = true;
			_activeSource.Pause();
			_inactiveSource.Pause();
		}
	}

	public void Resume()
	{
		if (_playlist != null && _isPaused.Value)
		{
			_isPaused.Value = false;
			_activeSource.UnPause();
			_inactiveSource.UnPause();
		}
	}

	public void ToggleLoop()
	{
		_isLooping.Value = !_isLooping.Value;
	}

	public void ToggleShuffle()
	{
		_isShuffling.Value = !_isShuffling.Value;
		if (_isShuffling.Value && _playlist != null)
		{
			RebuildShuffleQueue(_currentIndex.Value);
		}
	}

	public void Seek(float normalizedTime)
	{
		if (_playlist != null && (bool)_activeSource.clip)
		{
			float max = Mathf.Max(0f, _activeSource.clip.length - 0.05f);
			float num = Mathf.Clamp(Mathf.Clamp01(normalizedTime) * _activeSource.clip.length, 0f, max);
			_activeSource.time = num;
			_currentTime.Value = num;
		}
	}

	public void Next()
	{
		if (_playlist != null && !_isTransitioning)
		{
			int index = (_isLooping.Value ? _currentIndex.Value : ((!_isShuffling.Value) ? WrapIndex(_currentIndex.Value + 1, _playlist.Count) : DequeueShuffleIndex()));
			PlayIndexCrossfade(index);
		}
	}

	public void Previous()
	{
		if (_playlist != null && !_isTransitioning)
		{
			if ((bool)_activeSource.clip && _activeSource.time > 3f)
			{
				RestartCurrentImmediate();
				return;
			}
			int index = (_isLooping.Value ? _currentIndex.Value : ((!_isShuffling.Value) ? WrapIndex(_currentIndex.Value - 1, _playlist.Count) : DequeueShuffleIndex()));
			PlayIndexCrossfade(index);
		}
	}

	private void PlayIndexImmediate(int index)
	{
		_activeSource.Stop();
		_inactiveSource.Stop();
		SwapToSource(_sourceA);
		ApplyFade(1f, 0f);
		AudioClip clip = _playlist[index];
		_activeSource.clip = clip;
		_activeSource.time = 0f;
		_activeSource.Play();
		_inactiveSource.clip = null;
		_timeSource = _activeSource;
		SetNowPlaying(clip, index, resetTime: true);
	}

	private void RestartCurrentImmediate()
	{
		if ((bool)_activeSource.clip)
		{
			CancelCommandsAndResetCts();
			ApplyFade(1f, 0f);
			_activeSource.Stop();
			_activeSource.time = 0f;
			_activeSource.Play();
			_inactiveSource.Stop();
			_inactiveSource.clip = null;
			_isPaused.Value = false;
			_isTransitioning = false;
			_timeSource = _activeSource;
			SetNowPlaying(_activeSource.clip, _currentIndex.Value, resetTime: true);
			AutoAdvanceLoopAsync(_commandCts.Token).Forget();
		}
	}

	private void PlayIndexCrossfade(int index)
	{
		if (_playlist != null && _playlist.Count != 0)
		{
			CancelCommandsAndResetCts();
			ApplyInactiveFade(0f);
			_isTransitioning = true;
			AudioClip clip = _playlist[index];
			_inactiveSource.Stop();
			_inactiveSource.clip = clip;
			_inactiveSource.time = 0f;
			_inactiveSource.Play();
			_timeSource = _inactiveSource;
			SetNowPlaying(clip, index, resetTime: true);
			BeginCrossfade(_commandCts.Token).Forget();
			AutoAdvanceLoopAsync(_commandCts.Token).Forget();
		}
	}

	private void StopInternal(bool stopSources)
	{
		if (stopSources)
		{
			_sourceA.Stop();
			_sourceA.clip = null;
			_sourceB.Stop();
			_sourceB.clip = null;
			_activeSource = _sourceA;
			_inactiveSource = _sourceB;
			_timeSource = _activeSource;
			_isTransitioning = false;
			ApplyFade(0f, 0f);
		}
	}

	private void SetNowPlaying(AudioClip clip, int index, bool resetTime)
	{
		_currentClip.Value = clip;
		_currentIndex.Value = index;
		_currentDuration.Value = (clip ? clip.length : 0f);
		if (resetTime)
		{
			_currentTime.Value = 0f;
		}
	}

	private async UniTaskVoid BeginCrossfade(CancellationToken token)
	{
		MotionHandle handle = LMotion.Create(_activeFade, 0f, 1.25f).WithEase(Ease.InOutSine).Bind(ApplyActiveFade);
		MotionHandle handle2 = LMotion.Create(_inactiveFade, 1f, 1.25f).WithEase(Ease.InOutSine).Bind(ApplyInactiveFade);
		try
		{
			await UniTask.WhenAll(handle.ToUniTask(token), handle2.ToUniTask(token));
		}
		catch (OperationCanceledException)
		{
			_isTransitioning = false;
			return;
		}
		if (token.IsCancellationRequested)
		{
			_isTransitioning = false;
			return;
		}
		_activeSource.Stop();
		_activeSource.clip = null;
		SwapActiveInactive();
		ApplyFade(1f, 0f);
		_timeSource = _activeSource;
		_isTransitioning = false;
	}

	private async UniTask AutoAdvanceLoopAsync(CancellationToken token)
	{
		while (!token.IsCancellationRequested && !_lifetimeToken.IsCancellationRequested && _playlist != null)
		{
			if (_isPaused.Value || ReactiveSettings.AudioMuted.CurrentValue)
			{
				await UniTask.Delay(100, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
				continue;
			}
			if (!_isTransitioning && (bool)_activeSource.clip && !_activeSource.isPlaying)
			{
				int index = (_isLooping.Value ? _currentIndex.Value : ((!_isShuffling.Value) ? WrapIndex(_currentIndex.Value + 1, _playlist.Count) : DequeueShuffleIndex()));
				PlayIndexCrossfade(index);
				break;
			}
			await UniTask.Delay(200, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
		}
	}

	private async UniTask TimeLoopAsync()
	{
		while (!_lifetimeToken.IsCancellationRequested)
		{
			if (_playlist == null || _isPaused.Value || !_timeSource || !_timeSource.clip || ReactiveSettings.AudioMuted.CurrentValue)
			{
				await UniTask.Delay(200, ignoreTimeScale: false, PlayerLoopTiming.Update, _lifetimeToken);
				continue;
			}
			_currentTime.Value = _timeSource.time;
			_currentDuration.Value = _timeSource.clip.length;
			await UniTask.Delay(200, ignoreTimeScale: false, PlayerLoopTiming.Update, _lifetimeToken);
		}
	}

	private void CancelCommandsAndResetCts()
	{
		_commandCts.Cancel();
		_commandCts.Dispose();
		_commandCts = CancellationTokenSource.CreateLinkedTokenSource(_lifetimeToken);
	}

	private void SwapActiveInactive()
	{
		AudioSource inactiveSource = _inactiveSource;
		AudioSource activeSource = _activeSource;
		_activeSource = inactiveSource;
		_inactiveSource = activeSource;
	}

	private void SwapToSource(AudioSource newActive)
	{
		_activeSource = newActive;
		_inactiveSource = ((newActive == _sourceA) ? _sourceB : _sourceA);
	}

	private void RebuildShuffleQueue(int excludeIndex)
	{
		_shuffleQueue.Clear();
		for (int i = 0; i < _playlist.Count; i++)
		{
			if (i != excludeIndex)
			{
				_shuffleQueue.Add(i);
			}
		}
		for (int num = _shuffleQueue.Count - 1; num > 0; num--)
		{
			int num2 = UnityEngine.Random.Range(0, num + 1);
			List<int> shuffleQueue = _shuffleQueue;
			int index = num;
			List<int> shuffleQueue2 = _shuffleQueue;
			int index2 = num2;
			int num3 = _shuffleQueue[num2];
			int num4 = _shuffleQueue[num];
			int num5 = (shuffleQueue[index] = num3);
			num5 = (shuffleQueue2[index2] = num4);
		}
	}

	private int DequeueShuffleIndex()
	{
		if (_shuffleQueue.Count == 0)
		{
			RebuildShuffleQueue(_currentIndex.Value);
		}
		if (_shuffleQueue.Count == 0)
		{
			return _currentIndex.Value;
		}
		int result = _shuffleQueue[_shuffleQueue.Count - 1];
		_shuffleQueue.RemoveAt(_shuffleQueue.Count - 1);
		return result;
	}

	private static int WrapIndex(int index, int count)
	{
		if (count <= 0)
		{
			return 0;
		}
		int num = index % count;
		if (num >= 0)
		{
			return num;
		}
		return num + count;
	}
}
