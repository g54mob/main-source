using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMAClothProperties : ScriptableObject
	{
		public float selfcollisionDistance;

		public float selfcollisionStifiness;

		public float bendingStiffness;

		public float clothSolverFrequency;

		public float collisionMassScale;

		public float damping;

		public bool enableContinuousCollision;

		public float friction;

		public float sleepThreshold;

		public float stretchingStiffness;

		public bool useGravity;

		public float useVirtualParticles;

		public Vector3 externalAcceleration;

		public Vector3 randomAcceleration;

		public float worldAccelerationScale;

		public float worldVelocityScale;

		public void ApplyValues(Cloth cloth)
		{
		}

		public void ReadValues(Cloth cloth)
		{
		}
	}
}
