using FractureField.Rocks;

namespace FractureField.Drones
{
	public class DroneTargetSettings
	{
		public DroneTargetingMode Mode { get; set; }

		public RockLayerType TargetLayer { get; set; }

		public DroneTargetSettings()
		{
		}

		public DroneTargetSettings(DroneTargetingMode mode, RockLayerType layer)
		{
		}

		public bool IsValidLayer(RockLayerType rockLayer, RockLayerType defaultMaxLayer)
		{
			return false;
		}
	}
}
