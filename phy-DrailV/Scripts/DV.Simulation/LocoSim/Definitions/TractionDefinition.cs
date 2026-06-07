using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class TractionDefinition : SimComponentDefinition
	{
		public readonly PortDefinition torqueIn = new PortDefinition(PortType.IN, PortValueType.TORQUE, "TORQUE_IN");

		public readonly PortDefinition forwardSpeedExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.GENERIC, "FORWARD_SPEED_EXT_IN");

		public readonly PortDefinition wheelRpmExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.RPM, "WHEEL_RPM_EXT_IN");

		public readonly PortDefinition wheelSpeedKmhExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.GENERIC, "WHEEL_SPEED_KMH_EXT_IN");

		public override SimComponent InstantiateImplementation()
		{
			return new Traction(this);
		}
	}
}
