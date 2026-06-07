using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class SlugsPowerCalculatorDefinition : SimComponentDefinition
	{
		public readonly PortReferenceDefinition internalEffectiveResistanceReader = new PortReferenceDefinition(PortValueType.OHMS, "INTERNAL_EFFECTIVE_RESISTANCE");

		public readonly PortDefinition externalEffectiveResistanceExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.OHMS, "EXTERNAL_EFFECTIVE_RESISTANCE_EXT_IN");

		public readonly PortReferenceDefinition internalAmpsResistanceReader = new PortReferenceDefinition(PortValueType.AMPS, "INTERNAL_AMPS");

		public readonly PortDefinition externalAmpsExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.AMPS, "EXTERNAL_AMPS_EXT_IN");

		public readonly PortDefinition effectiveResistanceReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.OHMS, "EFFECTIVE_RESISTANCE");

		public readonly PortDefinition totalAmpsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.AMPS, "TOTAL_AMPS");

		public override SimComponent InstantiateImplementation()
		{
			return new SlugsPowerCalculator(this);
		}
	}
}
