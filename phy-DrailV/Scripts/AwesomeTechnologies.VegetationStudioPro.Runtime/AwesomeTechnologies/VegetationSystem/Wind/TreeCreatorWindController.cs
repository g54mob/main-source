using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Wind
{
	public class TreeCreatorWindController : IWindController
	{
		private WindControllerSettings _windControllerSettings;

		private int _wind;

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

		public TreeCreatorWindController()
		{
			WindControlerID = "TreeCreatorWindController";
			_wind = Shader.PropertyToID("_Wind");
		}

		public WindControllerSettings CreateDefaultSettings()
		{
			Settings = new WindControllerSettings
			{
				WindControlerID = WindControlerID,
				Heading = "Tree creator wind"
			};
			return Settings;
		}

		public void RefreshSettings()
		{
		}

		public void UpdateWind(WindZone windZone, float windSpeedFactor)
		{
			Vector3 forward = Vector3.forward;
			Vector4 value;
			if ((bool)windZone)
			{
				forward = windZone.transform.forward;
				value = new Vector4(forward.x, forward.y, forward.z, Mathf.Abs(windZone.windMain) * windSpeedFactor);
			}
			else
			{
				value = new Vector4(forward.x, forward.y, forward.z, windSpeedFactor);
			}
			Shader.SetGlobalVector(_wind, value);
		}
	}
}
