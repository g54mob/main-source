using UnityEngine;

namespace PG
{
	public class RaceAIControl : PositioningAIControl
	{
		private RaceAIConfig RaceAIConfig;

		private bool Reverse;

		private float ReverseTimer;

		private float PrevSpeed;

		private float LastReverseTime;

		private Vector3 HorizontalOffset;

		private Rigidbody AheadRB;

		private float DistanceToAheadCollider;

		private RaycastHit[] MainHits;

		private RaycastHit[] AdditionalHits;

		private Vector3[] MainHitPoints;

		private Vector3[] AdditionalHitPoints;

		private float LastMainHitsTime;

		private float LastAdditionalHitsTime;

		private float Aggressiveness => 0f;

		private float ObstacleHitDistance => 0f;

		private float HitPointHeight => 0f;

		private float ChangeHorizontalOffsetSpeed => 0f;

		private float OffsetForMainHitPoints => 0f;

		private float OffsetForMainHitDirections => 0f;

		private float OffsetForAdditionalHitPoints => 0f;

		private float MainHitDellayTime => 0f;

		private float AdditionalHitDellayTime => 0f;

		public float TargetDist { get; private set; }

		public AIPath.RoutePoint TargetPoint { get; private set; }

		public AIPath.RoutePoint TurnPredictionPoint { get; private set; }

		public float CurrentHorizontalOffset { get; set; }

		public override void Start()
		{
		}

		protected override void FixedUpdate()
		{
		}

		private void ForwardMove()
		{
		}

		private void StartHits()
		{
		}

		private void UpdateMainHits()
		{
		}

		private void UpdateAdditionalHits()
		{
		}

		private void ReverseMove()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
