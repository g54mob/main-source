using System;
using LocoSim.Attributes;
using LocoSim.Implementations;
using LocoSim.Implementations.Wheels;

namespace LocoSim.Definitions
{
	public class TractionMotorDefinition : SimComponentDefinition
	{
		[Serializable]
		public class ContactorTransition
		{
			public float transitionSwitchTmRpm;

			public float transitionDuration;

			public bool connectedToGen;
		}

		public float maxGeneratorVoltage = 1200f;

		public float maxRpm = 650f;

		public int numberOfTractionMotors = 4;

		public float maxAmpsPerTractionMotor = 2000f;

		public float torqueLimitRpmPercentage = 0.1f;

		public float torqueFactor = 2f;

		public float oppositeDirectionTorquePercentage = 1f;

		public float dynamicBrakeMaxPowerPerTractionMotor = 275000f;

		public float dynamicBrakeVoltage = 600f;

		public float dynamicBrakeTorqueFactor = 1f;

		public float dynamicBrakeThrottlePercentage;

		public float dynamicBrakeMinEffectRpmPercentage = 0.06f;

		public float dynamicBrakeMaxEffectRpmPercentage = 0.8f;

		public float contactor0To1SwitchDuration = 1f;

		public float contactor1To0DelayTime;

		public ContactorTransition[] contactorTransitions;

		public float heatRateFromAmps = 8f;

		public float heatRateOverMaxAmpsFactor = 2f;

		public float heatRateDynamicBrakeFactor = 5f;

		public float heatRateOppositeDirectionSpeedFactor = 5f;

		public float overheatingTemperatureThreshold = 120f;

		public float overheatingMaxTime = 5f;

		public float overheatingTmKillPercentage = 0.2f;

		public float setTmOnFireOnKillPercentage = 0.3f;

		public float damagePerRpmOverMaxPerSecond = 0.1f;

		public float rpmDamagePerSecond = 0.05f;

		public float overheatingDamagePerDegreePerSecond = 0.1f;

		public float damagePerFuseBlow = 20f;

		public float damagePerTmBlow = 300f;

		public float tmPerformanceDropHealthPercentage = 0.2f;

		public float damagedTmTorqueConstraintStart = 1f;

		public float damagedTmTorqueConstraintEnd = 0.5f;

		public PoweredWheelsManager poweredWheelsManager;

		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition throttlePowerReader = new PortReferenceDefinition(PortValueType.POWER, "THROTTLE_POWER");

		public readonly PortReferenceDefinition throttleNotchReader = new PortReferenceDefinition(PortValueType.GENERIC, "THROTTLE_NOTCH");

		public readonly PortReferenceDefinition throttlePrevNotchReader = new PortReferenceDefinition(PortValueType.GENERIC, "THROTTLE_PREV_NOTCH");

		public readonly PortReferenceDefinition reverserReader = new PortReferenceDefinition(PortValueType.CONTROL, "REVERSER");

		public readonly PortReferenceDefinition dynamicBrakeReader = new PortReferenceDefinition(PortValueType.CONTROL, "DYNAMIC_BRAKE");

		public readonly PortReferenceDefinition wheelRpmReader = new PortReferenceDefinition(PortValueType.RPM, "WHEEL_RPM");

		public readonly PortReferenceDefinition gearRatioReader = new PortReferenceDefinition(PortValueType.GENERIC, "GEAR_RATIO");

		public readonly PortReferenceDefinition maxPowerProvidedReader = new PortReferenceDefinition(PortValueType.POWER, "MAX_POWER_PROVIDED");

		public readonly PortDefinition tmHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "HEALTH_STATE_EXT_IN");

		public readonly PortDefinition workingTractionMotorsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "WORKING_TRACTION_MOTORS");

		public readonly PortDefinition powerIn = new PortDefinition(PortType.IN, PortValueType.POWER, "POWER_IN");

		public readonly PortDefinition goalPowerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "GOAL_POWER");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public readonly PortDefinition ampsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.AMPS, "AMPS");

		public readonly PortDefinition ampsNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.AMPS, "AMPS_NORMALIZED");

		public readonly PortDefinition maxAmpsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.AMPS, "MAX_AMPS");

		public readonly PortDefinition generatorVoltageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.VOLTS, "GENERATOR_VOLTAGE");

		public readonly PortDefinition tmRpmReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM");

		public readonly PortDefinition tmRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "RPM_NORMALIZED");

		public readonly PortDefinition dynamicBrakeNormalizedEffectReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "DYNAMIC_BRAKE_EFFECT");

		public readonly PortDefinition loadOnGeneratorReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "LOAD_ON_GENERATOR");

		public readonly PortDefinition contactor0To1ReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CONTACTOR_0_TO_1");

		public readonly PortDefinition contactor1To0ReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CONTACTOR_1_TO_0");

		public readonly PortDefinition contactorTransitionReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CONTACTOR_TRANSITION");

		public readonly PortDefinition overheatPowerFuseOffReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "OVERHEAT_POWER_FUSE_OFF");

		public readonly PortDefinition tmsStateReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "TMS_STATE");

		public readonly PortDefinition generatedEngineDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_ENGINE_DAMAGE");

		public readonly PortDefinition externalTractionMotorsExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.GENERIC, "EXTERNAL_TMS_NUM_EXT_IN");

		public readonly PortDefinition externalTractionMotorsTorqueReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TORQUE, "EXTERNAL_TMS_TORQUE");

		public override SimComponent InstantiateImplementation()
		{
			return new TractionMotor(this);
		}
	}
}
