using LocoSim.Attributes;
using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ElectricCompressorDefinition : SimComponentDefinition
	{
		public float maxPower = 45000f;

		public float maxBarLiterProductionRate = 80f;

		public float activationPressureThreshold = 7f;

		public float mainReservoirVolume = 50f;

		public float smoothTime = 0.3f;

		[FuseId]
		public string powerFuseId;

		public readonly PortDefinition activationSignalExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "ACTIVATION_SIGNAL_EXT_IN");

		public readonly PortDefinition compressorHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "COMPRESSOR_HEALTH_EXT_IN");

		public readonly PortReferenceDefinition voltageNormalizedReader = new PortReferenceDefinition(PortValueType.VOLTS, "VOLTAGE_NORMALIZED");

		public readonly PortDefinition powerConsumptionReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "POWER_CONSUMPTION");

		public readonly PortDefinition productionRateReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "PRODUCTION_RATE");

		public readonly PortDefinition productionRateNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "PRODUCTION_RATE_NORMALIZED");

		public readonly PortDefinition mainResVolumeReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "MAIN_RES_VOLUME");

		public readonly PortDefinition activationPressureThresholdReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "ACTIVATION_PRESSURE_THRESHOLD");

		public override SimComponent InstantiateImplementation()
		{
			return new ElectricCompressor(this);
		}
	}
}
