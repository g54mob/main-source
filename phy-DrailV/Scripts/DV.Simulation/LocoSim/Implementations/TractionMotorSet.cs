using System;
using System.Linq;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using LocoSim.Implementations.Wheels;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class TractionMotorSet : SimComponent
	{
		public class ElectricalConfiguration
		{
			public readonly int[][] motorGroups;

			public readonly int seriesMotorsPerGroup;

			public readonly float excitationMultiplier;

			public TractionMotorSetDefinition.TransitionDefinition forwardTransition;

			public TractionMotorSetDefinition.TransitionDefinition backwardTransition;

			public int ParallelGroups => motorGroups.Length;

			public ElectricalConfiguration(TractionMotorSetDefinition.ElectricalConfigurationDefinition ecDef)
			{
				motorGroups = ecDef.motorGroups.Select((TractionMotorSetDefinition.MotorGroupDefinition groupDef) => groupDef.motorIndexes).ToArray();
				seriesMotorsPerGroup = ((motorGroups.Length != 0) ? motorGroups[0].Length : 0);
				excitationMultiplier = ecDef.excitationMultiplier;
				forwardTransition = ecDef.forwardTransition;
				backwardTransition = ecDef.backwardTransition;
				int[][] array = motorGroups;
				foreach (int[] group in array)
				{
					if (group.Length != seriesMotorsPerGroup)
					{
						Debug.LogError($"Motor group {group} has incorrect number of motors");
					}
					int[] array2 = group;
					foreach (int motorIndex in array2)
					{
						if (group.Count((int x) => x == motorIndex) > 1)
						{
							Debug.LogError($"Duplicated motor indexes in group {group}");
						}
						if (motorGroups.Where((int[] g) => g != group).Any((int[] g) => g.Contains(motorIndex)))
						{
							Debug.LogError($"Motor index {motorIndex} appears in multiple groups");
						}
					}
				}
			}

			private string GroupToString(int[] motorGroup)
			{
				return string.Join(", ", motorGroup);
			}

			public bool TransitionRequiresCurrentDrop(ElectricalConfiguration activeConfig)
			{
				if (activeConfig.ParallelGroups == ParallelGroups)
				{
					return activeConfig.seriesMotorsPerGroup != seriesMotorsPerGroup;
				}
				return true;
			}

			public int[][] GetOperatingMotorGroups(int[] undamagedMotorIndexes)
			{
				return motorGroups.Where((int[] motorGroup) => motorGroup.All((int motorIndex) => undamagedMotorIndexes.Contains(motorIndex))).ToArray();
			}
		}

		private const string POWERED_WHEELS_SAVE_KEY = "poweredWheels";

		private const float TMS_STATE_FUSE_ON_HAS_DEAD_TM_SIGNAL_VALUE = -1f;

		private const float TMS_STATE_FUSE_OFF_SIGNAL_VALUE = 0f;

		private const float TMS_STATE_OK_SIGNAL_VALUE = 1f;

		private const float CONTACTOR_CHANGE_OPEN = -1f;

		private const float CONTACTOR_CHANGE_HOLD = 0f;

		private const float CONTACTOR_CHANGE_CLOSE = 1f;

		private const float TORQUE_LOSS_DAMAGE_THRESHOLD = 0.5f;

		private const float TEMPERATURE_DAMAGE_MIN_TEMP = 60f;

		private float maxMotorRpm;

		private float motorResistance;

		private float motorTorqueFactor;

		private float externalResistance;

		private float ampsSmoothTime;

		private float ampsSmoothMaxSpeed;

		private int numberOfTractionMotors;

		private float dynamicBrakePeakForceRpm;

		private float dynamicBrakeGridResistance;

		private float dynamicBrakeMaxCurrent;

		private float dynamicBrakeCoolerSmoothTime;

		private int circuitConnectionStages;

		private float circuitConnectionTime;

		private float circuitConnectionTimeRandomization;

		private float transitionMaxAmps;

		private float overheatingTemperatureThreshold;

		private float overheatingMaxTime;

		private float overheatingTmKillPercentage;

		private float setTmOnFireOnKillPercentage;

		private float rpmDamagePerSecond;

		private float overspeedDamageFactor;

		private float overheatingDamagePerSecond;

		private float damagePerFuseBlow;

		private float damagePerTmBlow;

		private readonly PoweredWheelsManager poweredWheelsManager;

		private readonly FuseReference powerFuseRef;

		private readonly PortReference throttleReader;

		private readonly PortReference reverserReader;

		private readonly PortReference dynamicBrakeReader;

		private readonly PortReference configurationOverrideReader;

		private readonly PortReference motorRpmReader;

		private readonly PortReference appliedVoltageReader;

		private readonly Port motorTorqueOut;

		private readonly Port effectiveResistanceReadOut;

		private readonly Port singleMotorEffectiveResistanceReadOut;

		private readonly Port totalAmpsReadOut;

		private readonly Port ampsPerTMReadOut;

		private readonly Port maxAmpsPerTMReadOut;

		private readonly PortReference environmentWaterState;

		private readonly Port motorRpmNormalizedReadOut;

		private readonly Port tmHealthStateExtIn;

		private readonly Port workingTractionMotorsReadOut;

		private readonly Port heatReadOut;

		private readonly PortReference tmTempReader;

		private readonly Port contactorChangeReadOut;

		private readonly Port currentLimitRequestReadOut;

		private readonly Port dynamicBrakeActiveReadOut;

		private readonly Port overheatPowerFuseOffReadOut;

		private readonly Port tmsStateReadOut;

		private readonly Port overspeedSoundReadOut;

		private readonly Port overspeedExplosionTriggerReadOut;

		private readonly Port generatedDamageReadOut;

		private readonly Port fieldFluxReadOut;

		private readonly Port motorVoltsReadOut;

		private readonly Port activeConfigReadOut;

		private readonly Port pendingConfigReadOut;

		private readonly Port powerInReadOut;

		private readonly Port powerOutReadOut;

		private readonly ElectricalConfiguration[] configurations;

		private int activeConfigIndex;

		private int pendingConfigIndex;

		private bool dynamicBrakeActive;

		private float dynamicBrakeCoolerVelocity;

		private int circuitConnectionStage;

		private float circuitConnectionTimer;

		private bool currentDropRequested;

		private float motorSetCurrentMultiplier;

		private float motorSetExcitationMultiplier;

		private float motorSetResistanceMultiplier;

		private float motorSetVoltageMultiplier;

		private float circuitResistance;

		private float magneticFluxFactor;

		private float magneticFlux;

		private float backEmfPerTM;

		private float motorSetVoltage;

		private float ampsPerTM;

		private float ampsPerTMVelocity;

		private float overheatingTimer;

		private bool ConnectionRequested
		{
			get
			{
				if (reverserReader.Value != 0f)
				{
					if (!(throttleReader.Value > 0f))
					{
						return dynamicBrakeReader.Value > 0f;
					}
					return true;
				}
				return false;
			}
		}

		private bool CircuitActive => circuitConnectionStage == circuitConnectionStages;

		private ElectricalConfiguration ActiveConfig => configurations[activeConfigIndex];

		private ElectricalConfiguration PendingConfig => configurations[pendingConfigIndex];

		public override bool HasSaveData => true;

		public TractionMotorSet(TractionMotorSetDefinition tmsDef)
			: base(tmsDef.ID)
		{
			maxMotorRpm = tmsDef.maxMotorRpm;
			motorResistance = tmsDef.motorResistance;
			motorTorqueFactor = tmsDef.motorTorqueFactor;
			externalResistance = tmsDef.externalResistance;
			ampsSmoothTime = tmsDef.ampsSmoothTime;
			ampsSmoothMaxSpeed = tmsDef.ampsSmoothMaxSpeed;
			numberOfTractionMotors = tmsDef.numberOfTractionMotors;
			dynamicBrakePeakForceRpm = tmsDef.dynamicBrakePeakForceRpm;
			dynamicBrakeGridResistance = tmsDef.dynamicBrakeGridResistance;
			dynamicBrakeMaxCurrent = tmsDef.dynamicBrakeMaxCurrent;
			dynamicBrakeCoolerSmoothTime = tmsDef.dynamicBrakeCoolerSmoothTime;
			circuitConnectionStages = Math.Max(1, tmsDef.circuitConnectionStages);
			circuitConnectionTime = tmsDef.circuitConnectionTime;
			circuitConnectionTimeRandomization = tmsDef.circuitConnectionTimeRandomization;
			transitionMaxAmps = tmsDef.transitionMaxAmps;
			overheatingTemperatureThreshold = tmsDef.overheatingTemperatureThreshold;
			overheatingMaxTime = tmsDef.overheatingMaxTime;
			overheatingTmKillPercentage = tmsDef.overheatingTmKillPercentage;
			setTmOnFireOnKillPercentage = tmsDef.setTmOnFireOnKillPercentage;
			rpmDamagePerSecond = tmsDef.rpmDamagePerSecond;
			overspeedDamageFactor = tmsDef.overspeedDamageFactor;
			overheatingDamagePerSecond = tmsDef.overheatingDamagePerSecond;
			damagePerFuseBlow = tmsDef.damagePerFuseBlow;
			damagePerTmBlow = tmsDef.damagePerTmBlow;
			poweredWheelsManager = tmsDef.poweredWheelsManager;
			if (!(poweredWheelsManager != null))
			{
				Debug.LogError("[" + id + "]: poweredWheelsManager reference is missing! Simulation will run without updating poweredWheelsManager");
			}
			powerFuseRef = AddFuseReference(tmsDef.powerFuseId);
			throttleReader = AddPortReference(tmsDef.throttleReader);
			reverserReader = AddPortReference(tmsDef.reverserReader);
			dynamicBrakeReader = AddPortReference(tmsDef.dynamicBrakeReader);
			configurationOverrideReader = AddPortReference(tmsDef.configurationOverrideReader);
			motorRpmReader = AddPortReference(tmsDef.motorRpmReader);
			appliedVoltageReader = AddPortReference(tmsDef.appliedVoltageReader);
			motorTorqueOut = AddPort(tmsDef.motorTorqueOut);
			effectiveResistanceReadOut = AddPort(tmsDef.effectiveResistanceReadOut);
			singleMotorEffectiveResistanceReadOut = AddPort(tmsDef.singleMotorEffectiveResistanceReadOut);
			totalAmpsReadOut = AddPort(tmsDef.totalAmpsReadOut);
			ampsPerTMReadOut = AddPort(tmsDef.ampsPerTMReadOut);
			maxAmpsPerTMReadOut = AddPort(tmsDef.maxAmpsPerTMReadOut, tmsDef.maxAmpsPerTm);
			motorRpmNormalizedReadOut = AddPort(tmsDef.motorRpmNormalizedReadOut);
			tmHealthStateExtIn = AddPort(tmsDef.tmHealthStateExtIn, 1f);
			workingTractionMotorsReadOut = AddPort(tmsDef.workingTractionMotorsReadOut, numberOfTractionMotors);
			heatReadOut = AddPort(tmsDef.heatReadOut);
			tmTempReader = AddPortReference(tmsDef.tmTempReader);
			environmentWaterState = AddPortReference(tmsDef.environmentWaterState);
			contactorChangeReadOut = AddPort(tmsDef.contactorChangeReadOut);
			currentLimitRequestReadOut = AddPort(tmsDef.currentLimitRequestReadOut);
			dynamicBrakeActiveReadOut = AddPort(tmsDef.dynamicBrakeActiveReadOut);
			overheatPowerFuseOffReadOut = AddPort(tmsDef.overheatPowerFuseOffReadOut);
			tmsStateReadOut = AddPort(tmsDef.tmsStateReadOut);
			overspeedSoundReadOut = AddPort(tmsDef.overspeedSoundReadOut);
			overspeedExplosionTriggerReadOut = AddPort(tmsDef.overspeedExplosionTriggerReadOut);
			generatedDamageReadOut = AddPort(tmsDef.generatedDamageReadOut);
			fieldFluxReadOut = AddPort(tmsDef.fieldFluxReadOut);
			motorVoltsReadOut = AddPort(tmsDef.motorVoltsReadOut);
			activeConfigReadOut = AddPort(tmsDef.activeConfigReadOut);
			pendingConfigReadOut = AddPort(tmsDef.pendingConfigReadOut);
			powerInReadOut = AddPort(tmsDef.powerInReadOut);
			powerOutReadOut = AddPort(tmsDef.powerOutReadOut);
			configurations = tmsDef.configurations.Select((TractionMotorSetDefinition.ElectricalConfigurationDefinition ecDef) => new ElectricalConfiguration(ecDef)).ToArray();
			SetContactorTimer();
		}

		public override void InitializationAfterConnecting()
		{
			UpdateMotorSetCharacteristics();
		}

		private void UpdateMotorSetCharacteristics()
		{
			bool drivetrainFailuresAllowed = gameParams.DrivetrainFailuresAllowed;
			int num;
			if (tmHealthStateExtIn.Value == 0f && drivetrainFailuresAllowed)
			{
				num = 0;
			}
			else if (!drivetrainFailuresAllowed || poweredWheelsManager == null)
			{
				num = ActiveConfig.ParallelGroups;
			}
			else
			{
				int[] undamagedWheelIndexes = poweredWheelsManager.GetUndamagedWheelIndexes();
				int[][] operatingMotorGroups = ActiveConfig.GetOperatingMotorGroups(undamagedWheelIndexes);
				int[] poweredWheels = operatingMotorGroups.SelectMany((int[] x) => x).ToArray();
				poweredWheelsManager.SetPoweredWheels(poweredWheels);
				num = operatingMotorGroups.Length;
			}
			if (num > 0)
			{
				int seriesMotorsPerGroup = ActiveConfig.seriesMotorsPerGroup;
				motorSetCurrentMultiplier = num;
				motorSetExcitationMultiplier = ActiveConfig.excitationMultiplier;
				motorSetResistanceMultiplier = (float)seriesMotorsPerGroup / (float)num;
				motorSetVoltageMultiplier = seriesMotorsPerGroup;
				workingTractionMotorsReadOut.Value = num * seriesMotorsPerGroup;
			}
			else
			{
				motorSetCurrentMultiplier = 0f;
				motorSetExcitationMultiplier = ActiveConfig.excitationMultiplier;
				motorSetResistanceMultiplier = float.PositiveInfinity;
				motorSetVoltageMultiplier = 0f;
				workingTractionMotorsReadOut.Value = 0f;
			}
		}

		private void SimulateDamage(float delta)
		{
			float num = 0f;
			bool flag = false;
			bool drivetrainFailuresAllowed = gameParams.DrivetrainFailuresAllowed;
			if (CircuitActive && effectiveResistanceReadOut.Value < 0f)
			{
				flag = true;
			}
			float value = tmTempReader.Value;
			float num2 = ((value > overheatingTemperatureThreshold) ? (0f - delta) : delta);
			overheatingTimer = Mathf.Clamp(overheatingTimer + num2, 0f, overheatingMaxTime);
			if (drivetrainFailuresAllowed)
			{
				if (overheatingTimer == 0f && powerFuseRef.State)
				{
					flag = true;
					if (poweredWheelsManager != null && UnityEngine.Random.value < overheatingTmKillPercentage)
					{
						bool setOnFire = UnityEngine.Random.value < setTmOnFireOnKillPercentage;
						poweredWheelsManager.KillOnePoweredWheel(setOnFire, random: true, 0);
						UpdateMotorSetCharacteristics();
						num += damagePerTmBlow;
					}
				}
				if (value > 60f)
				{
					float num3 = value / overheatingTemperatureThreshold;
					num3 *= num3;
					num3 *= num3;
					num3 *= num3;
					float num4 = overheatingDamagePerSecond * num3;
					num += num4 * delta;
				}
			}
			if (environmentWaterState.Value > 0.5f && powerInReadOut.Value > 0f && powerFuseRef.State)
			{
				flag = true;
				if (drivetrainFailuresAllowed && poweredWheelsManager != null && UnityEngine.Random.value < overheatingTmKillPercentage)
				{
					poweredWheelsManager.KillOnePoweredWheel(setOnFire: false, random: true, 0);
					UpdateMotorSetCharacteristics();
					num += damagePerTmBlow;
				}
			}
			if (poweredWheelsManager != null && tmHealthStateExtIn.Value > 0.95f && tmHealthStateExtIn.Diff > 0f)
			{
				workingTractionMotorsReadOut.Value = numberOfTractionMotors;
				poweredWheelsManager.RepairAllPoweredWheels();
				UpdateMotorSetCharacteristics();
			}
			if (overspeedExplosionTriggerReadOut.Value == 1f)
			{
				overspeedExplosionTriggerReadOut.Value = 0f;
			}
			float num5 = Mathf.Abs(motorRpmReader.Value);
			float num6 = 0f;
			if (num5 > 1f && drivetrainFailuresAllowed)
			{
				num6 += num5 / maxMotorRpm * rpmDamagePerSecond;
			}
			overspeedSoundReadOut.Value = ((workingTractionMotorsReadOut.Value < 1f) ? 0f : Mathf.InverseLerp(0.9f, 1f, num5 / maxMotorRpm));
			if (num5 > maxMotorRpm && drivetrainFailuresAllowed)
			{
				float num7 = num5 - maxMotorRpm;
				num6 += overspeedDamageFactor * num7 * num7;
				if (tmHealthStateExtIn.Value == 0f && workingTractionMotorsReadOut.Value > 0f)
				{
					overspeedExplosionTriggerReadOut.Value = 1f;
					poweredWheelsManager.KillAllPoweredWheels();
					UpdateMotorSetCharacteristics();
				}
			}
			else if (tmHealthStateExtIn.Value == 0f && tmHealthStateExtIn.Diff < 0f)
			{
				UpdateMotorSetCharacteristics();
			}
			if (drivetrainFailuresAllowed)
			{
				num += num6 * delta;
			}
			if (overheatPowerFuseOffReadOut.Value == 1f)
			{
				overheatPowerFuseOffReadOut.Value = 0f;
			}
			if (flag && drivetrainFailuresAllowed)
			{
				powerFuseRef.ChangeState(newState: false);
				overheatPowerFuseOffReadOut.Value = 1f;
				num += damagePerFuseBlow;
			}
			generatedDamageReadOut.Value = (drivetrainFailuresAllowed ? num : 0f);
		}

		private void SimulateTransition(float delta)
		{
			if (configurationOverrideReader.IsConnected)
			{
				activeConfigIndex = Mathf.RoundToInt(Mathf.Clamp(configurationOverrideReader.Value, 0f, configurations.Length - 1));
				activeConfigReadOut.Value = activeConfigIndex;
				UpdateMotorSetCharacteristics();
			}
			else if (dynamicBrakeActive)
			{
				if (activeConfigIndex != 0)
				{
					pendingConfigIndex = 0;
					activeConfigIndex = 0;
					activeConfigReadOut.Value = activeConfigIndex;
					UpdateMotorSetCharacteristics();
				}
			}
			else if (activeConfigIndex == pendingConfigIndex)
			{
				if (activeConfigIndex > 0 && ActiveConfig.backwardTransition.ConditionMet(motorRpmReader.Value))
				{
					pendingConfigIndex = activeConfigIndex - 1;
					currentDropRequested = PendingConfig.TransitionRequiresCurrentDrop(ActiveConfig);
				}
				else if (activeConfigIndex + 1 < configurations.Length && ActiveConfig.forwardTransition.ConditionMet(motorRpmReader.Value))
				{
					pendingConfigIndex = activeConfigIndex + 1;
					currentDropRequested = PendingConfig.TransitionRequiresCurrentDrop(ActiveConfig);
				}
				pendingConfigReadOut.Value = pendingConfigIndex;
			}
			else if (!currentDropRequested || totalAmpsReadOut.Value < transitionMaxAmps)
			{
				activeConfigIndex = pendingConfigIndex;
				activeConfigReadOut.Value = activeConfigIndex;
				currentDropRequested = false;
				UpdateMotorSetCharacteristics();
			}
			currentLimitRequestReadOut.Value = (currentDropRequested ? 0f : float.PositiveInfinity);
			float target = ((powerFuseRef.State && dynamicBrakeReader.Value > 0.1f) ? Mathf.Abs(ampsPerTM / dynamicBrakeMaxCurrent) : 0f);
			dynamicBrakeActiveReadOut.Value = Mathf.SmoothDamp(dynamicBrakeActiveReadOut.Value, target, ref dynamicBrakeCoolerVelocity, dynamicBrakeCoolerSmoothTime, float.PositiveInfinity, delta);
			if (!dynamicBrakeActive && (double)dynamicBrakeActiveReadOut.Value < 0.001)
			{
				dynamicBrakeActiveReadOut.Value = 0f;
				dynamicBrakeCoolerVelocity = 0f;
			}
		}

		private void SetContactorTimer()
		{
			circuitConnectionTimer = circuitConnectionTime * UnityEngine.Random.Range(1f - circuitConnectionTimeRandomization, 1f + circuitConnectionTimeRandomization);
		}

		private void SimulateCircuitConnections(float delta)
		{
			bool flag = dynamicBrakeReader.Value > 0f;
			if (!powerFuseRef.State || !ConnectionRequested)
			{
				circuitConnectionStage = 0;
				contactorChangeReadOut.Value = -1f;
			}
			else if (!CircuitActive)
			{
				if (circuitConnectionTimer <= delta)
				{
					circuitConnectionStage++;
					SetContactorTimer();
					contactorChangeReadOut.Value = 1f;
				}
				else
				{
					circuitConnectionTimer -= delta;
					contactorChangeReadOut.Value = 0f;
				}
			}
			if (!CircuitActive)
			{
				circuitResistance = float.PositiveInfinity;
				dynamicBrakeActive = false;
			}
			else if (flag)
			{
				circuitResistance = dynamicBrakeGridResistance;
				dynamicBrakeActive = true;
			}
			else
			{
				circuitResistance = externalResistance;
				dynamicBrakeActive = false;
			}
		}

		private void SimulateVoltage()
		{
			float num = (float)Math.PI / 30f * motorRpmReader.Value;
			magneticFluxFactor = reverserReader.Value * motorSetExcitationMultiplier;
			float num5;
			if (dynamicBrakeActive && CircuitActive)
			{
				float num2 = dynamicBrakePeakForceRpm * ((float)Math.PI / 30f);
				float num3 = dynamicBrakeMaxCurrent * circuitResistance / num2 / motorTorqueFactor;
				float a = num3 * dynamicBrakeReader.Value;
				float num4 = Mathf.Max(num2, Mathf.Abs(num));
				float b = num3 * num2 / num4;
				num5 = Mathf.Min(a, b);
			}
			else
			{
				num5 = ampsPerTM;
			}
			magneticFlux = magneticFluxFactor * num5;
			fieldFluxReadOut.Value = magneticFlux;
			backEmfPerTM = motorTorqueFactor * magneticFlux * num;
			motorSetVoltage = backEmfPerTM * motorSetVoltageMultiplier;
			motorVoltsReadOut.Value = motorSetVoltage;
		}

		private void SimulateCurrent(float delta)
		{
			float num;
			if (motorSetCurrentMultiplier == 0f)
			{
				effectiveResistanceReadOut.Value = float.PositiveInfinity;
				singleMotorEffectiveResistanceReadOut.Value = float.PositiveInfinity;
				num = 0f;
			}
			else if (dynamicBrakeActive && CircuitActive)
			{
				effectiveResistanceReadOut.Value = float.PositiveInfinity;
				singleMotorEffectiveResistanceReadOut.Value = float.PositiveInfinity;
				num = (0f - backEmfPerTM) / circuitResistance;
			}
			else
			{
				float num2 = motorTorqueFactor * magneticFluxFactor;
				float num3 = (float)Math.PI / 30f * motorRpmReader.Value;
				float num4 = motorResistance + num2 * num3;
				effectiveResistanceReadOut.Value = circuitResistance + num4 * motorSetResistanceMultiplier;
				singleMotorEffectiveResistanceReadOut.Value = effectiveResistanceReadOut.Value * motorSetCurrentMultiplier;
				num = ((singleMotorEffectiveResistanceReadOut.Value == 0f) ? 0f : (appliedVoltageReader.Value / singleMotorEffectiveResistanceReadOut.Value));
			}
			ampsPerTM = ((ampsSmoothTime == 0f) ? num : Mathf.SmoothDamp(ampsPerTM, num, ref ampsPerTMVelocity, ampsSmoothTime, ampsSmoothMaxSpeed, delta));
			ampsPerTMReadOut.Value = ampsPerTM;
			totalAmpsReadOut.Value = ampsPerTM * motorSetCurrentMultiplier;
		}

		private void SimulateTorque()
		{
			powerInReadOut.Value = appliedVoltageReader.Value * totalAmpsReadOut.Value;
			float num = (gameParams.DrivetrainFailuresAllowed ? Mathf.InverseLerp(0f, 0.5f, tmHealthStateExtIn.Value) : 1f);
			float num2 = motorTorqueFactor * magneticFlux * ampsPerTM;
			motorTorqueOut.Value = num * num2 * workingTractionMotorsReadOut.Value;
			powerOutReadOut.Value = motorTorqueOut.Value * motorRpmReader.Value * ((float)Math.PI / 30f);
		}

		private void SimulateHeat()
		{
			heatReadOut.Value = ampsPerTM * ampsPerTM * motorResistance;
		}

		private void UpdateReadOuts()
		{
			motorRpmNormalizedReadOut.Value = Mathf.Abs(motorRpmReader.Value / maxMotorRpm);
			float value = 1f;
			if (powerFuseRef.State)
			{
				if (workingTractionMotorsReadOut.Value != (float)numberOfTractionMotors)
				{
					value = -1f;
				}
			}
			else if (ConnectionRequested)
			{
				value = 0f;
			}
			tmsStateReadOut.Value = value;
		}

		public override void Tick(float delta)
		{
			SimulateDamage(delta);
			SimulateCircuitConnections(delta);
			SimulateTransition(delta);
			SimulateVoltage();
			SimulateCurrent(delta);
			SimulateTorque();
			SimulateHeat();
			UpdateReadOuts();
		}

		public override JObject GetSaveStateData()
		{
			if (poweredWheelsManager == null)
			{
				return null;
			}
			JObject jObject = new JObject();
			JObject saveStateData = poweredWheelsManager.GetSaveStateData();
			if (saveStateData != null)
			{
				jObject.SetJObject("poweredWheels", saveStateData);
			}
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			if (!(poweredWheelsManager == null))
			{
				JObject jObject = savedData.GetJObject("poweredWheels");
				if (jObject != null)
				{
					poweredWheelsManager.SetSaveStateData(jObject);
					UpdateMotorSetCharacteristics();
				}
			}
		}
	}
}
