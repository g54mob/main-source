using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class PowerProvider : SimComponent
	{
		public readonly float powerGainRate;

		public readonly PortReference goalPowerReader;

		public readonly Port powerOut;

		private float power;

		public PowerProvider(PowerProviderDefinition ppDef)
			: base(ppDef.ID)
		{
			powerGainRate = ppDef.powerGainRate;
			goalPowerReader = AddPortReference(ppDef.goalPowerReader);
			powerOut = AddPort(ppDef.powerOut);
		}

		public override void Tick(float delta)
		{
			float num = Mathf.Sign(goalPowerReader.Value - power);
			power += num * powerGainRate * delta;
			powerOut.Value = power;
		}
	}
}
