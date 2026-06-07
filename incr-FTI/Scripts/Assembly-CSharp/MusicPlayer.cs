using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	private static MusicPlayer instance;

	public AudioSource audioSource;

	public Song mainSong;

	public List<Song> backgroundMusicSongs;

	public Song currentPlayingSong;

	public float nextSongCountdown;

	public MusicPlayerState state;

	public float fadeProgress;

	private const float InitialPlayDelay = 2f;

	private const float TimeBetweenSongs = 120f;

	public static MusicPlayer Instance => instance;

	private void Awake()
	{
		instance = this;
		SetActive(active: false);
	}

	private void Update()
	{
		if (state == MusicPlayerState.FadingOut)
		{
			fadeProgress += TimeManager.MenuDelta * 0.3f;
			UpdateVolumeForCurrentSong();
			if (fadeProgress >= 1f)
			{
				fadeProgress = 0f;
				if (GameManager.GameState == GameState.Welcome)
				{
					PlayNext();
					return;
				}
				state = MusicPlayerState.CountingDown;
				nextSongCountdown = 2f;
				return;
			}
		}
		if (state == MusicPlayerState.Playing)
		{
			if (state == MusicPlayerState.Playing && !audioSource.isPlaying)
			{
				if (GameManager.GameState == GameState.Welcome && currentPlayingSong == mainSong)
				{
					state = MusicPlayerState.Paused;
					return;
				}
				state = MusicPlayerState.CountingDown;
				nextSongCountdown = 120f;
			}
		}
		else
		{
			if (state != MusicPlayerState.CountingDown)
			{
				return;
			}
			nextSongCountdown -= Time.deltaTime;
			if (!(nextSongCountdown <= 0f))
			{
				return;
			}
			if (GameManager.GameState == GameState.Welcome)
			{
				if (currentPlayingSong == mainSong)
				{
					state = MusicPlayerState.Paused;
				}
				else
				{
					PlayNext();
				}
			}
			else
			{
				PlayNext();
			}
		}
	}

	public void FadeOutPlayingSong()
	{
		if (state == MusicPlayerState.Playing)
		{
			fadeProgress = 0f;
		}
		else if (state == MusicPlayerState.Paused || state == MusicPlayerState.CountingDown)
		{
			fadeProgress = 1f;
		}
		nextSongCountdown = 0f;
		state = MusicPlayerState.FadingOut;
	}

	public void OnVolumePreferencesChanged()
	{
		UpdateVolumeForCurrentSong();
		if (Preferences.masterVolume <= 0f || Preferences.musicVolume <= 0f)
		{
			if (state != MusicPlayerState.None)
			{
				Pause();
			}
		}
		else if (state == MusicPlayerState.Paused || state == MusicPlayerState.None)
		{
			Resume();
		}
	}

	private void UpdateVolumeForCurrentSong()
	{
		if (null != currentPlayingSong)
		{
			float num = currentPlayingSong.volumeAdjustment;
			if (num <= 0f)
			{
				num = 1f;
			}
			if (fadeProgress > 0f)
			{
				float num2 = Mathf.Clamp01(fadeProgress);
				num *= 1f - num2;
			}
			audioSource.volume = Preferences.masterVolume * Preferences.musicVolume * num;
		}
	}

	public void BeginForGameLaunch()
	{
		if (!(null == mainSong))
		{
			state = MusicPlayerState.Initialized;
			SetActive(active: true);
			if (backgroundMusicSongs.Count > 1 && PlayerPrefs.HasKey("Has Launched"))
			{
				GameUtility.Shuffle(backgroundMusicSongs);
			}
			PlayerPrefs.SetInt("Has Launched", 1);
			backgroundMusicSongs.Insert(0, mainSong);
			BeginPlaying(backgroundMusicSongs[0]);
			if (Preferences.masterVolume <= 0f || Preferences.musicVolume <= 0f)
			{
				Pause();
			}
		}
	}

	private void BeginPlaying(Song song)
	{
		audioSource.clip = song.clip;
		audioSource.time = 0f;
		audioSource.Play();
		currentPlayingSong = song;
		state = MusicPlayerState.Playing;
		UpdateVolumeForCurrentSong();
		fadeProgress = 0f;
	}

	[ContextMenu("Pause")]
	public void Pause()
	{
		audioSource.Pause();
		state = MusicPlayerState.Paused;
		SetActive(active: false);
	}

	public void SetActive(bool active)
	{
	}

	[ContextMenu("Resume")]
	public void Resume()
	{
		SetActive(active: true);
		if (state == MusicPlayerState.None || null == currentPlayingSong)
		{
			BeginForGameLaunch();
			return;
		}
		if (nextSongCountdown > 0f)
		{
			state = MusicPlayerState.CountingDown;
			return;
		}
		audioSource.UnPause();
		state = MusicPlayerState.Playing;
	}

	[ContextMenu("Jump")]
	private void Jump()
	{
		if (audioSource.isPlaying)
		{
			audioSource.time = audioSource.clip.length - 3f;
		}
	}

	[ContextMenu("End")]
	private void DebugEnd()
	{
		audioSource.Stop();
		state = MusicPlayerState.CountingDown;
		nextSongCountdown = 3f;
	}

	[ContextMenu("Next")]
	public void PlayNext()
	{
		int num = backgroundMusicSongs.IndexOf(mainSong);
		if (GameManager.GameState == GameState.Welcome && num >= 0)
		{
			BeginPlaying(backgroundMusicSongs[backgroundMusicSongs.IndexOf(mainSong)]);
			return;
		}
		int num2 = backgroundMusicSongs.IndexOf(currentPlayingSong);
		if (null == currentPlayingSong)
		{
			Debug.Log("Play next song. CurrentIndex " + num2 + "/" + backgroundMusicSongs.Count);
		}
		else
		{
			Debug.Log("Play next song. CurrentIndex " + num2 + "/ " + backgroundMusicSongs.Count);
		}
		if (backgroundMusicSongs.Count <= 0)
		{
			Debug.Log("Pausing music player, background music songs list is empty");
			Pause();
			return;
		}
		num2++;
		if (num2 >= backgroundMusicSongs.Count)
		{
			num2 = 0;
		}
		BeginPlaying(backgroundMusicSongs[num2]);
	}

	[ContextMenu("Back")]
	public void Back()
	{
		if (audioSource.time < 5f)
		{
			PlayPrevious();
		}
		else
		{
			audioSource.time = 0f;
		}
	}

	[ContextMenu("Previous")]
	public void PlayPrevious()
	{
		int num = backgroundMusicSongs.IndexOf(currentPlayingSong);
		num--;
		if (num < 0 || num >= backgroundMusicSongs.Count)
		{
			num = backgroundMusicSongs.Count - 1;
		}
		BeginPlaying(backgroundMusicSongs[num]);
	}
}
