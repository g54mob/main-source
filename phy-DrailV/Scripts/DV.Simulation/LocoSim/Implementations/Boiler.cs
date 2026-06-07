using System;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class Boiler : SimComponent
	{
		public const float BOILER_EVENT_HANDLED_CODE = 0f;

		public const float BOILER_REMOVE_WATER_CODE = 1f;

		public const float BOILER_WATER_LEVEL_TO_SPAWN_RANGE_CODE = 2f;

		public const float BOILER_WATER_AND_PRESSURE_NOMINAL_RANGE_SETUP = 3f;

		private const float NOMINAL_PRESSURE_VALUE = 13f;

		private const string WATER_LEVEL_NORMALIZED_SAVE_KEY = "waterLevelNormalized";

		private const string PRESSURE_SAVE_KEY = "pressure";

		private const string CROWN_SHEET_TEMPERATURE_SAVE_KEY = "crownSheetTemperature";

		private const string IS_BROKEN_SAVE_KEY = "broken";

		private const float SAFETY_VALVE_CREEP_MULTIPLIER = 0.01f;

		private readonly float totalVolume;

		private readonly float aspectRatio;

		private readonly float maxInjectorRate;

		private readonly float waterConsumptionMultiplier;

		private readonly float maxBlowdownRate;

		private readonly float safetyValveOpeningPressure;

		private readonly float safetyValveClosingPressure;

		private readonly float safetyValveSlop;

		private readonly float maxSafetyValveVentRate;

		private readonly float spawnPressure;

		private readonly float crownSheetNormalizedWaterLevel;

		private readonly float crownSheetTempSmoothTime;

		private readonly float crownSheetOverheatTemp;

		private readonly float minimumExplosionPressure;

		private readonly AnimationCurve explosionPressureThreshold;

		public float steamOutletNormalizedWaterLevel;

		private readonly float exteriorThermalConductance;

		public readonly PortReference injectorControl;

		public readonly PortReference blowdownControl;

		public readonly PortReference heat;

		public readonly PortReference fireboxTemperature;

		public readonly PortReference feedwaterTemperature;

		public readonly Port angleExtIn;

		public readonly PortReference steamConsumption;

		public readonly Port pressureReadOut;

		public readonly Port temperatureReadOut;

		public readonly Port injectorFlowNormalizedReadOut;

		public readonly Port blowdownFlowNormalizedReadOut;

		public readonly Port waterLevelReadOut;

		public readonly Port waterMassReadOut;

		public readonly Port outletSteamQualityReadOut;

		public readonly PortReference water;

		public readonly PortReference waterConsumption;

		public readonly Port waterChangeRequestedExtIn;

		public readonly Port safetyValveReadOut;

		public readonly Port normalizedCrownSheetTemperatureReadOut;

		public readonly Port bodyHealthStateExtIn;

		public readonly Port isBrokenReadOut;

		private readonly Port enthalpyReadOut;

		private readonly Port powerInReadOut;

		private readonly Port powerOutReadOut;

		private readonly float spawnWaterMass;

		private WaterPressureVessel vessel;

		private float safetyValveOpening;

		private float crownSheetTemperature;

		private float blowdownSmoothVelocity;

		public override bool HasSaveData => true;

		public Boiler(BoilerDefinition bDef)
			: base(bDef.ID)
		{
			float num = bDef.diameter / 2f;
			float num2 = (float)Math.PI * num * num;
			totalVolume = num2 * bDef.length * bDef.capacityMultiplier * 1000f;
			aspectRatio = bDef.length / bDef.diameter;
			float num3 = (float)Math.PI * bDef.diameter;
			float num4 = 2f * num2 + num3 * bDef.length;
			exteriorThermalConductance = ((bDef.thermalInsulance <= 0f) ? 0f : (num4 / bDef.thermalInsulance));
			maxInjectorRate = bDef.maxInjectorRate;
			waterConsumptionMultiplier = bDef.waterConsumptionMultiplier;
			maxBlowdownRate = bDef.maxBlowdownRate;
			safetyValveOpeningPressure = bDef.safetyValveOpeningPressure;
			safetyValveClosingPressure = bDef.safetyValveClosingPressure;
			safetyValveSlop = bDef.safetyValveSlop;
			maxSafetyValveVentRate = bDef.maxSafetyValveVentRate;
			spawnPressure = bDef.spawnPressure;
			crownSheetNormalizedWaterLevel = bDef.crownSheetNormalizedWaterLevel;
			crownSheetTempSmoothTime = bDef.crownSheetTempSmoothTime;
			crownSheetOverheatTemp = bDef.crownSheetOverheatTemp;
			minimumExplosionPressure = bDef.minimumExplosionPressure;
			explosionPressureThreshold = bDef.explosionPressureThreshold;
			steamOutletNormalizedWaterLevel = bDef.steamOutletNormalizedWaterLevel;
			injectorControl = AddPortReference(bDef.injectorControl);
			blowdownControl = AddPortReference(bDef.blowdownControl);
			heat = AddPortReference(bDef.heat);
			fireboxTemperature = AddPortReference(bDef.fireboxTemperature);
			feedwaterTemperature = AddPortReference(bDef.feedwaterTemperature, bDef.defaultFeedwaterTemperature);
			angleExtIn = AddPort(bDef.angleExtIn);
			steamConsumption = AddPortReference(bDef.steamConsumption);
			pressureReadOut = AddPort(bDef.pressureReadOut);
			temperatureReadOut = AddPort(bDef.temperatureReadOut);
			injectorFlowNormalizedReadOut = AddPort(bDef.injectorFlowNormalizedReadOut);
			blowdownFlowNormalizedReadOut = AddPort(bDef.blowdownFlowNormalizedReadOut);
			waterLevelReadOut = AddPort(bDef.waterLevelReadOut);
			waterMassReadOut = AddPort(bDef.waterMassReadOut);
			outletSteamQualityReadOut = AddPort(bDef.outletSteamQualityReadOut);
			water = AddPortReference(bDef.water);
			waterConsumption = AddPortReference(bDef.waterConsumption);
			waterChangeRequestedExtIn = AddPort(bDef.waterChangeRequestedExtIn);
			waterChangeRequestedExtIn.ValueUpdatedInternally += OnBoilerWaterChangeRequested;
			safetyValveReadOut = AddPort(bDef.safetyValveReadOut);
			normalizedCrownSheetTemperatureReadOut = AddPort(bDef.normalizedCrownSheetTemperatureReadOut);
			bodyHealthStateExtIn = AddPort(bDef.bodyHealthStateExtIn, 1f);
			isBrokenReadOut = AddPort(bDef.isBrokenReadOut);
			enthalpyReadOut = AddPort(bDef.enthalpyReadOut);
			powerInReadOut = AddPort(bDef.powerInReadOut);
			powerOutReadOut = AddPort(bDef.powerOutReadOut);
			spawnWaterMass = bDef.spawnWaterLevel / SteamTables.WaterSpecificVolume(spawnPressure);
			vessel = new WaterPressureVessel(totalVolume, spawnPressure, spawnWaterMass);
			waterMassReadOut.Value = vessel.mass;
		}

		private void SimulateInjector(float delta)
		{
			float num = 0f;
			float value = injectorControl.Value;
			if (value > 0f && isBrokenReadOut.Value == 0f)
			{
				float a = value * maxInjectorRate * delta;
				float b = water.Value / waterConsumptionMultiplier;
				num = Mathf.Min(b: totalVolume - vessel.waterVolume, a: Mathf.Min(a, b));
				vessel.AddWater(num, feedwaterTemperature.Value);
			}
			injectorFlowNormalizedReadOut.Value = ((num > 0f) ? value : 0f);
			if (num > 0f)
			{
				waterConsumption.Value = num * waterConsumptionMultiplier * gameParams.ResourceConsumptionModifier;
			}
		}

		private void SimulateSteamConsumption(float delta)
		{
			vessel.RemoveSteam(steamConsumption.Value * delta);
			float num = 25f - vessel.waterTemp;
			vessel.AddEnergy(num * exteriorThermalConductance * delta);
		}

		private void SimulateSafetyValve(float delta)
		{
			float pressure = vessel.pressure;
			if (pressure > safetyValveOpeningPressure)
			{
				safetyValveOpening = 1f;
			}
			else if (safetyValveOpening < 1f && pressure > safetyValveOpeningPressure - safetyValveSlop)
			{
				safetyValveOpening = 0.01f * Mathf.InverseLerp(safetyValveOpeningPressure - safetyValveSlop, safetyValveOpeningPressure, pressure);
			}
			else if (pressure < safetyValveClosingPressure)
			{
				safetyValveOpening = 0f;
			}
			if (safetyValveOpening > 0f)
			{
				vessel.RemoveSteam(safetyValveOpening * maxSafetyValveVentRate * delta);
			}
			safetyValveReadOut.Value = safetyValveOpening;
		}

		private void SimulateEvaporation(float delta)
		{
			vessel.AddEnergy(heat.Value * delta);
			vessel.Update();
			pressureReadOut.Value = vessel.pressure;
			temperatureReadOut.Value = vessel.waterTemp;
			enthalpyReadOut.Value = vessel.enthalpy * 1000f;
			powerInReadOut.Value = heat.Value;
			powerOutReadOut.Value = steamConsumption.Value * SteamTables.SteamSpecificEnthalpy(vessel.pressure) * 1000f;
		}

		private void SimulateWaterLevel(float delta)
		{
			float num = vessel.waterVolume / totalVolume;
			outletSteamQualityReadOut.Value = Mathf.InverseLerp(1f, steamOutletNormalizedWaterLevel, num);
			float num2 = aspectRatio / 2f * Mathf.Tan((0f - angleExtIn.Value) * (float)Math.PI / 180f);
			waterLevelReadOut.Value = num + num2;
			waterMassReadOut.Value = vessel.mass;
		}

		private void SimulateCrownSheet(float delta)
		{
			float num = ((waterLevelReadOut.Value > crownSheetNormalizedWaterLevel) ? vessel.waterTemp : Mathf.Max(vessel.waterTemp, fireboxTemperature.Value));
			float num2 = (num - crownSheetTemperature) / crownSheetTempSmoothTime;
			if (num2 > 0f)
			{
				crownSheetTemperature = Mathf.Min(num, crownSheetTemperature + num2 * delta);
			}
			else
			{
				crownSheetTemperature = Mathf.Max(num, crownSheetTemperature + num2 * delta);
			}
			normalizedCrownSheetTemperatureReadOut.Value = Mathf.InverseLerp(vessel.waterTemp, crownSheetOverheatTemp, crownSheetTemperature);
		}

		private void SimulateDamage(float delta)
		{
			float num = safetyValveOpeningPressure * explosionPressureThreshold.Evaluate(bodyHealthStateExtIn.Value);
			if (isBrokenReadOut.Value == 1f && bodyHealthStateExtIn.Diff > 0f && bodyHealthStateExtIn.Value > 0.95f)
			{
				vessel = new WaterPressureVessel(totalVolume, spawnPressure, spawnWaterMass);
				crownSheetTemperature = vessel.waterTemp;
				isBrokenReadOut.Value = 0f;
			}
			if (gameParams.DrivetrainFailuresAllowed && ((crownSheetTemperature > crownSheetOverheatTemp && vessel.pressure > minimumExplosionPressure) || vessel.pressure > num))
			{
				vessel.RemoveSteam(vessel.mass);
				isBrokenReadOut.Value = 1f;
			}
		}

		public override void Tick(float delta)
		{
			SimulateInjector(delta);
			SimulateSteamConsumption(delta);
			SimulateSafetyValve(delta);
			SimulateBlowdown(delta);
			SimulateEvaporation(delta);
			SimulateWaterLevel(delta);
			SimulateCrownSheet(delta);
			SimulateDamage(delta);
		}

		private void SimulateBlowdown(float delta)
		{
			float value = blowdownControl.Value;
			float num = 0f;
			if (value > 0f && vessel.mass > 0f)
			{
				float num2 = Mathf.InverseLerp(0f, 4f, vessel.pressure);
				float massToRemove = maxBlowdownRate * num2 * value * delta;
				vessel.RemoveWater(massToRemove);
				num = value * num2;
			}
			float value2 = blowdownFlowNormalizedReadOut.Value;
			if (value2 != num)
			{
				if (value2 < 0.01f && num == 0f)
				{
					value2 = 0f;
					blowdownSmoothVelocity = 0f;
				}
				else
				{
					value2 = Mathf.SmoothDamp(value2, num, ref blowdownSmoothVelocity, 0.1f, float.PositiveInfinity, delta);
				}
				blowdownFlowNormalizedReadOut.Value = value2;
			}
		}

		private void OnBoilerWaterChangeRequested(float instantBoilerWaterChangeRequest)
		{
			if (instantBoilerWaterChangeRequest == 1f)
			{
				vessel.RemoveWater(vessel.mass);
				waterMassReadOut.Value = vessel.mass;
				waterChangeRequestedExtIn.Value = 0f;
			}
			else if (instantBoilerWaterChangeRequest == 2f)
			{
				vessel = new WaterPressureVessel(totalVolume, spawnPressure, spawnWaterMass);
				waterMassReadOut.Value = vessel.mass;
				waterChangeRequestedExtIn.Value = 0f;
			}
			else if (instantBoilerWaterChangeRequest == 3f)
			{
				vessel = new WaterPressureVessel(totalVolume, 13f, spawnWaterMass);
				waterMassReadOut.Value = vessel.mass;
				waterChangeRequestedExtIn.Value = 0f;
			}
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("pressure", vessel.pressure);
			jObject.SetFloat("waterLevelNormalized", vessel.waterVolume / totalVolume);
			jObject.SetFloat("crownSheetTemperature", crownSheetTemperature);
			if (isBrokenReadOut.Value == 1f)
			{
				jObject.SetBool("broken", value: true);
			}
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			float? num = savedData.GetFloat("pressure");
			float? num2 = savedData.GetFloat("waterLevelNormalized");
			if (num.HasValue && num2.HasValue)
			{
				vessel = WaterPressureVessel.FromSaveData(totalVolume, num.Value, num2.Value);
			}
			float? num3 = savedData.GetFloat("crownSheetTemperature");
			if (num3.HasValue)
			{
				crownSheetTemperature = num3.Value;
			}
			bool? flag = savedData.GetBool("broken");
			if (flag.HasValue && flag.Value)
			{
				isBrokenReadOut.Value = 1f;
			}
		}
	}
}
