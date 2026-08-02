using System;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Avoid : RadiusSteeringBehaviour
	{
		[Tooltip("An angular offset for the plane which is used to write objective values to the context. This parameter can be used to manipulate how the agent avoids the object. If this value is 0, the plane remains perpendicular towards the current percept. If this value is greater than 0, the plane is 'bend' towards the direction of the current percept.")]
		[Range(0f, 90f)]
		public float PlaneBend;

		[Tooltip("Can be used to optimize the resulting objective values. If enabled, the current velocity of the agent is used as forward direction. The forward direction is then used to prefer receptors facing both this direction and the plane perpendicular to the percept direction.")]
		public bool UseVelocity;

		[Tooltip("Is used instead of the agent's velocity if 'UseVelocity' is false. The 'DefaultOrientation' is used to determine the agent's alignment by applying the agent's rotation to this direction. The most common scenarios are 'Vector3.up' for 2D games (agent on xy-plane) and 'Vector3.forward' for most 3D games (agent on xz-plane).")]
		public Vector3 DefaultOrientation = Vector3.up;

		protected Vector3 planeDirection1;

		protected Vector3 planeDirection2;

		public Vector3 PlaneDirection1 => planeDirection1;

		public Vector3 PlaneDirection2 => planeDirection2;

		protected override bool forEachPercept => false;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			if (!IsPerceptSignificant())
			{
				return false;
			}
			CalculatePlane();
			float num = 1f;
			num = ((!UseVelocity) ? (Vector3.Dot(startDirection.normalized, self.Rotation * DefaultOrientation) + 1f) : (Vector3.Dot(startDirection.normalized, self.Velocity) + 1f));
			if (num <= 0f)
			{
				num = 0f;
			}
			if (num >= 1f)
			{
				num = 1f;
			}
			for (int i = 0; i < sensor.ReceptorCount; i++)
			{
				receptor = sensor[i];
				structure = receptor.Structure;
				float num2 = (UseSignificance ? percept.Significance : 1f) * MagnitudeMultiplier * structure.Magnitude * startMagnitude * MapBySensitivityPlane(ValueMapping, structure, planeDirection1, planeDirection2, PlaneBend, SensitivityOffset);
				WriteValue(ValueWriting, TargetObjective, receptor.ID, num2 * num);
			}
			return false;
		}

		protected virtual bool IsPerceptSignificant()
		{
			return base.StartSteering();
		}

		protected virtual void CalculatePlane()
		{
			if (Mathf2.Approximately(startDirection.y, 0f) && Mathf2.Approximately(startDirection.x, 0f))
			{
				planeDirection1 = new Vector3(0f - startDirection.z, 0f, startDirection.x);
			}
			else
			{
				planeDirection1 = new Vector3(0f - startDirection.y, startDirection.x, 0f);
			}
			planeDirection2 = new Vector3(0f - startDirection.z * planeDirection1.y, startDirection.z * planeDirection1.x, startDirection.x * planeDirection1.y - startDirection.y * planeDirection1.x);
			planeDirection1.Normalize();
			planeDirection2.Normalize();
		}
	}
}
