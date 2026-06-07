using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.Feel
{
	public class Wheel : MonoBehaviour
	{
		[Tooltip("the part of the wheel that rotates")]
		[Header("Binding")]
		public Transform RotatingPart;

		[Header("Settings")]
		[Tooltip("the speed at which the wheel should rotate")]
		public float RotationSpeed;

		[Tooltip("a feedback to call when the wheel starts turning")]
		[Header("Feedbacks")]
		public MMFeedbacks TurnFeedback;

		[Tooltip("a feedback to call when the wheel stops turning")]
		public MMFeedbacks TurnStopFeedback;

		protected bool _turning;

		protected virtual void Update()
		{
		}

		protected virtual void HandleInput()
		{
		}

		protected virtual void HandleWheel()
		{
		}

		protected virtual void Turn()
		{
		}

		protected virtual void TurnStop()
		{
		}
	}
}
