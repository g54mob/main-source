using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class DirectDriveMechanismDefinition : SimComponentDefinition
	{
		public readonly PortReferenceDefinition throttleReader = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition throttlingInOppositeMovementDirectionReader = new PortReferenceDefinition(PortValueType.STATE, "THROTTLING_IN_OPPOSITE_MOVEMENT_DIRECTION");

		public readonly PortReferenceDefinition reverserReader = new PortReferenceDefinition(PortValueType.CONTROL, "REVERSER");

		public readonly PortReferenceDefinition engineRpmReader = new PortReferenceDefinition(PortValueType.RPM, "ENGINE_RPM");

		public readonly PortReferenceDefinition engineInNeutralReader = new PortReferenceDefinition(PortValueType.STATE, "ENGINE_IN_NEUTRAL");

		public readonly PortDefinition powerIn = new PortDefinition(PortType.IN, PortValueType.POWER, "POWER_IN");

		public readonly PortDefinition engineBrakingTorqueIn = new PortDefinition(PortType.IN, PortValueType.TORQUE, "ENGINE_BRAKING_TORQUE_IN");

		public readonly PortDefinition engineBrakingActiveReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ENGINE_BRAKING_ACTIVE");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new DirectDriveMechanism(this);
		}
	}
}
