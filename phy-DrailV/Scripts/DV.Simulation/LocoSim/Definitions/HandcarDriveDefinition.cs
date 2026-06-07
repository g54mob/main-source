using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class HandcarDriveDefinition : SimComponentDefinition
	{
		public float maxTorqueProduction = 1000f;

		[Tooltip("x-axis should be in [0-1] range")]
		public AnimationCurve positionDiffToTorque;

		public readonly PortDefinition handcarBarExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "BAR_EXT_IN");

		public readonly PortDefinition handleEngagedExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "ENGAGED_EXT_IN");

		public readonly PortDefinition torqueOut = new PortDefinition(PortType.OUT, PortValueType.TORQUE, "TORQUE_OUT");

		public readonly PortDefinition currentPositionOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "CURRENT_POSITION");

		public readonly PortDefinition engagedHandlePositionOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ENGAGED_HANDLE_POSITION");

		public readonly PortDefinition directionOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "DIRECTION");

		public readonly PortDefinition actingAgainstOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "ACTING_AGAINST");

		public readonly PortReferenceDefinition wheelRpm = new PortReferenceDefinition(PortValueType.RPM, "WHEEL_RPM");

		public readonly PortReferenceDefinition gearRatio = new PortReferenceDefinition(PortValueType.GENERIC, "GEAR_RATIO");

		public override SimComponent InstantiateImplementation()
		{
			return new HandcarDrive(this);
		}
	}
}
