using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public abstract class PortForwardBaseOutDefinition : SimComponentDefinition
	{
		protected abstract PortDefinition SimIn { get; }

		protected abstract PortDefinition ForwardOut { get; }

		public override SimComponent InstantiateImplementation()
		{
			return new PortForwardOut(ID, SimIn, ForwardOut);
		}
	}
}
