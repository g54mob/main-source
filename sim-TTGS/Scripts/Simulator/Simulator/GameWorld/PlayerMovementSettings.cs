using System;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Player/Movement", Scope.Project)]
	public class PlayerMovementSettings : CustomSettings<PlayerMovementSettings>
	{
		[Serializable]
		public struct NoiseParams
		{
			[SerializeField]
			private float m_frequency;

			[SerializeField]
			private float m_amplitude;

			public float Frequency => m_frequency;

			public float Amplitude => m_amplitude;
		}

		[Header("Speed")]
		[SerializeField]
		private float m_maxWalkingSpeed = 3f;

		[SerializeField]
		private float m_maxSprintingSpeed = 5f;

		[SerializeField]
		private float m_maxCrouchingSpeed = 2f;

		[Header("Gravity")]
		[SerializeField]
		private float m_gravityForce = 9.81f;

		[SerializeField]
		private float m_maxVerticalSpeed = 50f;

		[Header("Jump")]
		[SerializeField]
		private float m_jumpHeight = 1f;

		[SerializeField]
		private float m_groundCheckRadius = 0.05f;

		[SerializeField]
		private LayerMask m_groundCheckMask;

		[Header("Crouch")]
		[SerializeField]
		private float m_baseHeight = 1.7f;

		[SerializeField]
		private float m_crouchHeight = 0.8f;

		[SerializeField]
		private float m_crouchTransitionSpeed = 1f;

		[Header("Step")]
		[SerializeField]
		private float m_timeBetweenStepsWalking;

		[SerializeField]
		private float m_timeBetweenStepsSprinting;

		[Header("Head Bobbing")]
		[SerializeField]
		private EnumValues<PlayerCharacterMovement.EMovementMode, NoiseParams> m_noiseParamsByMovementMode;

		[Tooltip("0: No influence, object move; 1: Full influence, object don't move")]
		[SerializeField]
		[Min(0f)]
		private float m_noiseInfluenceOnTargetToSyncWith;

		public static float MaxWalkingSpeed => CustomSettings<PlayerMovementSettings>.I.m_maxWalkingSpeed;

		public static float MaxSprintingSpeed => CustomSettings<PlayerMovementSettings>.I.m_maxSprintingSpeed;

		public static float MaxCrouchingSpeed => CustomSettings<PlayerMovementSettings>.I.m_maxCrouchingSpeed;

		public static float GravityForce => CustomSettings<PlayerMovementSettings>.I.m_gravityForce;

		public static float MaxVerticalSpeed => CustomSettings<PlayerMovementSettings>.I.m_maxVerticalSpeed;

		public static float JumpHeight => CustomSettings<PlayerMovementSettings>.I.m_jumpHeight;

		public static float CrouchTransitionSpeed => CustomSettings<PlayerMovementSettings>.I.m_crouchTransitionSpeed;

		public static float CrouchHeight => CustomSettings<PlayerMovementSettings>.I.m_crouchHeight;

		public static float BaseHeight => CustomSettings<PlayerMovementSettings>.I.m_baseHeight;

		public static float GroundCheckRadius => CustomSettings<PlayerMovementSettings>.I.m_groundCheckRadius;

		public static int GroundCheckMask => CustomSettings<PlayerMovementSettings>.I.m_groundCheckMask;

		public static float TimeBetweenStepsWalking => CustomSettings<PlayerMovementSettings>.I.m_timeBetweenStepsWalking;

		public static float TimeBetweenStepsSprinting => CustomSettings<PlayerMovementSettings>.I.m_timeBetweenStepsSprinting;

		public static float NoiseInfluenceOnTargetToSyncWith => CustomSettings<PlayerMovementSettings>.I.m_noiseInfluenceOnTargetToSyncWith;

		public static NoiseParams GetNoiseParamsByMovementMode(PlayerCharacterMovement.EMovementMode movementMode)
		{
			return CustomSettings<PlayerMovementSettings>.I.m_noiseParamsByMovementMode[movementMode];
		}
	}
}
