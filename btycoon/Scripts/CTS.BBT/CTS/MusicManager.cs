using System.Collections;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;

namespace CTS
{
	public class MusicManager : MonoSingleton<MusicManager>
	{
		[SerializeField]
		[HideInInspector]
		private MusicTrack[] _musicTracks;

		[SerializeField]
		[HideInInspector]
		private MusicPlaylist _menuPlaylist;

		[SerializeField]
		[HideInInspector]
		private MusicPlaylist _barPlaylist;

		[SerializeField]
		[HideInInspector]
		private MusicPlaylist _selectionMapList;

		[SerializeField]
		[HideInInspector]
		private AudioMixer _masterMixer;

		[SerializeField]
		private AudioAsset _menuMusic;

		[SerializeField]
		private AudioAsset _barMusic;

		[SerializeField]
		private AudioAsset _selectionMapMusic;

		[SerializeField]
		private float _timeBetweenMusic;

		private MusicPlaylist _currentPlaylist;

		private int _currentActiveTrack;

		[SerializeField]
		private float _crossfadeDuration = 1f;

		[SerializeField]
		[MinMaxSlider(0f, 300f)]
		private Vector2 _delayInSecondsBetweenTunes;

		private bool _firstPlaylistTune = true;

		private bool _tuneDelayed;

		private AudioClip _audioClip;

		[SerializeField]
		private AudioSource _musicAudioSource;

		private void Start()
		{
			_currentActiveTrack = _musicTracks.Length - 1;
			_currentPlaylist = _menuPlaylist;
			MusicTrack[] musicTracks = _musicTracks;
			for (int i = 0; i < musicTracks.Length; i++)
			{
				musicTracks[i].Initialize(this);
			}
		}

		public void PlayMenuMusic()
		{
			StopAllCoroutines();
			ChangeMusicPlaylist(_menuMusic);
			CTSSingleton<MusicMixManager>.Instance?.Stop();
		}

		public void PlayBarMusic()
		{
			_musicAudioSource.Stop();
			CTSSingleton<MusicMixManager>.Instance?.Play();
		}

		public void PlaySelectionMapMusic()
		{
			StopAllCoroutines();
			ChangeMusicPlaylist(_selectionMapMusic);
			CTSSingleton<MusicMixManager>.Instance?.Stop();
		}

		private void ChangeMusicPlaylist(AudioAsset audioAsset, bool barMusic = false)
		{
			if (barMusic)
			{
				_audioClip = _barMusic.AudioClips.GetRandom();
				_musicAudioSource.PlayanotherMusicAssec(audioAsset, _audioClip);
			}
			else
			{
				_musicAudioSource.PlaySoundAsset(audioAsset);
			}
		}

		private IEnumerator CheckMusicEnd()
		{
			while (_musicAudioSource.isPlaying)
			{
				yield return null;
			}
			AudioClip audioClip = _barMusic.AudioClips.GetRandom();
			while (audioClip == _audioClip)
			{
				audioClip = _barMusic.AudioClips.GetRandom();
				yield return null;
			}
			_audioClip = audioClip;
			yield return new WaitForSecondsRealtime(_timeBetweenMusic);
			OnMusicEnded();
		}

		private void OnMusicEnded()
		{
			_musicAudioSource.PlayanotherMusicAssec(_barMusic, _audioClip);
			StartCoroutine(CheckMusicEnd());
		}

		[Button(null, EButtonEnableMode.Always)]
		public void PassMusic()
		{
			_musicAudioSource.Stop();
		}

		private void ChangeCurrentPlaylist(MusicPlaylist playlist)
		{
			StartCoroutine(ChangePlaylistCoroutine(playlist));
		}

		private IEnumerator ChangePlaylistCoroutine(MusicPlaylist newPlaylist)
		{
			if (_currentActiveTrack >= 0 && _currentActiveTrack < _musicTracks.Length && _musicTracks[_currentActiveTrack].IsPlaying)
			{
				_musicTracks[_currentActiveTrack].Stop();
			}
			_currentPlaylist = newPlaylist;
			_firstPlaylistTune = true;
			_tuneDelayed = false;
			yield return PlayCurrentPlaylistNextTune();
		}

		private IEnumerator PlayCurrentPlaylistNextTune(bool withDelay = false)
		{
			if (!_currentPlaylist)
			{
				yield return null;
			}
			_firstPlaylistTune = false;
			_tuneDelayed = true;
			if (withDelay)
			{
				yield return new WaitForSeconds(_delayInSecondsBetweenTunes.RandomInRange());
			}
			_tuneDelayed = false;
		}

		private MusicTrack NextAvailableTrack()
		{
			_currentActiveTrack = (_currentActiveTrack + 1) % _musicTracks.Length;
			return _musicTracks[_currentActiveTrack];
		}

		private void Update()
		{
		}

		public void PauseTrack()
		{
			MusicTrack[] musicTracks = _musicTracks;
			for (int i = 0; i < musicTracks.Length; i++)
			{
				musicTracks[i].Stop();
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
