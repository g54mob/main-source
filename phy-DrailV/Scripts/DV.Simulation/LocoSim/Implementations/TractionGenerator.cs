using System;
using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class TractionGenerator : SimComponent
	{
		private const float LOAD_REDUCTION_THROTTLE_THRESHOLD = 0.99f;

		private float maxVoltage;

		private float torqueFactor;

		private float maxAmps;

		private float throttleProportionalGain;

		private float throttleDifferentialGain;

		private float throttleIntegralGain;

		private float throttleIntegralMax;

		private float throttleIntegralMin;

		private float throttleMaxSpeed;

		private float excitationGainMaxSpeed;

		private float excitationDropMaxSpeed;

		private float dynamicBrakeGoalRpmNormalized;

		private readonly FuseReference powerFuseRef;

		private readonly PortReference goalPowerReader;

		private readonly PortReference goalRpmNormalizedReader;

		private readonly PortReference dynamicBrakeReader;

		private readonly PortReference rpmReader;

		private readonly PortReference rpmNormalizedReader;

		private readonly Port throttleReadOut;

		private readonly Port loadTorqueReadOut;

		private readonly Port voltageReadOut;

		private readonly PortReference totalAmpsReader;

		private readonly PortReference effectiveResistanceReader;

		private readonly PortReference singleMotorEffectiveResistanceReader;

		private readonly PortReference transitionCurrentLimitReader;

		private readonly Port externalCurrentLimitExtIn;

		private readonly Port externalCurrentLimitActiveReadOut;

		private readonly Port overcurrentPowerFuseOffReadOut;

		private readonly Port generatorExcitationReadOut;

		private readonly Port powerInReadOut;

		private readonly Port powerOutReadOut;

		private readonly PIDController throttleController;

		private bool generatorConnected;

		public TractionGenerator(TractionGeneratorDefinition tgDef)
			: base(tgDef.ID)
		{
			maxVoltage = tgDef.maxVoltage;
			torqueFactor = tgDef.torqueFactor;
			maxAmps = tgDef.maxAmps;
			throttleProportionalGain = tgDef.throttleProportionalGain;
			throttleDifferentialGain = tgDef.throttleDifferentialGain;
			throttleIntegralGain = tgDef.throttleIntegralGain;
			throttleIntegralMax = tgDef.throttleIntegralMax;
			throttleIntegralMin = tgDef.throttleIntegralMin;
			throttleMaxSpeed = tgDef.throttleMaxSpeed;
			excitationGainMaxSpeed = tgDef.excitationGainMaxSpeed;
			excitationDropMaxSpeed = tgDef.excitationDropMaxSpeed;
			dynamicBrakeGoalRpmNormalized = tgDef.dynamicBrakeGoalRpmNormalized;
			powerFuseRef = AddFuseReference(tgDef.powerFuseId);
			goalPowerReader = AddPortReference(tgDef.goalPowerReader);
			goalRpmNormalizedReader = AddPortReference(tgDef.goalRpmNormalizedReader);
			dynamicBrakeReader = AddPortReference(tgDef.dynamicBrakeReader);
			rpmReader = AddPortReference(tgDef.rpmReader);
			rpmNormalizedReader = AddPortReference(tgDef.rpmNormalizedReader);
			throttleReadOut = AddPort(tgDef.throttleReadOut);
			loadTorqueReadOut = AddPort(tgDef.loadTorqueReadOut);
			voltageReadOut = AddPort(tgDef.voltageReadOut);
			totalAmpsReader = AddPortReference(tgDef.totalAmpsReader);
			effectiveResistanceReader = AddPortReference(tgDef.effectiveResistanceReader);
			singleMotorEffectiveResistanceReader = AddPortReference(tgDef.singleMotorEffectiveResistanceReader);
			transitionCurrentLimitReader = AddPortReference(tgDef.transitionCurrentLimitReader, float.PositiveInfinity);
			externalCurrentLimitExtIn = AddPort(tgDef.externalCurrentLimitExtIn, float.PositiveInfinity);
			externalCurrentLimitActiveReadOut = AddPort(tgDef.externalCurrentLimitActiveReadOut);
			overcurrentPowerFuseOffReadOut = AddPort(tgDef.overcurrentPowerFuseOffReadOut);
			generatorExcitationReadOut = AddPort(tgDef.generatorExcitationReadOut);
			powerInReadOut = AddPort(tgDef.powerInReadOut);
			powerOutReadOut = AddPort(tgDef.powerOutReadOut);
			throttleController = new PIDController();
		}

		private void SimulateDamage(float delta)
		{
			overcurrentPowerFuseOffReadOut.Value = 0f;
			if (totalAmpsReader.Value > maxAmps && powerFuseRef.State && gameParams.DrivetrainFailuresAllowed)
			{
				powerFuseRef.ChangeState(newState: false);
				overcurrentPowerFuseOffReadOut.Value = 1f;
			}
		}

		private void SimulateThrottleControl(float delta)
		{
			float setPoint = ((dynamicBrakeReader.Value > 0f) ? dynamicBrakeGoalRpmNormalized : goalRpmNormalizedReader.Value);
			throttleController.ProportionalGain = throttleProportionalGain;
			throttleController.DifferentialGain = throttleDifferentialGain;
			throttleController.IntegralGain = throttleIntegralGain;
			throttleController.IntegralMax = throttleIntegralMax;
			throttleController.IntegralMin = throttleIntegralMin;
			float num = Mathf.Clamp(throttleController.Update(setPoint, rpmNormalizedReader.Value, delta), 0f - throttleMaxSpeed, throttleMaxSpeed);
			throttleReadOut.Value = Mathf.Clamp01(throttleReadOut.Value + num * delta);
		}

		private void SimulateVoltageControl(float delta)
		{
			bool flag = float.IsInfinity(effectiveResistanceReader.Value);
			bool flag2 = dynamicBrakeReader.Value > 0f;
			float num = rpmReader.Value * ((float)Math.PI / 30f);
			float num2;
			if (!powerFuseRef.State || flag || flag2)
			{
				num2 = 0f;
			}
			else
			{
				float value = effectiveResistanceReader.Value;
				float num3 = ((value > 0f) ? Mathf.Sqrt(goalPowerReader.Value * value) : 0f);
				float num4 = NumberUtil.MapClamp(max2: Mathf.Min(1f, rpmNormalizedReader.Value / goalRpmNormalizedReader.Value), value: throttleReadOut.Value, min1: 0.99f, max1: 1f, min2: 1f);
				float a = num3 * num4;
				float b = (float.IsInfinity(transitionCurrentLimitReader.Value) ? float.PositiveInfinity : (transitionCurrentLimitReader.Value * singleMotorEffectiveResistanceReader.Value));
				float num5 = Mathf.Min(maxVoltage, Mathf.Min(a, b));
				float b2 = (float.IsInfinity(externalCurrentLimitExtIn.Value) ? float.PositiveInfinity : (externalCurrentLimitExtIn.Value * singleMotorEffectiveResistanceReader.Value));
				float num6 = Mathf.Min(num5, b2);
				externalCurrentLimitActiveReadOut.Value = ((num6 < num5) ? 1f : 0f);
				num2 = Mathf.Clamp01(num6 / num / torqueFactor);
			}
			float num7 = generatorExcitationReadOut.Value;
			if (num2 > generatorExcitationReadOut.Value)
			{
				num7 = Mathf.Min(num2, num7 + excitationGainMaxSpeed * delta);
			}
			else if (num2 < generatorExcitationReadOut.Value)
			{
				num7 = Mathf.Max(num2, num7 - excitationDropMaxSpeed * delta);
			}
			generatorExcitationReadOut.Value = num7;
			voltageReadOut.Value = torqueFactor * num7 * num;
		}

		private void SimulateTorque()
		{
			float value = totalAmpsReader.Value;
			loadTorqueReadOut.Value = (0f - generatorExcitationReadOut.Value) * torqueFactor * value;
			powerInReadOut.Value = (0f - loadTorqueReadOut.Value) * rpmReader.Value * ((float)Math.PI / 30f);
			powerOutReadOut.Value = voltageReadOut.Value * value;
		}

		public override void Tick(float delta)
		{
			SimulateDamage(delta);
			SimulateThrottleControl(delta);
			SimulateVoltageControl(delta);
			SimulateTorque();
		}
	}
}
