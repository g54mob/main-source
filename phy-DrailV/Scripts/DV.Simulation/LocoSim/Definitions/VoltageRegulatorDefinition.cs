using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class VoltageRegulatorDefinition : SimComponentDefinition
	{
		public readonly PortReferenceDefinition throttleReader = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition supplyVoltage = new PortReferenceDefinition(PortValueType.VOLTS, "SUPPLY_VOLTAGE");

		public readonly PortDefinition voltageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.VOLTS, "OUTPUT_VOLTAGE");

		public readonly PortReferenceDefinition singleMotorEffectiveResistanceReader = new PortReferenceDefinition(PortValueType.OHMS, "SINGLE_MOTOR_EFFECTIVE_RESISTANCE");

		public readonly PortDefinition externalCurrentLimitExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.AMPS, "EXTERNAL_CURRENT_LIMIT_EXT_IN");

		public readonly PortDefinition externalCurrentLimitActiveReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "EXTERNAL_CURRENT_LIMIT_ACTIVE");

		public override SimComponent InstantiateImplementation()
		{
			return new VoltageRegulator(this);
		}
	}
}
