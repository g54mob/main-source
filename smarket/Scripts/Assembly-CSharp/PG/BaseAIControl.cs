using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(CarController))]
	public class BaseAIControl : MonoBehaviour, ICarControl
	{
		public BaseAIConfigAsset AIConfigAsset;

		protected BaseAIConfig BaseAIConfig;

		protected AITrigger ActiveTrigger;

		protected float MaxSpeed => 0f;

		protected float MinSpeed => 0f;

		protected float ReverseWaitTime => 0f;

		protected float ReverseTime => 0f;

		protected float BetweenReverseTimeForReset => 0f;

		protected float OffsetToTargetPoint => 0f;

		protected float SpeedFactorToTargetPoint => 0f;

		protected float OffsetTurnPrediction => 0f;

		protected float SpeedFactorToTurnPrediction => 0f;

		protected float LookAngleSppedFactor => 0f;

		protected float SetSteerAngleMultiplayer => 0f;

		public float Acceleration { get; protected set; }

		public float BrakeReverse { get; protected set; }

		public float Horizontal { get; protected set; }

		public float Pitch { get; protected set; }

		public bool HandBrake { get; protected set; }

		public bool Boost { get; protected set; }

		public CarController Car { get; protected set; }

		public LayerMask AiDetectionMask { get; private set; }

		protected float Vertical
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual void Start()
		{
		}

		protected virtual void FixedUpdate()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private void SetActiveTrigger(AITrigger trigger)
		{
		}
	}
}
