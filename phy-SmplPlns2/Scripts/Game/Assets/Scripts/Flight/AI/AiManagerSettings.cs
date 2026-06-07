using System;
using UnityEngine;

namespace Assets.Scripts.Flight.AI
{
	public class AiManagerSettings
	{
		public const int MaxAiTrafficCountDefault = 1;

		private const string PlayerPrefsKey = "AiManager";

		private const char PlayerPrefsSeperator = '@';

		private float _agressiveSpawnFrequency;

		private float _aircraftDespawnDistance;

		private int _aircraftSpawnProbabilityPerSecond;

		private float _bulletTargetingDifficulty;

		private float _damagedAircraftDespawnTime;

		private int _maxAiTrafficCount;

		private float _nonAgressiveSpawnFrequency;

		private float _trackingDifficulty;

		public float AgressiveSpawnFrequency
		{
			get
			{
				return _agressiveSpawnFrequency;
			}
			set
			{
				_agressiveSpawnFrequency = value;
				SaveSettings();
			}
		}

		public float AircraftDespawnDistance
		{
			get
			{
				return _aircraftDespawnDistance;
			}
			set
			{
				_aircraftDespawnDistance = value;
			}
		}

		public int AircraftSpawnProbabilityPerSecond
		{
			get
			{
				return _aircraftSpawnProbabilityPerSecond;
			}
			set
			{
				_aircraftSpawnProbabilityPerSecond = value;
			}
		}

		public float BulletTargetingDifficulty
		{
			get
			{
				return _bulletTargetingDifficulty;
			}
			set
			{
				_bulletTargetingDifficulty = value;
				SaveSettings();
			}
		}

		public float DamagedAircraftDespawnTime
		{
			get
			{
				return _damagedAircraftDespawnTime;
			}
			set
			{
				_damagedAircraftDespawnTime = value;
				SaveSettings();
			}
		}

		public int MaxAiTrafficCount
		{
			get
			{
				return _maxAiTrafficCount;
			}
			set
			{
				_maxAiTrafficCount = value;
				SaveSettings();
			}
		}

		public float NonAgressiveSpawnFrequency
		{
			get
			{
				return _nonAgressiveSpawnFrequency;
			}
			set
			{
				_nonAgressiveSpawnFrequency = value;
				SaveSettings();
			}
		}

		public float TrackingDifficulty
		{
			get
			{
				return _trackingDifficulty;
			}
			set
			{
				_trackingDifficulty = value;
				SaveSettings();
			}
		}

		public AiManagerSettings()
		{
			RestoreDefaultValues();
			RestoreFromPlayerPrefs();
		}

		public void SaveSettings()
		{
			string value = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}", '@', AgressiveSpawnFrequency, BulletTargetingDifficulty, MaxAiTrafficCount, NonAgressiveSpawnFrequency, TrackingDifficulty, DamagedAircraftDespawnTime);
			PlayerPrefs.SetString("AiManager", value);
			PlayerPrefs.Save();
		}

		private void RestoreDefaultValues()
		{
			_agressiveSpawnFrequency = 1f;
			_bulletTargetingDifficulty = 1f;
			_maxAiTrafficCount = 0;
			_nonAgressiveSpawnFrequency = 1f;
			_trackingDifficulty = 1f;
			_damagedAircraftDespawnTime = 20f;
			_aircraftDespawnDistance = 40000f;
			_aircraftSpawnProbabilityPerSecond = 5;
		}

		private void RestoreFromPlayerPrefs()
		{
			string text = PlayerPrefs.GetString("AiManager");
			if (string.IsNullOrEmpty(text))
			{
				RestoreDefaultValues();
				SaveSettings();
				Debug.Log("No Manager settings detected...defaulting and saving defaults");
				return;
			}
			try
			{
				string[] array = text.Split('@');
				_agressiveSpawnFrequency = float.Parse(array[0]);
				_bulletTargetingDifficulty = float.Parse(array[1]);
				_maxAiTrafficCount = int.Parse(array[2]);
				_nonAgressiveSpawnFrequency = float.Parse(array[3]);
				_trackingDifficulty = float.Parse(array[4]);
				_damagedAircraftDespawnTime = float.Parse(array[5]);
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("There was a problem reading the AiManager settings, restoring defaults: {0}", ex.Message);
				RestoreDefaultValues();
				SaveSettings();
			}
		}
	}
}
