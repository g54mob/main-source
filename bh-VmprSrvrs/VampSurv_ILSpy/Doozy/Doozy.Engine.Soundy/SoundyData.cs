using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy;

[Serializable]
public class SoundyData
{
	public SoundSource SoundSource;

	public string DatabaseName;

	public string SoundName;

	public AudioClip AudioClip;

	public AudioMixerGroup OutputAudioMixerGroup;

	public SoundyData()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A7C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundSource = SoundSource.Soundy;
		DatabaseName = "General";
		SoundName = "No Sound";
		AudioClip = null;
	}

	public SoundGroupData GetAudioData()
	{
		SoundyDatabase database = SoundySettings.Database;
		if ((object)database != null)
		{
			if (!database.Contains(DatabaseName))
			{
				return null;
			}
			SoundDatabase soundDatabase = database.GetSoundDatabase(DatabaseName);
			if ((object)soundDatabase != null)
			{
				return soundDatabase.GetData(SoundName);
			}
		}
		return (SoundGroupData)(object)new NullReferenceException();
	}

	public void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A7C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundSource = SoundSource.Soundy;
		DatabaseName = "General";
		SoundName = "No Sound";
		AudioClip = null;
	}

	public SoundyData SetAudioClip(AudioClip audioClip)
	{
		AudioClip = audioClip;
		return this;
	}

	public SoundyData SetDatabaseName(string databaseName)
	{
		DatabaseName = databaseName;
		return this;
	}

	public SoundyData SetOutputAudioMixerGroup(AudioMixerGroup audioMixerGroup)
	{
		OutputAudioMixerGroup = audioMixerGroup;
		return this;
	}

	public SoundyData SetSoundName(string soundName)
	{
		SoundName = soundName;
		return this;
	}

	public SoundyData SetSoundSource(SoundSource soundSource)
	{
		SoundSource = soundSource;
		return this;
	}
}
