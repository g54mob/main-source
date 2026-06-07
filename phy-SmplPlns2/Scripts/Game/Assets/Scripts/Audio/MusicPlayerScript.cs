using System;
using System.Collections;
using System.Collections.Generic;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	public class MusicPlayerScript : MonoBehaviour
	{
		private int _activeSources;

		private List<AudioSource> _audioSources = new List<AudioSource>();

		[SerializeField]
		private GameObject _audioSourceTemplate;

		private float? _currentInFadeTime;

		private float? _currentOutFadeTime;

		private SongTags _currentTags;

		private Coroutine _delayedPlayCoroutine;

		private float _fadeStartValue;

		private float _fadetargetTime;

		private List<float> _layerVolumeScales = new List<float>();

		private float _musicVolume;

		private bool _paused;

		private Song _playingSong;

		[SerializeField]
		[Tooltip("The number of songs to keep track of in the past to not repeat them.")]
		private int _shuffleHistorySize;

		private Song[] _songHistoryBuffer;

		private int _songHistoryBufferIndex;

		private int _songHistoryCount;

		private SongList _songList;

		private bool _tempFadeOutOnSongThatShouldBeLoopingButThisIsHopefullyJustAQuickFixForThisBuildSoImUsingAnAwfulVariableNameSoItHurtsToSeeAndNobodyDaresToLeaveThisShitIn;

		public bool IsFadingOut => _currentOutFadeTime.HasValue;

		public float LayerTransitionTime { get; set; } = 5f;

		public float MaxVolume { get; set; } = 0.5f;

		public bool Paused
		{
			get
			{
				return _paused;
			}
			set
			{
				_paused = value;
				EqualizeSongTimes();
				for (int i = 0; i < _activeSources; i++)
				{
					if (value)
					{
						_audioSources[i].Pause();
					}
					else
					{
						_audioSources[i].UnPause();
					}
				}
			}
		}

		public Song PlayingSong => _playingSong;

		public bool ShouldMusicBePlaying
		{
			get
			{
				if (Volume > 0f && !Paused && !Device.IsUnityEditorApplicationPaused)
				{
					return _delayedPlayCoroutine == null;
				}
				return false;
			}
		}

		public float Volume
		{
			get
			{
				return _musicVolume;
			}
			set
			{
				_musicVolume = Mathf.Clamp01(value);
				UpdateVolumes();
			}
		}

		public float VolumeScale { get; set; }

		public void EnsureMusicIsPlaying()
		{
			if (Paused)
			{
				Paused = false;
			}
			if (_audioSources.Count == 0 || (!_audioSources[0].isPlaying && Volume > 0f))
			{
				PlayNextSong(0f);
			}
		}

		public void FadeVolumeIn(float fadeTime)
		{
			_fadeStartValue = VolumeScale;
			_currentInFadeTime = 0f;
			_currentOutFadeTime = null;
			_fadetargetTime = fadeTime;
		}

		public void FadeVolumeOut(float fadeTime)
		{
			_fadeStartValue = VolumeScale;
			_currentOutFadeTime = 0f;
			_currentInFadeTime = null;
			_fadetargetTime = fadeTime;
		}

		protected virtual void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Game.Instance.Settings.Gameplay.Audio.MusicVolume.Changed += OnMusicVolumeChanged;
			VolumeScale = 1f;
			_songList = Resources.Load<SongList>("Music/Songs/OST");
			UpdateSongTags();
			PlayNextSong(1f);
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.Settings.Gameplay.Audio.MusicVolume.Changed -= OnMusicVolumeChanged;
		}

		protected virtual void Update()
		{
			UpdateSongTags();
			if (((_audioSources.Count == 0 || !_audioSources[0].isPlaying) && ShouldMusicBePlaying) || (Device.IsUnityEditor && UnityEngine.Input.GetKeyDown(KeyCode.PageDown)))
			{
				PlayNextSong(1f);
				if (VolumeScale < 1f && _tempFadeOutOnSongThatShouldBeLoopingButThisIsHopefullyJustAQuickFixForThisBuildSoImUsingAnAwfulVariableNameSoItHurtsToSeeAndNobodyDaresToLeaveThisShitIn)
				{
					_tempFadeOutOnSongThatShouldBeLoopingButThisIsHopefullyJustAQuickFixForThisBuildSoImUsingAnAwfulVariableNameSoItHurtsToSeeAndNobodyDaresToLeaveThisShitIn = false;
					VolumeScale = 1f;
					_currentOutFadeTime = null;
					_currentInFadeTime = null;
				}
			}
			bool flag = false;
			if (_currentInFadeTime.HasValue)
			{
				_currentInFadeTime += Time.deltaTime;
				VolumeScale = Mathf.Lerp(_fadeStartValue, 1f, _currentInFadeTime.Value / _fadetargetTime);
				flag = true;
				if (_currentInFadeTime.Value >= _fadetargetTime)
				{
					_currentInFadeTime = null;
				}
			}
			if (_currentOutFadeTime.HasValue)
			{
				_currentOutFadeTime += Time.deltaTime;
				VolumeScale = Mathf.Lerp(_fadeStartValue, 0f, _currentOutFadeTime.Value / _fadetargetTime);
				flag = true;
				if (_currentOutFadeTime.Value >= _fadetargetTime)
				{
					_currentOutFadeTime = null;
				}
			}
			else if (_audioSources.Count > 0 && _audioSources[0].clip.length - _audioSources[0].time < 5f)
			{
				FadeVolumeOut(5f);
				_tempFadeOutOnSongThatShouldBeLoopingButThisIsHopefullyJustAQuickFixForThisBuildSoImUsingAnAwfulVariableNameSoItHurtsToSeeAndNobodyDaresToLeaveThisShitIn = true;
			}
			if (flag | UpdateLayerVolumes(lerp: true))
			{
				UpdateVolumes();
			}
		}

		private void EqualizeSongTimes()
		{
			if (_audioSources.Count >= 2)
			{
				int timeSamples = _audioSources[0].timeSamples;
				for (int i = 1; i < _activeSources; i++)
				{
					_audioSources[i].timeSamples = timeSamples;
				}
			}
		}

		private void OnMusicVolumeChanged(object sender, SettingChangedEventArgs<float> e)
		{
			float num = (Volume = e.Setting.Value);
			if (num > 0f)
			{
				Game.Instance.MusicPlayer.EnsureMusicIsPlaying();
			}
		}

		private Song PickNextSong(SongTags tags)
		{
			if (_songHistoryBuffer == null || _songHistoryBuffer.Length != _shuffleHistorySize)
			{
				_songHistoryBuffer = new Song[_shuffleHistorySize];
				_songHistoryCount = 0;
				_songHistoryBufferIndex = 0;
			}
			Song song = _songList.PickSong(tags, _songHistoryBuffer.AsSpan(0, _songHistoryCount));
			if (song == null)
			{
				song = _songList.PickSong(tags, Span<Song>.Empty);
			}
			if (song == null)
			{
				return null;
			}
			_songHistoryBuffer[_songHistoryBufferIndex++] = song;
			_songHistoryCount = Math.Max(_songHistoryCount, _songHistoryBufferIndex);
			_songHistoryBufferIndex %= _shuffleHistorySize;
			return song;
		}

		private void PlayNextSong(float delay)
		{
			if (_delayedPlayCoroutine != null)
			{
				StopCoroutine(_delayedPlayCoroutine);
				_delayedPlayCoroutine = null;
			}
			_delayedPlayCoroutine = StartCoroutine(PlayNextSongAsync(delay));
		}

		private IEnumerator PlayNextSongAsync(float delay)
		{
			try
			{
				if (_playingSong != null)
				{
					_playingSong.UnloadAudioData();
					_playingSong = null;
				}
				Song song = PickNextSong(_currentTags);
				if (song == null)
				{
					Debug.LogError($"Failed to pick a song from the current tags. ({_currentTags})");
					yield return new WaitForSecondsRealtime(10f);
					yield break;
				}
				song.LoadAudioData();
				_playingSong = song;
				double startTime = Time.realtimeSinceStartupAsDouble;
				yield return new WaitUntil(() => song.GetLoadState() != AudioDataLoadState.Loading);
				if (song.GetLoadState() != AudioDataLoadState.Loaded)
				{
					Debug.LogError($"Failed to load song {song}!", song);
					yield break;
				}
				float num = (float)(Time.realtimeSinceStartupAsDouble - startTime);
				if (num > delay && delay > 1f)
				{
					Debug.LogWarning($"Song load for {song} took {num:0.00}s, delaying its playback.", song);
				}
				if (delay > num)
				{
					yield return new WaitForSecondsRealtime(delay - num);
				}
				SetupSourcesFor(song);
				UpdateLayerVolumes();
				UpdateVolumes();
				for (int num2 = 0; num2 < _activeSources; num2++)
				{
					_audioSources[num2].Play();
				}
			}
			finally
			{
				_delayedPlayCoroutine = null;
			}
		}

		private void SetupSourcesFor(Song song)
		{
			int num = 1;
			if (song is ComplexSong complexSong)
			{
				num += complexSong.Layers.Length;
			}
			while (_audioSources.Count < num)
			{
				GameObject obj = UnityEngine.Object.Instantiate(_audioSourceTemplate, base.transform);
				obj.transform.SetLocalPositionAndRotation(default(Vector3), Quaternion.identity);
				AudioSource component = obj.GetComponent<AudioSource>();
				component.enabled = true;
				_audioSources.Add(component);
				_layerVolumeScales.Add(0f);
			}
			for (int i = 0; i < _audioSources.Count; i++)
			{
				_audioSources[i].enabled = i < num;
			}
			_activeSources = num;
			for (int j = 0; j < _layerVolumeScales.Count; j++)
			{
				_layerVolumeScales[j] = ((j == 0) ? 1f : 0f);
			}
			int num2 = 0;
			_audioSources[num2++].clip = song.MainClip;
			_audioSources[0].timeSamples = 0;
			if (song is ComplexSong complexSong2)
			{
				for (int k = 0; k < complexSong2.Layers.Length; k++)
				{
					AudioSource audioSource = _audioSources[num2++];
					ComplexSong.Layer layer = complexSong2.Layers[k];
					audioSource.clip = layer.Clip;
					audioSource.timeSamples = 0;
				}
			}
		}

		private bool UpdateLayerVolumes(bool lerp = false)
		{
			bool flag = false;
			for (int i = 0; i < _activeSources; i++)
			{
				float num = 1f;
				if (i != 0)
				{
					bool flag2 = false;
					if (_playingSong is ComplexSong complexSong)
					{
						flag2 = (complexSong.Layers[i - 1].Tags & _currentTags) != 0;
					}
					float num2 = (flag2 ? 1f : 0f);
					num = ((!lerp) ? num2 : Mathf.MoveTowards(_layerVolumeScales[i], num2, Time.deltaTime / LayerTransitionTime));
				}
				flag |= _layerVolumeScales[i] != num;
				_layerVolumeScales[i] = num;
			}
			return flag;
		}

		private void UpdateSongTags()
		{
			SongTags songTags = (SongTags)0;
			songTags = (Game.Instance.SceneManager.InDesigner ? SongTags.Designer : SongTags.Flight);
			_currentTags = songTags;
		}

		private void UpdateVolumes()
		{
			float num = _musicVolume * VolumeScale;
			for (int i = 0; i < _activeSources; i++)
			{
				float f = num * _layerVolumeScales[i];
				_audioSources[i].volume = Mathf.Pow(f, 2f) * MaxVolume;
			}
		}
	}
}
