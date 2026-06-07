using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class SmoothTransmissionDefinition : SimComponentDefinition
	{
		public float transitionTime = 1f;

		public float[] gearRatios;

		public float transmissionEfficiency = 1f;

		public AnimationCurve gearChangeEaseCurve;

		[Header("Damage")]
		public float powerShiftRpmThreshold = 400f;

		public float powerShiftDamage = 10f;

		public readonly PortReferenceDefinition gearReader = new PortReferenceDefinition(PortValueType.CONTROL, "GEAR");

		public readonly PortReferenceDefinition throttleReader = new PortReferenceDefinition(PortValueType.CONTROL, "THROTTLE");

		public readonly PortReferenceDefinition retarderReader = new PortReferenceDefinition(PortValueType.CONTROL, "RETARDER");

		public readonly PortReferenceDefinition engineRpmReader = new PortReferenceDefinition(PortValueType.RPM, "ENGINE_RPM");

		public readonly PortDefinition torqueIn = new PortDefinition(PortType.IN, PortValueType.TORQUE, "TORQUE_IN");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public readonly PortDefinition numOfGearsReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "NUM_OF_GEARS");

		public readonly PortDefinition gearRatioReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "GEAR_RATIO");

		public readonly PortDefinition gearChangeInProgressReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "GEAR_CHANGE_IN_PROGRESS");

		public readonly PortDefinition generatedDamageReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.DAMAGE, "GENERATED_DAMAGE");

		public override SimComponent InstantiateImplementation()
		{
			return new SmoothTransmission(this);
		}
	}
}
