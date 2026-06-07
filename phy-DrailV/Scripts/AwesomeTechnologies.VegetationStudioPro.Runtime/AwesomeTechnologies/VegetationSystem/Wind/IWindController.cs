using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Wind
{
	public interface IWindController
	{
		string WindControlerID { get; }

		WindControllerSettings Settings { get; set; }

		WindControllerSettings CreateDefaultSettings();

		void RefreshSettings();

		void UpdateWind(WindZone windZone, float windSpeedFactor);
	}
}
