using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class AdderDefinition : SimComponentDefinition
	{
		public float addAmount;

		public readonly PortDefinition genericInPort1 = new PortDefinition(PortType.IN, PortValueType.GENERIC, "IN_GENERIC_1");

		public readonly PortDefinition genericOutPort1 = new PortDefinition(PortType.OUT, PortValueType.GENERIC, "OUT_GENERIC_1");

		public override SimComponent InstantiateImplementation()
		{
			return new Adder(ID, addAmount, genericInPort1, genericOutPort1);
		}
	}
}
