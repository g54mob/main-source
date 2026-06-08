using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicManager : AudioManager
{
	private readonly float DEFAULT_VOLUME = 0.25f;

	private static List<AudioClip> songQueue;

	private static Dictionary<AudioClip, string> songNames;

	private int songIndex;

	private bool isPaused = true;

	[SerializeField]
	private TextMeshProUGUI songNameText;

	[SerializeField]
	private TextScroll scrollController;

	[SerializeField]
	private CoroutineRunner runner;

	private void Awake()
	{
		if (!audioSource.isPlaying)
		{
			SetSong();
		}
		SetVolume();
	}

	public void SetVolume()
	{
		float? volume = PlayerPrefsManager.GetVolume(PlayerPrefsManager.MUSIC_VOLUME);
		Debug.Log($"Setting savedVolume -> {volume}");
		Debug.Log($"Setting savedVolume.HasValue -> {volume.HasValue}");
		SetVolume(volume.HasValue ? volume.Value : DEFAULT_VOLUME);
	}

	public static void SetSongs((List<AudioClip>, Dictionary<AudioClip, string>) songs)
	{
		(songQueue, songNames) = songs;
	}

	public override void SetVolume(float sliderValue)
	{
		PlayerPrefs.SetFloat(PlayerPrefsManager.MUSIC_VOLUME, sliderValue);
		audioSource.volume = sliderValue * sliderValue;
		volumeSlider.value = sliderValue;
	}

	public void PlaySong()
	{
		isPaused = audioSource.isPlaying;
		if (audioSource.isPlaying)
		{
			iconSwitcher.PlaySprite();
			scrollController.SetScrollSpeed(0f);
			audioSource.Pause();
		}
		else
		{
			PlayAudio();
		}
	}

	public new void PlayAudio()
	{
		isPaused = false;
		iconSwitcher.PauseSprite();
		scrollController.SetScrollSpeed(1f);
		audioSource.Play();
		runner.StartCoroutine(StartMusic);
	}

	public IEnumerator StartMusic()
	{
		float waitDuration = 0.01f;
		while (!isPaused)
		{
			yield return new WaitForSeconds(waitDuration);
			progressSlider.value = audioSource.time;
			if (!isPaused && !audioSource.isPlaying)
			{
				NextSong();
			}
			yield return null;
		}
	}

	public void NextSong()
	{
		ShiftSong(1);
	}

	public void PreviousSong()
	{
		ShiftSong(-1);
	}

	private void ShiftSong(int delta)
	{
		progressSlider.value = 0f;
		if (songIndex + delta >= songQueue.Count)
		{
			songIndex = 0;
		}
		else if (songIndex + delta < 0)
		{
			songIndex = songQueue.Count - 1;
		}
		else
		{
			songIndex += delta;
		}
		SetSong();
		PlaySong();
		iconSwitcher.PauseSprite();
		scrollController.ResetPosition();
	}

	public void SetSong(string songName)
	{
		Debug.Log("Setting song to " + songName);
		for (int i = 0; i < songQueue.Count; i++)
		{
			if (songNames[songQueue[i]] == songName)
			{
				songIndex = i;
				SetSong(i);
				break;
			}
		}
	}

	private void SetSong()
	{
		SetSong(songIndex);
	}

	private void SetSong(int songIndex)
	{
		audioSource.clip = songQueue[songIndex];
		songNameText.text = songNames[audioSource.clip];
		SetMaxProgress();
	}
}
