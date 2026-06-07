using System;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
	[SerializeField]
	private AudioData ambienceDayClip;

	[SerializeField]
	private AudioData ambienceNightClip;

	[SerializeField]
	private AudioData nightfallClip;

	[SerializeField]
	private AudioData sunriseClip;

	[Header("Debug")]
	[SerializeField]
	private bool disableAmbience;

	private AudioSource ambienceSource;

	private Coroutine currentFadeAmbienceCoroutine;

	public AudioData AmbienceDayClip
	{
		get
		{
			return ambienceDayClip;
		}
		set
		{
			ambienceDayClip = value;
		}
	}

	public AudioData AmbienceNightClip
	{
		get
		{
			return ambienceNightClip;
		}
		set
		{
			ambienceNightClip = value;
		}
	}

	private void Start()
	{
		if ((bool)LTFunctionLibrary.GetLTGameManager())
		{
			if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
			{
				StartAmbience();
				return;
			}
			LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
			lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
		}
	}

	private void OnGameStarted()
	{
		StartAmbience();
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Remove(lTGameManager.onGameStarted, new Action(OnGameStarted));
	}

	private void StartAmbience()
	{
		DayNightCycle dayNightCycle = LTFunctionLibrary.GetLTLevelController().DayNightCycle;
		if ((bool)dayNightCycle)
		{
			dayNightCycle.onCycleStateChanged += OnDayNightCycleStateChange;
			float fadeTime = Mathf.Min(2f, dayNightCycle.GetCurrentTransitionRemainingDuration());
			DayNightCycle.EDayNightCycleState currentCycleState = dayNightCycle.CurrentCycleState;
			if (currentCycleState == DayNightCycle.EDayNightCycleState.FirstDay || currentCycleState == DayNightCycle.EDayNightCycleState.Day || currentCycleState == DayNightCycle.EDayNightCycleState.DayToSunset || currentCycleState == DayNightCycle.EDayNightCycleState.SunriseToDay)
			{
				PlayAmbience(ambienceDayClip, fadeTime);
			}
			else
			{
				PlayAmbience(ambienceNightClip, fadeTime);
			}
		}
		else
		{
			PlayAmbience(AmbienceDayClip, 2f);
		}
	}

	private void PlayAmbience(AudioData ambienceClip, float fadeTime)
	{
		if (ambienceClip != null)
		{
			if ((bool)ambienceSource && ambienceSource.isPlaying)
			{
				ambienceSource = AudioSystem.Instance.CrossfadeSounds(ambienceSource, ambienceClip.GetRandomAudioClip, fadeTime, 0f, ambienceClip.Volume, unscaledDeltaTime: true);
				return;
			}
			ambienceSource = AudioSystem.Instance.PlaySound2D(ambienceClip, AudioSystem.EAudioMixerGroup.Ambience, 0f, 0f, loop: true, AudioSystem.EAudioPriority.VeryHigh);
			ambienceSource.volume = 0f;
			AudioSystem.Instance.FadeAudioSource(ambienceSource, ambienceClip.Volume, fadeTime, unscaledDeltaTime: true);
		}
	}

	private void OnDayNightCycleStateChange(DayNightCycle.EDayNightCycleState state, float transitionDuration)
	{
		switch (state)
		{
		case DayNightCycle.EDayNightCycleState.SunsetToNight:
			PlayAmbience(ambienceNightClip, 5f);
			AudioSystem.Instance.PlaySound2D(nightfallClip, AudioSystem.EAudioMixerGroup.Ambience);
			break;
		case DayNightCycle.EDayNightCycleState.SunriseToDay:
			PlayAmbience(ambienceDayClip, 5f);
			AudioSystem.Instance.PlaySound2D(sunriseClip, AudioSystem.EAudioMixerGroup.Ambience);
			break;
		}
	}
}
