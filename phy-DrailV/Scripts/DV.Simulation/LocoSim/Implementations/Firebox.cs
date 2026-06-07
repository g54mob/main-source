using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class Firebox : SimComponent
	{
		public const string FIRE_ON_SAVE_KEY = "fireOn";

		public const string COAL_MASS_SAVE_KEY = "coalMass";

		private const string COAL_ENV_DAMAGE_SAVE_KEY = "coalEnvDmg";

		public const float COAL_HEAT_CONTENT = 32000000f;

		public const float OXYGEN_CONTENT = 0.23f;

		public const float CARBON_ATOMIC_WEIGHT = 12.011f;

		public const float OXYGEN_ATOMIC_WEIGHT = 15.999f;

		public const float EXCESS_OXYGEN_FACTOR = 1.2f;

		public const float OXYGEN_MASS_FACTOR = 3.1968696f;

		public const float AIR_MASS_FACTOR = 13.899433f;

		public const float HEAT_YIELD_BASE = 0.5f;

		public const float HEAT_YIELD_EXPONENT = 0.4f;

		public const float MIN_FIRE_TEMPERATURE = 500f;

		public const float MAX_FIRE_TEMPERATURE = 1400f;

		public const float MIN_COMBUSTION_RATE = 1E-09f;

		public const float STARTUP_COMBUSTION_RATE_BASE_MULTIPLIER = 25f;

		public const float STARTUP_MULTIPLIER_MAX_SPEED = 1f;

		public const float OXYGEN_AVAILABILITY_FOR_MAX_SMOKE = 0.5f;

		public readonly float maxCoalCapacity;

		public readonly float coalDumpRate;

		public readonly float burnTime;

		public readonly float efficiencyAtMaxCombustion;

		public readonly float combustionRateSmoothTime;

		public readonly float temperatureSmoothTime;

		public readonly float startupMaxPressure;

		public readonly PortReference coalDumpControl;

		public readonly Port coalCapacityReadOut;

		public readonly Port coalLevelReadOut;

		public readonly Port coalLevelNormalizedReadOut;

		public readonly Port coalControlExtIn;

		public readonly Port coalEnvDamage;

		public readonly Port ignitionExtIn;

		public readonly Port extinguishExtIn;

		public readonly PortReference intakeWaterContent;

		public readonly PortReference airFlow;

		public readonly Port heatReadOut;

		public readonly Port fireOnReadOut;

		public readonly Port coalDumpFlowNormalizedReadOut;

		public readonly Port smokeDensityReadOut;

		public readonly Port combustionRateNormalizedReadOut;

		public readonly Port temperatureReadOut;

		public readonly PortReference forwardSpeed;

		public readonly PortReference boilerPressure;

		public readonly PortReference boilerTemperature;

		public readonly PortReference boilerBrokenState;

		private readonly Port oxygenAvailabilityReadOut;

		private readonly float maxCombustionRate;

		private readonly float maxHeatOutput;

		private float coalMass;

		private float combustionRate;

		private float combustionRateVelocity;

		private float smokeDensity;

		private float smokinessVelocity;

		private float coalDumpFlow;

		private float coalDumpFlowVelocity;

		private float fireboxTemperatureVelocity;

		public override bool HasSaveData => true;

		public Firebox(FireboxDefinition fDef)
			: base(fDef.ID)
		{
			maxCoalCapacity = fDef.maxCoalCapacity;
			coalDumpRate = fDef.coalDumpRate;
			intakeWaterContent = AddPortReference(fDef.intakeWaterContent);
			burnTime = fDef.burnTime;
			efficiencyAtMaxCombustion = fDef.efficiencyAtMaxCombustion;
			combustionRateSmoothTime = fDef.combustionRateSmoothTime;
			temperatureSmoothTime = fDef.temperatureSmoothTime;
			startupMaxPressure = fDef.startupMaxPressure;
			coalDumpControl = AddPortReference(fDef.coalDumpControl, 0.5f);
			coalCapacityReadOut = AddPort(fDef.coalCapacityReadOut, maxCoalCapacity);
			coalLevelReadOut = AddPort(fDef.coalLevelReadOut);
			coalLevelNormalizedReadOut = AddPort(fDef.coalLevelNormalizedReadOut);
			coalControlExtIn = AddPort(fDef.coalControlExtIn);
			coalEnvDamage = AddPort(fDef.coalEnvDamage);
			ignitionExtIn = AddPort(fDef.ignitionExtIn);
			extinguishExtIn = AddPort(fDef.extinguishExtIn);
			airFlow = AddPortReference(fDef.airFlow);
			heatReadOut = AddPort(fDef.heatReadOut);
			coalDumpFlowNormalizedReadOut = AddPort(fDef.coalDumpFlowNormalizedReadOut);
			fireOnReadOut = AddPort(fDef.fireOnReadOut);
			smokeDensityReadOut = AddPort(fDef.smokeDensityReadOut);
			combustionRateNormalizedReadOut = AddPort(fDef.combustionRateNormalizedReadOut);
			temperatureReadOut = AddPort(fDef.temperatureReadOut, 100f);
			forwardSpeed = AddPortReference(fDef.forwardSpeed);
			boilerPressure = AddPortReference(fDef.boilerPressure);
			boilerTemperature = AddPortReference(fDef.boilerTemperature, 100f);
			boilerBrokenState = AddPortReference(fDef.boilerBrokenState);
			oxygenAvailabilityReadOut = AddPort(fDef.oxygenAvailabilityReadOut);
			maxCombustionRate = maxCoalCapacity / burnTime;
			maxHeatOutput = maxCombustionRate * 32000000f * efficiencyAtMaxCombustion;
			coalControlExtIn.ValueUpdatedInternally += OnCoalControlValueUpdated;
		}

		public override void InitializationAfterConnecting()
		{
			if (boilerBrokenState.IsConnected)
			{
				boilerBrokenState.port.ValueUpdatedInternally += OnBoilerBrokenStateChanged;
			}
		}

		private void OnBoilerBrokenStateChanged(float newBrokenStateValue)
		{
			if (newBrokenStateValue == 1f)
			{
				fireOnReadOut.Value = 0f;
			}
		}

		private void OnCoalControlValueUpdated(float coalMassDelta)
		{
			if (coalMassDelta != 0f)
			{
				coalMass = Mathf.Clamp(coalMass + coalMassDelta, 0f, maxCoalCapacity);
				coalLevelReadOut.Value = coalMass;
				coalLevelNormalizedReadOut.Value = coalMass / maxCoalCapacity;
				coalControlExtIn.Value = 0f;
			}
		}

		private void CheckIgnition()
		{
			if (ignitionExtIn.Value == 1f)
			{
				if (intakeWaterContent.Value <= 0.5f)
				{
					fireOnReadOut.Value = 1f;
				}
				ignitionExtIn.Value = 0f;
			}
			else if (extinguishExtIn.Value == 1f)
			{
				fireOnReadOut.Value = 0f;
				extinguishExtIn.Value = 0f;
			}
		}

		private void CoalDump(float delta)
		{
			float num = Mathf.InverseLerp(0.25f, 0.5f, Mathf.Abs(coalDumpControl.Value - 0.5f));
			float num2 = ((coalMass > 0f) ? num : 0f);
			coalDumpFlow = Mathf.SmoothDamp(coalDumpFlow, num2, ref coalDumpFlowVelocity, 0.5f, float.PositiveInfinity, delta);
			if (num2 == 0f && coalDumpFlow < 0.01f)
			{
				coalDumpFlow = 0f;
				coalDumpFlowVelocity = 0f;
			}
			coalDumpFlowNormalizedReadOut.Value = coalDumpFlow;
			if (coalDumpFlow > 0f)
			{
				float num3 = Mathf.Min(coalMass, coalDumpFlow * coalDumpRate * delta);
				coalMass -= num3;
			}
		}

		private void SimulateCombustion(float delta)
		{
			if (intakeWaterContent.Value > 0.5f)
			{
				fireOnReadOut.Value = 0f;
			}
			float num = airFlow.Value / 13.899433f * (1f - intakeWaterContent.Value);
			float num2 = coalMass / burnTime;
			float num3 = ((num2 == 0f) ? 1f : Mathf.Min(1f, num / num2));
			oxygenAvailabilityReadOut.Value = num3;
			float b = Mathf.Min(num2, num * 2f);
			float num4 = Mathf.InverseLerp(startupMaxPressure, 1f, boilerPressure.Value);
			float num5 = Mathf.InverseLerp(1f, 0f, Mathf.Abs(forwardSpeed.Value));
			float t = num4 * num5;
			float num6 = gameParams.SteamStartupMultiplier;
			if (num6 <= 0f)
			{
				Debug.LogError(string.Format("Unexpected value of {0}: {1}. Setting it to 1!", "SteamStartupMultiplier", num6));
				num6 = 1f;
			}
			float num7 = Mathf.Lerp(1f, 25f / num6, t);
			float target = ((fireOnReadOut.Value == 1f) ? Mathf.Max(1E-09f, b) : 0f);
			combustionRate = Mathf.SmoothDamp(combustionRate, target, ref combustionRateVelocity, combustionRateSmoothTime / num7, float.PositiveInfinity, delta) * (1f - intakeWaterContent.Value);
			float num8 = num7 * combustionRate * delta;
			if (num8 > coalMass)
			{
				num8 = coalMass;
				coalMass = 0f;
				combustionRate = 0f;
				combustionRateVelocity = 0f;
			}
			else
			{
				coalMass -= num8;
			}
			if (num8 > 0f)
			{
				coalEnvDamage.Value += num8;
			}
			if (coalMass == 0f && temperatureReadOut.Value < 500f)
			{
				fireOnReadOut.Value = 0f;
			}
			float num9 = 0.5f + 0.5f * Mathf.Pow(num3, 0.4f);
			float num10 = Mathf.Lerp(1f, efficiencyAtMaxCombustion, num9 * combustionRate / maxCombustionRate);
			float num11 = num9 * num10;
			heatReadOut.Value = ((delta == 0f) ? 0f : (num8 * 32000000f * num11 / delta));
			float target2 = ((fireOnReadOut.Value == 1f) ? (1f - num3 * num3) : 0f);
			smokeDensity = Mathf.SmoothDamp(smokeDensity, target2, ref smokinessVelocity, combustionRateSmoothTime / num7, float.PositiveInfinity, delta);
			smokeDensityReadOut.Value = smokeDensity;
		}

		private void ComputeTemperature(float delta)
		{
			float value = combustionRate / maxCombustionRate;
			combustionRateNormalizedReadOut.Value = value;
			float target = ((!(combustionRate < 1E-09f)) ? Mathf.Lerp(500f, 1400f, heatReadOut.Value / maxHeatOutput) : boilerTemperature.Value);
			temperatureReadOut.Value = Mathf.SmoothDamp(temperatureReadOut.Value, target, ref fireboxTemperatureVelocity, temperatureSmoothTime, float.PositiveInfinity, delta);
		}

		public override void Tick(float delta)
		{
			CheckIgnition();
			CoalDump(delta);
			SimulateCombustion(delta);
			ComputeTemperature(delta);
			coalLevelReadOut.Value = coalMass;
			coalLevelNormalizedReadOut.Value = coalMass / maxCoalCapacity;
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			if (fireOnReadOut.Value == 1f)
			{
				jObject.SetBool("fireOn", value: true);
			}
			jObject.SetFloat("coalMass", coalMass);
			float value = coalEnvDamage.Value;
			if (value > 0f)
			{
				jObject.SetFloat("coalEnvDmg", value);
			}
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			bool? flag = savedData.GetBool("fireOn");
			if (flag.HasValue && flag.Value)
			{
				fireOnReadOut.Value = 1f;
			}
			float? num = savedData.GetFloat("coalMass");
			if (num.HasValue)
			{
				coalMass = Mathf.Clamp(num.Value, 0f, maxCoalCapacity);
			}
			float? num2 = savedData.GetFloat("coalEnvDmg");
			if (num2.HasValue)
			{
				coalEnvDamage.Value = num2.Value;
			}
		}
	}
}
