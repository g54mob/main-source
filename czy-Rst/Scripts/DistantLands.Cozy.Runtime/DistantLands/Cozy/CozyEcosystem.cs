using System;
using System.Collections.Generic;
using System.Linq;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	public class CozyEcosystem
	{
		public enum EcosystemStyle
		{
			manual = 0,
			forecast = 1,
			dailyForecast = 2,
			automatic = 3,
			random = 4
		}

		[Serializable]
		public class WeatherPattern
		{
			public WeatherProfile profile;

			public MeridiemTime startTime;

			public MeridiemTime endTime;

			public float duration
			{
				get
				{
					if (!((float)startTime < (float)endTime))
					{
						return Mathf.Ceil(endTime) - (float)startTime;
					}
					return (float)endTime - (float)startTime;
				}
			}
		}

		public ForecastProfile forecastProfile;

		[Tooltip("How should this ecosystem manage weather selection? \n\n[Manual] allows you to manually select the weather profiles and weights for this ecosystem,\n\n[Automatic] allows you to manually select a weather profile and COZY will determine the weights automatically,\n\n[Forecast] allows for dynamically changing weather based on a predetermined forecast that runs entirely on it's own,\n\n[Daily Forecast] allows for a forecast that only changes at midnight every day for a more predictable play style,\n\n[Random] selects a random weather after the previous is done playing with no smart forecasting features.")]
		public EcosystemStyle weatherSelectionMode = EcosystemStyle.forecast;

		public List<WeatherPattern> currentForecast = new List<WeatherPattern>();

		public float weatherTransitionTime = 15f;

		public CozyWeather weatherSphere;

		public CozySystem system;

		public bool removeProfilesWithNoWeight = true;

		public WeatherProfile currentWeather;

		public WeatherProfile weatherChangeCheck;

		[WeatherRelation]
		public List<WeatherRelation> weightedWeatherProfiles = new List<WeatherRelation>();

		public float weatherTimer { get; set; }

		public WeatherRelation GetWeatherRelation(WeatherProfile profile, List<WeatherRelation> list)
		{
			foreach (WeatherRelation item in list)
			{
				if (item.profile == profile)
				{
					return item;
				}
			}
			WeatherRelation weatherRelation = new WeatherRelation();
			weatherRelation.profile = profile;
			list.Add(weatherRelation);
			return list.Last();
		}

		public void SetupEcosystem()
		{
			if (currentWeather == null)
			{
				currentWeather = (WeatherProfile)Resources.Load("Profiles/Weather Profiles/Partly Cloudy");
			}
			if (forecastProfile == null)
			{
				forecastProfile = (ForecastProfile)Resources.Load("Profiles/Forecast Profiles/Complex Forecast Profile");
			}
			weatherTimer = 0f;
			if (!Application.isPlaying)
			{
				return;
			}
			if (weatherSelectionMode == EcosystemStyle.forecast || weatherSelectionMode == EcosystemStyle.dailyForecast)
			{
				switch (forecastProfile.startWeatherWith)
				{
				case ForecastProfile.StartWeatherWith.InitialProfile:
				{
					if (forecastProfile.initialProfile == null)
					{
						for (int j = 0; j < forecastProfile.forecastLength; j++)
						{
							ForecastNewWeather();
						}
						break;
					}
					ForecastNewWeather(forecastProfile.initialProfile);
					for (int k = 1; k < forecastProfile.forecastLength; k++)
					{
						ForecastNewWeather();
					}
					break;
				}
				case ForecastProfile.StartWeatherWith.InitialForecast:
				{
					for (int l = 0; l < forecastProfile.initialForecast.Count; l++)
					{
						ForecastNewWeather(forecastProfile.initialForecast[l].profile, forecastProfile.initialForecast[l].duration);
					}
					for (int m = forecastProfile.initialForecast.Count; m < forecastProfile.forecastLength; m++)
					{
						ForecastNewWeather();
					}
					break;
				}
				case ForecastProfile.StartWeatherWith.Random:
				{
					for (int i = 0; i < forecastProfile.forecastLength; i++)
					{
						ForecastNewWeather();
					}
					break;
				}
				}
				SetupWeather();
			}
			else if (weatherSelectionMode == EcosystemStyle.manual && weightedWeatherProfiles.Count <= 0)
			{
				weightedWeatherProfiles = new List<WeatherRelation>
				{
					new WeatherRelation()
				};
				weightedWeatherProfiles[0].profile = currentWeather;
				weightedWeatherProfiles[0].weight = 1f;
				weatherChangeCheck = currentWeather;
			}
		}

		public void SetupWeather()
		{
			weightedWeatherProfiles = new List<WeatherRelation>();
			WeatherProfile profile = (currentWeather = currentForecast[0].profile);
			if (weatherSelectionMode == EcosystemStyle.forecast)
			{
				weatherTimer += currentForecast[0].duration;
			}
			else if (weatherSelectionMode == EcosystemStyle.dailyForecast)
			{
				weatherTimer += 1f - weatherSphere.dayPercentage;
			}
			GetWeatherRelation(profile, weightedWeatherProfiles).weight = 1f;
			currentForecast.RemoveAt(0);
			ForecastNewWeather();
		}

		public void SkipTicks(float ticksToSkip)
		{
			weatherTimer -= ticksToSkip;
		}

		public void UpdateEcosystem()
		{
			if (weatherSphere == null)
			{
				Debug.LogWarning("No weather sphere found. Ecosystem is not running!");
				return;
			}
			if (Application.isPlaying)
			{
				if (weatherSelectionMode == EcosystemStyle.forecast || weatherSelectionMode == EcosystemStyle.dailyForecast || weatherSelectionMode == EcosystemStyle.random)
				{
					if ((bool)weatherSphere.timeModule)
					{
						weatherTimer -= Time.deltaTime * weatherSphere.timeModule.modifiedTimeSpeed;
					}
					else
					{
						weatherTimer -= Time.deltaTime;
					}
					while (weatherTimer <= 0f)
					{
						SetNextWeather();
					}
				}
				if (weatherChangeCheck != currentWeather)
				{
					SetWeather(currentWeather, weatherTransitionTime);
				}
				foreach (WeatherRelation weightedWeatherProfile in weightedWeatherProfiles)
				{
					if (weightedWeatherProfile.weight == 0f)
					{
						FXProfile[] fX = weightedWeatherProfile.profile.FX;
						for (int i = 0; i < fX.Length; i++)
						{
							fX[i].PlayEffect(0f);
						}
					}
				}
				if (removeProfilesWithNoWeight)
				{
					weightedWeatherProfiles.RemoveAll((WeatherRelation x) => x.weight == 0f && !x.transitioning);
				}
			}
			else
			{
				if (weatherSelectionMode != EcosystemStyle.manual)
				{
					weightedWeatherProfiles = new List<WeatherRelation>
					{
						new WeatherRelation
						{
							profile = currentWeather,
							weight = 1f
						}
					};
				}
				if (weatherChangeCheck != currentWeather)
				{
					if ((bool)weatherChangeCheck)
					{
						weatherChangeCheck.SetWeatherWeight(0f);
					}
					weatherChangeCheck = currentWeather;
				}
			}
			if (weatherSelectionMode != EcosystemStyle.manual)
			{
				ClampEcosystem();
			}
		}

		public void ClampEcosystem()
		{
			float num = 0f;
			foreach (WeatherRelation weightedWeatherProfile in weightedWeatherProfiles)
			{
				num += weightedWeatherProfile.weight;
			}
			if (num == 0f)
			{
				num = 1f;
			}
			foreach (WeatherRelation weightedWeatherProfile2 in weightedWeatherProfiles)
			{
				weightedWeatherProfile2.weight /= num;
			}
		}

		public void SetupWeatherForecast()
		{
			while (currentForecast.Count < forecastProfile.forecastLength)
			{
				ForecastNewWeather();
			}
		}

		public void SetNextWeather()
		{
			SetupWeatherForecast();
			if (currentForecast.Count == 0)
			{
				ForecastNewWeather();
			}
			SetWeather(currentForecast[0].profile);
			weatherTimer += currentForecast[0].duration;
			currentForecast.RemoveAt(0);
			ForecastNewWeather();
		}

		public void SetWeather(WeatherProfile prof, float transitionTime)
		{
			currentWeather = prof;
			weatherChangeCheck = currentWeather;
			if (weightedWeatherProfiles.Find((WeatherRelation x) => x.profile == prof) == null)
			{
				weightedWeatherProfiles.Add(new WeatherRelation
				{
					profile = prof,
					weight = 0f,
					transitioning = true
				});
			}
			foreach (WeatherRelation weightedWeatherProfile in weightedWeatherProfiles)
			{
				if (weightedWeatherProfile.profile == prof)
				{
					weatherSphere.StartCoroutine(weightedWeatherProfile.Transition(1f, transitionTime));
				}
				else
				{
					weatherSphere.StartCoroutine(weightedWeatherProfile.Transition(0f, transitionTime));
				}
			}
		}

		public void SetWeather(WeatherProfile prof)
		{
			SetWeather(prof, weatherTransitionTime);
		}

		public void ForecastNewWeather()
		{
			WeatherProfile weatherProfile = ((currentForecast.Count <= 0) ? PickRandomWeather(forecastProfile.profilesToForecast.ToArray()) : PickRandomWeather(GetNextWeatherArray(forecastProfile.profilesToForecast.ToArray(), currentForecast.Last().profile.forecastNext, currentForecast.Last().profile.forecastModifierMethod)));
			ForecastNewWeather(weatherProfile, UnityEngine.Random.Range(weatherProfile.minWeatherTime, weatherProfile.maxWeatherTime));
		}

		public void ForecastNewWeather(WeatherProfile weatherProfile)
		{
			ForecastNewWeather(weatherProfile, UnityEngine.Random.Range(weatherProfile.minWeatherTime, weatherProfile.maxWeatherTime));
		}

		public void ForecastNewWeather(WeatherProfile weatherProfile, float duration)
		{
			WeatherPattern weatherPattern = new WeatherPattern
			{
				profile = weatherProfile
			};
			if (weatherSelectionMode == EcosystemStyle.forecast || weatherSelectionMode == EcosystemStyle.random)
			{
				weatherPattern.startTime = (float)weatherSphere.timeModule.currentTime + weatherTimer + (float)weatherSphere.timeModule.currentDay;
				foreach (WeatherPattern item in currentForecast)
				{
					weatherPattern.startTime = (float)weatherPattern.startTime + item.duration;
				}
				weatherPattern.endTime = (float)weatherPattern.startTime + duration;
			}
			else
			{
				weatherPattern.startTime = 0f;
				weatherPattern.endTime = 1f;
			}
			currentForecast.Add(weatherPattern);
		}

		private WeatherProfile PickRandomWeather(WeatherProfile[] profiles)
		{
			if (profiles.Count() == 0)
			{
				profiles = forecastProfile.profilesToForecast.ToArray();
			}
			if (weatherSelectionMode == EcosystemStyle.random)
			{
				return profiles[UnityEngine.Random.Range(0, profiles.Length - 1)];
			}
			WeatherProfile weatherProfile = null;
			List<float> list = new List<float>();
			float num = 0f;
			float inTime = 0f;
			if (currentForecast.Count != 0)
			{
				inTime = currentForecast[currentForecast.Count - 1].endTime;
			}
			WeatherProfile[] array = profiles;
			for (int i = 0; i < array.Length; i++)
			{
				float chance = array[i].GetChance(weatherSphere, inTime);
				list.Add(chance);
				num += chance;
			}
			float num2 = UnityEngine.Random.Range(0f, num);
			int num3 = 0;
			float num4 = 0f;
			while (num4 <= num2)
			{
				if (num3 >= list.Count)
				{
					weatherProfile = profiles[^1];
					break;
				}
				if (num2 >= num4 && num2 < num4 + list[num3])
				{
					weatherProfile = profiles[num3];
					break;
				}
				num4 += list[num3];
				num3++;
			}
			if (!weatherProfile)
			{
				weatherProfile = profiles[0];
			}
			return weatherProfile;
		}

		private WeatherProfile[] SubtractiveArray(WeatherProfile[] total, WeatherProfile[] subtraction)
		{
			return total.ToList().Except(subtraction.ToList()).ToArray();
		}

		private WeatherProfile[] IntersectionArray(WeatherProfile[] total, WeatherProfile[] intersection)
		{
			return intersection.ToList().Except(intersection.ToList().Except(total.ToList())).ToArray();
		}

		private WeatherProfile[] GetNextWeatherArray(WeatherProfile[] total, WeatherProfile[] exception, WeatherProfile.ForecastModifierMethod modifierMethod)
		{
			return modifierMethod switch
			{
				WeatherProfile.ForecastModifierMethod.DontForecastNext => SubtractiveArray(total, exception), 
				WeatherProfile.ForecastModifierMethod.forecastNext => IntersectionArray(total, exception), 
				_ => total, 
			};
		}
	}
}
