using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioManager
{
	public static int MaxChannels;

	public static int FurniturePlaying;

	public static AudioMixer MasterMixer;

	public static AudioMixerGroup Master;

	public static AudioMixerGroup UI;

	public static AudioMixerGroup UIReverb;

	public static AudioMixerGroup World;

	public static AudioMixerGroup InGame;

	public static AudioMixerGroup InGameNormal;

	public static AudioMixerGroup InGameHighPass;

	public static AudioMixerGroup Environment;

	public static AudioMixerGroup Music;

	public static Dictionary<string, AudioMixerGroup> MixerMap;

	public static Dictionary<string, float> InitVolumes;

	public static bool VolumeLoaded;

	private static bool _volumeInitialized;

	static AudioManager()
	{
		FurniturePlaying = 0;
		MixerMap = new Dictionary<string, AudioMixerGroup>();
		InitVolumes = new Dictionary<string, float>();
		VolumeLoaded = false;
		_volumeInitialized = false;
		MaxChannels = AudioSettings.GetConfiguration().numVirtualVoices;
		MasterMixer = Resources.Load<AudioMixer>("MasterMixer");
		Master = MasterMixer.FindMatchingGroups("Master")[0];
		UI = MasterMixer.FindMatchingGroups("Master/UI")[0];
		UIReverb = MasterMixer.FindMatchingGroups("Master/UI/UIReverb")[0];
		World = MasterMixer.FindMatchingGroups("Master/World")[0];
		InGame = MasterMixer.FindMatchingGroups("Master/World/In-game")[0];
		InGameNormal = MasterMixer.FindMatchingGroups("Master/World/In-game/Normal")[0];
		InGameHighPass = MasterMixer.FindMatchingGroups("Master/World/In-game/HighPass")[0];
		Environment = MasterMixer.FindMatchingGroups("Master/World/Environment")[0];
		Music = MasterMixer.FindMatchingGroups("Master/World/Music")[0];
		MixerMap = new Dictionary<string, AudioMixerGroup>
		{
			{ "Master", Master },
			{ "Music", Music },
			{ "SFX", InGame },
			{ "UI", UI },
			{ "Environment", Environment }
		};
	}

	public static List<string> ToConfig()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, AudioMixerGroup> item in MixerMap)
		{
			list.Add(item.Key + "=" + GetVolume(item.Key));
		}
		return list;
	}

	public static void LoadConfig(List<string> values)
	{
		_volumeInitialized = true;
		if (values == null)
		{
			return;
		}
		foreach (string value2 in values)
		{
			try
			{
				string[] array = value2.Split('=');
				string key = array[0];
				float value = (float)Convert.ToDouble(array[1]);
				InitVolumes[key] = value;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	public static float GetVolume(string map)
	{
		float value;
		if (!VolumeLoaded && InitVolumes.TryGetValue(map, out value))
		{
			return value;
		}
		MasterMixer.GetFloat(map + "Volume", out value);
		return value;
	}

	public static void SetVolume(string map, float volume, bool save = true)
	{
		MasterMixer.SetFloat(map + "Volume", Mathf.Min(volume, 0f));
		if (save && _volumeInitialized)
		{
			Options.SaveToFile();
		}
	}
}
