using Reactivity;

namespace FractureField.Drones
{
	public class DroneRuleSettings
	{
		public DroneType Type { get; set; }

		public RBool IsEnabled { get; set; }

		public float TargetPercent { get; set; }

		public int MaxQuantity { get; set; }

		public RInt Priority { get; set; }

		public DroneTargetSettings TargetSettings { get; set; }
	}
}
