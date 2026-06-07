using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class HeatReservoirDefinition : SimComponentDefinition
	{
		public float heatCapacity = 1f;

		public float overheatingTemperatureThreshold = 120f;

		public float maxTemperature = 300f;

		public readonly PortDefinition temperature = new PortDefinition(PortType.READONLY_OUT, PortValueType.TEMPERATURE, "TEMPERATURE");

		public PortReferenceDefinition[] inputs;

		public override SimComponent InstantiateImplementation()
		{
			return new HeatReservoir(this);
		}
	}
}
