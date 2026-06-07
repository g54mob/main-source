using LocoSim.Implementations;
using LocoSim.Resources;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class BoilerDefinition : SimComponentDefinition, IDefaultMassProvider
	{
		[Header("Dimensions")]
		public float diameter;

		public float length;

		public float capacityMultiplier;

		public float thermalInsulance = 0.04f;

		[Header("Injector")]
		public float maxInjectorRate;

		public float defaultFeedwaterTemperature = 110f;

		public float waterConsumptionMultiplier = 1f;

		[Header("Blowdown")]
		public float maxBlowdownRate = 10f;

		[Header("Safety valve")]
		public float safetyValveOpeningPressure;

		public float safetyValveClosingPressure;

		public float safetyValveSlop;

		public float maxSafetyValveVentRate;

		[Header("Spawn")]
		public float spawnPressure;

		public float spawnWaterLevel;

		[Header("Damage")]
		public float crownSheetNormalizedWaterLevel;

		public float crownSheetTempSmoothTime;

		public float crownSheetOverheatTemp;

		public float minimumExplosionPressure;

		public AnimationCurve explosionPressureThreshold;

		public float steamOutletNormalizedWaterLevel = 0.95f;

		public readonly PortReferenceDefinition injectorControl = new PortReferenceDefinition(PortValueType.CONTROL, "INJECTOR");

		public readonly PortReferenceDefinition blowdownControl = new PortReferenceDefinition(PortValueType.CONTROL, "BLOWDOWN");

		public readonly PortReferenceDefinition heat = new PortReferenceDefinition(PortValueType.HEAT_RATE, "HEAT");

		public readonly PortReferenceDefinition fireboxTemperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "FIREBOX_TEMPERATURE");

		public readonly PortReferenceDefinition feedwaterTemperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "FEEDWATER_TEMPERATURE");

		public readonly PortDefinition angleExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.GENERIC, "BOILER_ANGLE_EXT_IN");

		public readonly PortReferenceDefinition steamConsumption = new PortReferenceDefinition(PortValueType.MASS_RATE, "STEAM_CONSUMPTION");

		public readonly PortDefinition pressureReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.PRESSURE, "PRESSURE");

		public readonly PortDefinition temperatureReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortDefinition injectorFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.WATER, "INJECTOR_FLOW_NORMALIZED");

		public readonly PortDefinition blowdownFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.WATER, "BLOWDOWN_FLOW_NORMALIZED");

		public readonly PortDefinition waterLevelReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.WATER, "WATER_LEVEL_NORMALIZED");

		public readonly PortDefinition waterMassReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.WATER, "WATER_MASS");

		public readonly PortDefinition outletSteamQualityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "OUTLET_STEAM_QUALITY");

		public readonly PortReferenceDefinition water = new PortReferenceDefinition(PortValueType.WATER, "WATER");

		public readonly PortReferenceDefinition waterConsumption = new PortReferenceDefinition(PortValueType.WATER, "WATER_CONSUMPTION", writeAllowed: true);

		public readonly PortDefinition waterChangeRequestedExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.WATER, "WATER_CHANGE_REQUESTED_EXT_IN");

		public readonly PortDefinition safetyValveReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "SAFETY_VALVE_NORMALIZED");

		public readonly PortDefinition normalizedCrownSheetTemperatureReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TEMPERATURE, "CROWN_SHEET_TEMPERATURE_NORMALIZED");

		public readonly PortDefinition bodyHealthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "BODY_HEALTH_EXT_IN");

		public readonly PortDefinition isBrokenReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IS_BROKEN");

		public readonly PortDefinition enthalpyReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "ENTHALPY");

		public readonly PortDefinition powerInReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "POWER_IN");

		public readonly PortDefinition powerOutReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.POWER, "POWER_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new Boiler(this);
		}

		public float DefaultMassValue()
		{
			return spawnWaterLevel * ResourceContainerType.WATER.GetResourceMassMultiplier();
		}
	}
}
