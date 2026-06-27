using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyAmbienceModule : CozyBiomeModuleBase<CozyAmbienceModule>
	{
		[Serializable]
		public class WeightedAmbience
		{
			public AmbienceProfile ambienceProfile;

			[Range(0f, 1f)]
			public float weight;

			public bool transitioning;

			public IEnumerator Transition(float value, float time)
			{
				transitioning = true;
				float t = 0f;
				float start = weight;
				for (; t < time; t += Time.deltaTime)
				{
					float div = t / time;
					yield return new WaitForEndOfFrame();
					weight = Mathf.Lerp(start, value, div);
				}
				weight = value;
				ambienceProfile.SetWeight(weight);
				transitioning = false;
			}
		}

		[CozySearchable(new string[] { "Ambiences", "Ambience profiles", "profiles" })]
		public AmbienceProfile[] ambienceProfiles = new AmbienceProfile[0];

		public List<WeightedAmbience> weightedAmbience = new List<WeightedAmbience>();

		[CozySearchable(new string[] { "Ambience", "Ambience profile", "profile" })]
		public AmbienceProfile currentAmbienceProfile;

		public AmbienceProfile ambienceChangeCheck;

		public float timeToChangeProfiles = 7f;

		public float ambienceTimer;

		private void Start()
		{
			if (!base.enabled || base.isBiomeModule)
			{
				return;
			}
			if (ambienceProfiles.Length == 0)
			{
				FindAllAmbiences();
			}
			AmbienceProfile[] array = ambienceProfiles;
			for (int i = 0; i < array.Length; i++)
			{
				FXProfile[] fX = array[i].FX;
				for (int j = 0; j < fX.Length; j++)
				{
					fX[j]?.InitializeEffect(base.weatherSphere);
				}
			}
			if (Application.isPlaying)
			{
				SetNextAmbience();
				weightedAmbience = new List<WeightedAmbience>
				{
					new WeightedAmbience
					{
						weight = 1f,
						ambienceProfile = currentAmbienceProfile
					}
				};
			}
		}

		public void FindAllAmbiences()
		{
			List<AmbienceProfile> list = new List<AmbienceProfile>();
			AmbienceProfile[] allInstances = EditorUtilities.GetAllInstances<AmbienceProfile>();
			foreach (AmbienceProfile ambienceProfile in allInstances)
			{
				if (ambienceProfile.name != "Default Ambience")
				{
					list.Add(ambienceProfile);
				}
			}
			allInstances = ambienceProfiles;
			for (int i = 0; i < allInstances.Length; i++)
			{
				FXProfile[] fX = allInstances[i].FX;
				for (int j = 0; j < fX.Length; j++)
				{
					fX[j]?.InitializeEffect(base.weatherSphere);
				}
			}
			ambienceProfiles = list.ToArray();
		}

		public override void UpdateWeatherWeights()
		{
			if (Application.isPlaying)
			{
				if (ambienceChangeCheck != currentAmbienceProfile)
				{
					SetAmbience(currentAmbienceProfile);
				}
				if ((bool)base.weatherSphere.timeModule)
				{
					ambienceTimer -= Time.deltaTime * base.weatherSphere.timeModule.modifiedTimeSpeed;
				}
				else
				{
					ambienceTimer -= Time.deltaTime * 0.005f;
				}
				if (ambienceTimer <= 0f)
				{
					SetNextAmbience();
				}
				foreach (WeightedAmbience item in weightedAmbience)
				{
					item.weight *= weight;
				}
				weightedAmbience.RemoveAll((WeightedAmbience x) => x.weight == 0f && !x.transitioning);
			}
			ComputeBiomeWeights();
		}

		public override void UpdateFXWeights()
		{
			foreach (WeightedAmbience item in weightedAmbience)
			{
				if (item != null && (bool)item.ambienceProfile)
				{
					item.ambienceProfile.SetWeight(item.weight);
				}
			}
		}

		public override void UpdateBiomeModule()
		{
			currentAmbienceProfile.SetWeight(weight);
		}

		public void SetNextAmbience()
		{
			currentAmbienceProfile = WeightedRandom(ambienceProfiles.ToArray());
		}

		public void SetAmbience(AmbienceProfile profile)
		{
			currentAmbienceProfile = profile;
			ambienceChangeCheck = currentAmbienceProfile;
			if (weightedAmbience.Find((WeightedAmbience x) => x.ambienceProfile == profile) == null)
			{
				weightedAmbience.Add(new WeightedAmbience
				{
					weight = 0f,
					ambienceProfile = profile,
					transitioning = true
				});
			}
			foreach (WeightedAmbience item in weightedAmbience)
			{
				if (item.ambienceProfile == profile)
				{
					StartCoroutine(item.Transition(1f, timeToChangeProfiles));
				}
				else
				{
					StartCoroutine(item.Transition(0f, timeToChangeProfiles));
				}
			}
			ambienceTimer += UnityEngine.Random.Range(currentAmbienceProfile.minTime, currentAmbienceProfile.maxTime);
		}

		public void SetAmbience(AmbienceProfile profile, float timeToChange)
		{
			currentAmbienceProfile = profile;
			ambienceChangeCheck = currentAmbienceProfile;
			if (weightedAmbience.Find((WeightedAmbience x) => x.ambienceProfile == profile) == null)
			{
				weightedAmbience.Add(new WeightedAmbience
				{
					weight = 0f,
					ambienceProfile = profile,
					transitioning = true
				});
			}
			foreach (WeightedAmbience item in weightedAmbience)
			{
				if (item.ambienceProfile == profile)
				{
					StartCoroutine(item.Transition(1f, timeToChange));
				}
				else
				{
					StartCoroutine(item.Transition(0f, timeToChange));
				}
			}
			ambienceTimer += UnityEngine.Random.Range(currentAmbienceProfile.minTime, currentAmbienceProfile.maxTime);
		}

		public void SkipTime(float timeToSkip)
		{
			ambienceTimer -= timeToSkip;
		}

		public AmbienceProfile WeightedRandom(AmbienceProfile[] profiles)
		{
			AmbienceProfile ambienceProfile = null;
			List<float> list = new List<float>();
			float num = 0f;
			foreach (AmbienceProfile ambienceProfile2 in profiles)
			{
				float num2 = ((!base.weatherSphere.weatherModule) ? ambienceProfile2.GetChance(base.weatherSphere) : ((!ambienceProfile2.dontPlayDuring.Contains(base.weatherSphere.weatherModule.ecosystem.currentWeather)) ? ambienceProfile2.GetChance(base.weatherSphere) : 0f));
				list.Add(num2);
				num += num2;
			}
			if (num == 0f)
			{
				ambienceProfile = (AmbienceProfile)Resources.Load("Default Ambience");
				Debug.LogWarning("Could not find a suitable ambience given the current selected profiles and chance effectors. Defaulting to an empty ambience.");
				return ambienceProfile;
			}
			float num3 = UnityEngine.Random.Range(0f, num);
			int num4 = 0;
			float num5 = 0f;
			while (num5 <= num3)
			{
				if (num3 >= num5 && num3 < num5 + list[num4])
				{
					ambienceProfile = profiles[num4];
					break;
				}
				num5 += list[num4];
				num4++;
			}
			if (!ambienceProfile)
			{
				ambienceProfile = profiles[0];
			}
			return ambienceProfile;
		}

		public float GetTimeTillNextAmbience()
		{
			return ambienceTimer;
		}
	}
}
