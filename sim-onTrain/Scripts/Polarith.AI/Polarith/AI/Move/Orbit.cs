using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Orbit : SteeringBehaviour
	{
		public enum PlaneType
		{
			PlaneXY = 0,
			PlaneXZ = 1,
			PlaneYZ = 2
		}

		[Tooltip("Determines the plane on which the orbit is mapped.")]
		public PlaneType Plane;

		[Tooltip("This is the radius which determines the size of the orbit.")]
		public float Radius = 5f;

		[Tooltip("Determines how far the agent is able to move towards the object and away from the orbit.")]
		public float MinDeviation = 1f;

		[Tooltip("Determines how far the agent is able to move away from the object and towards the orbit.")]
		public float MaxDeviation = 1f;

		[Tooltip("Specifies the target position on the orbit. This depends on the agent's location relative to the target. The sign determines the movement direction, positive is clockwise and negative counter-clockwise.")]
		public float DeltaAngle = 10f;

		private Vector3 targetPosition;

		private Vector3 distancePercept;

		private float angle;

		public Vector3 TargetPosition => targetPosition;

		protected override bool forEachPercept => false;

		protected override bool forEachReceptor => false;

		protected override bool StartSteering()
		{
			switch (Plane)
			{
			case PlaneType.PlaneXY:
				angle = Vector3.Angle(Vector3.right, self.Position - percept.Position);
				if (self.Position.y < percept.Position.y)
				{
					angle = 360f - angle;
				}
				break;
			case PlaneType.PlaneXZ:
				angle = Vector3.Angle(Vector3.right, self.Position - percept.Position);
				if (self.Position.z < percept.Position.z)
				{
					angle = 360f - angle;
				}
				break;
			case PlaneType.PlaneYZ:
				angle = Vector3.Angle(Vector3.forward, self.Position - percept.Position);
				if (self.Position.y < percept.Position.y)
				{
					angle = 360f - angle;
				}
				break;
			}
			distancePercept = self.Position - percept.Position;
			if (distancePercept.sqrMagnitude > (Radius - MinDeviation) * (Radius - MinDeviation) && distancePercept.sqrMagnitude < (Radius + MaxDeviation) * (Radius + MaxDeviation))
			{
				angle -= DeltaAngle;
			}
			targetPosition = percept.Position;
			switch (Plane)
			{
			case PlaneType.PlaneXY:
				targetPosition.x += Radius * Mathf.Cos(angle * ((float)Math.PI / 180f));
				targetPosition.y += Radius * Mathf.Sin(angle * ((float)Math.PI / 180f));
				break;
			case PlaneType.PlaneXZ:
				targetPosition.x += Radius * Mathf.Cos(angle * ((float)Math.PI / 180f));
				targetPosition.z += Radius * Mathf.Sin(angle * ((float)Math.PI / 180f));
				break;
			case PlaneType.PlaneYZ:
				targetPosition.z += Radius * Mathf.Cos(angle * ((float)Math.PI / 180f));
				targetPosition.y += Radius * Mathf.Sin(angle * ((float)Math.PI / 180f));
				break;
			}
			ResultDirection = targetPosition - self.Position;
			ResultMagnitude = 1f;
			return true;
		}
	}
}
