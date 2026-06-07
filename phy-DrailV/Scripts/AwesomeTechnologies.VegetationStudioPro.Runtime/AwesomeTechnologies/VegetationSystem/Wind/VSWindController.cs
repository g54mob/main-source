using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Wind
{
	public class VSWindController : IWindController
	{
		private WindControllerSettings _windControllerSettings;

		public Texture2D WindWaveTexture;

		public float WindWaveSize;

		public float WindSpeed;

		private readonly int _awDir;

		private readonly int _awWavesTex;

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

		public VSWindController()
		{
			WindControlerID = "VSWindController";
			_awDir = Shader.PropertyToID("_AW_DIR");
			_awWavesTex = Shader.PropertyToID("_AW_WavesTex");
		}

		public WindControllerSettings CreateDefaultSettings()
		{
			Settings = new WindControllerSettings
			{
				WindControlerID = WindControlerID,
				Heading = "Vegetation Studio Grass Wind Settings"
			};
			Settings.AddTextureProperty("AW_WavesTex", "Wind Waves", "", Resources.Load("PerlinSeamless") as Texture2D);
			Settings.AddFloatProperty("WindWaveSize", "Wind Wave Size", "", 10f, 0f, 30f);
			Settings.AddFloatProperty("WindSpeed", "Wind Speed", "", 1f, 0f, 3f);
			RefreshSettings();
			return Settings;
		}

		public void RefreshSettings()
		{
			WindSpeed = Settings.GetFloatPropertyValue("WindSpeed");
			WindWaveSize = Settings.GetFloatPropertyValue("WindWaveSize");
			WindWaveTexture = Settings.GetTexturePropertyValue("AW_WavesTex");
		}

		public void UpdateWind(WindZone windZone, float windSpeedFactor)
		{
			Vector3 forward = Vector3.forward;
			Vector4 value;
			if ((bool)windZone)
			{
				forward = windZone.transform.forward;
				value = new Vector4(forward.x, Mathf.Abs(windZone.windMain) * WindSpeed * windSpeedFactor, forward.z, WindWaveSize);
			}
			else
			{
				value = new Vector4(forward.x, 1f * WindSpeed * windSpeedFactor, forward.z, WindWaveSize);
			}
			Shader.SetGlobalVector(_awDir, value);
			if ((bool)WindWaveTexture)
			{
				Shader.SetGlobalTexture(_awWavesTex, WindWaveTexture);
			}
		}
	}
}
