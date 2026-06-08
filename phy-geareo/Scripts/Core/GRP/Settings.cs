using System;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class Settings
	{
		[JsonDataState(null)]
		public State<float> musicAudioVolume;

		[JsonDataState(null)]
		public State<bool> musicAudioEnabled;

		[JsonDataState(null)]
		public State<float> sfxAudioVolume;

		[JsonDataState(null)]
		public State<bool> sfxAudioEnabled;

		[JsonDataState(null)]
		public State<bool> fullscreen;

		[JsonDataState(null)]
		public State<int> resolutionWidth;

		[JsonDataState(null)]
		public State<int> resolutionHeight;

		[JsonDataState(null)]
		public State<int> targetFrameRate;

		[JsonDataState(null)]
		public State<bool> rattleSystemEnabled;

		[JsonDataState(null)]
		public State<bool> guideEnabled;

		public Action onChanged;

		public Vector2Int defaultResolution;

		public Vector2Int[] resolutions;

		public SettingsConfig config;

		public Vector2Int resolution => default(Vector2Int);

		public Settings(SettingsConfig config)
		{
		}

		public void UpdateView()
		{
		}

		public void SetResolution(Vector2Int resolution)
		{
		}

		public void SetResolution(int width, int height, bool fullscreen)
		{
		}

		public SettingsData Serialize()
		{
			return null;
		}

		public void Deserialize(SettingsData data)
		{
		}

		public void Save()
		{
		}

		public void Load()
		{
		}
	}
}
