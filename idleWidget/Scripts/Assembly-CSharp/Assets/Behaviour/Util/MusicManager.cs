using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Behaviour.Util
{
	public class MusicManager : MonoBehaviour
	{
		public const string MainMenuMusic = "GroundControl";

		private static MusicManager _instance;

		[SerializeField]
		private AudioClip[] _musicTracks;

		[SerializeField]
		private AudioClip[] _ambientTracks;

		[SerializeField]
		private AudioSource _source;

		private Dictionary<string, AudioClip> _tracks = new Dictionary<string, AudioClip>();

		private string _queuedTrack;

		private float _nextMusicDelay = 0.1f;

		public static float Volume
		{
			get
			{
				return PlayerPrefs.GetFloat("MusicVolume", 0.35f);
			}
			set
			{
				PlayerPrefs.SetFloat("MusicVolume", value);
				if ((bool)_instance)
				{
					_instance._updateVolume();
				}
			}
		}

		private void Awake()
		{
			if (!_instance)
			{
				_instance = this;
				Object.DontDestroyOnLoad(this);
				AudioClip[] musicTracks = _musicTracks;
				foreach (AudioClip audioClip in musicTracks)
				{
					_tracks[audioClip.name] = audioClip;
				}
				_updateVolume();
			}
		}

		private void Update()
		{
			if (_source.isPlaying)
			{
				return;
			}
			_nextMusicDelay -= Time.deltaTime;
			if (_nextMusicDelay < 0f && _queuedTrack != null)
			{
				if (_tracks.TryGetValue(_queuedTrack, out var value))
				{
					_source.clip = value;
					_source.Play();
					_nextMusicDelay = SeededRandom.Global.RandomRange(value.length * 1.2f, value.length * 1.5f);
					_queuedTrack = SeededRandom.Global.Choose(_ambientTracks).name;
				}
				else
				{
					_nextMusicDelay = 1f;
				}
			}
		}

		public static void Play(string name, bool forceImmediate = false)
		{
			if (!_instance)
			{
				return;
			}
			if (_instance._source.clip?.name == "GroundControl")
			{
				forceImmediate = true;
			}
			_instance._queuedTrack = name;
			if (forceImmediate)
			{
				_instance._nextMusicDelay = 0f;
				if (_instance._source.isPlaying)
				{
					_instance.StartCoroutine(_instance._fadeOut());
				}
			}
			else if (!_instance._source.isPlaying)
			{
				_instance._nextMusicDelay = 1f;
			}
		}

		private IEnumerator _fadeOut()
		{
			AudioClip clip = _source.clip;
			float progress = 0f;
			float baseVolume = Volume;
			while (_source.clip == clip && progress < 1f)
			{
				progress += Time.deltaTime;
				_source.volume = Mathf.SmoothStep(0f, baseVolume, 1f - progress);
				yield return null;
			}
			_source.Stop();
			_source.volume = Volume;
		}

		private void _updateVolume()
		{
			_source.volume = Volume;
		}

		public static void PreviewVolume(float vol)
		{
			if ((bool)_instance)
			{
				_instance._source.volume = vol;
				if (!_instance._source.isPlaying)
				{
					_instance._source.Play();
				}
			}
		}
	}
}
