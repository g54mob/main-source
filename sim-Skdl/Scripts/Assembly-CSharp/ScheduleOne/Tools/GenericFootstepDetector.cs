using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Tools
{
	public abstract class GenericFootstepDetector : MonoBehaviour
	{
		private const float GroundDetectionRange = 0.15f;

		private const float GroundDetectionRayOriginShift = 0.5f;

		[SerializeField]
		private float _baseVolume;

		[SerializeField]
		private float _stepDetectionCooldown;

		[SerializeField]
		protected Transform _referencePoint;

		private float _timeOnLastStep;

		private static LayerMask _groundDetectionLayerMask;

		public float VolumeMultiplier { get; set; }

		private void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected void TriggerStep(EMaterialType materialType, Vector3 stepPosition)
		{
		}

		protected bool IsCooldown()
		{
			return false;
		}

		protected bool IsGrounded(out EMaterialType surfaceType)
		{
			surfaceType = default(EMaterialType);
			return false;
		}
	}
}
