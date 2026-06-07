using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class MechanicalCompressorDefinition : SimComponentDefinition
	{
		public float loadTorque = 400f;

		public float maxProductionRate = 250f;

		public float activationPressureThreshold = 7f;

		public float mainReservoirVolume = 15f;

		public float smoothTime = 0.3f;

		public readonly PortDefinition activationSignalExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "ACTIVATION_SIGNAL_EXT_IN");

		public readonly PortDefinition compressorHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "COMPRESSOR_HEALTH_EXT_IN");

		public readonly PortReferenceDefinition engineRpmNormalizedReader = new PortReferenceDefinition(PortValueType.RPM, "ENGINE_RPM_NORMALIZED");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TORQUE, "LOAD_TORQUE");

		public readonly PortDefinition productionRateReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "PRODUCTION_RATE");

		public readonly PortDefinition productionRateNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "PRODUCTION_RATE_NORMALIZED");

		public readonly PortDefinition mainResVolumeReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "MAIN_RES_VOLUME");

		public readonly PortDefinition activationPressureThresholdReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "ACTIVATION_PRESSURE_THRESHOLD");

		public override SimComponent InstantiateImplementation()
		{
			return new MechanicalCompressor(this);
		}
	}
}
