using LocoSim.Attributes;
using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class DieselEnginePowerSourceDefinition : SimComponentDefinition
	{
		public float engineRpmMax = 1000f;

		public float engineRpmIdle = 120f;

		public float maxPower = 2200000f;

		public float fuelInjection = 5f;

		public float rpmGainFromFuel = 150f;

		public float rpmGainNoLoadMultiplier = 10f;

		public float rpmGainMinLoadMultiplier = 1f;

		public float rpmGainMaxLoadMultiplier = 0.5f;

		public float fuelConsumptionSmoothTime = 0.1f;

		public float oilConsumptionRate = 0.1f;

		public float ignitionTime = 0.5f;

		public float engineDragFalloff = 0.05f;

		public float idleTemperature = 52f;

		public float heatRateFromRpm = 8f;

		public float heatRateBelowIdleFactor = 2f;

		public float overheatingTemperatureThreshold = 120f;

		public float overheatingMaxTime = 12f;

		public float noOilDamagePerSecond = 30f;

		public float rpmDamagePerSecond = 0.05f;

		public float overheatingDamagePerDegreePerSecond = 0.1f;

		public float damagePerIgnition = 10f;

		public float enginePerformanceDropHealthPercentage = 0.2f;

		public float damagedEnginePowerConstraintStart = 1f;

		public float damagedEnginePowerConstraintEnd = 0.2f;

		public float severeDamageEngineOffProbabilityMultiplier = 0.5f;

		[FuseId]
		public string engineStarterFuseId;

		public readonly PortDefinition ignitionExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "IGNITION_EXT_IN");

		public readonly PortDefinition emergencyEngineOffExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "EMERGENCY_ENGINE_OFF_EXT_IN");

		public readonly PortDefinition collisionEngineOffExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "COLLISION_ENGINE_OFF_EXT_IN");

		public readonly PortReferenceDefinition internalEngineOffReader = new PortReferenceDefinition(PortValueType.STATE, "INTERNAL_ENGINE_OFF");

		public readonly PortDefinition engineHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "ENGINE_HEALTH_STATE_EXT_IN");

		public readonly PortReferenceDefinition fuel = new PortReferenceDefinition(PortValueType.FUEL, "FUEL");

		public readonly PortReferenceDefinition fuelConsumption = new PortReferenceDefinition(PortValueType.FUEL, "FUEL_CONSUMPTION", writeAllowed: true);

		public readonly PortDefinition fuelEnvDamage = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.FUEL, "FUEL_ENV_DAMAGE_METER");

		public readonly PortReferenceDefinition oil = new PortReferenceDefinition(PortValueType.OIL, "OIL");

		public readonly PortReferenceDefinition oilConsumption = new PortReferenceDefinition(PortValueType.OIL, "OIL_CONSUMPTION", writeAllowed: true);

		public readonly PortReferenceDefinition goalPowerReader = new PortReferenceDefinition(PortValueType.POWER, "GOAL_POWER");

		public readonly PortReferenceDefinition secondaryGoalPowerReader = new PortReferenceDefinition(PortValueType.POWER, "SEC_GOAL_POWER");

		public readonly PortReferenceDefinition loadOnRotorReader = new PortReferenceDefinition(PortValueType.CONTROL, "LOAD_ON_ROTOR");

		public readonly PortDefinition powerOut = new PortDefinition(PortType.OUT, PortValueType.POWER, "POWER_OUT");

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public readonly PortDefinition engineRpmReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM");

		public readonly PortDefinition engineRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM_NORMALIZED");

		public readonly PortDefinition engineIdleRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "IDLE_RPM_NORMALIZED");

		public readonly PortDefinition engineOnReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ENGINE_ON");

		public readonly PortDefinition ignitionInProgressReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IGNITION_IN_PROGESS");

		public readonly PortDefinition maxPowerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "MAX_POWER");

		public readonly PortDefinition maxRpmReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "MAX_RPM");

		public readonly PortDefinition goalPowerSmoothNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "GOAL_POWER_SMOOTH_NORMALIZED");

		public readonly PortDefinition generatedEngineDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_ENGINE_DAMAGE");

		public readonly PortDefinition fuelConsumptionNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.FUEL, "FUEL_CONSUMPTION_NORMALIZED");

		public override SimComponent InstantiateImplementation()
		{
			return new DieselEnginePowerSource(this);
		}
	}
}
