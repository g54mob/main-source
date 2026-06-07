using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class PassiveCooler : SimComponent
	{
		public readonly float coolingRate;

		public readonly PortReference temperature;

		public readonly PortReference targetTemperature;

		public readonly Port heatOut;

		public PassiveCooler(PassiveCoolerDefinition pcDef)
			: base(pcDef.ID)
		{
			coolingRate = pcDef.coolingRate;
			temperature = AddPortReference(pcDef.temperature);
			targetTemperature = AddPortReference(pcDef.targetTemperature, 25f);
			heatOut = AddPort(pcDef.heatOut);
		}

		public override void Tick(float delta)
		{
			float num = targetTemperature.Value - temperature.Value;
			heatOut.Value = num * coolingRate;
		}
	}
}
