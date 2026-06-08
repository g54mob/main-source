using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	[SerializeField]
	protected AudioSource audioSource;

	[SerializeField]
	protected Slider volumeSlider;

	[SerializeField]
	protected Slider progressSlider;

	[SerializeField]
	protected PausePlayIconController iconSwitcher;

	public readonly float AUDIO_WAIT_TIME = 0.01f;

	protected virtual void Start()
	{
		volumeSlider.onValueChanged.AddListener(SetVolume);
		progressSlider.onValueChanged.AddListener(SetProgress);
	}

	public virtual void SetVolume(float sliderValue)
	{
		audioSource.volume = sliderValue;
	}

	public void SetProgress(float sliderValue)
	{
		if (sliderValue >= audioSource.clip.length || sliderValue < 0f)
		{
			if (!audioSource.isPlaying)
			{
				ResetAudio();
			}
		}
		else
		{
			audioSource.time = sliderValue;
		}
	}

	protected void SetMaxProgress()
	{
		progressSlider.maxValue = audioSource.clip.length;
	}

	protected void ResetAudio()
	{
		audioSource.Stop();
		audioSource.time = 0f;
		progressSlider.value = 0f;
		if (iconSwitcher != null)
		{
			iconSwitcher.PlaySprite();
		}
	}

	public virtual void PlayAudio()
	{
		throw new Exception("PlayAudio function cannot be called without overriding");
	}
}
