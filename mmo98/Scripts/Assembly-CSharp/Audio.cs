using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;
using ZLinq;

public class Audio : MonoSingleton<Audio>
{
	public enum Ambient
	{
		MainMenu = 0,
		Game = 1,
		Beach = 2
	}

	[SerializeField]
	private AudioSource mainMenu;

	[SerializeField]
	private AudioSource ambient;

	[SerializeField]
	private AudioSource beach;

	[SerializeField]
	private AudioSource musicTrackA;

	[SerializeField]
	private AudioSource musicTrackB;

	[SerializeField]
	private List<AudioClip> gameMusicTracks;

	private MusicPlaylist _playlist;

	[SerializeField]
	private int defaultSfxCapacity = 5;

	[SerializeField]
	private List<AudioClip> typewriterClickSfx;

	private AudioSourcePool _sfxPool;

	public static MusicPlaylist Playlist => MonoSingleton<Audio>.Instance._playlist;

	private void Awake()
	{
		InitializeSfx();
		InitializePlaylist();
		ReactiveSettings.AudioMuted.Subscribe(delegate(bool x)
		{
			AudioListener.pause = x;
		}).AddTo(this);
		ReactiveSettings.AudioAmbientVolume.Subscribe(ambient, delegate(float a, AudioSource source)
		{
			source.volume = a;
		}).AddTo(this);
		ReactiveSettings.AudioAmbientVolume.Subscribe(beach, delegate(float a, AudioSource source)
		{
			source.volume = a;
		}).AddTo(this);
		ReactiveSettings.AudioMusicVolume.Subscribe(mainMenu, delegate(float a, AudioSource source)
		{
			source.volume = a;
		}).AddTo(this);
		SceneManager.sceneLoaded += HandleSceneChanged;
		ambient.Play();
	}

	public void SetAmbient(Ambient type)
	{
		switch (type)
		{
		case Ambient.MainMenu:
			if (!mainMenu.isPlaying)
			{
				mainMenu.Play();
			}
			if (!ambient.isPlaying)
			{
				ambient.Play();
			}
			beach.Stop();
			StopPlaylist();
			break;
		case Ambient.Game:
			mainMenu.Stop();
			if (!ambient.isPlaying)
			{
				ambient.Play();
			}
			beach.Stop();
			StartPlaylist();
			break;
		case Ambient.Beach:
			mainMenu.Stop();
			if (!beach.isPlaying)
			{
				beach.Play();
			}
			ambient.Stop();
			StopPlaylist();
			break;
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	protected override void OnDestroy()
	{
		_sfxPool?.Dispose();
		_playlist?.Dispose();
		SceneManager.sceneLoaded -= HandleSceneChanged;
		base.OnDestroy();
	}

	private void HandleSceneChanged(Scene scene, LoadSceneMode _)
	{
		string text = scene.name;
		if (!(text == "MainMenu"))
		{
			if (text == "GameScene")
			{
				SetAmbient(Ambient.Game);
			}
		}
		else
		{
			SetAmbient(Ambient.MainMenu);
		}
	}

	private void InitializePlaylist()
	{
		_playlist = new MusicPlaylist(musicTrackA, musicTrackB, ReactiveSettings.AudioMusicVolume, this.GetCancellationTokenOnDestroy());
	}

	private void StartPlaylist()
	{
		_playlist.PlayPlaylist(gameMusicTracks, restartFromBeginning: true);
	}

	private void StopPlaylist()
	{
		_playlist.Stop();
	}

	private void InitializeSfx()
	{
		_sfxPool = new AudioSourcePool(base.transform);
		_sfxPool.Prewarm(defaultSfxCapacity);
		_sfxPool.HandleFinishedAudioSourcesAsync(1f, this.GetCancellationTokenOnDestroy()).Forget();
	}

	public static void PlaySfx(AudioDataType type, float pitch = 1f)
	{
		PlaySfx(type.Value(), pitch);
	}

	public static void PlayTypewriterClick()
	{
		PlaySfx(MonoSingleton<Audio>.Instance.typewriterClickSfx.AsValueEnumerable().Random());
	}

	public static void PlaySfx(AudioClip clip, float pitch = 1f)
	{
		AudioSource audioSource = MonoSingleton<Audio>.Instance._sfxPool.Rent();
		audioSource.clip = clip;
		audioSource.pitch = pitch;
		ReactiveSettings.AudioSfxVolume.Take(1).Subscribe(audioSource, delegate(float a, AudioSource s)
		{
			s.volume = a;
		});
		audioSource.Play();
	}
}
