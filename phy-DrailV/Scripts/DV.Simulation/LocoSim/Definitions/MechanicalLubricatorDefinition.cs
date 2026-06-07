using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class MechanicalLubricatorDefinition : SimComponentDefinition
	{
		public float oilCapacity;

		public float oilLeakageRate;

		public float oilConsumptionPerRev;

		public float refillPerRev;

		public float manualRefillTime = 10f;

		public readonly PortReferenceDefinition oil = new PortReferenceDefinition(PortValueType.OIL, "OIL");

		public readonly PortReferenceDefinition oilConsumption = new PortReferenceDefinition(PortValueType.OIL, "OIL_CONSUMPTION", writeAllowed: true);

		public readonly PortReferenceDefinition manualFillRateNormalized = new PortReferenceDefinition(PortValueType.GENERIC, "MANUAL_FILL_RATE_NORMALIZED");

		public readonly PortReferenceDefinition wheelRpm = new PortReferenceDefinition(PortValueType.RPM, "WHEEL_RPM");

		public readonly PortDefinition lubricationRateNormalized = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "LUBRICATION_RATE_NORMALIZED");

		public readonly PortDefinition lubricationNormalized = new PortDefinition(PortType.READONLY_OUT, PortValueType.OIL, "LUBRICATION_NORMALIZED");

		public readonly PortDefinition lubricationAudioNormalized = new PortDefinition(PortType.READONLY_OUT, PortValueType.OIL, "LUBRICATION_AUDIO_NORMALIZED");

		public readonly PortDefinition mechanicalPowerTrainHealthExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "MECHANICAL_PT_HEALTH_EXT_IN");

		public readonly PortDefinition specialRequestExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "SPECIAL_REQUEST");

		public override SimComponent InstantiateImplementation()
		{
			return new MechanicalLubricator(this);
		}
	}
}
