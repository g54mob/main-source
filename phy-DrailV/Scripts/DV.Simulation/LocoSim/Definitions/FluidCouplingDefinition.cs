using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class FluidCouplingDefinition : SimComponentDefinition
	{
		public float pumpRpmTorqueStartThreshold;

		public AnimationCurve turbineToPumpRelativeSpeedToTorqueMultiplier;

		public float maxSlipEffectRpmDifference = 500f;

		public float oppositeDirectionTorquePercentage = 0.5f;

		public float minTurbineRpmHydroDynamicBrake = 200f;

		public float maxTurbineRpmHydroDynamicBrake = 800f;

		public float hydroDynamicBrakeTorque = 5000f;

		public float heatRateSlip = 8f;

		public float heatRateOppositeDirectionSlip = 30f;

		public float heatRateHydroDynamicBraking = 8f;

		public float overheatingThreshold = 120f;

		public float overheatingMaxTime = 5f;

		public float overheatingDamagePerDegreePerSecond = 0.1f;

		public float overheatingExplosionDamage = 300f;

		public readonly PortReferenceDefinition reverserReader = new PortReferenceDefinition(PortValueType.CONTROL, "REVERSER");

		public readonly PortReferenceDefinition hydroDynamicBrakeReader = new PortReferenceDefinition(PortValueType.CONTROL, "HYDRO_DYNAMIC_BRAKE");

		public readonly PortReferenceDefinition pumpRpmReader = new PortReferenceDefinition(PortValueType.RPM, "PUMP_RPM");

		public readonly PortReferenceDefinition maxPumpRpmReader = new PortReferenceDefinition(PortValueType.RPM, "MAX_PUMP_RPM");

		public readonly PortReferenceDefinition turbineRpmReader = new PortReferenceDefinition(PortValueType.RPM, "TURBINE_RPM");

		public readonly PortReferenceDefinition wheelSpeedKmhReader = new PortReferenceDefinition(PortValueType.GENERIC, "WHEEL_SPEED_KMH");

		public readonly PortDefinition powerIn = new PortDefinition(PortType.IN, PortValueType.POWER, "POWER_IN");

		public readonly PortReferenceDefinition temperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortDefinition heatOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT_OUT");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public readonly PortDefinition throttlingInOppositeMovementDirectionReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "THROTTLING_IN_OPPOSITE_MOVEMENT_DIRECTION");

		public readonly PortDefinition inNeutralReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IN_NEUTRAL");

		public readonly PortDefinition transmissionEngagedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "TRANSMISSION_ENGAGED");

		public readonly PortDefinition hydroDynamicBrakeNormalizedEffectReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "HYDRO_DYNAMIC_BRAKE_EFFECT");

		public readonly PortDefinition slipNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "SLIP_NORMALIZED");

		public readonly PortDefinition turbineRpmNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.RPM, "TURBINE_RPM_NORMALIZED");

		public readonly PortDefinition mechanicalPowerTrainHealthExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "MECHANICAL_PT_HEALTH_EXT_IN");

		public readonly PortDefinition generatedDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_DAMAGE");

		public readonly PortDefinition isBrokenReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IS_BROKEN");

		public readonly PortDefinition powerSourceTurnOffReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "POWER_SOURCE_TURN_OFF");

		public override SimComponent InstantiateImplementation()
		{
			return new FluidCoupling(this);
		}
	}
}
