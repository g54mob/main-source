using System.Collections;
using System.Collections.Generic;
using SkyBrave_Toolkit.Scripts.Components;
using SkyBrave_Toolkit.Scripts.Scriptable_Game_Settings;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(TimerComponent))]
public class MusicPlayer : MonoBehaviour
{
	public List<AudioClip> musicTracks;

	private AudioSource audioSource;

	private TimerComponent _timerComponent;

	private int currentTrackIndex;

	public float fadeDuration = 2f;

	public GameSettings GameSettings;

	public static MusicPlayer Instance;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		_timerComponent = GetComponent<TimerComponent>();
		currentTrackIndex = 0;
		PlayRandomTrack();
	}

	private void Update()
	{
		UpdateMusicPlayerSettings();
	}

	private void PlayRandomTrack()
	{
		if (musicTracks.Count <= 0)
		{
			Debug.LogError("No music tracks available.");
			return;
		}
		if (musicTracks.Count == 1)
		{
			StartCoroutine(PlayWithFade(musicTracks[currentTrackIndex]));
			return;
		}
		int num;
		for (num = Random.Range(0, musicTracks.Count); num == currentTrackIndex; num = Random.Range(0, musicTracks.Count))
		{
		}
		currentTrackIndex = num;
		StartCoroutine(PlayWithFade(musicTracks[currentTrackIndex]));
	}

	private IEnumerator PlayWithFade(AudioClip newClip)
	{
		float timer = 0f;
		float startVolume = GameSettings.GetMusicVolume();
		while (timer < fadeDuration)
		{
			audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
			timer += Time.deltaTime;
			yield return null;
		}
		audioSource.clip = newClip;
		audioSource.Play();
		_timerComponent.StartTimer(newClip.length);
		timer = 0f;
		while (timer < fadeDuration)
		{
			audioSource.volume = Mathf.Lerp(0f, startVolume, timer / fadeDuration);
			timer += Time.deltaTime;
			yield return null;
		}
	}

	public void PlayNextTrack()
	{
		PlayRandomTrack();
	}

	public void ReplayCurrentTrack()
	{
		StartCoroutine(PlayWithFade(musicTracks[currentTrackIndex]));
	}

	private void UpdateMusicPlayerSettings()
	{
		audioSource.mute = !GameSettings.IsMusicEnabled;
		audioSource.volume = GameSettings.GetMusicVolume();
	}
}
