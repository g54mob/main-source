using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
	public GameObject soundInstancePrefab;

	public AudioMixer audioMixer;

	[SerializeField]
	private SoundLibrary library;

	[SerializeField]
	private AudioSource musicAudioSource;

	private List<SoundContainer> sounds = new List<SoundContainer>();

	private List<SoundInstance> soundInstances = new List<SoundInstance>();

	public static UnityEvent OnChangeMusicEvent = new UnityEvent();

	public static UnityEvent OnStopMusicEvent = new UnityEvent();

	private static SoundManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		UnityEngine.Object.DontDestroyOnLoad(instance);
		CombineGroups();
	}

	private void CombineGroups()
	{
		List<SoundContainer> list = new List<SoundContainer>();
		sounds.Clear();
		for (int i = 0; i < library.soundGroups.Count; i++)
		{
			List<SoundContainer> list2 = new List<SoundContainer>(library.soundGroups[i].sounds);
			foreach (SoundContainer item in list2)
			{
				if (!item.name.Contains(library.soundGroups[i].label.ToLower()))
				{
					string text = item.name;
					item.name = library.soundGroups[i].label.ToLower() + "_" + text;
				}
			}
			list.AddRange(list2);
		}
		sounds = list;
	}

	public static SoundContainer GetSoundContainer(string name)
	{
		return instance.sounds.Find((SoundContainer x) => x.name == name.ToLower());
	}

	public static AudioSource SetupExistingAudioSource(string name, AudioSource source)
	{
		SoundContainer soundContainer = GetSoundContainer(name);
		if (soundContainer == null)
		{
			return null;
		}
		source.outputAudioMixerGroup = soundContainer.group;
		if (soundContainer.selectRandomClip)
		{
			int num = UnityEngine.Random.Range(0, soundContainer.audioClip.Length);
			source.clip = soundContainer.audioClip[num];
		}
		else
		{
			source.clip = soundContainer.audioClip[0];
		}
		source.loop = soundContainer.loop;
		source.volume = soundContainer.volume;
		source.pitch = soundContainer.pitch;
		source.spatialBlend = soundContainer.spatialBlend;
		return source;
	}

	public static void StopSoundContainingKey(string name, bool destroy = true)
	{
		Transform transform = instance.transform.Find("SoundInstance_" + name);
		if (!(transform == null))
		{
			transform.GetComponent<AudioSource>().Stop();
			if (destroy)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
	}

	private void Update()
	{
		soundInstances.RemoveAll((SoundInstance x) => x.GetWorldInstance() == null);
		foreach (SoundInstance soundInstance in soundInstances)
		{
			if (!(soundInstance.GetWorldInstance() == null) && !soundInstance.GetSource().isPlaying)
			{
				soundInstance.DestroyInstance();
			}
		}
	}

	public static void PlaySound(string name, Transform parent = null)
	{
		SoundContainer soundContainer = instance.sounds.Find((SoundContainer x) => x.name == name.ToLower());
		if (soundContainer != null)
		{
			instance.CreateSoundInstance(parent, soundContainer, soundContainer.loop).GetSource().Play();
		}
	}

	public static void PlaySoundOnce(string name)
	{
		if (!(instance == null) && instance.sounds.Count != 0)
		{
			SoundContainer soundContainer = instance.sounds.Find((SoundContainer x) => x.name.ToLower() == name.ToLower());
			if (soundContainer == null)
			{
				Debug.LogWarning("Soundcontainer not found: " + name);
			}
			else
			{
				instance.CreateSoundInstance(null, soundContainer, loop: false).GetSource().Play();
			}
		}
	}

	public static void PlaySoundOnce(string name, bool noDuplicates)
	{
		if (instance == null || instance.sounds.Count == 0)
		{
			return;
		}
		if (noDuplicates)
		{
			Transform transform = instance.transform.Find("SoundInstance_" + name);
			if (transform == null)
			{
				PlaySoundOnce(name);
				return;
			}
			AudioSource component = transform.GetComponent<AudioSource>();
			component.Stop();
			SetupExistingAudioSource(name, component);
			component.Play();
		}
		else
		{
			PlaySoundOnce(name);
		}
	}

	public static void PlaySoundOnce(string name, Transform parent = null)
	{
		SoundContainer soundContainer = instance.sounds.Find((SoundContainer x) => x.name == name.ToLower());
		if (soundContainer != null)
		{
			instance.CreateSoundInstance(parent, soundContainer, loop: false).GetSource().Play();
		}
	}

	public static void PlaySoundOnceDelayed(string name, Transform parent = null, float delay = 0.1f)
	{
		SoundContainer soundContainer = instance.sounds.Find((SoundContainer x) => x.name == name.ToLower());
		if (soundContainer != null)
		{
			instance.CreateSoundInstance(parent, soundContainer, loop: false).GetSource().PlayDelayed(delay);
		}
	}

	public static AudioSource PlaySoundLoop(string name, Transform parent = null)
	{
		SoundContainer soundContainer = instance.sounds.Find((SoundContainer x) => x.name == name.ToLower());
		if (soundContainer == null)
		{
			return null;
		}
		SoundInstance soundInstance = instance.CreateSoundInstance(parent, soundContainer, loop: true);
		soundInstance.GetSource().Play();
		return soundInstance.GetSource();
	}

	public static void ChangeMusic(string name, float duration = 1f)
	{
		float currentVolume = GetVolume("MusicVolume");
		Action action = delegate
		{
			instance.musicAudioSource.Stop();
			AudioSource audioSource = SetupExistingAudioSource(name, instance.musicAudioSource);
			if (audioSource == null)
			{
				instance.musicAudioSource.clip = null;
			}
			else
			{
				instance.musicAudioSource = audioSource;
			}
			instance.musicAudioSource.volume = 0f;
			TweenerManager.TweenAudioSourceFade("Start_Music_Fade_Out", instance.musicAudioSource, 0f, currentVolume, duration, TweenerManager.GetDefaultEaseCurve(), null);
			instance.musicAudioSource.Play();
			OnChangeMusicEvent.Invoke();
		};
		TweenerManager.TweenAudioSourceFade("Start_Music_Fade_In", instance.musicAudioSource, currentVolume, 0f, duration, TweenerManager.GetDefaultEaseCurve(), action);
	}

	public static bool IsPlayingMusic()
	{
		return instance.musicAudioSource.isPlaying;
	}

	public static void StopMusic()
	{
		instance.musicAudioSource.Stop();
		OnStopMusicEvent.Invoke();
	}

	private SoundInstance CreateSoundInstance(Transform parent, SoundContainer sound, bool loop)
	{
		Transform transform = ((parent == null) ? base.transform : parent.transform);
		GameObject obj = UnityEngine.Object.Instantiate(soundInstancePrefab, transform.position, Quaternion.identity, transform);
		AudioSource component = obj.GetComponent<AudioSource>();
		SoundInstance soundInstance = new SoundInstance(obj, component);
		soundInstances.Add(soundInstance);
		obj.name = "SoundInstance_" + sound.name;
		component.outputAudioMixerGroup = sound.group;
		if (sound.selectRandomClip)
		{
			int num = UnityEngine.Random.Range(0, sound.audioClip.Length);
			component.clip = sound.audioClip[num];
		}
		else
		{
			component.clip = sound.audioClip[0];
		}
		component.loop = loop;
		component.volume = sound.volume;
		component.pitch = sound.pitch;
		component.spatialBlend = sound.spatialBlend;
		return soundInstance;
	}

	private void ApplySource(AudioSource source, SoundContainer sound, bool loop)
	{
		source.outputAudioMixerGroup = sound.group;
		if (sound.selectRandomClip)
		{
			int num = UnityEngine.Random.Range(0, sound.audioClip.Length);
			source.clip = sound.audioClip[num];
		}
		else
		{
			source.clip = sound.audioClip[0];
		}
		source.loop = loop;
		source.volume = sound.volume;
		source.pitch = sound.pitch;
		source.spatialBlend = sound.spatialBlend;
	}

	public static void SetVolume(string mixerProperty = "MasterVolume", float volume = 0.5f)
	{
		if (volume <= 0f)
		{
			volume = 1E-06f;
		}
		instance.audioMixer.SetFloat(mixerProperty, Mathf.Log10(volume) * 20f);
	}

	public static float GetVolume(string mixerProperty = "MasterVolume")
	{
		instance.audioMixer.GetFloat(mixerProperty, out var value);
		return Mathf.Pow(10f, value / 20f);
	}
}
