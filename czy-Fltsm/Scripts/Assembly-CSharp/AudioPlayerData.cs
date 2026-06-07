using System;
using UnityEngine;

[Serializable]
public class AudioPlayerData
{
	public bool FMOD;

	public float MasterVolume;

	public float MusicVolume;

	public float UIVolume;

	public float SFXVolume;

	private AudioPlayerData()
	{
	}

	public AudioPlayerData(bool fmod)
	{
		FMOD = fmod;
	}

	public AudioPlayerData(AudioPlayerData audioPlayerData)
	{
		Copy(audioPlayerData);
	}

	public void ResetSettings(float volume = 1f)
	{
		MasterVolume = volume;
		MusicVolume = volume;
		UIVolume = volume;
		SFXVolume = volume;
	}

	public bool IsEqual(AudioPlayerData audioData)
	{
		if (audioData.MasterVolume != MasterVolume)
		{
			return false;
		}
		if (audioData.MusicVolume != MusicVolume)
		{
			return false;
		}
		if (audioData.UIVolume != UIVolume)
		{
			return false;
		}
		if (audioData.SFXVolume != SFXVolume)
		{
			return false;
		}
		return true;
	}

	public void Copy(AudioPlayerData audioPlayerData)
	{
		MasterVolume = audioPlayerData.MasterVolume;
		MusicVolume = audioPlayerData.MusicVolume;
		UIVolume = audioPlayerData.UIVolume;
		SFXVolume = audioPlayerData.SFXVolume;
		FMOD = audioPlayerData.FMOD;
	}

	public void ConvertToFMOD()
	{
		if (!FMOD)
		{
			MasterVolume = Mathf.Pow(10f, MasterVolume / 20f);
			MusicVolume = Mathf.Pow(10f, MusicVolume / 20f);
			UIVolume = Mathf.Pow(10f, UIVolume / 20f);
			SFXVolume = Mathf.Pow(10f, SFXVolume / 20f);
			FMOD = true;
		}
	}
}
