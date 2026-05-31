using UnityEngine;

namespace PG
{
	public class DriftAIControl : PositioningAIControl
	{
		private DriftAIConfig DriftAIConfig;

		private bool Reverse;

		private float ReverseTimer;

		private float PrevSpeed;

		private float LastReverseTime;

		private Rigidbody AheadRB;

		private float DistanceToAheadRB;

		private RaycastHit MainHit;

		private float LastMainHitTime;

		private float StartPointDistance;

		private float ObstacleHitDistance => 0f;

		private float HitPointHeight => 0f;

		private float HitDellayTime => 0f;

		public Vector3 TargetPointResult { get; private set; }

		public AIPath.RoutePoint TargetPoint { get; private set; }

		public AIPath.RoutePoint TurnPredictionPoint { get; private set; }

		public override void Start()
		{
		}

		protected override void FixedUpdate()
		{
		}

		private void ForwardMove()
		{
		}

		private void ReverseMove()
		{
		}

		private void StartHits()
		{
		}

		private void UpdateMainHit()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
