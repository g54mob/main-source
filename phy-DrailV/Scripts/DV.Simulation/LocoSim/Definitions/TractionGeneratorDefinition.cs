using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class TractionGeneratorDefinition : SimComponentDefinition
	{
		[Header("Generator")]
		public float maxVoltage = 1000f;

		public float torqueFactor = 1f;

		public float maxAmps = 4000f;

		[Header("Throttle Control")]
		public float throttleProportionalGain;

		public float throttleDifferentialGain;

		public float throttleIntegralGain;

		public float throttleIntegralMin;

		public float throttleIntegralMax;

		public float throttleMaxSpeed = 1f;

		public float excitationGainMaxSpeed = 1f;

		public float excitationDropMaxSpeed = 1f;

		[Header("Dynamic Brake")]
		public float dynamicBrakeGoalRpmNormalized = 0.5f;

		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition goalPowerReader = new PortReferenceDefinition(PortValueType.POWER, "GOAL_POWER");

		public readonly PortReferenceDefinition goalRpmNormalizedReader = new PortReferenceDefinition(PortValueType.RPM, "GOAL_RPM_NORMALIZED");

		public readonly PortReferenceDefinition dynamicBrakeReader = new PortReferenceDefinition(PortValueType.CONTROL, "DYNAMIC_BRAKE");

		public readonly PortReferenceDefinition rpmReader = new PortReferenceDefinition(PortValueType.RPM, "RPM");

		public readonly PortReferenceDefinition rpmNormalizedReader = new PortReferenceDefinition(PortValueType.RPM, "RPM_NORMALIZED");

		public readonly PortDefinition throttleReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "THROTTLE");

		public readonly PortDefinition loadTorqueReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TORQUE, "LOAD_TORQUE");

		public readonly PortDefinition voltageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.VOLTS, "VOLTAGE");

		public readonly PortReferenceDefinition totalAmpsReader = new PortReferenceDefinition(PortValueType.AMPS, "TOTAL_AMPS");

		public readonly PortReferenceDefinition effectiveResistanceReader = new PortReferenceDefinition(PortValueType.OHMS, "EFFECTIVE_RESISTANCE");

		public readonly PortReferenceDefinition singleMotorEffectiveResistanceReader = new PortReferenceDefinition(PortValueType.OHMS, "SINGLE_MOTOR_EFFECTIVE_RESISTANCE");

		public readonly PortReferenceDefinition transitionCurrentLimitReader = new PortReferenceDefinition(PortValueType.AMPS, "TRANSITION_CURRENT_LIMIT");

		public readonly PortDefinition externalCurrentLimitExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.AMPS, "EXTERNAL_CURRENT_LIMIT_EXT_IN");

		public readonly PortDefinition externalCurrentLimitActiveReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "EXTERNAL_CURRENT_LIMIT_ACTIVE");

		public readonly PortDefinition overcurrentPowerFuseOffReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "OVERCURRENT_POWER_FUSE_OFF");

		public readonly PortDefinition generatorExcitationReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "EXCITATION");

		public readonly PortDefinition powerInReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "POWER_IN");

		public readonly PortDefinition powerOutReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "POWER_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new TractionGenerator(this);
		}
	}
}
