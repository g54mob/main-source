using System.Collections.Generic;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	public class CozySaveLoadModule : CozyModule
	{
		public struct DataSave
		{
			public MeridiemTime currentTime;

			public int day;

			public int year;

			public AmbienceProfile currentAmbience;

			public float ambienceTimer;

			public WeatherProfile currentWeather;

			public float weatherTimer;

			public List<CozyEcosystem.WeatherPattern> forecast;
		}

		private void Awake()
		{
			if (base.enabled)
			{
				InitializeModule();
			}
		}

		public void Save()
		{
			Save(0);
		}

		public void Save(int slot)
		{
			if (base.weatherSphere == null)
			{
				InitializeModule();
			}
			DataSave dataSave = default(DataSave);
			if ((bool)base.weatherSphere.GetModule(out CozyAmbienceModule module))
			{
				dataSave.ambienceTimer = module.ambienceTimer;
				dataSave.currentAmbience = module.currentAmbienceProfile;
			}
			if ((bool)base.weatherSphere.weatherModule)
			{
				dataSave.forecast = base.weatherSphere.weatherModule.ecosystem.currentForecast;
				dataSave.currentWeather = base.weatherSphere.weatherModule.ecosystem.currentWeather;
				dataSave.weatherTimer = base.weatherSphere.weatherModule.ecosystem.weatherTimer;
			}
			if ((bool)base.weatherSphere.timeModule)
			{
				dataSave.currentTime = base.weatherSphere.timeModule.currentTime;
				dataSave.day = base.weatherSphere.timeModule.currentDay;
				dataSave.year = base.weatherSphere.timeModule.currentYear;
			}
			PlayerPrefs.SetString($"CZY_Save_{slot}", JsonUtility.ToJson(dataSave));
			Debug.Log($"Saved COZY instance to slot 0\n{dataSave}");
		}

		public string SaveToExternalJSON()
		{
			DataSave dataSave = default(DataSave);
			if ((bool)base.weatherSphere.GetModule(out CozyAmbienceModule module))
			{
				dataSave.ambienceTimer = module.ambienceTimer;
				dataSave.currentAmbience = module.currentAmbienceProfile;
			}
			if ((bool)base.weatherSphere.weatherModule)
			{
				dataSave.forecast = base.weatherSphere.weatherModule.ecosystem.currentForecast;
				dataSave.currentWeather = base.weatherSphere.weatherModule.ecosystem.currentWeather;
				dataSave.weatherTimer = base.weatherSphere.weatherModule.ecosystem.weatherTimer;
			}
			if ((bool)base.weatherSphere.timeModule)
			{
				dataSave.currentTime = base.weatherSphere.timeModule.currentTime;
				dataSave.day = base.weatherSphere.timeModule.currentDay;
				dataSave.year = base.weatherSphere.timeModule.currentYear;
			}
			Debug.Log("Wrote COZY instance to external JSON");
			return JsonUtility.ToJson(dataSave);
		}

		public void Load()
		{
			Load(0);
		}

		public void Load(int slot)
		{
			if (base.weatherSphere == null)
			{
				InitializeModule();
			}
			DataSave dataSave = JsonUtility.FromJson<DataSave>(PlayerPrefs.GetString("CZY_Save_0"));
			if ((bool)base.weatherSphere.GetModule(out CozyAmbienceModule module))
			{
				module.ambienceTimer = dataSave.ambienceTimer;
				module.currentAmbienceProfile = dataSave.currentAmbience;
			}
			base.weatherSphere.weatherModule.ecosystem.currentForecast = dataSave.forecast;
			base.weatherSphere.weatherModule.ecosystem.currentWeather = dataSave.currentWeather;
			base.weatherSphere.weatherModule.ecosystem.weatherTimer = dataSave.weatherTimer;
			base.weatherSphere.timeModule.currentTime = dataSave.currentTime;
			base.weatherSphere.timeModule.currentDay = dataSave.day;
			base.weatherSphere.timeModule.currentYear = dataSave.year;
			base.weatherSphere.SetupReferences();
			Debug.Log("Loaded COZY save to current instance");
		}

		public void LoadFromExternalJSON(string JSONSave)
		{
			DataSave dataSave = JsonUtility.FromJson<DataSave>(JSONSave);
			JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("CZY_Save_0"), dataSave);
			if ((bool)base.weatherSphere.GetModule(out CozyAmbienceModule module))
			{
				module.ambienceTimer = dataSave.ambienceTimer;
				module.currentAmbienceProfile = dataSave.currentAmbience;
			}
			base.weatherSphere.weatherModule.ecosystem.currentForecast = dataSave.forecast;
			base.weatherSphere.weatherModule.ecosystem.currentWeather = dataSave.currentWeather;
			base.weatherSphere.weatherModule.ecosystem.weatherTimer = dataSave.weatherTimer;
			base.weatherSphere.timeModule.currentTime = dataSave.currentTime;
			base.weatherSphere.timeModule.currentDay = dataSave.day;
			base.weatherSphere.timeModule.currentYear = dataSave.year;
			base.weatherSphere.SetupReferences();
			base.weatherSphere.SetupReferences();
			Debug.Log("Loaded external JSON to current COZY instance");
		}
	}
}
