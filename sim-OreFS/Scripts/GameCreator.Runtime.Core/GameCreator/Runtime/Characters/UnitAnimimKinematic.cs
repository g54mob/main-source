using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Kinematic")]
	[Image(typeof(IconCharacterRun), ColorTheme.Type.Green)]
	[Category("Kinematic")]
	[Description("Default animation system for characters")]
	public class UnitAnimimKinematic : TUnitAnimim
	{
		private const float DECAY_PIVOT = 5f;

		private const float DECAY_GROUNDED = 10f;

		private const float DECAY_STAND = 5f;

		private static readonly int K_SPEED_X = Animator.StringToHash("Speed-X");

		private static readonly int K_SPEED_Y = Animator.StringToHash("Speed-Y");

		private static readonly int K_SPEED_Z = Animator.StringToHash("Speed-Z");

		private static readonly int K_SPEED_XZ = Animator.StringToHash("Speed-XZ");

		private static readonly int K_SPEED_YZ = Animator.StringToHash("Speed-YZ");

		private static readonly int K_SPEED_XY = Animator.StringToHash("Speed-XY");

		private static readonly int K_INTENT_X = Animator.StringToHash("Intent-X");

		private static readonly int K_INTENT_Y = Animator.StringToHash("Intent-Y");

		private static readonly int K_INTENT_Z = Animator.StringToHash("Intent-Z");

		private static readonly int K_SPEED = Animator.StringToHash("Speed");

		private static readonly int K_PIVOT_SPEED = Animator.StringToHash("Pivot");

		private static readonly int K_GROUNDED = Animator.StringToHash("Grounded");

		private static readonly int K_STAND = Animator.StringToHash("Stand");

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (!(m_Animator == null) && m_Animator.gameObject.activeInHierarchy)
			{
				m_Animator.updateMode = ((base.Character.Time.UpdateTime != TimeMode.UpdateMode.GameTime) ? AnimatorUpdateMode.UnscaledTime : AnimatorUpdateMode.Normal);
				IUnitMotion motion = base.Character.Motion;
				IUnitDriver driver = base.Character.Driver;
				IUnitFacing facing = base.Character.Facing;
				Vector3 vector = ((motion.LinearSpeed > float.Epsilon) ? Vector3.ClampMagnitude(base.Transform.InverseTransformDirection(motion.MoveDirection) / motion.LinearSpeed, 1f) : Vector3.zero);
				Vector3 vector2 = ((motion.LinearSpeed > float.Epsilon) ? (driver.LocalMoveDirection / motion.LinearSpeed) : Vector3.zero);
				float pivotSpeed = facing.PivotSpeed;
				float deltaTime = base.Character.Time.DeltaTime;
				float decay = Mathf.Lerp(1f, 25f, m_SmoothTime);
				m_Animator.SetFloat(K_SPEED_X, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_SPEED_X), vector2.x, decay, deltaTime));
				m_Animator.SetFloat(K_SPEED_Y, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_SPEED_Y), vector2.y, decay, deltaTime));
				m_Animator.SetFloat(K_SPEED_Z, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_SPEED_Z), vector2.z, decay, deltaTime));
				m_Animator.SetFloat(K_SPEED, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_SPEED), vector2.magnitude, decay, deltaTime));
				m_Animator.SetFloat(K_SPEED_XZ, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_SPEED_XZ), vector2.XZ().magnitude, decay, deltaTime));
				m_Animator.SetFloat(K_SPEED_XY, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_SPEED_XY), vector2.XY().magnitude, decay, deltaTime));
				m_Animator.SetFloat(K_SPEED_YZ, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_SPEED_YZ), vector2.YZ().magnitude, decay, deltaTime));
				m_Animator.SetFloat(K_INTENT_X, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_INTENT_X), vector.x, decay, deltaTime));
				m_Animator.SetFloat(K_INTENT_Y, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_INTENT_Y), vector.y, decay, deltaTime));
				m_Animator.SetFloat(K_INTENT_Z, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_INTENT_Z), vector.z, decay, deltaTime));
				m_Animator.SetFloat(K_PIVOT_SPEED, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_PIVOT_SPEED), pivotSpeed, 5f, deltaTime));
				m_Animator.SetFloat(K_GROUNDED, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_GROUNDED), driver.IsGrounded ? 1f : 0f, 10f, deltaTime));
				m_Animator.SetFloat(K_STAND, MathUtils.ExponentialDecay(m_Animator.GetFloat(K_STAND), motion.StandLevel.Current, 5f, deltaTime));
			}
		}
	}
}
