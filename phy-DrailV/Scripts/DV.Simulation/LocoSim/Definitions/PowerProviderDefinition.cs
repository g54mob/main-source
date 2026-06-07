using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class PowerProviderDefinition : SimComponentDefinition
	{
		public float powerGainRate = 1f;

		public readonly PortReferenceDefinition goalPowerReader = new PortReferenceDefinition(PortValueType.POWER, "GOAL_POWER");

		public readonly PortDefinition powerOut = new PortDefinition(PortType.OUT, PortValueType.POWER, "POWER_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new PowerProvider(this);
		}
	}
}
