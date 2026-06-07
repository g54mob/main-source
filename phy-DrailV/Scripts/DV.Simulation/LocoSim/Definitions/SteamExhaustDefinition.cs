using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class SteamExhaustDefinition : SimComponentDefinition
	{
		public float passiveExhaust = 0.6f;

		public float entrainmentRatio = 1.95f;

		[Header("Blower")]
		public float maxBlowerFlow = 0.5f;

		public float pressureForMaxBlowerFlow = 3f;

		[Header("Whistle")]
		public float maxWhistleFlow = 0.2f;

		public readonly PortReferenceDefinition exhaustFlow = new PortReferenceDefinition(PortValueType.MASS_RATE, "EXHAUST_FLOW");

		public readonly PortDefinition steamConsumptionReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "STEAM_CONSUMPTION");

		public readonly PortDefinition airFlowReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "AIR_FLOW");

		public readonly PortDefinition totalFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "TOTAL_FLOW_NORMALIZED");

		public readonly PortDefinition whistleFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "WHISTLE_FLOW_NORMALIZED");

		public readonly PortReferenceDefinition engineMaxFlowReader = new PortReferenceDefinition(PortValueType.MASS_RATE, "ENGINE_MAX_FLOW");

		public readonly PortReferenceDefinition boilerPressure = new PortReferenceDefinition(PortValueType.PRESSURE, "BOILER_PRESSURE");

		public readonly PortReferenceDefinition blowerControl = new PortReferenceDefinition(PortValueType.CONTROL, "BLOWER_CONTROL");

		public readonly PortReferenceDefinition whistleControl = new PortReferenceDefinition(PortValueType.CONTROL, "WHISTLE_CONTROL");

		public readonly PortReferenceDefinition damperControl = new PortReferenceDefinition(PortValueType.CONTROL, "DAMPER_CONTROL");

		public override SimComponent InstantiateImplementation()
		{
			return new SteamExhaust(this);
		}
	}
}
