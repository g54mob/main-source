using System;
using System.Linq;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class HydraulicTransmission : SimComponent
	{
		public class HydraulicConfig
		{
			public readonly float torqueCapacity;

			public readonly float stallTorqueMultiplier;

			public readonly float couplingSpeedRatio;

			public readonly float maxEfficiency;

			public readonly bool hasStatorUnlock;

			public readonly float gearRatio;

			public readonly float upshiftThreshold;

			public readonly float downshiftThreshold;

			public float torqueMultiplierCurveTermA;

			public float torqueMultiplierCurveTermD;

			public float fillLevel;

			public float pumpRpm;

			public float turbineRpm;

			public float pumpTorque;

			public float turbineTorque;

			public float torqueMultiplier;

			public float heatGeneration;

			public HydraulicConfig(HydraulicTransmissionDefinition.HydraulicConfigDefinition configDef)
			{
				torqueCapacity = configDef.torqueCapacity;
				stallTorqueMultiplier = configDef.stallTorqueMultiplier;
				couplingSpeedRatio = configDef.couplingSpeedRatio;
				maxEfficiency = configDef.maxEfficiency;
				hasStatorUnlock = configDef.hasStatorUnlock;
				gearRatio = configDef.gearRatio;
				upshiftThreshold = configDef.upshiftThreshold;
				downshiftThreshold = configDef.downshiftThreshold;
				if (configDef.stallTorqueMultiplier < 1f)
				{
					Debug.LogError($"stallTorqueMultiplier {configDef.stallTorqueMultiplier} must be >= 1");
					configDef.stallTorqueMultiplier = 1f;
				}
				if (configDef.couplingSpeedRatio < 0f || configDef.couplingSpeedRatio > 1f)
				{
					Debug.LogError($"couplingSpeedRatio {configDef.couplingSpeedRatio} must be between 0 and 1");
					configDef.couplingSpeedRatio = Mathf.Clamp01(configDef.couplingSpeedRatio);
				}
				if (configDef.maxEfficiency < 0f || configDef.maxEfficiency > 1f)
				{
					Debug.LogError($"maxEfficiency {configDef.maxEfficiency} must be between couplingSpeedRatio and 1");
					configDef.maxEfficiency = Mathf.Clamp(configDef.maxEfficiency, configDef.couplingSpeedRatio, 1f);
				}
				ComputeTorqueMultiplierTerms();
			}

			public static float ComputePumpTorque(float torqueCapacity, float fillLevel, float pumpRpm, float turbineRpm)
			{
				if (fillLevel == 0f)
				{
					return 0f;
				}
				float f = turbineRpm - pumpRpm;
				float num = (float)Math.PI / 30f * Mathf.Abs(f);
				float num2 = (float)Math.PI / 30f * Mathf.Abs(pumpRpm + turbineRpm);
				return Mathf.Sign(f) * torqueCapacity * fillLevel * Mathf.Sqrt(num * num * num * num2);
			}

			private void ComputeTorqueMultiplierTerms()
			{
				float num = stallTorqueMultiplier;
				float num2 = couplingSpeedRatio;
				float num3 = maxEfficiency;
				torqueMultiplierCurveTermA = (num2 * ((2f - num) * num3 - num * num * (num3 - num2)) - 2f * (num - 1f) * (num - 1f) * Mathf.Sqrt(num2 * num3 * num3 * (num3 - num2) / (num - 1f))) / (num2 * (num * num * num2 + (4f - 4f * num) * num3));
				torqueMultiplierCurveTermD = num2 * (torqueMultiplierCurveTermA - 1f) / (1f - num);
				if (NumberUtil.IsInfinityMinMaxNaN(torqueMultiplierCurveTermA) || NumberUtil.IsInfinityMinMaxNaN(torqueMultiplierCurveTermD))
				{
					torqueMultiplierCurveTermA = 1f;
					torqueMultiplierCurveTermD = 0f;
				}
			}

			private void ComputeTorqueMultiplier(float speedRatio)
			{
				float num = (torqueMultiplierCurveTermA * speedRatio + torqueMultiplierCurveTermD * stallTorqueMultiplier) / (speedRatio + torqueMultiplierCurveTermD);
				if (NumberUtil.IsInfinityMinMaxNaN(num))
				{
					torqueMultiplier = stallTorqueMultiplier;
				}
				else if (hasStatorUnlock)
				{
					torqueMultiplier = Mathf.Clamp(num, 1f, stallTorqueMultiplier);
				}
				else
				{
					torqueMultiplier = Mathf.Clamp(num, 0f, stallTorqueMultiplier);
				}
			}

			private void ComputeTorque()
			{
				pumpTorque = ComputePumpTorque(torqueCapacity, fillLevel, pumpRpm, turbineRpm);
				float speedRatio = Mathf.Clamp01((pumpRpm == 0f) ? 0f : (turbineRpm / pumpRpm));
				ComputeTorqueMultiplier(speedRatio);
				turbineTorque = (0f - pumpTorque) * torqueMultiplier;
			}

			public static float ComputeHeat(float pumpRpm, float pumpTorque, float turbineRpm, float turbineTorque)
			{
				float num = (float)Math.PI / 30f * pumpRpm * (0f - pumpTorque);
				float num2 = (float)Math.PI / 30f * turbineRpm * turbineTorque;
				return Mathf.Abs(num - num2);
			}

			public void Tick()
			{
				if (fillLevel == 0f)
				{
					pumpTorque = 0f;
					torqueMultiplier = 0f;
					turbineTorque = 0f;
					heatGeneration = 0f;
				}
				else
				{
					ComputeTorque();
					heatGeneration = ComputeHeat(pumpRpm, pumpTorque, turbineRpm, turbineTorque);
				}
			}
		}

		private const string IS_BROKEN_SAVE_KEY = "broken";

		public const float TRANSMISSION_ENGAGED_SMOOTH_TIME = 0.2f;

		public const float OVERHEAT_EXPLOSION_THRESHOLD_MULTIPLIER = 1.75f;

		public const float RETARDER_FILL_MULTIPLIER = 10f;

		public bool hasFreewheel;

		public float outputTorqueLimit;

		public float hydroDynamicBrakeTorqueCapacity;

		public AnimationCurve pumpRpmFillCurve;

		public bool fillCouplingAtIdle;

		public float couplingFillTime;

		public float overheatingThreshold;

		public float overheatingMaxTime;

		public float overheatingDamagePerDegreePerSecond;

		public float overheatingExplosionDamage;

		public readonly PortReference throttleControl;

		public readonly PortReference hydroDynamicBrakeControl;

		public readonly PortReference reverserControl;

		public readonly PortReference inputShaftRpm;

		public readonly PortReference maxRpmReader;

		public readonly PortReference outputShaftRpm;

		public readonly PortReference temperature;

		public readonly Port heatOut;

		public readonly Port inputShaftTorque;

		public readonly Port outputShaftTorque;

		public readonly Port hydroDynamicBrakeEffectReadOut;

		public readonly Port gearRatioReadOut;

		public readonly Port pumpTorqueNormalizedReadOut;

		public readonly Port transmissionEngagedReadOut;

		public readonly Port turbineRpmReadOut;

		public readonly Port turbineRpmNormalizedReadOut;

		public readonly Port mechanicalPowerTrainHealthExtIn;

		public readonly Port generatedDamageReadOut;

		public readonly Port isBrokenReadOut;

		public readonly Port inputPowerReadOut;

		public readonly Port outputPowerReadOut;

		public readonly Port efficiencyReadOut;

		public readonly Port activeConfigReadOut;

		public readonly Port speedRatioReadOut;

		private readonly HydraulicConfig[] configs;

		private float maxHydroDynamicBrakeTorque;

		private float maxPumpTorque;

		private float maxFillLevel;

		private int activeConfigIndex;

		private float hydroDynamicBrakeFillLevel;

		private float hydroDynamicBrakeTorque;

		private float hydroDynamicBrakeHeatGeneration;

		private float transmissionEngagedSmoothRefVelocity;

		private float overheatingTimer;

		public override bool HasSaveData => true;

		public HydraulicTransmission(HydraulicTransmissionDefinition htDef)
			: base(htDef.ID)
		{
			hasFreewheel = htDef.hasFreewheel;
			outputTorqueLimit = htDef.outputTorqueLimit;
			hydroDynamicBrakeTorqueCapacity = htDef.hydroDynamicBrakeTorqueCapacity;
			pumpRpmFillCurve = htDef.pumpRpmFillCurve;
			fillCouplingAtIdle = htDef.fillCouplingAtIdle;
			couplingFillTime = htDef.couplingFillTime;
			overheatingThreshold = htDef.overheatingThreshold;
			overheatingMaxTime = htDef.overheatingMaxTime;
			overheatingDamagePerDegreePerSecond = htDef.overheatingDamagePerDegreePerSecond;
			overheatingExplosionDamage = htDef.overheatingExplosionDamage;
			throttleControl = AddPortReference(htDef.throttleControl);
			hydroDynamicBrakeControl = AddPortReference(htDef.hydroDynamicBrakeControl);
			reverserControl = AddPortReference(htDef.reverserControl);
			inputShaftRpm = AddPortReference(htDef.inputShaftRpm);
			maxRpmReader = AddPortReference(htDef.maxRpmReader);
			outputShaftRpm = AddPortReference(htDef.outputShaftRpm);
			temperature = AddPortReference(htDef.temperature);
			heatOut = AddPort(htDef.heatOut);
			inputShaftTorque = AddPort(htDef.inputShaftTorque);
			outputShaftTorque = AddPort(htDef.outputShaftTorque);
			hydroDynamicBrakeEffectReadOut = AddPort(htDef.hydroDynamicBrakeEffectReadOut);
			gearRatioReadOut = AddPort(htDef.gearRatioReadOut);
			pumpTorqueNormalizedReadOut = AddPort(htDef.pumpTorqueNormalizedReadOut);
			transmissionEngagedReadOut = AddPort(htDef.transmissionEngagedReadOut);
			turbineRpmReadOut = AddPort(htDef.turbineRpmReadOut);
			turbineRpmNormalizedReadOut = AddPort(htDef.turbineRpmNormalizedReadOut);
			mechanicalPowerTrainHealthExtIn = AddPort(htDef.mechanicalPowerTrainHealthExtIn, 1f);
			generatedDamageReadOut = AddPort(htDef.generatedDamageReadOut);
			isBrokenReadOut = AddPort(htDef.isBrokenReadOut);
			activeConfigReadOut = AddPort(htDef.activeConfigReadOut);
			speedRatioReadOut = AddPort(htDef.speedRatioReadOut);
			inputPowerReadOut = AddPort(htDef.inputPowerReadOut);
			outputPowerReadOut = AddPort(htDef.outputPowerReadOut);
			efficiencyReadOut = AddPort(htDef.efficiencyReadOut);
			configs = htDef.configs.Select((HydraulicTransmissionDefinition.HydraulicConfigDefinition configDef) => new HydraulicConfig(configDef)).ToArray();
		}

		public override void InitializationAfterConnecting()
		{
			maxHydroDynamicBrakeTorque = HydraulicConfig.ComputePumpTorque(hydroDynamicBrakeTorqueCapacity, 1f, maxRpmReader.Value, 0f);
			maxPumpTorque = configs.Select((HydraulicConfig c) => HydraulicConfig.ComputePumpTorque(c.torqueCapacity, 1f, maxRpmReader.Value, 0f)).Max((float torque) => Mathf.Abs(torque));
		}

		private void SimulateGearSelect(float delta)
		{
			HydraulicConfig hydraulicConfig = configs[activeConfigIndex];
			float num = ((inputShaftRpm.Value == 0f) ? 0f : Mathf.Abs(outputShaftRpm.Value / inputShaftRpm.Value));
			if (activeConfigIndex > 0 && num < hydraulicConfig.downshiftThreshold)
			{
				activeConfigIndex--;
			}
			else if (activeConfigIndex + 1 < configs.Length && num > hydraulicConfig.upshiftThreshold)
			{
				activeConfigIndex++;
			}
			activeConfigReadOut.Value = activeConfigIndex;
			speedRatioReadOut.Value = num;
			gearRatioReadOut.Value = configs[activeConfigIndex].gearRatio;
			maxFillLevel = ((isBrokenReadOut.Value == 1f) ? 0f : pumpRpmFillCurve.Evaluate(inputShaftRpm.Value));
			bool flag = fillCouplingAtIdle || throttleControl.Value > 0.01f;
			for (int i = 0; i < configs.Length; i++)
			{
				HydraulicConfig hydraulicConfig2 = configs[i];
				float num2 = ((flag && i == activeConfigIndex) ? maxFillLevel : 0f);
				if (hydraulicConfig2.fillLevel < num2)
				{
					hydraulicConfig2.fillLevel = Mathf.Min(num2, hydraulicConfig2.fillLevel + delta / couplingFillTime);
				}
				else if (hydraulicConfig2.fillLevel > num2)
				{
					hydraulicConfig2.fillLevel = Mathf.Max(num2, hydraulicConfig2.fillLevel - delta / couplingFillTime);
				}
			}
		}

		private void SimulateCouplings(float delta)
		{
			float value = inputShaftRpm.Value;
			float num = outputShaftRpm.Value * reverserControl.Value;
			HydraulicConfig[] array = configs;
			foreach (HydraulicConfig hydraulicConfig in array)
			{
				hydraulicConfig.pumpRpm = value;
				float num2 = num * hydraulicConfig.gearRatio;
				hydraulicConfig.turbineRpm = ((hasFreewheel && num2 > value) ? value : num2);
				hydraulicConfig.Tick();
			}
		}

		private void SimulateRetarder(float delta)
		{
			float num = Mathf.Min(maxFillLevel * 10f, hydroDynamicBrakeControl.Value);
			if (hydroDynamicBrakeFillLevel < num)
			{
				hydroDynamicBrakeFillLevel = Mathf.Min(num, hydroDynamicBrakeFillLevel + delta / couplingFillTime);
			}
			else if (hydroDynamicBrakeFillLevel > num)
			{
				hydroDynamicBrakeFillLevel = Mathf.Max(num, hydroDynamicBrakeFillLevel - delta / couplingFillTime);
			}
			hydroDynamicBrakeTorque = HydraulicConfig.ComputePumpTorque(hydroDynamicBrakeTorqueCapacity, hydroDynamicBrakeFillLevel, outputShaftRpm.Value, 0f);
			hydroDynamicBrakeHeatGeneration = ((hydroDynamicBrakeTorque == 0f) ? 0f : HydraulicConfig.ComputeHeat(outputShaftRpm.Value, hydroDynamicBrakeTorque, 0f, 0f));
		}

		private void SumOutputs(float delta)
		{
			float value = reverserControl.Value;
			bool num = value == 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			if (!num)
			{
				HydraulicConfig[] array = configs;
				foreach (HydraulicConfig hydraulicConfig in array)
				{
					if (hydraulicConfig.fillLevel > 0f)
					{
						num2 += hydraulicConfig.pumpTorque;
						num3 += hydraulicConfig.turbineTorque * hydraulicConfig.gearRatio;
						num4 += hydraulicConfig.heatGeneration;
					}
				}
				num3 *= value;
			}
			num3 += hydroDynamicBrakeTorque;
			num4 += hydroDynamicBrakeHeatGeneration;
			float value2 = outputTorqueLimit * (float)Math.Tanh(num3 / outputTorqueLimit);
			inputShaftTorque.Value = num2;
			outputShaftTorque.Value = value2;
			heatOut.Value = num4;
			hydroDynamicBrakeEffectReadOut.Value = ((maxHydroDynamicBrakeTorque == 0f) ? 0f : Mathf.Abs(hydroDynamicBrakeTorque / maxHydroDynamicBrakeTorque));
			pumpTorqueNormalizedReadOut.Value = Mathf.Abs(num2 / maxPumpTorque);
			float target = Mathf.Clamp01(Mathf.Abs(10f * outputShaftRpm.Value / maxRpmReader.Value * 4f * num3 / maxPumpTorque));
			transmissionEngagedReadOut.Value = Mathf.SmoothDamp(transmissionEngagedReadOut.Value, target, ref transmissionEngagedSmoothRefVelocity, 0.2f, float.PositiveInfinity, delta);
			float turbineRpm = configs[activeConfigIndex].turbineRpm;
			turbineRpmReadOut.Value = turbineRpm;
			turbineRpmNormalizedReadOut.Value = turbineRpm / maxRpmReader.Value;
			float num5 = (0f - num2) * ((float)Math.PI / 30f) * inputShaftRpm.Value;
			inputPowerReadOut.Value = num5;
			float num6 = num3 * ((float)Math.PI / 30f) * outputShaftRpm.Value;
			outputPowerReadOut.Value = num6;
			float a = Mathf.Abs(num5);
			float b = Mathf.Abs(num6);
			float num7 = Mathf.Min(a, b);
			float num8 = Mathf.Max(a, b);
			efficiencyReadOut.Value = ((num8 == 0f) ? 1f : (num7 / num8));
		}

		private void SimulateDamage(float delta)
		{
			bool flag = isBrokenReadOut.Value == 1f;
			float value = temperature.Value;
			bool flag2 = false;
			bool drivetrainFailuresAllowed = gameParams.DrivetrainFailuresAllowed;
			if (drivetrainFailuresAllowed)
			{
				if (value > overheatingThreshold && overheatingTimer <= 0f)
				{
					overheatingTimer = UnityEngine.Random.Range(1f, overheatingMaxTime);
				}
				if (overheatingTimer > 0f)
				{
					if (value <= overheatingThreshold || flag)
					{
						overheatingTimer = 0f;
					}
					else
					{
						overheatingTimer -= delta;
						if (overheatingTimer <= 0f || value > overheatingThreshold * 1.75f)
						{
							flag2 = true;
							overheatingTimer = 0f;
						}
					}
				}
			}
			if (mechanicalPowerTrainHealthExtIn.Value > 0.95f && mechanicalPowerTrainHealthExtIn.Diff > 0f)
			{
				isBrokenReadOut.Value = 0f;
			}
			float num = 0f;
			if (drivetrainFailuresAllowed)
			{
				if (value > overheatingThreshold)
				{
					float num2 = value - overheatingThreshold;
					if (num2 > 0f)
					{
						num += overheatingDamagePerDegreePerSecond * num2 * delta;
					}
				}
				if (flag2 && !flag)
				{
					isBrokenReadOut.Value = 1f;
					flag = true;
					num += overheatingExplosionDamage;
					inputShaftTorque.Value = 0f;
					outputShaftTorque.Value = 0f;
				}
			}
			generatedDamageReadOut.Value = (drivetrainFailuresAllowed ? num : 0f);
		}

		public override void Tick(float delta)
		{
			SimulateGearSelect(delta);
			SimulateRetarder(delta);
			SimulateCouplings(delta);
			SumOutputs(delta);
			SimulateDamage(delta);
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
