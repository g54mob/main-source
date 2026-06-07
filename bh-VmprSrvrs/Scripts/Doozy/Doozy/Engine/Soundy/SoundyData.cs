using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy
{
	[Serializable]
	public class SoundyData
	{
		public SoundSource SoundSource;

		public string DatabaseName;

		public string SoundName;

		public AudioClip AudioClip;

		public AudioMixerGroup OutputAudioMixerGroup;

		public SoundGroupData GetAudioData()
		{
			return null;
		}

		public void Reset()
		{
		}

		public SoundyData SetAudioClip(AudioClip audioClip)
		{
			return null;
		}

		public SoundyData SetDatabaseName(string databaseName)
		{
			return null;
		}

		public SoundyData SetOutputAudioMixerGroup(AudioMixerGroup audioMixerGroup)
		{
			return null;
		}

		public SoundyData SetSoundName(string soundName)
		{
			return null;
		}

		public SoundyData SetSoundSource(SoundSource soundSource)
		{
			return null;
		}
	}
}
