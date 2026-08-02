using System;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	public class PhysicsSettings
	{
		public enum ForceApplyType
		{
			Initial = 0,
			Continuous = 1
		}

		public ForceApplyType forceApplyType;

		public int maxIterations = 1000;

		public Vector2 forceMinMax = Vector2.zero;

		public float forceAngleInDegrees;

		public bool randomizeForceAngle;

		[Range(1f, 60f)]
		public float simulationTime = 3f;

		[Range(1f, 1000f)]
		public int simulationSteps = 1;

		public CollisionDetectionMode collisionDetectionMode = CollisionDetectionMode.Continuous;
	}
}
