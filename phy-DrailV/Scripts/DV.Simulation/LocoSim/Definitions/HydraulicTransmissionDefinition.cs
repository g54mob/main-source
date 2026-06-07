using System;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class HydraulicTransmissionDefinition : SimComponentDefinition
	{
		[Serializable]
		public class HydraulicConfigDefinition
		{
			public float torqueCapacity;

			[Header("Max torque multiplier, applies at 0 speed ratio.")]
			public float stallTorqueMultiplier;

			[Header("Speed ratio where torque multiplier drops to 1.")]
			public float couplingSpeedRatio;

			[Header("Maximum achieved thermal efficiency. Must be >= couplingSpeedRatio and <= 1.")]
			public float maxEfficiency;

			public bool hasStatorUnlock;

			public float gearRatio;

			public float upshiftThreshold;

			public float downshiftThreshold;
		}

		[Header("Torque Transmission")]
		public bool hasFreewheel;

		public float outputTorqueLimit;

		public HydraulicConfigDefinition[] configs;

		[Header("Hydrodynamic Brake")]
		public float hydroDynamicBrakeTorqueCapacity;

		[Header("Transitions")]
		public AnimationCurve pumpRpmFillCurve = AnimationCurve.EaseInOut(200f, 0f, 400f, 1f);

		public bool fillCouplingAtIdle;

		public float couplingFillTime = 1f;

		[Header("Damage")]
		public float overheatingThreshold = 120f;

		public float overheatingMaxTime = 12f;

		public float overheatingDamagePerDegreePerSecond = 0.1f;

		public float overheatingExplosionDamage = 300f;

		public readonly PortReferenceDefinition throttleControl = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition hydroDynamicBrakeControl = new PortReferenceDefinition(PortValueType.CONTROL, "HYDRODYNAMIC_BRAKE");

		public readonly PortReferenceDefinition reverserControl = new PortReferenceDefinition(PortValueType.CONTROL, "REVERSER");

		public readonly PortReferenceDefinition inputShaftRpm = new PortReferenceDefinition(PortValueType.RPM, "INPUT_SHAFT_RPM");

		public readonly PortReferenceDefinition maxRpmReader = new PortReferenceDefinition(PortValueType.RPM, "MAX_RPM");

		public readonly PortReferenceDefinition outputShaftRpm = new PortReferenceDefinition(PortValueType.RPM, "OUTPUT_SHAFT_RPM");

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public readonly PortDefinition inputShaftTorque = new PortDefinition(PortType.READONLY_OUT, PortValueType.TORQUE, "INPUT_SHAFT_TORQUE");

		public readonly PortDefinition outputShaftTorque = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "OUTPUT_SHAFT_TORQUE");

		public readonly PortDefinition hydroDynamicBrakeEffectReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "HYDRO_DYNAMIC_BRAKE_EFFECT");

		public readonly PortDefinition gearRatioReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "GEAR_RATIO");

		public readonly PortDefinition pumpTorqueNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TORQUE, "PUMP_TORQUE_NORMALIZED");

		public readonly PortDefinition transmissionEngagedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "TRANSMISSION_ENGAGED");

		public readonly PortDefinition turbineRpmReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "TURBINE_RPM");

		public readonly PortDefinition turbineRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "TURBINE_RPM_NORMALIZED");

		public readonly PortDefinition mechanicalPowerTrainHealthExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "MECHANICAL_PT_HEALTH_EXT_IN");

		public readonly PortDefinition generatedDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_DAMAGE");

		public readonly PortDefinition isBrokenReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IS_BROKEN");

		public readonly PortDefinition activeConfigReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ACTIVE_CONFIGURATION");

		public readonly PortDefinition speedRatioReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "SPEED_RATIO");

		public readonly PortDefinition inputPowerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "INPUT_SHAFT_POWER");

		public readonly PortDefinition outputPowerReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "OUTPUT_SHAFT_POWER");

		public readonly PortDefinition efficiencyReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "EFFICIENCY");

		public override SimComponent InstantiateImplementation()
		{
			return new HydraulicTransmission(this);
		}
	}
}
