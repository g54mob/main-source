using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ThrottleGammaPowerConversionDefinition : SimComponentDefinition
	{
		public int numberOfNotches = 8;

		public float gamma = 1.2f;

		public readonly PortReferenceDefinition throttleReader = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition idleRpmNormalizedReader = new PortReferenceDefinition(PortValueType.RPM, "IDLE_RPM_NORMALIZED");

		public readonly PortReferenceDefinition maxPowerRpmNormalizedReader = new PortReferenceDefinition(PortValueType.RPM, "MAX_POWER_RPM_NORMALIZED");

		public readonly PortReferenceDefinition maxPowerReader = new PortReferenceDefinition(PortValueType.POWER, "MAX_POWER");

		public readonly PortDefinition goalPowerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "GOAL_POWER");

		public readonly PortDefinition goalRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "GOAL_RPM_NORMALIZED");

		public readonly PortDefinition notchReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "NOTCH");

		public override SimComponent InstantiateImplementation()
		{
			return new ThrottleGammaPowerConversion(this);
		}
	}
}
