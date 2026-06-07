using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class SteamCompressorDefinition : SimComponentDefinition
	{
		public float maxProductionRate = 250f;

		public float maxSteamConsumption = 1f;

		public float pressureForMaxProduction = 3f;

		public float activationPressureThreshold = 7f;

		public float mainReservoirVolume = 15f;

		public float smoothTime = 5f;

		public readonly PortDefinition activationSignalExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "ACTIVATION_SIGNAL_EXT_IN");

		public readonly PortDefinition mainResPressureNormalizedExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.PRESSURE, "MAIN_RES_PRESSURE_NORMALIZED");

		public readonly PortReferenceDefinition compressorControl = new PortReferenceDefinition(PortValueType.CONTROL, "COMPRESSOR_CONTROL");

		public readonly PortDefinition compressorHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "COMPRESSOR_HEALTH_EXT_IN");

		public readonly PortReferenceDefinition steamPressure = new PortReferenceDefinition(PortValueType.PRESSURE, "STEAM_PRESSURE");

		public readonly PortDefinition steamConsumptionReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "STEAM_CONSUMPTION");

		public readonly PortDefinition productionRateReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "PRODUCTION_RATE");

		public readonly PortDefinition productionRateNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "PRODUCTION_RATE_NORMALIZED");

		public readonly PortDefinition mainResVolumeReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "MAIN_RES_VOLUME");

		public readonly PortDefinition activationPressureThresholdReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "ACTIVATION_PRESSURE_THRESHOLD");

		public override SimComponent InstantiateImplementation()
		{
			return new SteamCompressor(this);
		}
	}
}
