using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class DynamoDefinition : SimComponentDefinition
	{
		public float minOperatingPressure = 2f;

		public float steamConsumption = 0.1f;

		public float smoothTime = 2f;

		public readonly PortReferenceDefinition dynamoControl = new PortReferenceDefinition(PortValueType.CONTROL, "CONTROL");

		public readonly PortReferenceDefinition steamPressure = new PortReferenceDefinition(PortValueType.PRESSURE, "STEAM_PRESSURE");

		public readonly PortDefinition steamConsumptionReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "STEAM_CONSUMPTION");

		public readonly PortDefinition dynamoFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "DYNAMO_FLOW_NORMALIZED");

		public override SimComponent InstantiateImplementation()
		{
			return new Dynamo(this);
		}
	}
}
