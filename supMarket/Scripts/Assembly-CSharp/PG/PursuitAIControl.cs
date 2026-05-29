using UnityEngine;

namespace PG
{
	public class PursuitAIControl : BaseAIControl
	{
		public Rigidbody TargetRB;

		private PursuitAIConfig PursuitAIConfig;

		private Vector3 TargetPoint;

		private Vector3 TurnPredictionPoint;

		private float VisibilityAreaIgnoreObstacleSqr;

		private bool Reverse;

		private float ReverseTimer;

		private float PrevSpeed;

		private float LastReverseTime;

		private float LastHitTime;

		private float StartHitPointDistance;

		private RaycastHit Hit;

		private bool InPursuit;

		private LayerMask ObstacleHitMask => default(LayerMask);

		private float HitPointHeight => 0f;

		private float VisibilityArea => 0f;

		private float VisibilityAreaIgnoreObstacle => 0f;

		private float HitDellayTime => 0f;

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

		private void UpdateHit()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
