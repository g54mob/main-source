using Jundroo.Common.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.Guidance
{
	public class PathWaypointModifier : MonoBehaviour
	{
		public enum ModifierType
		{
			NoModifier = 0,
			Override = 1,
			SustainPrevious = 2
		}

		[InspectorFieldOrder(110)]
		public float Brake;

		[InspectorFieldOrder(100)]
		public ModifierType BrakeType = ModifierType.SustainPrevious;

		[InspectorFieldOrder(130)]
		public bool LandingGearDown;

		[InspectorFieldOrder(120)]
		public ModifierType LandingGearType = ModifierType.SustainPrevious;

		[InspectorFieldOrder(150)]
		public float PitchSensitivity = 1f;

		[InspectorFieldOrder(140)]
		public ModifierType PitchSensitivityType = ModifierType.SustainPrevious;

		[InspectorFieldOrder(170)]
		public float RollSensitivity = 1f;

		[InspectorFieldOrder(160)]
		public ModifierType RollSensitivityType = ModifierType.SustainPrevious;

		[InspectorFieldOrder(190)]
		public float Throttle;

		[InspectorFieldOrder(180)]
		public ModifierType ThrottleType = ModifierType.SustainPrevious;
	}
}
