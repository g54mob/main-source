using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ThrottleCustomPowerConversionDefinition : SimComponentDefinition
	{
		public float[] notchPowerPercentages;

		public readonly PortReferenceDefinition throttleReader = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition maxPowerReader = new PortReferenceDefinition(PortValueType.POWER, "MAX_POWER");

		public readonly PortDefinition goalPowerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "GOAL_POWER");

		public readonly PortDefinition notchReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "NOTCH");

		public readonly PortDefinition prevNotchReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "PREV_NOTCH");

		public override SimComponent InstantiateImplementation()
		{
			return new ThrottleCustomPowerConversion(this);
		}
	}
}
