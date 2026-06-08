using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MusicPlayer : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public MusicPlayer _003C_003E4__this;

		public bool fadeIn;

		public bool randomStartTime;

		internal void _003CStartCurrentTrack_003Eb__0(AsyncOperationHandle<AudioClip> x)
		{
			_003C_003E4__this.StartPlaying(x, fadeIn, randomStartTime);
		}
	}

	private sealed class _003CStartNextClipAfterCurrentOneFinished_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MusicPlayer _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CStartNextClipAfterCurrentOneFinished_003Ed__13(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			MusicPlayer musicPlayer = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(musicPlayer.tracks[musicPlayer.currentTrackIndex].length);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				Debug.Log("track finished");
				_003C_003E2__current = new WaitForSeconds(UnityEngine.Random.Range(musicPlayer.silenceRange.x, musicPlayer.silenceRange.y));
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				musicPlayer.audioSource.clip = null;
				Addressables.Release(musicPlayer.currentAudioClipLoadingHandle);
				musicPlayer.StartNextTrack();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private List<TrackInfo> tracks;

	[SerializeField]
	private int startTrack = -1;

	[SerializeField]
	private Vector2 silenceRange = new Vector2(60f, 120f);

	private AudioSource audioSource;

	private int currentTrackIndex;

	private float targetVolume;

	private AudioClip currentClip;

	private AsyncOperationHandle<AudioClip> currentAudioClipLoadingHandle;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		targetVolume = audioSource.volume;
	}

	private void Start()
	{
		currentTrackIndex = ((startTrack >= 0) ? startTrack : UnityEngine.Random.Range(0, tracks.Count));
		StartCurrentTrack(fadeIn: true, randomStartTime: true);
	}

	private void StartCurrentTrack(bool fadeIn = false, bool randomStartTime = false)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.fadeIn = fadeIn;
		CS_0024_003C_003E8__locals6.randomStartTime = randomStartTime;
		audioSource.clip = null;
		currentAudioClipLoadingHandle = tracks[currentTrackIndex].clipReference.LoadAssetAsync<AudioClip>();
		currentAudioClipLoadingHandle.Completed += delegate(AsyncOperationHandle<AudioClip> x)
		{
			CS_0024_003C_003E8__locals6._003C_003E4__this.StartPlaying(x, CS_0024_003C_003E8__locals6.fadeIn, CS_0024_003C_003E8__locals6.randomStartTime);
		};
	}

	private void StartPlaying(AsyncOperationHandle<AudioClip> audioClipLoadOperation, bool fadeIn, bool randomStartTime)
	{
		currentClip = audioClipLoadOperation.Result;
		audioSource.clip = currentClip;
		if (randomStartTime)
		{
			audioSource.time = tracks[currentTrackIndex].startTimeStamps[UnityEngine.Random.Range(0, tracks[currentTrackIndex].startTimeStamps.Count)];
		}
		if (fadeIn)
		{
			TweenSettingsExtensions.From(DOTweenModuleAudio.DOFade(audioSource, tracks[currentTrackIndex].volume, 3f), 0f);
		}
		else
		{
			audioSource.volume = tracks[currentTrackIndex].volume;
		}
		audioSource.Play();
		StartCoroutine(StartNextClipAfterCurrentOneFinished());
	}

	private void StartNextTrack()
	{
		List<TrackInfo> list = new List<TrackInfo>(tracks);
		if (list.Count > 1)
		{
			list.RemoveAt(currentTrackIndex);
		}
		currentTrackIndex = tracks.IndexOf(list[UnityEngine.Random.Range(0, list.Count)]);
		StartCurrentTrack();
	}

	public IEnumerator StartNextClipAfterCurrentOneFinished()
	{
		return new _003CStartNextClipAfterCurrentOneFinished_003Ed__13(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDestroy()
	{
		Addressables.Release(currentAudioClipLoadingHandle);
	}
}
