using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
	private static SoundManager _instance;

	[Header("Sound Clips Library")]
	public List<SoundAudioClip> soundClips = new List<SoundAudioClip>();

	[Header("Music Playlist")]
	public List<AudioClip> musicPlaylist = new List<AudioClip>();

	[Header("Audio Mixer")]
	public AudioMixer audioMixer;

	public AudioMixerGroup masterMixerGroup;

	public AudioMixerGroup musicMixerGroup;

	public AudioMixerGroup ambianceMixerGroup;

	public AudioMixerGroup sfxMixerGroup;

	[Header("Audio Mixer Parameter Names")]
	public string masterVolumeParam = "MasterVolume";

	public string musicVolumeParam = "MusicVolume";

	public string ambianceVolumeParam = "AmbianceVolume";

	public string sfxVolumeParam = "SFXVolume";

	[Header("Audio Source Pool Settings")]
	public int sfxPoolSize = 15;

	[Header("Settings")]
	[Range(0.1f, 5f)]
	public float zoneCrossFadeDuration = 2f;

	[Range(0f, 1f)]
	public float globalMusicVolume = 0.4f;

	[Range(0f, 1f)]
	public float globalAmbianceVolume = 0.5f;

	[Range(0f, 1f)]
	public float globalSfxVolume = 1f;

	[Header("Biomass Combo")]
	public string biomassCollectionSoundID = "biomass_pickup";

	public float comboPitchStep = 0.05f;

	public float maxComboPitch = 2f;

	public float comboVolumeStep = 0.02f;

	public float maxComboVolume = 1f;

	public float comboResetTime = 0.75f;

	public int maxComboCountForScaling = 10;

	private List<AudioSource> _sfxPool;

	private int _nextSfxPoolIndex;

	private Dictionary<string, SoundAudioClip> _soundLookup;

	private AudioSource _ambianceSource;

	private AudioSource _musicSource;

	private Coroutine _ambianceFadeJob;

	private Coroutine _musicFadeJob;

	private float _ambianceFadeMultiplier;

	private float _musicFadeMultiplier = 1f;

	private float _zoneAmbientVolume = 1f;

	private int currentBiomassComboCount;

	private float lastBiomassCollectionTime;

	private float baseBiomassSoundPitch = 1f;

	private float baseBiomassSoundVolume = 1f;

	private AudioClip _currentMusicClip;

	private const string PREF_MUSIC_VOL = "MusicVolume";

	private const string PREF_AMB_VOL = "AmbienceVolume";

	private const string PREF_SFX_VOL = "SFXVolume";

	public static SoundManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType<SoundManager>();
				if (_instance == null)
				{
					_instance = new GameObject("SoundManager_Instance").AddComponent<SoundManager>();
				}
			}
			return _instance;
		}
	}

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		_instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		InitializeAudioSources();
		InitializeLookup();
		LoadSettings();
	}

	private void Start()
	{
		SyncMixerVolumes();
		SkipToNextSong();
	}

	private void Update()
	{
		if (_ambianceSource != null)
		{
			_ambianceSource.volume = globalAmbianceVolume * _ambianceFadeMultiplier * _zoneAmbientVolume;
		}
		if (_musicSource != null)
		{
			_musicSource.volume = globalMusicVolume * _musicFadeMultiplier;
		}
		if (audioMixer != null)
		{
			SyncMixerVolumes();
		}
		if (currentBiomassComboCount > 0 && Time.time - lastBiomassCollectionTime > comboResetTime)
		{
			currentBiomassComboCount = 0;
		}
		if (!_musicSource.isPlaying && musicPlaylist.Count > 0)
		{
			SkipToNextSong();
		}
	}

	private void InitializeAudioSources()
	{
		_sfxPool = new List<AudioSource>();
		for (int i = 0; i < sfxPoolSize; i++)
		{
			GameObject obj = new GameObject("SFXSource_" + i);
			obj.transform.SetParent(base.transform);
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.playOnAwake = false;
			if (sfxMixerGroup != null)
			{
				audioSource.outputAudioMixerGroup = sfxMixerGroup;
			}
			_sfxPool.Add(audioSource);
		}
		GameObject gameObject = new GameObject("AmbianceSource");
		gameObject.transform.SetParent(base.transform);
		_ambianceSource = gameObject.AddComponent<AudioSource>();
		_ambianceSource.loop = true;
		_ambianceSource.volume = 0f;
		_ambianceFadeMultiplier = 0f;
		if (ambianceMixerGroup != null)
		{
			_ambianceSource.outputAudioMixerGroup = ambianceMixerGroup;
		}
		GameObject gameObject2 = new GameObject("MusicSource");
		gameObject2.transform.SetParent(base.transform);
		_musicSource = gameObject2.AddComponent<AudioSource>();
		_musicSource.loop = false;
		_musicSource.volume = globalMusicVolume;
		_musicFadeMultiplier = 1f;
		if (musicMixerGroup != null)
		{
			_musicSource.outputAudioMixerGroup = musicMixerGroup;
		}
	}

	private void InitializeLookup()
	{
		_soundLookup = new Dictionary<string, SoundAudioClip>();
		foreach (SoundAudioClip soundClip in soundClips)
		{
			if (soundClip.audioClip != null && !string.IsNullOrEmpty(soundClip.soundID) && !_soundLookup.ContainsKey(soundClip.soundID))
			{
				_soundLookup.Add(soundClip.soundID, soundClip);
				if (soundClip.soundID == biomassCollectionSoundID)
				{
					baseBiomassSoundPitch = soundClip.pitch;
					baseBiomassSoundVolume = soundClip.volume;
				}
			}
		}
	}

	public void SkipToNextSong()
	{
		if (musicPlaylist != null && musicPlaylist.Count != 0)
		{
			AudioClip audioClip = musicPlaylist[UnityEngine.Random.Range(0, musicPlaylist.Count)];
			if (musicPlaylist.Count > 1 && audioClip == _currentMusicClip)
			{
				audioClip = musicPlaylist[UnityEngine.Random.Range(0, musicPlaylist.Count)];
			}
			_currentMusicClip = audioClip;
			_musicSource.clip = _currentMusicClip;
			_musicFadeMultiplier = 1f;
			_musicSource.volume = globalMusicVolume;
			_musicSource.Play();
		}
	}

	public void StopAmbiance()
	{
		FadeToClip(_ambianceSource, null, delegate(float val)
		{
			_ambianceFadeMultiplier = val;
		}, ref _ambianceFadeJob);
	}

	public AudioSource GetMusicSource()
	{
		return _musicSource;
	}

	public AudioSource GetAmbianceSource()
	{
		return _ambianceSource;
	}

	public static void SetZoneAudio(ZoneData zone)
	{
		if (Instance == null)
		{
			return;
		}
		if (zone == null)
		{
			Instance.FadeToClip(Instance._ambianceSource, null, delegate(float val)
			{
				Instance._ambianceFadeMultiplier = val;
			}, ref Instance._ambianceFadeJob);
			return;
		}
		Instance._zoneAmbientVolume = zone.ambientVolume;
		Instance.FadeToClip(Instance._ambianceSource, zone.ambientSound, delegate(float val)
		{
			Instance._ambianceFadeMultiplier = val;
		}, ref Instance._ambianceFadeJob);
	}

	private void FadeToClip(AudioSource source, AudioClip newClip, Action<float> updateMultiplierCallback, ref Coroutine currentJob)
	{
		if (!(source.clip == newClip) || !source.isPlaying)
		{
			if (currentJob != null)
			{
				StopCoroutine(currentJob);
			}
			currentJob = StartCoroutine(CrossFadeCoroutine(source, newClip, updateMultiplierCallback));
		}
	}

	private IEnumerator CrossFadeCoroutine(AudioSource source, AudioClip newClip, Action<float> setMultiplier)
	{
		float timer = 0f;
		float halfDuration = zoneCrossFadeDuration / 2f;
		float startVal = ((source.volume > 0.01f) ? 1f : 0f);
		if (source.isPlaying && startVal > 0f)
		{
			while (timer < halfDuration)
			{
				timer += Time.deltaTime;
				setMultiplier(Mathf.Lerp(startVal, 0f, timer / halfDuration));
				yield return null;
			}
		}
		setMultiplier(0f);
		source.Stop();
		if (newClip != null)
		{
			source.clip = newClip;
			source.Play();
			timer = 0f;
			while (timer < halfDuration)
			{
				timer += Time.deltaTime;
				setMultiplier(Mathf.Lerp(0f, 1f, timer / halfDuration));
				yield return null;
			}
			setMultiplier(1f);
		}
	}

	public static void PlaySoundOneShot(string soundID)
	{
		if (!(Instance == null) && Instance._soundLookup.TryGetValue(soundID, out var value) && value.audioClip != null)
		{
			AudioSource availableSfxSource = Instance.GetAvailableSfxSource();
			availableSfxSource.loop = false;
			availableSfxSource.pitch = value.pitch;
			availableSfxSource.volume = value.volume * Instance.globalSfxVolume;
			availableSfxSource.clip = value.audioClip;
			availableSfxSource.Play();
		}
	}

	public static void PlaySound(string soundID)
	{
		Instance?.PlaySoundInternal(soundID, null, null);
	}

	public static void PlaySound(string soundID, float volume)
	{
		Instance?.PlaySoundInternal(soundID, null, volume);
	}

	public static void PlaySound(string soundID, float volume, float pitch)
	{
		Instance?.PlaySoundInternal(soundID, pitch, volume);
	}

	private void PlaySoundInternal(string soundID, float? pitchOverride, float? volumeOverride)
	{
		if (_soundLookup.TryGetValue(soundID, out var value) && value.audioClip != null)
		{
			AudioSource availableSfxSource = GetAvailableSfxSource();
			float pitch = pitchOverride ?? value.pitch;
			float num = volumeOverride ?? value.volume;
			num *= globalSfxVolume;
			availableSfxSource.clip = value.audioClip;
			availableSfxSource.volume = num;
			availableSfxSource.pitch = pitch;
			availableSfxSource.loop = value.loop;
			availableSfxSource.Play();
		}
	}

	private AudioSource GetAvailableSfxSource()
	{
		for (int i = 0; i < _sfxPool.Count; i++)
		{
			if (!_sfxPool[i].isPlaying)
			{
				return _sfxPool[i];
			}
		}
		AudioSource result = _sfxPool[_nextSfxPoolIndex];
		_nextSfxPoolIndex = (_nextSfxPoolIndex + 1) % _sfxPool.Count;
		return result;
	}

	public static void PlayBiomassPickup()
	{
		if (!(Instance == null) && !string.IsNullOrEmpty(Instance.biomassCollectionSoundID) && Instance._soundLookup.ContainsKey(Instance.biomassCollectionSoundID))
		{
			SoundAudioClip soundAudioClip = Instance._soundLookup[Instance.biomassCollectionSoundID];
			AudioSource availableSfxSource = Instance.GetAvailableSfxSource();
			if (Time.time - Instance.lastBiomassCollectionTime <= Instance.comboResetTime)
			{
				Instance.currentBiomassComboCount++;
			}
			else
			{
				Instance.currentBiomassComboCount = 1;
			}
			Instance.lastBiomassCollectionTime = Time.time;
			int num = Mathf.Min(Instance.currentBiomassComboCount, Instance.maxComboCountForScaling);
			float a = Instance.baseBiomassSoundPitch + (float)(num - 1) * Instance.comboPitchStep;
			a = Mathf.Min(a, Instance.maxComboPitch);
			float value = Instance.baseBiomassSoundVolume + (float)(num - 1) * Instance.comboVolumeStep;
			value = Mathf.Min(Mathf.Clamp01(value), Instance.maxComboVolume);
			value *= Instance.globalSfxVolume;
			availableSfxSource.clip = soundAudioClip.audioClip;
			availableSfxSource.volume = value;
			availableSfxSource.pitch = a;
			availableSfxSource.Play();
		}
	}

	private void SyncMixerVolumes()
	{
		if (!(audioMixer == null))
		{
			audioMixer.SetFloat(masterVolumeParam, VolumeToDecibels(1f));
			audioMixer.SetFloat(musicVolumeParam, VolumeToDecibels(globalMusicVolume));
			audioMixer.SetFloat(ambianceVolumeParam, VolumeToDecibels(globalAmbianceVolume));
			audioMixer.SetFloat(sfxVolumeParam, VolumeToDecibels(globalSfxVolume));
		}
	}

	private float VolumeToDecibels(float volume)
	{
		if (!(volume > 0.0001f))
		{
			return -80f;
		}
		return Mathf.Log10(volume) * 20f;
	}

	public void SaveSettings()
	{
		PlayerPrefs.SetFloat("MusicVolume", globalMusicVolume);
		PlayerPrefs.SetFloat("AmbienceVolume", globalAmbianceVolume);
		PlayerPrefs.SetFloat("SFXVolume", globalSfxVolume);
		PlayerPrefs.Save();
	}

	private void LoadSettings()
	{
		bool num = !PlayerPrefs.HasKey("MusicVolume");
		globalMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.15f);
		globalAmbianceVolume = PlayerPrefs.GetFloat("AmbienceVolume", 0.4f);
		globalSfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.33f);
		if (num)
		{
			SaveSettings();
		}
		if (_musicSource != null)
		{
			_musicSource.volume = globalMusicVolume;
		}
		if (_ambianceSource != null)
		{
			_ambianceSource.volume = globalAmbianceVolume;
		}
		SyncMixerVolumes();
	}
}
