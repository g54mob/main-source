using LocoSim.Attributes;
using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class AutomaticCoolerDefinition : SimComponentDefinition
	{
		public float coolingRate = 12500f;

		public float activationTemperature = 100f;

		public float deactivationTemperature = 90f;

		public float easeTime = 2f;

		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition isPoweredReader = new PortReferenceDefinition(PortValueType.STATE, "IS_POWERED");

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortReferenceDefinition targetTemperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TARGET_TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public readonly PortDefinition coolingEffectReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "COOLING_EFFECT");

		public override SimComponent InstantiateImplementation()
		{
			return new AutomaticCooler(this);
		}
	}
}
