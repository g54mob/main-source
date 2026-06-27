using System.Collections.Generic;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	public class LinkModule : CozyModule
	{
		private static readonly string[] Integrations = new string[6] { "None", "Netcode for Gameobjects", "PUN", "Mirror", "FishNetworking", "PurrNet" };

		public bool linkTime = true;

		public bool linkWeather = true;

		public bool linkAmbience = true;

		[Tooltip("Controls the amount of time (in seconds) before an RPC is sent to the server to sync the COZY systems.")]
		[Range(0f, 6f)]
		public float updateDelay = 0.5f;

		[Tooltip("Controls the amount of ticks away from the main server a client has to be before resyncing with the server. (Default: 2)")]
		[Range(0f, 15f)]
		public float timeSettingSensitivity = 2f;

		private float currentDelay;

		public Dictionary<WeatherProfile, int> weatherHashes = new Dictionary<WeatherProfile, int>();

		public Dictionary<AmbienceProfile, int> ambienceHashes = new Dictionary<AmbienceProfile, int>();

		public CozyAmbienceModule ambienceManager;

		public static string SelectedIntegrationName => Integrations[SelectedIntegration];

		public static int SelectedIntegration => 0;

		public int[] GetWeatherIDs()
		{
			List<int> list = new List<int>();
			foreach (WeatherRelation weightedWeatherProfile in base.weatherSphere.weatherModule.ecosystem.weightedWeatherProfiles)
			{
				list.Add(weatherHashes[weightedWeatherProfile.profile]);
			}
			return list.ToArray();
		}

		public float[] GetWeatherIntensities()
		{
			List<float> list = new List<float>();
			foreach (WeatherRelation weightedWeatherProfile in base.weatherSphere.weatherModule.ecosystem.weightedWeatherProfiles)
			{
				list.Add(weightedWeatherProfile.weight);
			}
			return list.ToArray();
		}

		public int[] PollValues(string key)
		{
			char c = ",".ToCharArray()[0];
			string[] array = key.Split(c);
			List<int> list = new List<int>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!(text == ""))
				{
					int item = int.Parse(text.TrimEnd(c));
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public float[] PollWeightValues(string key)
		{
			char c = ",".ToCharArray()[0];
			string[] array = key.Split(c);
			List<float> list = new List<float>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!(text == ""))
				{
					list.Add(float.Parse(text.TrimEnd(c)));
				}
			}
			return list.ToArray();
		}
	}
}
