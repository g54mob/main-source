using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	[SerializeField]
	private AudioData roundMusic;

	[SerializeField]
	private AudioData waveMusic;

	[Header("Debug")]
	[SerializeField]
	private bool disableMusic;

	private Coroutine currentFadeMusicCoroutine;

	private bool isEndingGame;

	private AudioSource roundMusicSource;

	private AudioSource waveMusicSource;

	public AudioData RoundMusic
	{
		get
		{
			return roundMusic;
		}
		set
		{
			roundMusic = value;
		}
	}

	public AudioData WaveMusic
	{
		get
		{
			return waveMusic;
		}
		set
		{
			waveMusic = value;
		}
	}

	private void Awake()
	{
		roundMusicSource = new GameObject("RoundMusic_AudioSource", typeof(AudioSource)).GetComponent<AudioSource>();
		waveMusicSource = new GameObject("WaveMusic_AudioSource", typeof(AudioSource)).GetComponent<AudioSource>();
		roundMusicSource.transform.SetParent(base.transform);
		waveMusicSource.transform.SetParent(base.transform);
	}

	private void Start()
	{
		if ((bool)LTFunctionLibrary.GetLTGameManager())
		{
			if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
			{
				StartMusic();
			}
			else
			{
				LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
				lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
			}
			LTGameManager lTGameManager2 = LTFunctionLibrary.GetLTGameManager();
			lTGameManager2.onVictoryAnimationStarted = (Action)Delegate.Combine(lTGameManager2.onVictoryAnimationStarted, new Action(OnVictoryAnimationStarted));
			LTGameManager lTGameManager3 = LTFunctionLibrary.GetLTGameManager();
			lTGameManager3.onGameOverAnimationStarted = (Action)Delegate.Combine(lTGameManager3.onGameOverAnimationStarted, new Action(OnGameOverAnimationStarted));
		}
	}

	private void OnGameStarted()
	{
		StartMusic();
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Remove(lTGameManager.onGameStarted, new Action(OnGameStarted));
	}

	private void StartMusic()
	{
		InitAudioSources();
		DayNightCycle dayNightCycle = LTFunctionLibrary.GetLTLevelController().DayNightCycle;
		if ((bool)dayNightCycle)
		{
			dayNightCycle.onCycleStateChanged += OnDayNightCycleStateChange;
			InitMusic(dayNightCycle.CurrentCycleState, dayNightCycle.GetCurrentTransitionRemainingDuration());
		}
		else
		{
			roundMusicSource.volume = RoundMusic.Volume * 0.5f;
			currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(roundMusicSource, RoundMusic.Volume, 5f, unscaledDeltaTime: true, 2f);
		}
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		OnCycleChanged(LTFunctionLibrary.GetCyclesManager().CurrentCycle, LTFunctionLibrary.GetCyclesManager().CurrentCycleMode);
	}

	private void InitAudioSources()
	{
		roundMusicSource.transform.SetParent(base.transform, worldPositionStays: false);
		roundMusicSource.clip = RoundMusic.GetRandomAudioClip;
		roundMusicSource.loop = true;
		roundMusicSource.volume = 0f;
		roundMusicSource.priority = 10;
		roundMusicSource.playOnAwake = false;
		roundMusicSource.outputAudioMixerGroup = AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.Music).mixer;
		waveMusicSource.transform.SetParent(base.transform, worldPositionStays: false);
		waveMusicSource.clip = WaveMusic.GetRandomAudioClip;
		waveMusicSource.loop = true;
		waveMusicSource.volume = 0f;
		waveMusicSource.priority = 10;
		waveMusicSource.playOnAwake = false;
		waveMusicSource.outputAudioMixerGroup = AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.Music).mixer;
	}

	public void PauseMusic(bool pause)
	{
		if (pause)
		{
			roundMusicSource.Pause();
			waveMusicSource.Pause();
		}
		else
		{
			roundMusicSource.UnPause();
			waveMusicSource.UnPause();
		}
	}

	private void InitMusic(DayNightCycle.EDayNightCycleState state, float transitionDuration)
	{
		switch (state)
		{
		case DayNightCycle.EDayNightCycleState.FirstDay:
			roundMusicSource.volume = RoundMusic.Volume * 0.5f;
			currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(roundMusicSource, RoundMusic.Volume, 5f, unscaledDeltaTime: true, 2f);
			break;
		case DayNightCycle.EDayNightCycleState.Day:
			roundMusicSource.volume = RoundMusic.Volume * 0.5f;
			currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(roundMusicSource, RoundMusic.Volume, 5f, unscaledDeltaTime: true, 2f);
			break;
		case DayNightCycle.EDayNightCycleState.DayToSunset:
			if (!(transitionDuration < 5f))
			{
				roundMusicSource.volume = RoundMusic.Volume * 0.5f;
				float num = Math.Min(2f, transitionDuration * 0.5f);
				AudioSystem.Instance.FadeAudioSource(roundMusicSource, RoundMusic.Volume, num, unscaledDeltaTime: true);
				currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(roundMusicSource, 0f, transitionDuration - num, unscaledDeltaTime: false, num);
			}
			break;
		case DayNightCycle.EDayNightCycleState.SunriseToDay:
			roundMusicSource.volume = RoundMusic.Volume * 0.5f;
			currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(roundMusicSource, RoundMusic.Volume, 5f, unscaledDeltaTime: true, 2f);
			break;
		case DayNightCycle.EDayNightCycleState.SunsetToNight:
		case DayNightCycle.EDayNightCycleState.Night:
		case DayNightCycle.EDayNightCycleState.NightToSunrise:
			break;
		}
	}

	private void OnCycleChanged(int cycle, ECycleMode mode)
	{
		if (mode == ECycleMode.Wave)
		{
			roundMusicSource.Stop();
			waveMusicSource.volume = WaveMusic.Volume;
			currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(waveMusicSource, WaveMusic.Volume, 5f, unscaledDeltaTime: true, 3f);
		}
	}

	private void OnDayNightCycleStateChange(DayNightCycle.EDayNightCycleState state, float transitionDuration)
	{
		if (!isEndingGame)
		{
			switch (state)
			{
			case DayNightCycle.EDayNightCycleState.DayToSunset:
				currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(roundMusicSource, 0f, transitionDuration);
				break;
			case DayNightCycle.EDayNightCycleState.NightToSunrise:
				currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(waveMusicSource, 0f, 5f, unscaledDeltaTime: true);
				break;
			case DayNightCycle.EDayNightCycleState.SunriseToDay:
				roundMusicSource.volume = RoundMusic.Volume * 0.5f;
				currentFadeMusicCoroutine = AudioSystem.Instance.FadeAudioSource(roundMusicSource, RoundMusic.Volume, 2f, unscaledDeltaTime: true, 5f);
				break;
			case DayNightCycle.EDayNightCycleState.SunsetToNight:
			case DayNightCycle.EDayNightCycleState.Night:
				break;
			}
		}
	}

	private void OnGameOverAnimationStarted()
	{
		isEndingGame = true;
		if (currentFadeMusicCoroutine != null)
		{
			StopCoroutine(currentFadeMusicCoroutine);
		}
		AudioSystem.Instance.FadeAudioSource(roundMusicSource, 0f, 1f);
		AudioSystem.Instance.FadeAudioSource(waveMusicSource, 0f, 1f);
	}

	private void OnVictoryAnimationStarted()
	{
		isEndingGame = true;
		if (currentFadeMusicCoroutine != null)
		{
			AudioSystem.Instance.StopCoroutine(currentFadeMusicCoroutine);
		}
		AudioSystem.Instance.FadeAudioSource(roundMusicSource, 0f, 1f);
		AudioSystem.Instance.FadeAudioSource(waveMusicSource, 0f, 1f);
	}
}
