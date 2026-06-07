using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class TransmissionFixedGearDefinition : SimComponentDefinition
	{
		public float gearRatio = 5.18f;

		public float transmissionEfficiency = 1f;

		public readonly PortDefinition torqueIn = new PortDefinition(PortType.IN, PortValueType.TORQUE, "TORQUE_IN");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public readonly PortDefinition gearRatioReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "GEAR_RATIO");

		public override SimComponent InstantiateImplementation()
		{
			return new TransmissionFixedGear(this);
		}
	}
}
