using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Wander : SteeringBehaviour
	{
		[Obsolete("Use 'Planar Mapping Type' instead.")]
		public Vector3 Up = Vector3.forward;

		[Tooltip("The lower limit for randomly generated angles regarding new wander directions.")]
		public float AngleDeviationMin;

		[Tooltip("The upper limit for randomly generated angles regarding new wander directions.")]
		public float AngleDeviationMax = 25f;

		[Tooltip("The lower limit for randomly determined values used as duration to generate new wander directions.")]
		public float TimeDeviationMin;

		[Tooltip("The upper limit for randomly determined values used as duration to generate new wander directions.")]
		public float TimeDeviationMax = 1f;

		[Range(0f, 1f)]
		[Tooltip("Every time the behaviour makes a new random decision, it can either decide to go steady until the next decision or generate a random angle. With a high 'Steadiness', the behaviour is more likely to stick to its current direction.")]
		public float Steadiness;

		[SerializeField]
		[Tooltip("Determines if the behaviour result gets mapped to either the XY-plane (2D mode), the XZ-plane (3D with ground), the plane is determined automatically via the attached sensor, or whether no mapping is used at all (general 3D).")]
		private PlanarMappingType planarMappingType = PlanarMappingType.Automatic;

		private static int seed = (int)DateTime.UtcNow.Ticks;

		private System.Random rand;

		private Vector3 velocityNorm;

		private Vector3 up;

		private Vector3 globalUp;

		private Vector3 globalRight;

		private Vector3 rightDir;

		private Vector2 angles;

		private float currentTime = 1f;

		private float time;

		public PlanarMappingType PlanarMappingType => planarMappingType;

		protected override bool forEachPercept => false;

		protected override bool forEachReceptor => false;

		public Wander()
		{
			seed = (seed + 1) % int.MaxValue;
			rand = new System.Random(seed);
			VectorProjection = VectorProjectionType.PlaneXY;
		}

		public void SetPlanarMappingType(PlanarMappingType mappingType, PlanarOrientationType orientation = PlanarOrientationType.PlaneXY)
		{
			planarMappingType = mappingType;
			ResultDirection = Vector3.zero;
			switch (planarMappingType)
			{
			case PlanarMappingType.Automatic:
				up = ((orientation == PlanarOrientationType.PlaneXY) ? Vector3.forward : Vector3.up);
				break;
			case PlanarMappingType.PlaneXY:
				up = Vector3.forward;
				break;
			case PlanarMappingType.PlaneXZ:
				up = Vector3.up;
				break;
			default:
				up = Vector3.up;
				break;
			}
		}

		protected override bool StartSteering()
		{
			if (up.magnitude < 1E-06f)
			{
				return false;
			}
			if (self.Velocity.magnitude < 1E-06f)
			{
				velocityNorm = ((sensor.ReceptorCount >= 0) ? sensor.GetReceptor(0).Structure.Direction : ResultDirection);
			}
			else
			{
				velocityNorm = self.Velocity.normalized;
			}
			if (currentTime > time)
			{
				angles = Vector2.zero;
				if ((float)rand.NextDouble() > Steadiness)
				{
					angles.x = GetRandomAngle();
					angles.y = GetRandomAngle();
				}
				time = TimeDeviationMin + (float)rand.NextDouble() * (TimeDeviationMax - TimeDeviationMin);
				currentTime = 0f;
				currentTime = 0f;
			}
			ResultMagnitude = MagnitudeMultiplier;
			globalUp = Self.Rotation * up;
			ResultDirection = Quaternion.AngleAxis(angles.x, globalUp) * velocityNorm;
			if (planarMappingType == PlanarMappingType.None)
			{
				globalRight = Vector3.Cross(globalUp, velocityNorm);
				rightDir = Quaternion.AngleAxis(angles.y, globalRight) * velocityNorm;
				ResultDirection = Vector3.Slerp(ResultDirection, rightDir, 0.5f);
			}
			currentTime += Context.DeltaTime;
			return true;
		}

		private float GetRandomAngle()
		{
			float num = 0f;
			num = AngleDeviationMin + (float)rand.NextDouble() * (AngleDeviationMax - AngleDeviationMin);
			if (rand.Next(0, 2) == 0)
			{
				num = 0f - num;
			}
			return num;
		}
	}
}
