using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class PlanarAvoid : RadiusSteeringBehaviour
	{
		[Tooltip("Influences the preferred avoidance direction relative to an agent's movement direction.\n\nThe agent will get interest into both left and right according to its movement direction with respect to the 'AvoidanceAngle' in degrees based on how much these directions are facing towards the processed percept.")]
		[Range(0f, 180f)]
		public float AvoidanceAngle = 25f;

		[Tooltip("The direction which is used to rotate the forward direction about the specified 'AvoidanceAngle'.\n\nThis vector must be perpendicular to an agent's forward direction, e.g., if the agent moves in the x/y-plane, this vector needs always to be (0, 0, 1).")]
		public Vector3 Up = Vector3.forward;

		private Vector3 tmp;

		private float val1;

		private float val2;

		private int i;

		protected override bool forEachPercept => true;

		protected override bool forEachReceptor => false;

		protected override void PerceptSteering()
		{
			ResultDirection = Quaternion.AngleAxis(0f - AvoidanceAngle, Up) * self.Velocity;
			val1 = Vector3.Dot(ResultDirection.normalized, startDirection.normalized);
			val1 = ((val1 <= 0f) ? 0f : val1);
			tmp = Quaternion.AngleAxis(AvoidanceAngle, Up) * self.Velocity;
			val2 = Vector3.Dot(tmp.normalized, startDirection.normalized);
			val2 = ((val2 <= 0f) ? 0f : val2);
			ResultMagnitude = val2 * startMagnitude;
			for (i = 0; i < sensor.ReceptorCount; i++)
			{
				structure = sensor.GetReceptor(i).Structure;
				WriteValue(ValueWritingType.AssignGreater, TargetObjective, i, (UseSignificance ? percept.Significance : 1f) * MagnitudeMultiplier * structure.Magnitude * val1 * startMagnitude * MapBySensitivity(ValueMapping, structure, tmp, SensitivityOffset), LayerBlending != LayerBlendingType.None);
			}
		}
	}
}
