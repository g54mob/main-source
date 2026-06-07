using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Environment
{
	public class EnvironmentManagerScript : MonoBehaviour
	{
		private class RandomPresetItem
		{
			public int MaxValue { get; set; }

			public int MinValue { get; set; }

			public WeatherPreset? Preset { get; set; }

			public RandomPresetItem(WeatherPreset? preset, int min, int max)
			{
				Preset = preset;
				MinValue = min;
				MaxValue = max;
			}
		}

		public int WeatherChangeWeight_BrokenClouds;

		public int WeatherChangeWeight_Clear;

		public int WeatherChangeWeight_FewClouds;

		public int WeatherChangeWeight_HeavyFog;

		public int WeatherChangeWeight_LightFog;

		public int WeatherChangeWeight_NoChange;

		public int WeatherChangeWeight_Overcast;

		public int WeatherChangeWeight_ScatteredClouds;

		public int WeatherChangeWeight_Stormy;

		private float _lengthOfDay;

		private WeatherPreset _previousWeatherChangeState = WeatherPreset.ScatteredClouds;

		protected virtual void Awake()
		{
			FlightSceneScript.Instance.FlightSceneLoaded += OnFlightSceneLoaded;
		}

		protected virtual void Update()
		{
			FlightSceneScript.Instance.Environment.Update(Time.deltaTime, Time.unscaledDeltaTime);
			float lengthOfDay = FlightSceneScript.Instance.Environment.LengthOfDay;
			if (!Mathf.Approximately(lengthOfDay, _lengthOfDay))
			{
				LengthOfDayChanged(lengthOfDay);
			}
		}

		private float GetTransitionTime(WeatherPreset to)
		{
			WeatherPreset previousWeatherChangeState = _previousWeatherChangeState;
			bool flag = previousWeatherChangeState == WeatherPreset.Overcast || previousWeatherChangeState == WeatherPreset.Stormy || previousWeatherChangeState == WeatherPreset.LightFog || previousWeatherChangeState == WeatherPreset.HeavyFog;
			bool flag2 = to == WeatherPreset.Overcast || to == WeatherPreset.Stormy || to == WeatherPreset.LightFog || to == WeatherPreset.HeavyFog;
			if (flag && !flag2)
			{
				return 20f;
			}
			if (!flag && flag2)
			{
				return 25f;
			}
			return 15f;
		}

		private void LengthOfDayChanged(float lengthOfDay)
		{
			_lengthOfDay = lengthOfDay;
			StopAllCoroutines();
			StartWeatherChanger();
		}

		private void OnFlightSceneLoaded(object sender, EventArgs e)
		{
			_lengthOfDay = FlightSceneScript.Instance.Environment.LengthOfDay;
			StartWeatherChanger();
		}

		private void StartWeatherChanger()
		{
			StartCoroutine(WeatherChangerCoroutine());
		}

		private float UpdateWeather()
		{
			float result = 0f;
			List<RandomPresetItem> list = new List<RandomPresetItem>();
			list.Add(new RandomPresetItem(null, 1, WeatherChangeWeight_NoChange));
			list.Add(new RandomPresetItem(WeatherPreset.Clear, list[list.Count - 1].MaxValue + 1, list[list.Count - 1].MaxValue + WeatherChangeWeight_Clear));
			list.Add(new RandomPresetItem(WeatherPreset.FewClouds, list[list.Count - 1].MaxValue + 1, list[list.Count - 1].MaxValue + WeatherChangeWeight_FewClouds));
			list.Add(new RandomPresetItem(WeatherPreset.ScatteredClouds, list[list.Count - 1].MaxValue + 1, list[list.Count - 1].MaxValue + WeatherChangeWeight_ScatteredClouds));
			list.Add(new RandomPresetItem(WeatherPreset.BrokenClouds, list[list.Count - 1].MaxValue + 1, list[list.Count - 1].MaxValue + WeatherChangeWeight_BrokenClouds));
			list.Add(new RandomPresetItem(WeatherPreset.Overcast, list[list.Count - 1].MaxValue + 1, list[list.Count - 1].MaxValue + WeatherChangeWeight_Overcast));
			list.Add(new RandomPresetItem(WeatherPreset.Stormy, list[list.Count - 1].MaxValue + 1, list[list.Count - 1].MaxValue + WeatherChangeWeight_Stormy));
			list.Add(new RandomPresetItem(WeatherPreset.LightFog, list[list.Count - 1].MaxValue + 1, list[list.Count - 1].MaxValue + WeatherChangeWeight_LightFog));
			list.Add(new RandomPresetItem(WeatherPreset.HeavyFog, list[list.Count - 1].MaxValue + 1, list[list.Count - 1].MaxValue + WeatherChangeWeight_HeavyFog));
			int num = UnityEngine.Random.Range(1, list[list.Count - 1].MaxValue);
			for (int i = 0; i < list.Count; i++)
			{
				RandomPresetItem randomPresetItem = list[i];
				if (num <= randomPresetItem.MaxValue)
				{
					if (randomPresetItem.Preset.HasValue)
					{
						result = UpdateWeather(randomPresetItem.Preset.Value);
					}
					break;
				}
			}
			return result;
		}

		private float UpdateWeather(WeatherPreset newWeather)
		{
			float transitionTime = GetTransitionTime(newWeather);
			FlightSceneScript.Instance.Environment.UpdateWeather(newWeather, transitionTime, ignorePause: false);
			_previousWeatherChangeState = newWeather;
			return transitionTime;
		}

		private IEnumerator WeatherChangerCoroutine()
		{
			while (true)
			{
				float num = _lengthOfDay * 60f;
				float minWeatherChangeTime = Mathf.Max(30f, num * 0.1f);
				float maxInclusive = num * 0.5f;
				float seconds = UnityEngine.Random.Range(minWeatherChangeTime, maxInclusive);
				yield return new WaitForSeconds(seconds);
				while (PauseManager.Paused)
				{
					yield return new WaitForSeconds(minWeatherChangeTime);
				}
				if (FlightSceneScript.Instance.Environment.DynamicWeatherEnabled)
				{
					float seconds2 = UpdateWeather();
					yield return new WaitForSeconds(seconds2);
				}
			}
		}
	}
}
