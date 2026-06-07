using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.Feel
{
	public class Blob : MonoBehaviour
	{
		[Tooltip("a duration, in seconds, between two moves, during which moves are prevented")]
		[Header("Cooldown")]
		public float CooldownDuration;

		[Tooltip("a feedback to call when moving")]
		[Header("Feedbacks")]
		public MMFeedbacks MoveFeedback;

		[Tooltip("a feedback to call when trying to move while in cooldown")]
		public MMFeedbacks DeniedFeedback;

		protected float _lastMoveStartedAt;

		protected virtual void Update()
		{
		}

		protected virtual void HandleInput()
		{
		}

		protected virtual void Move()
		{
		}
	}
}
