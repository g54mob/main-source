using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will let you apply forces and torques (relative or not) to a Rigidbody.")]
	[FeedbackPath("GameObject/Rigidbody2D")]
	[AddComponentMenu(null)]
	public class MMFeedbackRigidbody2D : MMFeedback
	{
		public enum Modes
		{
			AddForce = 0,
			AddRelativeForce = 1,
			AddTorque = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Rigidbody")]
		[Tooltip("the rigidbody to target on play")]
		public Rigidbody2D TargetRigidbody2D;

		[Tooltip("the selected mode for this feedback")]
		public Modes Mode;

		[Tooltip("the min force or torque to apply")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 MinForce;

		[Tooltip("the max force or torque to apply")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 MaxForce;

		[MMFEnumCondition("Mode", new int[] { 2 })]
		[Tooltip("the min torque to apply to this rigidbody on play")]
		public float MinTorque;

		[Tooltip("the max torque to apply to this rigidbody on play")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float MaxTorque;

		[Tooltip("the force mode to apply")]
		public ForceMode2D AppliedForceMode;

		protected Vector2 _force;

		protected float _torque;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
