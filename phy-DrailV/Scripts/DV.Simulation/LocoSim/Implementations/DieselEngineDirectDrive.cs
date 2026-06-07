using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class DieselEngineDirectDrive : SimComponent
	{
		private const string ENGINE_ON_SAVE_KEY = "on";

		private const string IS_BROKEN_SAVE_KEY = "broken";

		private const string FUEL_ENV_DAMAGE_SAVE_KEY = "fuelEnvDmg";

		private const float NEUTRAL_FUEL_CONSUMPTION_MODIFIER = 0.5f;

		private const float THROTTLE_STRESS_FUEL_CONSUMPTION_INFLUENCE_PERCENTAGE = 0.4f;

		private const float IGNITION_CONTROL_THRESHOLD = 0.75f;

		private const float IGNITION_DELAY_RATIO_OF_IGNITION_TIME = 0.4f;

		private const float IGNITION_MIN_TIME_RANDOMIZE_PERCENTAGE = 0.3f;

		private const float IGNITION_IN_PROGRESS_SMOOTH_TIME = 0.125f;

		private const float ENGINE_OFF_IDLE_RPM_PERCENTAGE_THRESHOLD = 0.6f;

		private const float ENGINE_OFF_LOW_RPM_TIME_THRESHOLD = 0.75f;

		private const float IDLE_FUEL_CONSUMPTION_PERCENTAGE = 0.01f;

		private const float TEMPERATURE_ABOVE_MAX_RPM_PERCENTAGE_FULL_EFFECT = 1.15f;

		private const float TRANSMISSION_ENGAGED_MIN_EFFECT_SPEED_KMH = 2f;

		private const float TRANSMISSION_ENGAGED_MAX_EFFECT_SPEED_KMH = 6f;

		public readonly float engineRpmMax;

		public readonly float engineRpmIdle;

		public readonly bool neutralAtZeroThrottle;

		public readonly AnimationCurve rpmToPowerCurve;

		public readonly float engineDragMaxBrakingTorque;

		public readonly float engineDragOverMaxRpmMultiplier;

		public readonly float retarderBrakingTorque;

		public readonly float minRetarderEffectEngineRpm;

		public readonly float maxRetarderEffectEngineRpm;

		public readonly float driveShaftToEngineRpmSmoothTime;

		public readonly float engineRpmDropToIdleInNeutralSmoothTime;

		public readonly float fuelInjection;

		public readonly float fuelConsumptionSmoothTime;

		public readonly float oilConsumptionRate;

		public readonly float ignitionMaxTime;

		public readonly float idleTemperature;

		public readonly float heatRateFromRpm;

		public readonly float heatRateBelowIdleFactor;

		public readonly float heatRateAboveMaxRpmFactor;

		public readonly float heatRateOppositeDirectionEffectFactor;

		public readonly float heatRateRetarderEffectFactor;

		public readonly float heatRateFromThrottleStress;

		public readonly float overheatingThreshold;

		public readonly float overheatingMaxTime;

		public readonly float noOilDamagePerSecond;

		public readonly float rpmDamagePerSecond;

		public readonly float damagePerIgnition;

		public readonly float overheatingExplosionDamage;

		public readonly float overheatingDamagePerDegreePerSecond;

		public readonly FuseReference engineStarterFuseRef;

		public readonly Port ignitionExtIn;

		public readonly Port ignitionInProgressReadOut;

		public readonly PortReference throttleReader;

		public readonly PortReference reverserReader;

		public readonly PortReference gearReader;

		public readonly PortReference retarderReader;

		public readonly PortReference driveShaftRpmReader;

		public readonly PortReference wheelSpeedKmhReader;

		public readonly Port emergencyEngineOffExtIn;

		public readonly Port collisionEngineOffExtIn;

		public readonly Port engineHealthStateExtIn;

		public readonly PortReference fuel;

		public readonly PortReference fuelConsumption;

		public readonly Port fuelEnvDamage;

		public readonly PortReference oil;

		public readonly PortReference oilConsumption;

		public readonly Port powerOut;

		public readonly Port engineBrakingTorqueOut;

		public readonly Port engineRpmReadOut;

		public readonly Port engineRpmNormalizedReadOut;

		public readonly Port engineIdleRpmNormalizedReadOut;

		public readonly Port engineRpmMaxReadOut;

		public readonly Port engineOnReadOut;

		public readonly Port inNeutralReadOut;

		public readonly Port throttleStressReadOut;

		public readonly Port throttlingInOppositeMovementDirectionReadOut;

		public readonly Port transmissionEngagedReadOut;

		public readonly PortReference temperature;

		public readonly Port heatOut;

		public readonly Port retarderNormalizedBrakeEffectReadOut;

		public readonly Port generatedEngineDamageReadOut;

		public readonly Port fuelConsumptionNormalizedReadOut;

		public readonly Port isBrokenReadOut;

		private bool ignitionRequested;

		private float ignitionDelay;

		private float ignitionRpmBuildUpTime;

		private float ignitionInProgressRefVelocity;

		private float fuelConsumptionSmoothed;

		private float fuelConsumptionSmoothedRefVelocity;

		private float targetFuelConsumption;

		private readonly float idleFuelConsumption;

		private bool engineOn;

		private float engineRpm;

		private float engineRpmSmoothingVelocity;

		private float engineOffLowRpmTimer;

		private float overheatingTimer;

		private float throttleStressSmoothedRefVelocity;

		private float transmissionEngagedSmoothRefVelocity;

		private float poweredReverserOppositeDirectionEffect;

		public override bool HasSaveData => true;

		public DieselEngineDirectDrive(DieselEngineDirectDriveDefinition deddDef)
			: base(deddDef.ID)
		{
			engineRpmMax = deddDef.engineRpmMax;
			engineRpmIdle = deddDef.engineRpmIdle;
			neutralAtZeroThrottle = deddDef.neutralAtZeroThrottle;
			rpmToPowerCurve = deddDef.rpmToPowerCurve;
			engineDragMaxBrakingTorque = deddDef.engineDragMaxBrakingTorque;
			engineDragOverMaxRpmMultiplier = deddDef.engineDragOverMaxRpmMultiplier;
			retarderBrakingTorque = deddDef.retarderBrakingTorque;
			minRetarderEffectEngineRpm = deddDef.minRetarderEffectEngineRpm;
			maxRetarderEffectEngineRpm = deddDef.maxRetarderEffectEngineRpm;
			driveShaftToEngineRpmSmoothTime = deddDef.driveShaftToEngineRpmSmoothTime;
			engineRpmDropToIdleInNeutralSmoothTime = deddDef.engineRpmDropToIdleInNeutralSmoothTime;
			fuelInjection = deddDef.fuelInjection;
			fuelConsumptionSmoothTime = deddDef.fuelConsumptionSmoothTime;
			idleFuelConsumption = fuelInjection * 0.01f;
			oilConsumptionRate = deddDef.oilConsumptionRate;
			ignitionMaxTime = deddDef.ignitionMaxTime;
			idleTemperature = deddDef.idleTemperature;
			heatRateFromRpm = deddDef.heatRateFromRpm;
			heatRateBelowIdleFactor = deddDef.heatRateBelowIdleFactor;
			heatRateAboveMaxRpmFactor = deddDef.heatRateAboveMaxRpmFactor;
			heatRateOppositeDirectionEffectFactor = deddDef.heatRateOppositeDirectionEffectFactor;
			heatRateRetarderEffectFactor = deddDef.heatRateRetarderEffectFactor;
			heatRateFromThrottleStress = deddDef.heatRateFromThrottleStress;
			overheatingThreshold = deddDef.overheatingThreshold;
			overheatingMaxTime = deddDef.overheatingMaxTime;
			noOilDamagePerSecond = deddDef.noOilDamagePerSecond;
			rpmDamagePerSecond = deddDef.rpmDamagePerSecond;
			damagePerIgnition = deddDef.damagePerIgnition;
			overheatingExplosionDamage = deddDef.overheatingExplosionDamage;
			overheatingDamagePerDegreePerSecond = deddDef.overheatingDamagePerDegreePerSecond;
			engineStarterFuseRef = AddFuseReference(deddDef.engineStarterFuseId);
			ignitionExtIn = AddPort(deddDef.ignitionExtIn);
			ignitionInProgressReadOut = AddPort(deddDef.ignitionInProgressReadOut);
			throttleReader = AddPortReference(deddDef.throttleReader);
			reverserReader = AddPortReference(deddDef.reverserReader);
			gearReader = AddPortReference(deddDef.gearReader);
			retarderReader = AddPortReference(deddDef.retarderReader);
			driveShaftRpmReader = AddPortReference(deddDef.driveShaftRpmReader);
			wheelSpeedKmhReader = AddPortReference(deddDef.wheelSpeedKmhReader);
			emergencyEngineOffExtIn = AddPort(deddDef.emergencyEngineOffExtIn);
			collisionEngineOffExtIn = AddPort(deddDef.collisionEngineOffExtIn);
			engineHealthStateExtIn = AddPort(deddDef.engineHealthStateExtIn, 1f);
			fuel = AddPortReference(deddDef.fuel);
			fuelConsumption = AddPortReference(deddDef.fuelConsumption);
			fuelEnvDamage = AddPort(deddDef.fuelEnvDamage);
			oil = AddPortReference(deddDef.oil);
			oilConsumption = AddPortReference(deddDef.oilConsumption);
			powerOut = AddPort(deddDef.powerOut);
			engineBrakingTorqueOut = AddPort(deddDef.engineBrakingTorqueOut);
			engineRpmReadOut = AddPort(deddDef.engineRpmReadOut);
			engineRpmNormalizedReadOut = AddPort(deddDef.engineRpmNormalizedReadOut);
			engineIdleRpmNormalizedReadOut = AddPort(deddDef.engineIdleRpmNormalizedReadOut, engineRpmIdle / engineRpmMax);
			engineRpmMaxReadOut = AddPort(deddDef.engineRpmMaxReadOut, engineRpmMax);
			engineOnReadOut = AddPort(deddDef.engineOnReadOut);
			inNeutralReadOut = AddPort(deddDef.inNeutralReadOut);
			throttleStressReadOut = AddPort(deddDef.throttleStressReadOut);
			throttlingInOppositeMovementDirectionReadOut = AddPort(deddDef.throttlingInOppositeMovementDirectionReadOut);
			transmissionEngagedReadOut = AddPort(deddDef.transmissionEngagedReadOut);
			temperature = AddPortReference(deddDef.temperature);
			heatOut = AddPort(deddDef.heatOut);
			retarderNormalizedBrakeEffectReadOut = AddPort(deddDef.retarderNormalizedBrakeEffectReadOut);
			generatedEngineDamageReadOut = AddPort(deddDef.generatedEngineDamageReadOut);
			fuelConsumptionNormalizedReadOut = AddPort(deddDef.fuelConsumptionNormalizedReadOut);
			isBrokenReadOut = AddPort(deddDef.isBrokenReadOut);
		}

		public override void Tick(float delta)
		{
			bool drivetrainFailuresAllowed = gameParams.DrivetrainFailuresAllowed;
			if (!drivetrainFailuresAllowed && isBrokenReadOut.Value == 1f)
			{
				isBrokenReadOut.Value = 0f;
			}
			float value = throttleStressReadOut.Value;
			bool flag = false;
			float value2 = temperature.Value;
			if (engineOn)
			{
				float num = engineRpm / engineRpmMax * heatRateFromRpm;
				if (value2 < idleTemperature)
				{
					num *= heatRateBelowIdleFactor;
				}
				if (engineRpm > engineRpmMax)
				{
					float t = Mathf.InverseLerp(engineRpmMax, engineRpmMax * 1.15f, engineRpm);
					num *= Mathf.Lerp(1f, heatRateAboveMaxRpmFactor, t);
				}
				float value3 = retarderNormalizedBrakeEffectReadOut.Value;
				if (value3 > 0f)
				{
					num *= Mathf.Lerp(1f, heatRateRetarderEffectFactor, value3);
				}
				if (poweredReverserOppositeDirectionEffect > 0f)
				{
					num *= Mathf.Lerp(1f, heatRateOppositeDirectionEffectFactor, poweredReverserOppositeDirectionEffect);
				}
				if (value > 0f)
				{
					num += value * heatRateFromThrottleStress;
				}
				heatOut.Value = num;
				if (value2 > overheatingThreshold && overheatingTimer <= 0f)
				{
					overheatingTimer = Random.Range(1f, overheatingMaxTime);
				}
			}
			if (overheatingTimer > 0f)
			{
				if (value2 <= overheatingThreshold || !engineOn || drivetrainFailuresAllowed)
				{
					overheatingTimer = 0f;
				}
				else
				{
					overheatingTimer -= delta;
					if (overheatingTimer <= 0f)
					{
						engineOn = false;
						engineOnReadOut.Value = 0f;
						overheatingTimer = 0f;
					}
					else if (value2 > overheatingThreshold * 1.75f)
					{
						isBrokenReadOut.Value = 1f;
						flag = true;
						engineOn = false;
						engineOnReadOut.Value = 0f;
						overheatingTimer = 0f;
					}
				}
			}
			float value4 = fuel.Value;
			float value5 = oil.Value;
			float num2 = 0f;
			if (drivetrainFailuresAllowed)
			{
				float num3 = engineRpm / engineRpmMax;
				if (value5 <= 0f && engineRpm > 0f)
				{
					num2 += noOilDamagePerSecond * num3 * delta;
				}
				if (num3 > 0f)
				{
					num2 += num3 * rpmDamagePerSecond * delta;
				}
				float num4 = value2 - overheatingThreshold;
				if (num4 > 0f)
				{
					num2 += overheatingDamagePerDegreePerSecond * num4 * delta;
				}
				if (flag)
				{
					num2 += overheatingExplosionDamage;
				}
			}
			generatedEngineDamageReadOut.Value = num2;
			float value6 = engineHealthStateExtIn.Value;
			if (value6 > 0.95f && engineHealthStateExtIn.Diff > 0f)
			{
				isBrokenReadOut.Value = 0f;
			}
			bool flag2 = value6 == 0f;
			float num5 = (engineStarterFuseRef.State ? ignitionExtIn.Value : 0f);
			if (!ignitionRequested && num5 >= 0.75f)
			{
				ignitionRequested = true;
				float num6 = ignitionMaxTime * 0.4f;
				ignitionDelay = Random.Range(num6 * 0.3f, num6);
				float num7 = ignitionMaxTime * 0.6f;
				ignitionRpmBuildUpTime = Random.Range(num7 * 0.3f, num7);
			}
			else if (ignitionRequested && num5 < 0.75f)
			{
				ignitionRequested = false;
			}
			if (ignitionRequested && !engineOn && value4 > 0f && isBrokenReadOut.Value == 0f && !flag2)
			{
				if (ignitionDelay > 0f)
				{
					ignitionDelay -= delta;
				}
				else
				{
					engineRpm += engineRpmIdle / ignitionRpmBuildUpTime * delta;
					targetFuelConsumption = fuelInjection * 0.5f;
					fuelConsumptionSmoothed = Mathf.SmoothDamp(fuelConsumptionSmoothed, targetFuelConsumption, ref fuelConsumptionSmoothedRefVelocity, 0.01f, float.PositiveInfinity, delta);
					float num8 = fuelConsumptionSmoothed * gameParams.ResourceConsumptionModifier * delta;
					if (value4 < num8)
					{
						num8 = value4;
					}
					if (num8 > 0f)
					{
						fuelConsumption.Value = num8;
						fuelEnvDamage.Value += num8;
					}
					if (engineRpm > engineRpmIdle)
					{
						engineOn = true;
						engineOnReadOut.Value = 1f;
						if (drivetrainFailuresAllowed)
						{
							generatedEngineDamageReadOut.Value += damagePerIgnition;
						}
						fuelConsumptionSmoothedRefVelocity = 0f;
					}
				}
				ignitionInProgressReadOut.Value = Mathf.SmoothDamp(ignitionInProgressReadOut.Value, 1f, ref ignitionInProgressRefVelocity, 0.125f, float.PositiveInfinity, delta);
				engineRpmReadOut.Value = engineRpm;
				engineRpmNormalizedReadOut.Value = engineRpm / engineRpmMax;
				fuelConsumptionNormalizedReadOut.Value = fuelConsumptionSmoothed / fuelInjection;
				powerOut.Value = 0f;
				engineBrakingTorqueOut.Value = 0f;
				retarderNormalizedBrakeEffectReadOut.Value = 0f;
				throttleStressReadOut.Value = 0f;
				throttlingInOppositeMovementDirectionReadOut.Value = 0f;
				poweredReverserOppositeDirectionEffect = 0f;
				transmissionEngagedReadOut.Value = 0f;
				inNeutralReadOut.Value = 1f;
				return;
			}
			float value7 = ignitionInProgressReadOut.Value;
			if (value7 != 0f)
			{
				value7 = Mathf.SmoothDamp(value7, 0f, ref ignitionInProgressRefVelocity, 0.125f, float.PositiveInfinity, delta);
				if (value7 < 0.001f)
				{
					value7 = 0f;
				}
				ignitionInProgressReadOut.Value = value7;
			}
			if (flag2 && engineOn)
			{
				engineOn = false;
				engineOnReadOut.Value = 0f;
			}
			if (emergencyEngineOffExtIn.Value > 0f)
			{
				engineOn = false;
				engineOnReadOut.Value = 0f;
			}
			if (collisionEngineOffExtIn.Value > 0f)
			{
				engineOn = false;
				engineOnReadOut.Value = 0f;
				collisionEngineOffExtIn.Value = 0f;
			}
			float value8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			bool flag3 = false;
			poweredReverserOppositeDirectionEffect = 0f;
			float value9 = reverserReader.Value;
			float value10 = throttleReader.Value;
			bool flag4 = value10 == 0f;
			bool flag5 = neutralAtZeroThrottle && flag4;
			float value11 = retarderReader.Value;
			bool flag6 = flag4 && value11 > 0f;
			bool flag7 = value9 == 0f || (flag5 && !flag6);
			float num11 = 0f;
			if (engineOn)
			{
				if (value10 > 0f)
				{
					num11 = Mathf.Clamp((value10 * engineRpmMax - engineRpm) / engineRpmMax, 0.1f, 1f);
					float num12 = value10 * 0.6f;
					float num13 = 0.4f * value;
					targetFuelConsumption = (num12 + num13) * fuelInjection;
				}
				else
				{
					targetFuelConsumption = idleFuelConsumption;
				}
				if (flag7)
				{
					targetFuelConsumption = Mathf.Clamp(targetFuelConsumption * 0.5f, idleFuelConsumption, fuelInjection);
					float num14 = engineRpmIdle + value10 * (engineRpmMax - engineRpmIdle);
					float smoothTime = ((num14 == engineRpmIdle) ? engineRpmDropToIdleInNeutralSmoothTime : 1f);
					engineRpm = Mathf.SmoothDamp(engineRpm, num14, ref engineRpmSmoothingVelocity, smoothTime, float.PositiveInfinity, delta);
					value8 = rpmToPowerCurve.Evaluate(engineRpm);
					engineOffLowRpmTimer = 0f;
				}
				else
				{
					float num15 = Mathf.Abs(driveShaftRpmReader.Value);
					bool num16 = Mathf.Sign(driveShaftRpmReader.Value) == Mathf.Sign(value9);
					bool flag8 = num15 > 0.1f;
					flag3 = !num16 && flag8;
					if (flag3)
					{
						poweredReverserOppositeDirectionEffect = Mathf.InverseLerp(0f, engineRpmIdle * 0.6f, num15);
					}
					engineRpm = Mathf.SmoothDamp(target: (!flag4 || !(num15 < engineRpmIdle)) ? num15 : engineRpmIdle, current: engineRpm, currentVelocity: ref engineRpmSmoothingVelocity, smoothTime: driveShaftToEngineRpmSmoothTime, maxSpeed: float.PositiveInfinity, deltaTime: delta);
					value8 = (flag4 ? rpmToPowerCurve.Evaluate(engineRpmIdle) : (value10 * rpmToPowerCurve.Evaluate(engineRpm)));
					if (num15 > engineRpmIdle)
					{
						num9 = engineDragMaxBrakingTorque * (num15 / engineRpmMax);
						if (num15 > engineRpmMax)
						{
							num9 *= engineDragOverMaxRpmMultiplier;
						}
					}
					if (flag6)
					{
						num10 = Mathf.InverseLerp(minRetarderEffectEngineRpm, maxRetarderEffectEngineRpm, engineRpm) * value11;
						num9 += num10 * retarderBrakingTorque;
					}
					if (engineRpm < engineRpmIdle * 0.6f)
					{
						engineOffLowRpmTimer += delta;
						if (engineOffLowRpmTimer > 0.75f)
						{
							engineOn = false;
							engineOnReadOut.Value = 0f;
							engineOffLowRpmTimer = 0f;
						}
					}
					else
					{
						engineOffLowRpmTimer = 0f;
					}
				}
				targetFuelConsumption = Mathf.Clamp(targetFuelConsumption, 0f, fuelInjection);
				fuelConsumptionSmoothed = Mathf.SmoothDamp(fuelConsumptionSmoothed, targetFuelConsumption, ref fuelConsumptionSmoothedRefVelocity, fuelConsumptionSmoothTime, float.PositiveInfinity, delta);
				if (fuelConsumptionSmoothed < 0.0001f && targetFuelConsumption == 0f)
				{
					fuelConsumptionSmoothed = 0f;
				}
				float num17 = fuelConsumptionSmoothed * gameParams.ResourceConsumptionModifier * delta;
				if (value4 < num17)
				{
					num17 = value4;
				}
				if (num17 > 0f)
				{
					fuelConsumption.Value = num17;
					fuelEnvDamage.Value += num17;
				}
				if (fuel.Value <= 0f)
				{
					engineOn = false;
					engineOnReadOut.Value = 0f;
				}
				float num18 = engineRpm / engineRpmMax * oilConsumptionRate * gameParams.ResourceConsumptionModifier * delta;
				if (value5 < num18)
				{
					num18 = value5;
				}
				oilConsumption.Value = num18;
			}
			else
			{
				engineRpm -= Mathf.Max(engineRpm, engineRpmIdle) * delta;
				engineRpm = Mathf.Clamp(engineRpm, 0f, float.PositiveInfinity);
				if (fuelConsumptionSmoothed > 0f)
				{
					targetFuelConsumption = 0f;
					fuelConsumptionSmoothed = Mathf.SmoothDamp(fuelConsumptionSmoothed, targetFuelConsumption, ref fuelConsumptionSmoothedRefVelocity, 0.01f, float.PositiveInfinity, delta);
					if (fuelConsumptionSmoothed < 0.0001f)
					{
						fuelConsumptionSmoothed = 0f;
					}
				}
				engineOffLowRpmTimer = 0f;
			}
			inNeutralReadOut.Value = (flag7 ? 1f : 0f);
			value = Mathf.Clamp01(Mathf.SmoothDamp(value, num11, ref throttleStressSmoothedRefVelocity, 0.01f, float.PositiveInfinity, delta));
			if (value > 0f && value < 0.001f && num11 == 0f)
			{
				value = 0f;
				throttleStressSmoothedRefVelocity = 0f;
			}
			throttleStressReadOut.Value = value;
			throttlingInOppositeMovementDirectionReadOut.Value = (flag3 ? 1f : 0f);
			float num19 = 0f;
			if (!flag7 && engineOn)
			{
				num19 = (flag3 ? 1f : Mathf.Max(value, num10));
				float num20 = Mathf.InverseLerp(2f, 6f, Mathf.Abs(wheelSpeedKmhReader.Value));
				num19 *= num20;
			}
			float num21 = transmissionEngagedReadOut.Value;
			if (num21 != num19)
			{
				num21 = Mathf.SmoothDamp(num21, num19, ref transmissionEngagedSmoothRefVelocity, 0.3f, float.PositiveInfinity, delta);
				if (num21 < 0.01f && num19 == 0f)
				{
					num21 = 0f;
					transmissionEngagedSmoothRefVelocity = 0f;
				}
			}
			transmissionEngagedReadOut.Value = num21;
			engineRpmReadOut.Value = engineRpm;
			engineRpmNormalizedReadOut.Value = engineRpm / engineRpmMax;
			powerOut.Value = value8;
			engineBrakingTorqueOut.Value = num9;
			retarderNormalizedBrakeEffectReadOut.Value = num10;
			fuelConsumptionNormalizedReadOut.Value = fuelConsumptionSmoothed / fuelInjection;
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetBool("on", engineOn);
			if (isBrokenReadOut.Value == 1f)
			{
				jObject.SetBool("broken", value: true);
			}
			float value = fuelEnvDamage.Value;
			if (value > 0f)
			{
				jObject.SetFloat("fuelEnvDmg", value);
			}
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			bool? flag = savedData.GetBool("on");
			if (flag.HasValue)
			{
				if (flag.Value)
				{
					engineOn = true;
					engineOnReadOut.Value = 1f;
					engineRpm = engineRpmIdle;
				}
			}
			else
			{
				Debug.LogError("Unexpected state: Missing data for " + id + ".ENGINE_ON_SAVE_KEY. Loading ignored for this parameter.");
			}
			bool? flag2 = savedData.GetBool("broken");
			if (flag2.HasValue && flag2.Value)
			{
				isBrokenReadOut.Value = 1f;
			}
			float? num = savedData.GetFloat("fuelEnvDmg");
			if (num.HasValue)
			{
				fuelEnvDamage.Value = num.Value;
			}
		}
	}
}
