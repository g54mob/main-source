using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class ReciprocatingSteamEngineDefinition : SimComponentDefinition
	{
		public int numCylinders = 2;

		public float cylinderBore = 0.533f;

		public float pistonStroke = 0.711f;

		public float minCutoff = 0.05f;

		public float maxCutoff = 0.9f;

		[Header("Throttle and steam chest")]
		public float throttleMaxFlow;

		public float steamChestVolume;

		[Header("Water in cylinders")]
		public float cylinderHeatRate = 0.05f;

		public float maxCondensationRate = 0.015f;

		public float primingRate = 0.05f;

		public float maxWaterExpulsionRate = 0.015f;

		public float waterDrainPercentagePerSecond = 0.3f;

		public float waterDamagePercentagePerChuff = 0.025f;

		public float waterDamageRestorePerSecond = 0.03f;

		[Header("Damage")]
		public float cylinderCrackDamage = 100f;

		public float passiveDamagePerRev = 0.01f;

		public float noOilDamagePerRev = 1f;

		public float ashChuffDamage = 1f;

		public readonly PortReferenceDefinition throttleControl = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE_CONTROL");

		public readonly PortReferenceDefinition reverserControl = new PortReferenceDefinition(PortValueType.CONTROL, "REVERSER_CONTROL");

		public readonly PortReferenceDefinition cylinderCockControl = new PortReferenceDefinition(PortValueType.CONTROL, "CYLINDER_COCK_CONTROL");

		public readonly PortReferenceDefinition intakePressure = new PortReferenceDefinition(PortValueType.PRESSURE, "INTAKE_PRESSURE");

		public readonly PortReferenceDefinition intakeTemperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "INTAKE_TEMPERATURE");

		public readonly PortReferenceDefinition intakeQuality = new PortReferenceDefinition(PortValueType.GENERIC, "INTAKE_QUALITY");

		public readonly PortDefinition crankRotationReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CRANK_ROTATION");

		public readonly PortReferenceDefinition crankRpm = new PortReferenceDefinition(PortValueType.RPM, "CRANK_RPM");

		public readonly PortDefinition cylindersInletValveOpen = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CYLINDERS_INLET_VALVE_OPEN");

		public readonly PortDefinition maxFlowReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "MAX_FLOW");

		public readonly PortDefinition intakeFlowReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "INTAKE_FLOW");

		public readonly PortDefinition intakeFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "INTAKE_FLOW_NORMALIZED");

		public readonly PortDefinition exhaustFlowReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.MASS_RATE, "EXHAUST_FLOW");

		public readonly PortDefinition exhaustPressureReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.PRESSURE, "EXHAUST_PRESSURE");

		public readonly PortDefinition exhaustTemperatureReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TEMPERATURE, "EXHAUST_TEMPERATURE");

		public readonly PortDefinition chuffEventReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CHUFF_EVENT");

		public readonly PortDefinition chuffFrequencyReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CHUFF_FREQUENCY");

		public readonly PortDefinition cylinderTemperatureReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TEMPERATURE, "CYLINDER_TEMPERATURE");

		public readonly PortDefinition waterInCylindersNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "WATER_IN_CYLINDERS_NORMALIZED");

		public readonly PortDefinition ashesInPipesReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ASHES_IN_PIPES");

		public readonly PortDefinition cylinderCockFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CYLINDER_COCK_FLOW_NORMALIZED");

		public readonly PortDefinition cylinderCrackFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CYLINDER_CRACK_FLOW_NORMALIZED");

		public readonly PortDefinition steamChestPressureReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.PRESSURE, "STEAM_CHEST_PRESSURE");

		public readonly PortReferenceDefinition lubricationNormalized = new PortReferenceDefinition(PortValueType.OIL, "LUBRICATION_NORMALIZED");

		public readonly PortDefinition healthStateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "HEALTH_STATE_EXT_IN");

		public readonly PortDefinition generatedMechanicalDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_MECHANICAL_DAMAGE");

		public readonly PortDefinition isCylinderCrackedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "IS_CYLINDER_CRACKED");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new ReciprocatingSteamEngine(this);
		}
	}
}
