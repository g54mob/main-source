using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you apply forces and torques (relative or not) to a Rigidbody.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("GameObject/Rigidbody2D")]
	public class MMF_Rigidbody2D : MMF_Feedback
	{
		public enum Modes
		{
			AddForce = 0,
			AddRelativeForce = 1,
			AddTorque = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Rigidbody2D", true, 32, true, false)]
		[Tooltip("the rigidbody to target on play")]
		public Rigidbody2D TargetRigidbody2D;

		[Tooltip("an extra list of rigidbodies to target on play")]
		public List<Rigidbody2D> ExtraTargetRigidbodies2D;

		[Tooltip("the selected mode for this feedback")]
		public Modes Mode;

		[Tooltip("the min force or torque to apply")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 MinForce;

		[Tooltip("the max force or torque to apply")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 MaxForce;

		[Tooltip("the min torque to apply to this rigidbody on play")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float MinTorque;

		[Tooltip("the max torque to apply to this rigidbody on play")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float MaxTorque;

		[Tooltip("the force mode to apply")]
		public ForceMode2D AppliedForceMode = ForceMode2D.Impulse;

		[Tooltip("if this is true, the velocity of the rigidbody will be reset before applying the new force")]
		public bool ResetVelocityOnPlay;

		protected Vector2 _force;

		protected float _torque;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetRigidbody2D = FindAutomatedTarget<Rigidbody2D>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || TargetRigidbody2D == null)
			{
				return;
			}
			ApplyForce(TargetRigidbody2D, feedbacksIntensity);
			foreach (Rigidbody2D item in ExtraTargetRigidbodies2D)
			{
				ApplyForce(item, feedbacksIntensity);
			}
		}

		protected virtual void ApplyForce(Rigidbody2D rb, float feedbacksIntensity)
		{
			if (ResetVelocityOnPlay)
			{
				rb.linearVelocity = Vector2.zero;
			}
			switch (Mode)
			{
			case Modes.AddForce:
				_force.x = Random.Range(MinForce.x, MaxForce.x);
				_force.y = Random.Range(MinForce.y, MaxForce.y);
				if (!Timing.ConstantIntensity)
				{
					_force *= feedbacksIntensity;
				}
				rb.AddForce(_force, AppliedForceMode);
				break;
			case Modes.AddRelativeForce:
				_force.x = Random.Range(MinForce.x, MaxForce.x);
				_force.y = Random.Range(MinForce.y, MaxForce.y);
				if (!Timing.ConstantIntensity)
				{
					_force *= feedbacksIntensity;
				}
				rb.AddRelativeForce(_force, AppliedForceMode);
				break;
			case Modes.AddTorque:
				_torque = Random.Range(MinTorque, MaxTorque);
				if (!Timing.ConstantIntensity)
				{
					_torque *= feedbacksIntensity;
				}
				rb.AddTorque(_torque, AppliedForceMode);
				break;
			}
		}
	}
}
