using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public abstract class PortForwardBaseInDefinition : SimComponentDefinition
	{
		public bool skipOneTickWhenConnected;

		public bool skipPropagationWhenDisconnected;

		protected abstract PortDefinition ForwardIn { get; }

		protected abstract PortDefinition SimOut { get; }

		public override SimComponent InstantiateImplementation()
		{
			return new PortForwardIn(ID, ForwardIn, SimOut, skipOneTickWhenConnected, skipPropagationWhenDisconnected);
		}
	}
}
