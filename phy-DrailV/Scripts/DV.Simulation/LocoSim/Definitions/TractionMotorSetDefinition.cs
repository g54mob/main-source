using System;
using LocoSim.Attributes;
using LocoSim.Implementations;
using LocoSim.Implementations.Wheels;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class TractionMotorSetDefinition : SimComponentDefinition
	{
		[Serializable]
		public class ElectricalConfigurationDefinition
		{
			public float excitationMultiplier;

			public MotorGroupDefinition[] motorGroups;

			public TransitionDefinition forwardTransition;

			public TransitionDefinition backwardTransition;
		}

		[Serializable]
		public class MotorGroupDefinition
		{
			public int[] motorIndexes;
		}

		[Serializable]
		public class TransitionDefinition
		{
			public enum ThresholdType
			{
				TRANSITION_WHEN_ABOVE_THRESHOLD = 0,
				TRANSITION_WHEN_BELOW_THRESHOLD = 1
			}

			public float thresholdValue;

			public ThresholdType thresholdType;

			public bool ConditionMet(float motorRpm)
			{
				float num = Mathf.Abs(motorRpm);
				switch (thresholdType)
				{
				case ThresholdType.TRANSITION_WHEN_ABOVE_THRESHOLD:
					return num > thresholdValue;
				case ThresholdType.TRANSITION_WHEN_BELOW_THRESHOLD:
					return num < thresholdValue;
				default:
					return false;
				}
			}
		}

		[Header("Motor")]
		public float maxMotorRpm;

		public float motorResistance = 0.015f;

		public float motorTorqueFactor = 1f;

		public float externalResistance = 0.01f;

		public float ampsSmoothTime = 0.5f;

		public float ampsSmoothMaxSpeed = 1000f;

		public float maxAmpsPerTm = 1000f;

		public int numberOfTractionMotors = 2;

		[Header("Dynamic Brake")]
		public float dynamicBrakePeakForceRpm = 1300f;

		public float dynamicBrakeGridResistance = 1f;

		public float dynamicBrakeMaxCurrent = 700f;

		public float dynamicBrakeCoolerSmoothTime = 5f;

		[Header("Transition")]
		public int circuitConnectionStages = 1;

		public float circuitConnectionTime = 1f;

		public float circuitConnectionTimeRandomization = 0.1f;

		public float transitionMaxAmps = 10f;

		public ElectricalConfigurationDefinition[] configurations;

		[Header("Damage")]
		public float overheatingTemperatureThreshold = 120f;

		public float overheatingMaxTime = 5f;

		public float overheatingTmKillPercentage = 0.2f;

		public float setTmOnFireOnKillPercentage = 0.3f;

		public float rpmDamagePerSecond = 0.05f;

		public float overspeedDamageFactor = 0.01f;

		public float overheatingDamagePerSecond = 0.1f;

		public float damagePerFuseBlow = 20f;

		public float damagePerTmBlow = 300f;

		public PoweredWheelsManager poweredWheelsManager;

		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition throttleReader = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition reverserReader = new PortReferenceDefinition(PortValueType.CONTROL, "REVERSER");

		public readonly PortReferenceDefinition dynamicBrakeReader = new PortReferenceDefinition(PortValueType.CONTROL, "DYNAMIC_BRAKE");

		public readonly PortReferenceDefinition configurationOverrideReader = new PortReferenceDefinition(PortValueType.CONTROL, "CONFIGURATION_OVERRIDE");

		public readonly PortReferenceDefinition motorRpmReader = new PortReferenceDefinition(PortValueType.RPM, "MOTOR_RPM");

		public readonly PortReferenceDefinition appliedVoltageReader = new PortReferenceDefinition(PortValueType.VOLTS, "APPLIED_VOLTAGE");

		public readonly PortDefinition motorTorqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public readonly PortDefinition effectiveResistanceReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.OHMS, "EFFECTIVE_RESISTANCE");

		public readonly PortDefinition singleMotorEffectiveResistanceReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.OHMS, "SINGLE_MOTOR_EFFECTIVE_RESISTANCE");

		public readonly PortDefinition totalAmpsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.AMPS, "TOTAL_AMPS");

		public readonly PortDefinition ampsPerTMReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.AMPS, "AMPS_PER_TM");

		public readonly PortDefinition maxAmpsPerTMReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.AMPS, "MAX_AMPS_PER_TM");

		public readonly PortDefinition motorRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM_NORMALIZED");

		public readonly PortDefinition tmHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "HEALTH_STATE_EXT_IN");

		public readonly PortDefinition workingTractionMotorsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "WORKING_TRACTION_MOTORS");

		public readonly PortDefinition heatReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public readonly PortReferenceDefinition tmTempReader = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TM_TEMPERATURE");

		public readonly PortReferenceDefinition environmentWaterState = new PortReferenceDefinition(PortValueType.STATE, "ENVIRONMENT_WATER_STATE");

		public readonly PortDefinition contactorChangeReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CONTACTOR_CHANGE");

		public readonly PortDefinition currentLimitRequestReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.AMPS, "CURRENT_LIMIT_REQUEST");

		public readonly PortDefinition dynamicBrakeActiveReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "DYNAMIC_BRAKE_ACTIVE");

		public readonly PortDefinition overheatPowerFuseOffReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "OVERHEAT_POWER_FUSE_OFF");

		public readonly PortDefinition tmsStateReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "TMS_STATE");

		public readonly PortDefinition overspeedSoundReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "OVERSPEED_SOUND");

		public readonly PortDefinition overspeedExplosionTriggerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "OVERSPEED_EXPLOSION_TRIGGER");

		public readonly PortDefinition generatedDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_DAMAGE");

		public readonly PortDefinition fieldFluxReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "FIELD_FLUX");

		public readonly PortDefinition motorVoltsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.VOLTS, "MOTOR_VOLTS");

		public readonly PortDefinition activeConfigReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ACTIVE_CONFIGURATION");

		public readonly PortDefinition pendingConfigReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "PENDING_CONFIGURATION");

		public readonly PortDefinition powerInReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "POWER_IN");

		public readonly PortDefinition powerOutReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "POWER_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new TractionMotorSet(this);
		}
	}
}
