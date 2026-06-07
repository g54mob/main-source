using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class DirectionalMovementCoolerDefinition : SimComponentDefinition
	{
		public float coolingRate = 12500f;

		public float minCoolingSpeed = 2f;

		public float maxCoolingSpeed = 25f;

		public bool coolingInForwardDirection = true;

		public readonly PortReferenceDefinition speedReader = new PortReferenceDefinition(PortValueType.GENERIC, "SPEED");

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortReferenceDefinition targetTemperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TARGET_TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new DirectionalMovementCooler(this);
		}
	}
}
