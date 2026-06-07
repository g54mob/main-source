using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("GameObject/Rigidbody")]
	[FeedbackHelp("This feedback will let you apply forces and torques (relative or not) to a Rigidbody.")]
	[AddComponentMenu(null)]
	public class MMFeedbackRigidbody : MMFeedback
	{
		public enum Modes
		{
			AddForce = 0,
			AddRelativeForce = 1,
			AddTorque = 2,
			AddRelativeTorque = 3
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Rigidbody")]
		[Tooltip("the rigidbody to target on play")]
		public Rigidbody TargetRigidbody;

		[Tooltip("the selected mode for this feedback")]
		public Modes Mode;

		[Tooltip("the min force or torque to apply")]
		public Vector3 MinForce;

		[Tooltip("the max force or torque to apply")]
		public Vector3 MaxForce;

		[Tooltip("the force mode to apply")]
		public ForceMode AppliedForceMode;

		protected Vector3 _force;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
