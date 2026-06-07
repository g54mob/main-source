using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Wind
{
	public class CTIWindController : IWindController
	{
		private WindControllerSettings _windControllerSettings;

		public float WindSpeed;

		private readonly int _terrainLODWind = Shader.PropertyToID("_TerrainLODWind");

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

		public CTIWindController()
		{
			WindControlerID = "CTIWindController";
		}

		public WindControllerSettings CreateDefaultSettings()
		{
			Settings = new WindControllerSettings
			{
				WindControlerID = WindControlerID,
				Heading = "CTI Wind Settings"
			};
			Settings.AddFloatProperty("WindSpeed", "Wind Speed", "", 1f, 0f, 3f);
			RefreshSettings();
			return Settings;
		}

		public void RefreshSettings()
		{
			WindSpeed = Settings.GetFloatPropertyValue("WindSpeed");
		}

		public void UpdateWind(WindZone windZone, float windSpeedFactor)
		{
			Vector3 forward;
			float w;
			float num;
			if ((bool)windZone)
			{
				forward = windZone.transform.forward;
				num = windZone.windMain * windSpeedFactor * WindSpeed;
				num += windZone.windPulseMagnitude * (1f + Mathf.Sin(Time.time * windZone.windPulseFrequency) + 1f + Mathf.Sin(Time.time * windZone.windPulseFrequency * 3f)) * 0.5f;
				w = windZone.windTurbulence * windZone.windMain * windSpeedFactor * WindSpeed;
			}
			else
			{
				forward = Vector3.forward;
				num = 1f * windSpeedFactor * WindSpeed;
				num += 1f * (1f + Mathf.Sin(Time.time) + 1f + Mathf.Sin(Time.time * 3f)) * 0.5f;
				w = windSpeedFactor * WindSpeed;
			}
			forward.x *= num;
			forward.y *= num;
			forward.z *= num;
			Shader.SetGlobalVector(_terrainLODWind, new Vector4(forward.x, forward.y, forward.z, w));
		}
	}
}
