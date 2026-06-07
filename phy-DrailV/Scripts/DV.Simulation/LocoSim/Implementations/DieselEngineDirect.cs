using System;
using System.Linq;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class DieselEngineDirect : SimComponent
	{
		private const string ENGINE_ON_SAVE_KEY = "on";

		private const string IS_BROKEN_SAVE_KEY = "broken";

		private const string FUEL_ENV_DAMAGE_SAVE_KEY = "fuelEnvDmg";

		private const float ENGINE_OFF_IDLE_RPM_PERCENTAGE_THRESHOLD = 0.4f;

		private const float OVERREV_DAMAGE_ALPHA = 0.1f;

		private const float OVERREV_DAMAGE_EXPONENT = 50f;

		private const float STARTER_TORQUE_MULTIPLIER = 2f;

		private const float STARTUP_NO_OIL_TIME = 2f;

		private const float ENGINE_POWER_LOSS_HEALTH = 0.5f;

		private const float HYDROLOCK_DAMAGE_PERCENTAGE = 0.3f;

		private float rotationalInertia;

		private float viscousDampingFactor;

		private float engineRpmMax;

		private float engineRpmIdle;

		private AnimationCurve rpmToPowerCurve;

		private float retarderBrakingTorque;

		private float fuelInjection;

		private float oilConsumptionRate;

		private float noOilDamagePerSecond;

		private float rpmDamagePerSecond;

		private float rpmDamageImmunityTime;

		private float overheatingThreshold;

		private float overheatingDamagePerDegreePerSecond;

		public readonly FuseReference engineStarterFuseRef;

		public readonly Port ignitionExtIn;

		public readonly PortReference throttleReader;

		public readonly PortReference retarderReader;

		public readonly Port engineRpm;

		public readonly PortReference drivenRpm;

		public readonly PortReference intakeWaterContent;

		public readonly PortReference fuel;

		public readonly PortReference fuelConsumption;

		public readonly Port fuelEnvDamage;

		public readonly PortReference oil;

		public readonly PortReference oilConsumption;

		public readonly PortReference loadTorque;

		public readonly PortReference temperature;

		public readonly Port heatOut;

		public readonly Port emergencyEngineOffExtIn;

		public readonly Port collisionEngineOffExtIn;

		public readonly Port engineHealthStateExtIn;

		public readonly Port generatedEngineDamageReadOut;

		public readonly Port generatedEnginePercentualDamageReadOut;

		public readonly Port engineOnReadOut;

		public readonly Port engineRpmNormalizedReadOut;

		public readonly Port engineIdleRpmNormalizedReadOut;

		public readonly Port engineIdlePowerReadOut;

		public readonly Port engineMaxPowerRpmNormalizedReadOut;

		public readonly Port engineMaxPowerReadOut;

		public readonly Port engineRpmMaxReadOut;

		public readonly Port ignitionInProgressReadOut;

		public readonly Port retarderNormalizedBrakeEffectReadOut;

		public readonly Port fuelConsumptionNormalizedReadOut;

		public readonly Port isBrokenReadOut;

		private float torqueIdle;

		private float engineRpmMin;

		private bool engineOn;

		private float lubrication;

		private float lubricationVelocity;

		private bool isMisfiring;

		private float retarderOpening;

		private float retarderOpeningVelocity;

		private float normalizedRetarderEffect;

		private float torqueGenerated;

		private float torqueGeneratedVelocity;

		private float ignitionInProgressReadOutVelocity;

		private float remainingRpmDamageImmunityTime;

		public override bool HasSaveData => true;

		public DieselEngineDirect(DieselEngineDirectDefinition deDef)
			: base(deDef.ID)
		{
			engineStarterFuseRef = AddFuseReference(deDef.engineStarterFuseId);
			rotationalInertia = deDef.rotationalInertia;
			viscousDampingFactor = deDef.viscousDampingFactor;
			rpmToPowerCurve = deDef.rpmToPowerCurve ?? throw new ArgumentNullException("rpmToPowerCurve");
			engineRpmMax = deDef.engineRpmMax;
			engineRpmIdle = deDef.engineRpmIdle;
			fuelInjection = deDef.fuelInjection;
			oilConsumptionRate = deDef.oilConsumptionRate;
			retarderBrakingTorque = deDef.retarderBrakingTorque;
			noOilDamagePerSecond = deDef.noOilDamagePerSecond;
			rpmDamagePerSecond = deDef.rpmDamagePerSecond;
			rpmDamageImmunityTime = deDef.rpmDamageImmunityTime;
			overheatingThreshold = deDef.overheatingThreshold;
			overheatingDamagePerDegreePerSecond = deDef.overheatingDamagePerDegreePerSecond;
			engineRpmMin = 0.4f * deDef.engineRpmIdle;
			torqueIdle = (float)Math.PI / 30f * deDef.engineRpmIdle * deDef.viscousDampingFactor;
			ignitionExtIn = AddPort(deDef.ignitionExtIn);
			throttleReader = AddPortReference(deDef.throttleReader);
			retarderReader = AddPortReference(deDef.retarderReader);
			engineRpm = AddPort(deDef.engineRpm);
			drivenRpm = AddPortReference(deDef.drivenRpm);
			intakeWaterContent = AddPortReference(deDef.intakeWaterContent);
			fuel = AddPortReference(deDef.fuel);
			fuelConsumption = AddPortReference(deDef.fuelConsumption);
			fuelEnvDamage = AddPort(deDef.fuelEnvDamage);
			oil = AddPortReference(deDef.oil);
			oilConsumption = AddPortReference(deDef.oilConsumption);
			loadTorque = AddPortReference(deDef.loadTorque);
			temperature = AddPortReference(deDef.temperature);
			heatOut = AddPort(deDef.heatOut);
			emergencyEngineOffExtIn = AddPort(deDef.emergencyEngineOffExtIn);
			collisionEngineOffExtIn = AddPort(deDef.collisionEngineOffExtIn);
			engineHealthStateExtIn = AddPort(deDef.engineHealthStateExtIn, 1f);
			generatedEngineDamageReadOut = AddPort(deDef.generatedEngineDamageReadOut);
			generatedEnginePercentualDamageReadOut = AddPort(deDef.generatedEnginePercentualDamageReadOut);
			float defaultValue = rpmToPowerCurve.Evaluate(engineRpmIdle);
			float maxPower = rpmToPowerCurve.keys.Max((Keyframe kf) => kf.value);
			float time = rpmToPowerCurve.keys.Where((Keyframe kf) => kf.value == maxPower).First().time;
			engineOnReadOut = AddPort(deDef.engineOnReadOut);
			engineRpmNormalizedReadOut = AddPort(deDef.engineRpmNormalizedReadOut);
			engineIdleRpmNormalizedReadOut = AddPort(deDef.engineIdleRpmNormalizedReadOut, engineRpmIdle / engineRpmMax);
			engineIdlePowerReadOut = AddPort(deDef.engineIdlePowerReadOut, defaultValue);
			engineMaxPowerRpmNormalizedReadOut = AddPort(deDef.engineMaxPowerRpmNormalizedReadOut, time / engineRpmMax);
			engineMaxPowerReadOut = AddPort(deDef.engineMaxPowerReadOut, maxPower);
			engineRpmMaxReadOut = AddPort(deDef.engineRpmMaxReadOut, engineRpmMax);
			ignitionInProgressReadOut = AddPort(deDef.ignitionInProgressReadOut);
			retarderNormalizedBrakeEffectReadOut = AddPort(deDef.retarderNormalizedBrakeEffectReadOut);
			fuelConsumptionNormalizedReadOut = AddPort(deDef.fuelConsumptionNormalizedReadOut);
			isBrokenReadOut = AddPort(deDef.isBrokenReadOut);
			remainingRpmDamageImmunityTime = rpmDamageImmunityTime;
		}

		private void SimulateDamage(float delta)
		{
			bool drivetrainFailuresAllowed = gameParams.DrivetrainFailuresAllowed;
			float value = engineHealthStateExtIn.Value;
			float num = Mathf.InverseLerp(0.5f, 0f, value);
			float num2 = engineRpm.Value / engineRpmMax;
			isMisfiring = num > 0f && UnityEngine.Random.value < num && drivetrainFailuresAllowed;
			float num3 = ((lubrication < 1f) ? ((1f - lubrication) * noOilDamagePerSecond * num2) : 0f);
			float num4 = Mathf.Max(0f, temperature.Value - overheatingThreshold) * overheatingDamagePerDegreePerSecond;
			float num5 = ((num2 > 1f) ? (0f - delta) : delta);
			remainingRpmDamageImmunityTime = Mathf.Clamp(remainingRpmDamageImmunityTime + num5, 0f, rpmDamageImmunityTime);
			float num6 = rpmDamagePerSecond * num2;
			float num7 = ((remainingRpmDamageImmunityTime > 0f) ? 0f : (rpmDamagePerSecond * 0.1f * Mathf.Pow(num2, 50f)));
			float num8 = num6 + num7;
			float num9 = (drivetrainFailuresAllowed ? (num3 + num4 + num8) : 0f);
			generatedEngineDamageReadOut.Value = num9 * delta;
			float num10 = 0f;
			if (engineOn && intakeWaterContent.Value > 0.5f)
			{
				num10 += 0.3f;
				engineOn = false;
			}
			generatedEnginePercentualDamageReadOut.Value = (drivetrainFailuresAllowed ? num10 : 0f);
			if (value == 0f && engineHealthStateExtIn.Diff < 0f && drivetrainFailuresAllowed)
			{
				isBrokenReadOut.Value = 1f;
			}
			if (value > 0.95f && engineHealthStateExtIn.Diff > 0f)
			{
				isBrokenReadOut.Value = 0f;
			}
		}

		private void SimulateFuel(float delta)
		{
			float value = fuel.Value;
			if (value <= 0f)
			{
				engineOn = false;
			}
			float num = (engineOn ? (engineRpm.Value / engineRpmMax * Mathf.Lerp(0.1f, 1f, throttleReader.Value)) : 0f);
			fuelConsumptionNormalizedReadOut.Value = num;
			float num2 = num * fuelInjection * gameParams.ResourceConsumptionModifier * delta;
			if (value < num2)
			{
				num2 = value;
			}
			if (num2 > 0f)
			{
				fuelConsumption.Value = num2;
				fuelEnvDamage.Value += num2;
			}
		}

		private void SimulateOil(float delta)
		{
			float num = ((engineRpm.Value > 0f && oil.Value > 0f) ? 1f : 0f);
			lubrication = Mathf.SmoothDamp(lubrication, num, ref lubricationVelocity, 2f, float.PositiveInfinity, delta);
			if (num == 1f && lubrication > 0.99f)
			{
				lubrication = 1f;
				lubricationVelocity = 0f;
			}
			float num2 = engineRpm.Value / engineRpmMax * oilConsumptionRate * delta;
			num2 *= gameParams.ResourceConsumptionModifier;
			if (num2 > 0f)
			{
				oilConsumption.Value = num2;
			}
		}

		private void SimulateRetarder(float delta)
		{
			retarderOpening = Mathf.SmoothDamp(retarderOpening, retarderReader.Value, ref retarderOpeningVelocity, 0.3f, float.PositiveInfinity, delta);
			if (retarderReader.Value == 0f && retarderOpening < 0.01f)
			{
				retarderOpening = 0f;
			}
			normalizedRetarderEffect = retarderOpening * Mathf.InverseLerp(engineRpmIdle, engineRpmMax, engineRpm.Value);
			retarderNormalizedBrakeEffectReadOut.Value = normalizedRetarderEffect;
		}

		private void SimulateTorque(float delta)
		{
			float value = engineRpm.Value;
			float num = value / engineRpmMax;
			bool flag = engineStarterFuseRef.ProcessInput(ignitionExtIn.Value) > 0f;
			bool flag2 = !flag && value < engineRpmMin;
			engineOn = (engineOn || flag) && fuel.Value > 0f && value > engineRpmMin && intakeWaterContent.Value < 0.5f && emergencyEngineOffExtIn.Value == 0f && collisionEngineOffExtIn.Value == 0f;
			collisionEngineOffExtIn.Value = 0f;
			if (isBrokenReadOut.Value == 1f)
			{
				heatOut.Value = 0f;
				engineRpm.Value = 0f;
				return;
			}
			float num2 = 0f;
			float num3 = (float)Math.PI / 30f * value * viscousDampingFactor;
			if (flag)
			{
				num2 += Mathf.Lerp(torqueIdle * 2f, 0f, value / engineRpmIdle);
			}
			torqueGenerated = Mathf.SmoothDamp(target: flag2 ? (num2 - retarderBrakingTorque * num) : ((!engineOn || isMisfiring || normalizedRetarderEffect != 0f) ? (num2 - normalizedRetarderEffect * retarderBrakingTorque) : (num2 + Mathf.Lerp(torqueIdle, rpmToPowerCurve.Evaluate(value) / ((float)Math.PI / 30f * value) + num3, throttleReader.Value))), current: torqueGenerated, currentVelocity: ref torqueGeneratedVelocity, smoothTime: 0.2f, maxSpeed: float.PositiveInfinity, deltaTime: delta);
			float num4 = torqueGenerated - num3;
			float b = num4 * ((float)Math.PI / 30f) * value;
			heatOut.Value = Mathf.Max(0f, b);
			float num5 = num4 + loadTorque.Value;
			float num6 = engineRpm.Value + num5 / rotationalInertia * delta;
			if (drivenRpm.IsConnected && num5 > 0f && num4 < 0f)
			{
				num6 = Mathf.Min(num6, drivenRpm.Value);
			}
			if (num6 < 0.01f)
			{
				num6 = 0f;
			}
			engineRpm.Value = num6;
		}

		private void FeedReadOuts(float delta)
		{
			float value = engineRpm.Value;
			engineOnReadOut.Value = (engineOn ? 1f : 0f);
			engineRpmNormalizedReadOut.Value = value / engineRpmMax;
			float num = ((engineStarterFuseRef.ProcessInput(ignitionExtIn.Value) > 0f && value > 0f && value <= engineRpmMin) ? 1f : 0f);
			float num2 = Mathf.SmoothDamp(ignitionInProgressReadOut.Value, num, ref ignitionInProgressReadOutVelocity, 0.125f, float.PositiveInfinity, delta);
			if (num2 < 0.01f && num == 0f)
			{
				num2 = 0f;
				ignitionInProgressReadOutVelocity = 0f;
			}
			ignitionInProgressReadOut.Value = num2;
		}

		public override void Tick(float delta)
		{
			SimulateDamage(delta);
			SimulateFuel(delta);
			SimulateOil(delta);
			SimulateRetarder(delta);
			SimulateTorque(delta);
			FeedReadOuts(delta);
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			if (engineOn)
			{
				jObject.SetBool("on", value: true);
			}
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
			if (flag.HasValue && flag.Value)
			{
				engineOn = true;
				engineOnReadOut.Value = 1f;
				engineRpm.Value = engineRpmIdle;
				lubrication = 1f;
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
