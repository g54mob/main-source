using System;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class AudioSourceVolumeConnectionComponent : MonoBehaviour
	{
		public SettingsProvider SettingsProvider;

		public string ID;

		[Tooltip("How the input should be mapped to the requierd ouput of 0f..1f (X = min, Y = max).\nUseful if you have a range in percent (from 0 to 100) but need output ranging from 0f to 1f.")]
		public Vector2 InputRange = new Vector2(0f, 100f);

		public AudioSource[] AudioSources;

		[NonSerialized]
		public AudioSourceVolumeConnection Connection;

		public void Start()
		{
			SettingFloat orCreateFloat = SettingsProvider.Settings.GetOrCreateFloat(ID);
			if (!orCreateFloat.HasConnection())
			{
				Connection = new AudioSourceVolumeConnection(InputRange, AudioSources);
				orCreateFloat.SetConnection(Connection);
			}
			else
			{
				Connection = orCreateFloat.GetConnection() as AudioSourceVolumeConnection;
				if (Connection != null)
				{
					Connection.AddAudioSources(AudioSources);
				}
			}
			orCreateFloat.Apply();
		}

		public void Reset()
		{
			AudioSources = GetComponents<AudioSource>();
		}
	}
}
