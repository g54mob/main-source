using LocoSim.Attributes;
using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class BatteryDefinition : SimComponentDefinition
	{
		public enum BatteryChemistry
		{
			Unknown = 0,
			LeadAcid = 1
		}

		public readonly BatteryChemistry chemistry = BatteryChemistry.LeadAcid;

		public int numSeriesCells = 36;

		public float internalResistance = 0.005f;

		public float baseConsumptionMultiplier = 4f;

		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition chargeNormalized = new PortReferenceDefinition(PortValueType.ELECTRIC_CHARGE, "NORMALIZED_CHARGE");

		public readonly PortReferenceDefinition chargeConsumption = new PortReferenceDefinition(PortValueType.ELECTRIC_CHARGE, "CHARGE_CONSUMPTION", writeAllowed: true);

		public readonly PortDefinition voltageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.VOLTS, "VOLTAGE");

		public readonly PortDefinition voltageNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.VOLTS, "VOLTAGE_NORMALIZED");

		public readonly PortReferenceDefinition powerReader = new PortReferenceDefinition(PortValueType.POWER, "POWER");

		public override SimComponent InstantiateImplementation()
		{
			return new Battery(this);
		}
	}
}
