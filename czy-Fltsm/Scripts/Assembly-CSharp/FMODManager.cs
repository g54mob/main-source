using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public static class FMODManager
{
	private static VCA _masterVCA;

	private static VCA _musicVCA;

	private static VCA _uiVCA;

	private static VCA _sfxVCA;

	public static bool IsInitialized => RuntimeManager.IsInitialized;

	public static void ApplyAudioPlayerData(AudioPlayerData audioPlayerData)
	{
		SetMasterVolume(audioPlayerData.MasterVolume);
		SetMusicVolume(audioPlayerData.MusicVolume);
		SetUIVolume(audioPlayerData.UIVolume);
		SetSFXVolume(audioPlayerData.SFXVolume);
	}

	public static void SetAllVolumeLevels(float volume)
	{
		SetMasterVolume(volume);
		SetMusicVolume(volume);
		SetUIVolume(volume);
		SetSFXVolume(volume);
	}

	public static void SetMasterVolume(float volume)
	{
		if (_masterVCA.handle == IntPtr.Zero)
		{
			_masterVCA = RuntimeManager.GetVCA("vca:/master");
		}
		_masterVCA.setVolume(Mathf.Clamp(volume, 0f, 1f));
	}

	public static void SetMusicVolume(float volume)
	{
		if (_musicVCA.handle == IntPtr.Zero)
		{
			_musicVCA = RuntimeManager.GetVCA("vca:/music");
		}
		_musicVCA.setVolume(Mathf.Clamp(volume, 0f, 1f));
	}

	public static void SetUIVolume(float volume)
	{
		if (_uiVCA.handle == IntPtr.Zero)
		{
			_uiVCA = RuntimeManager.GetVCA("vca:/ui");
		}
		_uiVCA.setVolume(Mathf.Clamp(volume, 0f, 1f));
	}

	public static void SetSFXVolume(float volume)
	{
		if (_sfxVCA.handle == IntPtr.Zero)
		{
			_sfxVCA = RuntimeManager.GetVCA("vca:/sfx");
		}
		_sfxVCA.setVolume(Mathf.Clamp(volume, 0f, 1f));
	}
}
