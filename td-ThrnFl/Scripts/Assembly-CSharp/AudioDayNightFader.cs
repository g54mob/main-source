using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioDayNightFader : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public float fadeTime = 0.5f;

	public AudioMixer mixer;

	public AudioClip nightMusic;

	public AudioClip finalNightMusic;

	public float nightMusicFadeInTime = 3f;

	public float nightMusicFadeOutTime = 4f;

	[Header("Classic Mode Settings")]
	public float transitionDelayInLastNight;

	public bool quickMusicFadeInLastNight;

	private float transitionClock;

	private float dayTargetVol;

	private float nightTargetVol;

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		mixer.GetFloat("DayEnvVolume", out dayTargetVol);
		mixer.GetFloat("NightEnvVolume", out nightTargetVol);
		dayTargetVol = Mathf.Pow(10f, dayTargetVol / 20f);
		nightTargetVol = Mathf.Pow(10f, nightTargetVol / 20f);
		mixer.SetFloat("NightEnvVolume", Mathf.Log10(0.0001f) * 20f);
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		StopAllCoroutines();
		StartCoroutine(FadeToDay());
	}

	public void OnDusk()
	{
		StopAllCoroutines();
		StartCoroutine(FadeToNight());
	}

	private IEnumerator FadeToNight()
	{
		if (EnemySpawner.instance.Wavenumber >= EnemySpawner.instance.waves.Count - 1)
		{
			if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.Classic)
			{
				yield return new WaitForSeconds(transitionDelayInLastNight);
			}
			if (quickMusicFadeInLastNight && LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.Classic)
			{
				MusicManager.instance.PlayMusic(finalNightMusic, 0.25f);
			}
			else
			{
				MusicManager.instance.PlayMusic(finalNightMusic, nightMusicFadeInTime);
			}
		}
		else
		{
			MusicManager.instance.PlayMusic(nightMusic, nightMusicFadeInTime);
		}
		while (transitionClock < 1f)
		{
			transitionClock += Time.deltaTime / fadeTime;
			mixer.SetFloat("DayEnvVolume", Mathf.Log10(Mathf.Lerp(dayTargetVol, 0.0001f, transitionClock)) * 20f);
			mixer.SetFloat("NightEnvVolume", Mathf.Log10(Mathf.Lerp(0.0001f, nightTargetVol, transitionClock)) * 20f);
			yield return null;
		}
		transitionClock = 1f;
		mixer.SetFloat("DayEnvVolume", Mathf.Log10(0.0001f) * 20f);
		mixer.SetFloat("NightEnvVolume", Mathf.Log10(nightTargetVol) * 20f);
	}

	private IEnumerator FadeToDay()
	{
		MusicManager.instance.PlayMusic(null, nightMusicFadeOutTime);
		while (transitionClock > 0f)
		{
			transitionClock -= Time.deltaTime / fadeTime;
			mixer.SetFloat("DayEnvVolume", Mathf.Log10(Mathf.Lerp(dayTargetVol, 0.0001f, transitionClock)) * 20f);
			mixer.SetFloat("NightEnvVolume", Mathf.Log10(Mathf.Lerp(0.0001f, nightTargetVol, transitionClock)) * 20f);
			yield return null;
		}
		transitionClock = 0f;
		mixer.SetFloat("DayEnvVolume", Mathf.Log10(dayTargetVol) * 20f);
		mixer.SetFloat("NightEnvVolume", Mathf.Log10(0.0001f) * 20f);
	}

	public void OnDuskEarly()
	{
	}
}
