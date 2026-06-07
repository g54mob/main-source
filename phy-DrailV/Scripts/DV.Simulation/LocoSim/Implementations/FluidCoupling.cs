using System;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class FluidCoupling : SimComponent
	{
		private const string IS_BROKEN_SAVE_KEY = "broken";

		private const float TRANSMISSION_ENGAGED_MIN_EFFECT_SPEED_KMH = 2f;

		private const float TRANSMISSION_ENGAGED_MAX_EFFECT_SPEED_KMH = 6f;

		public readonly float pumpRpmTorqueStartThreshold;

		public readonly AnimationCurve turbineAndPumpRpmRatioToTorqueMultiplier;

		public readonly float maxSlipEffectRpmDifference;

		public readonly float oppositeDirectionTorquePercentage;

		public readonly float minTurbineRpmHydroDynamicBrake;

		public readonly float maxTurbineRpmHydroDynamicBrake;

		public readonly float hydroDynamicBrakeTorque;

		public readonly float heatRateSlip;

		public readonly float heatRateOppositeDirectionSlip;

		public readonly float heatRateHydroDynamicBraking;

		public readonly float overheatingThreshold;

		public readonly float overheatingMaxTime;

		public readonly float overheatingDamagePerDegreePerSecond;

		public readonly float overheatingExplosionDamage;

		public readonly PortReference reverserReader;

		public readonly PortReference hydroDynamicBrakeReader;

		public readonly PortReference pumpRpmReader;

		public readonly PortReference maxPumpRpmReader;

		public readonly PortReference turbineRpmReader;

		public readonly PortReference wheelSpeedKmhReader;

		public readonly Port powerIn;

		public readonly PortReference temperature;

		public readonly Port heatOut;

		public readonly Port torqueOut;

		public readonly Port throttlingInOppositeMovementDirectionReadOut;

		public readonly Port inNeutralReadOut;

		public readonly Port transmissionEngagedReadOut;

		public readonly Port hydroDynamicBrakeNormalizedEffectReadOut;

		public readonly Port slipNormalizedReadOut;

		public readonly Port turbineRpmNormalizedReadOut;

		public readonly Port mechanicalPowerTrainHealthExtIn;

		public readonly Port generatedDamageReadOut;

		public readonly Port isBrokenReadOut;

		public readonly Port powerSourceTurnOffReadOut;

		private float transmissionEngagedSmoothRefVelocity;

		private float slipNormalizedRefVelocity;

		private float overheatingTimer;

		private float hydroDynamicBrakeSmoothingMultiplier;

		private float hydroDynamicBrakeSmoothingRefVelocity;

		public override bool HasSaveData => true;

		public FluidCoupling(FluidCouplingDefinition fcDef)
			: base(fcDef.ID)
		{
			pumpRpmTorqueStartThreshold = fcDef.pumpRpmTorqueStartThreshold;
			turbineAndPumpRpmRatioToTorqueMultiplier = fcDef.turbineToPumpRelativeSpeedToTorqueMultiplier;
			maxSlipEffectRpmDifference = fcDef.maxSlipEffectRpmDifference;
			oppositeDirectionTorquePercentage = fcDef.oppositeDirectionTorquePercentage;
			minTurbineRpmHydroDynamicBrake = fcDef.minTurbineRpmHydroDynamicBrake;
			maxTurbineRpmHydroDynamicBrake = fcDef.maxTurbineRpmHydroDynamicBrake;
			hydroDynamicBrakeTorque = fcDef.hydroDynamicBrakeTorque;
			heatRateSlip = fcDef.heatRateSlip;
			heatRateOppositeDirectionSlip = fcDef.heatRateOppositeDirectionSlip;
			heatRateHydroDynamicBraking = fcDef.heatRateHydroDynamicBraking;
			overheatingThreshold = fcDef.overheatingThreshold;
			overheatingMaxTime = fcDef.overheatingMaxTime;
			overheatingDamagePerDegreePerSecond = fcDef.overheatingDamagePerDegreePerSecond;
			overheatingExplosionDamage = fcDef.overheatingExplosionDamage;
			reverserReader = AddPortReference(fcDef.reverserReader);
			hydroDynamicBrakeReader = AddPortReference(fcDef.hydroDynamicBrakeReader);
			pumpRpmReader = AddPortReference(fcDef.pumpRpmReader);
			maxPumpRpmReader = AddPortReference(fcDef.maxPumpRpmReader);
			turbineRpmReader = AddPortReference(fcDef.turbineRpmReader);
			wheelSpeedKmhReader = AddPortReference(fcDef.wheelSpeedKmhReader);
			powerIn = AddPort(fcDef.powerIn);
			temperature = AddPortReference(fcDef.temperature);
			heatOut = AddPort(fcDef.heatOut);
			torqueOut = AddPort(fcDef.torqueOut);
			throttlingInOppositeMovementDirectionReadOut = AddPort(fcDef.throttlingInOppositeMovementDirectionReadOut);
			inNeutralReadOut = AddPort(fcDef.inNeutralReadOut);
			transmissionEngagedReadOut = AddPort(fcDef.transmissionEngagedReadOut);
			hydroDynamicBrakeNormalizedEffectReadOut = AddPort(fcDef.hydroDynamicBrakeNormalizedEffectReadOut);
			slipNormalizedReadOut = AddPort(fcDef.slipNormalizedReadOut);
			turbineRpmNormalizedReadOut = AddPort(fcDef.turbineRpmNormalizedReadOut);
			mechanicalPowerTrainHealthExtIn = AddPort(fcDef.mechanicalPowerTrainHealthExtIn, 1f);
			generatedDamageReadOut = AddPort(fcDef.generatedDamageReadOut);
			isBrokenReadOut = AddPort(fcDef.isBrokenReadOut);
			powerSourceTurnOffReadOut = AddPort(fcDef.powerSourceTurnOffReadOut);
		}

		public override void Tick(float delta)
		{
			float value = turbineRpmReader.Value;
			turbineRpmNormalizedReadOut.Value = value / maxPumpRpmReader.Value;
			float value2 = pumpRpmReader.Value;
			bool flag = value2 > 0f;
			bool flag2 = isBrokenReadOut.Value == 1f;
			if (flag2 && powerSourceTurnOffReadOut.Value == 1f)
			{
				powerSourceTurnOffReadOut.Value = 0f;
			}
			float value3 = reverserReader.Value;
			bool flag3 = value3 == 0f;
			inNeutralReadOut.Value = (flag3 ? 1f : 0f);
			bool flag4 = Mathf.Sign(value) == Mathf.Sign(value3);
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float value4 = hydroDynamicBrakeReader.Value;
			bool num5 = flag && value4 > 0f && !flag3;
			bool flag5 = value2 > pumpRpmTorqueStartThreshold && !flag3;
			bool flag6 = false;
			if (num5)
			{
				num3 = 1f;
				float num6 = Mathf.InverseLerp(minTurbineRpmHydroDynamicBrake, maxTurbineRpmHydroDynamicBrake, Mathf.Abs(value));
				num4 = value4 * num6 * hydroDynamicBrakeSmoothingMultiplier;
				num2 = (flag2 ? 0f : (-1f * num4 * hydroDynamicBrakeTorque));
				if (!flag4)
				{
					num2 = 0f - num2;
				}
				flag6 = !flag4;
			}
			else if (flag5)
			{
				num = Mathf.Clamp01((value2 - value * value3) / maxSlipEffectRpmDifference);
				float num7 = (float)Math.PI * 2f * value2 / 60f;
				float num8 = powerIn.Value / num7;
				float num9 = Mathf.Abs(value);
				float num10 = (flag4 ? turbineAndPumpRpmRatioToTorqueMultiplier.Evaluate(Mathf.Max(num9, pumpRpmTorqueStartThreshold) / value2) : Mathf.Lerp(1f, oppositeDirectionTorquePercentage, Mathf.InverseLerp(0f, pumpRpmTorqueStartThreshold, num9)));
				num2 = (flag2 ? 0f : (num10 * num8));
				flag6 = !flag4;
			}
			float num11 = Mathf.SmoothDamp(slipNormalizedReadOut.Value, num, ref slipNormalizedRefVelocity, 0.2f, float.PositiveInfinity, delta);
			if (num11 < 0.001f && num11 > 0f && num == 0f)
			{
				slipNormalizedRefVelocity = 0f;
				num11 = 0f;
			}
			slipNormalizedReadOut.Value = num11;
			hydroDynamicBrakeSmoothingMultiplier = Mathf.SmoothDamp(hydroDynamicBrakeSmoothingMultiplier, num3, ref hydroDynamicBrakeSmoothingRefVelocity, 1f, float.PositiveInfinity, delta);
			if (hydroDynamicBrakeSmoothingMultiplier < 0.01f && hydroDynamicBrakeSmoothingMultiplier > 0f && num3 == 0f)
			{
				hydroDynamicBrakeSmoothingRefVelocity = 0f;
				hydroDynamicBrakeSmoothingMultiplier = 0f;
			}
			hydroDynamicBrakeNormalizedEffectReadOut.Value = num4;
			torqueOut.Value = num2 * value3;
			throttlingInOppositeMovementDirectionReadOut.Value = (flag6 ? 1f : 0f);
			float num12 = 0f;
			if (!flag3 && flag)
			{
				num12 = (flag6 ? 1f : Mathf.Max(num11, num4));
				float num13 = Mathf.InverseLerp(2f, 6f, Mathf.Abs(wheelSpeedKmhReader.Value));
				num12 *= num13;
			}
			float num14 = transmissionEngagedReadOut.Value;
			if (num14 != num12)
			{
				num14 = Mathf.SmoothDamp(num14, num12, ref transmissionEngagedSmoothRefVelocity, 0.3f, float.PositiveInfinity, delta);
				if (num14 < 0.01f && num12 == 0f)
				{
					num14 = 0f;
					transmissionEngagedSmoothRefVelocity = 0f;
				}
			}
			transmissionEngagedReadOut.Value = num14;
			bool flag7 = false;
			float value5 = temperature.Value;
			float value6 = 0f;
			if (!flag2)
			{
				if (num4 > 0f)
				{
					value6 = num4 * heatRateHydroDynamicBraking;
				}
				else if (flag5)
				{
					value6 = (flag4 ? (num11 * heatRateSlip) : (num11 * heatRateOppositeDirectionSlip));
				}
			}
			heatOut.Value = value6;
			if (value5 > overheatingThreshold)
			{
				if (overheatingTimer <= 0f)
				{
					overheatingTimer = UnityEngine.Random.Range(1f, overheatingMaxTime);
				}
			}
			else if (!gameParams.DrivetrainFailuresAllowed && flag2)
			{
				isBrokenReadOut.Value = 0f;
				flag2 = false;
			}
			if (overheatingTimer > 0f)
			{
				if (value5 <= overheatingThreshold || flag2)
				{
					overheatingTimer = 0f;
				}
				else
				{
					overheatingTimer -= delta;
					if (overheatingTimer <= 0f || value5 > overheatingThreshold * 1.75f)
					{
						isBrokenReadOut.Value = 1f;
						powerSourceTurnOffReadOut.Value = 1f;
						flag7 = true;
						overheatingTimer = 0f;
					}
				}
			}
			if (mechanicalPowerTrainHealthExtIn.Value > 0.95f && mechanicalPowerTrainHealthExtIn.Diff > 0f)
			{
				isBrokenReadOut.Value = 0f;
			}
			if (value5 > overheatingThreshold)
			{
				float num15 = 0f;
				float num16 = value5 - overheatingThreshold;
				if (num16 > 0f)
				{
					num15 += overheatingDamagePerDegreePerSecond * num16 * delta;
				}
				if (flag7)
				{
					num15 += overheatingExplosionDamage;
				}
				generatedDamageReadOut.Value = num15;
			}
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			if (isBrokenReadOut.Value == 1f)
			{
				jObject.SetBool("broken", value: true);
			}
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			bool? flag = savedData.GetBool("broken");
			if (flag.HasValue && flag.Value)
			{
				isBrokenReadOut.Value = 1f;
			}
		}
	}
}
