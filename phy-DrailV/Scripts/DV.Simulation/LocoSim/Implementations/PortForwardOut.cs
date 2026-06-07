using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class PortForwardOut : SimComponent
	{
		public readonly Port simIn;

		public readonly Port forwardOut;

		public PortForwardOut(string id, PortDefinition simInDef, PortDefinition forwardOutDef)
			: base(id)
		{
			simIn = AddPort(simInDef);
			forwardOut = AddPort(forwardOutDef);
		}

		public override void Tick(float delta)
		{
			forwardOut.Value = simIn.Value;
		}
	}
}
