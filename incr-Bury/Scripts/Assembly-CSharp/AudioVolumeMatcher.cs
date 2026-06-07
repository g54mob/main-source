using System;
using System.Collections;
using UnityEngine;

public class AudioVolumeMatcher : MonoBehaviour
{
	private AudioSource audioSource;

	[SerializeField]
	private AudioChannelType audioChannelType;

	[SerializeField]
	private bool startVolumeAtZero;

	[SerializeField]
	private float additionalVolumeMult = 1f;

	[SerializeField]
	private bool ignoreDuckedVolume;

	[SerializeField]
	private bool checkVolumeAFrameLater;

	[SerializeField]
	private bool alwaysCheckEveryFrame;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		if (startVolumeAtZero)
		{
			audioSource.volume = 0f;
		}
	}

	private void Start()
	{
		AudioManager singleton = AudioManager.Singleton;
		singleton.AudioLevelsChanged_Action = (Action)Delegate.Combine(singleton.AudioLevelsChanged_Action, new Action(OnVolumesChanged));
		OnVolumesChanged();
		if (checkVolumeAFrameLater)
		{
			audioSource.volume = 0f;
			audioSource.Stop();
			StartCoroutine(WaitASec_ThenHandleDelayedVolumeSetting());
		}
		else if (audioSource.playOnAwake)
		{
			audioSource.Stop();
			audioSource.Play();
		}
	}

	private void Update()
	{
		if (alwaysCheckEveryFrame)
		{
			OnVolumesChanged();
		}
	}

	private void OnDestroy()
	{
		AudioManager singleton = AudioManager.Singleton;
		singleton.AudioLevelsChanged_Action = (Action)Delegate.Remove(singleton.AudioLevelsChanged_Action, new Action(OnVolumesChanged));
	}

	private void OnVolumesChanged()
	{
		switch (audioChannelType)
		{
		case AudioChannelType.SFX:
			audioSource.volume = (ignoreDuckedVolume ? (AudioManager.Singleton.sfx_Volume_Base * additionalVolumeMult) : (AudioManager.Singleton.sfxVolume * additionalVolumeMult));
			break;
		case AudioChannelType.Music:
			audioSource.volume = (ignoreDuckedVolume ? (AudioManager.Singleton.music_Volume_Base * additionalVolumeMult) : (AudioManager.Singleton.musicVolume * additionalVolumeMult));
			if (audioSource.isPlaying)
			{
				audioSource.Pause();
				audioSource.Play();
			}
			break;
		case AudioChannelType.Ambient:
			audioSource.volume = (ignoreDuckedVolume ? (AudioManager.Singleton.ambient_Volume_Base * additionalVolumeMult) : (AudioManager.Singleton.ambientVolume * additionalVolumeMult));
			break;
		}
	}

	private IEnumerator WaitASec_ThenHandleDelayedVolumeSetting()
	{
		yield return null;
		yield return null;
		yield return null;
		OnVolumesChanged();
		if (audioSource.playOnAwake)
		{
			audioSource.Play();
		}
	}
}
