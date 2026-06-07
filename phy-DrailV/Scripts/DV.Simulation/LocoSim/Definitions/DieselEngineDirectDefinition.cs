using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class DieselEngineDirectDefinition : SimComponentDefinition
	{
		[Header("RPM Range")]
		public float rotationalInertia;

		public float viscousDampingFactor;

		public float engineRpmMax;

		public float engineRpmIdle;

		[Header("Power & Torque")]
		public AnimationCurve rpmToPowerCurve;

		public float retarderBrakingTorque;

		[Header("Resource Consumption")]
		public float fuelInjection;

		public float oilConsumptionRate;

		[Header("Damage")]
		public float noOilDamagePerSecond = 30f;

		public float rpmDamagePerSecond = 0.05f;

		public float rpmDamageImmunityTime = 2f;

		public float overheatingThreshold = 110f;

		public float overheatingDamagePerDegreePerSecond = 0.1f;

		[FuseId]
		public string engineStarterFuseId;

		public readonly PortDefinition ignitionExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "IGNITION_EXT_IN");

		public readonly PortDefinition ignitionInProgressReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IGNITION_IN_PROGRESS");

		public readonly PortReferenceDefinition throttleReader = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition retarderReader = new PortReferenceDefinition(PortValueType.CONTROL, "RETARDER");

		public readonly PortDefinition engineRpm = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM");

		public readonly PortReferenceDefinition drivenRpm = new PortReferenceDefinition(PortValueType.RPM, "DRIVEN_RPM");

		public readonly PortReferenceDefinition intakeWaterContent = new PortReferenceDefinition(PortValueType.STATE, "INTAKE_WATER_CONTENT");

		public readonly PortReferenceDefinition fuel = new PortReferenceDefinition(PortValueType.FUEL, "FUEL");

		public readonly PortReferenceDefinition fuelConsumption = new PortReferenceDefinition(PortValueType.FUEL, "FUEL_CONSUMPTION", writeAllowed: true);

		public readonly PortDefinition fuelEnvDamage = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.FUEL, "FUEL_ENV_DAMAGE_METER");

		public readonly PortReferenceDefinition oil = new PortReferenceDefinition(PortValueType.OIL, "OIL");

		public readonly PortReferenceDefinition oilConsumption = new PortReferenceDefinition(PortValueType.OIL, "OIL_CONSUMPTION", writeAllowed: true);

		public readonly PortReferenceDefinition loadTorque = new PortReferenceDefinition(PortValueType.TORQUE, "LOAD_TORQUE");

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public readonly PortDefinition emergencyEngineOffExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "EMERGENCY_ENGINE_OFF_EXT_IN");

		public readonly PortDefinition collisionEngineOffExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "COLLISION_ENGINE_OFF_EXT_IN");

		public readonly PortDefinition engineHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "ENGINE_HEALTH_STATE_EXT_IN");

		public readonly PortDefinition generatedEngineDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_ENGINE_DAMAGE");

		public readonly PortDefinition generatedEnginePercentualDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_ENGINE_PERCENTUAL_DAMAGE");

		public readonly PortDefinition engineOnReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ENGINE_ON");

		public readonly PortDefinition engineRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM_NORMALIZED");

		public readonly PortDefinition engineIdleRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "IDLE_RPM_NORMALIZED");

		public readonly PortDefinition engineIdlePowerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "IDLE_POWER");

		public readonly PortDefinition engineMaxPowerRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "MAX_POWER_RPM_NORMALIZED");

		public readonly PortDefinition engineMaxPowerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "MAX_POWER");

		public readonly PortDefinition engineRpmMaxReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "MAX_RPM");

		public readonly PortDefinition retarderNormalizedBrakeEffectReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "RETARDER_BRAKE_EFFECT");

		public readonly PortDefinition fuelConsumptionNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.FUEL, "FUEL_CONSUMPTION_NORMALIZED");

		public readonly PortDefinition isBrokenReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "IS_BROKEN");

		public override SimComponent InstantiateImplementation()
		{
			return new DieselEngineDirect(this);
		}
	}
}
