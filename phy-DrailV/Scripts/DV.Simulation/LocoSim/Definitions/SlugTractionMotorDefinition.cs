using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class SlugTractionMotorDefinition : SimComponentDefinition
	{
		public int numberOfTractionMotors = 4;

		public float maxRpm = 650f;

		public readonly PortReferenceDefinition wheelRpmReader = new PortReferenceDefinition(PortValueType.RPM, "WHEEL_RPM");

		public readonly PortReferenceDefinition gearRatioReader = new PortReferenceDefinition(PortValueType.GENERIC, "GEAR_RATIO");

		public readonly PortDefinition torqueInverterExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "TORQUE_INVERTER_EXT_IN");

		public readonly PortDefinition torqueExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.TORQUE, "TORQUE_EXT_IN");

		public readonly PortDefinition ampsExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.AMPS, "AMPS_EXT_IN");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public readonly PortDefinition dynamicBrakeEffectExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "DYNAMIC_BRAKE_EFFECT");

		public readonly PortDefinition tmRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM_NORMALIZED");

		public readonly PortDefinition numOfTractionMotorsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "TM_NUM");

		public override SimComponent InstantiateImplementation()
		{
			return new SlugTractionMotor(this);
		}
	}
}
