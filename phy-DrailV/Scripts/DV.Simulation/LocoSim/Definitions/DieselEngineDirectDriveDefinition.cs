using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class DieselEngineDirectDriveDefinition : SimComponentDefinition
	{
		public float engineRpmMax = 6000f;

		public float engineRpmIdle = 1000f;

		public bool neutralAtZeroThrottle = true;

		public AnimationCurve rpmToPowerCurve;

		public float engineDragMaxBrakingTorque = 100000f;

		public float engineDragOverMaxRpmMultiplier = 3f;

		public float retarderBrakingTorque = 5000f;

		public float minRetarderEffectEngineRpm = 2000f;

		public float maxRetarderEffectEngineRpm = 5000f;

		public float driveShaftToEngineRpmSmoothTime = 1f;

		public float engineRpmDropToIdleInNeutralSmoothTime = 1f;

		public float fuelInjection = 5f;

		public float fuelConsumptionSmoothTime = 0.1f;

		public float oilConsumptionRate = 0.1f;

		public float ignitionMaxTime = 3f;

		public float idleTemperature = 52f;

		public float heatRateFromRpm = 8f;

		public float heatRateBelowIdleFactor = 2f;

		public float heatRateAboveMaxRpmFactor = 5f;

		public float heatRateOppositeDirectionEffectFactor = 30f;

		public float heatRateRetarderEffectFactor = 2f;

		public float heatRateFromThrottleStress = 10f;

		public float overheatingThreshold = 120f;

		public float overheatingMaxTime = 12f;

		public float noOilDamagePerSecond = 30f;

		public float rpmDamagePerSecond = 0.05f;

		public float damagePerIgnition = 10f;

		public float overheatingExplosionDamage = 300f;

		public float overheatingDamagePerDegreePerSecond = 0.1f;

		[FuseId]
		public string engineStarterFuseId;

		public readonly PortDefinition ignitionExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "IGNITION_EXT_IN");

		public readonly PortDefinition ignitionInProgressReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IGNITION_IN_PROGESS");

		public readonly PortReferenceDefinition throttleReader = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition reverserReader = new PortReferenceDefinition(PortValueType.CONTROL, "REVERSER");

		public readonly PortReferenceDefinition gearReader = new PortReferenceDefinition(PortValueType.CONTROL, "GEAR");

		public readonly PortReferenceDefinition retarderReader = new PortReferenceDefinition(PortValueType.CONTROL, "RETARDER");

		public readonly PortReferenceDefinition driveShaftRpmReader = new PortReferenceDefinition(PortValueType.RPM, "DRIVE_SHAFT_RPM");

		public readonly PortReferenceDefinition wheelSpeedKmhReader = new PortReferenceDefinition(PortValueType.GENERIC, "WHEEL_SPEED_KMH");

		public readonly PortDefinition emergencyEngineOffExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "EMERGENCY_ENGINE_OFF_EXT_IN");

		public readonly PortDefinition collisionEngineOffExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "COLLISION_ENGINE_OFF_EXT_IN");

		public readonly PortDefinition engineHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "ENGINE_HEALTH_STATE_EXT_IN");

		public readonly PortReferenceDefinition fuel = new PortReferenceDefinition(PortValueType.FUEL, "FUEL");

		public readonly PortReferenceDefinition fuelConsumption = new PortReferenceDefinition(PortValueType.FUEL, "FUEL_CONSUMPTION", writeAllowed: true);

		public readonly PortDefinition fuelEnvDamage = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.FUEL, "FUEL_ENV_DAMAGE_METER");

		public readonly PortReferenceDefinition oil = new PortReferenceDefinition(PortValueType.OIL, "OIL");

		public readonly PortReferenceDefinition oilConsumption = new PortReferenceDefinition(PortValueType.OIL, "OIL_CONSUMPTION", writeAllowed: true);

		public readonly PortDefinition powerOut = new PortDefinition(PortType.OUT, PortValueType.POWER, "POWER_OUT");

		public readonly PortDefinition engineBrakingTorqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "ENGINE_BRAKING_TORQUE_OUT");

		public readonly PortDefinition engineRpmReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM");

		public readonly PortDefinition engineRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM_NORMALIZED");

		public readonly PortDefinition engineIdleRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "IDLE_RPM_NORMALIZED");

		public readonly PortDefinition engineRpmMaxReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM_MAX");

		public readonly PortDefinition engineOnReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ENGINE_ON");

		public readonly PortDefinition inNeutralReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IN_NEUTRAL");

		public readonly PortDefinition throttleStressReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "THROTTLE_STRESS");

		public readonly PortDefinition throttlingInOppositeMovementDirectionReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "THROTTLING_IN_OPPOSITE_MOVEMENT_DIRECTION");

		public readonly PortDefinition transmissionEngagedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "TRANSMISSION_ENGAGED");

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public readonly PortDefinition retarderNormalizedBrakeEffectReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "RETARDER_BRAKE_EFFECT");

		public readonly PortDefinition generatedEngineDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_ENGINE_DAMAGE");

		public readonly PortDefinition fuelConsumptionNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.FUEL, "FUEL_CONSUMPTION_NORMALIZED");

		public readonly PortDefinition isBrokenReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IS_BROKEN");

		public override SimComponent InstantiateImplementation()
		{
			return new DieselEngineDirectDrive(this);
		}
	}
}
