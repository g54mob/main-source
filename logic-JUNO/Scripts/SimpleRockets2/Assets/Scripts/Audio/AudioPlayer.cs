using ModApi.Audio;
using ModApi.Flight;
using ModApi.Scenes.Events;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
	public class AudioPlayer : MonoBehaviour, IAudioPlayer
	{
		private const string GameLowpassCutoffName = "GameLowpassCutoff";

		private const string GameLowpassResonanceName = "GameLowpassResonance";

		[SerializeField]
		private AudioMixer _audioMixer;

		[SerializeField]
		private AudioMixerGroup _audioMixerGroupGame;

		[SerializeField]
		private AudioMixerGroup _audioMixerGroupUi;

		private float _defaultLowpassCutoff;

		private float _defaultLowpassResonance;

		private GameObject _parent;

		private AudioMixerSnapshot _snapshotNormal;

		private AudioMixerSnapshot _snapshotPaused;

		public AudioSource CreateAudioSource(AudioFile audioFile, GameObject gameObjectToApplyAudioSourceTo, bool userInterfaceSound = true)
		{
			AudioSource audioSource = ((!(gameObjectToApplyAudioSourceTo == null)) ? gameObjectToApplyAudioSourceTo.AddComponent<AudioSource>() : Camera.main.gameObject.AddComponent<AudioSource>());
			audioSource.clip = GetAudioClip(audioFile);
			audioSource.volume = audioFile.DefaultVolume;
			audioSource.spatialBlend = (userInterfaceSound ? 0f : 1f);
			audioSource.minDistance = audioFile.MinDistance;
			audioSource.maxDistance = audioFile.MaxDistance;
			if (userInterfaceSound)
			{
				audioSource.outputAudioMixerGroup = _audioMixerGroupUi;
			}
			else
			{
				audioSource.outputAudioMixerGroup = _audioMixerGroupGame;
			}
			return audioSource;
		}

		public void EnableGameAudio(bool enable)
		{
			if (enable)
			{
				_audioMixer.SetFloat("GameVolume", 0f);
			}
			else
			{
				_audioMixer.SetFloat("GameVolume", -80f);
			}
		}

		public AudioMixerGroup GetGameMixerGroup()
		{
			return _audioMixerGroupGame;
		}

		public AudioMixerGroup GetUiMixerGroup()
		{
			return _audioMixerGroupUi;
		}

		public AudioSource PlaySound(AudioFile audioFile, Vector3? position = null, bool userInterfaceSound = true)
		{
			return PlaySound(audioFile, position, audioFile.DefaultVolume, 0f, userInterfaceSound);
		}

		public AudioSource PlaySound(AudioFile audioFile, Vector3? position, float volume, float delay = 0f, bool userInterfaceSound = true)
		{
			return PlaySound(audioFile, position, volume, string.Empty, delay, userInterfaceSound);
		}

		public void SetLowpassValues(float? cutoff, float? resonance)
		{
			_audioMixer.SetFloat("GameLowpassCutoff", cutoff ?? _defaultLowpassCutoff);
			_audioMixer.SetFloat("GameLowpassResonance", resonance ?? _defaultLowpassResonance);
		}

		public void SetMasterVolume(float volume)
		{
			_audioMixer.SetFloat("MasterVolume", LinearToDecibels(volume));
		}

		public void SetMusicVolume(float volume)
		{
			_audioMixer.SetFloat("MusicVolume", LinearToDecibels(volume * 0.15f));
		}

		public void SetSoundVolume(float volume)
		{
			_audioMixer.SetFloat("SoundVolume", LinearToDecibels(volume * 0.15f));
		}

		public void SetVolumes(float sound, float music)
		{
			float value = LinearToDecibels(sound);
			_audioMixer.SetFloat("SoundVolume", value);
			float value2 = LinearToDecibels(music);
			_audioMixer.SetFloat("MusicVolume", value2);
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.SceneManager.SceneLoaded -= OnSceneLoaded;
			ModApi.Settings.AudioSettings audio = Game.Instance.Settings.Game.Audio;
			audio.MasterVolume.Changed -= OnVolumeChanged;
			audio.MusicVolume.Changed -= OnVolumeChanged;
			audio.SoundVolume.Changed -= OnVolumeChanged;
		}

		protected virtual void Start()
		{
			Game.Instance.SceneManager.SceneLoaded += OnSceneLoaded;
			_snapshotNormal = _audioMixer.FindSnapshot("Normal");
			_snapshotPaused = _audioMixer.FindSnapshot("Paused");
			ModApi.Settings.AudioSettings audio = Game.Instance.Settings.Game.Audio;
			audio.MasterVolume.Changed += OnVolumeChanged;
			audio.MusicVolume.Changed += OnVolumeChanged;
			audio.SoundVolume.Changed += OnVolumeChanged;
			SetVolumes();
			_audioMixer.GetFloat("GameLowpassCutoff", out _defaultLowpassCutoff);
			_audioMixer.GetFloat("GameLowpassResonance", out _defaultLowpassResonance);
		}

		private static float LinearToDecibels(float x)
		{
			if (x > 0f)
			{
				return 20f * Mathf.Log10(x);
			}
			return -80f;
		}

		private AudioClip GetAudioClip(AudioFile audioFile)
		{
			if (audioFile.AudioClip == null)
			{
				audioFile.AudioClip = Game.Instance.ResourceLoader.LoadAudio(audioFile.ResourcePath);
			}
			return audioFile.AudioClip;
		}

		private void OnFlightSceneTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			if (e.CurrentMode.TimeMultiplier == 0.0)
			{
				_snapshotPaused.TransitionTo(0f);
			}
			else if (e.PreviousMode.TimeMultiplier == 0.0)
			{
				_snapshotNormal.TransitionTo(0f);
			}
		}

		private void OnSceneLoaded(object sender, SceneEventArgs e)
		{
			if (e.Scene == "Flight")
			{
				Game.Instance.FlightScene.TimeManager.TimeMultiplierModeChanged += OnFlightSceneTimeMultiplierModeChanged;
			}
			_snapshotNormal.TransitionTo(0f);
		}

		private void OnVolumeChanged(object sender, SettingChangedEventArgs<float> e)
		{
			SetVolumes();
		}

		private AudioSource PlaySound(AudioFile audioFile, Vector3? position, float volume, string trackedSoundId, float delay = 0f, bool userInterfaceSound = true)
		{
			float spatialBlend = 0f;
			if (!position.HasValue)
			{
				position = ((!(Camera.main != null)) ? new Vector3?(Vector3.zero) : new Vector3?(Camera.main.transform.position));
			}
			else
			{
				spatialBlend = 1f;
			}
			if (_parent == null)
			{
				_parent = new GameObject("OneShotAudios");
			}
			GameObject obj = new GameObject("OneShotAudio");
			obj.transform.SetParent(_parent.transform);
			obj.transform.position = position.Value;
			obj.AddComponent<OneShotAudioScript>();
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.loop = false;
			audioSource.playOnAwake = true;
			audioSource.clip = GetAudioClip(audioFile);
			audioSource.volume = volume;
			audioSource.spatialBlend = spatialBlend;
			audioSource.dopplerLevel = 0f;
			if (userInterfaceSound)
			{
				audioSource.outputAudioMixerGroup = _audioMixerGroupUi;
			}
			else
			{
				audioSource.outputAudioMixerGroup = _audioMixerGroupGame;
			}
			if (audioFile.MinDistance > 0f)
			{
				audioSource.minDistance = audioFile.MinDistance;
				audioSource.maxDistance = audioFile.MaxDistance;
			}
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

		private void SetVolumes()
		{
			ModApi.Settings.AudioSettings audio = Game.Instance.Settings.Game.Audio;
			SetMasterVolume(audio.MasterVolume);
			SetMusicVolume(audio.MusicVolume);
			SetSoundVolume(audio.SoundVolume);
		}
	}
}
