using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class Adder : SimComponent
	{
		public float addAmount;

		public readonly Port inPort;

		public readonly Port outPort;

		public Adder(string id, float addAmount, PortDefinition inPortDef, PortDefinition outPortDef)
			: base(id)
		{
			this.addAmount = addAmount;
			inPort = AddPort(inPortDef);
			outPort = AddPort(outPortDef);
		}

		public override void Tick(float delta)
		{
			float value = inPort.Value + addAmount * delta;
			outPort.Value = value;
		}
	}
}
