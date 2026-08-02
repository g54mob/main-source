using System;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public class Pursue : RadiusSteeringBehaviour
	{
		[Tooltip("Threshold for the maximum prediction time of the computed point.")]
		public float MaxPredictionTime = 2f;

		public bool ForEachReceptor;

		private Vector3 targetPosition;

		private Vector3 receptorDistance;

		private float time;

		private float directionMatching;

		public Vector3 TargetPosition => targetPosition;

		protected override bool forEachPercept => !ForEachReceptor;

		protected override bool forEachReceptor => ForEachReceptor;

		protected override bool StartSteering()
		{
			if (!base.StartSteering())
			{
				return false;
			}
			directionMatching = 1f - Mathf.Abs(Vector3.Dot(percept.Velocity.normalized, self.Velocity.normalized));
			return true;
		}

		protected override void PerceptSteering()
		{
			time = startDirection.sqrMagnitude / self.Velocity.sqrMagnitude;
			if (time > MaxPredictionTime)
			{
				time = MaxPredictionTime;
			}
			targetPosition = percept.Velocity * time * directionMatching + percept.Position;
			ResultDirection = targetPosition - self.Position;
			ResultMagnitude = MoveBehaviour.MapSpecial(RadiusMapping, InnerRadius + percept.Radius, OuterRadius + percept.Radius, ResultDirection.magnitude);
		}

		protected override void ReceptorSteering()
		{
			receptorDistance.x = percept.Position.x - self.Position.x - structure.Position.x;
			receptorDistance.y = percept.Position.y - self.Position.y - structure.Position.y;
			receptorDistance.z = percept.Position.z - self.Position.z - structure.Position.z;
			time = receptorDistance.sqrMagnitude / self.Velocity.sqrMagnitude;
			if (time > MaxPredictionTime)
			{
				time = MaxPredictionTime;
			}
			targetPosition = percept.Velocity * time * directionMatching + percept.Position;
			ResultDirection = targetPosition - self.Position - structure.Position;
			ResultMagnitude = MoveBehaviour.MapSpecial(RadiusMapping, InnerRadius + percept.Radius, OuterRadius + percept.Radius, ResultDirection.magnitude);
		}
	}
}
