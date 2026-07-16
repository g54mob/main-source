using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitAudioController : MonoBehaviour
{
	private const float MIN_RANDOM_PITCH = 0.9f;

	private const float MAX_RANDOM_PITCH = 1.1f;

	private AudioSource mainAS;

	private List<AudioSource> audioChannels = new List<AudioSource>();

	[Header("Initialization Settings")]
	[SerializeField]
	private bool initFromAudioClips;

	[SerializeField]
	private bool playMainOnStart = true;

	[SerializeField]
	private bool playChannelsOnStart;

	[Header("Main Audio Settings")]
	[SerializeField]
	private List<AudioClip> mainClips;

	[SerializeField]
	[Range(0f, 1f)]
	private float mainVolume = 1f;

	[SerializeField]
	private bool loopMain = true;

	[SerializeField]
	private AMG mainAudioGroup = AMG.SFX;

	[Header("Channel Audio Settings")]
	[SerializeField]
	private List<AudioClip> audioClips = new List<AudioClip>();

	[SerializeField]
	[Range(0f, 1f)]
	private float channelsVolume = 0.5f;

	[SerializeField]
	private bool loopChannels;

	[SerializeField]
	private AMG channelsAudioGroup = AMG.SFX;

	[Header("Randomizer")]
	[SerializeField]
	private float minRandomPitch = 0.9f;

	[SerializeField]
	private float maxRandomPitch = 1.1f;

	[SerializeField]
	private bool initiallyRandomizeMain = true;

	[SerializeField]
	private bool randomizeMain;

	[SerializeField]
	private bool initiallyRandomizeChannels = true;

	[SerializeField]
	private bool randomizeChannels;

	public event Action OnInitialized;

	private void Awake()
	{
		if (base.gameObject.GetComponent<RectTransform>() == null)
		{
			ClearComponents();
		}
	}

	private void Start()
	{
		Init();
		mainAS = base.gameObject.AddComponent<AudioSource>();
		mainAS.volume = mainVolume;
		mainAS.loop = loopMain;
		mainAS.playOnAwake = playMainOnStart;
		SetAudioGroupForMain(mainAudioGroup);
		if (initiallyRandomizeMain)
		{
			SetRandomPitchOnMain(minRandomPitch, maxRandomPitch);
		}
		if (mainClips != null && mainClips.Count > 0)
		{
			mainAS.clip = mainClips[0];
			if (playMainOnStart && mainAS.clip != null)
			{
				mainAS.Play();
			}
		}
		audioChannels = new List<AudioSource>();
		if (initFromAudioClips)
		{
			foreach (AudioClip audioClip in audioClips)
			{
				AddChannel(audioClip);
			}
		}
		this.OnInitialized?.Invoke();
	}

	private void Update()
	{
		if (randomizeMain && mainAS.clip != null && mainAS.isPlaying)
		{
			SetRandomPitchOnMain(minRandomPitch, maxRandomPitch);
		}
		if (!randomizeChannels)
		{
			return;
		}
		foreach (AudioSource audioChannel in audioChannels)
		{
			if (audioChannel.clip != null && audioChannel.isPlaying)
			{
				SetRandomPitchOnChannel(audioChannel, minRandomPitch, maxRandomPitch);
			}
		}
	}

	public void Init()
	{
	}

	private void ClearComponents()
	{
		Component[] components = GetComponents<Component>();
		foreach (Component component in components)
		{
			if (!(component is Transform) && !(component is UnitAudioController))
			{
				UnityEngine.Object.DestroyImmediate(component, allowDestroyingAssets: true);
			}
		}
	}

	public AudioSource AddChannel(AudioClip clip = null)
	{
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.volume = channelsVolume;
		audioSource.loop = loopChannels;
		audioSource.playOnAwake = playChannelsOnStart;
		SetAudioGroupForChannel(audioSource, channelsAudioGroup);
		audioChannels.Add(audioSource);
		if (clip != null)
		{
			audioSource.clip = clip;
		}
		if (initiallyRandomizeChannels)
		{
			SetRandomPitchOnChannel(audioSource, minRandomPitch, maxRandomPitch);
		}
		if (playChannelsOnStart && clip != null)
		{
			audioSource.Play();
		}
		return audioSource;
	}

	public AudioSource AddChannel(int clipIndex)
	{
		return AddChannel((clipIndex >= 0 && clipIndex < audioClips.Count) ? audioClips[clipIndex] : null);
	}

	public void PlayOnMain(bool muteOthers = false, bool loop = false)
	{
		if (mainAS.clip != null)
		{
			if (muteOthers)
			{
				MuteChannels(mainAS);
			}
			if (!loopMain)
			{
				mainAS.loop = loop;
			}
			mainAS.Play();
		}
		else
		{
			Debug.LogError("No clip assigned to main audio source");
		}
	}

	public void StopMain()
	{
		if (mainAS.isPlaying)
		{
			mainAS.Stop();
		}
	}

	public void SetClipOnMain(AudioClip clip)
	{
		if (mainAS != null)
		{
			mainAS.clip = clip;
		}
		else
		{
			Debug.LogError("Main audio source is null");
		}
	}

	public void SetClipOnMain(int clipIndex)
	{
		if (clipIndex >= 0 && clipIndex < mainClips.Count)
		{
			SetClipOnMain(mainClips[clipIndex]);
		}
		else
		{
			Debug.LogError("Clip index out of range for main audio source");
		}
	}

	public void SetVolumeOnMain(float volume)
	{
		if (mainAS != null)
		{
			mainAS.volume = volume;
		}
		else
		{
			Debug.LogError("Main audio source is null");
		}
	}

	public void SetRandomPitchOnMain(float min = 0.9f, float max = 1.1f)
	{
		if (mainAS != null)
		{
			mainAS.pitch = UnityEngine.Random.Range(min, max);
		}
		else
		{
			Debug.LogError("Main audio source is null");
		}
	}

	public void SetAudioGroupForMain(AMG audioGroup)
	{
		if (mainAS != null)
		{
			switch (audioGroup)
			{
			case AMG.Master:
				mainAS.outputAudioMixerGroup = AudioManager.Instance.MasterGroup;
				break;
			case AMG.Music:
				mainAS.outputAudioMixerGroup = AudioManager.Instance.MusicGroup;
				break;
			case AMG.SFX:
				mainAS.outputAudioMixerGroup = AudioManager.Instance.SfxGroup;
				break;
			default:
				Debug.LogError("Invalid audio group specified for main audio source");
				break;
			}
		}
		else
		{
			Debug.LogError("Main audio source is null");
		}
	}

	public AudioSource GetMainChannel()
	{
		if (mainAS != null)
		{
			return mainAS;
		}
		Debug.LogError("Main audio source is null");
		return null;
	}

	public void PlayOnChannel(AudioSource channel, bool muteOthers = false, bool loop = false, bool randomize = false)
	{
		if (channel == null)
		{
			Debug.LogError("Channel is null");
			return;
		}
		if (!audioChannels.Contains(channel))
		{
			Debug.LogError("Channel is not from this audio controller");
			return;
		}
		if (muteOthers)
		{
			MuteChannels(channel);
		}
		if (randomize)
		{
			SetRandomPitchOnChannel(channel);
		}
		channel.loop = loop;
		channel.Play();
	}

	public void PlayOnChannel(int channelIndex, bool muteOthers = false, bool loop = false, bool randomize = false)
	{
		if (channelIndex < 0 || channelIndex >= audioChannels.Count)
		{
			Debug.LogError("Channel index out of range");
		}
		else
		{
			PlayOnChannel(audioChannels[channelIndex], muteOthers, loop, randomize);
		}
	}

	public void PlayOnChannel(int channelIndex, AudioClip clip, bool muteOthers = false, bool loop = false, bool randomize = false)
	{
		if (channelIndex < 0 || channelIndex >= audioChannels.Count)
		{
			Debug.LogError("Channel index out of range");
		}
		else
		{
			PlayOnChannel(audioChannels[channelIndex], clip, muteOthers, loop, randomize);
		}
	}

	public void PlayOnChannel(AudioSource channel, AudioClip clip, bool muteOthers = false, bool loop = false, bool randomize = false)
	{
		if (channel == null)
		{
			Debug.LogError("Channel is null");
			return;
		}
		if (!audioChannels.Contains(channel))
		{
			Debug.LogError("Channel is not from this audio controller");
			return;
		}
		channel.clip = clip;
		PlayOnChannel(channel, muteOthers, loop, randomize);
	}

	public void StopChannel(int channelIndex)
	{
		if (channelIndex < 0 || channelIndex >= audioChannels.Count)
		{
			Debug.LogError("Channel index out of range");
			return;
		}
		AudioSource audioSource = audioChannels[channelIndex];
		if (audioSource.isPlaying)
		{
			audioSource.Stop();
		}
	}

	public void StopChannel(AudioSource channel)
	{
		if (channel == null)
		{
			Debug.LogError("Channel is null");
		}
		else if (!audioChannels.Contains(channel))
		{
			Debug.LogError("Channel is not from this audio controller");
		}
		else if (channel.isPlaying)
		{
			channel.Stop();
		}
	}

	public void SetClipOnChannel(int channelIndex, AudioClip clip)
	{
		if (channelIndex < 0 || channelIndex >= audioChannels.Count)
		{
			Debug.LogError("Channel index out of range");
		}
		else
		{
			SetClipOnChannel(audioChannels[channelIndex], clip);
		}
	}

	public void SetClipOnChannel(AudioSource channel, AudioClip clip)
	{
		if (channel == null)
		{
			Debug.LogError("Channel is null");
		}
		else if (!audioChannels.Contains(channel))
		{
			Debug.LogError("Channel is not from this audio controller");
		}
		else
		{
			channel.clip = clip;
		}
	}

	public void SetVolumeOnChannel(int channelIndex, float volume)
	{
		if (channelIndex < 0 || channelIndex >= audioChannels.Count)
		{
			Debug.LogError("Channel index out of range");
		}
		else
		{
			SetVolumeOnChannel(audioChannels[channelIndex], volume);
		}
	}

	public void SetVolumeOnChannel(AudioSource channel, float volume)
	{
		if (channel == null)
		{
			Debug.LogError("Channel is null");
		}
		else if (!audioChannels.Contains(channel))
		{
			Debug.LogError("Channel is not from this audio controller");
		}
		else
		{
			channel.volume = volume;
		}
	}

	public void SetRandomPitchOnChannel(int channelIndex, float min = 0.9f, float max = 1.1f)
	{
		if (channelIndex < 0 || channelIndex >= audioChannels.Count)
		{
			Debug.LogError("Channel index out of range");
		}
		else
		{
			SetRandomPitchOnChannel(audioChannels[channelIndex], min, max);
		}
	}

	public void SetRandomPitchOnChannel(AudioSource channel, float min = 0.9f, float max = 1.1f)
	{
		if (channel == null)
		{
			Debug.LogError("Channel is null");
		}
		else if (!audioChannels.Contains(channel))
		{
			Debug.LogError("Channel is not from this audio controller");
		}
		else
		{
			channel.pitch = UnityEngine.Random.Range(min, max);
		}
	}

	public void SetAudioGroupForChannel(int channelIndex, AMG audioGroup)
	{
		if (channelIndex < 0 || channelIndex >= audioChannels.Count)
		{
			Debug.LogError("Channel index out of range");
		}
		else
		{
			SetAudioGroupForChannel(audioChannels[channelIndex], audioGroup);
		}
	}

	public void SetAudioGroupForChannel(AudioSource channel, AMG audioGroup)
	{
		if (channel == null)
		{
			Debug.LogError("Channel index out of range");
			return;
		}
		switch (audioGroup)
		{
		case AMG.Master:
			channel.outputAudioMixerGroup = AudioManager.Instance.MasterGroup;
			break;
		case AMG.Music:
			channel.outputAudioMixerGroup = AudioManager.Instance.MusicGroup;
			break;
		case AMG.SFX:
			channel.outputAudioMixerGroup = AudioManager.Instance.SfxGroup;
			break;
		default:
			Debug.LogError("Invalid audio group specified for channel");
			break;
		}
	}

	public AudioSource GetChannel(int channelIndex)
	{
		if (channelIndex < 0 || channelIndex >= audioChannels.Count)
		{
			Debug.LogError("Channel index out of range");
			return null;
		}
		return audioChannels[channelIndex];
	}

	public int GetNumberOfChannels()
	{
		return audioClips.Count;
	}

	public void PlayMain()
	{
		PlayOnMain();
	}

	public void PlayChannel0()
	{
		PlayOnChannel(0);
	}

	public void MuteChannels(AudioSource exception = null)
	{
		if (exception != mainAS)
		{
			mainAS.Stop();
		}
		foreach (AudioSource audioChannel in audioChannels)
		{
			if (audioChannel != exception)
			{
				audioChannel.Stop();
			}
		}
	}
}
