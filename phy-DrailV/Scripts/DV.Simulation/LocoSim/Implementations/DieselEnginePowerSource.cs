using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class DieselEnginePowerSource : SimComponent
	{
		private const string ENGINE_ON_SAVE_KEY = "on";

		private const string FUEL_ENV_DAMAGE_SAVE_KEY = "fuelEnvDmg";

		private const float SEVERE_DAMAGE_ENGINE_OFF_CHECK_PERIOD = 60f;

		private const float IGNITION_CONTROL_THRESHOLD = 0.75f;

		private const float IGNITION_DELAY_RATIO_OF_IGNITION_TIME = 0.4f;

		private const float IGNITION_MIN_TIME_RANDOMIZE_PERCENTAGE = 0.3f;

		private const float IGNITION_IN_PROGRESS_SMOOTH_TIME = 0.15f;

		private const float IDLE_RPM_POWER_MULTIPLIER = 0.1f;

		public readonly float engineRpmMax;

		public readonly float engineRpmIdle;

		public readonly float maxPower;

		public readonly float fuelInjection;

		public readonly float rpmGainFromFuel;

		public readonly float rpmGainNoLoadMultiplier;

		public readonly float rpmGainMinLoadMultiplier;

		public readonly float rpmGainMaxLoadMultiplier;

		public readonly float fuelConsumptionSmoothTime;

		public readonly float oilConsumptionRate;

		public readonly float ignitionTime;

		public readonly float engineDragFalloff;

		public readonly float idleTemperature;

		public readonly float heatRateFromRpm;

		public readonly float heatRateBelowIdleFactor;

		public readonly float overheatingTemperatureThreshold;

		public readonly float overheatingMaxTime;

		public readonly float noOilDamagePerSecond;

		public readonly float rpmDamagePerSecond;

		public readonly float damagePerIgnition;

		public readonly float overheatingDamagePerDegreePerSecond;

		public readonly float enginePerformanceDropHealthPercentage;

		public readonly float damagedEnginePowerConstraintStart;

		public readonly float damagedEnginePowerConstraintEnd;

		public readonly float severeDamageEngineOffProbabilityMultiplier;

		public readonly FuseReference engineStarterFuseRef;

		public readonly Port ignitionExtIn;

		public readonly Port emergencyEngineOffExtIn;

		public readonly Port collisionEngineOffExtIn;

		public readonly PortReference internalEngineOffReader;

		public readonly Port engineHealthStateExtIn;

		public readonly PortReference fuel;

		public readonly PortReference fuelConsumption;

		public readonly Port fuelEnvDamage;

		public readonly PortReference oil;

		public readonly PortReference oilConsumption;

		public readonly PortReference goalPowerReader;

		public readonly PortReference secondaryGoalPowerReader;

		public readonly PortReference loadOnRotorReader;

		public readonly Port powerOut;

		public readonly Port goalPowerSmoothNormalizedReadOut;

		public readonly PortReference temperature;

		public readonly Port heatOut;

		public readonly Port engineRpmReadOut;

		public readonly Port engineRpmNormalizedReadOut;

		public readonly Port engineIdleRpmNormalizedReadOut;

		public readonly Port engineOnReadOut;

		public readonly Port ignitionInProgressReadOut;

		public readonly Port maxPowerReadOut;

		public readonly Port maxRpmReadOut;

		public readonly Port generatedEngineDamageReadOut;

		public readonly Port fuelConsumptionNormalizedReadOut;

		private bool ignitionRequested;

		private float ignitionDelay;

		private float ignitionRpmBuildUpTime;

		private float ignitionInProgressRefVelocity;

		private float goalPowerSmoothNormalized;

		private float goalPowerSmoothNormalizedVelocity;

		private float targetFuelConsumption;

		private float fuelConsumptionSmoothed;

		private float fuelConsumptionSmoothedRefVelocity;

		private float rpmGainFromFuelSmoothed;

		private float rpmGainFromFuelSmoothedRefVelocity;

		private bool engineOn;

		private float engineRpm;

		private float idlePower;

		private float overheatingTimer;

		private bool overheatingTimerActivated;

		private float severeDamageEngineOffTimer = 60f;

		public override bool HasSaveData => true;

		public DieselEnginePowerSource(DieselEnginePowerSourceDefinition depsDef)
			: base(depsDef.ID)
		{
			engineRpmMax = depsDef.engineRpmMax;
			engineRpmIdle = depsDef.engineRpmIdle;
			maxPower = depsDef.maxPower;
			fuelInjection = depsDef.fuelInjection;
			rpmGainFromFuel = depsDef.rpmGainFromFuel;
			rpmGainNoLoadMultiplier = depsDef.rpmGainNoLoadMultiplier;
			rpmGainMinLoadMultiplier = depsDef.rpmGainMinLoadMultiplier;
			rpmGainMaxLoadMultiplier = depsDef.rpmGainMaxLoadMultiplier;
			fuelConsumptionSmoothTime = depsDef.fuelConsumptionSmoothTime;
			rpmGainFromFuelSmoothed = rpmGainFromFuel;
			ignitionTime = depsDef.ignitionTime;
			oilConsumptionRate = depsDef.oilConsumptionRate;
			engineDragFalloff = depsDef.engineDragFalloff;
			idleTemperature = depsDef.idleTemperature;
			heatRateFromRpm = depsDef.heatRateFromRpm;
			heatRateBelowIdleFactor = depsDef.heatRateBelowIdleFactor;
			overheatingTemperatureThreshold = depsDef.overheatingTemperatureThreshold;
			overheatingMaxTime = depsDef.overheatingMaxTime;
			noOilDamagePerSecond = depsDef.noOilDamagePerSecond;
			rpmDamagePerSecond = depsDef.rpmDamagePerSecond;
			damagePerIgnition = depsDef.damagePerIgnition;
			overheatingDamagePerDegreePerSecond = depsDef.overheatingDamagePerDegreePerSecond;
			enginePerformanceDropHealthPercentage = depsDef.enginePerformanceDropHealthPercentage;
			damagedEnginePowerConstraintStart = depsDef.damagedEnginePowerConstraintStart;
			damagedEnginePowerConstraintEnd = depsDef.damagedEnginePowerConstraintEnd;
			severeDamageEngineOffProbabilityMultiplier = depsDef.severeDamageEngineOffProbabilityMultiplier;
			engineStarterFuseRef = AddFuseReference(depsDef.engineStarterFuseId);
			ignitionExtIn = AddPort(depsDef.ignitionExtIn);
			emergencyEngineOffExtIn = AddPort(depsDef.emergencyEngineOffExtIn);
			collisionEngineOffExtIn = AddPort(depsDef.collisionEngineOffExtIn);
			internalEngineOffReader = AddPortReference(depsDef.internalEngineOffReader);
			engineHealthStateExtIn = AddPort(depsDef.engineHealthStateExtIn, 1f);
			fuel = AddPortReference(depsDef.fuel);
			fuelConsumption = AddPortReference(depsDef.fuelConsumption);
			fuelEnvDamage = AddPort(depsDef.fuelEnvDamage);
			oil = AddPortReference(depsDef.oil);
			oilConsumption = AddPortReference(depsDef.oilConsumption);
			goalPowerReader = AddPortReference(depsDef.goalPowerReader);
			secondaryGoalPowerReader = AddPortReference(depsDef.secondaryGoalPowerReader);
			loadOnRotorReader = AddPortReference(depsDef.loadOnRotorReader);
			powerOut = AddPort(depsDef.powerOut);
			temperature = AddPortReference(depsDef.temperature);
			heatOut = AddPort(depsDef.heatOut);
			engineRpmReadOut = AddPort(depsDef.engineRpmReadOut);
			engineRpmNormalizedReadOut = AddPort(depsDef.engineRpmNormalizedReadOut);
			engineIdleRpmNormalizedReadOut = AddPort(depsDef.engineIdleRpmNormalizedReadOut, engineRpmIdle / engineRpmMax);
			engineOnReadOut = AddPort(depsDef.engineOnReadOut);
			ignitionInProgressReadOut = AddPort(depsDef.ignitionInProgressReadOut);
			maxPowerReadOut = AddPort(depsDef.maxPowerReadOut, maxPower);
			maxRpmReadOut = AddPort(depsDef.maxRpmReadOut, engineRpmMax);
			generatedEngineDamageReadOut = AddPort(depsDef.generatedEngineDamageReadOut);
			fuelConsumptionNormalizedReadOut = AddPort(depsDef.fuelConsumptionNormalizedReadOut);
			goalPowerSmoothNormalizedReadOut = AddPort(depsDef.goalPowerSmoothNormalizedReadOut);
			idlePower = 0.1f * maxPower;
		}

		public override void Tick(float delta)
		{
			float value = fuel.Value;
			float value2 = oil.Value;
			float value3 = engineHealthStateExtIn.Value;
			float value4 = temperature.Value;
			if (engineOn)
			{
				float num = engineRpm / engineRpmMax * heatRateFromRpm;
				if (value4 < idleTemperature)
				{
					num *= heatRateBelowIdleFactor;
				}
				heatOut.Value = num;
				if (value4 > overheatingTemperatureThreshold && !overheatingTimerActivated && gameParams.DrivetrainFailuresAllowed)
				{
					overheatingTimerActivated = true;
					overheatingTimer = Random.Range(1f, overheatingMaxTime);
				}
			}
			if (overheatingTimerActivated)
			{
				if (value4 <= overheatingTemperatureThreshold || !engineOn)
				{
					overheatingTimerActivated = false;
					overheatingTimer = 0f;
				}
				else if (overheatingTimer <= 0f)
				{
					overheatingTimerActivated = false;
					overheatingTimer = 0f;
					engineOn = false;
					engineOnReadOut.Value = 0f;
				}
				else
				{
					overheatingTimer -= delta;
				}
			}
			float num2 = 0f;
			float num3 = engineRpm / engineRpmMax;
			if (value2 <= 0f && engineRpm > 0f)
			{
				num2 += noOilDamagePerSecond * num3 * delta;
			}
			if (num3 > 0f)
			{
				num2 += num3 * rpmDamagePerSecond * delta;
			}
			float num4 = value4 - overheatingTemperatureThreshold;
			if (num4 > 0f)
			{
				num2 += overheatingDamagePerDegreePerSecond * num4 * delta;
			}
			generatedEngineDamageReadOut.Value = num2;
			float num5 = (engineStarterFuseRef.State ? ignitionExtIn.Value : 0f);
			if (!ignitionRequested && num5 >= 0.75f)
			{
				ignitionRequested = true;
				float num6 = ignitionTime * 0.4f;
				ignitionDelay = Random.Range(num6 * 0.3f, num6);
				float num7 = ignitionTime * 0.6f;
				ignitionRpmBuildUpTime = Random.Range(num7 * 0.3f, num7);
			}
			else if (ignitionRequested && num5 < 0.75f)
			{
				ignitionRequested = false;
			}
			if (ignitionRequested && !engineOn && value > 0f && value3 > 0f)
			{
				if (ignitionDelay > 0f)
				{
					ignitionDelay -= delta;
				}
				else
				{
					engineRpm += engineRpmIdle / ignitionRpmBuildUpTime * delta;
					if (engineRpm > engineRpmIdle)
					{
						engineOn = true;
						engineOnReadOut.Value = 1f;
						generatedEngineDamageReadOut.Value += damagePerIgnition;
					}
				}
				ignitionInProgressReadOut.Value = Mathf.SmoothDamp(ignitionInProgressReadOut.Value, 1f, ref ignitionInProgressRefVelocity, 0.15f, float.PositiveInfinity, delta);
				engineRpmReadOut.Value = engineRpm;
				engineRpmNormalizedReadOut.Value = engineRpm / engineRpmMax;
				powerOut.Value = 0f;
				return;
			}
			float value5 = ignitionInProgressReadOut.Value;
			if (value5 != 0f)
			{
				value5 = Mathf.SmoothDamp(value5, 0f, ref ignitionInProgressRefVelocity, 0.15f, float.PositiveInfinity, delta);
				if (value5 < 0.001f)
				{
					value5 = 0f;
				}
				ignitionInProgressReadOut.Value = value5;
			}
			if (internalEngineOffReader.Value > 0f || emergencyEngineOffExtIn.Value > 0f || collisionEngineOffExtIn.Value > 0f)
			{
				engineOn = false;
				engineOnReadOut.Value = 0f;
				collisionEngineOffExtIn.Value = 0f;
			}
			float num8 = Mathf.Max(engineRpm, engineRpmIdle) * engineDragFalloff;
			if (engineOn)
			{
				float a = Mathf.Max(goalPowerReader.Value, secondaryGoalPowerReader.Value);
				a = Mathf.Max(a, idlePower);
				a = Mathf.Clamp(a, 0f, maxPower);
				if (value3 < enginePerformanceDropHealthPercentage && gameParams.DrivetrainFailuresAllowed)
				{
					float num9 = Mathf.InverseLerp(enginePerformanceDropHealthPercentage, 0f, value3);
					float num10 = Mathf.Lerp(damagedEnginePowerConstraintStart, damagedEnginePowerConstraintEnd, num9);
					a *= num10;
					if (severeDamageEngineOffTimer > 0f)
					{
						severeDamageEngineOffTimer -= delta;
					}
					else
					{
						severeDamageEngineOffTimer = 60f;
						if (Random.value < num9 * severeDamageEngineOffProbabilityMultiplier)
						{
							engineOn = false;
							engineOnReadOut.Value = 0f;
						}
					}
				}
				float num11 = a / maxPower;
				float smoothTime = ((goalPowerSmoothNormalized > num11) ? 0.1f : 0.5f);
				goalPowerSmoothNormalized = Mathf.SmoothDamp(goalPowerSmoothNormalized, num11, ref goalPowerSmoothNormalizedVelocity, smoothTime, float.PositiveInfinity, delta);
				float value6 = powerOut.Value;
				float num12 = goalPowerSmoothNormalized * maxPower;
				float num13 = num12 + maxPower * 0.1f;
				if (value6 < num13)
				{
					float num14 = rpmGainFromFuel;
					num14 = ((loadOnRotorReader.Value != 0f) ? (num14 * Mathf.Lerp(rpmGainMinLoadMultiplier, rpmGainMaxLoadMultiplier, loadOnRotorReader.Value)) : (num14 * rpmGainNoLoadMultiplier));
					float smoothTime2 = ((rpmGainFromFuelSmoothed > num14) ? 0.1f : 1f);
					rpmGainFromFuelSmoothed = Mathf.SmoothDamp(rpmGainFromFuelSmoothed, num14, ref rpmGainFromFuelSmoothedRefVelocity, smoothTime2, float.PositiveInfinity, delta);
					float num15 = num8 / rpmGainFromFuelSmoothed;
					if (value6 >= num12)
					{
						float num16 = Mathf.InverseLerp(num13, num12, value6);
						targetFuelConsumption = num16 * num15;
					}
					else
					{
						float num17 = num15 * 1.01f;
						float value7 = num12 - value6;
						float num18 = Mathf.InverseLerp(0f, maxPower * 0.6f, value7);
						targetFuelConsumption = num18 * fuelInjection + num17;
					}
				}
				else
				{
					if (targetFuelConsumption > 0f)
					{
						fuelConsumptionSmoothedRefVelocity = 0f;
					}
					targetFuelConsumption = 0f;
				}
				targetFuelConsumption = Mathf.Clamp(targetFuelConsumption, 0f, fuelInjection);
				float num19 = ((targetFuelConsumption > 0f) ? 1f : 5f);
				fuelConsumptionSmoothed = Mathf.SmoothDamp(fuelConsumptionSmoothed, targetFuelConsumption, ref fuelConsumptionSmoothedRefVelocity, fuelConsumptionSmoothTime * num19, float.PositiveInfinity, delta);
				if (fuelConsumptionSmoothed < 0.0001f && targetFuelConsumption == 0f)
				{
					fuelConsumptionSmoothed = 0f;
				}
				float num20 = fuelConsumptionSmoothed * delta;
				if (value < num20)
				{
					num20 = value;
				}
				engineRpm += num20 * rpmGainFromFuelSmoothed;
				num20 *= gameParams.ResourceConsumptionModifier;
				if (value < num20)
				{
					num20 = value;
				}
				if (num20 > 0f)
				{
					fuelConsumption.Value = num20;
					fuelEnvDamage.Value += num20;
				}
				if (engineRpm < engineRpmIdle * 0.5f)
				{
					engineOn = false;
					engineOnReadOut.Value = 0f;
				}
				float num21 = engineRpm / engineRpmMax * oilConsumptionRate * gameParams.ResourceConsumptionModifier * delta;
				if (value2 < num21)
				{
					num21 = value2;
				}
				oilConsumption.Value = num21;
			}
			else
			{
				goalPowerSmoothNormalized = Mathf.SmoothDamp(goalPowerSmoothNormalized, 0f, ref goalPowerSmoothNormalizedVelocity, 1f, float.PositiveInfinity, delta);
				targetFuelConsumption = 0f;
				fuelConsumptionSmoothed = Mathf.SmoothDamp(fuelConsumptionSmoothed, targetFuelConsumption, ref fuelConsumptionSmoothedRefVelocity, 0.01f, float.PositiveInfinity, delta);
				if (fuelConsumptionSmoothed < 0.0001f)
				{
					fuelConsumptionSmoothed = 0f;
				}
			}
			engineRpm -= num8 * delta;
			engineRpm = Mathf.Clamp(engineRpm, 0f, engineRpmMax);
			engineRpmReadOut.Value = engineRpm;
			engineRpmNormalizedReadOut.Value = engineRpm / engineRpmMax;
			goalPowerSmoothNormalizedReadOut.Value = goalPowerSmoothNormalized;
			fuelConsumptionNormalizedReadOut.Value = fuelConsumptionSmoothed / fuelInjection;
			powerOut.Value = ((engineRpm >= engineRpmIdle) ? NumberUtil.Map(engineRpm, engineRpmIdle, engineRpmMax, idlePower, maxPower) : (engineRpm / engineRpmIdle * idlePower));
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetBool("on", engineOn);
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
			float? num = savedData.GetFloat("fuelEnvDmg");
			if (num.HasValue)
			{
				fuelEnvDamage.Value = num.Value;
			}
		}
	}
}
