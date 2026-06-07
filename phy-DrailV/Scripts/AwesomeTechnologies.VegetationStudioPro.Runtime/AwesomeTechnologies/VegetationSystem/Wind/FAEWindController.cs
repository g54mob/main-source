using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Wind
{
	public class FAEWindController : IWindController
	{
		private WindControllerSettings _windControllerSettings;

		public Texture2D WindVectors;

		public float WindSpeed;

		public float WindStrength;

		public float WindAmplitude;

		public float TrunkWindSpeed;

		public float TrunkWindWeight;

		public float TrunkWindSwinging;

		private readonly int _windVectors;

		private readonly int _windSpeed;

		private readonly int _windStrength;

		private readonly int _windAmplitude;

		private readonly int _windDirection;

		private readonly int _trunkWindSpeed;

		private readonly int _trunkWindWeight;

		private readonly int _trunkWindSwinging;

		public string WindControlerID { get; }

		public WindControllerSettings Settings
		{
			get
			{
				return _windControllerSettings;
			}
			set
			{
				_windControllerSettings = value;
				RefreshSettings();
			}
		}

		public FAEWindController()
		{
			WindControlerID = "FAEWindController";
			_windVectors = Shader.PropertyToID("_WindVectors");
			_windSpeed = Shader.PropertyToID("_WindSpeed");
			_windStrength = Shader.PropertyToID("_WindStrength");
			_windAmplitude = Shader.PropertyToID("_WindAmplitude");
			_windDirection = Shader.PropertyToID("_WindDirection");
			_trunkWindSpeed = Shader.PropertyToID("_TrunkWindSpeed");
			_trunkWindWeight = Shader.PropertyToID("_TrunkWindWeight");
			_trunkWindSwinging = Shader.PropertyToID("_TrunkWindSwinging");
		}

		public WindControllerSettings CreateDefaultSettings()
		{
			Settings = new WindControllerSettings
			{
				WindControlerID = WindControlerID,
				Heading = "Fantasy Adventure Environment Wind Settings"
			};
			Settings.AddTextureProperty("Windvectors", "Windvectors", "", Resources.Load("FAE_Windvectors") as Texture2D);
			Settings.AddFloatProperty("WindSpeed", "Base Wind Speed", "", 0.33f, 0f, 10f);
			Settings.AddFloatProperty("WindStrength", "Wind Strength", "", 1f, 0f, 3f);
			Settings.AddFloatProperty("WindAmplitude", "Wind Amplitude", "", 14f, 0f, 20f);
			Settings.AddLabelProperty(" ");
			Settings.AddFloatProperty("TrunkWindSpeed", "Trunk Wind Speed", "", 10f, 0f, 150f);
			Settings.AddFloatProperty("TrunkWindWeight", "Trunk Wind Weight", "", 4f, 0f, 30f);
			Settings.AddFloatProperty("TrunkWindSwinging", "Trunk Wind Swinging", "", 0.5f, 0f, 0.99f);
			RefreshSettings();
			return Settings;
		}

		public void RefreshSettings()
		{
			WindSpeed = Settings.GetFloatPropertyValue("WindSpeed");
			WindStrength = Settings.GetFloatPropertyValue("WindStrength");
			WindAmplitude = Settings.GetFloatPropertyValue("WindAmplitude");
			TrunkWindSpeed = Settings.GetFloatPropertyValue("TrunkWindSpeed");
			TrunkWindWeight = Settings.GetFloatPropertyValue("TrunkWindWeight");
			TrunkWindSwinging = Settings.GetFloatPropertyValue("TrunkWindSwinging");
			WindVectors = Settings.GetTexturePropertyValue("Windvectors");
		}

		public void UpdateWind(WindZone windZone, float windSpeedFactor)
		{
			Vector3 vector = Vector3.back;
			if ((bool)windZone)
			{
				vector = windZone.transform.rotation * Vector3.back;
				Shader.SetGlobalFloat(_windSpeed, WindSpeed * windZone.windMain * windSpeedFactor);
			}
			else
			{
				Shader.SetGlobalFloat(_windSpeed, WindSpeed * windSpeedFactor);
			}
			Shader.SetGlobalTexture(_windVectors, WindVectors);
			Shader.SetGlobalFloat(_windStrength, WindStrength);
			Shader.SetGlobalFloat(_windAmplitude, WindAmplitude);
			Shader.SetGlobalVector(_windDirection, vector);
			Shader.SetGlobalFloat(_trunkWindSpeed, TrunkWindSpeed);
			Shader.SetGlobalFloat(_trunkWindWeight, TrunkWindWeight);
			Shader.SetGlobalFloat(_trunkWindSwinging, TrunkWindSwinging);
		}
	}
}
