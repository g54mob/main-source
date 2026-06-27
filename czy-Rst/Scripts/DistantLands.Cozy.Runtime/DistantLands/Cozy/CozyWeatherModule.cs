using System.Collections.Generic;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyWeatherModule : CozyBiomeModuleBase<CozyWeatherModule>, ICozyEcosystem
	{
		public float cumulus;

		public float cirrus;

		public float altocumulus;

		public float cirrostratus;

		public float chemtrails;

		public float nimbus;

		public float nimbusHeight;

		public float nimbusVariation;

		public float borderHeight;

		public float borderEffect;

		public float borderVariation;

		public float fogDensity;

		public float filterSaturation;

		public float filterValue;

		public Color filterColor = Color.white;

		public Color sunFilter = Color.white;

		public Color cloudFilter = Color.white;

		[CozySearchable(true, new string[] { })]
		public CozyEcosystem ecosystem;

		[WeatherRelation]
		[CozySearchable(new string[] { })]
		public List<WeatherRelation> currentWeatherProfiles = new List<WeatherRelation>();

		public FilterFX defaultFilter;

		public CloudFX defaultClouds;

		private WeatherProfile strongestWeather;

		public CozyEcosystem Ecosystem
		{
			get
			{
				return ecosystem;
			}
			set
			{
				ecosystem = value;
			}
		}

		public CozySystem LocalSystem => base.system;

		public void Awake()
		{
			if (base.enabled)
			{
				RunChecks();
				ecosystem.SetupEcosystem();
				ResetFilter();
				ResetClouds();
				strongestWeather = currentWeatherProfiles.Find((WeatherRelation x) => x.weight > 0.5f).profile;
			}
		}

		public override void InitializeModule()
		{
			base.isBiomeModule = GetComponent<CozyBiome>();
			if (base.isBiomeModule)
			{
				AddBiome();
				return;
			}
			base.InitializeModule();
			base.weatherSphere.weatherModule = this;
			AddBiome();
		}

		private void RunChecks()
		{
			defaultClouds = (CloudFX)Resources.Load("Default Profiles/Default Clouds");
			defaultFilter = (FilterFX)Resources.Load("Default Profiles/Default Filter");
			if (ecosystem == null)
			{
				ecosystem = new CozyEcosystem();
			}
			if (base.system == base.weatherSphere)
			{
				base.weatherSphere.weatherModule = this;
			}
			ecosystem.weatherSphere = base.weatherSphere;
			ecosystem.system = base.system;
		}

		public void Start()
		{
			foreach (WeatherProfile item in ecosystem.forecastProfile.profilesToForecast)
			{
				FXProfile[] fX = item.FX;
				for (int i = 0; i < fX.Length; i++)
				{
					fX[i]?.InitializeEffect(base.weatherSphere);
				}
			}
		}

		public override void UpdateWeatherWeights()
		{
			ecosystem.UpdateEcosystem();
			ManageGlobalEcosystem();
			UpdateWeatherByWeight();
			WeatherProfile profile = currentWeatherProfiles.Find((WeatherRelation x) => x.weight > 0.5f).profile;
			if (profile != strongestWeather)
			{
				strongestWeather = profile;
				base.weatherSphere.events.RaiseOnWeatherChange();
			}
		}

		public override void UpdateFXWeights()
		{
			foreach (WeatherRelation currentWeatherProfile in currentWeatherProfiles)
			{
				currentWeatherProfile.profile.SetWeatherWeight(currentWeatherProfile.weight);
			}
		}

		public override void FrameReset()
		{
			ResetClouds();
			ResetFilter();
		}

		private void ResetFilter()
		{
			if (ecosystem != null)
			{
				filterSaturation = defaultFilter.filterSaturation;
				filterValue = defaultFilter.filterValue;
				filterColor = defaultFilter.filterColor;
				sunFilter = defaultFilter.sunFilter;
				cloudFilter = defaultFilter.cloudFilter;
			}
		}

		private void ResetClouds()
		{
			if (ecosystem != null)
			{
				cumulus = defaultClouds.cumulusCoverage;
				cirrus = defaultClouds.cirrusCoverage;
				altocumulus = defaultClouds.altocumulusCoverage;
				cirrostratus = defaultClouds.cirrostratusCoverage;
				chemtrails = defaultClouds.chemtrailCoverage;
				nimbus = defaultClouds.nimbusCoverage;
				nimbusHeight = defaultClouds.nimbusHeightEffect;
				nimbusVariation = defaultClouds.nimbusVariation;
				borderHeight = defaultClouds.borderHeight;
				borderEffect = defaultClouds.borderEffect;
				borderVariation = defaultClouds.borderVariation;
				fogDensity = defaultClouds.fogDensity;
			}
		}

		public override void PropogateVariables()
		{
			base.weatherSphere.cumulus = cumulus;
			base.weatherSphere.cirrus = cirrus;
			base.weatherSphere.altocumulus = altocumulus;
			base.weatherSphere.cirrostratus = cirrostratus;
			base.weatherSphere.chemtrails = chemtrails;
			base.weatherSphere.nimbus = nimbus;
			base.weatherSphere.nimbusHeightEffect = nimbusHeight;
			base.weatherSphere.nimbusVariation = nimbusVariation;
			base.weatherSphere.borderHeight = borderHeight;
			base.weatherSphere.borderEffect = borderEffect;
			base.weatherSphere.borderVariation = borderVariation;
			base.weatherSphere.fogDensity = fogDensity;
			base.weatherSphere.filterSaturation = filterSaturation;
			base.weatherSphere.filterValue = filterValue;
			base.weatherSphere.filterColor = filterColor;
			base.weatherSphere.sunFilter = sunFilter;
			base.weatherSphere.cloudFilter = cloudFilter;
		}

		private void ManageGlobalEcosystem()
		{
			if (base.system == null)
			{
				RunChecks();
			}
			currentWeatherProfiles.Clear();
			if (weight > 0f)
			{
				foreach (WeatherRelation weatherRelation in ecosystem.weightedWeatherProfiles)
				{
					if (weatherRelation.weight == 0f)
					{
						weatherRelation.profile.SetWeatherWeight(0f);
						continue;
					}
					if (currentWeatherProfiles.Find((WeatherRelation x) => x.profile == weatherRelation.profile) != null)
					{
						currentWeatherProfiles.Find((WeatherRelation x) => x.profile == weatherRelation.profile).weight += weatherRelation.weight * weight;
						continue;
					}
					WeatherRelation item = new WeatherRelation
					{
						profile = weatherRelation.profile,
						weight = weatherRelation.weight * weight
					};
					currentWeatherProfiles.Add(item);
				}
			}
			foreach (CozyWeatherModule biome in biomes)
			{
				if (biome == null)
				{
					continue;
				}
				CozyEcosystem cozyEcosystem = biome.Ecosystem;
				if (biome.weight > 0f)
				{
					foreach (WeatherRelation weatherRelation2 in cozyEcosystem.weightedWeatherProfiles)
					{
						if (weatherRelation2.weight == 0f)
						{
							if ((bool)weatherRelation2.profile)
							{
								weatherRelation2.profile.SetWeatherWeight(0f);
							}
						}
						else if (currentWeatherProfiles.Find((WeatherRelation x) => x.profile == weatherRelation2.profile) != null)
						{
							currentWeatherProfiles.Find((WeatherRelation x) => x.profile == weatherRelation2.profile).weight += weatherRelation2.weight * biome.weight;
						}
						else
						{
							WeatherRelation weatherRelation3 = new WeatherRelation();
							weatherRelation3.profile = weatherRelation2.profile;
							weatherRelation3.weight = weatherRelation2.weight * biome.weight;
							currentWeatherProfiles.Add(weatherRelation3);
						}
					}
					continue;
				}
				foreach (WeatherRelation weightedWeatherProfile in cozyEcosystem.weightedWeatherProfiles)
				{
					weightedWeatherProfile.profile.SetWeatherWeight(0f);
				}
			}
		}

		private void UpdateWeatherByWeight()
		{
			ComputeBiomeWeights();
			float num = 0f;
			foreach (WeatherRelation currentWeatherProfile in currentWeatherProfiles)
			{
				num += currentWeatherProfile.weight;
			}
			if (num == 0f)
			{
				num = 1f;
			}
			foreach (WeatherRelation currentWeatherProfile2 in currentWeatherProfiles)
			{
				currentWeatherProfile2.weight /= num;
			}
		}
	}
}
