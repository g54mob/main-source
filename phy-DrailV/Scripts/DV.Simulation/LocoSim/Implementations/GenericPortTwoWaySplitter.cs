using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class GenericPortTwoWaySplitter : SimComponent
	{
		public readonly Port portIn;

		public readonly Port port1Out;

		public readonly Port port2Out;

		public GenericPortTwoWaySplitter(GenericPortTwoWaySplitterDefinition gptwsDef)
			: base(gptwsDef.ID)
		{
			portIn = AddPort(gptwsDef.portIn);
			port1Out = AddPort(gptwsDef.port1Out);
			port2Out = AddPort(gptwsDef.port2Out);
		}

		public override void Tick(float delta)
		{
			float value = portIn.Value;
			port1Out.Value = value;
			port2Out.Value = value;
		}
	}
}
