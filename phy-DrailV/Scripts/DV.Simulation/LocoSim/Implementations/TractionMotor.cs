using DV.JObjectExtstensions;
using LocoSim.Definitions;
using LocoSim.Implementations.Wheels;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class TractionMotor : SimComponent
	{
		private const string WORKING_TRACTION_MOTORS_SAVE_KEY = "workingTMs";

		private const string POWERED_WHEELS_SAVE_KEY = "poweredWheels";

		private const float TMS_STATE_FUSE_ON_HAS_DEAD_TM_SIGNAL_VALUE = -1f;

		private const float TMS_STATE_FUSE_OFF_SIGNAL_VALUE = 0f;

		private const float TMS_STATE_FUSE_ON_TMS_ALIVE_SIGNAL_VALUE = 1f;

		private const float RPM_SMOOTH_TIME = 0.2f;

		private const float AMPS_SMOOTH_TIME = 0.5f;

		private const float MAX_AMPS_PERCENTAGE_REQUIRED_FOR_TM_KILL = 0.75f;

		public readonly float maxRpm;

		public readonly float maxGeneratorVoltage;

		public readonly int numberOfTractionMotors;

		public readonly float maxAmpsPerTractionMotor;

		public readonly float torqueLimitRpmPercentage;

		public readonly float torqueFactor;

		public readonly float oppositeDirectionTorquePercentage;

		public readonly float dynamicBrakeMaxPowerPerTractionMotor;

		public readonly float dynamicBrakeVoltage;

		public readonly float dynamicBrakeTorqueFactor;

		public readonly float dynamicBrakeThrottlePercentage;

		public readonly float dynamicBrakeMinEffectRpmPercentage;

		public readonly float dynamicBrakeMaxEffectRpmPercentage;

		public readonly float contactor0To1SwitchDuration;

		public readonly float contactor1To0DelayTime;

		public readonly TractionMotorDefinition.ContactorTransition[] contactorTransitions;

		public readonly float heatRateFromAmps;

		public readonly float heatRateOverMaxAmpsFactor;

		public readonly float heatRateDynamicBrakeFactor;

		public readonly float heatRateOppositeDirectionSpeedFactor;

		public readonly float overheatingTemperatureThreshold;

		public readonly float overheatingMaxTime;

		public readonly float overheatingTmKillPercentage;

		public readonly float setTmOnFireOnKillPercentage;

		public readonly float damagePerRpmOverMaxPerSecond;

		public readonly float rpmDamagePerSecond;

		public readonly float overheatingDamagePerDegreePerSecond;

		public readonly float damagePerFuseBlow;

		public readonly float damagePerTmBlow;

		public readonly float tmPerformanceDropHealthPercentage;

		public readonly float damagedTmTorqueConstraintStart;

		public readonly float damagedTmTorqueConstraintEnd;

		public readonly PoweredWheelsManager poweredWheelsManager;

		public readonly FuseReference powerFuseRef;

		public readonly PortReference throttlePowerReader;

		public readonly PortReference throttleNotchReader;

		public readonly PortReference throttlePrevNotchReader;

		public readonly PortReference reverserReader;

		public readonly PortReference dynamicBrakeReader;

		public readonly PortReference wheelRpmReader;

		public readonly PortReference gearRatioReader;

		public readonly PortReference maxPowerProvidedReader;

		public readonly Port tmHealthStateExtIn;

		public readonly Port workingTractionMotorsReadOut;

		public readonly Port powerIn;

		public readonly Port goalPowerReadOut;

		public readonly Port torqueOut;

		public readonly PortReference temperature;

		public readonly Port heatOut;

		public readonly Port ampsReadOut;

		public readonly Port ampsNormalizedReadOut;

		public readonly Port maxAmpsReadOut;

		public readonly Port generatorVoltageReadOut;

		public readonly Port tmRpmReadOut;

		public readonly Port tmRpmNormalizedReadOut;

		public readonly Port dynamicBrakeNormalizedEffectReadOut;

		public readonly Port loadOnGeneratorReadOut;

		public readonly Port contactor0To1ReadOut;

		public readonly Port contactor1To0ReadOut;

		public readonly Port contactorTransitionReadOut;

		public readonly Port overheatPowerFuseOffReadOut;

		public readonly Port tmsStateReadOut;

		public readonly Port generatedEngineDamageReadOut;

		public readonly Port externalTractionMotorsExtIn;

		public readonly Port externalTractionMotorsTorqueReadOut;

		private readonly float minGeneratorVoltage;

		private bool dynamicBrakeActive;

		private float tmRpm;

		private float tmRpmSmoothVelocity;

		private bool poweredReverserOppositeOfMovementDirection;

		private float amps;

		private float ampsSmoothingVelocity;

		private bool contactor0To1InProgress;

		private float contactor0To1TimeElapsed;

		private bool contactor1To0InProgress;

		private float contactor1To0TimeElapsed;

		private bool contactorTransitionInProgress;

		private float contactorTransitionTimeElapsed;

		private int transitionStateIndex = -1;

		private float overheatingTimer;

		private bool overheatingTimerActivated;

		private bool wasDisconnectedFromGenerator;

		private float PoweredReverserOppositeDirectionEffect => Mathf.InverseLerp(0f, maxRpm * 0.1f, tmRpm);

		public override bool HasSaveData => true;

		public TractionMotor(TractionMotorDefinition tmDef)
			: base(tmDef.ID)
		{
			maxGeneratorVoltage = tmDef.maxGeneratorVoltage;
			minGeneratorVoltage = maxGeneratorVoltage * 0.1f;
			maxRpm = tmDef.maxRpm;
			numberOfTractionMotors = tmDef.numberOfTractionMotors;
			maxAmpsPerTractionMotor = tmDef.maxAmpsPerTractionMotor;
			torqueLimitRpmPercentage = tmDef.torqueLimitRpmPercentage;
			torqueFactor = tmDef.torqueFactor;
			oppositeDirectionTorquePercentage = tmDef.oppositeDirectionTorquePercentage;
			dynamicBrakeMaxPowerPerTractionMotor = tmDef.dynamicBrakeMaxPowerPerTractionMotor;
			dynamicBrakeVoltage = tmDef.dynamicBrakeVoltage;
			dynamicBrakeTorqueFactor = tmDef.dynamicBrakeTorqueFactor;
			dynamicBrakeThrottlePercentage = tmDef.dynamicBrakeThrottlePercentage;
			dynamicBrakeMinEffectRpmPercentage = tmDef.dynamicBrakeMinEffectRpmPercentage;
			dynamicBrakeMaxEffectRpmPercentage = tmDef.dynamicBrakeMaxEffectRpmPercentage;
			contactor0To1SwitchDuration = tmDef.contactor0To1SwitchDuration;
			contactor1To0DelayTime = tmDef.contactor1To0DelayTime;
			contactorTransitions = tmDef.contactorTransitions;
			heatRateFromAmps = tmDef.heatRateFromAmps;
			heatRateOverMaxAmpsFactor = tmDef.heatRateOverMaxAmpsFactor;
			heatRateDynamicBrakeFactor = tmDef.heatRateDynamicBrakeFactor;
			heatRateOppositeDirectionSpeedFactor = tmDef.heatRateOppositeDirectionSpeedFactor;
			overheatingTemperatureThreshold = tmDef.overheatingTemperatureThreshold;
			overheatingMaxTime = tmDef.overheatingMaxTime;
			overheatingTmKillPercentage = tmDef.overheatingTmKillPercentage;
			setTmOnFireOnKillPercentage = tmDef.setTmOnFireOnKillPercentage;
			damagePerRpmOverMaxPerSecond = tmDef.damagePerRpmOverMaxPerSecond;
			rpmDamagePerSecond = tmDef.rpmDamagePerSecond;
			overheatingDamagePerDegreePerSecond = tmDef.overheatingDamagePerDegreePerSecond;
			damagePerFuseBlow = tmDef.damagePerFuseBlow;
			damagePerTmBlow = tmDef.damagePerTmBlow;
			tmPerformanceDropHealthPercentage = tmDef.tmPerformanceDropHealthPercentage;
			damagedTmTorqueConstraintStart = tmDef.damagedTmTorqueConstraintStart;
			damagedTmTorqueConstraintEnd = tmDef.damagedTmTorqueConstraintEnd;
			powerFuseRef = AddFuseReference(tmDef.powerFuseId);
			throttlePowerReader = AddPortReference(tmDef.throttlePowerReader);
			throttleNotchReader = AddPortReference(tmDef.throttleNotchReader);
			throttlePrevNotchReader = AddPortReference(tmDef.throttlePrevNotchReader);
			reverserReader = AddPortReference(tmDef.reverserReader);
			dynamicBrakeReader = AddPortReference(tmDef.dynamicBrakeReader);
			wheelRpmReader = AddPortReference(tmDef.wheelRpmReader);
			gearRatioReader = AddPortReference(tmDef.gearRatioReader);
			maxPowerProvidedReader = AddPortReference(tmDef.maxPowerProvidedReader);
			tmHealthStateExtIn = AddPort(tmDef.tmHealthStateExtIn, 1f);
			workingTractionMotorsReadOut = AddPort(tmDef.workingTractionMotorsReadOut, numberOfTractionMotors);
			powerIn = AddPort(tmDef.powerIn);
			goalPowerReadOut = AddPort(tmDef.goalPowerReadOut);
			torqueOut = AddPort(tmDef.torqueOut);
			temperature = AddPortReference(tmDef.temperature);
			heatOut = AddPort(tmDef.heatOut);
			ampsReadOut = AddPort(tmDef.ampsReadOut);
			ampsNormalizedReadOut = AddPort(tmDef.ampsNormalizedReadOut);
			maxAmpsReadOut = AddPort(tmDef.maxAmpsReadOut, maxAmpsPerTractionMotor);
			generatorVoltageReadOut = AddPort(tmDef.generatorVoltageReadOut);
			tmRpmReadOut = AddPort(tmDef.tmRpmReadOut);
			tmRpmNormalizedReadOut = AddPort(tmDef.tmRpmNormalizedReadOut);
			dynamicBrakeNormalizedEffectReadOut = AddPort(tmDef.dynamicBrakeNormalizedEffectReadOut);
			loadOnGeneratorReadOut = AddPort(tmDef.loadOnGeneratorReadOut);
			contactor0To1ReadOut = AddPort(tmDef.contactor0To1ReadOut);
			contactor1To0ReadOut = AddPort(tmDef.contactor1To0ReadOut);
			contactorTransitionReadOut = AddPort(tmDef.contactorTransitionReadOut);
			overheatPowerFuseOffReadOut = AddPort(tmDef.overheatPowerFuseOffReadOut);
			tmsStateReadOut = AddPort(tmDef.tmsStateReadOut);
			generatedEngineDamageReadOut = AddPort(tmDef.generatedEngineDamageReadOut);
			externalTractionMotorsExtIn = AddPort(tmDef.externalTractionMotorsExtIn);
			externalTractionMotorsTorqueReadOut = AddPort(tmDef.externalTractionMotorsTorqueReadOut);
			poweredWheelsManager = tmDef.poweredWheelsManager;
			if (!(poweredWheelsManager != null))
			{
				Debug.LogError("[" + id + "]: poweredWheelsManager reference is missing! Simulation will run without updating poweredWheelsManager");
			}
		}

		public override void Tick(float delta)
		{
			float num = 0f;
			float value = temperature.Value;
			if (overheatPowerFuseOffReadOut.Value == 1f)
			{
				overheatPowerFuseOffReadOut.Value = 0f;
			}
			float num2 = Mathf.Abs(amps);
			if (num2 > 0f)
			{
				float num3 = num2 / maxAmpsPerTractionMotor * heatRateFromAmps;
				if (num2 > maxAmpsPerTractionMotor)
				{
					num3 *= heatRateOverMaxAmpsFactor;
				}
				if (dynamicBrakeNormalizedEffectReadOut.Value > 0f)
				{
					num3 *= heatRateDynamicBrakeFactor;
				}
				if (poweredReverserOppositeOfMovementDirection)
				{
					num3 *= Mathf.Lerp(1f, heatRateOppositeDirectionSpeedFactor, tmRpmNormalizedReadOut.Value);
				}
				heatOut.Value = num3;
				if (value > overheatingTemperatureThreshold && !overheatingTimerActivated && gameParams.DrivetrainFailuresAllowed)
				{
					overheatingTimerActivated = true;
					overheatingTimer = Random.Range(0.2f, overheatingMaxTime);
				}
			}
			if (overheatingTimerActivated)
			{
				if (value <= overheatingTemperatureThreshold || !powerFuseRef.State)
				{
					overheatingTimerActivated = false;
					overheatingTimer = 0f;
				}
				else if (overheatingTimer <= 0f || value > overheatingTemperatureThreshold * 1.75f)
				{
					overheatingTimerActivated = false;
					overheatingTimer = 0f;
					bool flag = false;
					float value2 = workingTractionMotorsReadOut.Value;
					if (value2 > 0f && num2 > maxAmpsPerTractionMotor * 0.75f && Random.value < overheatingTmKillPercentage)
					{
						if (poweredWheelsManager != null)
						{
							bool setOnFire = Random.value < setTmOnFireOnKillPercentage;
							poweredWheelsManager.KillOnePoweredWheel(setOnFire, random: true, 0);
						}
						workingTractionMotorsReadOut.Value = value2 - 1f;
						flag = true;
					}
					if (num2 > 10f)
					{
						powerFuseRef.ChangeState(newState: false);
						overheatPowerFuseOffReadOut.Value = 1f;
						if (gameParams.DrivetrainFailuresAllowed)
						{
							num += (flag ? damagePerTmBlow : damagePerFuseBlow);
						}
					}
				}
				else
				{
					overheatingTimer -= delta;
				}
			}
			float value3 = tmHealthStateExtIn.Value;
			if (value3 > 0.95f && tmHealthStateExtIn.Diff > 0f)
			{
				workingTractionMotorsReadOut.Value = numberOfTractionMotors;
				if (poweredWheelsManager != null)
				{
					poweredWheelsManager.RepairAllPoweredWheels();
				}
			}
			if (gameParams.DrivetrainFailuresAllowed)
			{
				if (tmRpm > maxRpm)
				{
					num += (tmRpm - maxRpm) * damagePerRpmOverMaxPerSecond * delta;
				}
				if (tmRpm > 1f)
				{
					num += tmRpm / maxRpm * rpmDamagePerSecond * delta;
				}
				float num4 = value - overheatingTemperatureThreshold;
				if (num4 > 0f)
				{
					num += overheatingDamagePerDegreePerSecond * num4 * delta;
				}
			}
			generatedEngineDamageReadOut.Value = num;
			float value4 = wheelRpmReader.Value;
			tmRpm = Mathf.SmoothDamp(target: Mathf.Abs(value4) * gearRatioReader.Value, current: tmRpm, currentVelocity: ref tmRpmSmoothVelocity, smoothTime: 0.2f, maxSpeed: float.PositiveInfinity, deltaTime: delta);
			tmRpmReadOut.Value = tmRpm;
			tmRpmNormalizedReadOut.Value = tmRpm / maxRpm;
			float num5 = powerFuseRef.ProcessInput(powerIn.Value);
			bool flag2 = num5 > 0f;
			float value5 = throttlePowerReader.Value;
			float value6 = throttleNotchReader.Value;
			float value7 = throttlePrevNotchReader.Value;
			if (value6 != value7 && !wasDisconnectedFromGenerator)
			{
				goalPowerReadOut.Value = value5;
			}
			bool flag3 = value5 > 0f;
			float value8 = reverserReader.Value;
			bool flag4 = value8 == 0f;
			bool flag5 = Mathf.Sign(value4) == Mathf.Sign(value8);
			float value9 = dynamicBrakeReader.Value;
			if (!dynamicBrakeActive && value9 > 0f)
			{
				dynamicBrakeActive = true;
				if (dynamicBrakeThrottlePercentage > 0f)
				{
					goalPowerReadOut.Value = dynamicBrakeThrottlePercentage * maxPowerProvidedReader.Value;
				}
			}
			else if (dynamicBrakeActive && value9 == 0f)
			{
				dynamicBrakeActive = false;
				if (dynamicBrakeThrottlePercentage > 0f)
				{
					goalPowerReadOut.Value = value5;
				}
			}
			if (contactor0To1InProgress)
			{
				contactor0To1TimeElapsed += delta;
				if (contactor0To1TimeElapsed > contactor0To1SwitchDuration)
				{
					contactor0To1InProgress = false;
					contactor0To1TimeElapsed = 0f;
					contactor0To1ReadOut.Value = 0f;
				}
			}
			if (contactor1To0InProgress)
			{
				contactor1To0TimeElapsed += delta;
				if (contactor1To0TimeElapsed > contactor1To0DelayTime)
				{
					contactor1To0InProgress = false;
					contactor1To0TimeElapsed = 0f;
					contactor1To0ReadOut.Value = 0f;
				}
			}
			if (contactorTransitionInProgress)
			{
				contactorTransitionTimeElapsed += delta;
				float num6 = ((transitionStateIndex > -1) ? contactorTransitions[transitionStateIndex].transitionDuration : contactorTransitions[0].transitionDuration);
				if (contactorTransitionTimeElapsed > num6)
				{
					contactorTransitionInProgress = false;
					contactorTransitionTimeElapsed = 0f;
					contactorTransitionReadOut.Value = 0f;
				}
			}
			if (flag2 && !flag4 && value7 == 0f && value6 > 0f)
			{
				contactor0To1InProgress = true;
				contactor0To1ReadOut.Value = 1f;
				contactor0To1TimeElapsed = 0f;
			}
			if (flag2 && !flag4 && value7 > 0f && value6 == 0f)
			{
				contactor1To0InProgress = true;
				contactor1To0ReadOut.Value = 1f;
				contactor1To0TimeElapsed = 0f;
			}
			int num7 = contactorTransitions.Length;
			if (num7 > 0 && flag2 && flag3 && !flag4 && !contactorTransitionInProgress)
			{
				float num8 = 10f;
				while (transitionStateIndex > -1 && !(tmRpm > contactorTransitions[transitionStateIndex].transitionSwitchTmRpm - num8))
				{
					transitionStateIndex--;
					contactorTransitionInProgress = true;
					contactorTransitionReadOut.Value = 1f;
					contactorTransitionTimeElapsed = 0f;
				}
				while (transitionStateIndex < num7 - 1)
				{
					int num9 = transitionStateIndex + 1;
					if (tmRpm < contactorTransitions[num9].transitionSwitchTmRpm + num8)
					{
						break;
					}
					transitionStateIndex = num9;
					contactorTransitionInProgress = true;
					contactorTransitionReadOut.Value = 1f;
					contactorTransitionTimeElapsed = 0f;
				}
			}
			bool flag6 = false;
			if (contactorTransitionInProgress)
			{
				flag6 = ((transitionStateIndex > -1) ? (!contactorTransitions[transitionStateIndex].connectedToGen) : (!contactorTransitions[0].connectedToGen));
			}
			if (!wasDisconnectedFromGenerator && flag6)
			{
				goalPowerReadOut.Value = value5 * 0.75f;
				wasDisconnectedFromGenerator = true;
			}
			else if (wasDisconnectedFromGenerator && !flag6)
			{
				goalPowerReadOut.Value = value5;
				wasDisconnectedFromGenerator = false;
			}
			bool flag7 = contactor0To1InProgress || contactor1To0InProgress || flag6;
			float value10 = workingTractionMotorsReadOut.Value;
			float value11 = externalTractionMotorsExtIn.Value;
			int num10 = Mathf.RoundToInt(value10 + value11);
			float num11 = ((flag7 || num10 == 0) ? 0f : (num5 / (float)num10));
			float num12 = Mathf.InverseLerp(0f, maxRpm, tmRpm);
			float num13 = Mathf.InverseLerp(0f, 1f / torqueLimitRpmPercentage, 1f / num12);
			float num14 = 0f;
			if (num11 > 0f)
			{
				num14 = ((num13 != 0f) ? Mathf.Clamp(minGeneratorVoltage / num13, minGeneratorVoltage, maxGeneratorVoltage) : maxGeneratorVoltage);
			}
			poweredReverserOppositeOfMovementDirection = !flag4 && !flag5 && flag2 && (flag3 || dynamicBrakeActive);
			float target = 0f;
			float num15 = 0f;
			if (num11 > 0f && !flag4)
			{
				if (num14 != 0f && flag3)
				{
					if (!poweredReverserOppositeOfMovementDirection)
					{
						target = num11 / num14;
					}
					else
					{
						float a = num11 / num14;
						float b = maxAmpsPerTractionMotor + maxAmpsPerTractionMotor * (value5 / maxPowerProvidedReader.Value);
						target = Mathf.Lerp(a, b, PoweredReverserOppositeDirectionEffect);
					}
				}
				else if (dynamicBrakeActive)
				{
					float num16 = Mathf.InverseLerp(maxRpm * dynamicBrakeMinEffectRpmPercentage, maxRpm * dynamicBrakeMaxEffectRpmPercentage, tmRpm);
					num15 = value9 * num16;
					target = -1f * num15 * dynamicBrakeMaxPowerPerTractionMotor / dynamicBrakeVoltage;
				}
			}
			dynamicBrakeNormalizedEffectReadOut.Value = num15;
			amps = Mathf.SmoothDamp(amps, target, ref ampsSmoothingVelocity, 0.5f, float.PositiveInfinity, delta);
			ampsReadOut.Value = amps;
			ampsNormalizedReadOut.Value = amps / maxAmpsPerTractionMotor;
			generatorVoltageReadOut.Value = num14;
			float num17 = 0f;
			if (flag2)
			{
				if (dynamicBrakeActive)
				{
					num17 = dynamicBrakeTorqueFactor * amps * value8;
				}
				else if (flag3)
				{
					float num18 = 1f - Mathf.InverseLerp(maxRpm, maxRpm * 1.05f, tmRpm);
					num17 = torqueFactor * amps * value8 * num18;
				}
			}
			if (poweredReverserOppositeOfMovementDirection)
			{
				num17 = ((!dynamicBrakeActive) ? (num17 * Mathf.Lerp(1f, oppositeDirectionTorquePercentage, PoweredReverserOppositeDirectionEffect)) : (0f - num17));
			}
			float num19 = 1f;
			if (value3 < tmPerformanceDropHealthPercentage && gameParams.DrivetrainFailuresAllowed)
			{
				float t = Mathf.InverseLerp(tmPerformanceDropHealthPercentage, 0f, value3);
				num19 = Mathf.Lerp(damagedTmTorqueConstraintStart, damagedTmTorqueConstraintEnd, t);
			}
			torqueOut.Value = num17 * num19 * value10;
			externalTractionMotorsTorqueReadOut.Value = ((value11 > 0f) ? num17 : 0f);
			float value12 = 0f;
			if (flag2 && flag3 && !flag4 && !flag7)
			{
				value12 = Mathf.Clamp(1f - num12, 0.01f, 1f);
			}
			loadOnGeneratorReadOut.Value = value12;
			float value13 = 0f;
			if (powerFuseRef.State)
			{
				value13 = ((value10 != (float)numberOfTractionMotors) ? (-1f) : 1f);
			}
			tmsStateReadOut.Value = value13;
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			float value = workingTractionMotorsReadOut.Value;
			if (value < (float)numberOfTractionMotors)
			{
				jObject.SetInt("workingTMs", Mathf.RoundToInt(value));
				if (poweredWheelsManager != null)
				{
					JObject saveStateData = poweredWheelsManager.GetSaveStateData();
					if (saveStateData != null)
					{
						jObject.SetJObject("poweredWheels", saveStateData);
					}
					else
					{
						Debug.LogError("Unexpected state: PoweredWheelsManager save data is null, when there are dead traction motors");
					}
				}
			}
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			int? num = savedData.GetInt("workingTMs");
			if (!num.HasValue)
			{
				return;
			}
			int value = num.Value;
			if (value > numberOfTractionMotors || value < 0)
			{
				Debug.LogError(string.Format("Unexpected state: {0} is out of range ({1}). Ignoring loading state.", "numOfWorkingTMs", value));
				return;
			}
			workingTractionMotorsReadOut.Value = num.Value;
			if (poweredWheelsManager != null)
			{
				JObject jObject = savedData.GetJObject("poweredWheels");
				if (jObject != null)
				{
					poweredWheelsManager.SetSaveStateData(jObject);
				}
				else
				{
					Debug.LogError("Unexpected state: Missing data for " + id + ".POWERED_WHEELS_SAVE_KEY. Loading ignored for this parameter");
				}
			}
		}
	}
}
