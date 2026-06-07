using System;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[Serializable]
	public class PlanarMovementParameters
	{
		[Serializable]
		public struct PlanarMovementProperties
		{
			[Tooltip("How fast the character increses its current velocity.")]
			public float acceleration;

			[Tooltip("How fast the character reduces its current velocity.")]
			public float deceleration;

			[Tooltip("How fast the character reduces its current velocity.")]
			public float angleAccelerationMultiplier;

			public PlanarMovementProperties(float acceleration, float deceleration, float angleAccelerationBoost)
			{
				this.acceleration = acceleration;
				this.deceleration = deceleration;
				angleAccelerationMultiplier = angleAccelerationBoost;
			}
		}

		[Min(0f)]
		public float baseSpeedLimit = 6f;

		[Header("Run (boost)")]
		public bool canRun = true;

		[Tooltip("\"Toggle\" will activate/deactivate the action when the input is \"pressed\". On the other hand, \"Hold\" will activate the action when the input is pressed, and deactivate it when the input is \"released\".")]
		public InputMode runInputMode = InputMode.Hold;

		[Min(0f)]
		public float boostSpeedLimit = 10f;

		[Header("Stable grounded parameters")]
		public float stableGroundedAcceleration = 50f;

		public float stableGroundedDeceleration = 40f;

		public AnimationCurve stableGroundedAngleAccelerationBoost = AnimationCurve.EaseInOut(0f, 1f, 180f, 2f);

		[Header("Unstable grounded parameters")]
		public float unstableGroundedAcceleration = 10f;

		public float unstableGroundedDeceleration = 2f;

		public AnimationCurve unstableGroundedAngleAccelerationBoost = AnimationCurve.EaseInOut(0f, 1f, 180f, 1f);

		[Header("Not grounded parameters")]
		public float notGroundedAcceleration = 20f;

		public float notGroundedDeceleration = 5f;

		public AnimationCurve notGroundedAngleAccelerationBoost = AnimationCurve.EaseInOut(0f, 1f, 180f, 1f);
	}
}
