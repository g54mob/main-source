using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSystem : MonoBehaviour
{
	public enum EAudioMixerGroup
	{
		Master = 0,
		Music = 1,
		SFX = 2,
		UI = 3,
		Ambience = 4
	}

	public enum EAudioPriority
	{
		VeryHigh = 10,
		High = 80,
		Normal = 128,
		Low = 200,
		VeryLow = 250
	}

	[Serializable]
	public class AudioMixerConfig
	{
		public AudioMixerGroup mixer;

		public bool bypassAudioListenerPause;
	}

	private static AudioSystem instance;

	[SerializeField]
	private AudioMixerConfig masterMixer;

	[SerializeField]
	private AudioMixerConfig musicMixer;

	[SerializeField]
	private AudioMixerConfig sfxMixer;

	[SerializeField]
	private AudioMixerConfig uiMixer;

	[SerializeField]
	private AudioMixerConfig ambienceMixer;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("Volumen global por defecto en caso de que no haya uno especificado en PlayerPrefs")]
	private float defaultMasterVolumePercentage = 1f;

	[SerializeField]
	private int startAudioSources = 20;

	[SerializeField]
	private AnimationCurve defaultCustomRolloffCurve;

	private List<AudioSource> audioSources = new List<AudioSource>();

	private Dictionary<EAudioMixerGroup, AudioSource> oneShotAudioSources = new Dictionary<EAudioMixerGroup, AudioSource>();

	private Tweener musicAudioTweener;

	private Tweener sfxAudioTweener;

	private Tweener ambienceAudioTweener;

	public static AudioSystem Instance => instance;

	protected virtual void Awake()
	{
		InitAudioSources(startAudioSources, initOneShotAS: true);
		instance = this;
	}

	protected virtual void Start()
	{
		LoadPlayerPrefs();
		AudioListener.volume = 1f;
		AudioListener.pause = false;
		GameManager.instance.onPause += OnGamePaused;
		GameManager.instance.onResume += OnGameResumed;
	}

	private void InitAudioSources(int amountToInit, bool initOneShotAS = false)
	{
		for (int i = 0; i < amountToInit; i++)
		{
			GameObject obj = new GameObject("AudioSystem_Source" + audioSources.Count, typeof(AudioSource));
			obj.transform.parent = base.transform;
			AudioSource component = obj.GetComponent<AudioSource>();
			component.playOnAwake = false;
			audioSources.Add(component);
		}
		if (!initOneShotAS)
		{
			return;
		}
		foreach (EAudioMixerGroup value in Enum.GetValues(typeof(EAudioMixerGroup)))
		{
			GameObject obj2 = new GameObject("AudioSystem_Source" + value, typeof(AudioSource));
			obj2.transform.SetParent(base.transform);
			AudioSource component = obj2.GetComponent<AudioSource>();
			component.playOnAwake = false;
			component.outputAudioMixerGroup = GetAudioMixerConfig(value).mixer;
			oneShotAudioSources.Add(value, component);
		}
	}

	public AudioSource PlaySound2D(AudioClip clip, EAudioMixerGroup mixer = EAudioMixerGroup.Master, float volume = 1f, float pitch = 1f, float startTime = 0f, float delay = 0f, bool loop = false, EAudioPriority priority = EAudioPriority.Normal)
	{
		AudioSource freeAudioSource = GetFreeAudioSource();
		if ((bool)freeAudioSource && (bool)clip)
		{
			freeAudioSource.clip = clip;
			freeAudioSource.volume = volume;
			freeAudioSource.pitch = pitch;
			freeAudioSource.spatialBlend = 0f;
			freeAudioSource.outputAudioMixerGroup = GetAudioMixerConfig(mixer).mixer;
			freeAudioSource.time = startTime;
			freeAudioSource.loop = loop;
			freeAudioSource.priority = (int)priority;
			if (GetAudioMixerConfig(mixer).bypassAudioListenerPause)
			{
				freeAudioSource.ignoreListenerPause = true;
			}
			else
			{
				freeAudioSource.ignoreListenerPause = false;
			}
			if (delay > 0f)
			{
				freeAudioSource.PlayScheduled(AudioSettings.dspTime + (double)delay);
			}
			else
			{
				freeAudioSource.Play();
			}
		}
		return freeAudioSource;
	}

	public AudioSource PlaySound2D(AudioData audioData, EAudioMixerGroup mixer = EAudioMixerGroup.Master, float startTime = 0f, float delay = 0f, bool loop = false, EAudioPriority priority = EAudioPriority.Normal)
	{
		return PlaySound2D(audioData.GetRandomAudioClip, mixer, audioData.Volume, audioData.Pitch, startTime, delay, loop, priority);
	}

	public bool PlaySound2DOneShot(AudioClip clip, EAudioMixerGroup mixer = EAudioMixerGroup.Master, float volume = 1f, EAudioPriority priority = EAudioPriority.Normal)
	{
		AudioSource oneShotAudioSourceByMixer = GetOneShotAudioSourceByMixer(mixer);
		if ((bool)oneShotAudioSourceByMixer)
		{
			oneShotAudioSourceByMixer.spatialBlend = 0f;
			oneShotAudioSourceByMixer.priority = (int)priority;
			oneShotAudioSourceByMixer.PlayOneShot(clip, volume);
			return true;
		}
		return false;
	}

	public bool PlaySound2DOneShot(AudioData audioData, EAudioMixerGroup mixer = EAudioMixerGroup.Master, EAudioPriority priority = EAudioPriority.Normal)
	{
		return PlaySound2DOneShot(audioData.GetRandomAudioClip, mixer, audioData.Volume, priority);
	}

	public AudioSource PlaySound3D(AudioClip clip, Vector3 position, EAudioMixerGroup mixer = EAudioMixerGroup.Master, float volume = 1f, float pitch = 1f, AudioRolloffMode rollOffMode = AudioRolloffMode.Logarithmic, float minDistance = 1f, float maxDistance = 500f, AnimationCurve rolloffCurve = null, float startTime = 0f, float doppler = 0f, bool loop = false, float delay = 0f, EAudioPriority priority = EAudioPriority.Normal)
	{
		AudioSource freeAudioSource = GetFreeAudioSource();
		if ((bool)freeAudioSource)
		{
			freeAudioSource.clip = clip;
			freeAudioSource.volume = volume;
			freeAudioSource.pitch = pitch;
			freeAudioSource.spatialBlend = 1f;
			freeAudioSource.dopplerLevel = doppler;
			freeAudioSource.rolloffMode = rollOffMode;
			freeAudioSource.minDistance = minDistance;
			freeAudioSource.maxDistance = maxDistance;
			freeAudioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, (rolloffCurve != null) ? rolloffCurve : defaultCustomRolloffCurve);
			freeAudioSource.outputAudioMixerGroup = GetAudioMixerConfig(mixer).mixer;
			freeAudioSource.loop = loop;
			freeAudioSource.priority = (int)priority;
			freeAudioSource.time = startTime;
			freeAudioSource.transform.position = position;
			if (GetAudioMixerConfig(mixer).bypassAudioListenerPause)
			{
				freeAudioSource.ignoreListenerPause = true;
			}
			else
			{
				freeAudioSource.ignoreListenerPause = false;
			}
			if (delay > 0f)
			{
				freeAudioSource.PlayDelayed(delay);
			}
			else
			{
				freeAudioSource.Play();
			}
		}
		return freeAudioSource;
	}

	public AudioSource PlaySound3D(AudioData audioData, Vector3 position, EAudioMixerGroup mixer = EAudioMixerGroup.Master, AudioRolloffMode rollOffMode = AudioRolloffMode.Logarithmic, float minDistance = 1f, float maxDistance = 500f, AnimationCurve rolloffCurve = null, float startTime = 0f, float doppler = 0f, bool loop = false, float delay = 0f, EAudioPriority priority = EAudioPriority.Normal)
	{
		return PlaySound3D(audioData.GetRandomAudioClip, position, mixer, audioData.Volume, audioData.Pitch, rollOffMode, minDistance, maxDistance, rolloffCurve, startTime, doppler, loop, delay, priority);
	}

	public void StopAllSoundsByMixer(EAudioMixerGroup mixer)
	{
		AudioMixerGroup mixer2 = GetAudioMixerConfig(mixer).mixer;
		foreach (AudioSource audioSource in audioSources)
		{
			if (audioSource.outputAudioMixerGroup == mixer2)
			{
				audioSource.Stop();
			}
		}
	}

	public Coroutine FadeAudioSource(AudioSource audioSource, float targetVolume, float fadeTime, bool unscaledDeltaTime = false, float delay = 0f)
	{
		return StartCoroutine(FadeAudioSourceCoroutine(audioSource, targetVolume, fadeTime, unscaledDeltaTime, delay));
	}

	public AudioSource CrossfadeSounds(AudioSource mainAS, AudioClip clip, float crossTime = 1f, float startTime = 0f, float volumeOverride = -1f, bool unscaledDeltaTime = false)
	{
		AudioSource freeAudioSource = GetFreeAudioSource();
		freeAudioSource.transform.position = mainAS.transform.position;
		freeAudioSource.pitch = mainAS.pitch;
		freeAudioSource.dopplerLevel = mainAS.dopplerLevel;
		freeAudioSource.spatialBlend = mainAS.spatialBlend;
		freeAudioSource.rolloffMode = mainAS.rolloffMode;
		freeAudioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, mainAS.GetCustomCurve(AudioSourceCurveType.CustomRolloff));
		freeAudioSource.minDistance = mainAS.minDistance;
		freeAudioSource.maxDistance = mainAS.maxDistance;
		freeAudioSource.priority = mainAS.priority;
		freeAudioSource.outputAudioMixerGroup = mainAS.outputAudioMixerGroup;
		freeAudioSource.loop = mainAS.loop;
		mainAS.loop = false;
		freeAudioSource.clip = clip;
		if ((bool)clip)
		{
			freeAudioSource.time = startTime;
		}
		freeAudioSource.volume = 0f;
		freeAudioSource.Play();
		StartCoroutine(FadeAudioSourceCoroutine(freeAudioSource, (volumeOverride >= 0f) ? volumeOverride : mainAS.volume, crossTime, unscaledDeltaTime));
		StartCoroutine(FadeAudioSourceCoroutine(mainAS, 0f, crossTime, unscaledDeltaTime));
		return freeAudioSource;
	}

	public AudioMixerConfig GetAudioMixerConfig(EAudioMixerGroup audioMixerGroup)
	{
		return audioMixerGroup switch
		{
			EAudioMixerGroup.Master => masterMixer, 
			EAudioMixerGroup.SFX => sfxMixer, 
			EAudioMixerGroup.Music => musicMixer, 
			EAudioMixerGroup.UI => uiMixer, 
			EAudioMixerGroup.Ambience => ambienceMixer, 
			_ => masterMixer, 
		};
	}

	private AudioSource GetFreeAudioSource(bool createNewIfAllOccupied = true)
	{
		foreach (AudioSource audioSource in audioSources)
		{
			if ((bool)audioSource && !audioSource.isPlaying)
			{
				return audioSource;
			}
		}
		if (createNewIfAllOccupied)
		{
			InitAudioSources(1);
			return audioSources[audioSources.Count - 1];
		}
		return null;
	}

	public void SetMixerVolume(float mixerVolume, EAudioMixerGroup mixer)
	{
		GetAudioMixerConfig(mixer).mixer.audioMixer.SetFloat(mixer.ToString() + "Volume", Mathf.Log(Mathf.Max(mixerVolume, 0.0001f)) * 20f);
	}

	public void SetMixerPitch(float mixerPitch, EAudioMixerGroup mixer)
	{
		GetAudioMixerConfig(mixer).mixer.audioMixer.SetFloat(mixer.ToString() + "Pitch", mixerPitch);
	}

	public float GetMixerVolumePercentage(EAudioMixerGroup mixer)
	{
		switch (mixer)
		{
		case EAudioMixerGroup.Master:
			if (PlayerPrefs.HasKey("MasterVolumePercentage"))
			{
				return PlayerPrefs.GetFloat("MasterVolumePercentage");
			}
			break;
		case EAudioMixerGroup.Music:
			if (PlayerPrefs.HasKey("MusicVolumePercentage"))
			{
				return PlayerPrefs.GetFloat("MusicVolumePercentage");
			}
			break;
		case EAudioMixerGroup.SFX:
			if (PlayerPrefs.HasKey("SoundVolumePercentage"))
			{
				return PlayerPrefs.GetFloat("SoundVolumePercentage");
			}
			break;
		case EAudioMixerGroup.UI:
			if (PlayerPrefs.HasKey("SoundVolumePercentage"))
			{
				return PlayerPrefs.GetFloat("SoundVolumePercentage");
			}
			break;
		case EAudioMixerGroup.Ambience:
			if (PlayerPrefs.HasKey("SoundVolumePercentage"))
			{
				return PlayerPrefs.GetFloat("SoundVolumePercentage");
			}
			break;
		}
		return GetCurrentMixerVolumePercentage(mixer);
	}

	public float GetCurrentMixerVolumePercentage(EAudioMixerGroup mixer)
	{
		GetAudioMixerConfig(mixer).mixer.audioMixer.GetFloat(mixer.ToString() + "Volume", out var value);
		return Mathf.Exp(value / 20f);
	}

	public void ResetAllMixersVolumes()
	{
		SetMixerVolume(GetMixerVolumePercentage(EAudioMixerGroup.Master), EAudioMixerGroup.Master);
		SetMixerVolume(GetMixerVolumePercentage(EAudioMixerGroup.Music), EAudioMixerGroup.Music);
		SetMixerVolume(GetMixerVolumePercentage(EAudioMixerGroup.SFX), EAudioMixerGroup.SFX);
		SetMixerVolume(GetMixerVolumePercentage(EAudioMixerGroup.UI), EAudioMixerGroup.UI);
		SetMixerVolume(GetMixerVolumePercentage(EAudioMixerGroup.Ambience), EAudioMixerGroup.Ambience);
	}

	private AudioSource GetOneShotAudioSourceByMixer(EAudioMixerGroup mixer)
	{
		if (oneShotAudioSources.ContainsKey(mixer))
		{
			return oneShotAudioSources[mixer];
		}
		return null;
	}

	private IEnumerator FadeAudioSourceCoroutine(AudioSource audioSource, float targetVolume, float fadeTime, bool unscaledDeltaTime = false, float delay = 0f)
	{
		float time = 0f;
		float startVolume = audioSource.volume;
		if (unscaledDeltaTime)
		{
			yield return new WaitForSecondsRealtime(delay);
		}
		else
		{
			yield return new WaitForSeconds(delay);
		}
		if (!audioSource.isPlaying)
		{
			audioSource.Play();
		}
		while (time <= fadeTime && audioSource.volume != targetVolume)
		{
			time += (unscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime);
			audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / fadeTime);
			yield return null;
		}
		if (targetVolume == 0f)
		{
			audioSource.Stop();
		}
	}

	private void LoadPlayerPrefs()
	{
		if (PlayerPrefs.HasKey("MasterVolumePercentage"))
		{
			float mixerVolume = PlayerPrefs.GetFloat("MasterVolumePercentage");
			SetMixerVolume(mixerVolume, EAudioMixerGroup.Master);
		}
		else
		{
			SetMixerVolume(defaultMasterVolumePercentage, EAudioMixerGroup.Master);
			PlayerPrefs.SetFloat("MasterVolumePercentage", defaultMasterVolumePercentage);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("MusicVolumePercentage"))
		{
			float mixerVolume2 = PlayerPrefs.GetFloat("MusicVolumePercentage");
			SetMixerVolume(mixerVolume2, EAudioMixerGroup.Music);
		}
		else
		{
			SetMixerVolume(1f, EAudioMixerGroup.Music);
			PlayerPrefs.SetFloat("MusicVolumePercentage", 1f);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("SoundVolumePercentage"))
		{
			float mixerVolume3 = PlayerPrefs.GetFloat("SoundVolumePercentage");
			SetMixerVolume(mixerVolume3, EAudioMixerGroup.SFX);
		}
		else
		{
			SetMixerVolume(1f, EAudioMixerGroup.SFX);
			PlayerPrefs.SetFloat("SoundVolumePercentage", 1f);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("UIVolumePercentage"))
		{
			float mixerVolume4 = PlayerPrefs.GetFloat("UIVolumePercentage");
			SetMixerVolume(mixerVolume4, EAudioMixerGroup.UI);
		}
		else
		{
			SetMixerVolume(1f, EAudioMixerGroup.UI);
			PlayerPrefs.SetFloat("UIVolumePercentage", 1f);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("AmbienceVolumePercentage"))
		{
			float mixerVolume5 = PlayerPrefs.GetFloat("AmbienceVolumePercentage");
			SetMixerVolume(mixerVolume5, EAudioMixerGroup.Ambience);
		}
		else
		{
			SetMixerVolume(1f, EAudioMixerGroup.Ambience);
			PlayerPrefs.SetFloat("AmbienceVolumePercentage", 1f);
			PlayerPrefs.Save();
		}
	}

	public virtual void OnGamePaused()
	{
		sfxAudioTweener.Kill();
		ambienceAudioTweener.Kill();
		sfxAudioTweener = DOVirtual.Float(GetCurrentMixerVolumePercentage(EAudioMixerGroup.SFX), 0f, 0.25f, delegate(float volume)
		{
			SetMixerVolume(volume, EAudioMixerGroup.SFX);
		}).SetUpdate(isIndependentUpdate: true);
		ambienceAudioTweener = DOVirtual.Float(GetCurrentMixerVolumePercentage(EAudioMixerGroup.Ambience), 0f, 0.25f, delegate(float volume)
		{
			SetMixerVolume(volume, EAudioMixerGroup.Ambience);
		}).SetUpdate(isIndependentUpdate: true);
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
		{
			PauseMusic(pause: true, 0.25f);
		}
	}

	public virtual void OnGameResumed()
	{
		sfxAudioTweener.Kill();
		ambienceAudioTweener.Kill();
		PauseMusic(pause: false, 0.25f);
		sfxAudioTweener = DOVirtual.Float(GetCurrentMixerVolumePercentage(EAudioMixerGroup.SFX), GetMixerVolumePercentage(EAudioMixerGroup.SFX), 0.25f, delegate(float volume)
		{
			SetMixerVolume(volume, EAudioMixerGroup.SFX);
		});
		ambienceAudioTweener = DOVirtual.Float(GetCurrentMixerVolumePercentage(EAudioMixerGroup.Ambience), GetMixerVolumePercentage(EAudioMixerGroup.Ambience), 0.25f, delegate(float volume)
		{
			SetMixerVolume(volume, EAudioMixerGroup.Ambience);
		});
	}

	public virtual void PauseMusic(bool pause, float fadeTime)
	{
		musicAudioTweener.Kill();
		if (pause)
		{
			musicAudioTweener = DOVirtual.Float(GetCurrentMixerVolumePercentage(EAudioMixerGroup.Music), 0f, fadeTime, delegate(float volume)
			{
				SetMixerVolume(volume, EAudioMixerGroup.Music);
			}).SetUpdate(isIndependentUpdate: true);
		}
		else
		{
			musicAudioTweener = DOVirtual.Float(GetCurrentMixerVolumePercentage(EAudioMixerGroup.Music), GetMixerVolumePercentage(EAudioMixerGroup.Music), fadeTime, delegate(float volume)
			{
				SetMixerVolume(volume, EAudioMixerGroup.Music);
			});
		}
	}
}
