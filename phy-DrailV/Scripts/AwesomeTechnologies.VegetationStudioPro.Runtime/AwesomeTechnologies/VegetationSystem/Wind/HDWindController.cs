using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Wind
{
	public class HDWindController : IWindController
	{
		private WindControllerSettings _windControllerSettings;

		public float WindSpeed = 30f;

		public float Turbulence = 0.25f;

		public Texture2D NoiseTexture;

		public float FlexNoiseWorldSize = 175f;

		public float ShiverNoiseWorldSize = 10f;

		public Texture2D GustMaskTexture;

		public float GustWorldSize = 600f;

		public float GustSpeed = 50f;

		public float GustScale = 1f;

		private readonly int _windSettingsTexNoise;

		private readonly int _windSettingsTexGust;

		private readonly int _windSettingsWorldDirectionAndSpeed;

		private readonly int _windSettingsFlexNoiseScale;

		private readonly int _windSettingsShiverNoiseScale;

		private readonly int _windSettingsTurbulence;

		private readonly int _windSettingsGustSpeed;

		private readonly int _windSettingsGustScale;

		private readonly int _windSettingsGustWorldScale;

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

		public HDWindController()
		{
			WindControlerID = "HDWindController";
			_windSettingsTexNoise = Shader.PropertyToID("WIND_SETTINGS_TexNoise");
			_windSettingsTexGust = Shader.PropertyToID("WIND_SETTINGS_TexGust");
			_windSettingsWorldDirectionAndSpeed = Shader.PropertyToID("WIND_SETTINGS_WorldDirectionAndSpeed");
			_windSettingsFlexNoiseScale = Shader.PropertyToID("WIND_SETTINGS_FlexNoiseScale");
			_windSettingsShiverNoiseScale = Shader.PropertyToID("WIND_SETTINGS_ShiverNoiseScale");
			_windSettingsTurbulence = Shader.PropertyToID("WIND_SETTINGS_Turbulence");
			_windSettingsGustSpeed = Shader.PropertyToID("WIND_SETTINGS_GustSpeed");
			_windSettingsGustScale = Shader.PropertyToID("WIND_SETTINGS_GustScale");
			_windSettingsGustWorldScale = Shader.PropertyToID("WIND_SETTINGS_GustWorldScale");
		}

		public WindControllerSettings CreateDefaultSettings()
		{
			Settings = new WindControllerSettings
			{
				WindControlerID = WindControlerID,
				Heading = "HD Wind Settings"
			};
			Settings.AddFloatProperty("WindSpeed", "Base Wind Speed (km/h)", "", 45f, 0f, 120f);
			Settings.AddFloatProperty("Turbulence", "Turbulence", "", 0.4f, 0f, 2f);
			Settings.AddLabelProperty(" ");
			Settings.AddTextureProperty("3DNoise", "3D Noise", "", Resources.Load("3DNoise") as Texture2D);
			Settings.AddFloatProperty("FlexNoiseWorldSize", "Flex Noise World Size", "", 150f, 0f, 1000f);
			Settings.AddFloatProperty("ShiverNoiseWorldSize", "Shiver Noise World Size", "", 60f, 0f, 300f);
			Settings.AddLabelProperty(" ");
			Settings.AddTextureProperty("GustNoise", "Gust Noise", "", Resources.Load("GustNoise") as Texture2D);
			Settings.AddFloatProperty("GustWorldSize", "Gust World Size", "", 600f, 0f, 2000f);
			Settings.AddFloatProperty("GustSpeed", "Gust Speed", "", 20f, 0f, 100f);
			Settings.AddFloatProperty("GustScale", "Gust Scale", "", 0.35f, 0f, 5f);
			RefreshSettings();
			return Settings;
		}

		public void RefreshSettings()
		{
			WindSpeed = Settings.GetFloatPropertyValue("WindSpeed");
			Turbulence = Settings.GetFloatPropertyValue("Turbulence");
			NoiseTexture = Settings.GetTexturePropertyValue("3DNoise");
			FlexNoiseWorldSize = Settings.GetFloatPropertyValue("FlexNoiseWorldSize");
			ShiverNoiseWorldSize = Settings.GetFloatPropertyValue("ShiverNoiseWorldSize");
			GustMaskTexture = Settings.GetTexturePropertyValue("GustNoise");
			GustWorldSize = Settings.GetFloatPropertyValue("GustWorldSize");
			GustSpeed = Settings.GetFloatPropertyValue("GustSpeed");
			GustScale = Settings.GetFloatPropertyValue("GustScale");
		}

		public void UpdateWind(WindZone windZone, float windSpeedFactor)
		{
			float num = 1f;
			if ((bool)windZone)
			{
				num = windZone.windMain;
			}
			Shader.SetGlobalTexture(_windSettingsTexNoise, NoiseTexture);
			Shader.SetGlobalTexture(_windSettingsTexGust, GustMaskTexture);
			Shader.SetGlobalVector(_windSettingsWorldDirectionAndSpeed, GetDirectionAndSpeed(windZone, windSpeedFactor));
			Shader.SetGlobalFloat(_windSettingsFlexNoiseScale, 1f / Mathf.Max(0.01f, FlexNoiseWorldSize));
			Shader.SetGlobalFloat(_windSettingsShiverNoiseScale, 1f / Mathf.Max(0.01f, ShiverNoiseWorldSize));
			Shader.SetGlobalFloat(_windSettingsTurbulence, WindSpeed * Turbulence * num * windSpeedFactor);
			Shader.SetGlobalFloat(_windSettingsGustSpeed, GustSpeed);
			Shader.SetGlobalFloat(_windSettingsGustScale, GustScale);
			Shader.SetGlobalFloat(_windSettingsGustWorldScale, 1f / Mathf.Max(0.01f, GustWorldSize));
		}

		private Vector4 GetDirectionAndSpeed(WindZone windZone, float windSpeedFactor)
		{
			float num = 1f;
			Vector3 vector;
			if ((bool)windZone)
			{
				vector = windZone.transform.forward.normalized;
				num = windZone.windMain;
			}
			else
			{
				vector = Vector3.forward;
			}
			return new Vector4(vector.x, vector.y, vector.z, WindSpeed * 0.2777f * num * windSpeedFactor);
		}
	}
}
