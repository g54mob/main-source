using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.Feel
{
	public class Tactical : MonoBehaviour
	{
		[Header("Cooldown")]
		[Tooltip("a duration, in seconds, between two shots, during which shots are prevented")]
		public float CooldownDuration;

		[Tooltip("the position of the shot's impact")]
		[Header("Bindings")]
		public Transform ImpactPosition;

		[Tooltip("a feedback to call when shooting")]
		[Header("Feedbacks")]
		public MMFeedbacks ShootFeedback;

		[Tooltip("a feedback to call when shooting stops")]
		public MMFeedbacks ShootStopFeedback;

		[Tooltip("a feedback to call when a reload happens")]
		public MMFeedbacks ReloadFeedback;

		protected float _lastJumpStartedAt;

		protected int _magazine;

		protected virtual void Update()
		{
		}

		protected virtual void HandleInput()
		{
		}

		protected virtual void Shoot()
		{
		}

		protected virtual void ShootStop()
		{
		}
	}
}
