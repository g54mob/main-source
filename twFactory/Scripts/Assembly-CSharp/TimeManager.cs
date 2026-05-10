using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour, ISavable
{
	public enum ETimeSpeed
	{
		None = 0,
		Pause = 1,
		Play = 2,
		Fast = 3,
		VeryFast = 4
	}

	[SerializeField]
	private AudioData pauseSound;

	[SerializeField]
	private AudioData playSound;

	[SerializeField]
	private AudioData fastSound;

	[SerializeField]
	private AudioData veryFastSound;

	private ColorAdjustments pppColorAdjustments;

	private float baseSaturation;

	[Savable("currentTime", true, false)]
	private float currentTime;

	private bool hasLoadedData;

	public event Action<ETimeSpeed, float> onGameSpeedChanged;

	private void Start()
	{
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
		LTGameManager lTGameManager2 = LTFunctionLibrary.GetLTGameManager();
		lTGameManager2.onGameOver = (Action)Delegate.Combine(lTGameManager2.onGameOver, new Action(OnGameOver));
		LTFunctionLibrary.GetLTGameManager().onResume += OnGameResumed;
		LTFunctionLibrary.GetLTLevelController().PostProcessingProfile.profile.TryGet<ColorAdjustments>(out pppColorAdjustments);
		baseSaturation = pppColorAdjustments.saturation.value;
	}

	private void OnDestroy()
	{
		SetPlayVisuals();
	}

	private void Update()
	{
		currentTime += Time.deltaTime;
	}

	public ETimeSpeed GetGameSpeed()
	{
		if (Time.timeScale == 0f)
		{
			return ETimeSpeed.Pause;
		}
		if (Time.timeScale == 1f)
		{
			return ETimeSpeed.Play;
		}
		if (Time.timeScale == 1.75f)
		{
			return ETimeSpeed.Fast;
		}
		if (Time.timeScale == 2.5f)
		{
			return ETimeSpeed.VeryFast;
		}
		return ETimeSpeed.None;
	}

	public void SetGameSpeed(ETimeSpeed timeSpeed, bool playSound = true)
	{
		if (GetGameSpeed() == timeSpeed)
		{
			return;
		}
		switch (timeSpeed)
		{
		case ETimeSpeed.Pause:
			Time.timeScale = 0f;
			SetPauseVisuals();
			if (playSound)
			{
				AudioSystem.Instance.PlaySound2D(pauseSound, AudioSystem.EAudioMixerGroup.UI, 0f, 0f, loop: false, AudioSystem.EAudioPriority.High);
			}
			break;
		case ETimeSpeed.Play:
			Time.timeScale = 1f;
			SetPlayVisuals();
			if (playSound)
			{
				AudioSystem.Instance.PlaySound2D(this.playSound, AudioSystem.EAudioMixerGroup.UI, 0f, 0f, loop: false, AudioSystem.EAudioPriority.High);
			}
			break;
		case ETimeSpeed.Fast:
			Time.timeScale = 1.75f;
			SetPlayVisuals();
			if (playSound)
			{
				AudioSystem.Instance.PlaySound2D(fastSound, AudioSystem.EAudioMixerGroup.UI, 0f, 0f, loop: false, AudioSystem.EAudioPriority.High);
			}
			break;
		case ETimeSpeed.VeryFast:
			Time.timeScale = 2.5f;
			SetPlayVisuals();
			if (playSound)
			{
				AudioSystem.Instance.PlaySound2D(veryFastSound, AudioSystem.EAudioMixerGroup.UI, 0f, 0f, loop: false, AudioSystem.EAudioPriority.High);
			}
			break;
		}
		this.onGameSpeedChanged?.Invoke(timeSpeed, Time.timeScale);
	}

	private void SetPauseVisuals()
	{
		pppColorAdjustments.saturation.value = -30f;
		AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.Music).mixer.audioMixer.SetFloat("MusicLowPassFreq", 700f);
		AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.Music).mixer.audioMixer.SetFloat("MusicHighPassFreq", 60f);
	}

	private void SetPlayVisuals()
	{
		pppColorAdjustments.saturation.value = baseSaturation;
		AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.Music).mixer.audioMixer.SetFloat("MusicLowPassFreq", 22000f);
		AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.Music).mixer.audioMixer.SetFloat("MusicHighPassFreq", 10f);
	}

	public void ToggleGamePause()
	{
		if (GetGameSpeed() == ETimeSpeed.Pause)
		{
			SetGameSpeed(ETimeSpeed.Play);
		}
		else
		{
			SetGameSpeed(ETimeSpeed.Pause);
		}
	}

	public void DecreaseSpeed(bool canPause = false)
	{
		int gameSpeed = (int)GetGameSpeed();
		gameSpeed = Mathf.Max(gameSpeed - 1, canPause ? 1 : 2);
		SetGameSpeed((ETimeSpeed)gameSpeed);
	}

	public void IncreaseSpeed()
	{
		int gameSpeed = (int)GetGameSpeed();
		gameSpeed = Mathf.Min(gameSpeed + 1, Enum.GetValues(typeof(ETimeSpeed)).Length - 1);
		SetGameSpeed((ETimeSpeed)gameSpeed);
	}

	public long GetTimeMilliseconds()
	{
		return (long)(currentTime * 1000f);
	}

	public double GetTimeSeconds()
	{
		return currentTime;
	}

	private void OnGameStarted()
	{
		if (!hasLoadedData)
		{
			currentTime = 0f;
		}
	}

	private void OnGameOver()
	{
		SetPlayVisuals();
	}

	private void OnGameResumed()
	{
		SetGameSpeed(ETimeSpeed.Play, playSound: false);
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		hasLoadedData = hasLoadedSomething;
	}
}
