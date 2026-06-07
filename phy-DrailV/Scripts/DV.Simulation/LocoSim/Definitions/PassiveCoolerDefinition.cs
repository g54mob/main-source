using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class PassiveCoolerDefinition : SimComponentDefinition
	{
		public float coolingRate = 12500f;

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortReferenceDefinition targetTemperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TARGET_TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new PassiveCooler(this);
		}
	}
}
