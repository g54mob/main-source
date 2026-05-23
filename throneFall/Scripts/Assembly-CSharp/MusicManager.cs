using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	[Serializable]
	public class OverrideVolume
	{
		public AudioClip audioClip;

		[Range(0f, 1f)]
		public float volume;

		public OverrideVolume(AudioClip clip, float volume)
		{
			audioClip = clip;
			this.volume = volume;
		}
	}

	public static MusicManager instance;

	[SerializeField]
	private AudioSource audioSource;

	private AudioClip currentMusic;

	private Coroutine fadeCoroutine;

	private float currentVolume;

	[SerializeField]
	private AudioClip[] resumeableMusicClips;

	private Dictionary<AudioClip, float> resumeableMusicPlaybackPositions = new Dictionary<AudioClip, float>();

	[SerializeField]
	private List<OverrideVolume> overrideVolumes = new List<OverrideVolume>();

	private float CurrentVolume
	{
		get
		{
			return currentVolume;
		}
		set
		{
			float num = value;
			currentVolume = value;
			OverrideVolume overrideVolume = overrideVolumes.Find((OverrideVolume o) => o.audioClip == currentMusic);
			if (overrideVolume != null)
			{
				num *= overrideVolume.volume;
			}
			audioSource.volume = Mathf.Pow(num, 2f);
		}
	}

	private void Awake()
	{
		if (instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		CurrentVolume = 0f;
		AudioClip[] array = resumeableMusicClips;
		foreach (AudioClip key in array)
		{
			resumeableMusicPlaybackPositions.Add(key, 0f);
		}
	}

	public void PlayMusic(AudioClip music, float fadeDuration = 4f)
	{
		if (currentMusic == music)
		{
			return;
		}
		if (music == null && currentMusic != null)
		{
			StartCoroutine(FadeOutAndStop(fadeDuration));
			return;
		}
		if (fadeCoroutine != null)
		{
			StopCoroutine(fadeCoroutine);
		}
		fadeCoroutine = StartCoroutine(FadeOutChangeMusicFadeIn(music, fadeDuration));
	}

	private IEnumerator FadeOutChangeMusicFadeIn(AudioClip newMusic, float fadeDuration)
	{
		if (currentMusic != null)
		{
			if (resumeableMusicPlaybackPositions.ContainsKey(currentMusic))
			{
				resumeableMusicPlaybackPositions[currentMusic] = audioSource.time;
			}
			yield return StartCoroutine(FadeOut(fadeDuration));
		}
		CurrentVolume = 0f;
		audioSource.clip = newMusic;
		currentMusic = newMusic;
		if (resumeableMusicPlaybackPositions.ContainsKey(newMusic))
		{
			audioSource.time = resumeableMusicPlaybackPositions[newMusic];
		}
		else
		{
			audioSource.time = 0f;
		}
		audioSource.Play();
		yield return null;
		yield return StartCoroutine(FadeIn(fadeDuration));
	}

	private IEnumerator FadeOutAndStop(float fadeDuration)
	{
		yield return StartCoroutine(FadeOut(fadeDuration));
		if (currentMusic != null && resumeableMusicPlaybackPositions.ContainsKey(currentMusic))
		{
			resumeableMusicPlaybackPositions[currentMusic] = audioSource.time;
		}
		audioSource.Stop();
		currentMusic = null;
	}

	private IEnumerator FadeOut(float fadeDuration)
	{
		if (fadeDuration <= 0f)
		{
			CurrentVolume = 0f;
			yield break;
		}
		float fadeSpeed = 1f / fadeDuration;
		while (CurrentVolume > 0f)
		{
			CurrentVolume -= fadeSpeed * Time.unscaledDeltaTime;
			yield return null;
		}
		CurrentVolume = 0f;
	}

	private IEnumerator FadeIn(float fadeDuration)
	{
		if (fadeDuration <= 0f)
		{
			CurrentVolume = 1f;
			yield break;
		}
		float fadeSpeed = 1f / fadeDuration;
		while (CurrentVolume < 1f)
		{
			CurrentVolume += fadeSpeed * Time.unscaledDeltaTime;
			yield return null;
		}
		CurrentVolume = 1f;
	}
}
