using System;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ReciprocatingSteamEngine : SimComponent
	{
		private class CylinderData
		{
			public bool isInletValveOpen;

			private float positionWithinStroke;

			private float crankOffset;

			private bool isCrankAboveHorizontal;

			private bool prevIsCrankAboveHorizontal;

			private float admissionPressure;

			private readonly ReciprocatingSteamEngine sim;

			public CylinderData(ReciprocatingSteamEngine sim)
			{
				this.sim = sim;
				admissionPressure = 1f;
			}

			public void SimulateCylinder(float lead)
			{
				float num = (sim.crankRotation + lead) % 1f;
				isCrankAboveHorizontal = num < 0.5f;
				float num2 = (sim.prevCrankRotation + lead) % 1f;
				prevIsCrankAboveHorizontal = num2 < 0.5f;
				float f = num * 2f * (float)Math.PI;
				float num3 = 0.5f + Mathf.Cos(f) * 0.5f;
				crankOffset = Mathf.Sin(f);
				positionWithinStroke = ((isCrankAboveHorizontal ^ sim.isReverserForward) ? num3 : (1f - num3));
				isInletValveOpen = positionWithinStroke < sim.cutoff;
			}

			public float SimulateTorque(float cylinderPressure)
			{
				if (prevIsCrankAboveHorizontal != isCrankAboveHorizontal || isInletValveOpen)
				{
					bool flag = sim.isReverserForward ^ isCrankAboveHorizontal;
					admissionPressure = (flag ? (0f - cylinderPressure) : cylinderPressure);
				}
				return CalculatePistonForce() * crankOffset * sim.pistonStroke / 2f;
			}

			private float CalculatePistonForce()
			{
				float num = Mathf.Abs(admissionPressure);
				float num2 = Mathf.Sign(admissionPressure);
				if (positionWithinStroke > sim.cutoff)
				{
					num *= InstantaneousCylinderPressureRatio(positionWithinStroke / sim.cutoff);
				}
				float num3 = Mathf.Max(0f, num - 1f);
				return num2 * num3 * 100000f * sim.pistonArea;
			}

			private float InstantaneousCylinderPressureRatio(float expansionRatio)
			{
				if (expansionRatio < sim.condensationExpansionRatio)
				{
					return 1f / expansionRatio;
				}
				return 1f / expansionRatio * sim.cutoff;
			}
		}

		public const string CYLINDER_CRACKED_SAVE_KEY = "cylCracked";

		public const float ADIABATIC_INDEX = 1.3333334f;

		public const float CONDENSATION_TEMPERATURE_K = 380f;

		public const float TORQUE_SMOOTH_TIME = 0.1f;

		public const float RPM_FOR_LERP_START = 45f;

		public const float RPM_FOR_LERP_END = 60f;

		public const float ABS_SINUSOID_MEAN = 2f / (float)Math.PI;

		private const float CYLINDER_COCK_OPEN_PRESSURE_LOST_PERCENTAGE = 0.1f;

		private const float CYLINDER_CRACK_PRESSURE_LOST_PERCENTAGE = 0.5f;

		private const float RPM_FOR_MAX_WATER_EXPULSION = 100f;

		public int numCylinders;

		public float cylinderBore;

		public float pistonStroke;

		public float minCutoff;

		public float maxCutoff;

		public readonly float throttleMaxFlow;

		public readonly float steamChestVolume;

		public readonly float cylinderHeatRate;

		public readonly float maxCondensationRate;

		public readonly float primingRate;

		public readonly float maxWaterExpulsionRate;

		public readonly float waterDrainPercentagePerSecond;

		public readonly float waterDamagePercentagePerChuff;

		public readonly float waterDamageRestorePerSecond;

		public readonly float cylinderCrackDamage;

		public readonly float passiveDamagePerRev = 0.01f;

		public readonly float noOilDamagePerRev = 1f;

		public readonly float ashChuffDamage;

		public readonly PortReference throttleControl;

		public readonly PortReference reverserControl;

		public readonly PortReference cylinderCockControl;

		public readonly PortReference intakePressure;

		public readonly PortReference intakeTemperature;

		public readonly PortReference intakeQuality;

		public readonly Port crankRotationReadOut;

		public readonly PortReference crankRpm;

		public readonly Port cylindersInletValveOpen;

		public readonly Port maxFlowReadOut;

		public readonly Port intakeFlowReadOut;

		public readonly Port intakeFlowNormalizedReadOut;

		public readonly Port exhaustFlowReadOut;

		public readonly Port exhaustPressureReadOut;

		public readonly Port exhaustTemperatureReadOut;

		public readonly Port chuffEventReadOut;

		public readonly Port chuffFrequencyReadOut;

		public readonly Port cylinderTemperatureReadOut;

		public readonly Port waterInCylindersNormalizedReadOut;

		public readonly Port ashesInPipesReadOut;

		public readonly Port cylinderCockFlowNormalizedReadOut;

		public readonly Port cylinderCrackFlowNormalizedReadOut;

		public readonly Port steamChestPressureReadOut;

		public readonly PortReference lubricationNormalized;

		public readonly Port healthStateExtIn;

		public readonly Port generatedMechanicalDamageReadOut;

		public readonly Port isCylinderCrackedReadOut;

		public readonly Port torqueOut;

		private readonly float pistonRotationLead;

		private readonly float pistonArea;

		private readonly float cylinderVolume;

		private readonly int chuffsPerCycle;

		private float steamChestSteamMass;

		private readonly CylinderData[] cylinderData;

		private bool isReverserForward;

		private float cutoff;

		private float condensationExpansionRatio;

		private float crankRotation;

		private float prevCrankRotation;

		private float torqueVelocity;

		private float steamMassPerChuff;

		private float admissionPressure;

		private float waterInCylindersDamageMeter;

		private float temperatureInCylinders;

		private float damageThisTick;

		public override bool HasSaveData => true;

		public ReciprocatingSteamEngine(ReciprocatingSteamEngineDefinition seDef)
			: base(seDef.ID)
		{
			numCylinders = seDef.numCylinders;
			cylinderBore = seDef.cylinderBore;
			pistonStroke = seDef.pistonStroke;
			minCutoff = seDef.minCutoff;
			maxCutoff = seDef.maxCutoff;
			throttleMaxFlow = seDef.throttleMaxFlow;
			steamChestVolume = seDef.steamChestVolume;
			cylinderHeatRate = seDef.cylinderHeatRate;
			maxCondensationRate = seDef.maxCondensationRate;
			primingRate = seDef.primingRate;
			maxWaterExpulsionRate = seDef.maxWaterExpulsionRate;
			waterDrainPercentagePerSecond = seDef.waterDrainPercentagePerSecond;
			waterDamagePercentagePerChuff = seDef.waterDamagePercentagePerChuff;
			waterDamageRestorePerSecond = seDef.waterDamageRestorePerSecond;
			cylinderCrackDamage = seDef.cylinderCrackDamage;
			passiveDamagePerRev = seDef.passiveDamagePerRev;
			noOilDamagePerRev = seDef.noOilDamagePerRev;
			ashChuffDamage = seDef.ashChuffDamage;
			throttleControl = AddPortReference(seDef.throttleControl);
			reverserControl = AddPortReference(seDef.reverserControl);
			cylinderCockControl = AddPortReference(seDef.cylinderCockControl);
			intakePressure = AddPortReference(seDef.intakePressure);
			intakeTemperature = AddPortReference(seDef.intakeTemperature);
			intakeQuality = AddPortReference(seDef.intakeQuality);
			crankRotationReadOut = AddPort(seDef.crankRotationReadOut);
			crankRpm = AddPortReference(seDef.crankRpm);
			cylindersInletValveOpen = AddPort(seDef.cylindersInletValveOpen);
			maxFlowReadOut = AddPort(seDef.maxFlowReadOut, throttleMaxFlow);
			intakeFlowReadOut = AddPort(seDef.intakeFlowReadOut);
			intakeFlowNormalizedReadOut = AddPort(seDef.intakeFlowNormalizedReadOut);
			exhaustFlowReadOut = AddPort(seDef.exhaustFlowReadOut);
			exhaustPressureReadOut = AddPort(seDef.exhaustPressureReadOut);
			exhaustTemperatureReadOut = AddPort(seDef.exhaustTemperatureReadOut);
			chuffEventReadOut = AddPort(seDef.chuffEventReadOut);
			chuffFrequencyReadOut = AddPort(seDef.chuffFrequencyReadOut);
			cylinderTemperatureReadOut = AddPort(seDef.cylinderTemperatureReadOut);
			waterInCylindersNormalizedReadOut = AddPort(seDef.waterInCylindersNormalizedReadOut, 1f);
			ashesInPipesReadOut = AddPort(seDef.ashesInPipesReadOut);
			cylinderCockFlowNormalizedReadOut = AddPort(seDef.cylinderCockFlowNormalizedReadOut);
			cylinderCrackFlowNormalizedReadOut = AddPort(seDef.cylinderCrackFlowNormalizedReadOut);
			steamChestPressureReadOut = AddPort(seDef.steamChestPressureReadOut);
			lubricationNormalized = AddPortReference(seDef.lubricationNormalized, 1f);
			healthStateExtIn = AddPort(seDef.healthStateExtIn, 1f);
			generatedMechanicalDamageReadOut = AddPort(seDef.generatedMechanicalDamageReadOut);
			isCylinderCrackedReadOut = AddPort(seDef.isCylinderCrackedReadOut);
			torqueOut = AddPort(seDef.torqueOut);
			cylinderData = new CylinderData[numCylinders];
			for (int i = 0; i < numCylinders; i++)
			{
				cylinderData[i] = new CylinderData(this);
			}
			pistonRotationLead = ((numCylinders == 3) ? (1f / 3f) : 0.25f);
			pistonArea = (float)Math.PI / 4f * cylinderBore * cylinderBore;
			cylinderVolume = pistonArea * pistonStroke * 1000f;
			chuffsPerCycle = numCylinders * 2;
		}

		private int CheckChuff(float prevCrankRotation, float rotationDelta)
		{
			float num = 1f / (float)chuffsPerCycle;
			float num2 = prevCrankRotation % num;
			float num3 = crankRotation % num;
			int num4 = Mathf.FloorToInt(Mathf.Abs(rotationDelta) * (float)chuffsPerCycle);
			if ((rotationDelta < 0f) ? (num3 > num2) : (num3 < num2))
			{
				num4++;
			}
			float num5 = Mathf.Abs(crankRpm.Value) / 60f;
			chuffFrequencyReadOut.Value = num5 * (float)chuffsPerCycle;
			if (num4 > 0)
			{
				int num6 = Mathf.FloorToInt(crankRotation * (float)chuffsPerCycle) % chuffsPerCycle;
				chuffEventReadOut.Value = num6;
			}
			return num4;
		}

		private float CondensationExpansionRatio()
		{
			return Mathf.Pow((intakeTemperature.Value + 273.15f) / 380f, 2.9999998f);
		}

		private float SimulateInstantaneousTorque(float admissionPressure)
		{
			float num = 0f;
			for (int i = 0; i < numCylinders; i++)
			{
				num += cylinderData[i].SimulateTorque(admissionPressure);
			}
			return num;
		}

		private void SimulateValveFlow()
		{
			float num = Mathf.Abs(crankRpm.Value) / 60f;
			if (cutoff == 0f || num == 0f)
			{
				admissionPressure = steamChestPressureReadOut.Value;
				return;
			}
			float num2 = cylinderVolume * cutoff;
			float a = num2 / (num2 + steamChestVolume) * steamChestSteamMass;
			float num3 = cutoff / num / 2f;
			float num4 = throttleMaxFlow;
			float b = num3 * num4;
			steamMassPerChuff = Mathf.Min(a, b);
			if (steamMassPerChuff > 0f)
			{
				float v = num2 / steamMassPerChuff;
				admissionPressure = Mathf.Min(steamChestPressureReadOut.Value, SteamTables.SteamSpecificVolumeToPressure(v));
			}
			else
			{
				admissionPressure = 1f;
			}
		}

		private float MeanEffectivePressureRatio()
		{
			float num = 1f / cutoff;
			if (num <= condensationExpansionRatio)
			{
				return cutoff * (1f + Mathf.Log(num));
			}
			return cutoff * (1f + (1f - cutoff) * Mathf.Log(condensationExpansionRatio) + cutoff * Mathf.Log(num));
		}

		private float SimulateMeanTorque(float admissionPressure)
		{
			float num = admissionPressure * MeanEffectivePressureRatio();
			return Mathf.Max(0f, num - 1f) * 100000f * pistonArea * (2f / (float)Math.PI) * pistonStroke / 2f * (float)numCylinders * Mathf.Sign(reverserControl.Value);
		}

		private float SimulateSteamConsumption(float absRpm, float admissionPressure, float modifiedAdmissionPressure, float dumpedPressure, bool steamInjectedToAnyCylinder)
		{
			if (admissionPressure <= 1f)
			{
				exhaustFlowReadOut.Value = 0f;
				return 0f;
			}
			float num = modifiedAdmissionPressure / admissionPressure;
			float num2 = dumpedPressure / admissionPressure;
			float num3 = absRpm / 60f;
			float num4 = (float)(numCylinders * 2) * num3 * steamMassPerChuff * num;
			exhaustFlowReadOut.Value = num4 * num;
			float result = 0f;
			if (num2 > 0f && num3 < 0.1f && steamInjectedToAnyCylinder)
			{
				result = (float)(numCylinders * 2) * steamMassPerChuff * num2;
			}
			return result;
		}

		private void SimulateWaterInCylinders(bool steamFlowing, int numChuffs, float delta)
		{
			bool flag = isCylinderCrackedReadOut.Value == 1f;
			float value = cylinderCockControl.Value;
			float num = waterInCylindersNormalizedReadOut.Value;
			float num2 = 25f;
			float value2 = crankRpm.Value;
			bool drivetrainFailuresAllowed = gameParams.DrivetrainFailuresAllowed;
			if (temperatureInCylinders < 100f && value2 < 100f)
			{
				float num3 = NumberUtil.MapClamp(temperatureInCylinders, 25f, 100f, maxCondensationRate, 0f);
				num += num3 * delta;
			}
			if (steamFlowing)
			{
				num2 = intakeTemperature.Value;
				if (intakeQuality.Value < 1f)
				{
					float num4 = (1f - intakeQuality.Value) * primingRate;
					num += num4 * delta;
				}
				float num5 = (flag ? 1f : 0f);
				if ((num5 > 0f || value > 0f) && num > 0f)
				{
					num -= waterDrainPercentagePerSecond * (value + num5) * delta;
				}
			}
			else if (num > 0f && value > 0f)
			{
				num -= 0.05f * waterDrainPercentagePerSecond * value * delta;
			}
			if (num > 0f)
			{
				float num6 = Mathf.InverseLerp(0f, 100f, Mathf.Abs(crankRpm.Value)) * maxWaterExpulsionRate;
				num -= num6 * delta;
			}
			num = Mathf.Clamp01(num);
			waterInCylindersNormalizedReadOut.Value = num;
			temperatureInCylinders += (num2 - temperatureInCylinders) * cylinderHeatRate * delta;
			cylinderTemperatureReadOut.Value = temperatureInCylinders;
			float value3 = healthStateExtIn.Value;
			if (flag && value3 > 0.95f && healthStateExtIn.Diff > 0f)
			{
				isCylinderCrackedReadOut.Value = 0f;
				flag = false;
				waterInCylindersDamageMeter = 0f;
			}
			bool flag2 = false;
			if (numChuffs > 0 && value == 0f && !flag && drivetrainFailuresAllowed)
			{
				float num7 = num * waterDamagePercentagePerChuff * (float)numChuffs;
				if (num7 > 0f)
				{
					flag2 = true;
					waterInCylindersDamageMeter += num7;
				}
				if (waterInCylindersDamageMeter > 1f)
				{
					Debug.Log("Cylinder crack");
					isCylinderCrackedReadOut.Value = 1f;
					damageThisTick += cylinderCrackDamage;
				}
			}
			if (waterInCylindersDamageMeter > 0f && !flag2)
			{
				waterInCylindersDamageMeter -= waterDamageRestorePerSecond * delta;
				waterInCylindersDamageMeter = Mathf.Clamp01(waterInCylindersDamageMeter);
			}
		}

		private void SimulateDamage(float absRotationDelta)
		{
			bool drivetrainFailuresAllowed = gameParams.DrivetrainFailuresAllowed;
			float num = passiveDamagePerRev * absRotationDelta;
			float num2 = noOilDamagePerRev * Mathf.InverseLerp(0.5f, 0f, lubricationNormalized.Value) * absRotationDelta;
			damageThisTick += (drivetrainFailuresAllowed ? (num + num2) : 0f);
			generatedMechanicalDamageReadOut.Value = (drivetrainFailuresAllowed ? damageThisTick : 0f);
		}

		private void SimulateSteamChest(float steamLossMassRate, int numChuffs, float delta)
		{
			float num = 1f;
			if (steamChestSteamMass > 0f)
			{
				float v = steamChestVolume / steamChestSteamMass;
				num = Mathf.Max(1f, SteamTables.SteamSpecificVolumeToPressure(v));
				float num2 = steamLossMassRate * delta;
				if (numChuffs > 0)
				{
					num2 += (float)numChuffs * steamMassPerChuff;
				}
				if (num2 > 0f)
				{
					steamChestSteamMass = Mathf.Max(0f, steamChestSteamMass - num2);
				}
			}
			steamChestPressureReadOut.Value = num;
			float value = intakePressure.Value;
			if (Mathf.Abs(num - value) < 0.001f)
			{
				intakeFlowReadOut.Value = 0f;
				intakeFlowNormalizedReadOut.Value = 0f;
				return;
			}
			float value2 = (steamChestVolume / SteamTables.SteamSpecificVolume(value) - steamChestSteamMass) / delta;
			float num3 = throttleMaxFlow * throttleControl.Value;
			float num4 = Mathf.Clamp(value2, 0f - num3, num3);
			intakeFlowReadOut.Value = num4;
			intakeFlowNormalizedReadOut.Value = num4 / throttleMaxFlow;
			steamChestSteamMass += num4 * delta;
		}

		public override void Tick(float delta)
		{
			damageThisTick = 0f;
			prevCrankRotation = crankRotation;
			float num = crankRpm.Value / 60f * delta;
			crankRotation = Mathf.Repeat(crankRotation + num, 1f);
			crankRotationReadOut.Value = crankRotation;
			int num2 = CheckChuff(prevCrankRotation, num);
			float num3 = Mathf.Abs(crankRpm.Value);
			isReverserForward = reverserControl.Value >= 0f;
			cutoff = Mathf.Lerp(minCutoff, maxCutoff, Mathf.Abs(reverserControl.Value));
			SimulateValveFlow();
			float num4 = Mathf.Max(0f, admissionPressure - 1f);
			float num5 = Mathf.InverseLerp(0f, 3f, num4);
			float value = cylinderCockControl.Value;
			cylinderCockFlowNormalizedReadOut.Value = num5 * value;
			float num6 = Mathf.Lerp(0f, 0.1f, value) * num4;
			bool flag = isCylinderCrackedReadOut.Value > 0f;
			float num7 = (flag ? (0.5f * num4) : 0f);
			cylinderCrackFlowNormalizedReadOut.Value = (flag ? (1f * num5) : 0f);
			float num8 = num6 + num7;
			float num9 = Mathf.Max(1f, admissionPressure - num8);
			condensationExpansionRatio = CondensationExpansionRatio();
			exhaustPressureReadOut.Value = cutoff * num9;
			int num10 = 0;
			for (int i = 0; i < numCylinders; i++)
			{
				cylinderData[i].SimulateCylinder(pistonRotationLead * (float)i);
				if (cylinderData[i].isInletValveOpen)
				{
					num10 += 1 << i;
				}
			}
			cylindersInletValveOpen.Value = num10;
			float target = ((num3 < 45f) ? SimulateInstantaneousTorque(num9) : ((!(num3 > 60f)) ? Mathf.Lerp(SimulateInstantaneousTorque(num9), SimulateMeanTorque(num9), Mathf.InverseLerp(45f, 60f, num3)) : SimulateMeanTorque(num9)));
			float value2 = healthStateExtIn.Value;
			float num11 = (gameParams.DrivetrainFailuresAllowed ? NumberUtil.MapClamp(value2, 0.3f, 0f, 1f, 0f) : 1f);
			torqueOut.Value = num11 * Mathf.SmoothDamp(torqueOut.Value, target, ref torqueVelocity, 0.1f, float.PositiveInfinity, delta);
			bool flag2 = (float)num10 * num4 > 0f;
			float steamLossMassRate = SimulateSteamConsumption(num3, admissionPressure, num9, num8, flag2);
			bool flag3 = Mathf.Sign(crankRpm.Value) > 0f;
			float num12 = ((isReverserForward != flag3) ? cutoff : 0f);
			ashesInPipesReadOut.Value = num12;
			if (num2 > 0 && num12 > 0f)
			{
				damageThisTick += (float)num2 * ashChuffDamage * num12;
			}
			SimulateWaterInCylinders(flag2, num2, delta);
			SimulateDamage(Mathf.Abs(num));
			SimulateSteamChest(steamLossMassRate, num2, delta);
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			if (isCylinderCrackedReadOut.Value > 0f)
			{
				jObject.SetBool("cylCracked", value: true);
			}
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			if (savedData.GetBool("cylCracked").HasValue)
			{
				isCylinderCrackedReadOut.Value = 1f;
			}
		}
	}
}
