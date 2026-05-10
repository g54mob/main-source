using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AmbienceManager), typeof(MusicManager))]
public class LTAudioSystem : AudioSystem
{
	private AmbienceManager ambienceManager;

	private MusicManager musicManager;

	private Coroutine pauseMusicCoroutine;

	protected override void Awake()
	{
		base.Awake();
		ambienceManager = GetComponent<AmbienceManager>();
		musicManager = GetComponent<MusicManager>();
	}

	protected override void Start()
	{
		base.Start();
		LTFunctionLibrary.GetTimeManager().onGameSpeedChanged += OnGameSpeedChanged;
		LTFunctionLibrary.GetLTGameManager().onPause += OnPause;
		LTFunctionLibrary.GetLTGameManager().onResume += OnResume;
		SceneManager.activeSceneChanged += OnSceneChanged;
	}

	public override void PauseMusic(bool pause, float fadeTime)
	{
		base.PauseMusic(pause, fadeTime);
		if (pause)
		{
			this.StartCoroutineCheckingVar(PauseMusicCoroutine(fadeTime), ref pauseMusicCoroutine, stopCoroutineIfRunning: true);
			return;
		}
		musicManager.PauseMusic(pause: false);
		this.StopCoroutineCheckingVar(ref pauseMusicCoroutine);
	}

	private IEnumerator PauseMusicCoroutine(float delay)
	{
		yield return new WaitForSecondsRealtime(delay + 0.05f);
		musicManager.PauseMusic(pause: true);
	}

	private void OnGameSpeedChanged(TimeManager.ETimeSpeed timeSpeed, float speed)
	{
		SetMixerPitch(speed, EAudioMixerGroup.SFX);
	}

	private void OnResume()
	{
		SetMixerPitch(1f, EAudioMixerGroup.SFX);
	}

	private void OnPause()
	{
		SetMixerPitch(0f, EAudioMixerGroup.SFX);
	}

	private void OnSceneChanged(Scene currentScene, Scene nextScene)
	{
		SetMixerPitch(1f, EAudioMixerGroup.SFX);
	}
}
