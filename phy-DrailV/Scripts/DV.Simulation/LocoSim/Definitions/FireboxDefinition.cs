using LocoSim.Implementations;
using LocoSim.Resources;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class FireboxDefinition : SimComponentDefinition, IDefaultMassProvider
	{
		[Header("Capacity")]
		public float maxCoalCapacity = 80f;

		public float coalDumpRate = 10f;

		[Header("Combustion")]
		public float burnTime = 120f;

		public float efficiencyAtMaxCombustion = 0.5f;

		public float combustionRateSmoothTime = 5f;

		public float temperatureSmoothTime = 15f;

		[Header("Fast Startup")]
		public float startupMaxPressure = 13f;

		public readonly PortReferenceDefinition coalDumpControl = new PortReferenceDefinition(PortValueType.CONTROL, "COAL_DUMP_CONTROL");

		public readonly PortReferenceDefinition intakeWaterContent = new PortReferenceDefinition(PortValueType.STATE, "INTAKE_WATER_CONTENT");

		public readonly PortDefinition coalCapacityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.COAL, "COAL_CAPACITY");

		public readonly PortDefinition coalLevelReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.COAL, "COAL_LEVEL");

		public readonly PortDefinition coalLevelNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.COAL, "COAL_LEVEL_NORMALIZED");

		public readonly PortDefinition coalControlExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "COAL_CONTROL_EXT_IN");

		public readonly PortDefinition coalEnvDamage = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.COAL, "COAL_ENV_DAMAGE_METER");

		public readonly PortDefinition ignitionExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "IGNITION_EXT_IN");

		public readonly PortDefinition extinguishExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "EXTINGUISH_EXT_IN");

		public readonly PortReferenceDefinition airFlow = new PortReferenceDefinition(PortValueType.MASS_RATE, "AIR_FLOW");

		public readonly PortDefinition heatReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.HEAT_RATE, "HEAT");

		public readonly PortDefinition fireOnReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "FIRE_ON");

		public readonly PortDefinition coalDumpFlowNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.COAL, "COAL_DUMP_FLOW_NORMALIZED");

		public readonly PortDefinition smokeDensityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "SMOKE_DENSITY");

		public readonly PortDefinition combustionRateNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.COAL, "COMBUSTION_RATE_NORMALIZED");

		public readonly PortDefinition temperatureReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.TEMPERATURE, "TEMPERATURE");

		public readonly PortReferenceDefinition forwardSpeed = new PortReferenceDefinition(PortValueType.GENERIC, "FORWARD_SPEED");

		public readonly PortReferenceDefinition boilerPressure = new PortReferenceDefinition(PortValueType.PRESSURE, "BOILER_PRESSURE");

		public readonly PortReferenceDefinition boilerTemperature = new PortReferenceDefinition(PortValueType.TEMPERATURE, "BOILER_TEMPERATURE");

		public readonly PortReferenceDefinition boilerBrokenState = new PortReferenceDefinition(PortValueType.STATE, "BOILER_BROKEN_STATE");

		public readonly PortDefinition oxygenAvailabilityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "OXYGEN_AVAILABILITY");

		public override SimComponent InstantiateImplementation()
		{
			return new Firebox(this);
		}

		public float DefaultMassValue()
		{
			return maxCoalCapacity * ResourceContainerType.COAL.GetResourceMassMultiplier();
		}
	}
}
