using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class SteamBellDefinition : SimComponentDefinition
	{
		public float steamConsumption = 0.1f;

		public float minOperatingPressure = 2f;

		public float smoothDownTime = 2f;

		public readonly PortReferenceDefinition bellControl = new PortReferenceDefinition(PortValueType.CONTROL, "CONTROL");

		public readonly PortReferenceDefinition steamPressure = new PortReferenceDefinition(PortValueType.PRESSURE, "STEAM_PRESSURE");

		public readonly PortDefinition steamConsumptionReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "STEAM_CONSUMPTION");

		public readonly PortDefinition bellNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "BELL_NORMALIZED");

		public override SimComponent InstantiateImplementation()
		{
			return new SteamBell(this);
		}
	}
}
